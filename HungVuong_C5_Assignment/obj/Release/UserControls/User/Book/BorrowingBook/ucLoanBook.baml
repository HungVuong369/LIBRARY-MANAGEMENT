   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  (    "HungVuong_C5_Assignment.ucLoanBook   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     -   $	��230��$	��5 0q�  � ToolTip  _� .���� -   $	��250��$	��250��$��Uniform=�.��� -   $��grdTest��.+��� -   $��btnContainer��
������ 
 � Tag �� *SelectedLoanBook+ �� Mode$ TwoWay=����� *RemoveBookCommand+����  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R��� -   
���   �$	��^.^��$��14(�
������ ���� " ��.���  � z� T�  T� Y$ 0Q� �� Triggers P� 	 P� Property	 �@J�IsMouseOver
 P� Value
 .  N� EnterActions �� .���� .��W�  �� TargetProperty$8 2(UIElement.RenderTransform).(TranslateTransform.Y)�	 W� To$ -5X� g� Duration$ 0:0:0.2D� N� ExitActions �� .���� .��W� $8 2(UIElement.RenderTransform).(TranslateTransform.Y)�$ 0X�$ 0:0:0.2D�.��� -    � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� $
��auto ��� .+��� $
��Id: ��$��SemiBold"�$��14(��� $��Book: ��$��SemiBold"�$��1��$��14(��� $��
Category: ��$��2��$��SemiBold"�$��14(��� $��Author: ��$��SemiBold"�$��3��$��14(��� $��
Language: ��$��SemiBold"�$��4��$��14(��� $��Translator: ��$��SemiBold"�$��5��$��14(��� $��Publisher: ��$��SemiBold"�$��6��$��14(��� $��1��$
��Wrap=�$��Center=�$��13(����� *Id+�� $��1��$
��Wrap=�$��Center=�$��1��$��13(����� *Name+�� $��1��$��2��$
��Wrap=�$��Center=�$��13(����� *
Category+�� $��1��$��3��$
��Wrap=�$��Center=�$��13(����� *BookAuthor.Name+�� $��1��$��4��$
��Wrap=�$��13(�$��Center=����� *
Language+�� $��1��$��5��$
��Wrap=�$��13(�$��Center=����� *BookTranslator.Name+�� $��1��$��6��$
��Wrap=�$��13(�$��Center=����� *BookPublisher.Name+ P� 	 �@J�IsMouseOver
 . . ���  �@�Cursor$
 Hand��