   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity -    'HungVuong_C5_Assignment.ucAddTranslator   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity       � 	Resources     ValidationErrorTemplate �� 
TargetType �� Property �� Value��%�   &	        '�� R     7   �� .R�]� .+��� 
���  ��$��12(�$��0 20 0 0q����� *ErrorContent+�� " ��.���  �@=�ErrorTemplate8   .���  � RowDefinitions �� $
��auto ��� �� $
��auto �.+��� $��Add Translator��$��20(�$
��Bold"�$��Center=�$��5q��� $��15(�$��SemiBold"�
���   �$��Translator Information��$��1��$	��200��$	��500��$��5q�.���  � ColumnDefinitions �� �� .+�� $��5q� �� �� �� ��  �� $
��auto ��� .+��� $
��Id: ��$��Center=��� $��1��
������� �� 
IsReadOnly . $��Center=����� *NewTranslatorID+�� $��Name: ��$��1��$��Center=��� -   $��txtName��$��1��$��1��$��Center=�.������  �� Path$ 
AuthorName� �� UpdateSourceTrigger$ PropertyChanged=�	 �� Mode$	 TwoWay=�
 �� ValidationRules
 +   %HungVuong_C5_Assignment.InputTextRule  .��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ TextChanged��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *NameTextChangedCommand+   CommandParameter �� .���� $��BoF: ��$��2��$��Center=�(  "System.Windows.Controls.DatePicker  $��1��$��2�� � Language$ vi-VN�$��Center=�   DisplayDateStart$ 
1753-01-01X�   DisplayDateEnd$ 
9999-12-31X�   SelectedDate �� *BoF+�� $��Created At: ��$��3��$��Center=��� $��1��$��3��
������� . $��Center=����� *	CreatedAt+ �� StringFormat$ 
dd/MM/yyyy��� $��1��$��5q� �� $
��auto ���  �� �� �� �� .+��� $��Description: ��$��Center=��� -   $��txtDescription��$��1��$��Center=� �� TextWrapping$
 Wrap=�.��   $ TextChanged��.    �� *NameTextChangedCommand+ �� .������ $ Description�$ PropertyChanged=�$	 TwoWay=�
 5   /HungVuong_C5_Assignment.InputOnlyPhoneAndNumber  .���� $��	Summary: ��$��1��$��Center=��� -   $��
txtSummary��$��1��$��1��$
 Wrap=�$��Center=�.��   $ TextChanged��.    �� *NameTextChangedCommand+ �� .������ $ Summary�$ PropertyChanged=�$	 TwoWay=�
   .��� $��2��$��5q� �� �� .+��� $	��Add��$��5q�{��� *IsEnabledAdd+���� *
AddCommand+�� $��1��$��Cancel��$��5q����� *CancelCommand+