   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  '    !HungVuong_C5_Assignment.InputUser   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     .���   � ColumnDefinitions  �� �� .+�� $��0��$��10q� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $
��User��$��Center=�$��16(�$��SemiBold"��� $��Username��$��1��$��14(�$��SemiBold"��� -   $��txtUsername��$��2��.������  �� Path$ Username� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidationRules 5   /HungVuong_C5_Assignment.InputOnlyPhoneAndNumber  .���� $��Password��$��3��$��14(�$��SemiBold"�$��0 10 0 0q��� -   $��txtPassword��$��4��.������ $ Password�$ PropertyChanged=� 0   *HungVuong_C5_Assignment.InputTextAndNumber  .���� $��
Created At��$��5��$��14(�$��0 10 0 0q�$��SemiBold"��� -   $��txtCreatedAt��$��6��{�.  �� $��Modified At��$��7��$��0 10 0 0q�$��14(�$��SemiBold"��� -   $��txtModifiedAt��$��8��{�.  � $��1��$��10q� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��	User Info��$��Center=�$��16(�$��SemiBold"��� $��	Last Name��$��1��$��14(�$��SemiBold"��� -   $��txtLName��$��2��.������ $ LName�$ PropertyChanged=� +   %HungVuong_C5_Assignment.InputTextRule  .���� $��
First Name��$��3��$��0 10 0 0q�$��14(�$��SemiBold"��� -   $��txtFName��$��4��.������ $ FName�$ PropertyChanged=�   .���� $��Phone��$��5��$��0 10 0 0q�$��14(�$��SemiBold"��� -   $��txtPhone��$��6�� �� 	MaxLength$ 10��.������ $ Phone�$ PropertyChanged=� ,   &HungVuong_C5_Assignment.InputPhoneRule  .���� $��Address��$��7��$��0 10 0 0q�$��14(�$��SemiBold"��� -   $��
txtAddress��$��8��.������ $ Address�$ PropertyChanged=�   .��