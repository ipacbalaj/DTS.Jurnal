using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Common.Infrastructure
{
    public static class ImagePath
    {
        //tabs icons
        public static string GeneralPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                           @"\DTS\icons\";

        public static string PacientiIconPath = GeneralPath + "_SUS_pacienti.png";
        public static string FiltrareIconPath = GeneralPath + "_SUS_filtrare.png";
        public static string RapoarteIconPath = GeneralPath + "_SUS_rapoarte.png";
        public static string SetariIconPath = GeneralPath + "_SUS_setari.png";
        public static string FisaPacientIconPath = GeneralPath + "_SUS_fisa_pacient.png";
        public static string ContabiliitateIconPath = GeneralPath + "_SUS_contabilitate.png";
        public static string DentistProfile = GeneralPath + "_SUS_profil_dentist.png";
        public static string SigleIconPath = GeneralPath + "SIGLA_MICA.jpg";

        //icons
        public static string SaveIconPath = GeneralPath + "pacient adaugat.png";
        public static string CancelIconPath = GeneralPath + "anulare introducere pacient.png";
        public static string PatientEditPath = GeneralPath + "edit pacient.png";
        public static string ShowFilters = GeneralPath + "afiseaza filtre.png";
        public static string GenerateWord = GeneralPath + "generare word.png";
        public static string Location = GeneralPath + "locatie.png";
        public static string Work = GeneralPath + "manopere.png";
        public static string AddFilter = GeneralPath + "adauga filtre.png";
        public static string AddPatientPath = GeneralPath + "adaugare pacient.png";
        public static string Materiale = GeneralPath + "materiale.png";
        public static string Zona = GeneralPath + "zona.png";
        public static string PatientSeadch = GeneralPath + "Patient Boy 2 Search.png";
        public static string Present = GeneralPath + "present.png";

    }
}
