   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      -    'HungVuong_C5_Assignment.ucChildDataGrid   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��dgChildInfo��5
          AutoGenerateColumns  .     
IsReadOnly .    SelectionMode$ Single=�5   )      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Reader ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *
IdReader+  5      $ 	Full Name��6%    68   �� *
FullName+  5      $	 BoF��6%    62   �� *BoF+ �� StringFormat$ 
dd/MM/yyyy��  5      $ Reader Type��6%    6:   �� *
ReaderType+  5      $ 
Created At��6%    69   �� *	CreatedAt+$ 
dd/MM/yyyy��  5      $ Modified At��6%    6:   �� *
ModifiedAt+$ 
dd/MM/yyyy��5      5      5      