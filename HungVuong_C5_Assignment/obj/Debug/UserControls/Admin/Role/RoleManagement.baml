   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      ,    &HungVuong_C5_Assignment.RoleManagement   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��Role Management��6   $��20(�5      $��Center=�5      $
��Bold"�5      � 5   
   $��1��6   .+�5      �   5      �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $��* �6$   .+�5      �� -   5        $��	lbTabMenu��5      $��0��5         HorizontalListBox#��[  6'    �� SelectedIndex$ 0��5      $
��10 5q�5       .@�5!      �� .��6"   
Management6.   �� 5"      .��6"   Feature Assignment66   �� 5#      .��6"   	View Role6-   5$      � 5&      -   5        $��grdManagement��5'      $��1��5&      $
��10 5q�5(       � ColumnDefinitions 5)      �� 5*      $��* �6+   �� 5+      $��* �6+   �� 5,      $��* �6+   .+�5/      �� -   5        $��	txtSearch��51        FloatingLabelTextBoxStyle#��[ 5/      
 � Tag$ Search��50      $��2��53      �� 55      -   5        $��btnAdd��5;      $��1��55      $	��Add��56      $	��100��57        ButtonBasicStyle#��[ 58      ���#007ACC$��25��5:      $��Right=�5=      $��0 0 10 0q�5>      d� 5@      -   5        $��toggleButton��5D   #   $��0��5@   #   $ User Assignment��5A   #   $
��Left=�5E   #   $��28��5F   #   5G      0   *HungVuong_C5_Assignment.ucUserRoleDataGrid  5I      -   5          Name$ ucUserRoleDataGrid��5J      $��2��5I   +   $
��10 0q�5K   +   ,   &HungVuong_C5_Assignment.ucRoleDataGrid  5M      -   5          Name$ ucRoleDataGrid��5N   '   $��2��5M   '   $y�	Collapsed=�5O   '   $
��10 0q�5P   '   � 5Q      -   5        $��grdFeatureAssignment��5Q   $   $��2��6   .+�5R      /   )HungVuong_C5_Assignment.FeatureAssignment  -	   5          Name$ ucFeatureAssignment��5R   .   $y�	Collapsed=�5S   .   $
��10 0q�5T   .   5U      5V      5W      5X      5Y      