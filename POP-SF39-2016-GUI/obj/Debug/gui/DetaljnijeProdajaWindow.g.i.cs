﻿#pragma checksum "..\..\..\gui\DetaljnijeProdajaWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3F3C94D72683097360324E67BF610256F2B1C3E6"
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
using POP_SF39_2016_GUI.gui;
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
    /// DetaljnijeProdajaWindow
    /// </summary>
    public partial class DetaljnijeProdajaWindow : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\gui\DetaljnijeProdajaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbKupac;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\gui\DetaljnijeProdajaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbDatum;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\gui\DetaljnijeProdajaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbBrojRacuna;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\gui\DetaljnijeProdajaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbUkupnaCena;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\gui\DetaljnijeProdajaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgRacun;
        
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
            System.Uri resourceLocater = new System.Uri("/POP-SF39-2016-GUI;component/gui/detaljnijeprodajawindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\gui\DetaljnijeProdajaWindow.xaml"
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
            this.tbKupac = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.tbDatum = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.tbBrojRacuna = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.tbUkupnaCena = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.dgRacun = ((System.Windows.Controls.DataGrid)(target));
            
            #line 32 "..\..\..\gui\DetaljnijeProdajaWindow.xaml"
            this.dgRacun.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.IgnoreDoubleclick);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\gui\DetaljnijeProdajaWindow.xaml"
            this.dgRacun.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.Indexiranje);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

