   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  .    (HungVuong_C5_Assignment.ConnectionWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:HungVuong_C5_Assignment       � WindowStartupLocation$  CenterScreen=�$��5q� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � SizeToContent$ WidthAndHeight=� � Title$ ConnectionWindow��$	��300��$	��400��.��� ����  �� ImageSource$ /Assets/Images/1.jpg�� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��LIBRARY MANAGEMENT��$��Center=�$��20(�$
��Bold"�$��0�����#C3C2C9�� $��1�� �� Orientation$ 
Horizontal=�$��Center=�$��5q�.+��� -   $��lbServerName��$��Server name��$��14(�$��SemiBold"�$��85�����#C3C2C9�� -   $��
txtConnect��$��1��$	��250��$��20�����#1F2029���#C0BFC6�� -   $��	cbConnect��$��1��$��18��$��Center=�$��Center=� �� 
IsReadOnly .  $��20���� $��2��$ 
Horizontal=�$��5 10 5 5q�$��Center=�.+��� -   $��lbDatasource��$��Data source��$��14(�$��SemiBold"�$��85�����#C3C2C9�� -   $��txtDataSource��$��1��$	��250��$��20�����#1F2029���#C0BFC6�� -   $��cbDataSource��$��1��$��18��$��Center=�$��Center=� .  $��20��	 �� SelectedIndex$	 0���� -   $��ckAutoConnect��$��3��$��Auto connect at startup�����#C3C2C9���#C3C2C9$��5 10 5 5q��� $ 
Horizontal=�$��4��$��Center=�$��0 10 0 0q�.+��� -   $��
btnConnect��$��Connect��$	��100��$��5 0 0 10q����#FFEBA7���#203473$��0q�$��25��   ButtonBasicStyle#��[  �� -	   $��btnClose��$��Close��$	��100��$��5 0 0 10q����#FFEBA7���#203473$��0q�$��25��#��[  