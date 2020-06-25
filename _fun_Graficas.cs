using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Text;
//using Microsoft.WindowsCE.Forms;
using System.Runtime.InteropServices;



namespace Adhesive_Weight
{

    class _fun_Graficas
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        public FontFamily D3_Archism;
        public FontFamily Eras_demi;
        public FontFamily Tamworth;
        //public Font D3_Archism;

        #region Fonts
        public void Carga_Eras_demi()
        {
            byte[] fontArray = Properties.Resources.ERASDEMI;
            int dataLength = Properties.Resources.ERASDEMI.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddMemoryFont(ptrData, dataLength);

            Marshal.FreeCoTaskMem(ptrData);

            Eras_demi = pfc.Families[0];

        }

        public void Carga_D3_Archism()
        {
            byte[] fontArray = Properties.Resources.D3_Archism;
            int dataLength = Properties.Resources.D3_Archism.Length;


            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddMemoryFont(ptrData, dataLength);

            Marshal.FreeCoTaskMem(ptrData);

            D3_Archism = pfc.Families[0];

        }

        public void Carga_TamWorth()
        {
            byte[] fontArray = Properties.Resources.TAMWORTH;
            int dataLength = Properties.Resources.TAMWORTH.Length;


            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddMemoryFont(ptrData, dataLength);

            Marshal.FreeCoTaskMem(ptrData);

            Tamworth = pfc.Families[0];

        }

        #endregion // Fonts


        /* Funciones Gráficas para Textos, Label's etc... *************************************************************************************************/

        public void _Text(Graphics e, String pTexto, int px1, int py1, Font pFuente, Brush pBrush)
        {
            e.DrawString(pTexto, pFuente, pBrush, px1, py1);
        }

        public void _Text(Graphics e, String pTexto, int px1, int py1, String pFuente, int pSize, FontStyle pFontStyle, Color pColor)
        {

            e.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            Font vF = new Font(pFuente, pSize, pFontStyle);
            Brush vB = new SolidBrush(pColor);
            e.DrawString(pTexto, vF, vB, px1, py1);

        }

        public void _Text(Graphics e, String pTexto, int px1, int py1, FontFamily pFontFamily, int pSize, FontStyle pFontStyle, Color pColor)
        {

            e.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            Font lFont = new Font(pFontFamily, pSize, pFontStyle);
            Brush lBrush = new SolidBrush(pColor);
            e.DrawString(pTexto, lFont, lBrush, px1, py1);

        }

        public void _Text(Graphics e, String pTexto, float px1, float py1, float pAngulo, FontFamily pFontFamily, int pSize, FontStyle pFontStyle, Color pColor)
        {


            e.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;


            Font lFont = new Font(pFontFamily, pSize, pFontStyle);
            Brush lBrush = new SolidBrush(pColor);
            //  StringFormat  lFormato = new StringFormat(StringFormatFlags.DirectionVertical  );

            //SizeF sz = e.MeasureString(pTexto, lFont);
            //e.TranslateTransform(sz.Width, sz.Height); 


            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;

            SizeF txt = e.MeasureString(pTexto, lFont);
            SizeF sz = e.VisibleClipBounds.Size;

            ////90 degrees
            e.TranslateTransform(px1, py1);
            e.RotateTransform(pAngulo);
            //e.DrawString(pTexto, lFont, Brushes.Red , new RectangleF(0, 0, sz.Height, sz.Width), format);
            e.DrawString(pTexto, lFont, lBrush, new RectangleF(0, 0, sz.Height, sz.Width));
            e.ResetTransform();



        }


        public void _Text(Graphics e, String pTexto, int px1, int py1, FontFamily pFontFamily, int pSize, FontStyle pFontStyle, Color pColor, Color pColor2, LinearGradientMode pLinearMode)
        {
            if (pTexto.Length > 0)
            {
                e.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                Font lFont = new Font(pFontFamily, pSize, pFontStyle);
                SizeF ubound = e.MeasureString(pTexto, lFont);

                //Brush lBrush = new LinearGradientBrush(new Rectangle(px1 + (int)(ubound.Width/2), py1, (int)ubound.Width*2, (int)ubound.Height), pColor, pColor2, 180, true);

                Brush lBrush = new LinearGradientBrush(new Rectangle(px1, py1, (int)ubound.Width, (int)ubound.Height), pColor, pColor2, pLinearMode);

                //GraphicsContainer 

                e.DrawString(pTexto, lFont, lBrush, px1, py1);
            }
            //e.DrawString()
        }



        public void _Text(Graphics e, String pTexto, int px1, int py1, String pFuente, int pSize, FontStyle pFontStyle, Color pColor, Color pColor2, LinearGradientMode pLinearMode)
        {

            e.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            Font vF = new Font(pFuente, pSize, pFontStyle);
            Brush vB = new LinearGradientBrush(new Rectangle(px1, py1, 50, pSize + 10), pColor, pColor2, pLinearMode);
            e.DrawString(pTexto, vF, vB, px1, py1);

        }
        /****   Funciones Gráficas para RECT    *************************************************************************/

        public void Rect_NoFill(Graphics e, Rectangle pArea, Color pColor)
        {
            Pen lB = new Pen(pColor);
            e.DrawRectangle(lB, pArea);
        }


        public void RectF(Graphics e, RectangleF pAreaF, Color pColor)
        {
            Brush lB = new SolidBrush(pColor);
            e.FillRectangle(lB, pAreaF);
        }


        public void Rect(Graphics e, Rectangle pArea, Color pColor)
        {
            e.SmoothingMode = SmoothingMode.None;
            Brush lB = new SolidBrush(pColor);
            e.FillRectangle(lB, pArea);
        }

        public void Rect(Graphics e, Rectangle pArea, Color pColor1, Color pColor2, LinearGradientMode pLinearMode)
        {
            if (pArea.Width > 0)
            {

                Brush lB = new LinearGradientBrush(pArea, pColor1, pColor2, pLinearMode);
                e.FillRectangle(lB, pArea);
            }
        }

        public void RoundRect(Graphics e, Rectangle pRec, int pAngulo, Color pColor_Marco, Color pColor_relleno)
        {
            pAngulo *= 1;
            e.SmoothingMode = SmoothingMode.AntiAlias;
            Pen Color_Marco = new Pen(pColor_Marco);  //new TextureBrush(StartImage);
            Brush pBrocha = new SolidBrush(pColor_relleno);
            GraphicsPath gp = new GraphicsPath();

            //////gp.AddArc(pRec.Left, pRec.Top, pAngulo, pAngulo, 180, 90);
            //////gp.AddArc(pRec.Left + pRec.Width - pAngulo, pRec.Top, pAngulo, pAngulo, 270, 90);
            //////gp.AddArc(pRec.Left + pRec.Width - pAngulo, pRec.Top + pRec.Height - pAngulo, pAngulo, pAngulo, 0, 90);
            //////gp.AddArc(pRec.Left, pRec.Top + pRec.Height - pAngulo, pAngulo, pAngulo, 90, 90);
            ////////gp.AddArc(pRec.Left, pRec.Top, pAngulo, pAngulo, 180, 90);

            gp.AddArc(pRec.Left, pRec.Top, pAngulo, pAngulo, 180, 90);
            gp.AddLine(pRec.Left + pAngulo, pRec.Y, pRec.Left + pRec.Width - pAngulo, pRec.Y);
            gp.AddArc(pRec.Left + pRec.Width - pAngulo, pRec.Y, pAngulo, (pAngulo), 270, 90);
            gp.AddLine(pRec.Left + pRec.Width, pRec.Y + pAngulo, pRec.Left + pRec.Width, pRec.Y + pRec.Height - pAngulo);
            gp.AddArc(pRec.Left + pRec.Width - pAngulo, pRec.Top + pRec.Height - pAngulo, pAngulo, pAngulo, 0, 90);
            gp.AddLine(pRec.Left + pRec.Width - pAngulo, pRec.Y + pRec.Height, pRec.Left + pAngulo, pRec.Y + pRec.Height);
            gp.AddArc(pRec.Left, pRec.Top + pRec.Height - pAngulo, pAngulo, pAngulo, 90, 90);
            gp.AddLine(pRec.Left, pRec.Y + pRec.Height - pAngulo, pRec.Left, pRec.Y + (pAngulo / 2));

            e.DrawPath(Color_Marco, gp);

            e.FillPath(pBrocha, gp);
        }

        public void RoundRect(Graphics e, Rectangle pRec, int pAngulo, Color pColor_Marco, Color pColor_g1, Color pColor_g2, LinearGradientMode LGMode)
        {
            pAngulo *= 1;
            e.SmoothingMode = SmoothingMode.AntiAlias;
            Pen Color_Marco = new Pen(pColor_Marco);  //new TextureBrush(StartImage);
                                                      //Brush pBrocha = new SolidBrush(pColor_relleno);
            Brush pBrocha = new LinearGradientBrush(pRec, pColor_g1, pColor_g2, LGMode);

            GraphicsPath gp = new GraphicsPath();
            if (pRec.Height > 0)
            {
                gp.AddArc(pRec.Left, pRec.Top, pAngulo, pAngulo, 180, 90);
                gp.AddLine(pRec.Left + pAngulo, pRec.Y, pRec.Left + pRec.Width - pAngulo, pRec.Y);
                gp.AddArc(pRec.Left + pRec.Width - pAngulo, pRec.Y, pAngulo, (pAngulo), 270, 90);
                gp.AddLine(pRec.Left + pRec.Width, pRec.Y + pAngulo, pRec.Left + pRec.Width, pRec.Y + pRec.Height - pAngulo);
                gp.AddArc(pRec.Left + pRec.Width - pAngulo, pRec.Top + pRec.Height - pAngulo, pAngulo, pAngulo, 0, 90);
                gp.AddLine(pRec.Left + pRec.Width - pAngulo, pRec.Y + pRec.Height, pRec.Left + pAngulo, pRec.Y + pRec.Height);
                gp.AddArc(pRec.Left, pRec.Top + pRec.Height - pAngulo, pAngulo, pAngulo, 90, 90);
                gp.AddLine(pRec.Left, pRec.Y + pRec.Height - pAngulo, pRec.Left, pRec.Y + (pAngulo / 2));

                e.DrawPath(Color_Marco, gp);

                e.FillPath(pBrocha, gp);
            }
        }

        /***** Grid_Cells ***********************************************************************************************************************************/
        public void Cell_T(Graphics e, Rectangle pRec, int pRow_Height, int pCol_Width, Color pColor_Marco, Color pColor_relleno)
        {

            e.SmoothingMode = SmoothingMode.AntiAlias;
            Pen Color_Marco = new Pen(pColor_Marco);  //new TextureBrush(StartImage);
            Brush pBrocha = new SolidBrush(pColor_relleno);
            GraphicsPath gp = new GraphicsPath();

            if (pRow_Height > 2)
                pRow_Height--;

            if (pCol_Width > 2)
                pCol_Width--;

            pRec = new Rectangle(pRec.X, pRec.Y, (pRec.Width - 1), (pRec.Height - 1));

            gp.AddLine(pRec.Left, pRec.Y, pRec.Left + pRec.Width, pRec.Y);
            gp.AddLine(pRec.Left + pRec.Width, pRec.Y + pRow_Height, pRec.Left + pCol_Width, pRec.Y + pRow_Height);
            gp.AddLine(pRec.Left + pCol_Width, pRec.Y + (pRow_Height), pRec.Left + pCol_Width, pRec.Y + (pRec.Height));
            ////////gp.AddLine(pRec.Left + pCol_Width, pRec.Y + pRow_Height, pRec.Left + pCol_Width, pRec.Y + pRec.Height );
            ////////gp.AddLine(pRec.Left + pCol_Width, pRec.Y + pRec.Height, pRec.Left, pRec.Y + pRec.Height );
            gp.AddLine(pRec.Left, pRec.Y + (pRec.Height), pRec.Left, pRec.Y);

            e.DrawPath(Color_Marco, gp);

            e.FillPath(pBrocha, gp);
        }

        /***** TIME ICON ***********************************************************************************************************************************/
        public void TimeIcon(Graphics e, Rectangle pRec, int pAngulo, int wPalo, int hCono, Color pColor_Marco, Color pColor_g1, Color pColor_g2, LinearGradientMode LGMode)
        {
            pAngulo *= 1;
            e.SmoothingMode = SmoothingMode.AntiAlias;
            Pen Color_Marco = new Pen(pColor_Marco);  //new TextureBrush(StartImage);
                                                      //Brush pBrocha = new SolidBrush(pColor_relleno);
            Brush pBrocha = new LinearGradientBrush(pRec, pColor_g1, pColor_g2, LGMode);

            GraphicsPath gp = new GraphicsPath();




            gp.AddArc(pRec.Left, pRec.Y, pAngulo, pAngulo, 130, 160);
            gp.AddLine(pRec.Left + pAngulo, pRec.Y, pRec.Left + pRec.Width - pAngulo, pRec.Y);
            gp.AddArc(pRec.Left + pRec.Width - pAngulo, pRec.Y, pAngulo, (pAngulo), 270, 160);
            gp.AddLine(pRec.Left + (pRec.Width / 2) + wPalo, pRec.Y + hCono, pRec.Left + (pRec.Width / 2) + wPalo, pRec.Y + pRec.Height);
            gp.AddLine(pRec.Left + (pRec.Width / 2) + wPalo, pRec.Y + pRec.Height, pRec.Left + (pRec.Width / 2) - wPalo, pRec.Y + pRec.Height);
            gp.AddLine(pRec.Left + (pRec.Width / 2) - wPalo, pRec.Y + pRec.Height, pRec.Left + (pRec.Width / 2) - wPalo, pRec.Y + hCono);
            gp.AddLine(pRec.Left + (pRec.Width / 2) - wPalo, pRec.Y + hCono, pRec.Left + 2, pRec.Y + pAngulo);

            //gp.AddLine(pRec.Left + (pRec.Width/2) + wPalo , pRec.Y + pRec.Height - hCono , pRec.Left + pRec.Width - pAngulo , pRec.Y + pRec.Height- pAngulo);

            //gp.AddArc(pRec.Left + pRec.Width - pAngulo, pRec.Y + pRec.Height -pAngulo, (pAngulo), pAngulo, 290, 160);

            //gp.AddLine(pRec.Left + (pRec.Width) - pAngulo, pRec.Y + pRec.Height , pRec.Left + pAngulo, pRec.Y + pRec.Height );
            //gp.AddArc(pRec.Left , pRec.Y + pRec.Height - pAngulo, (pAngulo), (pAngulo), -270, 100);

            //gp.AddLine(pRec.Left + pAngulo , pRec.Y + pRec.Height - pAngulo-2, pRec.Left + ((pRec.Width /2)-wPalo), pRec.Y + pRec.Height -hCono);

            //gp.AddLine(pRec.Left + ((pRec.Width /2)-wPalo),  pRec.Y + pRec.Height -hCono, pRec.Left + ((pRec.Width /2)-wPalo) , pRec.Y + hCono);

            //gp.AddLine(pRec.Left + ((pRec.Width /2)-wPalo) , pRec.Y + hCono, pRec.Left , pRec.Y+pAngulo-1);

            //gp.AddArc(pRec.Left + pRec.Width - pAngulo , pRec.Y + pRec.Height- pAngulo, (pAngulo), pAngulo, 160, 90);
            //gp.AddLine(pRec.Left + pRec.Width - pAngulo, pRec.Y + pAngulo, pRec.Left + pAngulo + (pRec.Width /2) + 5 , pRec.Y + pRec.Height /5 );
            //           gp.AddLine(pRec.Left + pRec.Width - pAngulo - (pRec.Width /3), pRec.Y + pAngulo, pRec.Left + pRec.Width, pRec.Y + pRec.Height );
            //gp.AddArc(pRec.Left + pRec.Width - pAngulo, pRec.Top + pRec.Height - pAngulo, pAngulo, pAngulo, 0, 90);
            //gp.AddLine(pRec.Left + pRec.Width - pAngulo, pRec.Y + pRec.Height, pRec.Left + pAngulo, pRec.Y + pRec.Height);
            //gp.AddArc(pRec.Left, pRec.Top + pRec.Height - pAngulo, pAngulo, pAngulo, 90, 90);
            //         gp.AddLine(pRec.Left, pRec.Y + pRec.Height - pAngulo, pRec.Left, pRec.Y + (pAngulo / 2));

            e.DrawPath(Color_Marco, gp);

            e.FillPath(pBrocha, gp);
        }

        /******* Funciones Elipticas **********************************************************************************************************************/
        public void Ellipse(Graphics e, int px, int py, int pw, int ph)
        {
            int Width = pw;
            int Height = ph;

            PathGradientBrush GradientBrush;

            GraphicsPath Circle = new GraphicsPath();

            Circle.AddEllipse(px, py, Width, Height);

            GradientBrush = new PathGradientBrush(Circle);

            Color[] SurroundColors = { Color.FromArgb(10, 32, 32, 32) };
            GradientBrush.SurroundColors = SurroundColors;

            GradientBrush.CenterColor = Color.FromArgb(120, 250, 250, 250);
            //GradientBrush.CenterColor = Color.FromArgb(85,156,241);
            e.FillRectangle(GradientBrush, px, py, Width, Height);

        }

        public void Ellipse(Graphics e, int x1, int y1, int w1, int h1, Color Color_Centro, Color Surround_Colors)
        {

            PathGradientBrush GradientBrush;
            GraphicsPath Circle = new GraphicsPath();
            Circle.AddEllipse(x1, y1, w1, h1);
            GradientBrush = new PathGradientBrush(Circle);
            Color[] SurroundColors = { Surround_Colors };
            GradientBrush.SurroundColors = SurroundColors;
            GradientBrush.CenterColor = Color_Centro;
            e.FillRectangle(GradientBrush, x1, y1, w1, h1);

        }

        public void Ellipse(Graphics e, Rectangle pArea, Color Color_Centro, Color Surround_Colors)
        {

            PathGradientBrush GradientBrush;
            GraphicsPath Circle = new GraphicsPath();
            Circle.AddEllipse(pArea);
            GradientBrush = new PathGradientBrush(Circle);
            Color[] SurroundColors = { Surround_Colors };
            GradientBrush.SurroundColors = SurroundColors;
            GradientBrush.CenterColor = Color_Centro;
            e.FillRectangle(GradientBrush, pArea);

        }

        public void Ellipse(Graphics e, Rectangle pArea, Color Color_Centro, Color[] Surround_Colors)
        {

            PathGradientBrush GradientBrush;
            GraphicsPath Circle = new GraphicsPath();
            Circle.AddEllipse(pArea);
            GradientBrush = new PathGradientBrush(Circle);
            GradientBrush.SurroundColors = Surround_Colors;
            GradientBrush.CenterColor = Color_Centro;
            e.FillRectangle(GradientBrush, pArea);

        }


        public void Ellipse(Graphics e, int x1, int y1, int w1, int h1, Color Color_Centro, Color[] Surround_Colors)
        {

            PathGradientBrush GradientBrush;
            GraphicsPath Circle = new GraphicsPath();
            Circle.AddEllipse(x1, y1, w1, h1);
            GradientBrush = new PathGradientBrush(Circle);
            GradientBrush.SurroundColors = Surround_Colors;
            GradientBrush.CenterColor = Color_Centro;
            e.FillRectangle(GradientBrush, x1, y1, w1, h1);

        }

        public void Ellipse_noFill(Graphics e, int x1, int y1, int w1, int h1, Color Color_Centro, Color[] Surround_Colors)
        {

            PathGradientBrush GradientBrush;
            GraphicsPath Circle = new GraphicsPath();
            Circle.AddEllipse(x1, y1, w1, h1);
            GradientBrush = new PathGradientBrush(Circle);
            GradientBrush.SurroundColors = Surround_Colors;
            GradientBrush.CenterColor = Color_Centro;
            e.DrawEllipse(new Pen(Color_Centro), new Rectangle(x1, y1, w1, h1));

        }

        public void Ellipse_noFill(Graphics e, Rectangle pArea, Color Color_Centro, Color Surround_Colors)
        {

            PathGradientBrush GradientBrush;
            GraphicsPath Circle = new GraphicsPath();
            Circle.AddEllipse(pArea);
            GradientBrush = new PathGradientBrush(Circle);
            Color[] SurroundColors = { Surround_Colors };
            GradientBrush.CenterColor = Color_Centro;
            e.DrawEllipse(new Pen(Color_Centro), pArea);

        }

        public void btn_Check(Graphics e, Rectangle pRec, int pAngulo, Color pColor_Marco, Color pColor_g1, Color pColor_g2, LinearGradientMode LGMode)
        {
            pAngulo *= 1;
            e.SmoothingMode = SmoothingMode.AntiAlias;
            Pen Color_Marco = new Pen(pColor_Marco);  //new TextureBrush(StartImage);
                                                      //Brush pBrocha = new SolidBrush(pColor_relleno);
            Brush pBrocha = new LinearGradientBrush(pRec, pColor_g1, pColor_g2, LGMode);

            GraphicsPath gp = new GraphicsPath();

            gp.AddArc(pRec.Left, pRec.Top, pAngulo, pAngulo, 180, 90);
            gp.AddLine(pRec.Left + pAngulo, pRec.Y, pRec.Left + pRec.Width - pAngulo, pRec.Y);
            gp.AddArc(pRec.Left + pRec.Width - pAngulo, pRec.Y, pAngulo, (pAngulo), 270, 90);
            gp.AddLine(pRec.Left + pRec.Width, pRec.Y + pAngulo, pRec.Left + pRec.Width, pRec.Y + pRec.Height - pAngulo);
            gp.AddArc(pRec.Left + pRec.Width - pAngulo, pRec.Top + pRec.Height - pAngulo, pAngulo, pAngulo, 0, 90);
            gp.AddLine(pRec.Left + pRec.Width - pAngulo, pRec.Y + pRec.Height, pRec.Left + pAngulo, pRec.Y + pRec.Height);
            gp.AddArc(pRec.Left, pRec.Top + pRec.Height - pAngulo, pAngulo, pAngulo, 90, 90);
            gp.AddLine(pRec.Left, pRec.Y + pRec.Height - pAngulo, pRec.Left, pRec.Y + (pAngulo / 2));

            e.DrawPath(Color_Marco, gp);
            e.FillPath(pBrocha, gp);

            float lwidth = (pRec.Height / 2);
            gp = new GraphicsPath();
            pAngulo = 5;

            gp.AddLine(pRec.Left, pRec.Y + (lwidth / 2), pRec.Left + lwidth - pAngulo, pRec.Y + (lwidth / 2));
            gp.AddArc(pRec.Left + lwidth - pAngulo, pRec.Y + (lwidth / 2), pAngulo, (pAngulo), 270, 90);
            gp.AddLine(pRec.Left + lwidth, pRec.Y + (lwidth / 2) + pAngulo, pRec.Left + lwidth, pRec.Y + lwidth + pAngulo);
            gp.AddArc(pRec.Left + lwidth - pAngulo, pRec.Y + lwidth + pAngulo, pAngulo, pAngulo, 0, 90);
            gp.AddLine(pRec.Left + lwidth - pAngulo, pRec.Y + lwidth + pAngulo * 2, pRec.Left, pRec.Y + lwidth + pAngulo * 2);

            Color_Marco = new Pen(Color.FromArgb(14, 14, 14));  //new TextureBrush(StartImage);
            pBrocha = new LinearGradientBrush(pRec, pColor_g1, Color.FromArgb(32, 32, 32), LGMode);

            e.DrawPath(Color_Marco, gp);
            e.FillPath(pBrocha, gp);
        }

    }
}
