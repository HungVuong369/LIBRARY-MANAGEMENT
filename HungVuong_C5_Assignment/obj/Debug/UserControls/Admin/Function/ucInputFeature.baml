   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      ,    &HungVuong_C5_Assignment.ucInputFeature   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      .��5	      �� $��1��6     �� Orientation$  Vertical=�6   $��10q�5
      $	��300��5      .+�5   
   �� $
��Name��6   $��14(�5      $��SemiBold"�6"   �� 5   
   -   5        $��txtName��5      .��5   8   ��5      �� 5       �� Path$ NameFeature�6    �� UpdateSourceTrigger$ PropertyChanged=�5       �� ValidationRules 5      +   %HungVuong_C5_Assignment.InputTextRule  5      5      .��5      5      �� 5   
   $��Description��6   $��14(�5      $��SemiBold"�6&   $��0 10 0 0q�5      �� 5   
   -   5        $��txtDescription��5      .��5    8   ��5!      �� 5"      $ Description�6   $ PropertyChanged=�5#       5$      0   *HungVuong_C5_Assignment.InputTextAndNumber  5%      5'      .��5(      5)      �� 5+   
   $��Parent��6   $��14(�5,      $��SemiBold"�6&   $��0 10 0 0q�5-      � 5/   
    � ColumnDefinitions 50      �� 51      �� 52      $
��auto �6#   .+�55      �� -   5        $��	txtParent��58       �� 
IsReadOnly . $
��None��56      $��0��57      58      �� 5:      -   5        $��	btnSelect��5:      $��Select��5;      $��1��6*      ButtonDefault#��[  5<      $��0q�5=      $��0q�5>      $��18��5?      $��14(�5@      $	��100��5A      
����  �5C      5D      �� 5F   
   $��	Url Image��6   $��14(�5G      $��SemiBold"�6&   $��0 10 0 0q�5H      �� 5J   
   -   5        $��txtUrlImage��5J      $��	Click me!��5K       . 5M      �� 5O   
   -   5        $��
imgFeature��5O      $	��100��5P      $	��100��5Q      5R      5S      