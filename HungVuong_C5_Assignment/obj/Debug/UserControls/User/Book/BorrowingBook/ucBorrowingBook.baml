   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      -    'HungVuong_C5_Assignment.ucBorrowingBook   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5        � 	Resources  5
       �� 
TargetType �� Property �� Value��%  '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��
 �   �6,   �� 5       � ��$ 15(�6)   �� 5       � ��$ SemiBold"�6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$ SemiBold"�6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   � $	��270��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      �� 5       $
��auto �6#    5#      �� 5$      �� 5%      .+�5(      �� $��0��6   $��1q�6%   ���#27AE60���#27AE60._�5+      �� $��1��6   $��Center=�5,      
�������5-   1   5.      �� 50      $��1��6   $��Choose a reader��51      
���   �52   -   �� 54      $��2��6   $��1��55      ��54   #   �� *BorderBrushMultipleStep+55      �� 57      $��2��6   $��1q�6%   ��58      �� *BorderBrushMultipleStep+��59      �� *BackgroundMultipleStep+._�5:      �� $��2��6   $��Center=�5;      ��5<      �� *ForegroundMultipleStep+6L   5=      �� 5?      $��1��6   $��2��5@      $��Choose books��5A      
���   �5B   -   5C      �� 5E   
   $��1��6   $��5q�5F      $��Reader Information��5G      y�5H      �� *ReaderInformationVisibility+.��5I      �  5J      �� 5K      $
��auto �6$   �� 5L      �� 5M      $
��auto �6$   .+�5P      �� $��Search Reader��6   $��5q�5Q      .��5R      �  5S      �� 5T      $
��auto �6/   �� 5U       5X      �� 5Y      �� 5Z      �� 5[      �� 5\      �� 5]      .+�5`      �� $��
Reader ID:��6$   $��5q�5a   $   � 5b      $��0��6   $��1��6,    5c      �� 5d   "   �� 5e   "   $
��auto �63   .+�5h      �� -   5        $��txtReaderID��5h   &   $��5q�5i   &      PlaceHolderTextStyle#��[  5j   &   
 � Tag$ Search here...��5k   &   {�5l   &   �� *ShowBookVM.IsInputReader+��5m   &   �� *
ReaderID+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��6r   .  (System.Windows.Interactivity.Interaction	   Triggers	 5n   "   /  )System.Windows.Interactivity.EventTrigger  5o   &   
   	EventName$
 TextChanged��65   .  (System.Windows.Interactivity.TriggerBase   Actions. 5p   *   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6@   �� *TextChangedReaderIDCommand+   CommandParameter 5q   @   �� 5r   '   .��5s   :   5t      �� 5v      -   5        $��
cbReaderID��5y   '   $��0��5v   '   $��0��5w   '   $��1��5x   '    �� DisplayMemberPath$ Id��5{   '    �� SelectedValuePath$ Id��5|   '   $
��Left=�5}   '   ��5~   '   �� *FilterReaders+ �� SelectedItem 5   '   �� *SelectedReader+$ OneWayToSource=�$ PropertyChanged=� �� IsDropDownOpen 5�   '   �� *IsDropDownReaderID+	 5�   "     5�   &   $
 SelectionChanged��65   . 5�   *      6@   �� *!SelectionChangedReaderIDCommand+ 5�   @   �� 5�   +   5�   '   ��5�   "   �� 5�   &   " ��6,     ComboBoxUsedStyle �� BasedOn# [ 6B    �� Triggers 5�   *   P� 5�   .    P� Property �@��IsDropDownOpen P� Value . . �5�   2   ��  � ��
 ���� 6O   5�   /   5�   '   5�      5�      �� 5�      $��Name:��6$   $��1��5�   $   $��5q�5�   $   �� 5�      $��1��6"   $��1��6/   
������� �� 
IsReadOnly . $��5q�5�   "   ��5�   "   �� *
ReaderName+5�   "   �� 5�      $��Reader Type:��6$   $��2��5�   $   $��5q�5�   $   �� 5�      $��2��6"   $��1��6/   
������� . $��5q�5�   "   ��5�   "   �� *
ReaderType+.��5�   -   ��5�      �� 5�   "   " ��6(    5�   &   �� 5�   *    �� Binding 66   �� *
ReaderType+ �� Value Người lớn6U   .a�5�   .   ��  � ��
 �� ��6K   5�   +   �� 5�   *    66   �� *
ReaderType+ Trẻ em6U   .a�5�   .   ��  � ��
 ��  �6K   5�   +   5�   #   .��5�   -   5�      �� 5�      $��Status:��6$   $��3��5�   $   $��5q�5�   $   �� 5�      $��3��6"   $��1��6/   
������� . $��5q�5�   "   ��5�   "   �� *Status+.��5�   -   ��5�      �� 5�   "   " ��6(    5�   &   �� 5�   *    66   �� *Status+ 	Available6Q   .a�5�   .   ��  � ��
 � � �6K   5�   +   �� 5�   *    66   �� *Status+ Unavailable6Q   .a�5�   .   ��  � ��
 �  ��6K   5�   +   5�   #   .��5�   -   5�      �� 5�      $��Loaned Quantity:��6$   $��4��5�   $   $��5q�5�   $   �� 5�      $��4��6"   $��1��6/   
������� . $��5q�5�   "   ��5�   "   �� *
Quantity+��5�   "   �� *ForegroundQuantity+.��6L   5�      5�      5�      �� 5�      $��1��6   $��5q�5�   #   $��List Loan Detail��5�   #   .��5�      2   ,HungVuong_C5_Assignment.ucLoanDetailDataGrid  -   5          Name$ ucLoanDetail��5�   1   $��5q�5�   1   5�      �� 5�      $
��Next��6   $��2��5�        ButtonBasicStyle#��[ 5�      $��Stretch=�5�      $��Stretch=�5�      ���#27AE60$��5q�5�      $��20��5�      {�5�      �� *IsAllowLoanBooks+��5�      �� *NextCommand+6;   5�      5�      �� 5�   
   $��1��6   $��Search Book��5�      $��5q�5�       J� IsHitTestVisible 5�      �� *IsAllowLoanBooks+ J� Opacity 5�      �� *	Opacity+y�5�      �� *SearchBookVisibility+.��5�      �  5�      �� 5�      $
��auto �6$   �� 5�      �� 5�      $
��auto �6$   .+�5�      � -   5        $��	grdSearch��5      $��0��5�      $	��5 0q�5�       5     �� 5     $
��auto �6+   �� 5     �� 5     $
��auto �6+   �� 5     �� 5     $
��auto �6+   �� 5     �� 5     .+�5     �� $
��Book��6    $��Center=�5      �� 5     $	��5 0q�6   $��1��5     $��Center=�5     ��5     �� *
BookName+$ TwoWay=�$ PropertyChanged=�.��6j   	 5       5     $
 TextChanged��6-   . 5  "      68   �� *BookNameTextChangedCommand+ 5  -   �� 5     .��5  2   5     �� 5     $��Category��6    $��2��5      $��Center=�5      �� 5     $	��5 0q�6   $��3��5     $��Center=�5     $
 Name��5!     ��5     �� *LstCategory+ 5      �� *SelectedCategory+	 5"       5#     $
 SelectionChanged��6-   . 5$  "      68   �� *!CategorySelectionChangedCommand+ 5%  8   �� 5&     5(     �� 5*     $��Author��6    $��4��5+      $��Center=�5,      �� 5-     $	��5 0q�6   $��5��5.     $��Center=�5/     $
 Name��52     ��50     �� *	LstAuthor+ 51     �� *SelectedAuthor+	 53       54     $
 SelectionChanged��6-   . 55  "      68   �� *AuthorSelectionChangedCommand+ 56  8   �� 57     59     �� 5;     -   5        $��	btnCreate��5>     $��6��5;     $��Create Loan Slip��5<     $	��5 0q�5=     {�5?     �� *ShowBookVM.IsCreateLoanSlip+��5@     �� *CreateLoanSlipCommand+5B     � 5G     $��1��6    5H     �� 5I     �� 5J     .+�5M     �� $��	List Book��6   $	��5 0q�5N     .��5O     )   #HungVuong_C5_Assignment.ucShowBooks  5P     �� 5R     $��1��6   $	��5 0q�5S     $��List Book Loaning��5T     .��5U     )   #HungVuong_C5_Assignment.ucLoanBooks  -   5          Name$ ucLoanBooks��5U  ,   5V     5W     �� 5Y     $��Previous��6   $��2��5Z     #��[ 5[     $��Stretch=�5\     $��Stretch=�5]     ���#27AE60$��5q�5_     $��20��5a     {�5`     �� *IsAllowLoanBooks+��5b     �� *PreviousCommand+6?   5c     5d     5e     5f     