   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity /    )HungVuong_C5_Assignment.ucUpdateParameter   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity       � 	Resources     ValidationErrorTemplate �� 
TargetType �� Property �� Value��%�   &	        '�� R     7   �� .R�]� .+��� 
���  ��$��12(�$��0 20 0 0q����� *ErrorContent+�� " ��.���  �@=�ErrorTemplate8   .���  � RowDefinitions �� $
��auto ��� �� $
��auto �.+��� -   $��tbHeader��$��Update Parameter��$��20(�$
��Bold"�$��Center=�$��5q��� $��Parameter Information��$��1��$��5q�
���   �$	��250��$	��300��$��15(�$��SemiBold"�.���  �� �� �� �� �� ��  � ColumnDefinitions �� $
��auto ��� .+��� $
��Id: ��$��Center=�$��5q��� $��1��
������� �� 
IsReadOnly . $��Center=�$��5q����� *NewParameterID+�� $��Name: ��$��1��$��Center=�$��5q��� -   $��txtName��$��1��$��1��$��Center=�$��5q�.������  �� Path$ ParameterName� �� UpdateSourceTrigger$ PropertyChanged=�	 �� Mode$	 TwoWay=�
 �� ValidationRules
 0   *HungVuong_C5_Assignment.InputTextAndNumber  .��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ TextChanged��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *NameTextChangedCommand+   CommandParameter �� .���� $��Description: ��$��2��$��Center=�$��5q��� -   $��txtDescription��$��1��$��2��$��Center=�$��5q�.������ $ Description�$ PropertyChanged=�$	 TwoWay=�
 .��   $ TextChanged��.    �� *NameTextChangedCommand+ �� .���� $��Value: ��$��3��$��Center=�$��5q��� -   $��txtValue��$��1��$��3��$��Center=�$��5q�.������ $ Value�$ PropertyChanged=�$	 TwoWay=�
   .��   $ TextChanged��.    �� *ValueTextChangedCommand+ ��   $ TextChanged��.    �� *ValueIntergerCommand+ ��   $ TextChanged��.    �� *ValueDecimalCommand+ ��   $ TextChanged��.    �� *ValuePercentCommand+ �� .���� $��Created At: ��$��4��$��5q�$��Center=��� $��1��$��4��$��5q�
������� . $��Center=����� *	CreatedAt+ �� StringFormat$ 
dd/MM/yyyy���� $��Modified At: ��$��5��$��5q�$��Center=��� $��1��$��5��$��5q�
������� . $��Center=����� *
ModifiedAt+$ 
dd/MM/yyyy��� $��2��$��5q� �� �� .+��� $��Update��$��5q�  ButtonBasicStyle#��[ $��Stretch=�$��Stretch=�
��� ���
����  ����� *UpdateCommand+{��� *IsEnabledAdd+�� $��Cancel��$��1��$��5q����� *CancelCommand+