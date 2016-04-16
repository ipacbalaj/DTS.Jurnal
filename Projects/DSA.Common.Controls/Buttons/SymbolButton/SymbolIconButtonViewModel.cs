using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;

namespace DSA.Common.Controls.Buttons.SymbolButton
{
   public class SymbolIconButtonViewModel:ViewModelBase
    {
       #region Constructor

       public SymbolIconButtonViewModel(ICommand receivedCommand,string symbol)
       {
           ButtonCommand = receivedCommand;
           Symbol = symbol;
       }

       #endregion Constructor

       #region Properties

       public SymbolIconButtonView ViewReference { get; set; }

       public ICommand ButtonCommand { get; set; }

       private string symbol;

       public string Symbol
       {
           get { return symbol; }
           set
           {
               if (value == symbol)
                   return;
               symbol = value;
               OnPropertyChanged();
           }
       }

       private Brush symbolColor=BackgroundColors.Black;
       public Brush SymbolColor
       {
           get { return symbolColor; }
           set
           {
               if (value == symbolColor)
                   return;
               symbolColor = value;
               OnPropertyChanged();
           }
       }

       #endregion Properties

       #region Methods

       public void MouseOn()
       {
           SymbolColor = BackgroundColors.red;
       }

       public void MouseOff()
       {
           SymbolColor = BackgroundColors.Black;
       }

       #endregion Methods
    }
}
