   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      3    -HungVuong_C5_Assignment.ucConfirmRestoreAdult   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   �� $��Confirm Restore��6   $
��Bold"�5      $��20(�5      $��Center=�5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      6%   �� 5      6%   �� 5      6%   �� 5      6%   .+�5      � -   5        $��grdChildReader1��5      $��0��5      $��10q�5        5       �� 5!      $
��auto �6$   64   �� 5"      6&   .+�5%      �� $��0��6   
���   �$��2 2 2 0q�5'      $��5 5 5 0q�5(      ._�5)      �� $ ��Child Reader Information 1��6    $��18(�5*      $��SemiBold"�5+      $��Center=�5,      $
��Wrap=�5-      62   5.      �� 50      $��1��6   
���   �$��2q�52      $��5 0 5 5q�53      ._�54      �� .+�55      �� $��5q�6]   $��14(�56   (   $��SemiBold"�66   $
��Wrap=�57   (   ��55   $   �� *ChildReader1.Id+ �� StringFormat$ Id: {0}��57   (   $   HungVuong_C5_Assignment.ucLine  58      �� 59      $��5q�6c   $��14(�5:   (   $��SemiBold"�66   $
��Wrap=�5;   (   ��59   $   �� *FullNameChild1+$ Full Name: {0}��5;   (     5<      �� 5=      $��5q�6`   $��14(�5>   (   $��SemiBold"�66   $
��Wrap=�5?   (   ��5=   $   �� *ChildReader1.boF+$ BoF: {0}��5?   (     5@      �� 5A      $��5q�6m   $��14(�5B   (   $��SemiBold"�66   $
��Wrap=�5C   (   ��5A   $   �� *ChildReader1.ReaderType+$ ReaderType: {0}��5C   (     5D      �� 5E      $��5q�6k   $��14(�5F   (   $��SemiBold"�66   $
��Wrap=�5G   (   ��5E   $   �� *ChildReader1.CreatedAt+$ CreatedAt: {0}��5G   (     5H      �� 5I      $��5q�6m   $��14(�5J   (   $��SemiBold"�66   $
��Wrap=�5K   (   ��5I   $   �� *ChildReader1.ModifiedAt+$ ModifiedAt: {0}��5K   (     5L      �� 5M      $��5q�6e   $��14(�5N   (   $��SemiBold"�66   $
��Wrap=�5O   (   ��5M   $   �� *ChildReader1.Status+$ Status: {0}��5O   (   5P      5Q      5R      � 5T      -   5        $��	grdChild1��5T      $��1��5U      $��10q�5V        5W      �� 5X      $
��auto �6$   64   �� 5Y      6&   .+�5\      �� $��0��6   
���   �$��2 2 2 0q�5^      $��5 5 5 0q�5_      ._�5`      �� $��Child Information 1��6    $��18(�5a      $��SemiBold"�5b      $��Center=�5c      $
��Wrap=�5d      62   5e      �� 5g      $��1��6   
���   �$��2q�5i      $��5 0 5 5q�5j      ._�5k      �� .+�5l      �� $��5q�6f   $��14(�5m   (   $��SemiBold"�66   $
��Wrap=�5n   (   ��5l   $   �� *Child1.CreatedAt+$ Created At: {0}��5n   (     5o      �� 5p      $��5q�6h   $��14(�5q   (   $��SemiBold"�66   $
��Wrap=�5r   (   ��5p   $   �� *Child1.ModifiedAt+$ Modified At: {0}��5r   (   5s      5t      5u      � 5w      -   5        $��grdChildReader2��5w      $��2��5x      $��10q�5y      $y�	Collapsed=�5z        5{      �� 5|      $
��auto �6$   64   �� 5}      6&   .+�5�      �� $��0��6   
���   �$��2 2 2 0q�5�      $��5 5 5 0q�5�      ._�5�      �� $ ��Child Reader Information 2��6    $��18(�5�      $��SemiBold"�5�      $��Center=�5�      $
��Wrap=�5�      62   5�      �� 5�      $��1��6   
���   �$��2q�5�      $��5 0 5 5q�5�      ._�5�      �� .+�5�      �� $��5q�6]   $��14(�5�   (   $��SemiBold"�66   $
��Wrap=�5�   (   ��5�   $   �� *ChildReader2.Id+$ Id: {0}��5�   (     5�      �� 5�      $��5q�6c   $��14(�5�   (   $��SemiBold"�66   $
��Wrap=�5�   (   ��5�   $   �� *FullNameChild2+$ Full Name: {0}��5�   (     5�      �� 5�      $��5q�6`   $��14(�5�   (   $��SemiBold"�66   $
��Wrap=�5�   (   ��5�   $   �� *ChildReader2.boF+$ BoF: {0}��5�   (     5�      �� 5�      $��5q�6m   $��14(�5�   (   $��SemiBold"�66   $
��Wrap=�5�   (   ��5�   $   �� *ChildReader2.ReaderType+$ ReaderType: {0}��5�   (     5�      �� 5�      $��5q�6k   $��14(�5�   (   $��SemiBold"�66   $
��Wrap=�5�   (   ��5�   $   �� *ChildReader2.CreatedAt+$ CreatedAt: {0}��5�   (     5�      �� 5�      $��5q�6m   $��14(�5�   (   $��SemiBold"�66   $
��Wrap=�5�   (   ��5�   $   �� *ChildReader2.ModifiedAt+$ ModifiedAt: {0}��5�   (     5�      �� 5�      $��5q�6e   $��14(�5�   (   $��SemiBold"�66   $
��Wrap=�5�   (   ��5�   $   �� *ChildReader2.Status+$ Status: {0}��5�   (   5�      5�      5�      � 5�      -   5        $��	grdChild2��5�      $��4��5�      $��10q�5�      $y�	Collapsed=�5�        5�      �� 5�      $
��auto �6$   64   �� 5�      6&   .+�5�      �� $��0��6   
���   �$��2 2 2 0q�5�      $��5 5 5 0q�5�      ._�5�      �� $��Child Information 2��6    $��18(�5�      $��SemiBold"�5�      $��Center=�5�      $
��Wrap=�5�      62   5�      �� 5�      $��1��6   
���   �$��2q�5�      $��5 0 5 5q�5�      ._�5�      �� .+�5�      �� $��5q�6f   $��14(�5�   (   $��SemiBold"�66   $
��Wrap=�5�   (   ��5�   $   �� *Child2.CreatedAt+$ Created At: {0}��5�   (     5�      �� 5�      $��5q�6h   $��14(�5�   (   $��SemiBold"�66   $
��Wrap=�5�   (   ��5�   $   �� *Child2.ModifiedAt+$ Modified At: {0}��5�   (   5�      5�      5�      5�      �� 5�   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�5�      $��10q�5�      .+�5�      �� -   5        $��btnRestoreAdult��5�      $��Restore adult��5�      $	��250��5�         ButtonBasicStyle#��[  5�      
��� ���
���   �$��0 0 10 0q�5�      6)   �� 5�      -   5        $��
btnRestore��5�      $!��Restore all child and adult��5�      $	��250��5�      $��0 0 10 0q�5�      #��[  5�      
��� ���
���   �5�   *   �� 5�      -   5        $��	btnCancel��5�      $��Cancel��5�      $	��250��5�      6#   5�      5�      5�      