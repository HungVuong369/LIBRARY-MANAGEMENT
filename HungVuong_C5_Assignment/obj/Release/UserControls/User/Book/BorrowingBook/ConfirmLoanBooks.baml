   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  .    (HungVuong_C5_Assignment.ConfirmLoanBooks   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     .���   � RowDefinitions  �� $
��auto ��� $
��auto ��� �� $
��auto �.+��� $��Add Loan Slip��$��20(�$
��Bold"�$��Center=�� $��1��$��5q� � ColumnDefinitions �� �� .+��� $��Loan Slip Information��
���   �$��15(�$��SemiBold"�$��5q�.���   �� �� �� �� �� ��  �� $
��auto ��� .+��� $
��ID: ���� $��
Quantity: ��$��1��$��14(�$��SemiBold"��� $��Loan Paid: ��$��2��$��14(�$��SemiBold"��� $��	Deposit: ��$��3��$��14(�$��SemiBold"��� $��Loan Date: ��$��4��$��14(�$��SemiBold"��� $��Expire Date: ��$��5��$��14(�$��SemiBold"��� $��1��$��13(�$��SemiBold"�$��Center=����� *LoanSlip.Id+�� $��1��$��1��$��13(�$��SemiBold"�$��Center=����� *LoanSlip.Quantity+�� $��1��$��2��$��13(�$��SemiBold"�$��Center=����� *LoanSlip.LoanPaid+�� $��1��$��3��$��13(�$��SemiBold"�$��Center=����� *LoanSlip.Deposit+�� $��1��$��4��$��13(�$��SemiBold"�$��Center=����� *LoanSlip.LoanDate+ �� StringFormat$ 
dd/MM/yyyy���� $��1��$��5��$��13(�$��SemiBold"�$��Center=����� *LoanSlip.ExpDate+$ 
dd/MM/yyyy���� $��Reader Information��
���   �$��15(�$��SemiBold"�$��1��$��5q�.���  �� $
��auto ���   �� �� �� �� �� �� .+��� $
��Id: ��$��14(�$��SemiBold"��� $��Name: ��$��1��$��14(�$��SemiBold"��� $��Reader Type: ��$��2��$��14(�$��SemiBold"��� $��13(�$��SemiBold"�$��1��$��Center=����� *	Reader.Id+�� $��13(�$��SemiBold"�$��1��$��1��$��Center=����� *
FullName+�� $��13(�$��SemiBold"�$��1��$��2��$��Center=����� *
ReaderType+�� $��Loan Detail��$��2��$��15(�$��SemiBold"�
���   �$��5q�.��&   System.Windows.Controls.DataGrid  -   $��dgLoanDetails��   AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�$	��300��$��5q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 ISBN��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *ISBN+  $ 	Name Book�� �� *BookISBN.BookTitle.Name+  $ Author Name�� �� *BookISBN.Author.Name+  $ Translator Name�� �� *BookISBN.Author.Name+  $ Language�� �� *BookISBN.OriginLanguage+  $ 
Book Price�� �� *PriceCurrent+� $��3��$��5q� �� �� .+��� -   $��
btnConfirm��$��Confirm��$��5q��� -   $��	btnCancel��$��1��$��Cancel��$��5q�