using System;
using System.Windows.Forms;
using Limilabs.FTP.Client;
using System.Threading.Tasks;

namespace DTS.FtpConnection
{
    public static class FTPConnectionHandler
    {
        public static void DownloadFile(string ftpFolder, string ftpIP, string ftpUser, string ftpPass)
        {
            try
            {
                using (Ftp ftp = new Ftp())
                {
                    ftp.Connect(ftpIP);

                    ftp.Login(ftpUser, ftpPass);

                    ftp.ChangeFolder(ftpFolder);
                    ftp.Download("dsa.sdf", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/DTS/dsa.sdf");

                    ftp.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Baza de date nu a putut fi incărcată. Verificați conexiunea la FTP");
            }
        }

        public static async Task UploadFile(string ftpFolder, string ftpIP, string ftpUser, string ftpPass)
        {
            try
            {
                using (Ftp ftp = new Ftp())
                {
                    ftp.Connect(ftpIP);

                    ftp.Login(ftpUser, ftpPass);

                    ftp.ChangeFolder(ftpFolder);
                    ftp.Upload("dsa.sdf", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/DTS/dsa.sdf");

                    ftp.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Baza de date nu a putut fi salvată. Verificați conexiunea la FTP.!!Inainte de a reporni aplicația contactați administratorul!!!.");
            }
        }

    }
}
