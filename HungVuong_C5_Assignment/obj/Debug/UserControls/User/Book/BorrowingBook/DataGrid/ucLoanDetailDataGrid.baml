   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      2    ,HungVuong_C5_Assignment.ucLoanDetailDataGrid   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5        � 	Resources  5	      2   ,HungVuong_C5_Assignment.ExpiredDateConverter   ConvertExpiredDate3   -HungVuong_C5_Assignment.TrueFalseToReaderType  ConvertReaderType��%:   &	        &	        5
   
   6%     5   
   6&   5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgLoanDetail��5         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5   %   ��5      �� *LoanDetails+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5      �� *SelectedLoanDetail+$ TwoWay=�$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Loan ID��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 66   �� *IdLoan+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Reader��6)   
   CellTemplate
 5      �� 5      .R�5      �� ��5   "   `� 5   &    �� StringFormat$ {0} {1}��63   .1�5   *   ��  �� Path$ LoanSlip.Reader.LName�62   �� 5   *   $ LoanSlip.Reader.FName�62   5   '   5       5!      5#        5%      $
 Type��6%   	 63   �� *LoanSlip.Reader.ReaderType+ �� 	Converter# [    	CellStyle 5&      �� 5'       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6      CellDefault �� BasedOn# [ 6:    �� Triggers 5(      �� 5)   "    �� Binding 6.   �� *Type+ �� Value True6G   .a�5*   &   ��  �� Property � �� �� Value
 �� ��6C   5+   #   �� 5,   "    6.   �� *Type+	 False6G   .a�5-   &   ��  � ��
 ��  �6C   5.   #   P� 50   "    P� Property �@ 
IsSelected P� Value . . �51   &   ��  � ��
 �����6C   �� 52   &    � ��
 �  ��6D   �� 53   &    � ��
 �  ��6C   54   #   56      58        5:      $
 ISBN��6%   	 63   �� *	Book.ISBN+  5;      $
 Book��6%   	 63   �� *Book.BookISBN.BookTitle.Name+  5<      $ 	Loan Date��6%   	 68   �� *LoanSlip.LoanDate+$ 
dd/MM/yyyy��  5=      $ Expire Date��6%   	 6:   �� *LoanSlip.ExpDate+$ 
dd/MM/yyyy��  5?      $ Action��6)   
 5@      �� 5A      .R�5B      �� $��	btnReturn��6%   $��Return Loan��5C   %   $	��100��5E   %   $
��10 0q�5F   %   $��20��5G   %     ButtonBasicStyle#��[ 5H   %   
�������$y�	Collapsed=�5K   %   
 � Tag 5D   %   �� *
LoanSlip+��5J   %   �� *#!DataContext.ReturnLoanSlipCommand+ �� RelativeSource ��  �� AncestorType"  5L       �� Triggers 5N      �� 5O   "   $
 True��6y    6.   �� *	ExpDate+# [  .a�5P   &   ��  �� 
TargetName$ 	btnReturn��6-    � y�$ Visible=�6Z   6l   5Q   #   5S      5U         	CellStyle 5X      �� 5Y      "  6   # [ 62    5Z      P� 5[       �@ 
IsSelected . . �5\      ��  � ��$ 14(�69   �� 5]       � ��
 �  ��6<   �� 5^       � ��
 �����6;   �� 5_       � ��
 �  ��6;   5`      5b         RowStyle 5e      �� 5f      )	  #System.Windows.Controls.DataGridRow" 	 6    5g      �� 5h       6&   �� *	ExpDate+# [   True6q   .a�5i      ��  � ��
 �  ��6;   5j      P� 5l       �@	 
IsSelected . 5m      5o      5q      5r      5s      