   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5    /HungVuong_C5_Assignment.ucPenaltyReasonDataGrid   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     .���   � RowDefinitions  �� $��* ��� $
��auto �.+�&   System.Windows.Controls.DataGrid  -   $��dgPenaltyReasons��   AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=� �� SelectedItem �� *SelectedPenaltyReason+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $
 Name�� �� *Name+  $ Description��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200  �� *Description+  $ Price�� �� *Price+  $ 
Created At�� �� *	CreatedAt+	 �� StringFormat$	 
dd/MM/yyyy��  $ Modified At�� �� *
ModifiedAt+$	 
dd/MM/yyyy��4  .System.Windows.Controls.DataGridTemplateColumn  $ Action��
   CellTemplate
 �� .R��� $��	btnUpdate��$��Update��$	��100��$
��10 0q�$��20��   ButtonBasicStyle#��[  
��� ���
����  �
 � Tag �� ���� *DataContext.UpdateCommand+ �� RelativeSource ��  �� AncestorType"    $ Action��
 �� .R��� $��	btnDelete��$��Delete��$	��100��$��20��$
��10 0q�  ButtonDeleteStyle#��[  �� ���� *DataContext.DeleteCommand+ �� "  (   "HungVuong_C5_Assignment.Pagination  -     Name$ 
pagination��$��1��$��45��