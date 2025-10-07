using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Design_Form.PLC_Communication
{
    public class ModbusTCP
    {
        public SerialPort Serial = new SerialPort();

        public bool Mode_TCP_Serial = false;

        public int tcpClient_ReceiveTimeout = 3000;

        public bool RTUOverTCP = false;

        private static TcpClient tcpClient;

        public string m_ipAddress = "127.0.0.1";

        public int m_tcpPort = 9007;

        public int ID;

        private static DateTime dtDisconnect = default(DateTime);

        private static DateTime dtNow = default(DateTime);

        public bool NetworkIsOk = false;

        public string Datasending;

        public string DataRecived;

        public int numberOfTX;

        public string ExceptionCode = "";

        public string Status = "";

        public bool ReadHoldRegisterIsError;

        public bool ReadCoilsIsError;

        public bool WriteSingleCoilIsError;

        public bool WriteMultiRegisterIsError;

        public string TX_cmd;

        public string RX_cmd;

        private static readonly string Digits = "0123456789ABCDEF";

        public string ByteTo1Hex(byte b)
        {
            return new string(new char[2]
            {
            Digits[b / 16],
            Digits[b % 16]
            });
        }

        public byte[] CRC16(byte[] data)
        {
            byte[] array = new byte[2];
            ushort num = ushort.MaxValue;
            for (int i = 0; i < data.Length - 2; i++)
            {
                num ^= data[i];
                for (int j = 0; j < 8; j++)
                {
                    num = (((num & 1) != 1) ? ((ushort)(num >> 1)) : ((ushort)((uint)(num >> 1) ^ 0xA001u)));
                }
            }

            array[1] = (byte)((uint)(num >> 8) & 0xFFu);
            array[0] = (byte)(num & 0xFFu);
            return array;
        }

        public string IntToHex(int b)
        {
            string result = "0";
            if (b >= 0 && b < 16)
            {
                switch (b)
                {
                    case 0: { result = "0"; break; }
                    case 1: { result = "1"; break; }
                    case 2: { result = "2"; break; }
                    case 3: { result = "3"; break; }
                    case 4: { result = "4"; break; }
                    case 5: { result = "5"; break; }
                    case 6: { result = "6"; break; }
                    case 7: { result = "7"; break; }
                    case 8: { result = "8"; break; }
                    case 9: { result = "9"; break; }
                    case 10: { result = "A"; break; }
                    case 11: { result = "B"; break; }
                    case 12: { result = "C"; break; }
                    case 13: { result = "D"; break; }
                    case 14: { result = "E"; break; }
                    case 15: { result = "F"; break; }
                    default: { result = "0"; break; }
                }
            }
            return result;

        }

        public string IntToHex2(int b)
        {
            string result = "0";
            if (b >= 0 && b < 256)
            {
                int b2 = b % 16;
                int b3 = b / 16;
                result = IntToHex(b3) + IntToHex(b2);
            }

            return result;
        }

        public bool[] Int8ToBools(int value)
        {
            bool[] array = new bool[8];
            int num = 0;
            int num2 = 0;
            while (value > 0)
            {
                num = value % 2;
                value /= 2;
                array[num2] = Convert.ToBoolean(num);
                num2++;
            }

            return array;
        }

        public bool[] Int16ToBools(int value)
        {
            bool[] array = new bool[16];
            int num = 0;
            int num2 = 0;
            while (value > 0)
            {
                num = value % 2;
                value /= 2;
                array[num2] = Convert.ToBoolean(num);
                num2++;
            }

            return array;
        }

        public bool[] Int32ToBools(int value)
        {
            bool[] array = new bool[32];
            int num = 0;
            int num2 = 0;
            while (value > 0)
            {
                num = value % 2;
                value /= 2;
                array[num2] = Convert.ToBoolean(num);
                num2++;
            }

            return array;
        }

        public bool[] Hex8ToBools(string value)
        {
            int value2 = HexToInt8(value);
            return Int8ToBools(value2);
        }

        public int HexToInt8(string Hexstring)
        {
            if (Hexstring.Length == 0 || Hexstring.Length > 2)
            {
                return 0;
            }

            if (Hexstring.Length == 2)
            {
                string hexString = Hexstring.Substring(0, 1);
                string hexString2 = Hexstring.Substring(1, 1);
                int num = HexToInt4(hexString);
                int num2 = HexToInt4(hexString2);
                return num * 16 + num2;
            }

            return HexToInt4(Hexstring);
        }

        public int HexToInt4(string HexString)
        {
            int result;
            switch (HexString)
            {
                case "0": { result = 0; break; }
                case "1": { result = 1; break; }
                case "2": { result = 2; break; }
                case "3": { result = 3; break; }
                case "4": { result = 4; break; }
                case "5": { result = 5; break; }
                case "6": { result = 6; break; }
                case "7": { result = 7; break; }
                case "8": { result = 8; break; }
                case "9": { result = 9; break; }
                case "A": { result = 10; break; }
                case "B": { result = 11; break; }
                case "C": { result = 12; break; }
                case "D": { result = 13; break; }
                case "E": { result = 14; break; }
                case "F": { result = 15; break; }
                default: { result = 0; break; }
            }
            return result;
        }

        public bool ConnectTCP(string ipAddress, int tcpPort)
        {
            Mode_TCP_Serial = false;
            return Connect1(ipAddress, tcpPort);
        }

        public bool ConnectSerial()
        {
            Mode_TCP_Serial = true;
            try
            {
                if (!Serial.IsOpen)
                {
                    Serial.Open();
                }

                ExceptionCode = "";
                return true;
            }
            catch (Exception ex)
            {
                ExceptionCode = ex.ToString();
                return false;
            }
        }

        private static bool CheckInternet()
        {
            return true;
        }

        private bool Connect1(string ipAddress, int tcpPort)
        {
            m_ipAddress = ipAddress;
            m_tcpPort = tcpPort;
            if (tcpClient != null)
            {
                tcpClient.Close();
            }

            tcpClient = new TcpClient();
            if (CheckInternet())
            {
                try
                {
                    IAsyncResult asyncResult = tcpClient.BeginConnect(ipAddress, tcpPort, null, null);
                    asyncResult.AsyncWaitHandle.WaitOne(2000, exitContext: true);
                    if (!asyncResult.IsCompleted)
                    {
                        tcpClient.Close();
                        ExceptionCode = "ERROR" + DateTime.Now.ToString() + ":Cannot connect to server.";
                        Console.WriteLine(ExceptionCode);
                        return false;
                    }

                    ExceptionCode = "";
                    Status = DateTime.Now.ToString() + ":Connected to server.";
                    NetworkIsOk = true;
                    return true;
                }
                catch (Exception ex)
                {
                    ExceptionCode = "ERROR" + DateTime.Now.ToString() + ":Connect process " + ex.StackTrace + "==>" + ex.Message;
                    Console.WriteLine(DateTime.Now.ToString() + ":Connect process " + ex.StackTrace + "==>" + ex.Message);
                    NetworkIsOk = false;
                    return false;
                }
            }

            return false;
        }

        private void Reconnect()
        {
            try
            {
                if (NetworkIsOk)
                {
                    return;
                }

                dtNow = DateTime.Now;
                if (dtNow - dtDisconnect > TimeSpan.FromSeconds(10.0))
                {
                    Console.WriteLine(DateTime.Now.ToString() + ":Start connecting");
                    NetworkIsOk = Connect1(m_ipAddress, m_tcpPort);
                    if (!NetworkIsOk)
                    {
                        ExceptionCode = "ERROR" + DateTime.Now.ToString() + ":Connecting fail. Wait for retry";
                        Console.WriteLine(ExceptionCode);
                        dtDisconnect = DateTime.Now;
                    }
                }
                else
                {
                    Console.WriteLine(DateTime.Now.ToString() + ":Wait for retry connecting");
                }
            }
            catch (Exception ex)
            {
                if (ex.Source.Equals("System"))
                {
                    NetworkIsOk = false;
                    Console.WriteLine(ex.Message);
                    dtDisconnect = DateTime.Now;
                }
            }
        }

        public void Disconnect()
        {
            if (NetworkIsOk)
            {
                tcpClient.Close();
            }
        }

        public int[] ReadHoldingRegistersTCPIP(int startAddress, int numberOfPoints)
        {
            int maxRegistersPerRequest = 125; // Giới hạn theo Modbus TCP
            List<int> result = new List<int>();
            int index = 0;

            while (index < numberOfPoints)
            {
                int chunkSize = Math.Min(maxRegistersPerRequest, numberOfPoints - index);
                int[] chunkData = ReadHoldingRegistersChunk(startAddress + index, chunkSize);
                result.AddRange(chunkData);
                index += chunkSize;
            }

            return result.ToArray();
        }
        private int[] ReadHoldingRegistersChunk(int startAddress, int numberOfPoints)
        {
            // Code xử lý đọc với numberOfPoints nhỏ hơn 125
            int[] array = new int[numberOfPoints];
            int value = startAddress / 256;
            int value2 = startAddress % 256;
            int value3 = numberOfPoints % 256;
            int value4 = numberOfPoints / 256;
            int value5 = numberOfTX % 256;
            int value6 = numberOfTX / 256;
            byte[] array2 = new byte[12]
            {
            Convert.ToByte(value6),
            Convert.ToByte(value5),
            0,
            0,
            0,
            6,
            Convert.ToByte(ID),
            3,
            Convert.ToByte(value),
            Convert.ToByte(value2),
            Convert.ToByte(value4),
            Convert.ToByte(value3)
            };
            TX_cmd = "";
            for (int i = 0; i < 12; i++)
            {
                string text = IntToHex2(array2[i]);
                TX_cmd = TX_cmd + text + " ";
            }

            try
            {
                tcpClient.ReceiveTimeout = tcpClient_ReceiveTimeout;
                tcpClient.Client.Send(array2);
                byte[] array3 = new byte[500];
                int num = tcpClient.Client.Receive(array3);
                RX_cmd = "";
                for (int j = 0; j < num; j++)
                {
                    string text2 = IntToHex2(array3[j]);
                    RX_cmd = RX_cmd + text2 + " ";
                }

                if (num > 2)
                {
                    if (array3[0] == array2[0] && array3[1] == array2[1] && array3[6] == array2[6] && array3[7] == array2[7] && array3[8] != 83)
                    {
                        numberOfTX++;
                        if (numberOfTX > 65535)
                        {
                            numberOfTX = 0;
                        }

                        ReadHoldRegisterIsError = false;
                        Status = "ReadHoldingRegisters is OK " + numberOfTX;
                        for (int k = 0; k < numberOfPoints; k++)
                        {
                            array[k] = array3[9 + k * 2] * 256 + array3[10 + k * 2];
                        }

                        ExceptionCode = "";
                    }
                    else
                    {
                        if (array3[0] != array2[0] || array3[1] != array2[1])
                        {
                            int num2 = array3[0] * 256 + array3[1];
                            ExceptionCode = "ERROR! Modbus ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "Number of TX is " + numberOfTX + Environment.NewLine + "Number of RX is " + num2 + Environment.NewLine + "No Matching";
                        }

                        if (array3[5] == 0 && num == 6)
                        {
                            ExceptionCode = "ERROR! Modbus ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "Modbus have sent a wrong address ID to Slave device";
                        }

                        if (array3[7] == 131 && array3[8] == 1)
                        {
                            ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL FUNCTION";
                        }

                        if (array3[7] == 131 && array3[8] == 2)
                        {
                            ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL DATA ADDRESS";
                        }

                        if (array3[7] == 131 && array3[8] == 3)
                        {
                            ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL DATA VALUE";
                        }

                        if (array3[7] == 131 && array3[8] == 4)
                        {
                            ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "SLAVE DEVICE FAILURE";
                        }

                        ReadHoldRegisterIsError = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionCode = ex.ToString();
                NetworkIsOk = false;
                Reconnect();
                ReadHoldRegisterIsError = true;
            }

            return array;
        }
        public int[] ReadHoldingRegistersRTU(int startAddress, int numberOfPoints)
        {
            int[] array = new int[numberOfPoints];
            int value = startAddress / 256;
            int value2 = startAddress % 256;
            int value3 = numberOfPoints % 256;
            int value4 = numberOfPoints / 256;
            int num = numberOfTX % 256;
            int num2 = numberOfTX / 256;
            byte[] array2 = new byte[8]
            {
            Convert.ToByte(ID),
            3,
            Convert.ToByte(value),
            Convert.ToByte(value2),
            Convert.ToByte(value4),
            Convert.ToByte(value3),
            0,
            0
            };
            byte[] array3 = CRC16(array2);
            array2[6] = array3[0];
            array2[7] = array3[1];
            TX_cmd = "";
            for (int i = 0; i < 8; i++)
            {
                string text = IntToHex2(array2[i]);
                TX_cmd = TX_cmd + text + " ";
            }

            try
            {
                byte[] array4 = new byte[500];
                int num3 = 0;
                if (!Mode_TCP_Serial)
                {
                    tcpClient.ReceiveTimeout = tcpClient_ReceiveTimeout;
                    tcpClient.Client.Send(array2);
                    num3 = tcpClient.Client.Receive(array4);
                }
                else
                {
                    Serial.Write(array2, 0, array2.Length);
                    int num4 = 0;
                    int num5 = 0;
                    for (int j = 0; j < 200000; j++)
                    {
                        int bytesToRead = Serial.BytesToRead;
                        if (bytesToRead > 2)
                        {
                            if (bytesToRead != num4)
                            {
                                num4 = bytesToRead;
                                num5 = 0;
                            }
                            else
                            {
                                num5++;
                            }

                            if (num5 > 10000)
                            {
                                break;
                            }
                        }
                    }

                    num3 = Serial.BytesToRead;
                    if (num3 <= 0)
                    {
                        throw new Exception("Recived Timeout!");
                    }

                    Serial.Read(array4, 0, num3);
                }

                RX_cmd = "";
                for (int k = 0; k < num3; k++)
                {
                    string text2 = IntToHex2(array4[k]);
                    RX_cmd = RX_cmd + text2 + " ";
                }

                if (num3 > 2)
                {
                    if (array4[0] == array2[0] && array4[1] == array2[1])
                    {
                        numberOfTX++;
                        if (numberOfTX > 65535)
                        {
                            numberOfTX = 0;
                        }

                        ReadHoldRegisterIsError = false;
                        Status = "ReadHoldingRegisters is OK " + numberOfTX;
                        for (int l = 0; l < numberOfPoints; l++)
                        {
                            array[l] = array4[3 + l * 2] * 256 + array4[4 + l * 2];
                        }

                        ExceptionCode = "";
                    }
                    else
                    {
                        if (array4[1] == 131 && array4[2] == 1)
                        {
                            ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL FUNCTION";
                        }

                        if (array4[1] == 131 && array4[2] == 2)
                        {
                            ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL DATA ADDRESS";
                        }

                        if (array4[1] == 131 && array4[2] == 3)
                        {
                            ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL DATA VALUE";
                        }

                        if (array4[1] == 131 && array4[2] == 4)
                        {
                            ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "SLAVE DEVICE FAILURE";
                        }

                        ReadHoldRegisterIsError = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionCode = ex.ToString();
                NetworkIsOk = false;
                if (!Mode_TCP_Serial)
                {
                    Reconnect();
                }

                ReadHoldRegisterIsError = true;
            }

            return array;
        }

        public bool[] ReadCoilsTCPIP(int startAddress, int numberOfPoints)
        {
            bool[] array = new bool[numberOfPoints];
            int value = startAddress / 256;
            int value2 = startAddress % 256;
            int value3 = numberOfPoints % 256;
            int value4 = numberOfPoints / 256;
            int value5 = numberOfTX % 256;
            int value6 = numberOfTX / 256;
            byte[] array2 = new byte[12]
            {
            Convert.ToByte(value6),
            Convert.ToByte(value5),
            0,
            0,
            0,
            6,
            Convert.ToByte(ID),
            1,
            Convert.ToByte(value),
            Convert.ToByte(value2),
            Convert.ToByte(value4),
            Convert.ToByte(value3)
            };
            TX_cmd = "";
            for (int i = 0; i < 12; i++)
            {
                string text = IntToHex2(array2[i]);
                TX_cmd = TX_cmd + text + " ";
            }

            try
            {
                tcpClient.ReceiveTimeout = tcpClient_ReceiveTimeout;
                tcpClient.Client.Send(array2);
                byte[] array3 = new byte[500];
                int num = tcpClient.Client.Receive(array3);
                RX_cmd = "";
                for (int j = 0; j < num; j++)
                {
                    string text2 = IntToHex2(array3[j]);
                    RX_cmd = RX_cmd + text2 + " ";
                }

                if (num > 2)
                {
                    if (array3[0] == array2[0] && array3[1] == array2[1] && array3[5] != 0 && array3[6] == array2[6] && array3[7] == array2[7] && array3[8] != 83 && array3[9] != 2)
                    {
                        numberOfTX++;
                        if (numberOfTX > 65535)
                        {
                            numberOfTX = 0;
                        }

                        ReadCoilsIsError = false;
                        Status = "ReadCoils is OK " + numberOfTX;
                        for (int k = 0; k < array3[8]; k++)
                        {
                            bool[] array4 = new bool[8];
                            array4 = Int8ToBools(array3[k + 9]);
                            for (int l = 0; l < 8; l++)
                            {
                                array[l + 8 * k] = array4[l];
                            }
                        }

                        ExceptionCode = "";
                    }
                    else
                    {
                        if (array3[0] != array2[0] || array3[1] != array2[1])
                        {
                            int num2 = array3[0] * 256 + array3[1];
                            ExceptionCode = "ERROR! Modbus ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "Number of TX is " + numberOfTX + Environment.NewLine + "Number of RX is " + num2 + Environment.NewLine + "No Matching";
                        }

                        if (array3[7] == 131 && array3[8] == 1)
                        {
                            ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL FUNCTION";
                        }

                        if (array3[7] == 131 && array3[8] == 2)
                        {
                            ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL DATA ADDRESS";
                        }

                        if (array3[7] == 131 && array3[8] == 3)
                        {
                            ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL DATA VALUE";
                        }

                        if (array3[7] == 131 && array3[8] == 4)
                        {
                            ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "SLAVE DEVICE FAILURE";
                        }

                        ReadCoilsIsError = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionCode = ex.ToString();
                NetworkIsOk = false;
                Reconnect();
                ReadCoilsIsError = true;
            }

            return array;
        }

        public bool[] ReadCoilsRTU(int startAddress, int numberOfPoints)
        {
            bool[] array = new bool[numberOfPoints];
            int value = startAddress / 256;
            int value2 = startAddress % 256;
            int value3 = numberOfPoints % 256;
            int value4 = numberOfPoints / 256;
            byte[] array2 = new byte[8]
            {
            Convert.ToByte(ID),
            1,
            Convert.ToByte(value),
            Convert.ToByte(value2),
            Convert.ToByte(value4),
            Convert.ToByte(value3),
            0,
            0
            };
            byte[] array3 = CRC16(array2);
            array2[6] = array3[0];
            array2[7] = array3[1];
            TX_cmd = "";
            for (int i = 0; i < 8; i++)
            {
                string text = IntToHex2(array2[i]);
                TX_cmd = TX_cmd + text + " ";
            }

            try
            {
                byte[] array4 = new byte[500];
                int num = 0;
                if (!Mode_TCP_Serial)
                {
                    tcpClient.ReceiveTimeout = tcpClient_ReceiveTimeout;
                    tcpClient.Client.Send(array2);
                    num = tcpClient.Client.Receive(array4);
                }
                else
                {
                    Serial.Write(array2, 0, array2.Length);
                    for (int j = 0; j < 10000; j++)
                    {
                        if (Serial.BytesToRead > 2)
                        {
                            break;
                        }
                    }

                    num = Serial.BytesToRead;
                    if (num <= 0)
                    {
                        throw new Exception("Recived Timeout!");
                    }

                    Serial.Read(array4, 0, num);
                }

                RX_cmd = "";
                for (int k = 0; k < num; k++)
                {
                    string text2 = IntToHex2(array4[k]);
                    RX_cmd = RX_cmd + text2 + " ";
                }

                if (num > 2)
                {
                    if (array4[0] == array2[0] && array4[1] == array2[1])
                    {
                        ReadCoilsIsError = false;
                        Status = "ReadCoils is OK " + numberOfTX;
                        for (int l = 0; l < array4[2]; l++)
                        {
                            bool[] array5 = new bool[8];
                            array5 = Int8ToBools(array4[l + 3]);
                            for (int m = 0; m < 8; m++)
                            {
                                array[m + 8 * l] = array5[m];
                            }
                        }

                        ExceptionCode = "";
                    }
                    else
                    {
                        if (array4[1] == 131 && array4[2] == 1)
                        {
                            ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL FUNCTION";
                        }

                        if (array4[1] == 131 && array4[2] == 2)
                        {
                            ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL DATA ADDRESS";
                        }

                        if (array4[1] == 131 && array4[2] == 3)
                        {
                            ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL DATA VALUE";
                        }

                        if (array4[1] == 131 && array4[2] == 4)
                        {
                            ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "SLAVE DEVICE FAILURE";
                        }

                        ReadCoilsIsError = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionCode = ex.ToString();
                NetworkIsOk = false;
                if (!Mode_TCP_Serial)
                {
                    Reconnect();
                }

                ReadCoilsIsError = true;
            }

            return array;
        }

        public void WriteSingleCoilTCPIP(int coilAddress, bool value)
        {
            int value2 = coilAddress / 256;
            int value3 = coilAddress % 256;
            int value4 = 0;
            int value5 = (value ? 255 : 0);
            int value6 = numberOfTX % 256;
            int value7 = numberOfTX / 256;
            byte[] array = new byte[12]
            {
            Convert.ToByte(value7),
            Convert.ToByte(value6),
            0,
            0,
            0,
            6,
            Convert.ToByte(ID),
            5,
            Convert.ToByte(value2),
            Convert.ToByte(value3),
            Convert.ToByte(value5),
            Convert.ToByte(value4)
            };
            TX_cmd = "";
            for (int i = 0; i < 12; i++)
            {
                string text = IntToHex2(array[i]);
                TX_cmd = TX_cmd + text + " ";
            }

            try
            {
                tcpClient.ReceiveTimeout = 3000;
                tcpClient.Client.Send(array);
                byte[] array2 = new byte[500];
                int num = tcpClient.Client.Receive(array2);
                RX_cmd = "";
                for (int j = 0; j < num; j++)
                {
                    string text2 = IntToHex2(array2[j]);
                    RX_cmd = RX_cmd + text2 + " ";
                }

                if (num <= 2)
                {
                    return;
                }

                if (array2[0] == array[0] && array2[1] == array[1] && array2[5] != 0 && array2[6] == array[6] && array2[7] == array[7] && array2[8] != 83 && array2[9] != 2)
                {
                    numberOfTX++;
                    if (numberOfTX > 65535)
                    {
                        numberOfTX = 0;
                    }

                    WriteSingleCoilIsError = false;
                    Status = "WriteSingleCoil is OK " + numberOfTX;
                    ExceptionCode = "";
                    return;
                }

                if (array2[0] != array[0] || array2[1] != array[1])
                {
                    int num2 = array2[0] * 256 + array2[1];
                    ExceptionCode = "ERROR! Modbus ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "Number of TX is " + numberOfTX + Environment.NewLine + "Number of RX is " + num2 + Environment.NewLine + "No Matching";
                }

                if (array2[5] == 0 && num == 6)
                {
                    ExceptionCode = "ERROR! Modbus ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "Modbus have sent a wrong address ID to Slave device";
                }

                if (array2[7] == 131 && array2[8] == 1)
                {
                    ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL FUNCTION";
                }

                if (array2[7] == 131 && array2[8] == 2)
                {
                    ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL DATA ADDRESS";
                }

                if (array2[7] == 131 && array2[8] == 3)
                {
                    ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL DATA VALUE";
                }

                if (array2[7] == 131 && array2[8] == 4)
                {
                    ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "SLAVE DEVICE FAILURE";
                }

                WriteSingleCoilIsError = true;
            }
            catch (Exception ex)
            {
                ExceptionCode = ex.ToString();
                NetworkIsOk = false;
                Reconnect();
                WriteSingleCoilIsError = true;
            }
        }

        public void WriteSingleCoilRTU(int coilAddress, bool value)
        {
            int value2 = coilAddress / 256;
            int value3 = coilAddress % 256;
            int value4 = 0;
            int value5 = (value ? 255 : 0);
            byte[] array = new byte[8]
            {
            Convert.ToByte(ID),
            5,
            Convert.ToByte(value2),
            Convert.ToByte(value3),
            Convert.ToByte(value5),
            Convert.ToByte(value4),
            0,
            0
            };
            byte[] array2 = CRC16(array);
            array[6] = array2[0];
            array[7] = array2[1];
            TX_cmd = "";
            for (int i = 0; i < 8; i++)
            {
                string text = IntToHex2(array[i]);
                TX_cmd = TX_cmd + text + " ";
            }

            Console.WriteLine(TX_cmd);
            try
            {
                byte[] array3 = new byte[500];
                int num = 0;
                if (!Mode_TCP_Serial)
                {
                    tcpClient.ReceiveTimeout = tcpClient_ReceiveTimeout;
                    tcpClient.Client.Send(array);
                    num = tcpClient.Client.Receive(array3);
                }
                else
                {
                    Serial.Write(array, 0, array.Length);
                    int num2 = 0;
                    int num3 = 0;
                    for (int j = 0; j < 200000; j++)
                    {
                        int bytesToRead = Serial.BytesToRead;
                        if (bytesToRead > 2)
                        {
                            if (bytesToRead != num2)
                            {
                                num2 = bytesToRead;
                                num3 = 0;
                            }
                            else
                            {
                                num3++;
                            }

                            if (num3 > 10000)
                            {
                                break;
                            }
                        }
                    }

                    num = Serial.BytesToRead;
                    if (num <= 0)
                    {
                        throw new Exception("Recived Timeout!");
                    }

                    Serial.Read(array3, 0, num);
                }

                RX_cmd = "";
                for (int k = 0; k < num; k++)
                {
                    string text2 = IntToHex2(array3[k]);
                    RX_cmd = RX_cmd + text2 + " ";
                }

                if (num <= 2)
                {
                    return;
                }

                if (array3[0] == array[0] && array3[1] == array[1])
                {
                    numberOfTX++;
                    if (numberOfTX > 65535)
                    {
                        numberOfTX = 0;
                    }

                    WriteSingleCoilIsError = false;
                    Status = "WriteSingleCoil is OK " + numberOfTX;
                    ExceptionCode = "";
                    return;
                }

                if (array3[1] == 131 && array3[2] == 1)
                {
                    ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL FUNCTION";
                }

                if (array3[1] == 131 && array3[2] == 2)
                {
                    ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL DATA ADDRESS";
                }

                if (array3[1] == 131 && array3[2] == 3)
                {
                    ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL DATA VALUE";
                }

                if (array3[1] == 131 && array3[2] == 4)
                {
                    ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "SLAVE DEVICE FAILURE";
                }

                WriteSingleCoilIsError = true;
            }
            catch (Exception ex)
            {
                ExceptionCode = ex.ToString();
                NetworkIsOk = false;
                if (!Mode_TCP_Serial)
                {
                    Reconnect();
                }

                WriteSingleCoilIsError = true;
            }
        }

        public void WriteMultipleRegisters(int startAddress, int[] data)
        {
            int num = data.Length * 2 + 7;
            int value = startAddress / 256;
            int value2 = startAddress % 256;
            int value3 = data.Length % 256;
            int value4 = data.Length / 256;
            int value5 = numberOfTX % 256;
            int value6 = numberOfTX / 256;
            int value7 = num % 256;
            int num2 = num / 256;
            byte[] array = new byte[13 + data.Length * 2];
            array[0] = Convert.ToByte(value6);
            array[1] = Convert.ToByte(value5);
            array[2] = 0;
            array[3] = 0;
            array[4] = 0;
            array[5] = Convert.ToByte(value7);
            array[6] = Convert.ToByte(ID);
            array[7] = 16;
            array[8] = Convert.ToByte(value);
            array[9] = Convert.ToByte(value2);
            array[10] = Convert.ToByte(value4);
            array[11] = Convert.ToByte(value3);
            array[12] = Convert.ToByte(data.Length * 2);
            for (int i = 0; i < data.Length; i++)
            {
                int value8 = data[i] % 256;
                int value9 = data[i] / 256;
                array[13 + i * 2] = Convert.ToByte(value9);
                array[14 + i * 2] = Convert.ToByte(value8);
            }

            TX_cmd = "";
            for (int j = 0; j < array.Length; j++)
            {
                string text = IntToHex2(array[j]);
                TX_cmd = TX_cmd + text + " ";
            }

            try
            {
                tcpClient.ReceiveTimeout = 3000;
                tcpClient.Client.Send(array);
                byte[] array2 = new byte[500];
                int num3 = tcpClient.Client.Receive(array2);
                RX_cmd = "";
                for (int k = 0; k < num3; k++)
                {
                    string text2 = IntToHex2(array2[k]);
                    RX_cmd = RX_cmd + text2 + " ";
                }

                if (num3 <= 2)
                {
                    return;
                }

                if (array2[0] == array[0] && array2[1] == array[1] && array2[5] != 0 && array2[6] == array[6] && array2[7] == array[7] && array2[8] != 83 && array2[9] != 2)
                {
                    numberOfTX++;
                    if (numberOfTX > 65535)
                    {
                        numberOfTX = 0;
                    }

                    WriteMultiRegisterIsError = false;
                    Status = "WriteMultiRegister is OK " + numberOfTX;
                    ExceptionCode = "";
                    return;
                }

                if (array2[0] != array[0] || array2[1] != array[1])
                {
                    int num4 = array2[0] * 256 + array2[1];
                    ExceptionCode = "ERROR! Modbus ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "Number of TX is " + numberOfTX + Environment.NewLine + "Number of RX is " + num4 + Environment.NewLine + "No Matching";
                }

                if (array2[5] == 0 && num3 == 6)
                {
                    ExceptionCode = "ERROR! Modbus ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "Modbus have sent a wrong address ID to Slave device";
                }

                if (array2[7] == 131 && array2[8] == 1)
                {
                    ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL FUNCTION";
                }

                if (array2[7] == 131 && array2[8] == 2)
                {
                    ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL DATA ADDRESS";
                }

                if (array2[7] == 131 && array2[8] == 3)
                {
                    ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL DATA VALUE";
                }

                if (array2[7] == 131 && array2[8] == 4)
                {
                    ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "SLAVE DEVICE FAILURE";
                }

                WriteMultiRegisterIsError = true;
            }
            catch (Exception ex)
            {
                ExceptionCode = ex.ToString();
                NetworkIsOk = false;
                if (!Mode_TCP_Serial)
                {
                    Reconnect();
                }

                WriteMultiRegisterIsError = true;
            }
        }

        public void WriteMultipleRegistersRTU(int startAddress, int[] data)
        {
            int num = data.Length * 2 + 7;
            int value = startAddress / 256;
            int value2 = startAddress % 256;
            int value3 = data.Length % 256;
            int value4 = data.Length / 256;
            byte[] array = new byte[9 + data.Length * 2];
            array[0] = Convert.ToByte(ID);
            array[1] = 16;
            array[2] = Convert.ToByte(value);
            array[3] = Convert.ToByte(value2);
            array[4] = Convert.ToByte(value4);
            array[5] = Convert.ToByte(value3);
            array[6] = Convert.ToByte(data.Length * 2);
            for (int i = 0; i < data.Length; i++)
            {
                int value5 = data[i] % 256;
                int value6 = data[i] / 256;
                array[7 + i * 2] = Convert.ToByte(value6);
                array[8 + i * 2] = Convert.ToByte(value5);
            }

            byte[] array2 = CRC16(array);
            array[array.Length - 2] = array2[0];
            array[array.Length - 1] = array2[1];
            TX_cmd = "";
            for (int j = 0; j < array.Length; j++)
            {
                string text = IntToHex2(array[j]);
                TX_cmd = TX_cmd + text + " ";
            }

            try
            {
                byte[] array3 = new byte[500];
                int num2 = 0;
                if (!Mode_TCP_Serial)
                {
                    tcpClient.ReceiveTimeout = tcpClient_ReceiveTimeout;
                    tcpClient.Client.Send(array);
                    num2 = tcpClient.Client.Receive(array3);
                }
                else
                {
                    Serial.Write(array, 0, array.Length);
                    int num3 = 0;
                    int num4 = 0;
                    for (int k = 0; k < 200000; k++)
                    {
                        int bytesToRead = Serial.BytesToRead;
                        if (bytesToRead > 2)
                        {
                            if (bytesToRead != num3)
                            {
                                num3 = bytesToRead;
                                num4 = 0;
                            }
                            else
                            {
                                num4++;
                            }

                            if (num4 > 10000)
                            {
                                break;
                            }
                        }
                    }

                    num2 = Serial.BytesToRead;
                    if (num2 <= 0)
                    {
                        throw new Exception("Recived Timeout!");
                    }

                    Serial.Read(array3, 0, num2);
                }

                RX_cmd = "";
                for (int l = 0; l < num2; l++)
                {
                    string text2 = IntToHex2(array3[l]);
                    RX_cmd = RX_cmd + text2 + " ";
                }

                if (num2 <= 2)
                {
                    return;
                }

                if (array3[0] == array[0] && array3[1] == array[1])
                {
                    numberOfTX++;
                    if (numberOfTX > 65535)
                    {
                        numberOfTX = 0;
                    }

                    WriteMultiRegisterIsError = false;
                    Status = "WriteMultiRegister is OK " + numberOfTX;
                    ExceptionCode = "";
                    return;
                }

                if (array3[1] == 131 && array3[2] == 1)
                {
                    ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL FUNCTION";
                }

                if (array3[1] == 131 && array3[2] == 2)
                {
                    ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL DATA ADDRESS";
                }

                if (array3[1] == 131 && array3[2] == 3)
                {
                    ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "ILLEGAL DATA VALUE";
                }

                if (array3[1] == 131 && array3[2] == 4)
                {
                    ExceptionCode = "ERROR! Modbus error ReadHoldingRegisters! SlaveID: " + ID + Environment.NewLine + "SLAVE DEVICE FAILURE";
                }

                WriteMultiRegisterIsError = true;
            }
            catch (Exception ex)
            {
                ExceptionCode = ex.ToString();
                NetworkIsOk = false;
                if (!Mode_TCP_Serial)
                {
                    Reconnect();
                }

                WriteMultiRegisterIsError = true;
            }
        }
    }
}
