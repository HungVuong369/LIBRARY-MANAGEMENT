   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5   	   &     HungVuong_C5_Assignment.UserMenu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:HungVuong_C5_Assignment     5   	   -   5        $��
mainWindow��5	   	     � WindowStartupLocation$  CenterScreen=�5   	   $y�Visible=�5
   	    � WindowState$ 	Maximized=�5   	    � Title$ 	MainMenu1��5   	   $
��1000��6   $
��1000��6)    � 	Resources 5         PageTitleHeaderStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Orientation	 � RowDefinitions,   &HungVuong_C5_Assignment.ucUserInfoShow
  Name,   &HungVuong_C5_Assignment.ucUserInfoShow   Loaded  ButtonBasicStyle �� Triggers P� 
SourceName P� Property P� Value �� 
TargetName ]� 
Conditions �� 
SourceName �� Property �� Value��%q  &	        7  �� 5   
   " ��6-   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $��spHeader��5   )   $ Vertical=�5   )   $��Right=�5   )   $��Center=�5   )   
������ .+�5   "   �� $��spAdmin��5   -   $ 
Horizontal=�5   -   $��Right=�5   -   .+�5   &   �� $��/Assets/Images/User.png��6,   $��50��6M   $��30��6X   $��10q�6d   $��Right=�5   (   $��Center=�5   (   �� 5   &   -   5        $
��User��5   0   $��Center=�6<   $��0 0 10 0q�6W   $��16(�5   ,   $��SemiBold"�5    ,   5!   0   5"   #   � 5#   "   $��userInfoGrid��6'   
�������$y�	Collapsed=�6R   	 5$   &   �� 5%   *   �� 5&   *   .+�5)   &     $
 
ucUserInfo��6;    ucUserInfo_Loaded5*   ;   �� 5,   &   -   5        $��1��5,   -   $��Logout��5-   -   $	��100��5.   -   $��25��5/   -   $��0 0 0 10q�50   -   $��Center=�51   -   $��Center=�52   -   8��  
������ ���#0C1C2F56   -   57   #   58      59       5;      P� 5<      $ spHeader��6&    �@J�IsMouseOver . . �5=   "   �� $ userInfoGrid��6)    � y�$ Visible=�6Y   5>      P� 5@      $ spHeader��6&    �@J�IsMouseOver .  . �5A   "   �� $ userInfoGrid��6)    � y�$ Visible=�6Y   5B      ]� 5D       5E   "   �� 5F   &   $ spAdmin��60    �@J�IsMouseOver .  6\   �� 5G   &   $ spHeader��60    �@J�IsMouseOver .  6]   �� 5H   &   $ userInfoGrid��60    �@J�IsMouseOver .  6a   ./�5K   "   �� $ userInfoGrid��6)    � y�$ 	Collapsed=�6Y   5L      5N      5P      5Q      5R      .��5T      �   main_Background#��[ 6    � ColumnDefinitions 5U   
   �� 5V      $
��auto �6   6.   �� 5W      6!   .+�5Z   
   � -   5        $��grdContainer��5\      $��0��5Z      ���#212121	 5]      �� 5^      $
��auto �6    60   �� 5_      6"   .+�5b      R� -   5        $��TreeView��5b      $��1��5c      $��0q�5d      $��54��5e      
������ $��Disabled=�5g      ��5h      �� 5i      " R�6     TreeViewStyle �� BasedOn# [ 62    �� Triggers 5j      :� 5k       :� RoutedEvent$ UIElement.MouseEnter��6+   .[�5l   "   �� .��5m   &   �� .��5n   *   ��  �� TargetProperty$3 -(TreeView.Foreground).(SolidColorBrush.Color)�69   	 �� To$ #D4D9E3X�5o   9    g� Duration$ 0:0:0.3D�6F   W� 5p   *   $ Width�6:   	 W� To$	 268X�6\   $ 0:0:0.3D�6e   5q   '   5r   #   5s      :� 5u      $ UIElement.MouseLeave��6+   .[�5v   "   �� .��5w   &   �� .��5x   *   �� $3 -(TreeView.Foreground).(SolidColorBrush.Color)�69   $ TransparentX�5y   9   $ 0:0:0.3D�6J   W� 5z   *   $ Width�6:   $ 54X�6\   $ 0:0:0.3D�6d   5{   '   5|   #   5}      5      .@�5�      Q� -   5        $��Statistical��5�      
 � Tag$ /Assets/Images/14.png��5�      ���#212121$��5q�5�      $��5q�5�      6,   5�      5�      � 5�   
   -   5        $��grdMain��5�      $��1��6   $��Center=�6.   $	��Top=�6K   5�      �� 5�   
   #��[  6   $	��Top=�5�      $��1��5�      5�      5�      