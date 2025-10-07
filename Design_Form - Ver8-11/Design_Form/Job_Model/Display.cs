 using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design_Form.Job_Model
{
    class Display
    {
        public void set_font(HTuple hv_WindowHandle, HTuple hv_Size, HTuple hv_Font, HTuple hv_Bold, HTuple hv_Slant)
        {

            HTuple hv_OS = new HTuple(), hv_Fonts = new HTuple();
            HTuple hv_Style = new HTuple(), hv_Exception = new HTuple();
            HTuple hv_AvailableFonts = new HTuple(), hv_Fdx = new HTuple();
            HTuple hv_Indices = new HTuple();
            HTuple hv_Font_COPY_INP_TMP = new HTuple(hv_Font);
            HTuple hv_Size_COPY_INP_TMP = new HTuple(hv_Size);

            // Initialize local and output iconic variables 
            try
            {
                //This procedure sets the text font of the current window with
                //the specified attributes.
                //
                //Input parameters:
                //WindowHandle: The graphics window for which the font will be set
                //Size: The font size. If Size=-1, the default of 16 is used.
                //Bold: If set to 'true', a bold font is used
                //Slant: If set to 'true', a slanted font is used
                //
                hv_OS.Dispose();
                HOperatorSet.GetSystem("operating_system", out hv_OS);
                if ((int)((new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                    new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(-1)))) != 0)
                {
                    hv_Size_COPY_INP_TMP.Dispose();
                    hv_Size_COPY_INP_TMP = 16;
                }
                if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Win"))) != 0)
                {
                    //Restore previous behaviour
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Size = ((1.13677 * hv_Size_COPY_INP_TMP)).TupleInt()
                                ;
                            hv_Size_COPY_INP_TMP.Dispose();
                            hv_Size_COPY_INP_TMP = ExpTmpLocalVar_Size;
                        }
                    }
                }
                else
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Size = hv_Size_COPY_INP_TMP.TupleInt()
                                ;
                            hv_Size_COPY_INP_TMP.Dispose();
                            hv_Size_COPY_INP_TMP = ExpTmpLocalVar_Size;
                        }
                    }
                }
                if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("Courier"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Courier";
                    hv_Fonts[1] = "Courier 10 Pitch";
                    hv_Fonts[2] = "Courier New";
                    hv_Fonts[3] = "CourierNew";
                    hv_Fonts[4] = "Liberation Mono";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();

                    //hv_Fonts[0] = "Consolas";
                    //hv_Fonts[1] = "Menlo";
                    //hv_Fonts[2] = "Courier";
                    //hv_Fonts[3] = "Courier 10 Pitch";
                    //hv_Fonts[4] = "FreeMono";
                    //   hv_Fonts[5] = "Liberation Mono";

                    hv_Fonts[0] = "Arial";
                    hv_Fonts[1] = "Arial";
                    hv_Fonts[2] = "Arial";
                    hv_Fonts[3] = "Arial";
                    hv_Fonts[4] = "Arial";
                    hv_Fonts[5] = "Arial";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Luxi Sans";
                    hv_Fonts[1] = "DejaVu Sans";
                    hv_Fonts[2] = "FreeSans";
                    hv_Fonts[3] = "Arial";
                    hv_Fonts[4] = "Liberation Sans";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Times New Roman";
                    hv_Fonts[1] = "Luxi Serif";
                    hv_Fonts[2] = "DejaVu Serif";
                    hv_Fonts[3] = "FreeSerif";
                    hv_Fonts[4] = "Utopia";
                    hv_Fonts[5] = "Liberation Serif";
                }
                else
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple(hv_Font_COPY_INP_TMP);
                }
                hv_Style.Dispose();
                hv_Style = "";
                if ((int)(new HTuple(hv_Bold.TupleEqual("true"))) != 0)
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Style = hv_Style + "Bold";
                            hv_Style.Dispose();
                            hv_Style = ExpTmpLocalVar_Style;
                        }
                    }
                }
                else if ((int)(new HTuple(hv_Bold.TupleNotEqual("false"))) != 0)
                {
                    hv_Exception.Dispose();
                    hv_Exception = "Wrong value of control parameter Bold";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Slant.TupleEqual("true"))) != 0)
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Style = hv_Style + "Italic";
                            hv_Style.Dispose();
                            hv_Style = ExpTmpLocalVar_Style;
                        }
                    }
                }
                else if ((int)(new HTuple(hv_Slant.TupleNotEqual("false"))) != 0)
                {
                    hv_Exception.Dispose();
                    hv_Exception = "Wrong value of control parameter Slant";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Style.TupleEqual(""))) != 0)
                {
                    hv_Style.Dispose();
                    hv_Style = "Normal";
                }
                hv_AvailableFonts.Dispose();
                HOperatorSet.QueryFont(hv_WindowHandle, out hv_AvailableFonts);
                hv_Font_COPY_INP_TMP.Dispose();
                hv_Font_COPY_INP_TMP = "";
                for (hv_Fdx = 0; (int)hv_Fdx <= (int)((new HTuple(hv_Fonts.TupleLength())) - 1); hv_Fdx = (int)hv_Fdx + 1)
                {
                    hv_Indices.Dispose();
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_Indices = hv_AvailableFonts.TupleFind(
                            hv_Fonts.TupleSelect(hv_Fdx));
                    }
                    if ((int)(new HTuple((new HTuple(hv_Indices.TupleLength())).TupleGreater(
                        0))) != 0)
                    {
                        if ((int)(new HTuple(((hv_Indices.TupleSelect(0))).TupleGreaterEqual(0))) != 0)
                        {
                            hv_Font_COPY_INP_TMP.Dispose();
                            using (HDevDisposeHelper dh = new HDevDisposeHelper())
                            {
                                hv_Font_COPY_INP_TMP = hv_Fonts.TupleSelect(
                                    hv_Fdx);
                            }
                            break;
                        }
                    }
                }
                if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual(""))) != 0)
                {
                    throw new HalconException("Wrong value of control parameter Font");
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    {
                        HTuple
                          ExpTmpLocalVar_Font = (((hv_Font_COPY_INP_TMP + "-") + hv_Style) + "-") + hv_Size_COPY_INP_TMP;
                        hv_Font_COPY_INP_TMP.Dispose();
                        hv_Font_COPY_INP_TMP = ExpTmpLocalVar_Font;
                    }
                }
                HOperatorSet.SetFont(hv_WindowHandle, hv_Font_COPY_INP_TMP);

                hv_Font_COPY_INP_TMP.Dispose();
                hv_Size_COPY_INP_TMP.Dispose();
                hv_OS.Dispose();
                hv_Fonts.Dispose();
                hv_Style.Dispose();
                hv_Exception.Dispose();
                hv_AvailableFonts.Dispose();
                hv_Fdx.Dispose();
                hv_Indices.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {

                hv_Font_COPY_INP_TMP.Dispose();
                hv_Size_COPY_INP_TMP.Dispose();
                hv_OS.Dispose();
                hv_Fonts.Dispose();
                hv_Style.Dispose();
                hv_Exception.Dispose();
                hv_AvailableFonts.Dispose();
                hv_Fdx.Dispose();
                hv_Indices.Dispose();

                throw HDevExpDefaultException;
            }
        }
        public void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
       HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
        {



            // Local iconic variables 

            // Local control variables 

            HTuple hv_GenParamName = new HTuple(), hv_GenParamValue = new HTuple();
            HTuple hv_Color_COPY_INP_TMP = new HTuple(hv_Color);
            HTuple hv_Column_COPY_INP_TMP = new HTuple(hv_Column);
            HTuple hv_CoordSystem_COPY_INP_TMP = new HTuple(hv_CoordSystem);
            HTuple hv_Row_COPY_INP_TMP = new HTuple(hv_Row);

            // Initialize local and output iconic variables 
            try
            {
                //This procedure displays text in a graphics window.
                //
                //Input parameters:
                //WindowHandle: The WindowHandle of the graphics window, where
                //   the message should be displayed
                //String: A tuple of strings containing the text message to be displayed
                //CoordSystem: If set to 'window', the text position is given
                //   with respect to the window coordinate system.
                //   If set to 'image', image coordinates are used.
                //   (This may be useful in zoomed images.)
                //Row: The row coordinate of the desired text position
                //   A tuple of values is allowed to display text at different
                //   positions.
                //Column: The column coordinate of the desired text position
                //   A tuple of values is allowed to display text at different
                //   positions.
                //Color: defines the color of the text as string.
                //   If set to [], '' or 'auto' the currently set color is used.
                //   If a tuple of strings is passed, the colors are used cyclically...
                //   - if |Row| == |Column| == 1: for each new textline
                //   = else for each text position.
                //Box: If Box[0] is set to 'true', the text is written within an orange box.
                //     If set to' false', no box is displayed.
                //     If set to a color string (e.g. 'white', '#FF00CC', etc.),
                //       the text is written in a box of that color.
                //     An optional second value for Box (Box[1]) controls if a shadow is displayed:
                //       'true' -> display a shadow in a default color
                //       'false' -> display no shadow
                //       otherwise -> use given string as color string for the shadow color
                //
                //It is possible to display multiple text strings in a single call.
                //In this case, some restrictions apply:
                //- Multiple text positions can be defined by specifying a tuple
                //  with multiple Row and/or Column coordinates, i.e.:
                //  - |Row| == n, |Column| == n
                //  - |Row| == n, |Column| == 1
                //  - |Row| == 1, |Column| == n
                //- If |Row| == |Column| == 1,
                //  each element of String is display in a new textline.
                //- If multiple positions or specified, the number of Strings
                //  must match the number of positions, i.e.:
                //  - Either |String| == n (each string is displayed at the
                //                          corresponding position),
                //  - or     |String| == 1 (The string is displayed n times).
                //
                //
                //Convert the parameters for disp_text.
                if ((int)((new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                    new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(new HTuple())))) != 0)
                {

                    hv_Color_COPY_INP_TMP.Dispose();
                    hv_Column_COPY_INP_TMP.Dispose();
                    hv_CoordSystem_COPY_INP_TMP.Dispose();
                    hv_Row_COPY_INP_TMP.Dispose();
                    hv_GenParamName.Dispose();
                    hv_GenParamValue.Dispose();

                    return;
                }
                if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
                {
                    hv_Row_COPY_INP_TMP.Dispose();
                    hv_Row_COPY_INP_TMP = 12;
                }
                if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
                {
                    hv_Column_COPY_INP_TMP.Dispose();
                    hv_Column_COPY_INP_TMP = 12;
                }
                //
                //Convert the parameter Box to generic parameters.
                hv_GenParamName.Dispose();
                hv_GenParamName = new HTuple();
                hv_GenParamValue.Dispose();
                hv_GenParamValue = new HTuple();
                if ((int)(new HTuple((new HTuple(hv_Box.TupleLength())).TupleGreater(0))) != 0)
                {
                    if ((int)(new HTuple(((hv_Box.TupleSelect(0))).TupleEqual("false"))) != 0)
                    {
                        //Display no box
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamName = hv_GenParamName.TupleConcat(
                                    "box");
                                hv_GenParamName.Dispose();
                                hv_GenParamName = ExpTmpLocalVar_GenParamName;
                            }
                        }
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamValue = hv_GenParamValue.TupleConcat(
                                    "false");
                                hv_GenParamValue.Dispose();
                                hv_GenParamValue = ExpTmpLocalVar_GenParamValue;
                            }
                        }
                    }
                    else if ((int)(new HTuple(((hv_Box.TupleSelect(0))).TupleNotEqual(
                        "true"))) != 0)
                    {
                        //Set a color other than the default.
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamName = hv_GenParamName.TupleConcat(
                                    "box_color");
                                hv_GenParamName.Dispose();
                                hv_GenParamName = ExpTmpLocalVar_GenParamName;
                            }
                        }
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamValue = hv_GenParamValue.TupleConcat(
                                    hv_Box.TupleSelect(0));
                                hv_GenParamValue.Dispose();
                                hv_GenParamValue = ExpTmpLocalVar_GenParamValue;
                            }
                        }
                    }
                }
                if ((int)(new HTuple((new HTuple(hv_Box.TupleLength())).TupleGreater(1))) != 0)
                {
                    if ((int)(new HTuple(((hv_Box.TupleSelect(1))).TupleEqual("false"))) != 0)
                    {
                        //Display no shadow.
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamName = hv_GenParamName.TupleConcat(
                                    "shadow");
                                hv_GenParamName.Dispose();
                                hv_GenParamName = ExpTmpLocalVar_GenParamName;
                            }
                        }
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamValue = hv_GenParamValue.TupleConcat(
                                    "false");
                                hv_GenParamValue.Dispose();
                                hv_GenParamValue = ExpTmpLocalVar_GenParamValue;
                            }
                        }
                    }
                    else if ((int)(new HTuple(((hv_Box.TupleSelect(1))).TupleNotEqual(
                        "true"))) != 0)
                    {
                        //Set a shadow color other than the default.
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamName = hv_GenParamName.TupleConcat(
                                    "shadow_color");
                                hv_GenParamName.Dispose();
                                hv_GenParamName = ExpTmpLocalVar_GenParamName;
                            }
                        }
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamValue = hv_GenParamValue.TupleConcat(
                                    hv_Box.TupleSelect(1));
                                hv_GenParamValue.Dispose();
                                hv_GenParamValue = ExpTmpLocalVar_GenParamValue;
                            }
                        }
                    }
                }
                //Restore default CoordSystem behavior.
                if ((int)(new HTuple(hv_CoordSystem_COPY_INP_TMP.TupleNotEqual("window"))) != 0)
                {
                    hv_CoordSystem_COPY_INP_TMP.Dispose();
                    hv_CoordSystem_COPY_INP_TMP = "image";
                }
                //
                if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(""))) != 0)
                {
                    //disp_text does not accept an empty string for Color.
                    hv_Color_COPY_INP_TMP.Dispose();
                    hv_Color_COPY_INP_TMP = new HTuple();
                }
                //
                HOperatorSet.DispText(hv_WindowHandle, hv_String, hv_CoordSystem_COPY_INP_TMP,
                    hv_Row_COPY_INP_TMP, hv_Column_COPY_INP_TMP, hv_Color_COPY_INP_TMP, hv_GenParamName,
                    hv_GenParamValue);

                hv_Color_COPY_INP_TMP.Dispose();
                hv_Column_COPY_INP_TMP.Dispose();
                hv_CoordSystem_COPY_INP_TMP.Dispose();
                hv_Row_COPY_INP_TMP.Dispose();
                hv_GenParamName.Dispose();
                hv_GenParamValue.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {

                hv_Color_COPY_INP_TMP.Dispose();
                hv_Column_COPY_INP_TMP.Dispose();
                hv_CoordSystem_COPY_INP_TMP.Dispose();
                hv_Row_COPY_INP_TMP.Dispose();
                hv_GenParamName.Dispose();
                hv_GenParamValue.Dispose();

                throw HDevExpDefaultException;
            }
        }
        public void gen_cam_par_area_scan_division(HTuple hv_Focus, HTuple hv_Kappa, HTuple hv_Sx,
     HTuple hv_Sy, HTuple hv_Cx, HTuple hv_Cy, HTuple hv_ImageWidth, HTuple hv_ImageHeight,
     out HTuple hv_CameraParam)
        {



            // Local iconic variables 
            // Initialize local and output iconic variables 
            hv_CameraParam = new HTuple();
            //Generate a camera parameter tuple for an area scan camera
            //with distortions modeled by the division model.
            //
            hv_CameraParam.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_CameraParam = new HTuple();
                hv_CameraParam[0] = "area_scan_division";
                hv_CameraParam = hv_CameraParam.TupleConcat(hv_Focus, hv_Kappa, hv_Sx, hv_Sy, hv_Cx, hv_Cy, hv_ImageWidth, hv_ImageHeight);
            }


            return;
        }
        public void get_cam_par_data(HTuple hv_CameraParam, HTuple hv_ParamName, out HTuple hv_ParamValue)
        {



            // Local iconic variables 

            // Local control variables 

            HTuple hv_CameraType = new HTuple(), hv_CameraParamNames = new HTuple();
            HTuple hv_Index = new HTuple(), hv_ParamNameInd = new HTuple();
            HTuple hv_I = new HTuple();
            // Initialize local and output iconic variables 
            hv_ParamValue = new HTuple();
            try
            {
                //get_cam_par_data returns in ParamValue the value of the
                //parameter that is given in ParamName from the tuple of
                //camera parameters that is given in CameraParam.
                //
                //Get the parameter names that correspond to the
                //elements in the input camera parameter tuple.
                hv_CameraType.Dispose(); hv_CameraParamNames.Dispose();
                get_cam_par_names(hv_CameraParam, out hv_CameraType, out hv_CameraParamNames);
                //
                //Find the index of the requested camera data and return
                //the corresponding value.
                hv_ParamValue.Dispose();
                hv_ParamValue = new HTuple();
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_ParamName.TupleLength()
                    )) - 1); hv_Index = (int)hv_Index + 1)
                {
                    hv_ParamNameInd.Dispose();
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_ParamNameInd = hv_ParamName.TupleSelect(
                            hv_Index);
                    }
                    if ((int)(new HTuple(hv_ParamNameInd.TupleEqual("camera_type"))) != 0)
                    {
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_ParamValue = hv_ParamValue.TupleConcat(
                                    hv_CameraType);
                                hv_ParamValue.Dispose();
                                hv_ParamValue = ExpTmpLocalVar_ParamValue;
                            }
                        }
                        continue;
                    }
                    hv_I.Dispose();
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_I = hv_CameraParamNames.TupleFind(
                            hv_ParamNameInd);
                    }
                    if ((int)(new HTuple(hv_I.TupleNotEqual(-1))) != 0)
                    {
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_ParamValue = hv_ParamValue.TupleConcat(
                                    hv_CameraParam.TupleSelect(hv_I));
                                hv_ParamValue.Dispose();
                                hv_ParamValue = ExpTmpLocalVar_ParamValue;
                            }
                        }
                    }
                    else
                    {
                        throw new HalconException("Unknown camera parameter " + hv_ParamNameInd);
                    }
                }

                hv_CameraType.Dispose();
                hv_CameraParamNames.Dispose();
                hv_Index.Dispose();
                hv_ParamNameInd.Dispose();
                hv_I.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {

                hv_CameraType.Dispose();
                hv_CameraParamNames.Dispose();
                hv_Index.Dispose();
                hv_ParamNameInd.Dispose();
                hv_I.Dispose();

                throw HDevExpDefaultException;
            }
        }
        public void get_cam_par_names(HTuple hv_CameraParam, out HTuple hv_CameraType,
      out HTuple hv_ParamNames)
        {



            // Local iconic variables 

            // Local control variables 

            HTuple hv_CameraParamAreaScanDivision = new HTuple();
            HTuple hv_CameraParamAreaScanPolynomial = new HTuple();
            HTuple hv_CameraParamAreaScanTelecentricDivision = new HTuple();
            HTuple hv_CameraParamAreaScanTelecentricPolynomial = new HTuple();
            HTuple hv_CameraParamAreaScanTiltDivision = new HTuple();
            HTuple hv_CameraParamAreaScanTiltPolynomial = new HTuple();
            HTuple hv_CameraParamAreaScanImageSideTelecentricTiltDivision = new HTuple();
            HTuple hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial = new HTuple();
            HTuple hv_CameraParamAreaScanBilateralTelecentricTiltDivision = new HTuple();
            HTuple hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial = new HTuple();
            HTuple hv_CameraParamAreaScanObjectSideTelecentricTiltDivision = new HTuple();
            HTuple hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial = new HTuple();
            HTuple hv_CameraParamAreaScanHypercentricDivision = new HTuple();
            HTuple hv_CameraParamAreaScanHypercentricPolynomial = new HTuple();
            HTuple hv_CameraParamLinesScan = new HTuple(), hv_CameraParamAreaScanTiltDivisionLegacy = new HTuple();
            HTuple hv_CameraParamAreaScanTiltPolynomialLegacy = new HTuple();
            HTuple hv_CameraParamAreaScanTelecentricDivisionLegacy = new HTuple();
            HTuple hv_CameraParamAreaScanTelecentricPolynomialLegacy = new HTuple();
            HTuple hv_CameraParamAreaScanBilateralTelecentricTiltDivisionLegacy = new HTuple();
            HTuple hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy = new HTuple();
            // Initialize local and output iconic variables 
            hv_CameraType = new HTuple();
            hv_ParamNames = new HTuple();
            try
            {
                //get_cam_par_names returns for each element in the camera
                //parameter tuple that is passed in CameraParam the name
                //of the respective camera parameter. The parameter names
                //are returned in ParamNames. Additionally, the camera
                //type is returned in CameraType. Alternatively, instead of
                //the camera parameters, the camera type can be passed in
                //CameraParam in form of one of the following strings:
                //  - 'area_scan_division'
                //  - 'area_scan_polynomial'
                //  - 'area_scan_tilt_division'
                //  - 'area_scan_tilt_polynomial'
                //  - 'area_scan_telecentric_division'
                //  - 'area_scan_telecentric_polynomial'
                //  - 'area_scan_tilt_bilateral_telecentric_division'
                //  - 'area_scan_tilt_bilateral_telecentric_polynomial'
                //  - 'area_scan_tilt_object_side_telecentric_division'
                //  - 'area_scan_tilt_object_side_telecentric_polynomial'
                //  - 'area_scan_hypercentric_division'
                //  - 'area_scan_hypercentric_polynomial'
                //  - 'line_scan'
                //
                hv_CameraParamAreaScanDivision.Dispose();
                hv_CameraParamAreaScanDivision = new HTuple();
                hv_CameraParamAreaScanDivision[0] = "focus";
                hv_CameraParamAreaScanDivision[1] = "kappa";
                hv_CameraParamAreaScanDivision[2] = "sx";
                hv_CameraParamAreaScanDivision[3] = "sy";
                hv_CameraParamAreaScanDivision[4] = "cx";
                hv_CameraParamAreaScanDivision[5] = "cy";
                hv_CameraParamAreaScanDivision[6] = "image_width";
                hv_CameraParamAreaScanDivision[7] = "image_height";
                hv_CameraParamAreaScanPolynomial.Dispose();
                hv_CameraParamAreaScanPolynomial = new HTuple();
                hv_CameraParamAreaScanPolynomial[0] = "focus";
                hv_CameraParamAreaScanPolynomial[1] = "k1";
                hv_CameraParamAreaScanPolynomial[2] = "k2";
                hv_CameraParamAreaScanPolynomial[3] = "k3";
                hv_CameraParamAreaScanPolynomial[4] = "p1";
                hv_CameraParamAreaScanPolynomial[5] = "p2";
                hv_CameraParamAreaScanPolynomial[6] = "sx";
                hv_CameraParamAreaScanPolynomial[7] = "sy";
                hv_CameraParamAreaScanPolynomial[8] = "cx";
                hv_CameraParamAreaScanPolynomial[9] = "cy";
                hv_CameraParamAreaScanPolynomial[10] = "image_width";
                hv_CameraParamAreaScanPolynomial[11] = "image_height";
                hv_CameraParamAreaScanTelecentricDivision.Dispose();
                hv_CameraParamAreaScanTelecentricDivision = new HTuple();
                hv_CameraParamAreaScanTelecentricDivision[0] = "magnification";
                hv_CameraParamAreaScanTelecentricDivision[1] = "kappa";
                hv_CameraParamAreaScanTelecentricDivision[2] = "sx";
                hv_CameraParamAreaScanTelecentricDivision[3] = "sy";
                hv_CameraParamAreaScanTelecentricDivision[4] = "cx";
                hv_CameraParamAreaScanTelecentricDivision[5] = "cy";
                hv_CameraParamAreaScanTelecentricDivision[6] = "image_width";
                hv_CameraParamAreaScanTelecentricDivision[7] = "image_height";
                hv_CameraParamAreaScanTelecentricPolynomial.Dispose();
                hv_CameraParamAreaScanTelecentricPolynomial = new HTuple();
                hv_CameraParamAreaScanTelecentricPolynomial[0] = "magnification";
                hv_CameraParamAreaScanTelecentricPolynomial[1] = "k1";
                hv_CameraParamAreaScanTelecentricPolynomial[2] = "k2";
                hv_CameraParamAreaScanTelecentricPolynomial[3] = "k3";
                hv_CameraParamAreaScanTelecentricPolynomial[4] = "p1";
                hv_CameraParamAreaScanTelecentricPolynomial[5] = "p2";
                hv_CameraParamAreaScanTelecentricPolynomial[6] = "sx";
                hv_CameraParamAreaScanTelecentricPolynomial[7] = "sy";
                hv_CameraParamAreaScanTelecentricPolynomial[8] = "cx";
                hv_CameraParamAreaScanTelecentricPolynomial[9] = "cy";
                hv_CameraParamAreaScanTelecentricPolynomial[10] = "image_width";
                hv_CameraParamAreaScanTelecentricPolynomial[11] = "image_height";
                hv_CameraParamAreaScanTiltDivision.Dispose();
                hv_CameraParamAreaScanTiltDivision = new HTuple();
                hv_CameraParamAreaScanTiltDivision[0] = "focus";
                hv_CameraParamAreaScanTiltDivision[1] = "kappa";
                hv_CameraParamAreaScanTiltDivision[2] = "image_plane_dist";
                hv_CameraParamAreaScanTiltDivision[3] = "tilt";
                hv_CameraParamAreaScanTiltDivision[4] = "rot";
                hv_CameraParamAreaScanTiltDivision[5] = "sx";
                hv_CameraParamAreaScanTiltDivision[6] = "sy";
                hv_CameraParamAreaScanTiltDivision[7] = "cx";
                hv_CameraParamAreaScanTiltDivision[8] = "cy";
                hv_CameraParamAreaScanTiltDivision[9] = "image_width";
                hv_CameraParamAreaScanTiltDivision[10] = "image_height";
                hv_CameraParamAreaScanTiltPolynomial.Dispose();
                hv_CameraParamAreaScanTiltPolynomial = new HTuple();
                hv_CameraParamAreaScanTiltPolynomial[0] = "focus";
                hv_CameraParamAreaScanTiltPolynomial[1] = "k1";
                hv_CameraParamAreaScanTiltPolynomial[2] = "k2";
                hv_CameraParamAreaScanTiltPolynomial[3] = "k3";
                hv_CameraParamAreaScanTiltPolynomial[4] = "p1";
                hv_CameraParamAreaScanTiltPolynomial[5] = "p2";
                hv_CameraParamAreaScanTiltPolynomial[6] = "image_plane_dist";
                hv_CameraParamAreaScanTiltPolynomial[7] = "tilt";
                hv_CameraParamAreaScanTiltPolynomial[8] = "rot";
                hv_CameraParamAreaScanTiltPolynomial[9] = "sx";
                hv_CameraParamAreaScanTiltPolynomial[10] = "sy";
                hv_CameraParamAreaScanTiltPolynomial[11] = "cx";
                hv_CameraParamAreaScanTiltPolynomial[12] = "cy";
                hv_CameraParamAreaScanTiltPolynomial[13] = "image_width";
                hv_CameraParamAreaScanTiltPolynomial[14] = "image_height";
                hv_CameraParamAreaScanImageSideTelecentricTiltDivision.Dispose();
                hv_CameraParamAreaScanImageSideTelecentricTiltDivision = new HTuple();
                hv_CameraParamAreaScanImageSideTelecentricTiltDivision[0] = "focus";
                hv_CameraParamAreaScanImageSideTelecentricTiltDivision[1] = "kappa";
                hv_CameraParamAreaScanImageSideTelecentricTiltDivision[2] = "tilt";
                hv_CameraParamAreaScanImageSideTelecentricTiltDivision[3] = "rot";
                hv_CameraParamAreaScanImageSideTelecentricTiltDivision[4] = "sx";
                hv_CameraParamAreaScanImageSideTelecentricTiltDivision[5] = "sy";
                hv_CameraParamAreaScanImageSideTelecentricTiltDivision[6] = "cx";
                hv_CameraParamAreaScanImageSideTelecentricTiltDivision[7] = "cy";
                hv_CameraParamAreaScanImageSideTelecentricTiltDivision[8] = "image_width";
                hv_CameraParamAreaScanImageSideTelecentricTiltDivision[9] = "image_height";
                hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial.Dispose();
                hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial = new HTuple();
                hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial[0] = "focus";
                hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial[1] = "k1";
                hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial[2] = "k2";
                hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial[3] = "k3";
                hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial[4] = "p1";
                hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial[5] = "p2";
                hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial[6] = "tilt";
                hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial[7] = "rot";
                hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial[8] = "sx";
                hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial[9] = "sy";
                hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial[10] = "cx";
                hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial[11] = "cy";
                hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial[12] = "image_width";
                hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial[13] = "image_height";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivision.Dispose();
                hv_CameraParamAreaScanBilateralTelecentricTiltDivision = new HTuple();
                hv_CameraParamAreaScanBilateralTelecentricTiltDivision[0] = "magnification";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivision[1] = "kappa";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivision[2] = "tilt";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivision[3] = "rot";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivision[4] = "sx";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivision[5] = "sy";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivision[6] = "cx";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivision[7] = "cy";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivision[8] = "image_width";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivision[9] = "image_height";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial.Dispose();
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial = new HTuple();
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial[0] = "magnification";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial[1] = "k1";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial[2] = "k2";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial[3] = "k3";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial[4] = "p1";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial[5] = "p2";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial[6] = "tilt";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial[7] = "rot";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial[8] = "sx";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial[9] = "sy";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial[10] = "cx";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial[11] = "cy";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial[12] = "image_width";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial[13] = "image_height";
                hv_CameraParamAreaScanObjectSideTelecentricTiltDivision.Dispose();
                hv_CameraParamAreaScanObjectSideTelecentricTiltDivision = new HTuple();
                hv_CameraParamAreaScanObjectSideTelecentricTiltDivision[0] = "magnification";
                hv_CameraParamAreaScanObjectSideTelecentricTiltDivision[1] = "kappa";
                hv_CameraParamAreaScanObjectSideTelecentricTiltDivision[2] = "image_plane_dist";
                hv_CameraParamAreaScanObjectSideTelecentricTiltDivision[3] = "tilt";
                hv_CameraParamAreaScanObjectSideTelecentricTiltDivision[4] = "rot";
                hv_CameraParamAreaScanObjectSideTelecentricTiltDivision[5] = "sx";
                hv_CameraParamAreaScanObjectSideTelecentricTiltDivision[6] = "sy";
                hv_CameraParamAreaScanObjectSideTelecentricTiltDivision[7] = "cx";
                hv_CameraParamAreaScanObjectSideTelecentricTiltDivision[8] = "cy";
                hv_CameraParamAreaScanObjectSideTelecentricTiltDivision[9] = "image_width";
                hv_CameraParamAreaScanObjectSideTelecentricTiltDivision[10] = "image_height";
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial.Dispose();
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial = new HTuple();
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial[0] = "magnification";
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial[1] = "k1";
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial[2] = "k2";
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial[3] = "k3";
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial[4] = "p1";
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial[5] = "p2";
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial[6] = "image_plane_dist";
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial[7] = "tilt";
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial[8] = "rot";
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial[9] = "sx";
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial[10] = "sy";
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial[11] = "cx";
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial[12] = "cy";
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial[13] = "image_width";
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial[14] = "image_height";
                hv_CameraParamAreaScanHypercentricDivision.Dispose();
                hv_CameraParamAreaScanHypercentricDivision = new HTuple();
                hv_CameraParamAreaScanHypercentricDivision[0] = "focus";
                hv_CameraParamAreaScanHypercentricDivision[1] = "kappa";
                hv_CameraParamAreaScanHypercentricDivision[2] = "sx";
                hv_CameraParamAreaScanHypercentricDivision[3] = "sy";
                hv_CameraParamAreaScanHypercentricDivision[4] = "cx";
                hv_CameraParamAreaScanHypercentricDivision[5] = "cy";
                hv_CameraParamAreaScanHypercentricDivision[6] = "image_width";
                hv_CameraParamAreaScanHypercentricDivision[7] = "image_height";
                hv_CameraParamAreaScanHypercentricPolynomial.Dispose();
                hv_CameraParamAreaScanHypercentricPolynomial = new HTuple();
                hv_CameraParamAreaScanHypercentricPolynomial[0] = "focus";
                hv_CameraParamAreaScanHypercentricPolynomial[1] = "k1";
                hv_CameraParamAreaScanHypercentricPolynomial[2] = "k2";
                hv_CameraParamAreaScanHypercentricPolynomial[3] = "k3";
                hv_CameraParamAreaScanHypercentricPolynomial[4] = "p1";
                hv_CameraParamAreaScanHypercentricPolynomial[5] = "p2";
                hv_CameraParamAreaScanHypercentricPolynomial[6] = "sx";
                hv_CameraParamAreaScanHypercentricPolynomial[7] = "sy";
                hv_CameraParamAreaScanHypercentricPolynomial[8] = "cx";
                hv_CameraParamAreaScanHypercentricPolynomial[9] = "cy";
                hv_CameraParamAreaScanHypercentricPolynomial[10] = "image_width";
                hv_CameraParamAreaScanHypercentricPolynomial[11] = "image_height";
                hv_CameraParamLinesScan.Dispose();
                hv_CameraParamLinesScan = new HTuple();
                hv_CameraParamLinesScan[0] = "focus";
                hv_CameraParamLinesScan[1] = "kappa";
                hv_CameraParamLinesScan[2] = "sx";
                hv_CameraParamLinesScan[3] = "sy";
                hv_CameraParamLinesScan[4] = "cx";
                hv_CameraParamLinesScan[5] = "cy";
                hv_CameraParamLinesScan[6] = "image_width";
                hv_CameraParamLinesScan[7] = "image_height";
                hv_CameraParamLinesScan[8] = "vx";
                hv_CameraParamLinesScan[9] = "vy";
                hv_CameraParamLinesScan[10] = "vz";
                //Legacy parameter names
                hv_CameraParamAreaScanTiltDivisionLegacy.Dispose();
                hv_CameraParamAreaScanTiltDivisionLegacy = new HTuple();
                hv_CameraParamAreaScanTiltDivisionLegacy[0] = "focus";
                hv_CameraParamAreaScanTiltDivisionLegacy[1] = "kappa";
                hv_CameraParamAreaScanTiltDivisionLegacy[2] = "tilt";
                hv_CameraParamAreaScanTiltDivisionLegacy[3] = "rot";
                hv_CameraParamAreaScanTiltDivisionLegacy[4] = "sx";
                hv_CameraParamAreaScanTiltDivisionLegacy[5] = "sy";
                hv_CameraParamAreaScanTiltDivisionLegacy[6] = "cx";
                hv_CameraParamAreaScanTiltDivisionLegacy[7] = "cy";
                hv_CameraParamAreaScanTiltDivisionLegacy[8] = "image_width";
                hv_CameraParamAreaScanTiltDivisionLegacy[9] = "image_height";
                hv_CameraParamAreaScanTiltPolynomialLegacy.Dispose();
                hv_CameraParamAreaScanTiltPolynomialLegacy = new HTuple();
                hv_CameraParamAreaScanTiltPolynomialLegacy[0] = "focus";
                hv_CameraParamAreaScanTiltPolynomialLegacy[1] = "k1";
                hv_CameraParamAreaScanTiltPolynomialLegacy[2] = "k2";
                hv_CameraParamAreaScanTiltPolynomialLegacy[3] = "k3";
                hv_CameraParamAreaScanTiltPolynomialLegacy[4] = "p1";
                hv_CameraParamAreaScanTiltPolynomialLegacy[5] = "p2";
                hv_CameraParamAreaScanTiltPolynomialLegacy[6] = "tilt";
                hv_CameraParamAreaScanTiltPolynomialLegacy[7] = "rot";
                hv_CameraParamAreaScanTiltPolynomialLegacy[8] = "sx";
                hv_CameraParamAreaScanTiltPolynomialLegacy[9] = "sy";
                hv_CameraParamAreaScanTiltPolynomialLegacy[10] = "cx";
                hv_CameraParamAreaScanTiltPolynomialLegacy[11] = "cy";
                hv_CameraParamAreaScanTiltPolynomialLegacy[12] = "image_width";
                hv_CameraParamAreaScanTiltPolynomialLegacy[13] = "image_height";
                hv_CameraParamAreaScanTelecentricDivisionLegacy.Dispose();
                hv_CameraParamAreaScanTelecentricDivisionLegacy = new HTuple();
                hv_CameraParamAreaScanTelecentricDivisionLegacy[0] = "focus";
                hv_CameraParamAreaScanTelecentricDivisionLegacy[1] = "kappa";
                hv_CameraParamAreaScanTelecentricDivisionLegacy[2] = "sx";
                hv_CameraParamAreaScanTelecentricDivisionLegacy[3] = "sy";
                hv_CameraParamAreaScanTelecentricDivisionLegacy[4] = "cx";
                hv_CameraParamAreaScanTelecentricDivisionLegacy[5] = "cy";
                hv_CameraParamAreaScanTelecentricDivisionLegacy[6] = "image_width";
                hv_CameraParamAreaScanTelecentricDivisionLegacy[7] = "image_height";
                hv_CameraParamAreaScanTelecentricPolynomialLegacy.Dispose();
                hv_CameraParamAreaScanTelecentricPolynomialLegacy = new HTuple();
                hv_CameraParamAreaScanTelecentricPolynomialLegacy[0] = "focus";
                hv_CameraParamAreaScanTelecentricPolynomialLegacy[1] = "k1";
                hv_CameraParamAreaScanTelecentricPolynomialLegacy[2] = "k2";
                hv_CameraParamAreaScanTelecentricPolynomialLegacy[3] = "k3";
                hv_CameraParamAreaScanTelecentricPolynomialLegacy[4] = "p1";
                hv_CameraParamAreaScanTelecentricPolynomialLegacy[5] = "p2";
                hv_CameraParamAreaScanTelecentricPolynomialLegacy[6] = "sx";
                hv_CameraParamAreaScanTelecentricPolynomialLegacy[7] = "sy";
                hv_CameraParamAreaScanTelecentricPolynomialLegacy[8] = "cx";
                hv_CameraParamAreaScanTelecentricPolynomialLegacy[9] = "cy";
                hv_CameraParamAreaScanTelecentricPolynomialLegacy[10] = "image_width";
                hv_CameraParamAreaScanTelecentricPolynomialLegacy[11] = "image_height";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivisionLegacy.Dispose();
                hv_CameraParamAreaScanBilateralTelecentricTiltDivisionLegacy = new HTuple();
                hv_CameraParamAreaScanBilateralTelecentricTiltDivisionLegacy[0] = "focus";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivisionLegacy[1] = "kappa";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivisionLegacy[2] = "tilt";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivisionLegacy[3] = "rot";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivisionLegacy[4] = "sx";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivisionLegacy[5] = "sy";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivisionLegacy[6] = "cx";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivisionLegacy[7] = "cy";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivisionLegacy[8] = "image_width";
                hv_CameraParamAreaScanBilateralTelecentricTiltDivisionLegacy[9] = "image_height";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy.Dispose();
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy = new HTuple();
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy[0] = "focus";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy[1] = "k1";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy[2] = "k2";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy[3] = "k3";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy[4] = "p1";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy[5] = "p2";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy[6] = "tilt";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy[7] = "rot";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy[8] = "sx";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy[9] = "sy";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy[10] = "cx";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy[11] = "cy";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy[12] = "image_width";
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy[13] = "image_height";
                //
                //If the camera type is passed in CameraParam
                if ((int)((new HTuple((new HTuple(hv_CameraParam.TupleLength())).TupleEqual(
                    1))).TupleAnd(((hv_CameraParam.TupleSelect(0))).TupleIsString())) != 0)
                {
                    hv_CameraType.Dispose();
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_CameraType = hv_CameraParam.TupleSelect(
                            0);
                    }
                    if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_division"))) != 0)
                    {
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanDivision);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_polynomial"))) != 0)
                    {
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanPolynomial);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_telecentric_division"))) != 0)
                    {
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanTelecentricDivision);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_telecentric_polynomial"))) != 0)
                    {
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanTelecentricPolynomial);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_tilt_division"))) != 0)
                    {
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanTiltDivision);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_tilt_polynomial"))) != 0)
                    {
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanTiltPolynomial);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_tilt_image_side_telecentric_division"))) != 0)
                    {
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanImageSideTelecentricTiltDivision);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_tilt_image_side_telecentric_polynomial"))) != 0)
                    {
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_tilt_bilateral_telecentric_division"))) != 0)
                    {
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanBilateralTelecentricTiltDivision);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_tilt_bilateral_telecentric_polynomial"))) != 0)
                    {
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_tilt_object_side_telecentric_division"))) != 0)
                    {
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanObjectSideTelecentricTiltDivision);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_tilt_object_side_telecentric_polynomial"))) != 0)
                    {
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_hypercentric_division"))) != 0)
                    {
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanHypercentricDivision);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_hypercentric_polynomial"))) != 0)
                    {
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanHypercentricPolynomial);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("line_scan"))) != 0)
                    {
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamLinesScan);
                        }
                    }
                    else
                    {
                        throw new HalconException(("Unknown camera type '" + hv_CameraType) + "' passed in CameraParam.");
                    }

                    hv_CameraParamAreaScanDivision.Dispose();
                    hv_CameraParamAreaScanPolynomial.Dispose();
                    hv_CameraParamAreaScanTelecentricDivision.Dispose();
                    hv_CameraParamAreaScanTelecentricPolynomial.Dispose();
                    hv_CameraParamAreaScanTiltDivision.Dispose();
                    hv_CameraParamAreaScanTiltPolynomial.Dispose();
                    hv_CameraParamAreaScanImageSideTelecentricTiltDivision.Dispose();
                    hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial.Dispose();
                    hv_CameraParamAreaScanBilateralTelecentricTiltDivision.Dispose();
                    hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial.Dispose();
                    hv_CameraParamAreaScanObjectSideTelecentricTiltDivision.Dispose();
                    hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial.Dispose();
                    hv_CameraParamAreaScanHypercentricDivision.Dispose();
                    hv_CameraParamAreaScanHypercentricPolynomial.Dispose();
                    hv_CameraParamLinesScan.Dispose();
                    hv_CameraParamAreaScanTiltDivisionLegacy.Dispose();
                    hv_CameraParamAreaScanTiltPolynomialLegacy.Dispose();
                    hv_CameraParamAreaScanTelecentricDivisionLegacy.Dispose();
                    hv_CameraParamAreaScanTelecentricPolynomialLegacy.Dispose();
                    hv_CameraParamAreaScanBilateralTelecentricTiltDivisionLegacy.Dispose();
                    hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy.Dispose();

                    return;
                }
                //
                //If the camera parameters are passed in CameraParam
                if ((int)(((((hv_CameraParam.TupleSelect(0))).TupleIsString())).TupleNot()) != 0)
                {
                    //Format of camera parameters for HALCON 12 and earlier
                    switch ((new HTuple(hv_CameraParam.TupleLength()
                        )).I)
                    {
                        //
                        //Area Scan
                        case 8:
                            //CameraType: 'area_scan_division' or 'area_scan_telecentric_division'
                            if ((int)(new HTuple(((hv_CameraParam.TupleSelect(0))).TupleNotEqual(0.0))) != 0)
                            {
                                hv_ParamNames.Dispose();
                                hv_ParamNames = new HTuple(hv_CameraParamAreaScanDivision);
                                hv_CameraType.Dispose();
                                hv_CameraType = "area_scan_division";
                            }
                            else
                            {
                                hv_ParamNames.Dispose();
                                hv_ParamNames = new HTuple(hv_CameraParamAreaScanTelecentricDivisionLegacy);
                                hv_CameraType.Dispose();
                                hv_CameraType = "area_scan_telecentric_division";
                            }
                            break;
                        case 10:
                            //CameraType: 'area_scan_tilt_division' or 'area_scan_telecentric_tilt_division'
                            if ((int)(new HTuple(((hv_CameraParam.TupleSelect(0))).TupleNotEqual(0.0))) != 0)
                            {
                                hv_ParamNames.Dispose();
                                hv_ParamNames = new HTuple(hv_CameraParamAreaScanTiltDivisionLegacy);
                                hv_CameraType.Dispose();
                                hv_CameraType = "area_scan_tilt_division";
                            }
                            else
                            {
                                hv_ParamNames.Dispose();
                                hv_ParamNames = new HTuple(hv_CameraParamAreaScanBilateralTelecentricTiltDivisionLegacy);
                                hv_CameraType.Dispose();
                                hv_CameraType = "area_scan_tilt_bilateral_telecentric_division";
                            }
                            break;
                        case 12:
                            //CameraType: 'area_scan_polynomial' or 'area_scan_telecentric_polynomial'
                            if ((int)(new HTuple(((hv_CameraParam.TupleSelect(0))).TupleNotEqual(0.0))) != 0)
                            {
                                hv_ParamNames.Dispose();
                                hv_ParamNames = new HTuple(hv_CameraParamAreaScanPolynomial);
                                hv_CameraType.Dispose();
                                hv_CameraType = "area_scan_polynomial";
                            }
                            else
                            {
                                hv_ParamNames.Dispose();
                                hv_ParamNames = new HTuple(hv_CameraParamAreaScanTelecentricPolynomialLegacy);
                                hv_CameraType.Dispose();
                                hv_CameraType = "area_scan_telecentric_polynomial";
                            }
                            break;
                        case 14:
                            //CameraType: 'area_scan_tilt_polynomial' or 'area_scan_telecentric_tilt_polynomial'
                            if ((int)(new HTuple(((hv_CameraParam.TupleSelect(0))).TupleNotEqual(0.0))) != 0)
                            {
                                hv_ParamNames.Dispose();
                                hv_ParamNames = new HTuple(hv_CameraParamAreaScanTiltPolynomialLegacy);
                                hv_CameraType.Dispose();
                                hv_CameraType = "area_scan_tilt_polynomial";
                            }
                            else
                            {
                                hv_ParamNames.Dispose();
                                hv_ParamNames = new HTuple(hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy);
                                hv_CameraType.Dispose();
                                hv_CameraType = "area_scan_tilt_bilateral_telecentric_polynomial";
                            }
                            break;
                        //
                        //Line Scan
                        case 11:
                            //CameraType: 'line_scan'
                            hv_ParamNames.Dispose();
                            hv_ParamNames = new HTuple(hv_CameraParamLinesScan);
                            hv_CameraType.Dispose();
                            hv_CameraType = "line_scan";
                            break;
                        default:
                            throw new HalconException("Wrong number of values in CameraParam.");
                            break;
                    }
                }
                else
                {
                    //Format of camera parameters since HALCON 13
                    hv_CameraType.Dispose();
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_CameraType = hv_CameraParam.TupleSelect(
                            0);
                    }
                    if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_division"))) != 0)
                    {
                        if ((int)(new HTuple((new HTuple(hv_CameraParam.TupleLength())).TupleNotEqual(
                            9))) != 0)
                        {
                            throw new HalconException("Wrong number of values in CameraParam.");
                        }
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanDivision);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_polynomial"))) != 0)
                    {
                        if ((int)(new HTuple((new HTuple(hv_CameraParam.TupleLength())).TupleNotEqual(
                            13))) != 0)
                        {
                            throw new HalconException("Wrong number of values in CameraParam.");
                        }
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanPolynomial);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_telecentric_division"))) != 0)
                    {
                        if ((int)(new HTuple((new HTuple(hv_CameraParam.TupleLength())).TupleNotEqual(
                            9))) != 0)
                        {
                            throw new HalconException("Wrong number of values in CameraParam.");
                        }
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanTelecentricDivision);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_telecentric_polynomial"))) != 0)
                    {
                        if ((int)(new HTuple((new HTuple(hv_CameraParam.TupleLength())).TupleNotEqual(
                            13))) != 0)
                        {
                            throw new HalconException("Wrong number of values in CameraParam.");
                        }
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanTelecentricPolynomial);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_tilt_division"))) != 0)
                    {
                        if ((int)(new HTuple((new HTuple(hv_CameraParam.TupleLength())).TupleNotEqual(
                            12))) != 0)
                        {
                            throw new HalconException("Wrong number of values in CameraParam.");
                        }
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanTiltDivision);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_tilt_polynomial"))) != 0)
                    {
                        if ((int)(new HTuple((new HTuple(hv_CameraParam.TupleLength())).TupleNotEqual(
                            16))) != 0)
                        {
                            throw new HalconException("Wrong number of values in CameraParam.");
                        }
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanTiltPolynomial);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_tilt_image_side_telecentric_division"))) != 0)
                    {
                        if ((int)(new HTuple((new HTuple(hv_CameraParam.TupleLength())).TupleNotEqual(
                            11))) != 0)
                        {
                            throw new HalconException("Wrong number of values in CameraParam.");
                        }
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanImageSideTelecentricTiltDivision);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_tilt_image_side_telecentric_polynomial"))) != 0)
                    {
                        if ((int)(new HTuple((new HTuple(hv_CameraParam.TupleLength())).TupleNotEqual(
                            15))) != 0)
                        {
                            throw new HalconException("Wrong number of values in CameraParam.");
                        }
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_tilt_bilateral_telecentric_division"))) != 0)
                    {
                        if ((int)(new HTuple((new HTuple(hv_CameraParam.TupleLength())).TupleNotEqual(
                            11))) != 0)
                        {
                            throw new HalconException("Wrong number of values in CameraParam.");
                        }
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanBilateralTelecentricTiltDivision);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_tilt_bilateral_telecentric_polynomial"))) != 0)
                    {
                        if ((int)(new HTuple((new HTuple(hv_CameraParam.TupleLength())).TupleNotEqual(
                            15))) != 0)
                        {
                            throw new HalconException("Wrong number of values in CameraParam.");
                        }
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_tilt_object_side_telecentric_division"))) != 0)
                    {
                        if ((int)(new HTuple((new HTuple(hv_CameraParam.TupleLength())).TupleNotEqual(
                            12))) != 0)
                        {
                            throw new HalconException("Wrong number of values in CameraParam.");
                        }
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanObjectSideTelecentricTiltDivision);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_tilt_object_side_telecentric_polynomial"))) != 0)
                    {
                        if ((int)(new HTuple((new HTuple(hv_CameraParam.TupleLength())).TupleNotEqual(
                            16))) != 0)
                        {
                            throw new HalconException("Wrong number of values in CameraParam.");
                        }
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_hypercentric_division"))) != 0)
                    {
                        if ((int)(new HTuple((new HTuple(hv_CameraParam.TupleLength())).TupleNotEqual(
                            9))) != 0)
                        {
                            throw new HalconException("Wrong number of values in CameraParam.");
                        }
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanHypercentricDivision);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("area_scan_hypercentric_polynomial"))) != 0)
                    {
                        if ((int)(new HTuple((new HTuple(hv_CameraParam.TupleLength())).TupleNotEqual(
                            13))) != 0)
                        {
                            throw new HalconException("Wrong number of values in CameraParam.");
                        }
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamAreaScanHypercentricPolynomial);
                        }
                    }
                    else if ((int)(new HTuple(hv_CameraType.TupleEqual("line_scan"))) != 0)
                    {
                        if ((int)(new HTuple((new HTuple(hv_CameraParam.TupleLength())).TupleNotEqual(
                            12))) != 0)
                        {
                            throw new HalconException("Wrong number of values in CameraParam.");
                        }
                        hv_ParamNames.Dispose();
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            hv_ParamNames = new HTuple();
                            hv_ParamNames[0] = "camera_type";
                            hv_ParamNames = hv_ParamNames.TupleConcat(hv_CameraParamLinesScan);
                        }
                    }
                    else
                    {
                        throw new HalconException("Unknown camera type in CameraParam.");
                    }
                }

                hv_CameraParamAreaScanDivision.Dispose();
                hv_CameraParamAreaScanPolynomial.Dispose();
                hv_CameraParamAreaScanTelecentricDivision.Dispose();
                hv_CameraParamAreaScanTelecentricPolynomial.Dispose();
                hv_CameraParamAreaScanTiltDivision.Dispose();
                hv_CameraParamAreaScanTiltPolynomial.Dispose();
                hv_CameraParamAreaScanImageSideTelecentricTiltDivision.Dispose();
                hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial.Dispose();
                hv_CameraParamAreaScanBilateralTelecentricTiltDivision.Dispose();
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial.Dispose();
                hv_CameraParamAreaScanObjectSideTelecentricTiltDivision.Dispose();
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial.Dispose();
                hv_CameraParamAreaScanHypercentricDivision.Dispose();
                hv_CameraParamAreaScanHypercentricPolynomial.Dispose();
                hv_CameraParamLinesScan.Dispose();
                hv_CameraParamAreaScanTiltDivisionLegacy.Dispose();
                hv_CameraParamAreaScanTiltPolynomialLegacy.Dispose();
                hv_CameraParamAreaScanTelecentricDivisionLegacy.Dispose();
                hv_CameraParamAreaScanTelecentricPolynomialLegacy.Dispose();
                hv_CameraParamAreaScanBilateralTelecentricTiltDivisionLegacy.Dispose();
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {

                hv_CameraParamAreaScanDivision.Dispose();
                hv_CameraParamAreaScanPolynomial.Dispose();
                hv_CameraParamAreaScanTelecentricDivision.Dispose();
                hv_CameraParamAreaScanTelecentricPolynomial.Dispose();
                hv_CameraParamAreaScanTiltDivision.Dispose();
                hv_CameraParamAreaScanTiltPolynomial.Dispose();
                hv_CameraParamAreaScanImageSideTelecentricTiltDivision.Dispose();
                hv_CameraParamAreaScanImageSideTelecentricTiltPolynomial.Dispose();
                hv_CameraParamAreaScanBilateralTelecentricTiltDivision.Dispose();
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomial.Dispose();
                hv_CameraParamAreaScanObjectSideTelecentricTiltDivision.Dispose();
                hv_CameraParamAreaScanObjectSideTelecentricTiltPolynomial.Dispose();
                hv_CameraParamAreaScanHypercentricDivision.Dispose();
                hv_CameraParamAreaScanHypercentricPolynomial.Dispose();
                hv_CameraParamLinesScan.Dispose();
                hv_CameraParamAreaScanTiltDivisionLegacy.Dispose();
                hv_CameraParamAreaScanTiltPolynomialLegacy.Dispose();
                hv_CameraParamAreaScanTelecentricDivisionLegacy.Dispose();
                hv_CameraParamAreaScanTelecentricPolynomialLegacy.Dispose();
                hv_CameraParamAreaScanBilateralTelecentricTiltDivisionLegacy.Dispose();
                hv_CameraParamAreaScanBilateralTelecentricTiltPolynomialLegacy.Dispose();

                throw HDevExpDefaultException;
            }
        }
        public void fillter_Erosion(HWindow hWindow, HObject ho_Image, out HObject ho_object_done,bool stepbystep,int Erosion_W,int Erosion_H)
        {
            HOperatorSet.ErosionRectangle1(ho_Image, out ho_object_done, Erosion_W, Erosion_H);
            if (stepbystep == true)
            {
                HOperatorSet.ClearWindow(hWindow);
                HOperatorSet.DispObj(ho_object_done, hWindow);
                MessageBox.Show("ho_ero");
            }
        }
        public void fillter_Dilation(HWindow hWindow, HObject ho_Image, out HObject ho_object_done, bool stepbystep, int Dilation_W, int Dilation_H)
        {
            HOperatorSet.DilationRectangle1(ho_Image, out ho_object_done, Dilation_W, Dilation_H);
            if (stepbystep == true)
            {
                HOperatorSet.ClearWindow(hWindow);
                HOperatorSet.DispObj(ho_object_done, hWindow);
                MessageBox.Show("ho_dila");
            }
        }
        public void Adjust_bright(HWindow hWindow, HObject ho_)
        {
          
        }

    }


}
