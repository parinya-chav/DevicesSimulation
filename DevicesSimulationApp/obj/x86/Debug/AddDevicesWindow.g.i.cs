﻿#pragma checksum "..\..\..\AddDevicesWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B28B315961E22E5D4F064AF4A6277634"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace DevicesSimulationApp {
    
    
    /// <summary>
    /// AddDevicesWindow
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class AddDevicesWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\AddDevicesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridAddDevices;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\AddDevicesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbQty;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\AddDevicesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbQtyXml;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\AddDevicesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cmdCheckDefault;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\AddDevicesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSendTime;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\AddDevicesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdOK;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\AddDevicesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DevicesSimulationApp;component/adddeviceswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddDevicesWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\..\AddDevicesWindow.xaml"
            ((DevicesSimulationApp.AddDevicesWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.gridAddDevices = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.tbQty = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.tbQtyXml = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 34 "..\..\..\AddDevicesWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.titleBar_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cmdCheckDefault = ((System.Windows.Controls.CheckBox)(target));
            
            #line 36 "..\..\..\AddDevicesWindow.xaml"
            this.cmdCheckDefault.Checked += new System.Windows.RoutedEventHandler(this.cmdCheckDefault_Checked);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\AddDevicesWindow.xaml"
            this.cmdCheckDefault.Unchecked += new System.Windows.RoutedEventHandler(this.cmdCheckDefault_Unchecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tbSendTime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.cmdOK = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\AddDevicesWindow.xaml"
            this.cmdOK.Click += new System.Windows.RoutedEventHandler(this.cmdOK_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cmdCancel = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\AddDevicesWindow.xaml"
            this.cmdCancel.Click += new System.Windows.RoutedEventHandler(this.cmdCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

