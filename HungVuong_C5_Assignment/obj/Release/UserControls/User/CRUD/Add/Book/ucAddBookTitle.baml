   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  ,    &HungVuong_C5_Assignment.ucAddBookTitle   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     .���   � RowDefinitions  �� $
��auto ��� $
��auto ��� $
��auto �.+��� $��Add Book Title��$��20(�$
��Bold"�$��Center=�� $��1��$��5q�$	��185��$	��300��  �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��Name: ��$��14(�$��SemiBold"�$��0 0 0 5q�$��0���� -   $��txtBookTitleName��$��1��.������  �� Path$
 Name� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidationRules 0   *HungVuong_C5_Assignment.InputTextAndNumber  .���� $��Category��$��14(�$��SemiBold"�$��0 10 0 5q�$��2���� -   $��
cbCategory�� �� DisplayMemberPath$
 Name��$��3������ *
Categories+ �� SelectedItem �� *SelectedCategory+$ PropertyChanged=��� $��	Summary: ��$��14(�$��SemiBold"�$��0 10 0 5q�$��4���� -   $��
txtSummary��$��5��.������ $ Summary�$ TwoWay=�$ PropertyChanged=�   .��� $��6��$
��0 10q� � ColumnDefinitions �� �� .+��� -   $��btnAdd��$	��Add��$��0 0 5 0q����� *
AddCommand+{��� *	isEnabled+$ PropertyChanged=��� -   $��	btnCancel��$��Cancel��$��1��$��5 0 0 0q����� *CancelCommand+