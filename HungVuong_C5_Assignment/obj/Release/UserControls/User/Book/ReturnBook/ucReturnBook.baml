   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity *    $HungVuong_C5_Assignment.ucReturnBook   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity       � 	Resources   �� 
TargetType �� Property �� Value��%�   '��       '�� W     �� " ��.���  � ��
 �   ���  � ��$ 15(���  � ��$ SemiBold"��� " ��.���  � ��$ 14(���  � ��$ SemiBold"�.���  � RowDefinitions �� $
��auto ��� .+��� $��0��$��5q�$��Reader Information��.���  � ColumnDefinitions �� $
��auto ��� .+��� $��Search Reader��$��5q�$	��320��.���  �� $
��auto ���  �� �� �� �� �� .+��� $��
Reader ID:��$��5q�� $��0��$��1�� �� �� $
��auto �.+��� -   $��txtReaderID��$��5q����� *LoanHistoryVM.ReaderID+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger  	   	EventName$	 TextChanged��.  (System.Windows.Interactivity.TriggerBase
   Actions.
 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� **(LoanHistoryVM.TextChangedReaderIDCommand+   CommandParameter �� .���� -   $��
cbReaderID��$��0��$��0��$��1�� �� DisplayMemberPath$ Id�� �� SelectedValuePath$ Id��$
��Left=����� *LoanHistoryVM.FilterReaders+ �� SelectedItem �� *LoanHistoryVM.SelectedReader+$ OneWayToSource=�$ PropertyChanged=� �� IsDropDownOpen �� *" LoanHistoryVM.IsDropDownReaderID+   $	 SelectionChanged��.
    �� */-LoanHistoryVM.SelectionChangedReaderIDCommand+ �� ���� " ��   ComboBoxUsedStyle �� BasedOn# [   �� Triggers P�  P� Property �@��IsDropDownOpen P� Value . . ���  � ��
 ���� �� $��Name:��$��1��$��5q��� $��1��$��1��
������� �� 
IsReadOnly . $��5q����� *LoanHistoryVM.ReaderName+�� $��Reader Type:��$��2��$��5q��� $��2��$��1��
������� . $��5q����� *LoanHistoryVM.ReaderType+.������ " �� ��  �� Binding �� *LoanHistoryVM.ReaderType+ �� Value Người lớn.a���  � ��
 �� ����  �� *LoanHistoryVM.ReaderType+ Trẻ em.a���  � ��
 ��  �.���� $��Status:��$��3��$��5q��� $��3��$��1��
������� . $��5q����� *LoanHistoryVM.Status+.������ " �� ��  �� *LoanHistoryVM.Status+ 	Available.a���  � ��
 � � ���  �� *LoanHistoryVM.Status+ Unavailable.a���  � ��
 �  ��.���� $��Loaned Quantity:��$��4��$��5q��� $��4��$��1��
������� . $��5q����� *LoanHistoryVM.Quantity+���� *" LoanHistoryVM.ForegroundQuantity+.���� $��1��$��5q�$��List Loan Slip��.��0   *HungVuong_C5_Assignment.ucLoanSlipDataGrid  -     Name$ ucLoanSlipDataGrid��$��5q�$	��150���� $��1��$��Return Book��$��5q�.���  �� �� $
��auto �.+�� $��0�� �� �� $	��300 �.+��� $��Loan Details��$��5q�.��)   #HungVuong_C5_Assignment.ucLoanBooks  �� $��Payment��$��5q�$��1��.���  �� $
��auto ���  �� �� �� �� �� �� �� .+��� $��Loan Paid: ��$��Center=�$��5q��� $��Loan Period: ��$��Center=�$��5q�$��1���� $��
Late Fee: ��$��2��$��5q�$��Center=��� $��Other Fee: ��$��3��$��5q�$��Center=��� $��	Deposit: ��$��4��$��5q�$��Center=��� $��	Payment: ��$��5��$��5q�$��Center=��� $��Note: ��$��6��$��5q�$��Center=��� $��1�� . 
�������$��5q����� *,*LoanHistoryVM.SelectedLoanHistory.LoanPaid+�� $��1�� . 
�������$��1��$��5q����� *LoanHistoryVM.LoanPeriod+�� $��1�� . $��5q�$��2��
����������� *LoanHistoryVM.LateFee+�� $��1�� . 
�������$��3��$��5q����� *LoanHistoryVM.OtherFee+�� $��1�� . $��4��$��5q�
����������� *+)LoanHistoryVM.SelectedLoanHistory.Deposit+ �� TargetNullValue$ 0���� $��1��$��5q� . $��5��
����������� *LoanHistoryVM.Payment+�� $��1��$��6��$��5q����� *(&LoanHistoryVM.SelectedLoanHistory.Note+$ TwoWay=�$ PropertyChanged=�� $��1��.+��� $
��Note��$��1��$��5q�.���  �� $
��auto ��� �� $
��auto ��� �� $
��auto ��� �� .+��� $
��Book��$��Center=�$��5q��� $��1��$��5q�$��Center=�{�.  ���� *LJLoanHistoryDataGrid.SelectedLoanDetailHistory.Book.BookISBN.BookTitle.Name+�� $��Reason��$��Center=�$��2��$��5q��� $��3��$��5q�$��Center=�$
 Name�� �� SelectedIndex$ 0������ *LoanHistoryVM.PenaltyReason+ �� *%#LoanHistoryVM.SelectedPenaltyReason+$ PropertyChanged=�   $	 SelectionChanged��.
    �� *&$LoanHistoryVM.ReasonSelectionChanged+ �� �� $��Price��$��Center=�$��4��$��5q��� -   $��txtPrice��$��5��$��5q�$��Center=�{��� *LoanHistoryVM.IsEnabledPrice+���� *LoanHistoryVM.Price+$ PropertyChanged=�$ TwoWay=�.��   $	 TextChanged��.
    �� *'%LoanHistoryVM.PriceTextChangedCommand+ �� .���� $��OK��$��6��$��5q�{��� *LoanHistoryVM.IsReturnBook+���� *!LoanHistoryVM.ReturnBookCommand+