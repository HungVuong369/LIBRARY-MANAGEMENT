   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      ,    &HungVuong_C5_Assignment.ucAddBookTitle   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Add Book Title��6   $��20(�5      $
��Bold"�5      $��Center=�5      � 5   
   $��1��6   $��5q�5      $	��390��5      $	��300��5        5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5       $
��auto �6    �� 5!      $
��auto �6    �� 5"      $
��auto �6    �� 5#      $
��auto �6    .+�5&      �� $��Name: ��6   $��14(�5'      $��SemiBold"�6&   $��0 0 0 5q�5(      $��0��5)      �� 5+      -   5        $��txtBookTitleName��5+      $��1��5.      .��6#   ��5/      �� 50       �� Path$
 Name�6    �� Mode$ TwoWay=�51       �� UpdateSourceTrigger$ PropertyChanged=�52       �� ValidationRules 53      0   *HungVuong_C5_Assignment.InputTextAndNumber  54      56      .��57       58      �� 5:      $��Category��6   $��14(�5;       $��SemiBold"�6.   $��0 10 0 5q�5<       $��2��5=      �� 5>      -   5        $��
cbCategory��5>       �� DisplayMemberPath$
 Name��5A      $��3��5B      ��5?      �� *
Categories+ �� SelectedItem 5@      �� *SelectedCategory+$ PropertyChanged=�5B      �� 5D      $��	Summary: ��6   $��14(�5E      $��SemiBold"�6&   $��0 10 0 5q�5F      $��4��5G      �� 5H      -   5        $��
txtSummary��5H      $��5��5J      .��6#   ��5K      �� 5L      $ Summary�6   $ TwoWay=�5M      $ PropertyChanged=�5N       5O        5P      5R      .��5S       5T      �� 5V      $��Image: ��6   $��14(�5W      $��SemiBold"�6&   $��0 10 0 5q�5X      $��6��5Y      �� 5[      -   5        $��imgBookTitle��5^      $��7��5[      $��0 10 0 5q�5\      $	��150��5]      ��5_      �� *ImageSource+.  (System.Windows.Interactivity.Interaction   Triggers 5`      /  )System.Windows.Interactivity.EventTrigger  5a         	EventName$ MouseLeftButtonDown��6%   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5b      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 60   �� *ChooseImageCommand+   CommandParameter 5c   0   �� 5d      5f      � 5h      $��8��6   $
��0 10q�5i       � ColumnDefinitions 5j      �� 5k      �� 5l      .+�5o      �� -   5        $��btnAdd��5o      $	��Add��5p      $��0 0 5 0q�5q      ��5r      �� *
AddCommand+{�5s      �� *	isEnabled+$ PropertyChanged=��� 5u      -   5        $��	btnCancel��5u      $��Cancel��5v      $��1��5w      $��5 0 0 0q�5x      ��5y      �� *CancelCommand+5z      5{      5|      5}      