﻿#pragma checksum "..\..\..\..\..\..\..\UserControls\Admin\Function\CRUD\DeleteFeature\ucConfirmDeleteFeature.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3BA52195F02EA86B66B1E1AC6C7DA582869F7EAB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HungVuong_C5_Assignment;
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


namespace HungVuong_C5_Assignment {
    
    
    /// <summary>
    /// ucConfirmDeleteFeature
    /// </summary>
    public partial class ucConfirmDeleteFeature : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\..\..\..\UserControls\Admin\Function\CRUD\DeleteFeature\ucConfirmDeleteFeature.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblConfirm;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\..\..\UserControls\Admin\Function\CRUD\DeleteFeature\ucConfirmDeleteFeature.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblListFunction;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\..\..\UserControls\Admin\Function\CRUD\DeleteFeature\ucConfirmDeleteFeature.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HungVuong_C5_Assignment.ucFunctionDataGrid ucFunctionDataGrid;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\..\..\UserControls\Admin\Function\CRUD\DeleteFeature\ucConfirmDeleteFeature.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirm;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\..\..\UserControls\Admin\Function\CRUD\DeleteFeature\ucConfirmDeleteFeature.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/HungVuong_C5_Assignment;component/usercontrols/admin/function/crud/deletefeature" +
                    "/ucconfirmdeletefeature.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\UserControls\Admin\Function\CRUD\DeleteFeature\ucConfirmDeleteFeature.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.lblConfirm = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lblListFunction = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.ucFunctionDataGrid = ((HungVuong_C5_Assignment.ucFunctionDataGrid)(target));
            return;
            case 4:
            this.btnConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\..\..\..\UserControls\Admin\Function\CRUD\DeleteFeature\ucConfirmDeleteFeature.xaml"
            this.btnConfirm.Click += new System.Windows.RoutedEventHandler(this.btnConfirm_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\..\..\..\UserControls\Admin\Function\CRUD\DeleteFeature\ucConfirmDeleteFeature.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

