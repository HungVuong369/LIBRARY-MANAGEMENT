   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  3    -HungVuong_C5_Assignment.ucLoanHistoryDataGrid   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment       � 	Resources  2   ,HungVuong_C5_Assignment.ExpiredDateConverter   ConvertExpiredDate��%   &	          .���  � RowDefinitions �� �� $
��auto �.+�&   System.Windows.Controls.DataGrid  -   $��dgLoanHistories��   AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $ 
Created By�� �� *User.Username+  $ 	Reader ID�� �� *
IdReader+4  .System.Windows.Controls.DataGridTemplateColumn  $ Reader Name��   CellTemplate �� .R��� ��`� 	 �� StringFormat$	 {0} {1}��.1��� 
 �� Path$
 Reader.LName��� $
 Reader.FName�  $ Quantity Book�� �� *
Quantity+  $ 	Loan Date�� �� *
LoanDate+$	 
dd/MM/yyyy��  $ Return Date�� �� *	ExpDate+$	 
dd/MM/yyyy��  $ Payment�� �� *Total+  $ Action�� �� .R��� $��	btnDetail��-   $��Detail��$	��100��$
��10 0q�
 � Tag ��    RowStyle ��  �� 
TargetType)  #System.Windows.Controls.DataGridRow"   �� Triggers ��  �� Binding �� *	ExpDate+ �� 	Converter# [   �� Value True.a���  �� Property � �� �� Value
 �  ��P�  P� Property �@ 
IsSelected P� Value . (   "HungVuong_C5_Assignment.Pagination  -     Name$ 
pagination��$��1��$��45��