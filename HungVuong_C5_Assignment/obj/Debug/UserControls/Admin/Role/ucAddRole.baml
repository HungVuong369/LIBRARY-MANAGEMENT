   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      '    !HungVuong_C5_Assignment.ucAddRole   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Add Role��6   $��20(�5      $
��Bold"�5      $��Center=�5      $��Center=�5      $��Center=�5      $��Center=�5      $��0��5      �� 5   
   $��	Name Role��6   $��1��5      $��14(�5      $��SemiBold"�5      $��Center=�5       $	��7 0q�5!      �� 5#   
   -   5        $��txtNameRole��5&      $��2��5#      $��Center=�5$      $
��Left=�5%      $
��10 0q�5(      .��5)   0   ��5*      �� 5+       �� Path$ NameRole�6    �� UpdateSourceTrigger$ PropertyChanged=�5,       �� ValidationRules 5-      0   *HungVuong_C5_Assignment.InputTextAndNumber  5.      50      .��51      52      �� 54   
   $��14(�6   $��SemiBold"�55      $��Center=�56      $��3��57      $��Group��58      $��7 10 7 0q�59      �� 5;   
   -   5        $��cbGroup��5=      $��4��5;      $��Center=�5<      $
��10 0q�5>      5@      � 5B   
   $��5��6    � ColumnDefinitions 5C      �� 5D      �� 5E      .+�5H      �� -   5        $��btnAdd��5K      $��0��5H      $	��Add��5I      $��10 15q�5J      {�.  5M      �� 5O      -   5        $��btnClose��5R      $��1��5O      $��Cancel��5P      $��10 15q�5Q      {�. 5T      5U      5V      5W      