   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  3    -HungVuong_C5_Assignment.ucConfirmRestoreAdult   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     .���   � RowDefinitions  �� $
��auto ��� $
��auto ��� $
��auto �.+��� $��Confirm Restore��$
��Bold"�$��20(�$��Center=�� $��1�� � ColumnDefinitions �� �� �� �� .+�� -   $��grdChildReader1��$��0��$��10q�  �� $
��auto ��� .+��� $��0��
���   �$��2 2 2 0q�$��5 5 5 0q�._��� $ ��Child Reader Information 1��$��18(�$��SemiBold"�$��Center=�$
��Wrap=��� $��1��
���   �$��2q�$��5 0 5 5q�._��� .+��� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *ChildReader1.Id+ �� StringFormat$ Id: {0}��$   HungVuong_C5_Assignment.ucLine  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *FullNameChild1+$ Full Name: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *ChildReader1.boF+$ BoF: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *ChildReader1.ReaderType+$ ReaderType: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *ChildReader1.CreatedAt+$ CreatedAt: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *ChildReader1.ModifiedAt+$ ModifiedAt: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *ChildReader1.Status+$ Status: {0}��� -   $��	grdChild1��$��1��$��10q�  �� $
��auto ��� .+��� $��0��
���   �$��2 2 2 0q�$��5 5 5 0q�._��� $��Child Information 1��$��18(�$��SemiBold"�$��Center=�$
��Wrap=��� $��1��
���   �$��2q�$��5 0 5 5q�._��� .+��� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *Child1.CreatedAt+$ Created At: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *Child1.ModifiedAt+$ Modified At: {0}��� -   $��grdChildReader2��$��2��$��10q�$y�	Collapsed=�  �� $
��auto ��� .+��� $��0��
���   �$��2 2 2 0q�$��5 5 5 0q�._��� $ ��Child Reader Information 2��$��18(�$��SemiBold"�$��Center=�$
��Wrap=��� $��1��
���   �$��2q�$��5 0 5 5q�._��� .+��� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *ChildReader2.Id+$ Id: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *FullNameChild2+$ Full Name: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *ChildReader2.boF+$ BoF: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *ChildReader2.ReaderType+$ ReaderType: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *ChildReader2.CreatedAt+$ CreatedAt: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *ChildReader2.ModifiedAt+$ ModifiedAt: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *ChildReader2.Status+$ Status: {0}��� -   $��	grdChild2��$��4��$��10q�$y�	Collapsed=�  �� $
��auto ��� .+��� $��0��
���   �$��2 2 2 0q�$��5 5 5 0q�._��� $��Child Information 2��$��18(�$��SemiBold"�$��Center=�$
��Wrap=��� $��1��
���   �$��2q�$��5 0 5 5q�._��� .+��� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *Child2.CreatedAt+$ Created At: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *Child2.ModifiedAt+$ Modified At: {0}���� $��2�� �� Orientation$ 
Horizontal=�$��Center=�$��10q�.+��� -   $��btnRestoreAdult��$��Restore adult��$	��250��   ButtonBasicStyle#��[  
��� ���
���   �$��0 0 10 0q��� -   $��
btnRestore��$!��Restore all child and adult��$	��250��$��0 0 10 0q�#��[  
��� ���
���   ��� -   $��	btnCancel��$��Cancel��$	��250��