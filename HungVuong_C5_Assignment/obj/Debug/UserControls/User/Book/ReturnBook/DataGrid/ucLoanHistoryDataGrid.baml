   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      3    -HungVuong_C5_Assignment.ucLoanHistoryDataGrid   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5        � 	Resources  5	      2   ,HungVuong_C5_Assignment.ExpiredDateConverter   ConvertExpiredDate��%   &	          5
   
   6%   5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgLoanHistories��5         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $ 
Created By��6%    69   �� *User.Username+  5      $ 	Reader ID��6%    68   �� *
IdReader+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Reader Name��6)      CellTemplate 5      �� 5      .R�5      �� ��5   "   `� 5    &   	 �� StringFormat$	 {0} {1}��63   .1�5!   *   �� 
 �� Path$
 Reader.LName�62   �� 5"   *   $
 Reader.FName�62   5#   '   5%      5&      5(        5)      $ Quantity Book��6%    6<   �� *
Quantity+  5*      $ 	Loan Date��6%    68   �� *
LoanDate+$	 
dd/MM/yyyy��  5+      $ Return Date��6%    6:   �� *	ExpDate+$	 
dd/MM/yyyy��  5,      $ Payment��6%    66   �� *Total+  5.      $ Action��6)    5/      �� 50      .R�51      �� $��	btnDetail��6%   -   5        $��Detail��52   %   $	��100��55   %   $
��10 0q�56   %   
 � Tag 53   %   �� 56   %   57      59         RowStyle 5<      �� 5=       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    �� Triggers 5>      �� 5?       �� Binding 6&   �� *	ExpDate+ �� 	Converter# [   �� Value True6q   .a�5@      ��  �� Property � �� �� Value
 �  ��6;   5A      P� 5C       P� Property �@ 
IsSelected P� Value . 5D      5F      5H      (   "HungVuong_C5_Assignment.Pagination  5J   
   -   5          Name$ 
pagination��5K      $��1��5J      $��45��5L      5M      5N      