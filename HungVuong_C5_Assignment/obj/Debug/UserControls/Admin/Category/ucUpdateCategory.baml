   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      .    (HungVuong_C5_Assignment.ucUpdateCategory   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5        � 	Resources  5
         ValidationErrorTemplate �� 
TargetType �� Property �� Value��%	  &	        '�� �     7   �� 5   
   .R�5      ]� .+�5      �� 
���  ��$��12(�6-   $��0 20 0 0q�5      ��5   ;   �� *ErrorContent+5      5      5      �� 5   
   " ��6   .�5      ��  �@=�ErrorTemplate8   69   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   �� -   5        $��tbHeader��5"      $��Update Category��5      $��20(�5      $
��Bold"�5      $��Center=�5       $��5q�5!      5"      �� 5$   
   $��Category Information��6   $��1��5%      $��5q�5&      
���   �$	��170��5(      $	��300��5)      $��15(�5*      $��SemiBold"�5+      .��5,      �  5-      �� 5.      �� 5/      �� 50      �� 51       � ColumnDefinitions 54      �� 55      $
��auto �6'   �� 56      .+�59      �� $
��Id: ��6   $��Center=�5:      $��5q�5;      �� 5=      $��1��6   
������� �� 
IsReadOnly . $��Center=�5@      $��5q�5A      ��5B      �� *NewCategoryID+�� 5D      $��Name: ��6   $��1��5E      $��Center=�5F      $��5q�5G      �� 5I      -   5        $��txtName��5M      $��1��5I      $��1��5J      $��Center=�5K      $��5q�5L      .��5M   )   ��5N      �� 5O       �� Path$ CategoryName�6"    �� UpdateSourceTrigger$ PropertyChanged=�5P   "   	 �� Mode$	 TwoWay=�5Q   "   
 �� ValidationRules
 5R      +   %HungVuong_C5_Assignment.InputTextRule  5S   "   5U      .��5V   $   .  (System.Windows.Interactivity.Interaction   Triggers 5X      /  )System.Windows.Interactivity.EventTrigger  5Y         	EventName$ TextChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5Z      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *NameTextChangedCommand+   CommandParameter 5[   4   �� 5\      .��5]   .   5^      �� 5`      $��Created At: ��6   $��2��5a      $��5q�5b      $��Center=�5c      �� 5e      $��1��6   $��2��5f      $��5q�5g      
������� . $��Center=�5k      ��5j      �� *	CreatedAt+ �� StringFormat$ 
dd/MM/yyyy��5k      �� 5m      $��Modified At: ��6   $��3��5n      $��5q�5o      $��Center=�5p      �� 5r      $��1��6   $��3��5s      $��5q�5t      
������� . $��Center=�5x      ��5w      �� *
ModifiedAt+$ 
dd/MM/yyyy��5x      5y      5z      � 5|   
   $��2��6   $��5q�5}       5~      �� 5      �� 5�      .+�5�      �� $��Update��6   $��5q�5�        ButtonBasicStyle#��[ 5�      $��Stretch=�5�      $��Stretch=�5�      
��� ���
����  ���5�      �� *UpdateCommand+{�5�      �� *IsEnabledAdd+�� 5�      $��Cancel��6   $��1��5�      $��5q�5�      ��5�      �� *CancelCommand+5�      5�      5�      