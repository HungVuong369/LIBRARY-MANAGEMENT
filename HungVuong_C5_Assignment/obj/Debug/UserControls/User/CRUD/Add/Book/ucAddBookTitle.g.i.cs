﻿#pragma checksum "..\..\..\..\..\..\..\UserControls\User\CRUD\Add\Book\ucAddBookTitle.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43910493103DCEA02563E095EC900370F149F2FD"
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
    /// ucAddBookTitle
    /// </summary>
    public partial class ucAddBookTitle : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\..\..\..\..\UserControls\User\CRUD\Add\Book\ucAddBookTitle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBookTitleName;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\..\..\UserControls\User\CRUD\Add\Book\ucAddBookTitle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbCategory;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\..\..\..\UserControls\User\CRUD\Add\Book\ucAddBookTitle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSummary;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\..\..\..\UserControls\User\CRUD\Add\Book\ucAddBookTitle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\..\..\..\..\UserControls\User\CRUD\Add\Book\ucAddBookTitle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbAuthor;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\..\..\..\..\UserControls\User\CRUD\Add\Book\ucAddBookTitle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgAuthor;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\..\..\..\..\UserControls\User\CRUD\Add\Book\ucAddBookTitle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\..\..\..\..\UserControls\User\CRUD\Add\Book\ucAddBookTitle.xaml"
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
            System.Uri resourceLocater = new System.Uri("/HungVuong_C5_Assignment;component/usercontrols/user/crud/add/book/ucaddbooktitle" +
                    ".xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\UserControls\User\CRUD\Add\Book\ucAddBookTitle.xaml"
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
            this.txtBookTitleName = ((System.Windows.Controls.TextBox)(target));
            
            #line 45 "..\..\..\..\..\..\..\UserControls\User\CRUD\Add\Book\ucAddBookTitle.xaml"
            this.txtBookTitleName.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtBookTitleName_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 46 "..\..\..\..\..\..\..\UserControls\User\CRUD\Add\Book\ucAddBookTitle.xaml"
            this.txtBookTitleName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtBookTitleName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbCategory = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.txtSummary = ((System.Windows.Controls.TextBox)(target));
            
            #line 72 "..\..\..\..\..\..\..\UserControls\User\CRUD\Add\Book\ucAddBookTitle.xaml"
            this.txtSummary.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtBookTitleName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 113 "..\..\..\..\..\..\..\UserControls\User\CRUD\Add\Book\ucAddBookTitle.xaml"
            this.txtSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbAuthor = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.dgAuthor = ((System.Windows.Controls.DataGrid)(target));
            
            #line 129 "..\..\..\..\..\..\..\UserControls\User\CRUD\Add\Book\ucAddBookTitle.xaml"
            this.dgAuthor.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgAuthor_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 148 "..\..\..\..\..\..\..\UserControls\User\CRUD\Add\Book\ucAddBookTitle.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 154 "..\..\..\..\..\..\..\UserControls\User\CRUD\Add\Book\ucAddBookTitle.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

