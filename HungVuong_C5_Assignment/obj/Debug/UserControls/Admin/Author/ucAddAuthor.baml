   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      )    #HungVuong_C5_Assignment.ucAddAuthor   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5        � 	Resources  5
         ValidationErrorTemplate �� 
TargetType �� Property �� Value��%	  &	        '�� �     7   �� 5   
   .R�5      ]� .+�5      �� 
���  ��$��12(�6-   $��0 20 0 0q�5      ��5   ;   �� *ErrorContent+5      5      5      �� 5   
   " ��6   .�5      ��  �@=�ErrorTemplate8   69   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   �� $��
Add Author��6   $��20(�5      $
��Bold"�5       $��Center=�5!      $��5q�5"      �� 5$   
   $��15(�6   $��SemiBold"�5%      
���   �$��Author Information��5'      $��1��5(      $	��200��5)      $	��500��5*      $��5q�5+      .��5,      �  � ColumnDefinitions 5-      �� 5.      �� 5/      .+�52      �  53      �� 54      �� 55      �� 56      �� 57       5:      �� 5;      $
��auto �6+   �� 5<      .+�5?      �� $
��Id: ��6    $��Center=�5@       �� 5A      $��1��6   
������� �� 
IsReadOnly . $��Center=�5E      ��5D      �� *NewAuthorID+5E      �� 5G      $��Name: ��6    $��1��5H       $��Center=�5I       �� 5J      -   5        $��txtName��5M      $��1��5J      $��1��5K      $��Center=�5L      .��5M   -   ��5N      �� 5O       �� Path$ 
AuthorName�6&    �� UpdateSourceTrigger$ PropertyChanged=�5P   &   	 �� Mode$	 TwoWay=�5Q   &   
 �� ValidationRules
 5R   "   +   %HungVuong_C5_Assignment.InputTextRule  5S   &   5U      .��5V   (   .  (System.Windows.Interactivity.Interaction   Triggers 5X      /  )System.Windows.Interactivity.EventTrigger  5Y         	EventName$ TextChanged��6-   .  (System.Windows.Interactivity.TriggerBase   Actions. 5Z   "   6  0System.Windows.Interactivity.InvokeCommandAction     Command 68   �� *NameTextChangedCommand+   CommandParameter 5[   -   �� 5\      .��5]   2   5_      �� 5a      $��BoF: ��6    $��2��5b       $��Center=�5c       (  "System.Windows.Controls.DatePicker  5d      $��1��6!   $��2��5e   !    � Language$ vi-VN�5f   !   $��Center=�5g   !      DisplayDateStart$ 
1753-01-01X�5h   !      DisplayDateEnd$ 
9999-12-31X�5i   !      SelectedDate 5j   !   �� *BoF+�� 5l      $��Created At: ��6    $��3��5m       $��Center=�5n       �� 5o      $��1��6   $��3��5p      
������� . $��Center=�5t      ��5s      �� *	CreatedAt+ �� StringFormat$ 
dd/MM/yyyy��5t      5u      � 5w      $��1��6   $��10 0 0 0q�6'    5x      �� 5y      $
��auto �6+   �� 5z       5}      �� 5~      �� 5      �� 5�      �� 5�      .+�5�      �� $��Description: ��6    $��Center=�5�       �� 5�      -   5        $��txtDescription��5�      $��1��5�      $��Center=�5�       �� TextWrapping$
 Wrap=�5�      .��62    5�        5�      $ TextChanged��6-   . 5�   "      68   �� *NameTextChangedCommand+ 5�   -   �� 5�      .��5�   2   ��5�      �� 5�      $ Description�6&   $ PropertyChanged=�5�   &   $	 TwoWay=�5�   &   
 5�   "   5   /HungVuong_C5_Assignment.InputOnlyPhoneAndNumber  5�   &   5�      .��5�   (   5�      �� 5�      $��	Summary: ��6    $��1��5�       $��Center=�5�       �� 5�      -   5        $��
txtSummary��5�      $��1��5�      $��1��5�      $
 Wrap=�5�      $��Center=�5�      .��69    5�        5�      $ TextChanged��6-   . 5�   "      68   �� *NameTextChangedCommand+ 5�   -   �� 5�      .��5�   2   ��5�      �� 5�      $ Summary�6&   $ PropertyChanged=�5�   &   $	 TwoWay=�5�   &   
 5�   "     5�   &   5�      .��5�   (   5�      5�      5�      5�      � 5�   
   $��2��6   $��5q�5�       5�      �� 5�      �� 5�      .+�5�      �� $	��Add��6   $��5q�5�      {�5�      �� *IsEnabledAdd+��5�      �� *
AddCommand+�� 5�      $��1��6   $��Cancel��5�      $��5q�5�      ��5�      �� *CancelCommand+5�      5�      5�      