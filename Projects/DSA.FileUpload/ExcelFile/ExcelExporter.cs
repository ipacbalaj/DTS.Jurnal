using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSA.Common.Infrastructure.Entities;
using DSA.Common.Infrastructure.Helpers;
using DSA.Common.Infrastructure.Styles;
using DSA.Database.Model;
using DSA.Database.Model.Entities.Local;
using DSA.Database.Model.Helpers;
using DTS.Jurnal.Database.Model.Entities.Local;
using DTS.Jurnal.V3.Database.Module;
using DTS.Jurnal.V3.Database.Module.Entities.Local;
using Excel = Microsoft.Office.Interop.Excel;
namespace DSA.FileUpload.ExcelFile
{
    public static class ExcelExporter
    {
        public static void ExportExcelFile(List<InterventionModel> interventions)
        {
            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                Excel.Range chartRange;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Cells[1, 1] = "Data";
                xlWorkSheet.Cells[1, 2] = "Nume Prenume";
                xlWorkSheet.Cells[1, 3] = "Locație";
                xlWorkSheet.Cells[1, 4] = "Manoperă";
                xlWorkSheet.Cells[1, 5] = "Zona";
                xlWorkSheet.Cells[1, 6] = "Ora";
                xlWorkSheet.Cells[1, 7] = "Durată";
                xlWorkSheet.Cells[1, 8] = "Starsit";
                xlWorkSheet.Cells[1, 9] = "Încasare";
                xlWorkSheet.Cells[1, 10] = "Plătit";
                int row = 2;
                int col = 0;
                double total = 0;
                foreach (var interventionDetailse in interventions)
                {

                    xlWorkSheet.Cells[row, 1] = interventionDetailse.Date.ToOADate();
                    xlWorkSheet.Cells[row, 1].NumberFormat = "mm/dd/yyyy";
                    xlWorkSheet.Cells[row, 2] = interventionDetailse.PatientName;
                    xlWorkSheet.Cells[row, 3] = interventionDetailse.Location;
                    xlWorkSheet.Cells[row, 4] = interventionDetailse.Work;
                    xlWorkSheet.Cells[row, 5] = interventionDetailse.Area;
                    xlWorkSheet.Cells[row, 6] = interventionDetailse.Start.ToOADate();////interventionDetailse.Start.ToShortTimeString();
                    xlWorkSheet.Cells[row, 6].NumberFormat = "hh:mm:ss";
                    //formatRange.NumberFormat = "mm/dd/yyyy hh:mm:ss";
                    xlWorkSheet.Cells[row, 7] = interventionDetailse.Duration.TotalMinutes;//interventionDetailse.Durata.Hours+":"+interventionDetailse.Durata.Minutes;
                    xlWorkSheet.Cells[row, 8] = interventionDetailse.End.ToOADate();//interventionDetailse.End.ToShortTimeString();
                    xlWorkSheet.Cells[row, 8].NumberFormat = "hh:mm";
                    xlWorkSheet.Cells[row, 9] = interventionDetailse.Revenue;
                    xlWorkSheet.Cells[row, 10] = interventionDetailse.WasPayed ? "da" : "nu";
                    total += interventionDetailse.Revenue;
                    row++;
                }
                xlWorkSheet.Cells[row, 9] = total;
                var currentData = DateTime.Now;
                //                xlWorkBook.SaveAs("E:\\Dental Tracking System\\exportedFiles\\csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                //                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\DTS\Plati\xls\";
                //                string fileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\DTS\Plati\xls\" + currentData.Year + "_" + currentData.Month+"_"+currentData.Day +".xls";
                //                if (!Directory.Exists(path))
                //                    Directory.CreateDirectory(path);
                SaveFileDialog openDlg = new SaveFileDialog();
                var localUserInfo = XmlSerializerHelper.GetFromXml<LocalUser>(ViewConstants.appDataPath);
                openDlg.InitialDirectory = localUserInfo.SavePath;
                var currentDate = DateTime.Now;
                openDlg.FileName = currentData.Year + "_" + currentData.Month + "_" + currentData.Day + ".xls";
                DialogResult result = openDlg.ShowDialog();
                string path = openDlg.FileName;
                if (result == DialogResult.OK)
                {
                    xlWorkSheet.Columns.AutoFit();
                    xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();
                    LocalCache.Instance.LocalUser.SavePath = path;
                    MessageBox.Show("Fisierul a fost salvat. Locatie:" + path);
                }

                releaseObject(xlApp);
                releaseObject(xlWorkBook);
                releaseObject(xlWorkSheet);

            }
            catch (Exception)
            {
                MessageBox.Show("A intervenit o Eroare.Inchideti Fisierul Excel!");
            }
        }

        public static async Task ExportPatients(List<LocalPatient> localPatients)
        {
            if (localPatients.Count == 0)
            {
                MessageBox.Show("Nu exista nici un pacient nou");
                return;
            }
            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                Excel.Range chartRange;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Cells[1, 1] = "Nume";
                xlWorkSheet.Cells[1, 2] = "Prenume";
                xlWorkSheet.Cells[1, 3] = "Data Nasterii";
                xlWorkSheet.Cells[1, 4] = "Oras";
                xlWorkSheet.Cells[1, 5] = "Strada";
                xlWorkSheet.Cells[1, 6] = "Numar Strada";
                xlWorkSheet.Cells[1, 7] = "Ocupatie";
                xlWorkSheet.Cells[1, 8] = "Telefon";
                xlWorkSheet.Cells[1, 9] = "Email";
                int row = 2;
                foreach (var patient in localPatients)
                {

                    xlWorkSheet.Cells[row, 1] = patient.FirstName;
                    xlWorkSheet.Cells[row, 2] = patient.LastName;
                    xlWorkSheet.Cells[row, 3] = patient.BirthDate;
                    xlWorkSheet.Cells[row, 3].NumberFormat = "mm/dd/yyyy";
                    xlWorkSheet.Cells[row, 4] = patient.City;
                    xlWorkSheet.Cells[row, 5] = patient.Street;
                    xlWorkSheet.Cells[row, 6] = patient.StreetNumber;
                    xlWorkSheet.Cells[row, 7] = patient.Ocupation;
                    xlWorkSheet.Cells[row, 8] = patient.Phone;
                    xlWorkSheet.Cells[row, 9] = patient.Email;
                    row++;
                }
                var currentData = DateTime.Now;
                SaveFileDialog openDlg = new SaveFileDialog();
                var localUserInfo = XmlSerializerHelper.GetFromXml<LocalUser>(ViewConstants.appDataPath);
                openDlg.InitialDirectory = localUserInfo.SavePath;
                var currentDate = DateTime.Now;
                openDlg.FileName = "patients_" + currentData.Year + "_" + currentData.Month + "_" + currentData.Day + ".xls";
                DialogResult result = openDlg.ShowDialog();
                string path = openDlg.FileName;
                if (result == DialogResult.OK)
                {
                    xlWorkSheet.Columns.AutoFit();
                    xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();
                    LocalCache.Instance.LocalUser.SavePath = path;
                    DatabaseHandler.Instance.SetAsExported();
                    MessageBox.Show("Fisierul a fost salvat. Locatie:" + path);
                }

                releaseObject(xlApp);
                releaseObject(xlWorkBook);
                releaseObject(xlWorkSheet);

            }
            catch (Exception)
            {
                MessageBox.Show("A intervenit o Eroare.Inchideti Fisierul Excel!");
            }
        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
