﻿using DevExpress.Data.Linq.Helpers;
//using DevExpress.Drawing;
//using DevExpress.Drawing.Internal.Fonts.Interop;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.Utils.CommonDialogs;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars.Docking2010.Dragging;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.DataNodes;
using DevExpress.XtraSpellChecker.Parser;
using HalconDotNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Design_Form.Job_Model
{
    public class Model
    {
        public List<Class_Camera> Cameras = new List<Class_Camera>();
        public string Name_Model { get; set; } = "none";
        public int ID = 1;
        public int total_camera = 1;
        public string File_Path_Image { get; set; }
        public string file_model { get; set; }
        public string image1_model = "D:\\01. Workspace\\01. Vision\\Design_Form - Ver7\\Image_Model\\Face_A.jpg";
        public string image2_model = "D:\\01. Workspace\\01. Vision\\Design_Form - Ver7\\Image_Model\\Face_C.jpg";
        public string image3_model = "D:\\01. Workspace\\01. Vision\\Design_Form - Ver7\\Image_Model\\Face_B.jpg";
        public Model Clone()
        {
            string jobjson = JsonConvert.SerializeObject(this, Formatting.Indented);
            return JsonConvert.DeserializeObject<Model>(jobjson);
        }
    }
    public class Class_Camera
    {
        public List<Class_Job> Jobs = new List<Class_Job>();
        private string name;
        private string device;
       
        public Class_Camera() { }
        public Class_Camera(string Name, string Device)
        {
            this.name = Name;
            this.device = Device;
        }
    }
    public class Class_Job
    {
        public string JobName { get; set; }
    
        public string result_job = "OK";
        public int Exposure = 1300;
        public int Brightness = 0;
        public int Contrast = 512;
        public List<Roi_tool> roi_Tool = new List<Roi_tool>();
        public List<string> Name_Item_check = new List<string>();
        public bool auto_check =false;
        public string File_Path_Image { get; set; }
        public string Face_Check { get; set; }
        public List<Class_Image> Images = new List<Class_Image>();
        public void ExecuteAllImge(HWindow hWindow, HObject ho_Image)
        {

            result_job = "OK";
            foreach (Class_Image Images in Images)
            {

                Images.Excute(hWindow, ho_Image);
                //  ho_Image = Job_Model.Statatic_Model.Input_Image[tool.camera_index, tool.job_index, 0];
                if (Images.result_Image=="NG")
                    result_job = "NG";
            }
            dev_display_ok_nok(result_job, hWindow);
        }

       
       
        public void dev_display_ok_nok(string result, HWindow Display)
        {
            HTuple hv_Text = new HTuple(), hv_BoxColor = new HTuple();
            // Initialize local and output iconic variables 
            try
            {
                if (result =="Unknow")
                {
                    hv_Text.Dispose();
                    hv_Text = "NG";
                    hv_BoxColor.Dispose();
                    hv_BoxColor = "red";
                }
                else if (result == "NG")
                {
                    hv_Text.Dispose();
                    hv_Text = "NG";
                    hv_BoxColor.Dispose();
                    hv_BoxColor = "red";
                }
                else
                {
                    hv_Text.Dispose();
                    hv_Text = "OK";
                    hv_BoxColor.Dispose();
                    hv_BoxColor = "green";
                }
                Job_Model.Display set_display_font = new Job_Model.Display();
                set_display_font.set_font(Display, 50, "mono", "true", "false");
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    HOperatorSet.DispText(
                        Display
                        , hv_Text
                        , "window"
                        , "top"
                        , "right"
                        , "black"
                        , (new HTuple("box_color")).TupleConcat("shadow")
                        , hv_BoxColor.TupleConcat("false"));
                }
                set_display_font.set_font(Display, 10, "mono", "true", "false");
                HOperatorSet.FlushBuffer(Display);
                hv_Text.Dispose();
                hv_BoxColor.Dispose();
                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                hv_Text.Dispose();
                hv_BoxColor.Dispose();
                throw HDevExpDefaultException;
            }
        }

        public Class_Job Clone()
        {
            string jobjson = JsonConvert.SerializeObject(this, Formatting.Indented);
            return JsonConvert.DeserializeObject<Class_Job>(jobjson);
        }

    }
    public class Class_Image
    {
        public string result_Image = "OK";
        public bool auto_check = false;
        public List<Class_Tool> Tools = new List<Class_Tool>();
        public void AddTool(Class_Tool tool)
        {
            Tools.Add(tool);
        }
        public void Excute(HWindow hWindow, HObject ho_Image)
        { }
        public void ExecuteAllTools(HWindow hWindow, HObject ho_Image)
        {

            result_Image = "OK";
            foreach (Class_Tool tool in Tools)
            {
                if (auto_check)
                {
                    tool.show_text = false;
                }
                else
                {
                    tool.show_text = true;
                }
                tool.Excute(hWindow, ho_Image);
                //  ho_Image = Job_Model.Statatic_Model.Input_Image[tool.camera_index, tool.job_index, 0];
                if (!tool.Result_Tool)
                    result_Image = "NG";
            }
          
        }
    }
    public abstract class Class_Tool
    {
        
        public List<Roi_tool> roi_Tool = new List<Roi_tool>();
        public string item_check;
        public int camera_index {  get; set; }
        public int job_index {  get; set; }
        public int tool_index {  get; set; }

        public int image_index { get; set; }    
        public int index_follow { get; set; } = -1;
        public double cali { get; set; } = 1;
        public bool Result_Tool {  get; set; } = false;
        public string ToolName { get; set; }
        public bool stepbystep { get; set; } =false;
        public int threshold_Max { get; set; } = 255;
        public int threshold_Min { get; set; } = 125;
        public int index_input_Image { get; set; } = 0;
        public bool camera_color = false;
        public bool show_text = false;
        public string file_load { get; set; }
        public abstract void Excute(HWindow hWindow, HObject ho_Image);
        public abstract void Excute_OnlyTool(HWindow hWindow, HObject ho_Image);
        public void Draw_Hwindow(HWindow hWindow, HObject re_gion)
        {
            if(Result_Tool)
            {

            }
            else
            {

            }    
        }
        public Class_Tool(string toolName)
        {
            ToolName = toolName;
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public void align_Roi(int index_follow, int index_roi, out HObject ho_ImageROI)
        {
            // Khởi tạo đối tượng đầu ra
            HOperatorSet.GenEmptyObj(out ho_ImageROI);
            LibaryHalcon libaryHalcon = new LibaryHalcon();

            try
            {
                // Kiểm tra điều kiện đầu vào
                if (roi_Tool == null || index_roi < 0 || index_roi >= roi_Tool.Count)
                {
                    Job_Model.Statatic_Model.wirtelog.Log($"AL020 - Invalid ROI parameters (Index: {index_roi}, Count: {roi_Tool?.Count})");
                    return;
                }

                // Kiểm tra type ROI hợp lệ
                if (string.IsNullOrEmpty(roi_Tool[index_roi].Type))
                {
                    Job_Model.Statatic_Model.wirtelog.Log("AL021 - ROI Type is null or empty");
                    return;
                }

                // Xử lý căn chỉnh ROI
                if (index_follow >= 0)
                {
                    // Kiểm tra homMat2D hợp lệ
                    if (Statatic_Model.hommat2D == null ||
                        camera_index < 0 || job_index < 0 ||
                        index_follow >= Statatic_Model.hommat2D.GetLength(2))
                    {
                        Job_Model.Statatic_Model.wirtelog.Log("AL022 - Invalid homMat2D parameters");
                        return;
                    }

                    HTuple homMat2D = Statatic_Model.hommat2D[camera_index, job_index, index_follow];

                    switch (roi_Tool[index_roi].Type)
                    {
                        case "Rectangle":
                            var rectangleROI = roi_Tool[index_roi] as RectangleROI;
                            if (rectangleROI != null)
                                libaryHalcon.Alingn_Tool_Rectang(homMat2D, rectangleROI.X, rectangleROI.Y,
                                    rectangleROI.Phi, rectangleROI.Width, rectangleROI.Height, out ho_ImageROI);
                            break;

                        case "Circle":
                            var cirROI = roi_Tool[index_roi] as CircleROI;
                            if (cirROI != null)
                                libaryHalcon.Align_Tool_Cir(homMat2D, cirROI.CenterX, cirROI.CenterY,
                                    cirROI.Radius, out ho_ImageROI);
                            break;

                        case "Line":
                            var lineROI = roi_Tool[index_roi] as LineROI;
                            if (lineROI != null)
                                libaryHalcon.Align_Tool_Line(homMat2D, lineROI.StartX, lineROI.StartY,
                                    lineROI.EndX, lineROI.EndY, out ho_ImageROI);
                            break;

                        case "Polygon":
                            var polygonROI = roi_Tool[index_roi] as PolygonROI;
                            if (polygonROI != null && polygonROI.StartX != null && polygonROI.StartY != null)
                                libaryHalcon.Align_Tool_Polygon(homMat2D, polygonROI.StartX, polygonROI.StartY, out ho_ImageROI);
                            break;

                        default:
                            Job_Model.Statatic_Model.wirtelog.Log($"AL023 - Unknown ROI Type: {roi_Tool[index_roi].Type}");
                            break;
                    }
                }
                else
                {
                    // Tạo ROI không qua căn chỉnh
                    switch (roi_Tool[index_roi].Type)
                    {
                        case "Rectangle":
                            var rectangleROI = roi_Tool[index_roi] as RectangleROI;
                            if (rectangleROI != null)
                                HOperatorSet.GenRectangle2(out ho_ImageROI, rectangleROI.X, rectangleROI.Y,
                                    rectangleROI.Phi, rectangleROI.Width, rectangleROI.Height);
                            break;

                        case "Circle":
                            var cirROI = roi_Tool[index_roi] as CircleROI;
                            if (cirROI != null)
                                HOperatorSet.GenCircle(out ho_ImageROI, cirROI.CenterX, cirROI.CenterY, cirROI.Radius);
                            break;

                        case "Line":
                            var lineROI = roi_Tool[index_roi] as LineROI;
                            if (lineROI != null)
                                HOperatorSet.GenRegionLine(out ho_ImageROI, lineROI.StartX, lineROI.StartY,
                                    lineROI.EndX, lineROI.EndY);
                            break;

                        case "Polygon":
                            var polygonROI = roi_Tool[index_roi] as PolygonROI;
                            if (polygonROI != null && polygonROI.StartX != null && polygonROI.StartY != null)
                            {
                                int count = Math.Min(polygonROI.StartX.Count, polygonROI.StartY.Count);
                                double[] rows = polygonROI.StartX.Take(count).ToArray();
                                double[] cols = polygonROI.StartY.Take(count).ToArray();
                                HOperatorSet.GenRegionPolygon(out ho_ImageROI, rows, cols);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Job_Model.Statatic_Model.wirtelog.Log($"AL024 - Error in align_Roi: {ex.ToString()}");
                // Tạo ROI rỗng nếu có lỗi
                HOperatorSet.GenEmptyObj(out ho_ImageROI);
            }
        }
        public Class_Tool Clone()
        {
            string jobjson = JsonConvert.SerializeObject(this, Formatting.Indented);
            return JsonConvert.DeserializeObject<Class_Tool>(jobjson);

        }
    }
   
    
    public class FindLineTool : Class_Tool
    {
        public FindLineTool() : base("FindLine") { }
        public string folow_master { get; set; } = "none";
       
        public decimal sigma { get; set; } = 1;
        public decimal MeasureThres { get; set; }
        public decimal Length1 { get; set; } = 20;
        public decimal Length2 { get; set; } = 5;
        public decimal Threshold { get; set; } = 5;
        public decimal ThresMax { get; set; }
        public string combo_Result { get; set; } = "all";
        public string combo_Light_to_Dark { get; set; } = "positive";
       
      
        public bool show_line = true;
        // result findline
        public double X1ob = new double();
        public double Y1ob = new double();
        public double X2ob = new double();
        public double Y2ob = new double();
        public double Xcenterob = new double();
        public double Ycenterob = new double();
        public override void Excute(HWindow hWindow, HObject ho_Image)
        {
            Excute_OnlyTool(hWindow, ho_Image);
        }
        public override void Excute_OnlyTool(HWindow hWindow, HObject ho_Image)
        {
            HObject out_bitmap;
            HObject ho_Rectangle, ho_ImageReduced;
            Result_Tool = false;
            // Local control variables
            HTuple hv_Width = new HTuple();
            HTuple hv_Height = new HTuple(), hv_MetrologyHandle = new HTuple();
            HTuple hv_LineRow1 = new HTuple(), hv_LineColumn1 = new HTuple();
            HTuple hv_LineRow2 = new HTuple(), hv_LineColumn2 = new HTuple();
            HTuple hv_Tolerance = new HTuple(), hv_Tolerance2 = new HTuple(), hv_Index1 = new HTuple();
            HTuple hv_Rows = new HTuple(), hv_Columns = new HTuple();
            HTuple hv_LineParameter = new HTuple();
            HTuple hv_Angle = new HTuple(), hv_Row = new HTuple();
            HTuple hv_Column = new HTuple(), hv_IsOverlapping1 = new HTuple();
            HTuple hv_Orientation1 = new HTuple(), hv_Orientation2 = new HTuple();
            HTuple hv_MRow = new HTuple(), hv_MColumn = new HTuple();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            //HOperatorSet.GenEmptyObj(out ho_Region);
            //HOperatorSet.GenEmptyObj(out ho_ResultContour);
            //HOperatorSet.GenEmptyObj(out ho_ContCircle);
            HOperatorSet.GenEmptyObj(out out_bitmap);
            //HOperatorSet.GenEmptyObj(out ho_Cross);
            //Tính điểm trung bình insert vào;


            try
            {
                HOperatorSet.Rgb1ToGray(ho_Image, out ho_Image);
                LineROI lineROI = (LineROI)roi_Tool[0];
                double X1 = lineROI.StartX;
                double Y1 = lineROI.StartY;
                double X2 = lineROI.EndX;
                double Y2 = lineROI.EndY;
                hv_Width.Dispose(); hv_Height.Dispose();
                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);

                hv_MetrologyHandle.Dispose();
                HOperatorSet.CreateMetrologyModel(out hv_MetrologyHandle);
                HOperatorSet.SetMetrologyModelImageSize(hv_MetrologyHandle, hv_Width, hv_Height);
                hv_Index1.Dispose();
                LibaryHalcon libaryHalcon = new LibaryHalcon();
                HTuple homMat2D = null;
                if (index_follow >= 0)
                {
                    homMat2D = Statatic_Model.hommat2D[camera_index, job_index, index_follow];
                    libaryHalcon.Align_Roi_Line(homMat2D, X1, Y1, X2, Y2, out hv_LineRow1, out hv_LineColumn1, out hv_LineRow2, out hv_LineColumn2);
                }
                else
                {
                    hv_LineRow1 = X1;
                    hv_LineColumn1 = Y1;
                    hv_LineRow2 = X2;
                    hv_LineColumn2 = Y2;
                }




                HOperatorSet.AddMetrologyObjectLineMeasure(
                       hv_MetrologyHandle
                       , hv_LineRow1
                       , hv_LineColumn1
                       , hv_LineRow2
                       , hv_LineColumn2
                       , (HTuple)Length1 // Measure leng1 //20
                       , (HTuple)Length2 // Measure leng 2 //10
                       , (HTuple)sigma // Sigma Gaussian 1
                       , (HTuple)Threshold//Minimum edge amplitude. 30
                       , new HTuple()
                       , new HTuple()
                       , out hv_Index1);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, new HTuple("all"), new HTuple("measure_transition"), new HTuple(combo_Light_to_Dark));
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, new HTuple("all"), new HTuple("measure_select"), new HTuple(combo_Result));
                HOperatorSet.ApplyMetrologyModel(ho_Image, hv_MetrologyHandle);
                HOperatorSet.GetMetrologyObjectMeasures(out out_bitmap, hv_MetrologyHandle, "all", "all", out hv_MRow, out hv_MColumn);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, "all", "all", "result_type", "all_param", out hv_LineParameter);
                if (hv_LineParameter.Length > 2)
                {
                    X1ob = hv_LineParameter.TupleSelect(0);
                    Y1ob = hv_LineParameter.TupleSelect(1);
                    X2ob = hv_LineParameter.TupleSelect(2);
                    Y2ob = hv_LineParameter.TupleSelect(3);
                    Xcenterob = (X1ob + X2ob) / 2;
                    Ycenterob = (Y1ob + Y2ob) / 2;
                    out_bitmap.Dispose();
                    hv_MRow.Dispose();
                    hv_MColumn.Dispose();
                    if (show_line)
                    {
                        HOperatorSet.SetColor(hWindow, "green");
                        //  HOperatorSet.DispLine(hWindow, X1ob[cam, job, tool], Y1ob[cam, job, tool], X2ob[cam, job, tool], Y2ob[cam, job, tool]);
                        HOperatorSet.DispArrow(hWindow, X1ob, Y1ob, X2ob, Y2ob, 1);
                    }


                    Result_Tool = true;
                }
                else
                {
                    double Xtb = (X1 + X2) / 2;
                    double Ytb = (Y1 + Y2) / 2;
                    double Xtb1 = Xtb;
                    double Ytb1 = Ytb + (double)Length1;
                    double Xtb2 = Xtb;
                    double Ytb2 = Ytb - (double)Length1;
                    HOperatorSet.SetColor(hWindow, "red");
                    HOperatorSet.DispArrow(hWindow, Xtb1, Ytb1, Xtb2, Ytb2, 0.5);
                    Result_Tool = false;
                    HOperatorSet.SetColor(hWindow, "orange");
                    if (out_bitmap != null) HOperatorSet.DispObj(out_bitmap, hWindow);

                }
            }

            catch (Exception ex)
            {
                Job_Model.Statatic_Model.wirtelog.Log($"AL014 - {this.GetType().Name}" + ex.ToString());
                Result_Tool = false;

            }
        }

    }
    public class ShapeModelTool : Class_Tool
    {
        public string folow_master { get; set; } = "none";
        public double Ag_Start { get; set; } = 0;
        public double Ag_End { get; set; } = 360;
        public double Min_Score { get; set; } = 0.5;
        public double Number_of_match { get; set; } = 1;
        public double Greediness { get; set; } = 1;
        public double Max_Overlap { get; set; } = 0.5;
        public double Constract { get; set; } = 30;
        public double MinConstract { get; set; } = 5;
        public string Sub_pixel { get; set; } = "least_squares";
        public string File_Model { get; set; }
        public string Read_Model { get; set; }
        public double min_score { get; set; } = 0.9;
        public double max_score { get; set; } = 1;
        public double max_phi { get; set; } = 6;
        public double min_phi { get; set; } = -6;
        // Train Model
        public bool canmeasure { get; set; }
        // Result
        public double[] Score = new double[100];
        public double[] X_Master = new double[100];
        public double[] Y_Master = new double[100];
        public double[] Phi_Master = new double[100];
        // Master_Train
        public double X_follow { get; set; } = 0;
        public double Y_follow { get; set; } = 0;
        public double Phi_follow { get; set; } = 0;

        public ShapeModelTool() : base("ShapeModel") { }
        public override void Excute(HWindow hWindow, HObject ho_Image)
        {
            Excute_OnlyTool(hWindow, ho_Image);



        }
        public void Train_Model(HWindow hWindow, HObject ho_Image)
        {
            try
            {

                canmeasure = false;
                // Local iconic variables 

                HObject ho_ModelROI, ho_ImageROI;
                HObject ho_ShapeModelImage, ho_ShapeModelRegion, ho_ShapeModel;
                HObject ho_SearchImage = null, ho_ModelAtNewPosition = null;


                // Local control variables 

                HTuple hv_Width;
                HTuple hv_Height;
                HTuple hv_ModelID, hv_RowCheck = new HTuple(), hv_ColumnCheck = new HTuple();
                HTuple hv_AngleCheck = new HTuple(), hv_Score = new HTuple();
                HTuple hv_j = new HTuple(), hv_MovementOfObject = new HTuple();
                HTuple hv_RowArrowHead = new HTuple(), hv_ColumnArrowHead = new HTuple();
                // Initialize local and output iconic variables 
                HOperatorSet.GenEmptyObj(out ho_ModelROI);
                HOperatorSet.GenEmptyObj(out ho_ImageROI);
                HOperatorSet.GenEmptyObj(out ho_ShapeModelImage);
                HOperatorSet.GenEmptyObj(out ho_ShapeModelRegion);
                HOperatorSet.GenEmptyObj(out ho_ShapeModel);
                HOperatorSet.GenEmptyObj(out ho_SearchImage);
                HOperatorSet.GenEmptyObj(out ho_ModelAtNewPosition);

                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
                HOperatorSet.SetSystem("width", hv_Width);
                HOperatorSet.SetSystem("height", hv_Height);
                HOperatorSet.SetColor(hWindow, "blue");
                HOperatorSet.SetDraw(hWindow, "fill");
                HOperatorSet.SetShape(hWindow, "original");
                HOperatorSet.SetDraw(hWindow, "margin");
                HOperatorSet.SetLineWidth(hWindow, 2);
                HOperatorSet.ClearWindow(hWindow);
                HOperatorSet.DispObj(ho_Image, hWindow);
                HTuple Angle_Start = Ag_Start;
                HTuple Angle_End = Ag_End;
                // Get Roi 
                ho_ModelROI.Dispose();
                align_Roi(-1, 0, out ho_ModelROI);
                //  HOperatorSet.DispObj(ho_ModelROI, hWindow);
                //  MessageBox.Show("Model Region");
                //step 2: inspect the model region
                //ho_ImageROI.Dispose();
                HOperatorSet.ReduceDomain(ho_Image, ho_ModelROI, out ho_ImageROI);


                //  HOperatorSet.DispObj(ho_ImageROI, hWindow);
                //  MessageBox.Show("Reduce Domain");

               
                //SavePicMenuItem1_Click(ho_ImageROI);
                //step 3: create the model

                //    HOperatorSet.ReduceDomain(ho_Image, ho_ModelROI, out ho_ImageROI);

               
                HOperatorSet.CreateShapeModel(
                    ho_ImageROI
                    , "auto"
                    , (HTuple)Angle_Start.TupleRad()
                    , (HTuple)Angle_End.TupleRad()
                    , "auto"
                    , "auto"//"none"
                , "use_polarity"
                , (HTuple)Constract// 30
                    , (HTuple)MinConstract// 10
                    , out hv_ModelID);
                ho_ShapeModelImage.Dispose();
                ho_ShapeModelRegion.Dispose();
                HOperatorSet.InspectShapeModel(
                    ho_ImageROI
                    , out ho_ShapeModelImage
                    , out ho_ShapeModelRegion
                , 1//1
                    , (HTuple)Constract);//30

                //   HOperatorSet.ClearWindow(hWindow);
                HOperatorSet.DispObj(ho_ShapeModelRegion, hWindow);
                MessageBox.Show("Shape Model Region");

                //  HOperatorSet.DispObj(ho_ShapeModelImage, hWindow);
                //string pathcamparam = Application.StartupPath + "\\TrainModel\\" + "Camera" + camera_run.ToString() + "Job" + job.ToString() + "Tool" + tool.ToString() + ".Shape";
                //HOperatorSet.WriteShapeModel(hv_ModelID, @"Config\\" + Model + "_Job_" + job.ToString() + "_Tool_" + tool.ToString() + "_Shapemodel.shm");
                // HOperatorSet.WriteShapeModel(hv_ModelID, "D:\\2. DUC THUY\\" + "_Shapemodel.shm");
                string file_name = File_Model + "\\_Shapemodel"+job_index+tool_index+".model";
                Read_Model = file_name;
                HOperatorSet.WriteShapeModel(hv_ModelID, file_name);

                MessageBox.Show("Finish Train Shape Model");
                HOperatorSet.ClearShapeModel(hv_ModelID);
                Excute(hWindow, ho_Image);
                X_follow = X_Master[0];
                Y_follow= Y_Master[0];
                Phi_follow = Phi_Master[0];

                ho_ModelROI.Dispose();
                ho_ImageROI.Dispose();
                ho_ShapeModelImage.Dispose();
                ho_ShapeModelRegion.Dispose();
                ho_ShapeModel.Dispose();
                ho_SearchImage.Dispose();
                ho_ModelAtNewPosition.Dispose();
            }
            catch (Exception ex)
            {
                Job_Model.Statatic_Model.wirtelog.Log($"AL015 - {this.GetType().Name}" + ex.ToString());
                canmeasure = false;
            }
        }
        public override void Excute_OnlyTool(HWindow hWindow, HObject ho_Image)
        {
            Result_Tool = false;
            Array.Clear(Score, 0, Score.GetLength(0));
            Array.Clear(X_Master, 0, X_Master.GetLength(0));
            Array.Clear(Y_Master, 0, Y_Master.GetLength(0));
            Array.Clear(Phi_Master, 0, Phi_Master.GetLength(0));

            try
            {
                HTuple Angle_Start = Ag_Start;
                HTuple Angle_End = Ag_End;
                HObject ho_ModelROI, ho_ImageROI;
                HObject ho_ShapeModelImage, ho_ShapeModelRegion, ho_ShapeModel;
                HObject ho_ModelAtNewPosition = null;
                HTuple hv_ModelID, hv_RowCheck = new HTuple(), hv_ColumnCheck = new HTuple();
                HTuple hv_AngleCheck = new HTuple(), hv_Score = new HTuple();
                HTuple hv_j = new HTuple(), hv_MovementOfObject = new HTuple();
                HTuple hv_RowArrowHead = new HTuple(), hv_ColumnArrowHead = new HTuple();

                // Initialize local and output iconic variables 
                HOperatorSet.GenEmptyObj(out ho_ModelROI);
                HOperatorSet.GenEmptyObj(out ho_ImageROI);
                HOperatorSet.GenEmptyObj(out ho_ShapeModelImage);
                HOperatorSet.GenEmptyObj(out ho_ShapeModelRegion);
                HOperatorSet.GenEmptyObj(out ho_ShapeModel);
                HOperatorSet.GenEmptyObj(out ho_ModelAtNewPosition);

                align_Roi(index_follow, 1, out ho_ImageROI);


                HOperatorSet.ReduceDomain(ho_Image, ho_ImageROI, out ho_Image);

                HOperatorSet.ReadShapeModel(Read_Model, out hv_ModelID);
                ho_ShapeModel.Dispose();
                HOperatorSet.GetShapeModelContours(out ho_ShapeModel, hv_ModelID, 1);//1
                HOperatorSet.SetColor(hWindow, "blue");

                HOperatorSet.FindShapeModel(
                    ho_Image
                    , hv_ModelID
                    , (HTuple)Angle_Start.TupleRad()
                    , (HTuple)Angle_End.TupleRad()
                    , (HTuple)Min_Score //min score
                    , (HTuple)Number_of_match // numMatched
                    , (HTuple)Max_Overlap //Maxoverlap
                    , (HTuple)Sub_pixel
                    , 0
                    , (HTuple)Greediness
                    , out hv_RowCheck
                    , out hv_ColumnCheck
                    , out hv_AngleCheck
                    , out hv_Score);
                int numshape = (int)(new HTuple(hv_Score.TupleLength()));
                if (numshape > 0)
                {
                    canmeasure = true;
                    //X = hv_ColumnCheck.TupleSelect(0);
                    //Y = hv_RowCheck.TupleSelect(0);
                    //Phi = hv_AngleCheck.TupleSelect(0);
                    //Score = hv_Score.TupleSelect(0);
                    for (hv_j = 0; (int)hv_j <= (int)((new HTuple(hv_Score.TupleLength())) - 1); hv_j = (int)hv_j + 1)
                    {

                        Score[hv_j] = hv_Score.TupleSelect(hv_j);
                        Y_Master[hv_j] = hv_ColumnCheck.TupleSelect(hv_j);
                        X_Master[hv_j] = hv_RowCheck.TupleSelect(hv_j);
                        Phi_Master[hv_j] = hv_AngleCheck.TupleSelect(hv_j);
                        if (Phi_Master[hv_j]>6)
                        {
                            Phi_Master[hv_j] = Phi_Master[hv_j] - Math.PI * 2;
                        }
                        if (Score[hv_j] >= min_score && Score[hv_j] <= max_score && Phi_Master[hv_j]>=min_phi&& Phi_Master[hv_j]<=max_phi)
                        {
                            Result_Tool = true;
                            HOperatorSet.SetColor(hWindow, "green");
                        }
                        else
                        {
                            Result_Tool = false;
                            HOperatorSet.SetColor(hWindow, "red");
                        }
                        if (hv_j == 0)
                        {
                            HOperatorSet.VectorAngleToRigid(0, 0, 0, hv_RowCheck.TupleSelect(hv_j), hv_ColumnCheck.TupleSelect(hv_j), hv_AngleCheck.TupleSelect(hv_j), out hv_MovementOfObject);
                            ho_ModelAtNewPosition.Dispose();
                            HOperatorSet.AffineTransContourXld(ho_ShapeModel, out ho_ModelAtNewPosition, hv_MovementOfObject);
                            HOperatorSet.DispObj(ho_ModelAtNewPosition, hWindow);
                            HOperatorSet.AffineTransPixel(hv_MovementOfObject, 100, 0, out hv_RowArrowHead, out hv_ColumnArrowHead);
                            HOperatorSet.DispArrow(hWindow, hv_RowCheck.TupleSelect(hv_j), hv_ColumnCheck.TupleSelect(hv_j), hv_RowArrowHead, hv_ColumnArrowHead, 2);
                            HOperatorSet.AffineTransPixel(hv_MovementOfObject, 0, 100, out hv_RowArrowHead, out hv_ColumnArrowHead);
                            HOperatorSet.DispArrow(hWindow, hv_RowCheck.TupleSelect(hv_j), hv_ColumnCheck.TupleSelect(hv_j), hv_RowArrowHead, hv_ColumnArrowHead, 2);

                        }
                        if (hv_j > 0)
                        {

                            HOperatorSet.VectorAngleToRigid(0, 0, 0, hv_RowCheck.TupleSelect(hv_j), hv_ColumnCheck.TupleSelect(hv_j), hv_AngleCheck.TupleSelect(hv_j), out hv_MovementOfObject);
                            ho_ModelAtNewPosition.Dispose();
                            HOperatorSet.AffineTransContourXld(ho_ShapeModel, out ho_ModelAtNewPosition, hv_MovementOfObject);
                            HOperatorSet.DispObj(ho_ModelAtNewPosition, hWindow);
                            HOperatorSet.AffineTransPixel(hv_MovementOfObject, 100, 0, out hv_RowArrowHead, out hv_ColumnArrowHead);
                            //    HOperatorSet.DispArrow(hWindow, hv_RowCheck.TupleSelect(hv_j), hv_ColumnCheck.TupleSelect(hv_j), hv_RowArrowHead, hv_ColumnArrowHead, 2);
                            HOperatorSet.AffineTransPixel(hv_MovementOfObject, 0, 100, out hv_RowArrowHead, out hv_ColumnArrowHead);
                            //  HOperatorSet.DispArrow(hWindow, hv_RowCheck.TupleSelect(hv_j), hv_ColumnCheck.TupleSelect(hv_j), hv_RowArrowHead, hv_ColumnArrowHead, 2);

                        }
                    }
                }
                else
                {

                }
                HOperatorSet.ClearShapeModel(hv_ModelID);

                ho_Image.Dispose();
                ho_ModelROI.Dispose();
                ho_ImageROI.Dispose();
                ho_ShapeModelImage.Dispose();
                ho_ShapeModelRegion.Dispose();
                ho_ShapeModel.Dispose();
                ho_ModelAtNewPosition.Dispose();
            }
            catch (Exception ex)
            {
                Job_Model.Statatic_Model.wirtelog.Log($"AL016 - {this.GetType().Name}" + ex.ToString());
            }
        }
    }
    public class FixtureTool : Class_Tool
    {
        public string master_follow { get; set; } = "none";
        public int index_master_job { get; set; } = -1;
        public double master_y { get; set; } = 0;
        public double master_x { get; set; } = 0;
        public double master_phi { get; set; } = 0;
        public FixtureTool() : base("Fixture") { }
        public override void Excute(HWindow hWindow, HObject ho_Image)
        {
            Excute_OnlyTool(hWindow, ho_Image);
        }
        public override void Excute_OnlyTool(HWindow hWindow, HObject ho_Image)
        {
            Result_Tool = true;

            if (index_follow >= 0)
            {

                ShapeModelTool shapeModelTool = (ShapeModelTool)Statatic_Model.model_run.Cameras[camera_index].Jobs[index_master_job].Images[image_index].Tools[index_follow];
                double x_cr = shapeModelTool.X_Master[0];
                double y_cr = shapeModelTool.Y_Master[0];
                double phi_cr = shapeModelTool.Phi_Master[0];
                Align_Tool(out Statatic_Model.hommat2D[camera_index, job_index, tool_index], x_cr, y_cr, phi_cr);

            }
        }
        public void Align_Tool(out HTuple homMat2D, double x_cr, double y_cr, double phi_cr )
        {
            
            HOperatorSet.VectorAngleToRigid((HTuple)master_x, (HTuple)master_y, (HTuple)master_phi, (HTuple)x_cr, (HTuple)y_cr, (HTuple)phi_cr, out homMat2D);

        }
       

    }
    public class FindCircleTool : Class_Tool
    {
        public string master_follow { get; set; } = "none";
        public double sigma { get; set; } = 1;
        public double MeasureThres { get; set; } = 30;
        public double Length1 { get; set; } = 20;
        public double Length2 { get; set; } = 5;
        public double Ag_Start { get; set; } = 0;
        public double Ag_End { get; set; } = 360;
        public string combo_Result { get; set; } = "all";
        public string combo_Light_to_Dark { get; set; } = "positive";
        // Result
        public double X_center { get; set; }
        public double Y_center { get; set; }
        public double Radius { get; set; }
        public double limit_high { get; set; } = 1000;
        public double limit_low { get; set; } = 0;
        public FindCircleTool() : base("FindCircle") { }
        public override void Excute(HWindow hWindow, HObject ho_Image)
        {
            Excute_OnlyTool(hWindow, ho_Image);
        }
        public override void Excute_OnlyTool(HWindow hWindow, HObject ho_Image)
        {
            try
            {
                Result_Tool = false;
                HObject ho_Cross1, ho_Contours, ho_Reg, ho_cir;
                HObject ho_Cross;
                HTuple hv_Width = new HTuple(), hv_Height = new HTuple();
                HTuple hv_RowCircle = new HTuple();
                HTuple hv_CircleInitRow = new HTuple(), hv_CircleInitColumn = new HTuple();
                HTuple hv_CircleInitRadius = new HTuple(), hv_CircleRadiusTolerance = new HTuple();
                HTuple hv_MetrologyHandle = new HTuple();
                HTuple hv_MetrologyCircleIndices = new HTuple();
                HTuple hv_Sequence = new HTuple();
                HTuple hv_CircleParameter = new HTuple(), hv_CircleRow = new HTuple();
                HTuple hv_CircleColumn = new HTuple(), hv_CircleRadius = new HTuple();
                HTuple hv_Row1 = new HTuple(), hv_Column1 = new HTuple();
                HTuple hv_Color = new HTuple(), hv_Message = new HTuple();
                HObject out_bitmap;
                HOperatorSet.GenEmptyObj(out ho_Cross1);
                HOperatorSet.GenEmptyObj(out ho_Contours);
                HOperatorSet.GenEmptyObj(out ho_Cross);
                HOperatorSet.GenEmptyObj(out out_bitmap);
                HOperatorSet.GenEmptyObj(out ho_Reg);
                HOperatorSet.GenEmptyObj(out ho_cir);
                CircleROI cirROI = (CircleROI)roi_Tool[0];
                double X1 = cirROI.CenterX;
                double Y1 = cirROI.CenterY;
                double radius = cirROI.Radius;
                HTuple X2, Y2;
                X2 = X1; Y2 = Y1;
                hv_Width.Dispose();
                hv_Height.Dispose();
                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
                LibaryHalcon libaryHalcon = new LibaryHalcon();
                HTuple homMat2D = null;
                if (index_follow >= 0)
                {
                    homMat2D = Statatic_Model.hommat2D[camera_index, job_index, index_follow];
                    libaryHalcon.Align_Tool_Cir(homMat2D, X1, Y1, radius, out ho_Reg);
                    HOperatorSet.AffineTransPoint2d(homMat2D, X1, Y1, out X2, out Y2);
                }
                else
                {
                    X2 = X1; Y2 = Y1;
                    HOperatorSet.GenCircle(out ho_Reg, X2, Y2, radius);
                }

                HOperatorSet.ReduceDomain(ho_Image, ho_Reg, out ho_Image);
                hv_CircleInitRow.Dispose();
                hv_CircleInitColumn.Dispose();
                hv_CircleInitRadius.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_CircleInitRow = new HTuple();
                    hv_CircleInitRow[0] = X2;
                    hv_CircleInitColumn = new HTuple();
                    hv_CircleInitColumn[0] = Y2;
                    hv_CircleInitRadius = new HTuple();
                    hv_CircleInitRadius[0] = radius;
                }
                ho_Cross1.Dispose();
                HOperatorSet.GenCrossContourXld(out ho_Cross1, hv_CircleInitRow, hv_CircleInitColumn, 6, 0.785398);
                hv_MetrologyHandle.Dispose();
                HOperatorSet.CreateMetrologyModel(out hv_MetrologyHandle);
                HOperatorSet.SetMetrologyModelImageSize(hv_MetrologyHandle, hv_Width, hv_Height);
                hv_MetrologyCircleIndices.Dispose();
                HOperatorSet.AddMetrologyObjectCircleMeasure(
                   hv_MetrologyHandle
                   , hv_CircleInitRow
                   , hv_CircleInitColumn
                   , hv_CircleInitRadius
                , (HTuple)Length1
                   , (HTuple)Length2
                   , (HTuple)sigma
                   , (HTuple)MeasureThres
                   , (new HTuple("start_phi")).TupleConcat("end_phi")
                   , (new HTuple(Ag_Start)).TupleRad().TupleConcat((new HTuple(Ag_End)).TupleRad())
                   , out hv_MetrologyCircleIndices);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_MetrologyCircleIndices, "num_instances", 2);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_MetrologyCircleIndices, "measure_transition", new HTuple(combo_Light_to_Dark));
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_MetrologyCircleIndices, "measure_select", new HTuple(combo_Result));
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_MetrologyCircleIndices, "min_score", 0.5);//.9
                HOperatorSet.ApplyMetrologyModel(ho_Image, hv_MetrologyHandle);
                hv_CircleParameter.Dispose();
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_MetrologyCircleIndices, "all", "result_type", "all_param", out hv_CircleParameter);
                //Extract the parameters for better readability
                hv_Sequence.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_Sequence = HTuple.TupleGenSequence(0, (new HTuple(hv_CircleParameter.TupleLength())) - 1, 3);
                }
                hv_CircleRow.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_CircleRow = hv_CircleParameter.TupleSelect(hv_Sequence);
                }
                hv_CircleColumn.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_CircleColumn = hv_CircleParameter.TupleSelect(hv_Sequence + 1);
                }
                hv_CircleRadius.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_CircleRadius = hv_CircleParameter.TupleSelect(hv_Sequence + 2);
                }
                out_bitmap.Dispose();
                hv_Row1.Dispose();
                hv_Column1.Dispose();
                HOperatorSet.GetMetrologyObjectMeasures(out out_bitmap, hv_MetrologyHandle, "all", "all", out hv_Row1, out hv_Column1);
                if (hv_CircleParameter.Length > 1)
                {
                    X_center = hv_CircleRow;
                    Y_center = hv_CircleColumn;
                    Radius = hv_CircleRadius;
                    HOperatorSet.SetTposition(hWindow, X1, Y1);
                    Display design_Display = new Display();
                    design_Display.set_font(hWindow, 10, "mono", "true", "false");
                    HOperatorSet.SetDraw(hWindow, "margin");
                    if (limit_low <= Radius && Radius <= limit_high)
                    {
                        HOperatorSet.SetColor(hWindow, "green");
                        Result_Tool = true;
                    }
                    else
                    {
                        HOperatorSet.SetColor(hWindow, "red");
                        Result_Tool = false;
                    }
                    HOperatorSet.DispCircle(hWindow, X_center, Y_center, Radius);
                    ho_cir.Dispose();
                    if(show_text)
                    {
                        design_Display.disp_message(hWindow
                   , "Step" + job_index + "-" + tool_index + " Circle\n" + "Radius " + (Radius * cali).ToString("0.000") + "mm"
                   + "\nRadius " + (Radius).ToString("0.000")
                   , "image"
                   , X_center
                   , Y_center
                   , "black"
                   , "true");
                    }    
                   


                    //    HOperatorSet.DispText(hWindow
                    //    , "Step" + job_index + "-" + tool_index + " Circle\n" + "Radius " + (Radius * cali).ToString("0.000") + "mm"
                    //    + "\nRadius " + (Radius).ToString("0.000")
                    //    , "image"
                    //    , hv_CircleRow
                    //    , hv_CircleColumn
                    //    , "black"
                    //    , new HTuple()
                    //    , new HTuple());
                }
                else
                {
                    HOperatorSet.DispObj(out_bitmap, hWindow);
                }



                ho_Reg.Dispose();
                ho_Cross1.Dispose();
                ho_Contours.Dispose();
                ho_Cross.Dispose();
                hv_Width.Dispose();
                hv_Height.Dispose();
                hv_RowCircle.Dispose();
                hv_CircleInitRow.Dispose();
                hv_CircleInitColumn.Dispose();
                hv_CircleInitRadius.Dispose();
                hv_CircleRadiusTolerance.Dispose();
                hv_MetrologyHandle.Dispose();
                hv_MetrologyCircleIndices.Dispose();
                hv_Sequence.Dispose();
                hv_CircleParameter.Dispose();
                hv_CircleRow.Dispose();
                hv_CircleColumn.Dispose();
                hv_CircleRadius.Dispose();
                hv_Row1.Dispose();
                hv_Column1.Dispose();
                hv_Color.Dispose();
                hv_Message.Dispose();

            }
            catch (Exception ex)
            {

                Job_Model.Statatic_Model.wirtelog.Log($"AL017 - {this.GetType().Name}" + ex.ToString());
            }
        }
    }
    public class FindDistanceTool : Class_Tool
    {
        public int index_Fr_tool { get; set; }
        public int index_To_tool { get; set; }
        public string Geometry { get; set; }
        public string From_Pos { get; set; }
        public string To_Pos { get; set; }
        public string From_Point { get; set; }
        public string To_Point { get; set; }
        public double Max_Dis { get; set; }
        public double Min_Dis { get; set; }
        public string Fr_Name_Tool { get; set; }
        public string To_Name_Tool { get;set; }
        // Result
        public double Fr_X { get; set; }
        public double Fr_Y { get; set; }
        public double Fr_X1 { get; set; }
        public double Fr_Y1 { get; set; }
        public double Fr_X2 { get; set; }
        public double Fr_Y2 { get; set; }
        public double To_X { get; set; }
        public double To_Y { get; set; }
        public double To_X1 { get; set; }
        public double To_Y1 { get; set; }
        public double To_X2 { get; set; }
        public double To_Y2 { get; set; }

        public double Distance { get; set; }

        public FindDistanceTool() : base("FindDistance") { }
        public override void Excute(HWindow hWindow, HObject ho_Image)
        {
            Excute_OnlyTool(hWindow, ho_Image);
        }
        public override void Excute_OnlyTool(HWindow hWindow, HObject ho_Image)
        {
            try
            {
                Result_Tool = false;
                HTuple X_Fr, Y_Fr, X_To, Y_To;
                HTuple Xproject, Yproject, result;
                X_Fr = Fr_X;
                Y_Fr = Fr_Y;
                X_To = To_X;
                Y_To = To_Y;
                if (Fr_Name_Tool == "FindLine")
                {
                    FindLineTool tool = (FindLineTool)Job_Model.Statatic_Model.model_run.Cameras[camera_index].Jobs[job_index].Images[image_index].Tools[index_Fr_tool];
                    Fr_X = tool.Xcenterob;
                    Fr_Y = tool.Ycenterob;
                    Fr_X1 = tool.X1ob;
                    Fr_Y1 = tool.Y1ob;
                    Fr_X2 = tool.X2ob;
                    Fr_Y2 = tool.Y2ob;
                }
                if (Fr_Name_Tool == "FindCircle")
                {
                    FindCircleTool tool = (FindCircleTool)Job_Model.Statatic_Model.model_run.Cameras[camera_index].Jobs[job_index].Images[image_index].Tools[index_Fr_tool];
                    Fr_X = tool.X_center;
                    Fr_Y = tool.Y_center;

                }
                if (Fr_Name_Tool == "ShapeModel")
                {
                    ShapeModelTool tool = (ShapeModelTool)Job_Model.Statatic_Model.model_run.Cameras[camera_index].Jobs[job_index].Images[image_index].Tools[index_Fr_tool];
                    Fr_X = tool.X_Master[0];
                    Fr_Y = tool.Y_Master[0];
                }
                if (Fr_Name_Tool == "FitLine_Tool")
                {
                    FitLine_Tool tool = (FitLine_Tool)Job_Model.Statatic_Model.model_run.Cameras[camera_index].Jobs[job_index].Images[image_index].Tools[index_Fr_tool];
                    Fr_X = tool.X_Center;
                    Fr_Y = tool.Y_Center;
                    Fr_X1 = tool.X_Fr;
                    Fr_Y1 = tool.Y_Fr;
                    Fr_X2 = tool.X_To;
                    Fr_Y2 = tool.Y_To;
                }

                if (To_Name_Tool == "FindLine")
                {
                    FindLineTool tool = (FindLineTool)Job_Model.Statatic_Model.model_run.Cameras[camera_index].Jobs[job_index].Images[image_index].Tools[index_To_tool];
                    To_X = tool.Xcenterob;
                    To_Y = tool.Ycenterob;
                    To_X1 = tool.X1ob;
                    To_Y1 = tool.Y1ob;
                    To_X2 = tool.X2ob;
                    To_Y2 = tool.Y2ob;
                }
                if (To_Name_Tool == "FindCircle")
                {
                    FindCircleTool tool = (FindCircleTool)Job_Model.Statatic_Model.model_run.Cameras[camera_index].Jobs[job_index].Images[image_index].Tools[index_To_tool];
                    To_X = tool.X_center;
                    To_Y = tool.Y_center;

                }
                if (To_Name_Tool == "ShapeModel")
                {
                    ShapeModelTool tool = (ShapeModelTool)Job_Model.Statatic_Model.model_run.Cameras[camera_index].Jobs[job_index].Images[image_index].Tools[index_To_tool];
                    To_X = tool.X_Master[0];
                    To_Y = tool.Y_Master[0];
                }
                if (To_Name_Tool == "FitLine_Tool")
                {
                    FitLine_Tool tool = (FitLine_Tool)Job_Model.Statatic_Model.model_run.Cameras[camera_index].Jobs[job_index].Images[image_index].Tools[index_To_tool];
                    To_X = tool.X_Center;
                    To_Y = tool.Y_Center;
                    To_X1 = tool.X_Fr;
                    To_Y1 = tool.Y_Fr;
                    To_X2 = tool.X_To;
                    To_Y2 = tool.Y_To;
                }

                if (From_Point == "StartPoint")
                {
                    X_Fr = Fr_X1;
                    Y_Fr = Fr_Y1;
                }
                if (From_Point == "CenterPoint")
                {
                    X_Fr = Fr_X;
                    Y_Fr = Fr_Y;
                }
                if (From_Point == "EndPoint")
                {
                    X_Fr = Fr_X2;
                    Y_Fr = Fr_Y2;
                }
                if (To_Point == "StartPoint")
                {
                    X_To = To_X1;
                    Y_To = To_Y1;
                }
                if (To_Point == "CenterPoint")
                {
                    X_To = To_X;
                    Y_To = To_Y;
                }
                if (To_Point == "EndPoint")
                {
                    X_To = To_X2;
                    Y_To = To_Y2;
                }
                result = 0;
                if(Job_Model.Statatic_Model.use_calib)
                {
                    HTuple to_x1,to_y1,to_x2,to_y2,x_fr,y_fr,x_to,y_to;
                    HOperatorSet.ImagePointsToWorldPlane(Job_Model.Statatic_Model.Para_Cam, Job_Model.Statatic_Model.Pose_Cam, X_Fr, Y_Fr, "mm", out x_fr, out y_fr);
                    HOperatorSet.ImagePointsToWorldPlane(Job_Model.Statatic_Model.Para_Cam, Job_Model.Statatic_Model.Pose_Cam, X_To, Y_To, "mm", out x_to, out y_to);
                    HOperatorSet.ImagePointsToWorldPlane(Job_Model.Statatic_Model.Para_Cam, Job_Model.Statatic_Model.Pose_Cam, To_X1, To_Y1, "mm", out to_x1, out to_y1);
                    HOperatorSet.ImagePointsToWorldPlane(Job_Model.Statatic_Model.Para_Cam, Job_Model.Statatic_Model.Pose_Cam, To_X2, To_Y2, "mm", out to_x2, out to_y2);
                    if (Geometry == "Point to Line")
                    {
                        HOperatorSet.DistancePl(x_fr, y_fr, to_x1, to_y1, to_x2, to_y2, out result);
                        //   MessageBox.Show(result.ToString());
                        HOperatorSet.ProjectionPl(X_Fr, Y_Fr, To_X1, To_Y1, To_X2, To_Y2, out Xproject, out Yproject);
                        //HOperatorSet.LineOrientation(x_from, y_from, Yproject, Xproject, out Angle);

                        // if (show == true)
                        HOperatorSet.DispArrow(hWindow, X_Fr, Y_Fr, Xproject, Yproject, 1);
                    }
                    if (Geometry == "Point to Point")
                    {
                        HOperatorSet.DistancePp(x_fr, y_fr, x_to, y_to, out result);
                        // HOperatorSet.LineOrientation(x_from, y_from, x_to, y_to, out Angle);

                        //if (show == true)
                        HOperatorSet.DispArrow(hWindow, X_Fr, Y_Fr, X_To, Y_To, 1);
                    }
                }
                else
                {
                    if (Geometry == "Point to Line")
                    {
                        HOperatorSet.DistancePl(X_Fr, Y_Fr, To_X1, To_Y1, To_X2, To_Y2, out result);
                        //   MessageBox.Show(result.ToString());
                        HOperatorSet.ProjectionPl(X_Fr, Y_Fr, To_X1, To_Y1, To_X2, To_Y2, out Xproject, out Yproject);
                        //HOperatorSet.LineOrientation(x_from, y_from, Yproject, Xproject, out Angle);

                        // if (show == true)
                        HOperatorSet.DispArrow(hWindow, X_Fr, Y_Fr, Xproject, Yproject, 1);
                    }
                    if (Geometry == "Point to Point")
                    {
                        HOperatorSet.DistancePp(X_Fr, Y_Fr, X_To, Y_To, out result);
                        // HOperatorSet.LineOrientation(x_from, y_from, x_to, y_to, out Angle);

                        //if (show == true)
                        HOperatorSet.DispArrow(hWindow, X_Fr, Y_Fr, X_To, Y_To, 1);
                    }
                }
               
                Distance = (double)result * cali;
                if (Min_Dis <= Distance && Max_Dis >= Distance)
                {
                    Result_Tool = true;
                }
                Display design_Display = new Display();
                design_Display.set_font(hWindow, 15, "mono", "true", "false");
                // HOperatorSet.DispText()
                if(show_text)
                {
                    HOperatorSet.DispText(hWindow
                      , "Step" + job_index + "-" + tool_index + " Circle\n" + "Distance " + Distance.ToString("0.000") + "mm"
                      + "\nDistance " + ((double)result).ToString("0.000")
                      , "image"
                      , X_Fr
                      , Y_Fr
                      , "black"
                      , new HTuple()
                      , new HTuple());
                }    
              

            }
            catch (Exception ex) { Job_Model.Statatic_Model.wirtelog.Log($"AL017 - {this.GetType().Name}" + ex.ToString()); }
        }


    }
    public class HistogramTool : Class_Tool
    {
        public string master_follow { get; set; } = "none";
        public int pixel_high { get; set; } = 255;
        public int pixel_low { get; set; } = 0;
        public double max_setup { get; set; } = 100;
        public double min_setup { get; set; } = 0;
        public int threshold_high { get; set; } = 255;
        public int threshold_low { get; set; } = 125;
        public bool find_contour { get; set; } = false;
        public int nomal_size_max { get; set; } = 2000000;
        public int nomal_size_min { get; set; } = 100;
        public double max_deviation {  get; set; } = 255;
        public double min_deviation { get; set; } = 0;
        public double max_mean { get; set; } = 255;
        public double min_mean { get; set; } = 0;

        public double Rate_his { get; set; }
        public double Mean {  get; set; }
        public double Deviation {  get; set; }
        public int[] map_pixel = new int[256];
        public HistogramTool() : base("Histogram") { }
        private void Find_contour(HObject ho_ImageROI, HObject ho_Image, out HObject Region_contour,HWindow hWindow)
        {
            HObject ho_Contours;
            HObject ho_SelectedContour;
            HOperatorSet.GenEmptyObj(out Region_contour);
            HOperatorSet.GenEmptyObj(out ho_Contours);
            HObject ho_threshold;
            HOperatorSet.GenEmptyObj(out ho_threshold);
            HOperatorSet.ReduceDomain(ho_Image, ho_ImageROI, out ho_Image);
            HOperatorSet.Threshold(ho_Image, out ho_threshold, threshold_low, threshold_high);
            HOperatorSet.GenContourRegionXld(ho_threshold, out ho_Contours, "border");
            if(stepbystep)
            {
                HOperatorSet.ClearWindow(hWindow);
                HOperatorSet.DispObj(ho_Contours, hWindow);
                MessageBox.Show("GenContourRegionXld");
            }    
           
            HTuple hv_Number;
            HOperatorSet.CountObj(ho_Contours, out hv_Number);
          
          
            List<List<int>> hv_List = new List<List<int>>();

            for (int i = 1; i <= hv_Number; i++)
            {
                HOperatorSet.SelectObj(ho_Contours, out ho_SelectedContour, i);
                if (ho_SelectedContour != null && ho_SelectedContour.IsInitialized())
                {
                    HTuple hv_Row1, hv_Column1, hv_Row2, hv_Column2;
                    HOperatorSet.SelectObj(ho_Contours, out ho_SelectedContour, i);
                    HOperatorSet.SmallestRectangle1Xld(ho_SelectedContour, out hv_Row1, out hv_Column1, out hv_Row2, out hv_Column2);
                    double width = hv_Column2.D - hv_Column1.D;
                    double height = hv_Row2.D - hv_Row1.D;
                    if (nomal_size_max>width&&width >nomal_size_min )
                    {
                        HOperatorSet.GenRegionContourXld(ho_SelectedContour, out Region_contour, "filled");
                        break;
                    }
                }

            }
        }
        public override void Excute(HWindow hWindow, HObject ho_Image)
        {
            Excute_OnlyTool(hWindow, ho_Image);
        }
        public override void Excute_OnlyTool(HWindow hWindow, HObject ho_Image)
        {
            try
            {
                Array.Clear(map_pixel, 0, map_pixel.GetLength(0));
                Result_Tool = false;
                HObject ho_ImageROI;
                HObject ho_ImageROI1;
                HTuple abHis, relati;
                HTuple mean, deviation;
                HObject edges;
                HTuple area, rowCenter, columnCenter;
                HOperatorSet.GenEmptyObj(out ho_ImageROI);
                HOperatorSet.GenEmptyObj(out ho_ImageROI1);
                HOperatorSet.GenEmptyObj(out edges);
                align_Roi(index_follow, 0, out ho_ImageROI);
                if (roi_Tool.Count > 1)
                {
                    align_Roi(index_follow, 1, out ho_ImageROI1);
                //    HOperatorSet.Difference(ho_ImageROI, ho_ImageROI1, out ho_ImageROI);
                }
                if (find_contour)
                {
                    Find_contour(ho_ImageROI, ho_Image, out ho_ImageROI, hWindow);
                    if (stepbystep)
                    {
                        HOperatorSet.SetColor(hWindow, "Green");
                        HOperatorSet.ClearWindow(hWindow);
                        HOperatorSet.DispObj(ho_ImageROI, hWindow);
                        MessageBox.Show("ho_Imagecrop");
                    }
                    if (stepbystep)
                    {
                        //HObject contours;
                        //HOperatorSet.GenContoursSkeletonXld(edges, out contours, "true", 1);
                        //HOperatorSet.ClearWindow(hWindow);
                        //HOperatorSet.DispObj(contours, hWindow);
                        //MessageBox.Show("ho_Imagecrop");
                    }
                }

                HOperatorSet.AreaCenter(ho_ImageROI, out area, out rowCenter, out columnCenter);
                HOperatorSet.GrayHisto(ho_ImageROI, ho_Image, out abHis, out relati);
                HOperatorSet.Intensity(ho_ImageROI, ho_Image, out mean, out deviation);
                Mean = mean;
                Deviation = deviation;

                int result_Histogram = 0;
                int result_Histogram_tong = 0;
                for (int i = 0; i < abHis.Length; i++)
                {
                    map_pixel[i] = abHis[i];
                    result_Histogram_tong = result_Histogram_tong + abHis[i];
                    if (i >= pixel_low && i <= pixel_high)
                    {
                        result_Histogram = result_Histogram + abHis[i];
                    }
                }
                Rate_his = ((double)result_Histogram / (double)result_Histogram_tong) * 100;
                HOperatorSet.SetDraw(hWindow, "fill");
                HOperatorSet.SetShape(hWindow, "original");
                HOperatorSet.SetDraw(hWindow, "margin");
                if (min_setup <= Rate_his && Rate_his <= max_setup && deviation >= min_deviation && deviation <= max_deviation && mean>= min_mean && mean<=max_mean)
                {
                    HOperatorSet.SetColor(hWindow, "green");
                    Result_Tool = true;
                }
                else
                {
                    HOperatorSet.SetColor(hWindow, "red");
                }
                Display design_Display = new Display();
                design_Display.set_font(hWindow, 10, "mono", "true", "false");
                HOperatorSet.DispRegion(ho_ImageROI, hWindow);
                ho_ImageROI.Dispose();
                ho_ImageROI1.Dispose();
                edges.Dispose();
                // HOperatorSet.DispText()
                if (show_text)
                {
                    HOperatorSet.DispText(hWindow
                        , "Step" + job_index + "-" + tool_index + " Histogram\n" + "Rate " + Rate_his.ToString("0.00") + "%\n" + "Mean :" + Mean.ToString("0.00") + " pixel\n" + "Deviation :" + Deviation.ToString("0.00") + " pixel"
                        , "image"
                        , rowCenter
                        , columnCenter
                        , "black"
                        , new HTuple()
                        , new HTuple());

                }
               
               

            }
            catch (Exception e) { Job_Model.Statatic_Model.wirtelog.Log($"AL018 - {this.GetType().Name}" + e.ToString()); }
        }
    }
    public class BlobTool : Class_Tool
    {
        public string master_follow { get; set; } = "none";
        public string fillter_step_1 { get; set; }  = "none";
        public string fillter_step_2 { get; set; } = "none";
        public string fillter_step_3 { get; set; } = "none";
        public string fillter_step_4 { get; set; } = "none";
        public int threshold_high { get; set; } = 128;
        public int threshold_low { get; set; } = 0;
        public int Remove_Noise_Low { get; set; } = 1;
        public int ReMove_Noise_Height { get; set; } = 1000000;
        public int Dilation_W { get; set; } = 1;
        public int Dilation_H { get; set; } = 1;
        public int Erosion_W { get; set; } = 1;
        public int Erosion_H { get; set; } = 1;
        public int Approximate { get; set; } = 117;
        public int Percent_Shift { get; set; } = 36;
        public int min_Area { get; set; } = 500;
        public int max_Area { get; set; } = 1000000;
        public int max_Width { get; set; } = 1000;
        public int min_Width { get; set; } = 10;
        public int max_Height { get; set; } = 1000;
        public int min_Height { get; set; } = 10;
        public bool Partition { get; set; }= false;
        public int min_detect_object { get; set; } = 1;
        public int max_detect_object { get; set; } = 2;

        // Result Blob
        public double[] Result_Area = new double[1000];
        public double[] Result_W = new double[1000];
        public double[] Result_H = new double[1000];
        public int total_Blob { get; set; } = 0;
        public BlobTool() : base("Blob") { }
        public override void Excute(HWindow hWindow, HObject ho_Image)
        {
            Excute_OnlyTool(hWindow, ho_Image);
        }
     
        
        public override void Excute_OnlyTool(HWindow hWindow, HObject ho_Image)
        {
            HObject ho_DarkPixels;
            HObject ho_ConnectedRegions, ho_SelectedRegions, ho_RegionUnion;
            HObject ho_RegionDilation, ho_Skeleton, ho_Errors, ho_Scratches;
            HObject ho_Dots;
            HObject ho_Reg;
            HObject out_bitmap;
            HOperatorSet.GenEmptyObj(out ho_DarkPixels);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_RegionUnion);
            HOperatorSet.GenEmptyObj(out ho_RegionDilation);
            HOperatorSet.GenEmptyObj(out ho_Skeleton);
            HOperatorSet.GenEmptyObj(out ho_Errors);
            HOperatorSet.GenEmptyObj(out ho_Scratches);
            HOperatorSet.GenEmptyObj(out ho_Dots);
            HOperatorSet.GenEmptyObj(out ho_Reg);
            HOperatorSet.GenEmptyObj(out out_bitmap);
            Result_Tool = false;
            Array.Clear(Result_Area, 0, Result_Area.GetLength(0));
            try
            {
                // Lấy vùng ROI
                align_Roi(index_follow, 0, out ho_Reg);
                HOperatorSet.ReduceDomain(ho_Image, ho_Reg, out ho_Image);
                if (stepbystep == true)
                {
                    HOperatorSet.ClearWindow(hWindow);
                    HOperatorSet.DispObj(ho_Image, hWindow);
                    MessageBox.Show("ho_Imagecrop");
                }
                ho_DarkPixels.Dispose();
                HOperatorSet.Threshold(ho_Image, out ho_DarkPixels, threshold_low, threshold_high);
                if (stepbystep == true)
                {
                    HOperatorSet.ClearWindow(hWindow);
                    HOperatorSet.DispObj(ho_DarkPixels, hWindow);
                    MessageBox.Show("ho_Threshold");
                }

                HObject ho_ero;
                HOperatorSet.GenEmptyObj(out ho_ero);
                ho_ero.Dispose();
                HOperatorSet.ErosionRectangle1(ho_DarkPixels, out ho_ero, Erosion_W, Erosion_H);
                if (stepbystep == true)
                {
                    HOperatorSet.ClearWindow(hWindow);
                    HOperatorSet.DispObj(ho_ero, hWindow);
                    MessageBox.Show("ho_ero");
                }
                HOperatorSet.DilationRectangle1(ho_ero, out ho_ero, Dilation_W, Dilation_H);
                if (stepbystep == true)
                {
                    HOperatorSet.ClearWindow(hWindow);
                    HOperatorSet.DispObj(ho_ero, hWindow);
                    MessageBox.Show("ho_dila");
                }
                if (Partition == true)
                {
                    HOperatorSet.FillUp(ho_ero, out ho_ero);
                    if (stepbystep == true)
                    {
                        HOperatorSet.ClearWindow(hWindow);
                        HOperatorSet.DispObj(ho_DarkPixels, hWindow);
                        MessageBox.Show("Fill Up");
                    }
                }
                ho_Errors.Dispose();
                HOperatorSet.Connection(ho_ero, out ho_Errors);
                if (stepbystep == true)
                {
                    HOperatorSet.ClearWindow(hWindow);
                    HOperatorSet.DispObj(ho_Errors, hWindow);
                    MessageBox.Show("All Pin");
                }
                ho_Scratches.Dispose();
                HOperatorSet.SelectShape(ho_Errors, out out_bitmap, "area", "and", min_Area, max_Area);
                if (stepbystep == true)
                {
                    HOperatorSet.ClearWindow(hWindow);
                    HOperatorSet.DispObj(out_bitmap, hWindow);
                    MessageBox.Show("out_bitmap");
                }
                HObject ho_SortedRegions;
                HOperatorSet.GenEmptyObj(out ho_SortedRegions);
                ho_SortedRegions.Dispose();
                HOperatorSet.SortRegion(out_bitmap, out ho_SortedRegions, "first_point", "true", "column");/// phân loại vùng( vị trí ...)
                if (stepbystep == true)
                {
                    HOperatorSet.ClearWindow(hWindow);
                    HOperatorSet.DispObj(ho_SortedRegions, hWindow);
                    MessageBox.Show("ho_SortedRegions");
                }
                HTuple hv_Number;// so luong object loi
                HTuple hv_i;// so luong object loi               
                HOperatorSet.CountObj(ho_SortedRegions, out hv_Number);
                HTuple[] R1 = new HTuple[1000], C1 = new HTuple[1000], R2 = new HTuple[1000], C2 = new HTuple[1000], Cenx = new HTuple[1000], Ceny = new HTuple[1000], Area = new HTuple[1000];
                HTuple[] row = new HTuple[1000], col = new HTuple[1000], leng = new HTuple[1000], hight = new HTuple[1000], Phi = new HTuple[1000];
                HObject ho_ObjectSelected;
                HOperatorSet.GenEmptyObj(out ho_ObjectSelected);
                int k = 0;
                for (hv_i = 1; hv_i.Continue(hv_Number, 1); hv_i = hv_i.TupleAdd(1))
                {
                    ho_ObjectSelected.Dispose();
                    HOperatorSet.SelectObj(ho_SortedRegions, out ho_ObjectSelected, hv_i);
                    #region Duong bao trong
                    HOperatorSet.AreaCenter(ho_ObjectSelected, out Area[hv_i - 1], out Ceny[hv_i - 1], out Cenx[hv_i - 1]);
                    HOperatorSet.SmallestRectangle1(ho_ObjectSelected, out R1[hv_i - 1], out C1[hv_i - 1], out R2[hv_i - 1], out C2[hv_i - 1]);// Lấy kích thước ký tự
                    double w1 = C2[hv_i - 1] - C1[hv_i - 1];
                    double l1 = R2[hv_i - 1] - R1[hv_i - 1];
                    HOperatorSet.SmallestRectangle2(ho_ObjectSelected, out row[hv_i - 1], out col[hv_i - 1], out Phi[hv_i - 1], out hight[hv_i - 1], out leng[hv_i - 1]);
                    double w = 0;
                    double h = 0;
                    double degrees = Phi[hv_i - 1].TupleDeg();
                    if (degrees >= 45)
                    {
                        degrees = 90 - degrees;
                    }
                    else
                    if (degrees <= -45)
                    {
                        degrees = -(90 + degrees);
                    }

                    if (w1 > l1 && hight[hv_i - 1] > leng[hv_i - 1])
                    {
                        w = 2 * hight[hv_i - 1];
                        h = 2 * leng[hv_i - 1];
                    }
                    else
                    {
                        w = 2 * leng[hv_i - 1];
                        h = 2 * hight[hv_i - 1];
                    }

                    double x = col[hv_i - 1] - w / 2;
                    double y = row[hv_i - 1] - h / 2;
                    double cenx = col[hv_i - 1];
                    double ceny = row[hv_i - 1];
                    double phi = Phi[hv_i - 1];

                    if (stepbystep == true)
                    {
                        //    HOperatorSet.DispRectangle2(hWindow, row[hv_i - 1], col[hv_i - 1], Phi[hv_i - 1], hight[hv_i - 1], leng[hv_i - 1]);
                        MessageBox.Show("DegreesofObject " + hv_i + ":" + degrees + " -w: " + w + " -h: " + h + " -phi: " + phi + " -Area: " + Area[hv_i - 1]);
                    }
                    if (h <= max_Height && h >= min_Height && w >= min_Width && w <= max_Width && min_Area <= Area[hv_i - 1] && max_Area >= Area[hv_i - 1])
                    {
                        HOperatorSet.SetColor(hWindow, "green");
                        HOperatorSet.DispObj(ho_ObjectSelected, hWindow);

                        Result_Area[hv_i - 1] = Area[hv_i - 1];
                        Result_H[hv_i - 1] = h;
                        Result_W[hv_i - 1] = w;


                        k += 1;
                    }
                    #endregion
                }
                total_Blob = k;
                if (min_detect_object <= total_Blob && total_Blob <= max_detect_object)
                {
                    Result_Tool = true;
                }

                ho_DarkPixels.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_SelectedRegions.Dispose();
                ho_RegionUnion.Dispose();
                ho_RegionDilation.Dispose();
                ho_Skeleton.Dispose();
                ho_Errors.Dispose();
                ho_Scratches.Dispose();
                ho_Dots.Dispose();
                ho_Reg.Dispose();
            }
            catch (Exception ex)
            {
                Job_Model.Statatic_Model.wirtelog.Log($"AL019 - {this.GetType().Name}" + ex.ToString());

            }
        }
    }
    public class  Image_Processing : Class_Tool
    {
        public int index_capture {  get; set; } = 0;
        public Image_Processing() : base("Image_Process") { }
        public override void Excute(HWindow hWindow, HObject ho_Image)
        {

        }
        public override void Excute_OnlyTool(HWindow hWindow, HObject ho_Image)
        {

        }
    }
    public class Image_Roate : Class_Tool
    {
        HObject image_roate;
        
        public int angle_roate { get; set; } = 0;
        public string input_image { get; set; } = "Origin_Image";
        public string roate_angle { get; set; } = "0 độ";
        public bool FL_Red { get; set; } = false;
        public bool image_color {  get; set; } = false;
        public bool FL_Green { get; set; } = false;
        public bool FL_BLue {  get; set; } = false;
        public bool Cv2Gray { get; set; } = false;
        public Image_Roate() : base("Roate_Img") { }
        public override void Excute(HWindow hWindow, HObject ho_Image)
        {

            Excute_OnlyTool(hWindow, ho_Image);
        }
        public override void Excute_OnlyTool(HWindow hWindow, HObject ho_Image)
        {
            HObject img_FLR, img_FLG, img_FLB, img_Clear;
            HOperatorSet.GenEmptyObj(out img_Clear);
            HOperatorSet.GenEmptyObj(out img_FLR);
            HOperatorSet.GenEmptyObj(out img_FLG);
            HOperatorSet.GenEmptyObj(out img_FLB);
            HTuple Width, Height;
            HOperatorSet.GetImageSize(ho_Image, out Width, out Height);
            HOperatorSet.GenImage1(out img_Clear, "byte", Width, Height, 0);
            try
            {
                if (image_color)
                {
                    HOperatorSet.Decompose3(ho_Image, out img_FLR, out img_FLG, out img_FLB);

                    if (FL_Red)
                    {
                        img_FLR = img_Clear;
                    }
                    if (FL_Green)
                    {
                        img_FLG = img_Clear;
                    }
                    if (FL_BLue)
                    {
                        img_FLB = img_Clear;
                    }
                    HOperatorSet.Compose3(img_FLR, img_FLG, img_FLB, out ho_Image);
                    if (Cv2Gray)
                    {
                        HOperatorSet.Rgb1ToGray(ho_Image, out ho_Image);
                    }
                }

                HOperatorSet.RotateImage(ho_Image, out Job_Model.Statatic_Model.Input_Image[camera_index, job_index, 0], angle_roate, "constant");
                HOperatorSet.ClearWindow(hWindow);
                HOperatorSet.DispObj(Job_Model.Statatic_Model.Input_Image[camera_index, job_index, 0], hWindow);

            }
            catch (Exception e) { Job_Model.Statatic_Model.wirtelog.Log($"AL009 - {this.GetType().Name}"  + e.ToString()); }
        }
    }
    public class Barcode_2D : Class_Tool
    {
        public string master_follow { get; set; } = "none";
        public string Codetype {  get; set; }
        public int max_leng_code { get; set; } = 20;
        public int min_leng_code { get; set; } = 20;
        public int Blur { get; set; } = 1;
        // resule code
        public Barcode barcodes = new Barcode();    
        public Barcode_2D() : base("Barcode_2D") { }
        public override void Excute(HWindow hWindow, HObject ho_Image)
        {
            Excute_OnlyTool(hWindow, ho_Image);


        }
        public override void Excute_OnlyTool(HWindow hWindow, HObject ho_Image)
        {
            try
            {
                HTuple hv_DataCodeHandle = new HTuple(), hv_ResultHandles = new HTuple(), hv_DecodedDataStrings = new HTuple();
                HTuple hv_Message = new HTuple();
                HObject image_Reducer;
                HObject ho_SymbolXLDs = null;
                HObject ho_Reg;
                HOperatorSet.GenEmptyObj(out ho_Reg);
                HOperatorSet.GenEmptyObj(out image_Reducer);
                HOperatorSet.GenEmptyObj(out ho_SymbolXLDs);
                Result_Tool = false;
                // dATACODE = new DATACODE();
                // HRegion ROI = new HRegion();
                // ROI.GenRectangle2(Y1, X1, Phi, X2, Y2);
                // lấy vùng roi
                LibaryHalcon libaryHalcon = new LibaryHalcon();
                HTuple homMat2D = null;
                if (index_follow >= 0)
                {
                    homMat2D = Statatic_Model.hommat2D[camera_index, job_index, index_follow];
                    if (roi_Tool[0].Type == "Rectangle")
                    {
                        RectangleROI rectangleROI = (RectangleROI)roi_Tool[0];
                        libaryHalcon.Alingn_Tool_Rectang(homMat2D, rectangleROI.X, rectangleROI.Y, rectangleROI.Phi, rectangleROI.Width, rectangleROI.Height, out ho_Reg);
                    }
                    if (roi_Tool[0].Type == "Circle")
                    {
                        CircleROI CirROI = (CircleROI)roi_Tool[0];
                        libaryHalcon.Align_Tool_Cir(homMat2D, CirROI.CenterX, CirROI.CenterY, CirROI.Radius, out ho_Reg);

                    }

                }
                else
                {
                    if (roi_Tool[0].Type == "Rectangle")
                    {
                        RectangleROI rectangleROI = (RectangleROI)roi_Tool[0];

                        HOperatorSet.GenRectangle2(out ho_Reg, rectangleROI.X, rectangleROI.Y, rectangleROI.Phi, rectangleROI.Width, rectangleROI.Height);
                    }
                    if (roi_Tool[0].Type == "Circle")
                    {
                        CircleROI CirROI = (CircleROI)roi_Tool[0];
                        HOperatorSet.GenCircle(out ho_Reg, CirROI.CenterX, CirROI.CenterY, CirROI.Radius);
                    }
                }
                HOperatorSet.ReduceDomain(ho_Image, ho_Reg, out image_Reducer);
                //HOperatorSet.Threshold(image_Reducer, out image_Reducer, threshold_Min, threshold_Max);
                //VisionMode visionMode = VisionMode.Runtime;
                if (stepbystep)
                {
                    HOperatorSet.ClearWindow(hWindow);
                    HOperatorSet.DispObj(image_Reducer, hWindow);
                    MessageBox.Show("Threshold");
                }


                hv_DataCodeHandle.Dispose();
                HOperatorSet.CreateDataCode2dModel(Codetype, new HTuple(), new HTuple(), out hv_DataCodeHandle);

                ho_SymbolXLDs.Dispose(); hv_ResultHandles.Dispose(); hv_DecodedDataStrings.Dispose();
                HOperatorSet.FindDataCode2d(image_Reducer, out ho_SymbolXLDs, hv_DataCodeHandle, new HTuple(), new HTuple(), out hv_ResultHandles, out hv_DecodedDataStrings);

                //HOperatorSet.DispObj(image_Reducer, hWindow);



                hv_Message.Dispose();
                hv_Message = "No data code found.";
                if (hv_Message == null)
                    hv_Message = new HTuple();
                hv_Message[1] = "The symbol could not be found with the standard";
                if (hv_Message == null)
                    hv_Message = new HTuple();
                hv_Message[2] = "default setting. Please adjust the model parameters";
                if (hv_Message == null)
                    hv_Message = new HTuple();
                hv_Message[3] = "to read this symbol.";
                //
                //If no data code could be found
                if ((int)(new HTuple((new HTuple(hv_DecodedDataStrings.TupleLength())).TupleEqual(0))) != 0)
                {
                    //  disp_message(hWindow, hv_Message, "window", 40, 12, "red", "true");
                    Console.WriteLine(hv_Message.ToString());
                    HOperatorSet.SetDraw(hWindow, "margin");
                    HOperatorSet.SetColor(hWindow, "red");
                    HOperatorSet.DispObj(ho_Reg, hWindow);

                }
                else
                {
                    // disp_message(hWindow, hv_DecodedDataStrings, "window", 40, 12, "black", "true");
                    Result_Tool = true;
                    HOperatorSet.SetColor(hWindow, "green");
                    HOperatorSet.DispObj(ho_SymbolXLDs, hWindow);
                    barcodes.data_code = hv_DecodedDataStrings;
                    Job_Model.Statatic_Model.barcode = hv_DecodedDataStrings;
                    barcodes.format_code = Codetype;
                }
                //   ho_Image.Dispose();
                ho_SymbolXLDs.Dispose();
                hv_Message.Dispose();
                hv_DataCodeHandle.Dispose();
                hv_ResultHandles.Dispose();
                hv_DecodedDataStrings.Dispose();
            }
            catch (Exception e) { Job_Model.Statatic_Model.wirtelog.Log($"AL010 - {this.GetType().Name}" + e.ToString()); }
        }
    }
    public class Barcode
    {
        public string data_code { get; set; }
        public string format_code { get; set; }
    }
    public class Save_Image_Tool : Class_Tool
    {
        public bool Save_OK { get; set; } = false;
        public bool Save_NG { get; set; }=false;
        public string file_name_OK { get; set; }
        public string file_name_NG { get; set; }
        // resule code
       
        public Save_Image_Tool() : base("Save_Image_Tool") { }
        public override void Excute(HWindow hWindow, HObject ho_Image)
        {

            Excute_OnlyTool(hWindow, ho_Image);



        }
        public override void Excute_OnlyTool(HWindow hWindow, HObject ho_Image)
        {
            Result_Tool = true;
            try
            {
                if (Save_OK && Statatic_Model.model_run.Cameras[camera_index].Jobs[job_index].result_job == "OK")
                {
                    //HImage result_image = hWindow.DumpWindowImage();
                    //ho_Image = result_image;
                    string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tiff", ".tif" };
                    string[] allFiles = Directory.GetFiles(file_name_OK);
                    int imageCount = 0;
                    foreach (var file in allFiles)
                    {
                        if (Array.Exists(imageExtensions, ext => ext.Equals(Path.GetExtension(file), StringComparison.OrdinalIgnoreCase)))
                        {
                            imageCount++;
                        }
                    }
                    if (Statatic_Model.barcode != "")
                    {
                        string file_name = file_name_OK + "\\" + Statatic_Model.barcode + job_index + ".jpg";
                        //  string file_name= file_name_OK  +"\\" + imageCount+ ".jpg";
                        HOperatorSet.WriteImage(ho_Image, "jpeg", 0, file_name);
                    }

                }
                if (Save_NG && Statatic_Model.model_run.Cameras[camera_index].Jobs[job_index].result_job == "NG")
                {
                    //HImage result_image = hWindow.DumpWindowImage();
                    //ho_Image = result_image;
                    string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tiff", ".tif" };
                    string[] allFiles = Directory.GetFiles(file_name_NG);
                    int imageCount = 0;
                    foreach (var file in allFiles)
                    {

                        if (Array.Exists(imageExtensions, ext => ext.Equals(Path.GetExtension(file), StringComparison.OrdinalIgnoreCase)))
                        {
                            imageCount++;
                        }
                    }
                    if (Statatic_Model.barcode != "")
                    {
                        string file_name = file_name_NG + "\\" + Statatic_Model.barcode + job_index + ".jpg";
                        //  string file_name= file_name_OK  +"\\" + imageCount+ ".jpg";
                        HOperatorSet.WriteImage(ho_Image, "jpeg", 0, file_name);
                    }
                    //  string file_name = file_name_NG +"\\"+ imageCount + ".jpg";
                    //  HOperatorSet.WriteImage(ho_Image, "jpeg", 0, file_name);
                }
            }
            catch (Exception ex) { Statatic_Model.wirtelog.Log("error save image huhu" + ex.ToString()); }
        }
    }
    public class Segmentation_Tool : Class_Tool
    {
        public string master_follow { get; set; } = "none";
        public HTuple hv_GMMHandle;
        public Segmentation_Tool() : base("Segmentation_Tool") { }
        public void train_sengment(HObject ho_Image)
        {
            try
            {
               //d HOperatorSet.rea
             
              
            }
            catch(Exception ex)
            {

            }
        }
        public override void Excute(HWindow hWindow, HObject ho_Image)
        {
            Excute_OnlyTool(hWindow, ho_Image);
        }
        public override void Excute_OnlyTool(HWindow hWindow, HObject ho_Image)
        {
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_Sea, ho_Deck, ho_Walls;
            HObject ho_Chimney, ho_Classes, ho_ClassRegions, ho_ImageClass;

            // Local control variables 

            HTuple hv_WindowHandle = new HTuple(), hv_Color = new HTuple();
            HTuple hv_Message = new HTuple();
            HTuple hv_Centers = new HTuple(), hv_Iter = new HTuple();
            // Initialize local and output iconic variables 

            HOperatorSet.GenEmptyObj(out ho_Sea);
            HOperatorSet.GenEmptyObj(out ho_Deck);
            HOperatorSet.GenEmptyObj(out ho_Walls);
            HOperatorSet.GenEmptyObj(out ho_Chimney);
            HOperatorSet.GenEmptyObj(out ho_Classes);
            HOperatorSet.GenEmptyObj(out ho_ClassRegions);
            HOperatorSet.GenEmptyObj(out ho_ImageClass);
            try
            {
                //This example program shows how to segment an RGB image with a GMM
                //classifier.  The classifier is trained with four different colors.  In contrast to
                //other classifiers, colors that have not been trained can be rejected easily.


                //HOperatorSet.SetWindowAttr("background_color", "black");
                //HOperatorSet.OpenWindow(0, 0, 735, 485, 0, "visible", "", out hv_WindowHandle);
                //HDevWindowStack.Push(hv_WindowHandle);
                //  set_display_font(hv_WindowHandle, 14, "mono", "true", "false");
                HOperatorSet.SetDraw(hWindow, "margin");
                HOperatorSet.SetColored(hWindow, 6);
                HOperatorSet.SetLineWidth(hWindow, 3);
                if (stepbystep)
                {


                    HOperatorSet.GenEmptyObj(out ho_ImageClass);
                    int count_class = roi_Tool.Count;
                    for (int i = 0; i < count_class; i++)
                    {
                        HObject buffer;
                        align_Roi(index_follow, i, out buffer);
                        HOperatorSet.ConcatObj(buffer, ho_ImageClass, out buffer);
                        ho_ImageClass.Dispose();
                        ho_ImageClass = buffer;
                    }



                    //hv_Message.Dispose();
                    //hv_Message = "Training regions for the color classifier";
                    //   disp_message(hv_WindowHandle, hv_Message, "window", 12, 12, "black", "true");
                    //   disp_continue_message(hv_WindowHandle, "black", "true");
                    // stop(...); only in hdevelop
                    //Create the classifier and add the samples.
                    //  hv_GMMHandle.Dispose();
                    HOperatorSet.CreateClassGmm(1, count_class, (new HTuple(1)).TupleConcat(10), "full",
                        "none", 2, 42, out hv_GMMHandle);
                    HOperatorSet.AddSamplesImageClassGmm(ho_Image, ho_ImageClass, hv_GMMHandle, 2.0);
                    //if (HDevWindowStack.IsOpen())
                    //{
                    //    HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
                    //}

                    HOperatorSet.TrainClassGmm(hv_GMMHandle, 500, 1e-4, "uniform", 1e-4, out hv_Centers,
                        out hv_Iter);
                }
                //ho_Image.Dispose();
                //HOperatorSet.ReadImage(out ho_Image, "patras");
                //if (HDevWindowStack.IsOpen())
                //{
                //    HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
                //}
                //hv_Color.Dispose();
                //hv_Color = new HTuple();
                hv_Color[0] = "indian red";
                hv_Color[1] = "cornflower blue";
                hv_Color[2] = "white";
                hv_Color[3] = "black";
                hv_Color[4] = "yellow";
                //Create regions that contain the training samples of the four classes
                //ho_Sea.Dispose();
                //HOperatorSet.GenRectangle1(out ho_Sea, 10, 10, 120, 270);
                //ho_Deck.Dispose();
                //HOperatorSet.GenRectangle2(out ho_Deck, (new HTuple(170)).TupleConcat(400),
                //    (new HTuple(350)).TupleConcat(375), (new HTuple(-0.56)).TupleConcat(-0.75),
                //    (new HTuple(64)).TupleConcat(104), (new HTuple(26)).TupleConcat(11));
                //{
                //    HObject ExpTmpOutVar_0;
                //    HOperatorSet.Union1(ho_Deck, out ExpTmpOutVar_0);
                //    ho_Deck.Dispose();
                //    ho_Deck = ExpTmpOutVar_0;
                //}
                //ho_Walls.Dispose();
                //HOperatorSet.GenRectangle1(out ho_Walls, 355, 623, 420, 702);
                //ho_Chimney.Dispose();
                //HOperatorSet.GenRectangle2(out ho_Chimney, 286, 623, -0.56, 64, 33);
                //ho_Classes.Dispose();
                //HOperatorSet.ConcatObj(ho_Sea, ho_Deck, out ho_Classes);
                //{
                //    HObject ExpTmpOutVar_0;
                //    HOperatorSet.ConcatObj(ho_Classes, ho_Walls, out ExpTmpOutVar_0);
                //    ho_Classes.Dispose();
                //    ho_Classes = ExpTmpOutVar_0;
                //}
                //{
                //    HObject ExpTmpOutVar_0;
                //    HOperatorSet.ConcatObj(ho_Classes, ho_Chimney, out ExpTmpOutVar_0);
                //    ho_Classes.Dispose();
                //    ho_Classes = ExpTmpOutVar_0;
                //}
                // HObject ho_ImageClass;

                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    {
                        HTuple
                          ExpTmpLocalVar_Message = hv_Message + " ready.";
                        hv_Message.Dispose();
                        hv_Message = ExpTmpLocalVar_Message;
                    }
                }
                if (hv_Message == null)
                    hv_Message = new HTuple();

                //  disp_message(hv_WindowHandle, hv_Message, "window", 12, 12, "black", "true");
                //Segment (classify) the image.
                ho_ClassRegions.Dispose();
                HOperatorSet.ClassifyImageClassGmm(ho_Image, out ho_ClassRegions, hv_GMMHandle,
                    0.0001);
                //ho_ImageClass.Dispose();
                //for(int i=0;i< ho_ClassRegions.CountObj();i++)
                //{
                //    HOperatorSet.SetColor(hWindow, hv_Color[i]);
                //    HOperatorSet.DispObj(ho_ClassRegions[i], hWindow);
                //}
                HOperatorSet.CountObj(ho_ClassRegions, out HTuple numClasses);
                HOperatorSet.SetDraw(hWindow, "fill");
                for (int i = 1; i <= numClasses; i++)
                {
                    // Lấy từng lớp (region) từ `ho_ClassRegions`
                    HOperatorSet.SelectObj(ho_ClassRegions, out HObject ho_RegionClass, i);

                    // Hiển thị từng lớp
                    HOperatorSet.SetColor(hWindow, hv_Color[i]);  // Chọn màu hiển thị
                                                                  //   HOperatorSet.DispObj(ho_Image, hWindow);  // Hiển thị hình ảnh gốc
                    HOperatorSet.DispObj(ho_RegionClass, hWindow);  // Hiển thị vùng thuộc lớp i

                    // Thêm thông báo hoặc dừng để quan sát từng lớp
                    //    HOperatorSet.DispText(hWindow, $"Class {i}", "window", 12, 12, "black", new HTuple(), new HTuple());
                    //  HOperatorSet.DispContinueMessage(hv_WindowHandle, "black", "true");
                    // HOperatorSet.WaitSeconds(1);  // Dừng 1 giây để quan sát
                }

                //HOperatorSet.RegionToMean(ho_ClassRegions, ho_Image, out ho_ImageClass);

                //HOperatorSet.DispObj(ho_ImageClass, hWindow);



            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_Image.Dispose();
                ho_Sea.Dispose();
                ho_Deck.Dispose();
                ho_Walls.Dispose();
                ho_Chimney.Dispose();
                ho_Classes.Dispose();
                ho_ClassRegions.Dispose();
                ho_ImageClass.Dispose();

                hv_WindowHandle.Dispose();
                hv_Color.Dispose();
                hv_Message.Dispose();
                //  hv_GMMHandle.Dispose();
                hv_Centers.Dispose();
                hv_Iter.Dispose();

                throw HDevExpDefaultException;
            }
            ho_Image.Dispose();
            ho_Sea.Dispose();
            ho_Deck.Dispose();
            ho_Walls.Dispose();
            ho_Chimney.Dispose();
            ho_Classes.Dispose();
            ho_ClassRegions.Dispose();
            ho_ImageClass.Dispose();

            hv_WindowHandle.Dispose();
            hv_Color.Dispose();
            hv_Message.Dispose();
            // hv_GMMHandle.Dispose();
            hv_Centers.Dispose();
            hv_Iter.Dispose();
        
    }
        public void draw_mask(out HObject ho_Image)
        {
            align_Roi(-1, 0, out ho_Image);
        }

    }
    public class OCR_Tool : Class_Tool
    {
        public string code_type { get; set; } = "Universal_Rej.occ";
        public string master_follow { get; set; } = "none";
        public int threshold_high { get; set; } = 128;
        public int threshold_low { get; set; } = 0;
        public int Remove_Noise_Low { get; set; } = 1;
        public int ReMove_Noise_Height { get; set; } = 1000000;
        public int Dilation_W { get; set; } = 1;
        public int Dilation_H { get; set; } = 1;
        public int Erosion_W { get; set; } = 1;
        public int Erosion_H { get; set; } = 1;
        public int Approximate { get; set; } = 117;
        public int Percent_Shift { get; set; } = 36;
        public int min_contract { get; set; } = 30;
        public int min_Area { get; set; } = 500;
        public int max_Area { get; set; } = 1000000;
        public int max_Width { get; set; } = 1000;
        public int min_Width { get; set; } = 10;
        public int max_Height { get; set; } = 1000;
        public int min_Height { get; set; } = 10;
        public bool Partition { get; set; } = false;
        public OCR_Tool() : base("OCR_Tool") { }
       
        public override void Excute(HWindow hWindow, HObject ho_Image)
        {
            Excute_OnlyTool(hWindow, ho_Image);
        }
        public override void Excute_OnlyTool(HWindow hWindow, HObject ho_Image)
        {
            HObject ho_Chacracters;
            HOperatorSet.GenEmptyObj(out ho_Chacracters);
            HTuple hv_OCRHandle, hv_Class, hv_Confidence;
            HObject ho_DarkPixels;
            HObject ho_ConnectedRegions, ho_SelectedRegions, ho_RegionUnion;
            HObject ho_RegionDilation, ho_Skeleton, ho_Errors, ho_Scratches;
            HObject ho_Dots;
            HObject ho_Reg;
            HObject out_bitmap;
            HOperatorSet.GenEmptyObj(out ho_DarkPixels);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_RegionUnion);
            HOperatorSet.GenEmptyObj(out ho_RegionDilation);
            HOperatorSet.GenEmptyObj(out ho_Skeleton);
            HOperatorSet.GenEmptyObj(out ho_Errors);
            HOperatorSet.GenEmptyObj(out ho_Scratches);
            HOperatorSet.GenEmptyObj(out ho_Dots);
            HOperatorSet.GenEmptyObj(out ho_Reg);
            HOperatorSet.GenEmptyObj(out out_bitmap);
            Result_Tool = false;


            // HOperatorSet.DoOcrMultiClassCnn(ho_Chacracters, ho_Image, hv_OCRHandle, out hv_Class, out hv_Confidence);
            try
            {

                // Lấy vùng ROI
                align_Roi(index_follow, 0, out ho_Reg);
                HOperatorSet.ReduceDomain(ho_Image, ho_Reg, out ho_Image);
                if (stepbystep == true)
                {
                    HOperatorSet.ClearWindow(hWindow);
                    HOperatorSet.DispObj(ho_Image, hWindow);
                    MessageBox.Show("ho_Imagecrop");
                }
                ho_DarkPixels.Dispose();
                HOperatorSet.Threshold(ho_Image, out ho_DarkPixels, threshold_low, threshold_high);
                if (stepbystep == true)
                {
                    HOperatorSet.ClearWindow(hWindow);
                    HOperatorSet.DispObj(ho_DarkPixels, hWindow);
                    MessageBox.Show("ho_Threshold");
                }

                HObject ho_ero;
                HOperatorSet.GenEmptyObj(out ho_ero);
                ho_ero.Dispose();
                HOperatorSet.ErosionRectangle1(ho_DarkPixels, out ho_ero, Erosion_W, Erosion_H);
                if (stepbystep == true)
                {
                    HOperatorSet.ClearWindow(hWindow);
                    HOperatorSet.DispObj(ho_ero, hWindow);
                    MessageBox.Show("ho_ero");
                }
                HOperatorSet.DilationRectangle1(ho_ero, out ho_ero, Dilation_W, Dilation_H);
                if (stepbystep == true)
                {
                    HOperatorSet.ClearWindow(hWindow);
                    HOperatorSet.DispObj(ho_ero, hWindow);
                    MessageBox.Show("ho_dila");
                }
                if (Partition == true)
                {
                    HOperatorSet.FillUp(ho_ero, out ho_ero);
                    if (stepbystep == true)
                    {
                        HOperatorSet.ClearWindow(hWindow);
                        HOperatorSet.DispObj(ho_DarkPixels, hWindow);
                        MessageBox.Show("Fill Up");
                    }
                }
                ho_Errors.Dispose();
                HOperatorSet.Connection(ho_ero, out ho_Errors);
                if (stepbystep == true)
                {
                    HOperatorSet.ClearWindow(hWindow);
                    HOperatorSet.DispObj(ho_Errors, hWindow);
                    MessageBox.Show("All Pin");
                }
                ho_Scratches.Dispose();
                HOperatorSet.SelectShape(ho_Errors, out out_bitmap, "area", "and", min_Area, max_Area);
                if (stepbystep == true)
                {
                    HOperatorSet.ClearWindow(hWindow);
                    HOperatorSet.DispObj(out_bitmap, hWindow);
                    MessageBox.Show("out_bitmap");
                }
                HObject ho_SortedRegions;
                HOperatorSet.GenEmptyObj(out ho_SortedRegions);
                ho_SortedRegions.Dispose();
                HOperatorSet.SortRegion(out_bitmap, out ho_SortedRegions, "first_point", "true", "column");/// phân loại vùng( vị trí ...)
                if (stepbystep == true)
                {
                    HOperatorSet.ClearWindow(hWindow);
                    HOperatorSet.DispObj(ho_SortedRegions, hWindow);
                    MessageBox.Show("ho_SortedRegions");
                }

                HObject ho_ObjectSelected;
                HOperatorSet.GenEmptyObj(out ho_ObjectSelected);
                HTuple hv_TextModel;
                HOperatorSet.CreateTextModelReader("auto", code_type, out hv_TextModel); //Universal_0-9A-Z_Rej
                HOperatorSet.SetTextModelParam(hv_TextModel, "dot_print", "true");

                HOperatorSet.SetTextModelParam(hv_TextModel, "min_contrast", min_contract);
                HTuple hv_TextResultID;
                HOperatorSet.FindText(ho_Image, hv_TextModel, out hv_TextResultID);
                HObject ho_Characters;
                HOperatorSet.GetTextObject(out ho_Characters, hv_TextResultID, "all_lines");

                HOperatorSet.GetTextResult(hv_TextResultID, "class", out hv_Class);
                //
                //Display result.
                HOperatorSet.SetLineWidth(hWindow, 2);
                HOperatorSet.DispObj(ho_SortedRegions, hWindow);
                HOperatorSet.SetColored(hWindow, 12);
                HOperatorSet.DispObj(ho_Characters, hWindow);
                HOperatorSet.SetDraw(hWindow, "margin");
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    Display display = new Display();
                    display.disp_message(hWindow, "Lot number: " + (hv_Class.TupleSum()), "window",
                        12, 12, "black", "true");
                    if (hv_Class.Length > 0)
                        Result_Tool = true;
                }


                ho_DarkPixels.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_SelectedRegions.Dispose();
                ho_RegionUnion.Dispose();
                ho_RegionDilation.Dispose();
                ho_Skeleton.Dispose();
                ho_Errors.Dispose();
                ho_Scratches.Dispose();
                ho_Dots.Dispose();
                ho_Reg.Dispose();
            }
            catch (Exception ex)
            {
                Job_Model.Statatic_Model.wirtelog.Log($"AL011 - {this.GetType().Name}" + ex.ToString());

            }
        }

    }
    public class FitLine_Tool : Class_Tool
    {
        public int index_Fr_tool { get; set; }
        public int index_To_tool { get; set; }
        public string Geometry { get; set; }
        public string From_Pos { get; set; }
        public string To_Pos { get; set; }
        public string From_Point { get; set; }
        public string To_Point { get; set; }
        public double Max_Dis { get; set; }
        public double Min_Dis { get; set; }
        public string Fr_Name_Tool { get; set; }
        public string To_Name_Tool { get; set; }
        // Get Point
        public double Fr_X { get; set; }
        public double Fr_Y { get; set; }
        public double Fr_X1 { get; set; }
        public double Fr_Y1 { get; set; }
        public double Fr_X2 { get; set; }
        public double Fr_Y2 { get; set; }
        public double To_X { get; set; }
        public double To_Y { get; set; }
        public double To_X1 { get; set; }
        public double To_Y1 { get; set; }
        public double To_X2 { get; set; }
        public double To_Y2 { get; set; }
        // Get Result
        public double X_Fr { get; set; }
        public double Y_Fr { get; set; }
        public double X_To { get; set; }
        public double Y_To { get; set; }
        public double X_Center { get; set; }
        public double Y_Center { get; set; }
        public FitLine_Tool() : base("FitLine_Tool") { }

        public override void Excute(HWindow hWindow, HObject ho_Image)
        {
            Excute_OnlyTool(hWindow, ho_Image);
        }
        public override void Excute_OnlyTool(HWindow hWindow, HObject ho_Image)
        {
            try
            {
                Result_Tool = false;
                if (Fr_Name_Tool == "FindLine")
                {
                    FindLineTool tool = (FindLineTool)Job_Model.Statatic_Model.model_run.Cameras[camera_index].Jobs[job_index].Images[image_index].Tools[index_Fr_tool];
                    Fr_X = tool.Xcenterob;
                    Fr_Y = tool.Ycenterob;
                    Fr_X1 = tool.X1ob;
                    Fr_Y1 = tool.Y1ob;
                    Fr_X2 = tool.X2ob;
                    Fr_Y2 = tool.Y2ob;
                }
                if (Fr_Name_Tool == "FindCircle")
                {
                    FindCircleTool tool = (FindCircleTool)Job_Model.Statatic_Model.model_run.Cameras[camera_index].Jobs[job_index].Images[image_index].Tools[index_Fr_tool];
                    Fr_X = tool.X_center;
                    Fr_Y = tool.Y_center;

                }
                if (Fr_Name_Tool == "ShapeModel")
                {
                    ShapeModelTool tool = (ShapeModelTool)Job_Model.Statatic_Model.model_run.Cameras[camera_index].Jobs[job_index].Images[image_index].Tools[index_Fr_tool];
                    Fr_X = tool.X_Master[0];
                    Fr_Y = tool.Y_Master[0];
                }
                if (To_Name_Tool == "FindLine")
                {
                    FindLineTool tool = (FindLineTool)Job_Model.Statatic_Model.model_run.Cameras[camera_index].Jobs[job_index].Images[image_index].Tools[index_To_tool];
                    To_X = tool.Xcenterob;
                    To_Y = tool.Ycenterob;
                    To_X1 = tool.X1ob;
                    To_Y1 = tool.Y1ob;
                    To_X2 = tool.X2ob;
                    To_Y2 = tool.Y2ob;
                }
                if (To_Name_Tool == "FindCircle")
                {
                    FindCircleTool tool = (FindCircleTool)Job_Model.Statatic_Model.model_run.Cameras[camera_index].Jobs[job_index].Images[image_index].Tools[index_To_tool];
                    To_X = tool.X_center;
                    To_Y = tool.Y_center;

                }
                if (To_Name_Tool == "ShapeModel")
                {
                    ShapeModelTool tool = (ShapeModelTool)Job_Model.Statatic_Model.model_run.Cameras[camera_index].Jobs[job_index].Images[image_index].Tools[index_To_tool];
                    To_X = tool.X_Master[0];
                    To_Y = tool.Y_Master[0];
                }

                if (From_Point == "StartPoint")
                {
                    X_Fr = Fr_X1;
                    Y_Fr = Fr_Y1;
                }
                if (From_Point == "CenterPoint")
                {
                    X_Fr = Fr_X;
                    Y_Fr = Fr_Y;
                }
                if (From_Point == "EndPoint")
                {
                    X_Fr = Fr_X2;
                    Y_Fr = Fr_Y2;
                }
                if (To_Point == "StartPoint")
                {
                    X_To = To_X1;
                    Y_To = To_Y1;
                }
                if (To_Point == "CenterPoint")
                {
                    X_To = To_X;
                    Y_To = To_Y;
                }
                if (To_Point == "EndPoint")
                {
                    X_To = To_X2;
                    Y_To = To_Y2;
                }
                HOperatorSet.DispArrow(hWindow, X_Fr, Y_Fr, X_To, Y_To, 1);
                X_Center = (X_Fr + X_To) / 2;
                Y_Center = (Y_Fr + Y_To) / 2;
                Result_Tool = true;


            }
            catch (Exception ex) { Job_Model.Statatic_Model.wirtelog.Log($"AL012 - {this.GetType().Name}" + ex.ToString()); }
        }

    }
    public class Calibrate_Plate_Tool : Class_Tool
    {
        public string file_Calib_describe { get;set;}
        public string file_paracam {  get;set;}
        public string file_Pose_Came { get;set;}
        public string file_image_calib { get;set;}
        public double focus {  get;set;}
        public double Cell_Width { get;set;}
        public double Cell_Height { get;set;}
        public double Thick_Ness { get;set;}


        public Calibrate_Plate_Tool() : base("Calibrate_Plate_Tool") { }
        public override void Excute_OnlyTool(HWindow hWindow, HObject ho_Image)
        {
            HObject Image_ = new HObject();
            List<HObject> Image_read = new List<HObject>();
            HTuple calib_ID = new HTuple(); HTuple error = new HTuple();
            Display display = new Display();
            HTuple para_start = new HTuple();
            HTuple camera_type = new HTuple();
            HTuple cellx, celly;
            HTuple width, height;
            HTuple came_para = new HTuple();
            HTuple cam_Discribe = new HTuple();
            HTuple hv_CameraParameters = new HTuple();
            HTuple hv_CameraPose = new HTuple();
            try
            {

                cellx = Cell_Width / 1000;
                celly = Cell_Height / 1000;
                string[] allFiles = Directory.GetFiles(file_image_calib);
                for (int i = 0; i < allFiles.Length; i++)
                {
                    HOperatorSet.ReadImage(out Image_, allFiles[i]);
                    Image_read.Add(Image_);
                }
                HOperatorSet.GetImageSize(Image_read[0], out width, out height);
                HTuple width_2 = width / 2;
                HTuple height_2 = height / 2;
                display.gen_cam_par_area_scan_division(focus, 0, cellx, celly, width_2, height_2, width, height, out para_start);
                HOperatorSet.CreateCalibData("calibration_object", 1, 1, out calib_ID);
                display.get_cam_par_data(para_start, "camera_type", out camera_type);
                //  HOperatorSet.readpa
                HOperatorSet.SetCalibDataCalibObject(calib_ID, 0, file_Calib_describe);
                HOperatorSet.SetCalibDataCamParam(calib_ID, 0, camera_type, para_start);
                for (int i = 0; i < Image_read.Count; i++)
                {
                    HObject Catab,mask,lastcatab;
                    HOperatorSet.SetColor(hWindow, "green");
                    HOperatorSet.ClearWindow(hWindow);
                    HOperatorSet.DispObj(Image_read[i], hWindow);
                    HOperatorSet.FindCalibObject(Image_read[i], calib_ID, 0, 0, i, new HTuple(), new HTuple());
                    HOperatorSet.GetCalibDataObservContours(out Catab, calib_ID, "caltab", 0, 0, i);
                    HOperatorSet.GetCalibDataObservContours(out mask, calib_ID, "marks", 0, 0, i);
                    HOperatorSet.GetCalibDataObservContours(out lastcatab, calib_ID, "last_caltab", 0, 0, i);
                    HOperatorSet.DispObj(Catab, hWindow);
                    HOperatorSet.DispObj(mask, hWindow);
                    HOperatorSet.DispObj(lastcatab, hWindow);
                    //Thread.Sleep(1000);
                    MessageBox.Show("Image_Calib :" + i.ToString());

                }
               
                HOperatorSet.CalibrateCameras(calib_ID, out error);
                Console.WriteLine(error.ToString());
                string debugFolder = AppDomain.CurrentDomain.BaseDirectory;
                string name_file = "Para_Cam.cal";
                string name_file1 = "Pose_Cam.dat";
                string file_path = Path.Combine(debugFolder, name_file);
                string file_path1 = Path.Combine(debugFolder, name_file1);
                file_paracam = file_path;
                file_Pose_Came = file_path1;
                HOperatorSet.GetCalibData(calib_ID, "camera", 0, "params", out hv_CameraParameters);
                HOperatorSet.GetCalibData(calib_ID, "calib_obj_pose", (new HTuple(0)).TupleConcat(
            0), "pose", out hv_CameraPose);
                HOperatorSet.WriteCamPar(hv_CameraParameters, file_path);
                HOperatorSet.WritePose(hv_CameraPose, file_path1);

            }
            catch (Exception ex) { Job_Model.Statatic_Model.wirtelog.Log($"AL013 - {this.GetType().Name}" + ex.ToString()); }
        }

        public override void Excute(HWindow hWindow, HObject ho_Image)
        {
            try
            {
              if (!Result_Tool )
                {
                    HOperatorSet.ReadPose(file_Pose_Came, out Job_Model.Statatic_Model.Pose_Cam);
                    HOperatorSet.ReadCamPar(file_paracam, out Job_Model.Statatic_Model.Para_Cam);
                    Result_Tool = true;
                    Job_Model.Statatic_Model.use_calib = true;
                }
               
            }
            catch(Exception ex)
            {
                Statatic_Model.wirtelog.Log(ex.ToString());
            }
           
        }

    }
    public class Fillter_Tool : Class_Tool
    {
       

        public Fillter_Tool() : base("Fillter_Tool") { }
        public override void Excute_OnlyTool(HWindow hWindow, HObject ho_Image)
        {
            try
            {
                

            }
            catch (Exception ex)
            {
                Statatic_Model.wirtelog.Log(ex.ToString());
            }
        }

        public override void Excute(HWindow hWindow, HObject ho_Image)
        {
            try
            {
               

            }
            catch (Exception ex)
            {
                Statatic_Model.wirtelog.Log(ex.ToString());
            }

        }

    }
    public class Cal_Hand_Eye_Tool : Class_Tool
    {
        public string file_image_calib { get; set; }
        public double x_master { get; set; }
        public double y_master { get; set; }
        public double phi_master { get; set; }
        public double jump_x { get; set; }
        public double jump_y { get; set; }
        public double jump_angle { get; set; }
        public int step_x { get; set; }
        public int step_y { get; set; }
        public int step_angle { get; set; }
        public Cal_Hand_Eye_Tool() : base("Cal_Hand_Eye_Tool") { }
        public override void Excute_OnlyTool(HWindow hWindow, HObject ho_Image)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Statatic_Model.wirtelog.Log(ex.ToString());
            }
        }

        public override void Excute(HWindow hWindow, HObject ho_Image)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Statatic_Model.wirtelog.Log(ex.ToString());
            }

        }

    }
    public class Select_model_tool : Class_Tool
    {
        public string master_follow { get; set; } = "none";
       
      
    
        public double max_mean1 { get; set; } = 255;
        public double min_mean1 { get; set; } = 0;
        public double max_mean2 { get; set; } = 255;
        public double min_mean2 { get; set; } = 0;
        public double max_mean3 { get; set; } = 255;
        public double min_mean3 { get; set; } = 0;
        public string file_model1;
        public string file_model2;
        public string file_model3;
     
        public double Mean { get; set; }
        public double Deviation { get; set; }
        public int[] map_pixel = new int[256];
        public Select_model_tool() : base("Select_model_tool") { }
        public override void Excute(HWindow hWindow, HObject ho_Image)
        {
            Excute_OnlyTool(hWindow, ho_Image);
        }
        public override void Excute_OnlyTool(HWindow hWindow, HObject ho_Image)
        {
            try
            {
                Array.Clear(map_pixel, 0, map_pixel.GetLength(0));
                Result_Tool = false;
                HObject ho_ImageROI;
                HObject ho_ImageROI1;
                string model = "";
                HTuple mean, deviation;
                HObject edges;
                HTuple area, rowCenter, columnCenter;
                HOperatorSet.GenEmptyObj(out ho_ImageROI);
                HOperatorSet.GenEmptyObj(out ho_ImageROI1);
                HOperatorSet.GenEmptyObj(out edges);
                align_Roi(index_follow, 0, out ho_ImageROI);
                if (roi_Tool.Count > 1)
                {
                    align_Roi(index_follow, 1, out ho_ImageROI1);
                    //    HOperatorSet.Difference(ho_ImageROI, ho_ImageROI1, out ho_ImageROI);
                }
                

                HOperatorSet.AreaCenter(ho_ImageROI, out area, out rowCenter, out columnCenter);
            
                HOperatorSet.Intensity(ho_ImageROI, ho_Image, out mean, out deviation);
                Mean = mean;
                Deviation = deviation;

                HOperatorSet.SetDraw(hWindow, "fill");
                HOperatorSet.SetShape(hWindow, "original");
                HOperatorSet.SetDraw(hWindow, "margin");
                HOperatorSet.SetColor(hWindow, "green");
                Result_Tool = true;
                if (mean >= min_mean1 && mean <= max_mean1)
                {
                    Job_Model.Statatic_Model.model_run = Job_Model.Statatic_Model.LoadJob(file_model1);
                    file_load = file_model1;
                    Result_Tool = true;
                    model = "model 1";
                }
                if (mean >= min_mean2 && mean <= max_mean2)
                {
                    Job_Model.Statatic_Model.model_run = Job_Model.Statatic_Model.LoadJob(file_model2);
                    Result_Tool = true;
                    file_load = file_model2;
                    model = "model 2";
                }
                if (mean >= min_mean3 && mean <= max_mean3)
                {
                    Job_Model.Statatic_Model.model_run = Job_Model.Statatic_Model.LoadJob(file_model3);
                    Result_Tool = true;
                    file_load = file_model3;
                    model = "model 3";
                }
                if(!Result_Tool)
                {
                    HOperatorSet.SetColor(hWindow, "red");
                }    
                Display design_Display = new Display();
                design_Display.set_font(hWindow, 10, "mono", "true", "false");
                HOperatorSet.DispRegion(ho_ImageROI, hWindow);
                // HOperatorSet.DispText()
                HOperatorSet.DispText(hWindow
                        , "Step" + job_index + "-" + tool_index + " SelectModel\n" + "Model " + model + "\n" + Mean.ToString("0.00") + " pixel\n"
                        , "image"
                        , rowCenter
                        , columnCenter
                        , "black"
                        , new HTuple()
                        , new HTuple());

            }
            catch (Exception e) { Job_Model.Statatic_Model.wirtelog.Log($"AL018 - {this.GetType().Name}" + e.ToString()); }
        }
    }
 }
