   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 3    -HungVuong_C5_Assignment.ucUpdatePenaltyReason   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity       � 	Resources     ValidationErrorTemplate �� 
TargetType �� Property �� Value��%�   &	        '�� R     7   �� .R�]� .+��� 
���  ��$��12(�$��0 20 0 0q����� *ErrorContent+�� " ��.���  �@=�ErrorTemplate8   .���  � RowDefinitions �� $
��auto ��� �� $
��auto �.+��� -   $��tbHeader��$��Update Penalty Reason��$��20(�$
��Bold"�$��Center=�$��5q��� $ ��Penalty Reason Information��$��1��$��5q�
���   �$	��260��$	��420��$��15(�$��SemiBold"�.���  �� �� �� �� �� ��  � ColumnDefinitions �� $
��auto ��� .+��� $
��Id: ��$��Center=�$��5q��� $��1��
������� �� 
IsReadOnly . $��Center=�$��5q����� *NewPenaltyReasonID+�� $��Name: ��$��1��$��Center=�$��5q��� -   $��txtName��$��1��$��1��$��Center=�$��5q�.������  �� Path$ PenaltyReasonName� �� UpdateSourceTrigger$ PropertyChanged=�	 �� Mode$	 TwoWay=�
 �� ValidationRules
 +   %HungVuong_C5_Assignment.InputTextRule  .��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ TextChanged��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *TextChanged+   CommandParameter �� .���� $��Description: ��$��2��$��Center=�$��5q��� -   $��txtDescription��$��1��$��2��$��Center=�$��5q�.������ $ Description�$ PropertyChanged=�$	 TwoWay=�
 0   *HungVuong_C5_Assignment.InputTextAndNumber  .��   $ TextChanged��.    �� *TextChanged+ �� .���� $��Price: ��$��3��$��Center=�$��5q��� -   $��txtPrice��$��1��$��3��$��Center=�$��5q�.������ $ Price�$ PropertyChanged=�$	 TwoWay=�
 .��   $ TextChanged��.    �� *PriceTextChanged+ �� .���� $��Created At: ��$��4��$��Center=�$��5q��� $��1��
������� . $��Center=�$��5q�$��4������ *	CreatedAt+ �� StringFormat$ 
dd/MM/yyyy���� $��Modified At: ��$��5��$��Center=�$��5q��� $��1��
������� . $��Center=�$��5q�$��5������ *
ModifiedAt+$ 
dd/MM/yyyy��� $��2��$��5q� �� �� .+��� $��Update��$��5q�  ButtonBasicStyle#��[ 
��� ���
����  �$��Stretch=�$��Stretch=����� *UpdateCommand+{��� *IsEnabledAdd+�� $��Cancel��$��1��$��5q����� *CancelCommand+