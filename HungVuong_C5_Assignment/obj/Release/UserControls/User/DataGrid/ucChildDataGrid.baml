   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  -    'HungVuong_C5_Assignment.ucChildDataGrid   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     .��� .+�&   System.Windows.Controls.DataGrid  -   $��dgChildInfo��    AutoGenerateColumns  .     
IsReadOnly .    SelectionMode$ Single=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	Reader ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
IdReader+  $ 	Full Name�� �� *
FullName+  $	 BoF�� �� *BoF+ �� StringFormat$ 
dd/MM/yyyy��  $ Reader Type�� �� *
ReaderType+  $ 
Created At�� �� *	CreatedAt+$ 
dd/MM/yyyy��  $ Modified At�� �� *
ModifiedAt+$ 
dd/MM/yyyy��