﻿#pragma checksum "..\..\..\..\..\..\UserControls\User\Management\Book\LoanHistoryManagement.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8936707F2A158679AF21D2F1E09EA6DBF7D43F16"
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
    /// LoanHistoryManagement
    /// </summary>
    public partial class LoanHistoryManagement : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\..\..\UserControls\User\Management\Book\LoanHistoryManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbTabMenu;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\..\UserControls\User\Management\Book\LoanHistoryManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdContainView;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\..\..\UserControls\User\Management\Book\LoanHistoryManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\..\UserControls\User\Management\Book\LoanHistoryManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HungVuong_C5_Assignment.ucLoanHistoryDataGrid ucLoanHistory;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\..\UserControls\User\Management\Book\LoanHistoryManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HungVuong_C5_Assignment.ucReturnBook ucReturnBook;
        
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
            System.Uri resourceLocater = new System.Uri("/HungVuong_C5_Assignment;component/usercontrols/user/management/book/loanhistorym" +
                    "anagement.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\UserControls\User\Management\Book\LoanHistoryManagement.xaml"
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
            this.lbTabMenu = ((System.Windows.Controls.ListBox)(target));
            
            #line 23 "..\..\..\..\..\..\UserControls\User\Management\Book\LoanHistoryManagement.xaml"
            this.lbTabMenu.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbTabMenu_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grdContainView = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\..\..\..\..\UserControls\User\Management\Book\LoanHistoryManagement.xaml"
            this.txtSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ucLoanHistory = ((HungVuong_C5_Assignment.ucLoanHistoryDataGrid)(target));
            return;
            case 5:
            this.ucReturnBook = ((HungVuong_C5_Assignment.ucReturnBook)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
