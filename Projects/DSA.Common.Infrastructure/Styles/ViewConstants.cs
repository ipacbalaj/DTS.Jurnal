using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Common.Infrastructure.Styles
{
    public static class ViewConstants
    {
        public static  string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\DTS\LoginInfoJournal";

        public static string DimenstionAuto = "Auto";
        public static string DimenstionStar = "*";

        //Symbols
        public static string EditSymbol = "✎";
        public static string AddSymbol = "✚";
        public static string DeleteSymbol = "✘";
        public static string SaveSymbol = "✔";
    }
}
