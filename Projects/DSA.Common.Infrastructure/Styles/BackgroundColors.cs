using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DSA.Common.Infrastructure.Styles
{
    public static class BackgroundColors
    {
        public static Brush red = new SolidColorBrush(Colors.Red);
        public static Brush orange = new SolidColorBrush(Colors.Orange);
        public static Brush blue = new SolidColorBrush(Colors.Blue);
        public static Brush lightblue = new SolidColorBrush(Colors.LightBlue);
        public static Brush dark = new SolidColorBrush(Colors.Black);
        public static Brush gray = new SolidColorBrush(Colors.DarkGray);
        public static Brush green = new SolidColorBrush(Colors.ForestGreen);
        public static Brush whiteSmoke =new SolidColorBrush(Colors.WhiteSmoke);

        public static Brush MonthTileColor = new SolidColorBrush(Color.FromRgb(181, 217, 238));
        public static Brush MonthTileColorMouseOver = new SolidColorBrush(Color.FromRgb(155, 198, 192));

        public static Brush YearTileColor = new SolidColorBrush(Color.FromRgb(110, 164, 195));
        public static Brush YearTileColorMouseOver = new SolidColorBrush(Color.FromRgb(87, 154, 223));

        public static Brush closeColor = new SolidColorBrush(Colors.Red);
        public static Brush openColor = new SolidColorBrush(Colors.Orange);
        public static Brush textColor = new SolidColorBrush(Colors.Blue);
        //public static Brush testColor = new SolidColorBrush(Colors.Aqua);
        public static Brush testColor = new SolidColorBrush(Color.FromRgb(210, 208, 208));
        public static Brush titleBackgroundColor = new SolidColorBrush(Color.FromRgb(111, 111, 111));
        public static Brush mouseOffColor = new SolidColorBrush(Color.FromRgb(67, 77, 89));
        public static Brush mouseOnColor = new SolidColorBrush(Color.FromRgb(96, 96, 96));
        public static Brush noColor = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        public static Brush searchBackground = new SolidColorBrush(Color.FromRgb(67, 77, 89));
        public static Brush tabMouseOnColor = new SolidColorBrush(Color.FromRgb(0, 122, 252));

        public static Brush titleForeground = new SolidColorBrush(Color.FromRgb(30, 58, 93));
        public static Brush statusBackgroundColor = new SolidColorBrush(Color.FromRgb(117, 117, 117));
        //public static Brush pinDesactivated = new SolidColorBrush(Color.FromRgb(176,176,176));
        public static Brush addInformationTitleCompleted = new SolidColorBrush(Colors.LightGray);
        public static Brush addInformationTitleUncompleted = new SolidColorBrush(Color.FromArgb(0xFF, 0x64, 0x9A, 0xCF));
        public static Brush addInformationTitleCurrent = new SolidColorBrush(Colors.Orange);
        public static Brush defaultBackground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        public static Brush tabletButtonBackgroundOn = new SolidColorBrush(Color.FromArgb(0xFF, 0x14, 0x20, 0x2F));
        public static Brush tabletButtonBackgroundOff = new SolidColorBrush(Color.FromArgb(0xFF, 0x64, 0x9A, 0xCF));
        public static Brush fullStarColor = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        public static Brush partialStarColor = new SolidColorBrush(Color.FromRgb(0, 0, 255));

        // new color scheme
        public static Brush SuccessfulColor = new SolidColorBrush(Colors.SeaGreen);
        public static Brush UnsuccessfulColor = new SolidColorBrush(Colors.OrangeRed);

        public static Brush ButtonMouseOnColor = new SolidColorBrush(Color.FromRgb(255, 130, 10));
        public static Brush ButtonMouseOffColor = new SolidColorBrush(Color.FromRgb(50, 50, 50));
        public static Brush ButtonUnenable = new SolidColorBrush(Colors.LightGray);

        public static Brush TextUnenable = new SolidColorBrush(Colors.DarkGray);

        public static Brush BackgroundDarkColor = new SolidColorBrush(Color.FromRgb(30, 30, 30));
        public static Brush BackgroundMediumColor = new SolidColorBrush(Color.FromRgb(70, 70, 70));
        public static Brush BackgroundLightColor = new SolidColorBrush(Color.FromRgb(150, 150, 150));
        public static Brush BackgroundLightestColor = new SolidColorBrush(Color.FromRgb(220, 220, 220));
        public static Brush BackgroundLightOrangeColor = new SolidColorBrush(Color.FromRgb(255, 180, 10));

        public static Brush BackgroundPartFilled = new SolidColorBrush(Color.FromRgb(255, 180, 10));//255, 96, 22
        public static Brush BackgroundFilled = new SolidColorBrush(Color.FromRgb(50, 205, 50));
        public static Brush BackgroundRejected = new SolidColorBrush(Color.FromRgb(245, 160, 135));
        public static Brush BackgroundPending = new SolidColorBrush(Color.FromRgb(229, 255, 182));
        public static Brush BackgroundRepeating = new SolidColorBrush(Color.FromRgb(220, 255, 255));

        public static Brush BackgroundActiveColumn = new SolidColorBrush(Color.FromArgb(0xFF, 0x64, 0x9A, 0xCF));
        public static Brush BackgroundLightBlueColor = new SolidColorBrush(Color.FromRgb(0, 122, 252));
        public static Brush DescriptionValueForeground = new SolidColorBrush(Colors.DarkSlateGray);

        public static Brush White = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        public static Brush Black = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        public static Brush Transparent = new SolidColorBrush(Colors.Transparent);

        //grid 
        public static Brush GridInterventionRowColor = new SolidColorBrush(Color.FromRgb(240, 250, 255));

        //filters
        public static Brush ActiveFilter = new SolidColorBrush(Color.FromRgb(204, 235, 204));
        public static Brush InactiveFilter = new SolidColorBrush(Color.FromRgb(255, 232, 226));        

        //tab and background        
        public static Brush JurnalColor = new SolidColorBrush(Color.FromRgb(216, 240, 240));
        public static Brush FiltersColor = new SolidColorBrush(Color.FromRgb(240, 209, 224));
        public static Brush SettingsColor = new SolidColorBrush(Color.FromRgb(184, 184, 212 ));
        public static Brush FinancialColor = new SolidColorBrush(Color.FromRgb(255, 255, 204));
        public static Brush PersonalInfoColor = new SolidColorBrush(Color.FromRgb(240, 209, 178));       
        
        //fisa pacient
        public static Brush DatePersonaleColor = new SolidColorBrush(Color.FromRgb(196, 167, 137));
        public static Brush PatientsListColor = new SolidColorBrush(Color.FromRgb(255, 194, 102));
        public static Brush PatientsListColorOver = new SolidColorBrush(Color.FromRgb(255, 153, 0));
        //filtre
        public static Brush FiltreTitlu = new SolidColorBrush(Color.FromRgb(220, 131, 176));
        public static Brush FiltreTitluMouseOn = new SolidColorBrush(Color.FromRgb(197, 48, 123));
        //grid        
        public static Brush GridNotPayedColor = new SolidColorBrush(Color.FromRgb(255, 226, 226));

        //tecnician tile
        public static Brush TechnicianTile = new SolidColorBrush(Color.FromRgb(197, 197, 220));
        public static Brush TechnicianTileMouseOn = new SolidColorBrush(Color.FromRgb(243, 243, 248));

        //interventions 194, 240, 194
        public static Brush InterventionCurrentInterval = new SolidColorBrush(Color.FromRgb(194, 240, 194));

        //material tile
        public static Brush MaterialTileMouseOn = new SolidColorBrush(Color.FromRgb(243, 243, 248));
        public static Brush MaterialTileMouseOff = new SolidColorBrush(Color.FromRgb(197, 197, 220));

        //
        public static Brush SettingsMenuColor = new SolidColorBrush(Color.FromRgb(255, 224, 224));

        public static Brush AddInterventionTileColor = new SolidColorBrush(Color.FromRgb(194, 216, 216));
    }
}
