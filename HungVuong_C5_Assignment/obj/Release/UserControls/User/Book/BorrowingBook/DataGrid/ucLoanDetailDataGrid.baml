   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  2    ,HungVuong_C5_Assignment.ucLoanDetailDataGrid   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment       � 	Resources  2   ,HungVuong_C5_Assignment.ExpiredDateConverter   ConvertExpiredDate3   -HungVuong_C5_Assignment.TrueFalseToReaderType  ConvertReaderType��%   &	        &	          .��� .+�&   System.Windows.Controls.DataGrid  -   $��dgLoanDetail��   AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=����� *LoanDetails+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *SelectedLoanDetail+$ TwoWay=�$ PropertyChanged=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Loan ID��1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *IdLoan+4  .System.Windows.Controls.DataGridTemplateColumn  $ Reader��
   CellTemplate
 �� .R��� ��`�  �� StringFormat$ {0} {1}��.1���  �� Path$ LoanSlip.Reader.LName��� $ LoanSlip.Reader.FName�  $
 Type��	 �� *LoanSlip.Reader.ReaderType+ �� 	Converter# [    	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"    CellDefault �� BasedOn# [  �� Triggers ��  �� Binding �� *Type+ �� Value True.a���  �� Property � �� �� Value
 �� ����  �� *Type+	 False.a���  � ��
 ��  �P�  P� Property �@ 
IsSelected P� Value . . ���  � ��
 �������  � ��
 �  ����  � ��
 �  ��  $
 ISBN��	 �� *	Book.ISBN+  $
 Book��	 �� *Book.BookISBN.BookTitle.Name+  $ 	Loan Date��	 �� *LoanSlip.LoanDate+$ 
dd/MM/yyyy��  $ Expire Date��	 �� *LoanSlip.ExpDate+$ 
dd/MM/yyyy��  $ Action��
 �� .R��� $��	btnReturn��$��Return Loan��$	��100��$
��10 0q�$��20��  ButtonBasicStyle#��[ 
�������$y�	Collapsed=�
 � Tag �� *
LoanSlip+���� *#!DataContext.ReturnLoanSlipCommand+ �� RelativeSource ��  �� AncestorType"   �� Triggers �� $
 True�� �� *	ExpDate+# [  .a���  �� 
TargetName$ 	btnReturn�� � y�$ Visible=�   	CellStyle �� "  # [  P�  �@ 
IsSelected . . ���  � ��$ 14(���  � ��
 �  ����  � ��
 �������  � ��
 �  ��   RowStyle �� )	  #System.Windows.Controls.DataGridRow" 	  ��  �� *	ExpDate+# [   True.a���  � ��
 �  ��P�  �@	 
IsSelected . 