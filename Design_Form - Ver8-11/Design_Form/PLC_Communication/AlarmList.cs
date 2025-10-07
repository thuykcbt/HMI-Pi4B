using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Form.PLC_Communication
{
    public class AlarmList
    {
        public string date_Time { get; set; }
        public bool alarm =false;
        public string name_Code { get; set; }
        public AlarmList(int code_error)
        {
            switch (code_error)
            {
                    case 0:
                    name_Code = "D20.0 Alarm 01 : Servo Ax 1 Not Power On";
                    break;
                    case 1:
                    name_Code = "D20.1 Alarm 02 : Servo Ax 2 Not Power On";
                    break;
                case 2:
                    name_Code = "D20.2 Alarm 03 : Servo Ax 3 Not Power On";
                    break;
                case 3:
                    name_Code = "D20.3 Alarm 04 : Servo Ax 4 Not Power On";
                    break;
                case 4:
                    name_Code = "D20.4 Alarm 05 : Servo Ax 5 Not Power On";
                    break;
                case 5:
                    name_Code = "D20.5 Alarm 06 : Servo Ax 6 Not Power On";
                    break;
                case 6:
                    name_Code = "D20.6 Alarm 07 : Servo Ax 7 Not Power On";
                    break;
                case 7:
                    name_Code = "D20.7 Alarm 08 : Servo Ax 8 Not Power On";
                    break;
                case 8:
                    name_Code = "D20.8 Alarm 09 : Servo Ax 9 Not Power On";
                    break;
                case 9:
                    name_Code = "D20.9 Alarm 10 : Servo Ax 10 Not Power On";
                    break;
                case 10:
                    name_Code = "D20.A Alarm 11 : Servo Ax 1 Error Stop";
                    break;
                case 11:
                    name_Code = "D20.B Alarm 12 : Servo Ax 2 Error Stop";
                    break;
                case 12:
                    name_Code = "D20.C Alarm 13 : Servo Ax 3 Error Stop";
                    break;
                case 13:
                    name_Code = "D20.D Alarm 14 : Servo Ax 4 Error Stop";
                    break;
                case 14:
                    name_Code = "D20.E Alarm 15 : Servo Ax 5 Error Stop";
                    break;
                case 15:
                    name_Code = "D20.F Alarm 16 : Servo Ax 6 Error Stop";
                    break;
                case 16:
                    name_Code = "D21.0 Alarm 17 : Servo Ax 7 Error Stop";
                    break;
                case 17:
                    name_Code = "D21.1 Alarm 18 : Servo Ax 8 Error Stop";
                    break;
                case 18:
                    name_Code = "D21.2 Alarm 19 : Servo Ax 9 Error Stop";
                    break;
                case 19:
                    name_Code = "D21.3 Alarm 20 : Servo Ax 1 Not Home Done";
                    break;
                case 20:
                    name_Code = "D21.4 Alarm 21 : Servo Ax 2 Not Home Done";
                    break;
                case 21:
                    name_Code = "D21.5 Alarm 22 : Servo Ax 3 Not Home Done";
                    break;
                case 22:
                    name_Code = "D21.6 Alarm 23 : Servo Ax 4 Not Home Done";
                    break;
                case 23:
                    name_Code = "D21.7 Alarm 24 : Servo Ax 5 Not Home Done";
                    break;
                case 24:
                    name_Code = "D21.8 Alarm 25 : Servo Ax 6 Not Home Done";
                    break;
                case 25:
                    name_Code = "D21.9 Alarm 26 : Servo Ax 7 Not Home Done";
                    break;
                case 26:
                    name_Code = "D21.A Alarm 27 : Servo Ax 8 Not Home Done";
                    break;
                case 27:
                    name_Code = "D21.B Alarm 28 : Servo Ax 9 Not Home Done";
                    break;
                case 28:
                    name_Code = "D21.C Alarm 29 : Servo Ax 10 Not Home Done";
                    break;
                case 29:
                    name_Code = "D21.D Alarm 30 : Servo Ax 10 Error Stop";
                    break;
                case 30:
                    name_Code = "D21.E Alarm 31 : EMG-Stop is touched Check X06";
                    break;
                case 31:
                    name_Code = "D21.F Alarm 32 : EtherCat Driver Servo Error";
                    break;
                case 32:
                    name_Code = "D22.0 Alarm 33 : X003 Door is Open, Please close the Door";
                    break;
                case 33:
                    name_Code = "D22.1 Alarm 34 : User button stop machine";
                    break;
                case 34:
                    name_Code = "D22.2 Alarm 35 : Cylinder Stopper input Error Check X10,X11,Y10";
                    break;
                case 35:
                    name_Code = "D22.3 Alarm 36 : Cylinder Load Mov Error Check X20,X21,Y20";
                    break;
                case 36:
                    name_Code = "D22.4 Alarm 37 :  Cylinder Load Up/Down Error Check X22,X23,Y21";
                    break;
                case 37:
                    name_Code = "D22.5 Alarm 38 : Vacuum Load Error Check X24,Y22";
                    break;
                case 38:
                    name_Code = "D22.6 Alarm 39 : Vacuum Tool1 Error Check X31,Y31";
                    break;
                case 39:
                    name_Code = "D22.7 Alarm 40 : Cylinder Tool 1 Up/Down Error Check X32,X33,Y30";
                    break;
                case 40:
                    name_Code = "D22.8 Alarm 41 : Vacuum Tool2 Error Check X35,Y34";
                    break;
                case 41:
                    name_Code = "D22.9 Alarm 42 : Cylinder Tool 2 Up/Down Error Check X36,X37,Y33";
                    break;
                case 42:
                    name_Code = "D22.A Alarm 43 : Vacuum Unload NG Error Check X44,Y42";
                    break;
                case 43:
                    name_Code = "D22.B Alarm 44 : Cylinder Unload Mov Error Check X40,X41,Y40";
                    break;
                case 44:
                    name_Code = "D22.C Alarm 45 : Cylinder Unload Up/Down Error Check X42,X43,Y41";
                    break;
                case 45:
                    name_Code = "D22.D Alarm 46 : Vacuum Buffer 2 Error Check X45,Y36";
                    break;
                case 46:
                    name_Code = "D22.E Alarm 47 : Spear";
                    break;
                case 47:
                    name_Code = "D22.F Alarm 48 : Spear";
                    break;
                case 48:
                    name_Code = "D23.0 Alarm 49 : Overtime Wait Input Load X14";
                    break;
                case 49:
                    name_Code = "D23.1 Alarm 50 : Overtime Wait Input Load X15";
                    break;
                case 50:
                    name_Code = "D23.2 Alarm 51 : Overtime Wait Input Buffer 1 X30";
                    break;
                case 51:
                    name_Code = "D23.3 Alarm 52 : Overtime Wait Input Buffer 2 X34";
                    break;
                case 52:
                    name_Code = "D23.4 Alarm 53 : Spear";
                    break;
                case 53:
                    name_Code = "D23.5 Alarm 54 : Spear";
                    break;
                case 54:
                    name_Code = "D23.6 Alarm 55 : Spear";
                    break;
                case 55:
                    name_Code = "D23.7 Alarm 56 : Spear";
                    break;
                case 56:
                    name_Code = "D23.8 Alarm 57 : Spear";
                    break;
                case 57:
                    name_Code = "D23.9 Alarm 58 : Spear";
                    break;
                case 58:
                    name_Code = "D23.A Alarm 59 : Spear";
                    break;
                case 59:
                    name_Code = "D23.B Alarm 60 : Spear";
                    break;
                case 60:
                    name_Code = "D23.C Alarm 61 : Spear";
                    break;
                case 61:
                    name_Code = "D23.D Alarm 62 : Spear";
                    break;
                case 62:
                    name_Code = "D23.E Alarm 63 : Spear";
                    break;
                case 63:
                    name_Code = "D23.F Alarm 64 : Spear";
                    break;

                default:
                    name_Code = "none code error";
                    break;

            }
        }
    }
}
