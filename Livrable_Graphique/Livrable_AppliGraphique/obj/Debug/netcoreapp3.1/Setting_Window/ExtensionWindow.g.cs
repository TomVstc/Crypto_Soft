﻿#pragma checksum "..\..\..\..\Setting_Window\ExtensionWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0317EC445ACB48FB09A94161870A2F6CAF4ED4CE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Livrable_AppliGraphique.Properties.Langs;
using Livrable_AppliGraphique.Setting_Window;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Livrable_AppliGraphique.Setting_Window {
    
    
    /// <summary>
    /// ExtensionWindow
    /// </summary>
    public partial class ExtensionWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\..\Setting_Window\ExtensionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Extention_Name;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Setting_Window\ExtensionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_submit;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Setting_Window\ExtensionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_home;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Setting_Window\ExtensionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_save;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Setting_Window\ExtensionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_setting;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.12.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Livrable_AppliGraphique;component/setting_window/extensionwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Setting_Window\ExtensionWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.12.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 25 "..\..\..\..\Setting_Window\ExtensionWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextBox_Extention_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Button_submit = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\Setting_Window\ExtensionWindow.xaml"
            this.Button_submit.Click += new System.Windows.RoutedEventHandler(this.Button_submit_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_home = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\Setting_Window\ExtensionWindow.xaml"
            this.btn_home.Click += new System.Windows.RoutedEventHandler(this.btn_home_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_save = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\..\Setting_Window\ExtensionWindow.xaml"
            this.btn_save.Click += new System.Windows.RoutedEventHandler(this.btn_save_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_setting = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\..\Setting_Window\ExtensionWindow.xaml"
            this.btn_setting.Click += new System.Windows.RoutedEventHandler(this.Button_Setting_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

