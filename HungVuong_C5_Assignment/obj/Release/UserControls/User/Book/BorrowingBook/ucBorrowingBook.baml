   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity -    'HungVuong_C5_Assignment.ucBorrowingBook   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity       � 	Resources   �� 
TargetType �� Property �� Value��%�   '��       '�� W     �� " ��.���  � ��
 �   ���  � ��$ 15(���  � ��$ SemiBold"��� " ��.���  � ��$ 14(���  � ��$ SemiBold"�.���  � RowDefinitions �� $
��auto ��� .+�� $	��270�� � ColumnDefinitions �� $
��auto ��� �� $
��auto � �� �� .+��� $��0��$��1q����#27AE60���#27AE60._��� $��1��$��Center=�
��������� $��1��$��Choose a reader��
���   ��� $��2��$��1������ *BorderBrushMultipleStep+�� $��2��$��1q����� *BorderBrushMultipleStep+���� *BackgroundMultipleStep+._��� $��2��$��Center=����� *ForegroundMultipleStep+�� $��1��$��2��$��Choose books��
���   ��� $��1��$��5q�$��Reader Information��y��� *ReaderInformationVisibility+.���  �� $
��auto ��� �� $
��auto �.+��� $��Search Reader��$��5q�.���  �� $
��auto ���  �� �� �� �� �� .+��� $��
Reader ID:��$��5q�� $��0��$��1�� �� �� $
��auto �.+��� -   $��txtReaderID��$��5q�   PlaceHolderTextStyle#��[  
 � Tag$ Search here...��{��� *ShowBookVM.IsInputReader+���� *
ReaderID+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��.  (System.Windows.Interactivity.Interaction	   Triggers	 /  )System.Windows.Interactivity.EventTrigger  
   	EventName$
 TextChanged��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *TextChangedReaderIDCommand+   CommandParameter �� .���� -   $��
cbReaderID��$��0��$��0��$��1�� �� DisplayMemberPath$ Id�� �� SelectedValuePath$ Id��$
��Left=����� *FilterReaders+ �� SelectedItem �� *SelectedReader+$ OneWayToSource=�$ PropertyChanged=� �� IsDropDownOpen �� *IsDropDownReaderID+	   $
 SelectionChanged��.    �� *!SelectionChangedReaderIDCommand+ �� ���� " ��  ComboBoxUsedStyle �� BasedOn# [  �� Triggers P�  P� Property �@��IsDropDownOpen P� Value . . ���  � ��
 ���� �� $��Name:��$��1��$��5q��� $��1��$��1��
������� �� 
IsReadOnly . $��5q����� *
ReaderName+�� $��Reader Type:��$��2��$��5q��� $��2��$��1��
������� . $��5q����� *
ReaderType+.������ " �� ��  �� Binding �� *
ReaderType+ �� Value Người lớn.a���  � ��
 �� ����  �� *
ReaderType+ Trẻ em.a���  � ��
 ��  �.���� $��Status:��$��3��$��5q��� $��3��$��1��
������� . $��5q����� *Status+.������ " �� ��  �� *Status+ 	Available.a���  � ��
 � � ���  �� *Status+ Unavailable.a���  � ��
 �  ��.���� $��Loaned Quantity:��$��4��$��5q��� $��4��$��1��
������� . $��5q����� *
Quantity+���� *ForegroundQuantity+.���� $��1��$��5q�$��List Loan Detail��.��2   ,HungVuong_C5_Assignment.ucLoanDetailDataGrid  -     Name$ ucLoanDetail��$��5q��� $
��Next��$��2��  ButtonBasicStyle#��[ $��Stretch=�$��Stretch=����#27AE60$��5q�$��20��{��� *IsAllowLoanBooks+���� *NextCommand+�� $��1��$��Search Book��$��5q� J� IsHitTestVisible �� *IsAllowLoanBooks+ J� Opacity �� *	Opacity+y��� *SearchBookVisibility+.���  �� $
��auto ��� �� $
��auto �.+�� -   $��	grdSearch��$��0��$	��5 0q� �� $
��auto ��� �� $
��auto ��� �� $
��auto ��� �� .+��� $
��Book��$��Center=��� $	��5 0q�$��1��$��Center=����� *
BookName+$ TwoWay=�$ PropertyChanged=�.��	   $
 TextChanged��.    �� *BookNameTextChangedCommand+ �� .���� $��Category��$��2��$��Center=��� $	��5 0q�$��3��$��Center=�$
 Name������ *LstCategory+ �� *SelectedCategory+	   $
 SelectionChanged��.    �� *!CategorySelectionChangedCommand+ �� �� $��Author��$��4��$��Center=��� $	��5 0q�$��5��$��Center=�$
 Name������ *	LstAuthor+ �� *SelectedAuthor+	   $
 SelectionChanged��.    �� *AuthorSelectionChangedCommand+ �� �� -   $��	btnCreate��$��6��$��Create Loan Slip��$	��5 0q�{��� *ShowBookVM.IsCreateLoanSlip+���� *CreateLoanSlipCommand+� $��1�� �� �� .+��� $��	List Book��$	��5 0q�.��)   #HungVuong_C5_Assignment.ucShowBooks  �� $��1��$	��5 0q�$��List Book Loaning��.��)   #HungVuong_C5_Assignment.ucLoanBooks  -     Name$ ucLoanBooks���� $��Previous��$��2��#��[ $��Stretch=�$��Stretch=����#27AE60$��5q�$��20��{��� *IsAllowLoanBooks+���� *PreviousCommand+