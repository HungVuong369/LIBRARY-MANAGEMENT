   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  &     HungVuong_C5_Assignment.UserMenu   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:HungVuong_C5_Assignment     -   $��
mainWindow��  � WindowStartupLocation$  CenterScreen=�$y�Visible=� � WindowState$ 	Maximized=� � Title$ 	MainMenu1��$
��1000��$
��1000�� � 	Resources    PageTitleHeaderStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Orientation	 � RowDefinitions,   &HungVuong_C5_Assignment.ucUserInfoShow
  Name,   &HungVuong_C5_Assignment.ucUserInfoShow   Loaded  ButtonBasicStyle �� Triggers P� 
SourceName P� Property P� Value �� 
TargetName ]� 
Conditions �� 
SourceName �� Property �� Value��%�  &	        7  �� " ��.���  � �� �� " ��.R�� .+��� $��spHeader��$ Vertical=�$��Right=�$��Center=�
������ .+��� $��spAdmin��$ 
Horizontal=�$��Right=�.+��� $��/Assets/Images/User.png��$��50��$��30��$��10q�$��Right=�$��Center=��� -   $
��User��$��Center=�$��0 0 10 0q�$��16(�$��SemiBold"�� $��userInfoGrid��
�������$y�	Collapsed=�	 �� �� .+�  $
 
ucUserInfo�� ucUserInfo_Loaded�� -   $��1��$��Logout��$	��100��$��25��$��0 0 0 10q�$��Center=�$��Center=�8��  
������ ���#0C1C2F P� $ spHeader�� �@J�IsMouseOver . . ��� $ userInfoGrid�� � y�$ Visible=�P� $ spHeader�� �@J�IsMouseOver .  . ��� $ userInfoGrid�� � y�$ Visible=�]�  �� $ spAdmin�� �@J�IsMouseOver .  �� $ spHeader�� �@J�IsMouseOver .  �� $ userInfoGrid�� �@J�IsMouseOver .  ./��� $ userInfoGrid�� � y�$ 	Collapsed=�.���   main_Background#��[  � ColumnDefinitions �� $
��auto ��� .+�� -   $��grdContainer��$��0�����#0C1E35	 �� $
��auto ��� .+��� $��/Assets/Images/2.jpg��$	��230��$	��200��R� -   $��TreeView��$��1�����#0C1E35$��0q�.@�Q� -   $��Statistical��
 � Tag$ /Assets/Images/14.png�����#0C1C2F$��0 5 0 5q�� -   $��grdMain��$��1��$��Center=�$	��Top=��� #��[  $	��Top=�$��1��