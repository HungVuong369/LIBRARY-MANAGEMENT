   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  '    !HungVuong_C5_Assignment.ucAddBook   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     $��5q�  � 	Resources   �� 
TargetType �� Property �� Value��%2   '��       �� " ��.���  � ��$ 0 5 0 5q�.���  � RowDefinitions �� $
��auto ��� .+��� $��Add Book��$��Center=�$��20(�$
��Bold"�� $��1�� � ColumnDefinitions �� $
��auto ��� .+��� $��0��
���   �$��Book Information��$��15(�$��SemiBold"�$��5q�.����  �� Orientation$ Vertical=�.+��� $��5q�.+��� $��Id��$��14(�$��SemiBold"��� -   $��txtId��{�.  ���� *NewID+�� $��Language��$��14(�$��SemiBold"��� -   $��
cbLanguage��$	��0 5q����� *LstLanguage+ �� SelectedItem �� *SelectedLanguage+ �� UpdateSourceTrigger$ PropertyChanged=��� $��Publish Date��$��14(�$��SemiBold"�(  "System.Windows.Controls.DatePicker  -   $��dpPublishDate��$	��0 5q�	 � Language$	 vi-VN�
   SelectedDate
 �� *SelectedPublishDate+$ PropertyChanged=��� $��Price��$��14(�$��SemiBold"��� -   $��txtPrice������ *Price+$ PropertyChanged=��� $��Quantity��$��14(�$��SemiBold"��� -   $��txtQuantity������ *
Quantity+$ PropertyChanged=��� -   $��btnAdd��$	��Add��$
��0 10q�{�.  ���� *
AddCommand+�� -   $��	btnCancel��$��Cancel��$	��0 5q����� *CancelCommand+� $��1�� �� �� .+��  �� �� .+��� $��Select publisher��$��0��
���   �$��15(�$��SemiBold"�$��5q�$	��300��.���  �� $
��auto ��� .+��� -   $��txtSearchPublisher��$��0��   PlaceHolderTextStyle#��[  
 � Tag$ Search here...��$	��0 5q�&   System.Windows.Controls.DataGrid  -	   $��dgPublisher��   AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�$��1�� �� SelectedValuePath$
 ISBN��$��14(�$��SemiBold"����� *LstPublisher+ �� *SelectedPublisher+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $
 Name�� �� *Name+�� $��Select translator��$��1��
���   �$��15(�$��SemiBold"�$��5q�$	��300��.���  �� $
��auto ��� .+��� -
   $��txtSearchTranslator��$��0��#��[  $ Search here...��$	��0 5q�  -   $��dgTranslator�� .   . $ Single=�$��1��$��14(�$��SemiBold"�$
 ISBN������ *LstTranslator+ �� *SelectedTranslator+   $ Id�� �� *Id+  $
 Name�� �� *Name+  $	 BoF�� �� *boF+ �� StringFormat$ 
dd/MM/yyyy���� $��Select Book ISBN��$��15(�$��SemiBold"�$��1��
���   �$��5q�$	��300��.���  �� $
��auto ��� .+��� -   $��txtSearchBookISBN��$��0��#��[  $ Search here...��$	��0 5q�  -   $��
dgBookISBN�� .   . $ Single=�$��1��$��14(�$��SemiBold"�$
 ISBN�� �� *SelectedBookISBN+   $
 ISBN�� �� *ISBN+  $ Language�� �� *
Language+  $ Author Name�� �� *
AuthorName+  $ 
Author BoF�� �� *	AuthorBoF+$ 
dd/MM/yyyy��4  .System.Windows.Controls.DataGridTemplateColumn  $ Action��   CellTemplate �� .R��� $��	btnDetail��-   $��Detail��$	��100��$
��10 0q� �� *ISBN+