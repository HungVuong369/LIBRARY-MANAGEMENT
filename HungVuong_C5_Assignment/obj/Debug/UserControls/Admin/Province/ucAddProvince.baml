   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      +    %HungVuong_C5_Assignment.ucAddProvince   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5        � 	Resources  5
         ValidationErrorTemplate �� 
TargetType �� Property �� Value��%	  &	        '�� �     7   �� 5   
   .R�5      ]� .+�5      �� 
���  ��$��12(�6-   $��0 20 0 0q�5      ��5   ;   �� *ErrorContent+5      5      5      �� 5   
   " ��6   .�5      ��  �@=�ErrorTemplate8   69   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   �� -   5        $��tbHeader��5#      $��Add Province��5      $��20(�5      $
��Bold"�5       $��Center=�5!      $��5q�5"      5#      �� 5%   
   $��Province Information��6   $��1��5&      $��5q�5'      
���   �$	��170��5)      $	��300��5*      $��15(�5+      $��SemiBold"�5,      .��5-      �  5.      �� 5/      �� 50      �� 51       � ColumnDefinitions 54      �� 55      $
��auto �6'   �� 56      .+�59      �� $
��Id: ��6   $��Center=�5:      $��5q�5;      �� 5=      $��1��6   
������� �� 
IsReadOnly . $��Center=�5@      $��5q�5A       J� Opacity$	 0.8Q�5B      ��5C      �� *NewProvinceID+�� 5E      $��Name: ��6   $��1��5F      $��Center=�5G      $��5q�5H      �� 5J      -   5        $��txtName��5N      $��1��5J      $��1��5K      $��Center=�5L      $��5q�5M      .��5N   )   ��5O      �� 5P       �� Path$ ProvinceName�6"   	 �� UpdateSourceTrigger$	 PropertyChanged=�5Q   "   
 �� Mode$
 TwoWay=�5R   "    �� ValidationRules 5S      +   %HungVuong_C5_Assignment.InputTextRule  5T   "   5V      .��5W   $   .  (System.Windows.Interactivity.Interaction   Triggers 5Y      /  )System.Windows.Interactivity.EventTrigger  5Z         	EventName$ TextChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5[      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *NameTextChangedCommand+   CommandParameter 5\   4   �� 5]      .��5^   .   5_      �� 5a      $��Status: ��6   $��2��5b      $��5q�5c      $��Center=�5d      �� 5f      $��1��6   $��2��5g      $��5q�5h      
������� . $��	Available��5k      $	 0.8Q�5l      
��� � �$��Center=�5n      5o      5p      � 5r   
   $��2��6   $��5q�5s       5t      �� 5u      �� 5v      .+�5y      �� $	��Add��6   $��5q�5z      ��5{      �� *
AddCommand+{�5|      �� *IsEnabledAdd+�� 5}      $��Cancel��6   $��1��5~      $��5q�5      ��5�      �� *CancelCommand+5�      5�      5�      