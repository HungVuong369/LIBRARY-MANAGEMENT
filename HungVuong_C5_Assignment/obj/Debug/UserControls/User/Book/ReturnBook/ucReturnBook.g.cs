﻿#pragma checksum "..\..\..\..\..\..\UserControls\User\Book\ReturnBook\ucReturnBook.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E4E9BACE1D9BAB0F7A1E3E855AC865DB7F90825A"
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
using System.Windows.Interactivity;
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
    /// ucReturnBook
    /// </summary>
    public partial class ucReturnBook : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 62 "..\..\..\..\..\..\UserControls\User\Book\ReturnBook\ucReturnBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtReaderID;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\..\..\UserControls\User\Book\ReturnBook\ucReturnBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbReaderID;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\..\..\..\..\UserControls\User\Book\ReturnBook\ucReturnBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HungVuong_C5_Assignment.ucLoanSlipDataGrid ucLoanSlipDataGrid;
        
        #line default
        #line hidden
        
        
        #line 354 "..\..\..\..\..\..\UserControls\User\Book\ReturnBook\ucReturnBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrice;
        
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
            System.Uri resourceLocater = new System.Uri("/HungVuong_C5_Assignment;component/usercontrols/user/book/returnbook/ucreturnbook" +
                    ".xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\UserControls\User\Book\ReturnBook\ucReturnBook.xaml"
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
            this.txtReaderID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.cbReaderID = ((System.Windows.Controls.ComboBox)(target));
            
            #line 77 "..\..\..\..\..\..\UserControls\User\Book\ReturnBook\ucReturnBook.xaml"
            this.cbReaderID.DropDownClosed += new System.EventHandler(this.cbReaderID_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ucLoanSlipDataGrid = ((HungVuong_C5_Assignment.ucLoanSlipDataGrid)(target));
            return;
            case 4:
            this.txtPrice = ((System.Windows.Controls.TextBox)(target));
            
            #line 358 "..\..\..\..\..\..\UserControls\User\Book\ReturnBook\ucReturnBook.xaml"
            this.txtPrice.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtPrice_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 359 "..\..\..\..\..\..\UserControls\User\Book\ReturnBook\ucReturnBook.xaml"
            this.txtPrice.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtPrice_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

