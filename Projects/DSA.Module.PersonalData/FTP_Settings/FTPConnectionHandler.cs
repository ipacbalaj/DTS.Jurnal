using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FtpLib;
using Limilabs.FTP.Client;
using FtpException = Limilabs.FTP.Client.FtpException;

namespace DSA.Module.PersonalData.FTP_Settings
{
    public static class FTPConnectionHandler
    {
        public static void CreateRequest()
        {
            string localPath = @"C:\Users\Pac-Balaj ionutzela2\Desktop\NB\dsa.sdf";

            FtpWebRequest requestFileDownload = (FtpWebRequest)WebRequest.Create("ftp://109.102.28.238/test/DTS/dsa.sdf");
            requestFileDownload.Credentials = new NetworkCredential("ipacbalaj", "pbi");
            requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;
            requestFileDownload.UsePassive = true;
            requestFileDownload.KeepAlive = true;
            requestFileDownload.UseBinary = true;
            FtpWebResponse responseFileDownload = (FtpWebResponse)requestFileDownload.GetResponse();

            Stream responseStream = responseFileDownload.GetResponseStream();
            FileStream writeStream = new FileStream(localPath, FileMode.Create);

            int Length = 4000;
            Byte[] buffer = new Byte[Length];
            int bytesRead = responseStream.Read(buffer, 0, Length);

            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = responseStream.Read(buffer, 0, Length);
            }

            responseStream.Close();
            writeStream.Close();





            //            Debug.WriteLine("Download Complete, status {0}", response.StatusDescription);


            //            string inputfilepath = @"C:\Users\Pac-Balaj ionutzela2\Desktop\NB";
            //            string ftphost = "109.102.28.238";
            //            string ftpfilepath = "/test/DTS/dsa.sdf";
            //
            //            string ftpfullpath = "ftp://" + ftphost + ftpfilepath;
            //
            //            using (WebClient request = new WebClient())
            //            {
            //                request.Credentials = new NetworkCredential("ipacbalaj", "pbi");
            //                byte[] fileData = request.DownloadData(ftpfullpath);
            //
            //                using (FileStream file = File.Create(inputfilepath))
            //                {
            //                    file.Write(fileData, 0, fileData.Length);
            //                    file.Close();
            //                }
            //                MessageBox.Show("Download Complete");
            //            }
        }

        public static void DownloadFile()
        {
            try
            {
                using (Ftp ftp = new Ftp())
                {
                    ftp.Connect("109.102.28.238");

                    ftp.Login("ipacbalaj", "pbi");

                    ftp.ChangeFolder("test/DTS");
                    ftp.Download("dsa.sdf", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/DTS/dsa.sdf");

                    ftp.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Baza de date nu a putut fi incărcată. Verificați conexiunea la FTP");
            }
        }

        public static void UploadFile()
        {
            try
            {
                using (Ftp ftp = new Ftp())
                {
                    ftp.Connect("109.102.28.238");

                    ftp.Login("ipacbalaj", "pbi");

                    ftp.ChangeFolder("test/DTS");
                    ftp.Upload("dsa.sdf", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/DTS/dsa.sdf");

                    ftp.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Baza de date nu a putut fi salvată. Verificați conexiunea la FTP");
            }          
        }

    }
}
