   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  1    +HungVuong_C5_Assignment.ucDetailLoanHistory   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment       � 	Resources  :   4HungVuong_C5_Assignment.ConvertIdPenaltyReasonToName   ConvertIdPenaltyReason �� 
TargetType �� Property �� Value��%s   &	        '��        �� " ��.���  � ��$ 14(���  � ��$ SemiBold"���  � ��$ 0 0 0 5q�.���  � RowDefinitions �� $
��auto ��� �� .+��� $��Detail Loan History��$��20(�$
��Bold"�$��Center=�$��5q��� $��Information��$��1��
���   �$��15(�$��5q�$��SemiBold"�.��� $��5q� � ColumnDefinitions �� �� �� .+��  �� �� �� �� ��  �� $
��auto ��� .+��� $
��Id: ��$��Center=��� $��Reader ID: ��$��1��$��Center=��� $��Reader Name: ��$��2��$��Center=��� $��
Quantity: ��$��3��$��Center=��� $��1��$��Center=����� *Id+�� $��1��$��1��$��Center=����� *	Reader.Id+�� $��1��$��2��$��Center=�
��� ��� *Reader.LName+ �� $� �� �� ��� *Reader.FName+�� $��1��$��3��$��Center=����� *
Quantity+� $��1�� �� �� �� ��  �� $
��auto ��� .+��� $��	Deposit: ��$��0��$��Center=��� $��Loan Paid: ��$��1��$��Center=��� $��Other Fee: ��$��2��$��Center=��� $��	Payment: ��$��4��$��Center=��� $��0��$��1��$��Center=����� *	Deposit+�� $��1��$��1��$��Center=����� *
LoanPaid+�� $��2��$��1��$��Center=����� *	FineMoney+�� $��3��$��1��$��Center=����� *Total+� $��2��.+��  �� $
��auto ���  �� �� �� �� �� .+��� $��Created At: ��$��0��$��Center=��� $��Loan Date: ��$��1��$��Center=��� $��Expire Date: ��$��2��$��Center=��� $��Note: ��$��3��$��Center=��� $��0��$��1��$��Center=����� *
CreateAt+ �� StringFormat$ 
dd/MM/yyyy���� $��1��$��1��$��Center=����� *
LoanDate+$ 
dd/MM/yyyy���� $��2��$��1��$��Center=����� *	ExpDate+$ 
dd/MM/yyyy���� $��3��$��1��$
��Wrap=�$��Center=����� *Note+�� $��Loan Detail Histories��$��2��
���   �$��15(�$��SemiBold"�$��5q�.��&   System.Windows.Controls.DataGrid  -   $��dgLoanDetailHistories��   AutoGenerateColumns .     
IsReadOnly . 	   SelectionMode$	 Single=�$��3��$	��300��$��5q����� *LoanDetailHistories+
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 ISBN��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	Book.ISBN+  $ 	Name Book�� �� *Book.BookISBN.BookTitle.Name+  $ Author Name�� �� *Book.BookISBN.Author.Name+  $ Translator Name�� �� *Book.BookISBN.Author.Name+  $ Language�� �� *Book.BookISBN.OriginLanguage+  $ 
Book Price�� �� *Book.PriceCurrent+  $ 
Paid Money�� �� *	PaidMoney+  $
 Note�� �� *Note+ �� 	Converter# [  