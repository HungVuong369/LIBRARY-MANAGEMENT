   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5   	   .    (HungVuong_C5_Assignment.ConnectionWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:HungVuong_C5_Assignment     5   	     � WindowStartupLocation$  CenterScreen=�5   	   $��5q�5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStyle$
 None=�5   	    � SizeToContent$ WidthAndHeight=�5   	    � Title$ ConnectionWindow��5   	   $	��300��6"   $	��400��6/   .��5      � ��5   
   �� 5       �� ImageSource$ /Assets/Images/1.jpg��6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��LIBRARY MANAGEMENT��6   $��Center=�5      $��20(�5      $
��Bold"�5      $��0��6"   ���#C3C2C95      �� 5!   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�5"      $��5q�5#      .+�5$      �� -   5        $��lbServerName��5$      $��Server name��5%      $��14(�5&      $��SemiBold"�5'      $��85��5(      ���#C3C2C95)      �� 5*      -   5        $��
txtConnect��5*      $��1��6(   $	��250��65   $��20��5+      ���#1F2029���#C0BFC65-      �� 5/      -   5        $��	cbConnect��50      $��1��5/      $��18��50   (   $��Center=�51      $��Center=�52       �� 
IsReadOnly .  $��20��55      56      �� 58   
   $��2��6   $ 
Horizontal=�6"   $��5 10 5 5q�59      $��Center=�5:      .+�5;      �� -   5        $��lbDatasource��5;      $��Data source��5<      $��14(�5=      $��SemiBold"�5>      $��85��5?      ���#C3C2C95@      �� 5A      -   5        $��txtDataSource��5A      $��1��6+   $	��250��68   $��20��5B      ���#1F2029���#C0BFC65E      �� 5G      -   5        $��cbDataSource��5H      $��1��5G      $��18��5H   '   $��Center=�5I      $��Center=�5J       .  $��20��5M      	 �� SelectedIndex$	 0��5N      5O      �� 5Q   
   -   5        $��ckAutoConnect��5V      $��3��5Q      $��Auto connect at startup��5R      ���#C3C2C9���#C3C2C9$��5 10 5 5q�5U      5X      �� 5Z   
   $ 
Horizontal=�6   $��4��6.   $��Center=�6;   $��0 10 0 0q�5[      .+�5\      �� -   5        $��
btnConnect��5]      $��Connect��5\      $	��100��5^      $��5 0 0 10q�6!   ���#FFEBA7���#203473$��0q�5b      $��25��5c         ButtonBasicStyle#��[  5d      6A   �� 5e      -	   5        $��btnClose��5f      $��Close��5e      $	��100��5g      $��5 0 0 10q�5i      ���#FFEBA7���#203473$��0q�5l      $��25��5m      #��[  5n      6A   5o      5r      5s      