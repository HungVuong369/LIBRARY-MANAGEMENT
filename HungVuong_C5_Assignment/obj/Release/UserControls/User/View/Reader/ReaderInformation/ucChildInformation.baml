   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  0    *HungVuong_C5_Assignment.ucChildInformation   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     .���   � RowDefinitions  �� $
��auto ��� .+��� $��Detail Information��$��20(�$
��Bold"�$��Center=�� $��1�� � ColumnDefinitions �� �� �� �� .+�� $��0��$��10q�  �� $
��auto ��� .+��� $��0��
���   �$��2 2 2 0q�$��5 5 5 0q�._��� $��Child Reader Information��$��18(�$��SemiBold"�$��Center=��� $��1��
���   �$��2q�$��5 0 5 5q�._��� .+��� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *ChildReader.Id+ �� StringFormat$ Id: {0}��$   HungVuong_C5_Assignment.ucLine  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *FullNameChild+$ Full Name: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *ChildReader.boF+$ BoF: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *ChildReader.ReaderType+$ ReaderType: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *ChildReader.CreatedAt+$ CreatedAt: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *ChildReader.ModifiedAt+$ ModifiedAt: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *ChildReader.Status+$ Status: {0}��� $��1��$��10q�  �� $
��auto ��� .+��� $��0��
���   �$��2 2 2 0q�$��5 5 5 0q�._��� $��Child Information��$��18(�$��SemiBold"�$��Center=��� $��1��
���   �$��2q�$��5 0 5 5q�._��� .+��� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *Child.CreatedAt+$ Created At: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *Child.ModifiedAt+$ Modified At: {0}��� $��2��$��10q�  �� $
��auto ��� .+��� $��0��
���   �$��2 2 2 0q�$��5 5 5 0q�._��� $!��Guardian Reader Information��$��18(�$��SemiBold"�$��Center=�$
��Wrap=��� $��1��
���   �$��2q�$��5 0 5 5q�._��� .+��� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *AdultReader.Id+$ Id: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *FullNameAdult+$ Full Name: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *AdultReader.boF+$ BoF: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *AdultReader.ReaderType+$ ReaderType: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *AdultReader.CreatedAt+$ CreatedAt: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *AdultReader.ModifiedAt+$ ModifiedAt: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *AdultReader.Status+$ Status: {0}��� $��3��$��10q�  �� $
��auto ��� .+��� $��0��
���   �$��2 2 2 0q�$��5 5 5 0q�._��� $��Guardian Information��$��18(�$��SemiBold"�$��Center=��� $��1��
���   �$��2q�$��5 0 5 5q�._��� .+��� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *Adult.Identify+$ Identify: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *Adult.Address+$ Address: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *
Adult.City+$ 	City: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *Adult.Phone+$ 
Phone: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *Adult.ExpireDate+$ Expire Date: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *Adult.Status+$ Status: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *Adult.CreatedAt+$ CreatedAt: {0}��  �� $��5q�$��14(�$��SemiBold"�$
��Wrap=����� *Adult.ModifiedAt+$ ModifiedAt: {0}��