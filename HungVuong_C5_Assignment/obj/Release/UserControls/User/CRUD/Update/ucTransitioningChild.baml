   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  2    ,HungVuong_C5_Assignment.ucTransitioningChild   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     .���   � RowDefinitions  �� $
��auto ��� $��* ��� $
��auto ��� $��* �.+��� $��Transitioning Child��$��20(�$��Center=�$
��Bold"���  �� Orientation$ Vertical=�$��1��$��10q�.+��� $ Vertical=�.+��� $��Search by identify��$��14(�$��SemiBold"��� -   $��
txtSearch1���  � ColumnDefinitions �� $
��auto ��� $��* �.+��� -   $��lbSelectAdult1��$��Select an adult��$��14(�$��SemiBold"��� -   $��lbSelectChild��$��Select a child��$��14(�$��SemiBold"�
������ �� $ 
Horizontal=�$��Center=�$��1��$��5q�.+��� -   $��btnBack1��$	��◀��$��1��$��40��$��25��{�.  �� -   $��lbPage1��$	��1/2��$��14(�$��2��$��SemiBold"�$
��10 0q��� -   $��btnNext1��$	��▶��$��3��$��25��$��40��{�.  =   7HungVuong_C5_Assignment.ucAdultAndQuantityChildDataGrid  -     Name$ ucAdultDataGrid1��-   'HungVuong_C5_Assignment.ucChildDataGrid  -     Name$ ucChildDataGrid1��$y�	Collapsed=��� $��2��$ 
Horizontal=�$��Center=�$��10q�.+��� -	   $��btnTransition��$	��↓��$	��100��$��16(�$
��Bold"�$��0 0 10 0q��� -
   $��btnTransitionAll��$	��↧��$	��100��$��16(��� $��3��$��10q�.+��� $ Vertical=�.+��� $��Search by identify��$��14(�$��SemiBold"��� -   $��
txtSearch2���  �� $
��auto ��� $��* �.+��� -   $��lbSelectAdult2��$��Select an adult��$��14(�$��SemiBold"��� $ 
Horizontal=�$��Center=�$��1��$��5q�.+��� -   $��btnBack2��$	��◀��$��1��$��40��{�.  $��25���� -   $��lbPage2��$	��1/2��$��14(�$��2��$��SemiBold"�$
��10 0q��� -   $��btnNext2��$	��▶��$��3��$��40��$��25��{�.    -   $ ucAdultDataGrid2��  -   $ ucChildDataGrid2��$y�	Collapsed=�