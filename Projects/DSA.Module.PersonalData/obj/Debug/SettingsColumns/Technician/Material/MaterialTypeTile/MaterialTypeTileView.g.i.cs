﻿#pragma checksum "..\..\..\..\..\..\SettingsColumns\Technician\Material\MaterialTypeTile\MaterialTypeTileView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D0869B515C07CDBFC712CE1929522F30"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DSA.Common.Controls.Buttons;
using DSA.Common.Controls.Buttons.SymbolButton;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace DSA.Module.PersonalData.SettingsColumns.Technician.Material.MaterialTypeTile {
    
    
    /// <summary>
    /// MaterialTypeTileView
    /// </summary>
    public partial class MaterialTypeTileView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DSA.Module.PersonalData;component/settingscolumns/technician/material/materialty" +
                    "petile/materialtypetileview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\SettingsColumns\Technician\Material\MaterialTypeTile\MaterialTypeTileView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\..\..\SettingsColumns\Technician\Material\MaterialTypeTile\MaterialTypeTileView.xaml"
            ((System.Windows.Controls.Border)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.UIElement_OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\..\..\..\SettingsColumns\Technician\Material\MaterialTypeTile\MaterialTypeTileView.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.UIElement_OnMouseLeave);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 21 "..\..\..\..\..\..\SettingsColumns\Technician\Material\MaterialTypeTile\MaterialTypeTileView.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Name_OnMouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 24 "..\..\..\..\..\..\SettingsColumns\Technician\Material\MaterialTypeTile\MaterialTypeTileView.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Cost_OnMouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 28 "..\..\..\..\..\..\SettingsColumns\Technician\Material\MaterialTypeTile\MaterialTypeTileView.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.deleteIcon_OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 28 "..\..\..\..\..\..\SettingsColumns\Technician\Material\MaterialTypeTile\MaterialTypeTileView.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.deleteIcon_OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 28 "..\..\..\..\..\..\SettingsColumns\Technician\Material\MaterialTypeTile\MaterialTypeTileView.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.deleteIcon_OnMouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

