   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity +    %HungVuong_C5_Assignment.ucAddCategory   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity       � 	Resources     ValidationErrorTemplate �� 
TargetType �� Property �� Value��%�   &	        '�� R     7   �� .R�]� .+��� 
���  ��$��12(�$��0 20 0 0q����� *ErrorContent+�� " ��.���  �@=�ErrorTemplate8   .���  � RowDefinitions �� $
��auto ��� �� $
��auto �.+��� -   $��tbHeader��$��Add Category��$��20(�$
��Bold"�$��Center=�$��5q��� $��Category Information��$��1��$��5q�
���   �$	��170��$	��300��$��15(�$��SemiBold"�.���  �� �� ��  � ColumnDefinitions �� $
��auto ��� .+��� $
��Id: ��$��Center=�$��5q��� $��1��
������� �� 
IsReadOnly . $��Center=�$��5q����� *NewCategoryID+�� $��Name: ��$��1��$��Center=�$��5q��� -   $��txtName��$��1��$��1��$��Center=�$��5q�.������  �� Path$ CategoryName� �� UpdateSourceTrigger$ PropertyChanged=�	 �� Mode$	 TwoWay=�
 �� ValidationRules
 +   %HungVuong_C5_Assignment.InputTextRule  .��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ TextChanged��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *NameTextChangedCommand+   CommandParameter �� .���� $��Created At: ��$��2��$��5q�$��Center=��� $��1��$��2��$��5q�
������� . $��Center=����� *	CreatedAt+ �� StringFormat$ 
dd/MM/yyyy��� $��2��$��5q� �� �� .+��� $	��Add��$��5q����� *
AddCommand+{��� *IsEnabledAdd+�� $��Cancel��$��1��$��5q����� *CancelCommand+