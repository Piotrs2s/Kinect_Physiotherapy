﻿#pragma checksum "..\..\BaloonsDifficultyLevelPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5471580E4DE1225F1BD69AD51894FACB588E67BA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KinectPhysiotherapy;
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


namespace KinectPhysiotherapy {
    
    
    /// <summary>
    /// BaloonsDifficultyLevelPage
    /// </summary>
    public partial class BaloonsDifficultyLevelPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\BaloonsDifficultyLevelPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button baloons_veryEasyButton;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\BaloonsDifficultyLevelPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button baloons_easyButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\BaloonsDifficultyLevelPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button baloons_mediumButton;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\BaloonsDifficultyLevelPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button baloons_hardButton;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\BaloonsDifficultyLevelPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame Main;
        
        #line default
        #line hidden
        
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
            System.Uri resourceLocater = new System.Uri("/KinectPhysiotherapy;component/baloonsdifficultylevelpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\BaloonsDifficultyLevelPage.xaml"
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
            this.baloons_veryEasyButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\BaloonsDifficultyLevelPage.xaml"
            this.baloons_veryEasyButton.Click += new System.Windows.RoutedEventHandler(this.baloons_veryEasyButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.baloons_easyButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\BaloonsDifficultyLevelPage.xaml"
            this.baloons_easyButton.Click += new System.Windows.RoutedEventHandler(this.baloons_easyButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.baloons_mediumButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\BaloonsDifficultyLevelPage.xaml"
            this.baloons_mediumButton.Click += new System.Windows.RoutedEventHandler(this.baloons_mediumButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.baloons_hardButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\BaloonsDifficultyLevelPage.xaml"
            this.baloons_hardButton.Click += new System.Windows.RoutedEventHandler(this.baloons_hardButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Main = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

