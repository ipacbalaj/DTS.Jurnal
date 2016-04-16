using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using Novacode;
namespace DSA.FileUpload.ExcelFile
{
    public static class DocExporter
    {
        private static List<string> headerList = new List<string>() { "Data", "Nume Prenume", "Locatie", "Manopera", "Ora", "Durata", "Starsit", "Incasare" };

//        public static void ExportToDoc(List<InterventionDetails> intervensions)
//        {
//            try
//            {
//                var currentData = DateTime.Now;
//                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\DTS\Plati\doc\";
//                string fileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\DTS\Plati\doc\" + currentData.Year + "_" + currentData.Month + "_" + currentData.Day + ".xls";
//                if (!Directory.Exists(path))
//                    Directory.CreateDirectory(path);
//                var doc = DocX.Create(fileName);
//                Table table = doc.AddTable(intervensions.Count + 2, headerList.Count);
//                for (int i = 0; i < headerList.Count; i++)
//                {
//                    Paragraph currParagraph = table.Rows[0].Cells[i].Paragraphs.First().Append(headerList[i]);
//                    currParagraph.Bold();
//                }
//
//                int rowCount = 1;
//                foreach (var intervention in intervensions)
//                {
//                    int colCount = 0;
//                    //                foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(financialInfo))
//                    //                {
//                    //                    table.Rows[rowCount].Cells[colCount].Paragraphs.First().Append(prop.Converter.ConvertToString(prop.GetValue(financialInfo)));
//                    //                    colCount++;
//                    //                }
//                    foreach (var interventionDetailse in intervensions)
//                    {
//                        table.Rows[rowCount].Cells[0].Paragraphs.First().Append(interventionDetailse.Date.ToShortDateString());
//                        table.Rows[rowCount].Cells[1].Paragraphs.First().Append(interventionDetailse.PacientName);
//                        table.Rows[rowCount].Cells[2].Paragraphs.First().Append(interventionDetailse.Location);
//                        table.Rows[rowCount].Cells[3].Paragraphs.First().Append(interventionDetailse.Work);
//                        table.Rows[rowCount].Cells[4].Paragraphs.First().Append(interventionDetailse.StartH);
//                        table.Rows[rowCount].Cells[5].Paragraphs.First().Append(interventionDetailse.Durata.TotalMinutes.ToString());
//                        table.Rows[rowCount].Cells[6].Paragraphs.First().Append(interventionDetailse.EndH);
//                        table.Rows[rowCount].Cells[7].Paragraphs.First().Append(interventionDetailse.Revenue.ToString());
//                    }
//                    rowCount++;
//                }
//            }
//            catch (Exception)
//            {
//
//                MessageBox.Show("A intervenit o eroare.");
//            }
//        }
    }
}
