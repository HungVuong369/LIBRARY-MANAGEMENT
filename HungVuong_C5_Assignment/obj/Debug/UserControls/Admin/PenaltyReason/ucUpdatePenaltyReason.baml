   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      3    -HungVuong_C5_Assignment.ucUpdatePenaltyReason   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5        � 	Resources  5
         ValidationErrorTemplate �� 
TargetType �� Property �� Value��%	  &	        '�� �     7   �� 5   
   .R�5      ]� .+�5      �� 
���  ��$��12(�6-   $��0 20 0 0q�5      ��5   ;   �� *ErrorContent+5      5      5      �� 5   
   " ��6   .�5      ��  �@=�ErrorTemplate8   69   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   �� -   5        $��tbHeader��5#      $��Update Penalty Reason��5      $��20(�5      $
��Bold"�5       $��Center=�5!      $��5q�5"      5#      �� 5%   
   $ ��Penalty Reason Information��6   $��1��5&      $��5q�5'      
���   �$	��260��5)      $	��420��5*      $��15(�5+      $��SemiBold"�5,      .��5-      �  5.      �� 5/      �� 50      �� 51      �� 52      �� 53      �� 54       � ColumnDefinitions 57      �� 58      $
��auto �6'   �� 59      .+�5<      �� $
��Id: ��6   $��Center=�5=      $��5q�5>      �� 5@      $��1��6   
������� �� 
IsReadOnly . $��Center=�5C      $��5q�5D      ��5E      �� *NewPenaltyReasonID+�� 5G      $��Name: ��6   $��1��5H      $��Center=�5I      $��5q�5J      �� 5L      -   5        $��txtName��5P      $��1��5L      $��1��5M      $��Center=�5N      $��5q�5O      .��5P   )   ��5Q      �� 5R       �� Path$ PenaltyReasonName�6"    �� UpdateSourceTrigger$ PropertyChanged=�5S   "   	 �� Mode$	 TwoWay=�5T   "   
 �� ValidationRules
 5U      +   %HungVuong_C5_Assignment.InputTextRule  5V   "   5X      .��5Y   $   .  (System.Windows.Interactivity.Interaction   Triggers 5[      /  )System.Windows.Interactivity.EventTrigger  5\         	EventName$ TextChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5]      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *TextChanged+   CommandParameter 5^   4   �� 5_      .��5`   .   5a      �� 5c      $��Description: ��6   $��2��5d      $��Center=�5e      $��5q�5f      �� 5h      -   5        $��txtDescription��5l      $��1��5h      $��2��5i      $��Center=�5j      $��5q�5k      .��5l   0   ��5m      �� 5n      $ Description�6"   $ PropertyChanged=�5o   "   $	 TwoWay=�5p   "   
 5q      0   *HungVuong_C5_Assignment.InputTextAndNumber  5r   "   5t      .��5u   $    5w        5x      $ TextChanged��6)   . 5y         64   �� *TextChanged+ 5z   4   �� 5{      .��5|   .   5}      �� 5      $��Price: ��6   $��3��5�      $��Center=�5�      $��5q�5�      �� 5�      -   5        $��txtPrice��5�      $��1��5�      $��3��5�      $��Center=�5�      $��5q�5�      .��5�   G   ��5�      �� 5�      $ Price�6"   $ PropertyChanged=�5�   "   $	 TwoWay=�5�   "   
 5�      5�      .��5�   $    5�        5�      $ TextChanged��6)   . 5�         64   �� *PriceTextChanged+ 5�   4   �� 5�      .��5�   .   5�      �� 5�      $��Created At: ��6   $��4��5�      $��Center=�5�      $��5q�5�      �� 5�      $��1��6   
������� . $��Center=�5�      $��5q�5�      $��4��5�      ��5�      �� *	CreatedAt+ �� StringFormat$ 
dd/MM/yyyy���� 5�      $��Modified At: ��6   $��5��5�      $��Center=�5�      $��5q�5�      �� 5�      $��1��6   
������� . $��Center=�5�      $��5q�5�      $��5��5�      ��5�      �� *
ModifiedAt+$ 
dd/MM/yyyy��5�      5�      � 5�   
   $��2��6   $��5q�5�       5�      �� 5�      �� 5�      .+�5�      �� $��Update��6   $��5q�5�        ButtonBasicStyle#��[ 5�      
��� ���
����  �$��Stretch=�5�      $��Stretch=�5�      ��5�      �� *UpdateCommand+{�5�      �� *IsEnabledAdd+�� 5�      $��Cancel��6   $��1��5�      $��5q�5�      ��5�      �� *CancelCommand+5�      5�      5�      