﻿#pragma checksum "..\..\..\..\Save_Window\ServerManagerWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A25ED5DB3CFDF5AE809FE95F1156846C0BE99048"
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
using Livrable_AppliGraphique.Save_Window;
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


namespace Livrable_AppliGraphique.Save_Window {
    
    
    /// <summary>
    /// ServerManagerWindow
    /// </summary>
    public partial class ServerManagerWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Save_Window\ServerManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar progress_barre;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Save_Window\ServerManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SaveProgressionWindow;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Save_Window\ServerManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Break_Button;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Save_Window\ServerManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Restart_Button;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Save_Window\ServerManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit_Button;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Save_Window\ServerManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label stateSave;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Save_Window\ServerManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label pourcentageLaben;
        
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
            System.Uri resourceLocater = new System.Uri("/Livrable_AppliGraphique;V1.0.0.0;component/save_window/servermanagerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Save_Window\ServerManagerWindow.xaml"
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
            this.progress_barre = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 2:
            this.SaveProgressionWindow = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.Break_Button = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\Save_Window\ServerManagerWindow.xaml"
            this.Break_Button.Click += new System.Windows.RoutedEventHandler(this.Break_Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Restart_Button = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\Save_Window\ServerManagerWindow.xaml"
            this.Restart_Button.Click += new System.Windows.RoutedEventHandler(this.Restart_Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Exit_Button = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\Save_Window\ServerManagerWindow.xaml"
            this.Exit_Button.Click += new System.Windows.RoutedEventHandler(this.Exit_Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.stateSave = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.pourcentageLaben = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

