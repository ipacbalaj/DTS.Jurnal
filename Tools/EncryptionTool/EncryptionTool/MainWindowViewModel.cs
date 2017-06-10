using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EncryptionTool
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Constructor

        public MainWindowViewModel()
        {
        }

        #endregion Constructor

        #region Properties

        public  ICommand EncriptCommand { get; set; }
        public ICommand DecriptCommand { get; set; }

        private string stringToEncript;

        public string StringToEncript
        {
            get { return stringToEncript; }
            set
            {
                if (value == stringToEncript)
                    return;
                stringToEncript = value;
                OnPropertyChanged();
            }
        }

        private string encriptedString;

        public string EncriptedString
        {
            get { return encriptedString; }
            set
            {
                if (value == encriptedString)
                    return;
                encriptedString = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties


        #region Methods

        public void OnEncrypt()
        {
            EncriptedString = EncryptString(StringToEncript);
        }

        public void OnDecrypt()
        {
            EncriptedString = DecryptString(StringToEncript);
        }

        public  string DecryptString(string EncryptedText)
        {
            byte[] encryptedTextBytes = Convert.FromBase64String(EncryptedText);
            MemoryStream ms = new MemoryStream();

            System.Security.Cryptography.SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();
            byte[] rgbIV = Encoding.ASCII.GetBytes("ryojvlzffalyglrj");
            byte[] key = Encoding.ASCII.GetBytes("hcxilkqbbffffeultgbskdmaunivmfuo");

            CryptoStream cs = new CryptoStream(ms, rijn.CreateDecryptor(key, rgbIV),
                CryptoStreamMode.Write);

            cs.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
            cs.Close();

            return Encoding.UTF8.GetString(ms.ToArray());
        }

        public string EncryptString(string ClearText)
        {
            byte[] clearTextBytes = Encoding.UTF8.GetBytes(ClearText);

            System.Security.Cryptography.SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();
            MemoryStream ms = new MemoryStream();
            byte[] rgbIV = Encoding.ASCII.GetBytes("ryojvlzffalyglrj");
            byte[] key = Encoding.ASCII.GetBytes("hcxilkqbbffffeultgbskdmaunivmfuo");
            CryptoStream cs = new CryptoStream(ms, rijn.CreateEncryptor(key, rgbIV),
                CryptoStreamMode.Write);

            cs.Write(clearTextBytes, 0, clearTextBytes.Length);
            cs.Close();

            return Convert.ToBase64String(ms.ToArray());
        }	
        #endregion Methods
    }
}
