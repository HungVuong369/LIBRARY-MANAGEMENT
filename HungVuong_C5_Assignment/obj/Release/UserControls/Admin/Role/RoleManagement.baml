   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  ,    &HungVuong_C5_Assignment.RoleManagement   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     .���   � RowDefinitions  �� $
��auto ��� $��* �.+��� $��Role Management��$��20(�$��Center=�$
��Bold"�� $��1��.+��   �� $
��auto ��� $
��auto ��� $��* �.+��� -   $��	lbTabMenu��$��0��   HorizontalListBox#��[   �� SelectedIndex$ 0��$
��10 5q�.@��� .��
Management�� .��Feature Assignment�� .��	View Role� -   $��grdManagement��$��1��$
��10 5q� � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+��� -   $��	txtSearch��  FloatingLabelTextBoxStyle#��[ 
 � Tag$ Search��$��2���� -   $��btnAdd��$��1��$	��Add��$	��100��  ButtonBasicStyle#��[ ���#007ACC$��25��$��Right=�$��0 0 10 0q�d� -   $��toggleButton��$��0��$ User Assignment��$
��Left=�$��28��0   *HungVuong_C5_Assignment.ucUserRoleDataGrid  -     Name$ ucUserRoleDataGrid��$��2��$
��10 0q�,   &HungVuong_C5_Assignment.ucRoleDataGrid  -     Name$ ucRoleDataGrid��$��2��$y�	Collapsed=�$
��10 0q�� -   $��grdFeatureAssignment��$��2��.+�/   )HungVuong_C5_Assignment.FeatureAssignment  -	     Name$ ucFeatureAssignment��$y�	Collapsed=�$
��10 0q�