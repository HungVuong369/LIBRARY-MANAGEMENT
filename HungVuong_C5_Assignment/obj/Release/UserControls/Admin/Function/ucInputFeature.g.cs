﻿#pragma checksum "..\..\..\..\..\UserControls\Admin\Function\ucInputFeature.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F88156C283EB581A6C09E3B385FBCE7C9EF6FC72"
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
    /// ucInputFeature
    /// </summary>
    public partial class ucInputFeature : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\..\UserControls\Admin\Function\ucInputFeature.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\UserControls\Admin\Function\ucInputFeature.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescription;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\..\UserControls\Admin\Function\ucInputFeature.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtParent;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\..\UserControls\Admin\Function\ucInputFeature.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelect;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\..\UserControls\Admin\Function\ucInputFeature.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUrlImage;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\..\UserControls\Admin\Function\ucInputFeature.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgFeature;
        
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
            System.Uri resourceLocater = new System.Uri("/HungVuong_C5_Assignment;component/usercontrols/admin/function/ucinputfeature.xam" +
                    "l", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\UserControls\Admin\Function\ucInputFeature.xaml"
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
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\..\..\..\UserControls\Admin\Function\ucInputFeature.xaml"
            this.txtName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtDescription = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\..\..\..\UserControls\Admin\Function\ucInputFeature.xaml"
            this.txtDescription.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtParent = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnSelect = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\..\..\UserControls\Admin\Function\ucInputFeature.xaml"
            this.btnSelect.Click += new System.Windows.RoutedEventHandler(this.btnSelect_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtUrlImage = ((System.Windows.Controls.TextBox)(target));
            
            #line 77 "..\..\..\..\..\UserControls\Admin\Function\ucInputFeature.xaml"
            this.txtUrlImage.GotFocus += new System.Windows.RoutedEventHandler(this.txtUrlImage_GotFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.imgFeature = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
