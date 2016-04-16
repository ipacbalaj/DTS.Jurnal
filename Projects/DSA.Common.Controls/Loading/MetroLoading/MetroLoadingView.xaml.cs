using System;
using System.Windows;
using DevExpress.XtraBars.Docking2010.Base;
using Microsoft.Practices.Prism.Events;

namespace DSA.Common.Controls.Loading.MetroLoading
{
    /// <summary>
    /// Interaction logic for MetroLoadingView.xaml
    /// </summary>
    public partial class MetroLoadingView
    {
        public MetroLoadingView()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
            MetroLoadingAnimationN.Completed += OnCompleteAnimation;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            ((MetroLoadingViewModel) DataContext).MetroLoadingViewReference = this;
            StartAnimationProgramatically();
        }

        private void OnCompleteAnimation(object sender, EventArgs e)
        {
            if(DataContext!=null && ((MetroLoadingViewModel)DataContext).ShouldContinueAnimation)
            {
                MetroLoadingAnimationN.Begin();
                MetroLoadingAnimationN2.Begin();
                MetroLoadingAnimationN3.Begin();
                MetroLoadingAnimationN5.Begin();
                MetroLoadingAnimationN6.Begin();
            }
            else
            {
                StopAnimation();
              //  StartAnimationProgramatically();
            }

        }

        private void StopAnimation()
        {
            MetroLoadingAnimationN.Stop();
            MetroLoadingAnimationN2.Stop();
            MetroLoadingAnimationN3.Stop();
            MetroLoadingAnimationN5.Stop();
            MetroLoadingAnimationN6.Stop();
        }

        private void StartAnimationProgramatically()
        {
            MetroLoadingAnimationN.Begin();
            MetroLoadingAnimationN2.Begin();
            MetroLoadingAnimationN3.Begin();
            MetroLoadingAnimationN5.Begin();
            MetroLoadingAnimationN6.Begin();
        }
    }
}
