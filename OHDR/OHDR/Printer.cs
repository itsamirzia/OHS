using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

namespace OHDR
{
    static class BadgePrinter
    {
        public static string barcode = string.Empty;
        public static string nameDesignationCompany = string.Empty;
        public static string registrationType = string.Empty;
        private static Font printFont;
        private static Font printFontVisitor;

        public static void PrintBadges( )
        {
            try
            {
                printFont = new Font("Arial", 12, FontStyle.Bold);
                printFontVisitor = new Font("Arial Black", 36, FontStyle.Bold);
                PrintDocument printDocument = new PrintDocument();

                // We ALWAYS want true here, as we will implement the 
                // margin limitations later in code.
                //printDocument.OriginAtMargins = true;
                // printDocument.DefaultPageSettings.Margins(100, 100, 100, 100);
                printDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

                // Set some preferences, our method should print a box with any 
                // combination of these properties being true/false.
                printDocument.DefaultPageSettings.Landscape = false;

                //printDocument.DefaultPageSettings.PrintableArea.Height = 400;
                PaperSize ps = new PaperSize("Custom", 816, 800);


                printDocument.DefaultPageSettings.PaperSize = ps;
                //printDocument.DefaultPageSettings.PaperSize.Width = (int)(100 / 25.4) * 102;
                //printDocument.DefaultPageSettings.PrintableArea.Height = (float)100;
                //printDocument.PrinterSettings.PrinterName = "ZDesigner S4M-203dpi ZPL (Copy 1)";
                printDocument.PrintPage += new PrintPageEventHandler
                    (pd_PrintPage);

                //PrintController printController = new StandardPrintController();
                //printDocument.PrintController = printController;
                // printPreviewDialog1.Document = printDocument;
                // printPreviewDialog1.ShowDialog();
                printDocument.Print();

            }
            catch (Exception)
            {
               
            }

        }
        private static void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            ev.Graphics.PageUnit = GraphicsUnit.Millimeter;
            string[] display1 = Properties.Settings.Default.TextArea.Split(',');
            Rectangle displayRectangle =
            new Rectangle(Convert.ToInt32(display1[0]), Convert.ToInt32(display1[1]), Convert.ToInt32(display1[2]), Convert.ToInt32(display1[3]));

            string[] display2 = Properties.Settings.Default.BadgeArea.Split(',');
            Rectangle displayRectangle2 =
            new Rectangle(Convert.ToInt32(display2[0]), Convert.ToInt32(display2[1]), Convert.ToInt32(display2[2]), Convert.ToInt32(display2[3]));

            StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
            format1.Alignment = StringAlignment.Center;
            format1.LineAlignment = StringAlignment.Center;

            if (Properties.Settings.Default.PrintBarcode)
            {
                Bitmap bitm = new Bitmap(barcode.Length * 3, 10);
                using (Graphics graphic = Graphics.FromImage(bitm))
                {

                    string[] display3 = Properties.Settings.Default.BarcodeArea.Split(',');
                    Rectangle displayBarcode =
                                    new Rectangle(Convert.ToInt32(display3[0]), Convert.ToInt32(display3[1]), Convert.ToInt32(display3[2]), Convert.ToInt32(display3[3]));

                    Font newfont = new Font("IDAutomationHC39M", 12);
                    PointF point = new PointF(2f, 2f);
                    SolidBrush black = new SolidBrush(Color.Black);
                    SolidBrush white = new SolidBrush(Color.White);
                    ev.Graphics.FillRectangle(white, 0, 0, bitm.Width, bitm.Height);
                    ev.Graphics.DrawString("*" + barcode.ToUpper() + "*", newfont, black, displayBarcode, format1);
                }
            }

            ev.Graphics.DrawString(nameDesignationCompany.ToUpper(), printFont, Brushes.Black, displayRectangle, format1);
            ev.Graphics.DrawString(registrationType.ToUpper(), printFontVisitor, Brushes.Black, displayRectangle2, format1);
            ev.HasMorePages = false;
        }
    }
}
