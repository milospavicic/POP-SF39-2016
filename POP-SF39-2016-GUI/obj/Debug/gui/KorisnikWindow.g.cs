﻿#pragma checksum "..\..\..\gui\KorisnikWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0AFED5631A83C1EA57C3D688B17650834A9648E5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using POP_SF39_2016_GUI;
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


namespace POP_SF39_2016_GUI.gui {
    
    
    /// <summary>
    /// KorisnikWindow
    /// </summary>
    public partial class KorisnikWindow : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\gui\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbIme;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\gui\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPrezime;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\gui\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbKorisnickoIme;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\gui\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSifra;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\gui\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPozicija;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\gui\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSnimi;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\gui\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIzadji;
        
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
            System.Uri resourceLocater = new System.Uri("/POP-SF39-2016-GUI;component/gui/korisnikwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\gui\KorisnikWindow.xaml"
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
            this.tbIme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbPrezime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbKorisnickoIme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbSifra = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cbPozicija = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.btnSnimi = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\gui\KorisnikWindow.xaml"
            this.btnSnimi.Click += new System.Windows.RoutedEventHandler(this.SacuvajIzmene);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnIzadji = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\..\gui\KorisnikWindow.xaml"
            this.btnIzadji.Click += new System.Windows.RoutedEventHandler(this.ZatvoriWindow);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

