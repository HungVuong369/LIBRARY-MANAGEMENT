   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  #    HungVuong_C5_Assignment.Login   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:HungVuong_C5_Assignment     -     � WindowStartupLocation$  CenterScreen=� � Title$ Login��$	��300��$	��300��.��� ����  �� ImageSource$ /Assets/Images/11.jpg��.+��� ���#0F1824 �� CornerRadius$ 10��$��30q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ #121C2C��   	Direction$	 150Q�   ShadowDepth$ 6Q�   Opacity$	 0.3Q�._�� 	 � RowDefinitions	 �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��10q�$��Login�����#E1E1E3$��Center=�$��18(�$��0���� -   $��txtUsername��$��1��   FloatingLabelTextBoxStyle#��[  

 � Tag$
 Username�����#9DA0A4 �� 
CaretBrush
 ������� -   $��txtPassword��$��2��#��[  $
 Password�����#9DA0A4$��5 20 5 0q�
 ������� -   $��btnLogin��$��Login��
������ $��3��$��	5 15 5 10q����#06B9C4$��2q�$��25��  LoginBasicStyle#��[ �� -   $��btnBackToConnect��$��Back to connect form��
������ $��4��$	��5 0q����#06B9C4$��2q�$��25��#��[ 