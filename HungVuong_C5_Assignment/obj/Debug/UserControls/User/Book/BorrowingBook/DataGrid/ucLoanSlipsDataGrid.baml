   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      1    +HungVuong_C5_Assignment.ucLoanSlipsDataGrid   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5        � 	Resources  5	      2   ,HungVuong_C5_Assignment.ExpiredDateConverter   ConvertExpiredDate��%   &	          5
   
   6%   5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgLoanSlips��5         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $ 
Created By��6%    69   �� *	CreatedBy+  5      $ Reader Name��6%    6:   �� *
FullName+  5      $ Quantity Book��6%    6<   �� *
Quantity+  5      $ 	Loan Paid��6%    68   �� *
LoanPaid+  5      $ Deposit��6%    66   �� *	Deposit+  5      $ 	Loan Date��6%    68   �� *
LoanDate+ �� StringFormat$ 
dd/MM/yyyy��  5      $ Expire Date��6%    6:   �� *
ReturnDate+$ 
dd/MM/yyyy��4  .System.Windows.Controls.DataGridTemplateColumn  5       $ Action��6)   	   CellTemplate	 5!      �� 5"      .R�5#      �� $��	btnDetail��6%   -   5        $��Detail��5$   %   $	��100��5'   %   $
��10 0q�5(   %   

 � Tag
 5%   %   �� 5(   %   5)      5+         RowStyle 5.      �� 5/       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    �� Triggers 50      �� 51       �� Binding 6"   �� *
ReturnDate+ �� 	Converter# [   �� Value True6p   .a�52      ��  �� Property � �� �� Value
 �  ��6;   53      P� 55       P� Property �@ 
IsSelected P� Value . 56      58      5:      (   "HungVuong_C5_Assignment.Pagination  5<   
   -   5          Name$ 
pagination��5=      $��1��5<      $��45��5>      5?      5@      