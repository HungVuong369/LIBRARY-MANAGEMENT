   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5   	   #    HungVuong_C5_Assignment.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:HungVuong_C5_Assignment     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Login��5	   	   $	��300��6   $	��300��6$   .��5      � ��5   
   �� 5       �� ImageSource$ /Assets/Images/11.jpg��6   .+�5   
   �� ���#0F1824 �� CornerRadius$ 10��5      $��30q�5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ #121C2C��6#      	Direction$	 150Q�63      ShadowDepth$ 6Q�6C      Opacity$	 0.3Q�6S   ._�5      � 	 � RowDefinitions	 5      �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   .+�5      �� $��10q�6   $��Login��5       ���#E1E1E3$��Center=�5"      $��18(�5#      $��0��5$      �� 5&      -   5        $��txtUsername��5&      $��1��5'         FloatingLabelTextBoxStyle#��[  6'   

 � Tag$
 Username��6Z   ���#9DA0A4 �� 
CaretBrush
 �����5*      �� 5+      -   5        $��txtPassword��5+      $��2��5,      #��[  6'   $
 Password��5-      ���#9DA0A4$��5 20 5 0q�5/      
 �����53      �� 54      -   5        $��btnLogin��54      $��Login��55      
������ $��3��57      $��	5 15 5 10q�58      ���#06B9C4$��2q�5:      $��25��5;        LoginBasicStyle#��[ 5<      5>      �� 5@      -   5        $��btnBackToConnect��5@      $��Back to connect form��5A      
������ $��4��5C      $	��5 0q�5D      ���#06B9C4$��2q�5F      $��25��5G      #��[ 5H      5J      5K      5L      5M      5N      