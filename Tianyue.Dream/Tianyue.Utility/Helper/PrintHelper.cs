using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Utility.Helper
{
    public class PrintHelper
    {
        private static readonly PrintDocument FPrintDocument = new PrintDocument();

        //获取本地默认打印机名称
        ///<summary>
        ///获取本地默认打印机名称
        ///</summary>
        public static string DefaultPrinter
        {
            get
            {
                return FPrintDocument.PrinterSettings.PrinterName;
            }
        }

        //获取本地打印机的列表，第一项就是默认打印机
        /// <summary>
        ///  获取本地打印机的列表，第一项就是默认打印机
        /// </summary>
        public static List<string> GetLocalPrinter()
        {
            var fPrinters = new List<string>
                                {
                                    DefaultPrinter
                                };
            foreach (string fPrinterName in PrinterSettings.InstalledPrinters)
            {
                if (!fPrinters.Contains(fPrinterName))
                    fPrinters.Add(fPrinterName);
            }
            return fPrinters;
        }
    }
}
