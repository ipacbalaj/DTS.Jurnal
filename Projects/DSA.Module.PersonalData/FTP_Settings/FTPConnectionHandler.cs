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
            using (Ftp ftp = new Ftp())
            {
                ftp.Connect("109.102.28.238");

                ftp.Login("ipacbalaj", "pbi");

                ftp.ChangeFolder("test/DTS");
                ftp.Download("dsa.sdf", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/DTS/dsa.sdf");

                ftp.Close();
            }
        }

        public static void DownloadFile4()
        {
            String RemoteFtpPath = "ftp://109.102.28.238/test/DTS/dsa.sdf";
            String LocalDestinationPath = @"C:\Users\Pac-Balaj ionutzela2\Desktop\NB\test.dsa";
            String Username = "ipacbalaj";
            String Password = "pbi";
            Boolean UseBinary = true; // use true for .zip file or false for a text file
            Boolean UsePassive = false;

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(RemoteFtpPath);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.KeepAlive = true;
            request.Timeout = -1;
            request.UsePassive = UsePassive;
            request.UseBinary = UseBinary;

            request.Credentials = new NetworkCredential(Username, Password);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            using (FileStream writer = new FileStream(LocalDestinationPath, FileMode.Create))
            {

                long length = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[2048];

                readCount = responseStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    writer.Write(buffer, 0, readCount);
                    readCount = responseStream.Read(buffer, 0, bufferSize);
                }
            }

            reader.Close();
            response.Close();
        }

        public static void DownloadFile(string userName, string password, string ftpSourceFilePath, string localDestinationFilePath)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[2048];

            FtpWebRequest request = CreateFtpWebRequest(ftpSourceFilePath, userName, password, true);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            Stream reader = request.GetResponse().GetResponseStream();
            FileStream fileStream = new FileStream(localDestinationFilePath, FileMode.Create);

            while (true)
            {
                bytesRead = reader.Read(buffer, 0, buffer.Length);

                if (bytesRead == 0)
                    break;

                fileStream.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();
        }

        private static FtpWebRequest CreateFtpWebRequest(string ftpDirectoryPath, string userName, string password, bool keepAlive = false)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(ftpDirectoryPath));

            //Set proxy to null. Under current configuration if this option is not set then the proxy that is used will get an html response from the web content gateway (firewall monitoring system)
            request.Proxy = null;

            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = keepAlive;

            request.Credentials = new NetworkCredential(userName, password);

            return request;
        }


        //Connects to the FTP server and downloads the file
        public static void downloadFile(string FTPAddress, string filename, string username, string password)
        {

            byte[] downloadedData = new byte[0];

            try
            {
                //Create FTP request
                //Note: format is ftp://server.com/file.ext
                FtpWebRequest request = FtpWebRequest.Create(FTPAddress + "/" + filename) as FtpWebRequest;


                //Get the file size first (for progress bar)
                request.Method = WebRequestMethods.Ftp.GetFileSize;
                request.Credentials = new NetworkCredential(username, password);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true; //don't close the connection

                int dataLength = (int)request.GetResponse().ContentLength;

                //Now get the actual data
                request = FtpWebRequest.Create(FTPAddress + "/" + filename) as FtpWebRequest;
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(username, password);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = false; //close the connection when done

                //Streams
                FtpWebResponse response = request.GetResponse() as FtpWebResponse;
                Stream reader = response.GetResponseStream();

                //Download to memory
                //Note: adjust the streams here to download directly to the hard drive
                MemoryStream memStream = new MemoryStream();
                byte[] buffer = new byte[1024]; //downloads in chuncks

                while (true)
                {

                    //Try to read the data
                    int bytesRead = reader.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        break;
                    }
                    else
                    {
                        //Write the downloaded data
                        memStream.Write(buffer, 0, bytesRead);

                    }
                }

                //Convert the downloaded stream to a byte array
                downloadedData = memStream.ToArray();

                //Clean up
                reader.Close();
                memStream.Close();
                response.Close();

                MessageBox.Show("Downloaded Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error connecting to the FTP Server.");
            }

            username = string.Empty;
            password = string.Empty;
        }

        public static void DownloadWithFTPLibrary()
        {
            using (FtpConnection ftp = new FtpConnection("109.102.28.238", "ipacbalaj", "pbi"))
            {

                ftp.Open(); /* Open the FTP connection */
                ftp.Login(); /* Login using previously provided credentials */


                if (ftp.DirectoryExists("/test/DTS")) /* check that a directory exists */
                    ftp.SetCurrentDirectory("/test/DTS"); /* change current directory */

                if (ftp.FileExists("/test/DTS/dsa.sdf"))  /* check that a file exists */
                    ftp.GetFile("/test/DTS/dsa.sdf", false); /* download /incoming/file.txt as file.txt to current executing directory, overwrite if it exists */


                //                if (ftp.DirectoryExists("/test/DTS"))
                //                    /* check that a directory exists */
                //                {
                ////                    ftp.SetCurrentDirectory("/DTS"); /* change current directory */{}
                //                }
                //
                ////                ftp.CreateDirectory("/test/DTS/ionut");
                //
                //                if (ftp.FileExists("/test/DTS/dsa.sdf"))  /* check that a file exists */
                //                    ftp.GetFile("/test/DTS/dsa.sdf", @"C:\Users\Pac-Balaj ionutzela2\Desktop\NB\",false);

                //do some processing

                //                try
                //                {
                //                    ftp.SetCurrentDirectory("/outgoing");
                //                    ftp.PutFile(@"c:\localfile.txt", "file.txt"); /* upload c:\localfile.txt to the current ftp directory as file.txt */
                //                }
                //                catch (FtpException e)
                //                {
                //                    Console.WriteLine(String.Format("FTP Error: {0} {1}", e.ErrorCode, e.Message));
                //                }
                //
                //                foreach (var dir in ftp.GetDirectories("/incoming/processed"))
                //                {
                //                    Console.WriteLine(dir.Name);
                //                    Console.WriteLine(dir.CreationTime);
                //                    foreach (var file in dir.GetFiles())
                //                    {
                //                        Console.WriteLine(file.Name);
                //                        Console.WriteLine(file.LastAccessTime);
                //                    }
                //                }
            }
        }

    }
}
