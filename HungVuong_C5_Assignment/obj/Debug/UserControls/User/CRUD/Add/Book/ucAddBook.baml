   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      '    !HungVuong_C5_Assignment.ucAddBook   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      $��5q�5        � 	Resources  5
       �� 
TargetType �� Property �� Value��%W   '��       �� 5   
   " ��6   .�5      ��  � ��$ 0 5 0 5q�6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��Add Book��6   $��Center=�5      $��20(�5      $
��Bold"�5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      .+�5!      �� $��0��6   
���   �$��Book Information��5#      $��15(�5$      $��SemiBold"�5%      $��5q�5&      .��5'      ��  �� Orientation$ Vertical=�6   .+�5(      �� $��5q�6!   .+�5)      �� $��Id��6$   $��14(�5*   $   $��SemiBold"�5+   $   �� 5,      -   5        $��txtId��5,   "   {�.  ��5.   "   �� *NewID+�� 50      $��Language��6$   $��14(�51   $   $��SemiBold"�52   $   �� 54      -   5        $��
cbLanguage��54   #   $	��0 5q�55   #   ��56   #   �� *LstLanguage+ �� SelectedItem 57   #   �� *SelectedLanguage+ �� UpdateSourceTrigger$ PropertyChanged=��� 59      $��Publish Date��6$   $��14(�5:   $   $��SemiBold"�5;   $   (  "System.Windows.Controls.DatePicker  5=      -   5        $��dpPublishDate��5=   %   $	��0 5q�5>   %   	 � Language$	 vi-VN�5@   %   
   SelectedDate
 5?   %   �� *SelectedPublishDate+$ PropertyChanged=�5@   %   �� 5B      $��Price��6$   $��14(�5C   $   $��SemiBold"�5D   $   �� 5E      -   5        $��txtPrice��5E   "   ��5F   "   �� *Price+$ PropertyChanged=�5H   "   �� 5J      $��Quantity��6$   $��14(�5K   $   $��SemiBold"�5L   $   �� 5M      -   5        $��txtQuantity��5M   "   ��5N   "   �� *
Quantity+$ PropertyChanged=�5P   "   �� 5R      -   5        $��btnAdd��5T   !   $	��Add��5R   !   $
��0 10q�5S   !   {�.  ��5V   !   �� *
AddCommand+�� 5W      -   5        $��	btnCancel��5Y   !   $��Cancel��5W   !   $	��0 5q�5X   !   ��5Z   !   �� *CancelCommand+5[      5\      5]      � 5_      $��1��6    5`      �� 5a      �� 5b      .+�5e      �  5f      �� 5g      �� 5h      .+�5k      �� $��Select publisher��6   $��0��5l      
���   �$��15(�5n      $��SemiBold"�5o      $��5q�5p      $	��300��5q      .��5r      �  5s      �� 5t   "   $
��auto �60   �� 5u   "   .+�5x      �� -   5        $��txtSearchPublisher��5|   &   $��0��5x   &      PlaceHolderTextStyle#��[  5y   &   
 � Tag$ Search here...��5z   &   $	��0 5q�5{   &   5}   &   &   System.Windows.Controls.DataGrid  5      -	   5        $��dgPublisher��5   '      AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5�   9   $��1��5�   '    �� SelectedValuePath$
 ISBN��5�   '   $��14(�5�   '   $��SemiBold"�5�   '   ��5�   '   �� *LstPublisher+ 5�   '   �� *SelectedPublisher+   Columns 5�   "   0  *System.Windows.Controls.DataGridTextColumn  5�   &   ,  &System.Windows.Controls.DataGridColumn   Header$ Id��69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *Id+  5�   &   $
 Name��69    6G   �� *Name+5�      5�      5�      �� 5�      $��Select translator��6   $��1��5�      
���   �$��15(�5�      $��SemiBold"�5�      $��5q�5�      $	��300��5�      .��5�      �  5�      �� 5�   "   $
��auto �60   �� 5�   "   .+�5�      �� -
   5        $��txtSearchTranslator��5�   &   $��0��5�   &   #��[  5�   "   $ Search here...��5�   "   $	��0 5q�5�   &   5�   &     5�      -   5        $��dgTranslator��5�   '    .   . $ Single=�5�   9   $��1��5�   '   $��14(�5�   '   $��SemiBold"�5�   '   $
 ISBN��5�   '   ��5�   '   �� *LstTranslator+ 5�   '   �� *SelectedTranslator+ 5�   "     5�   &   $ Id��69    6E   �� *Id+  5�   &   $
 Name��69    6G   �� *Name+  5�   &   $	 BoF��69    6F   �� *boF+ �� StringFormat$ 
dd/MM/yyyy��5�      5�      5�      5�      �� 5�      $��Select Book ISBN��6   $��15(�5�      $��SemiBold"�5�      $��1��5�      
���   �$��5q�5�      $	��300��5�      .��5�      �  5�      �� 5�      $
��auto �6,   �� 5�      .+�5�      �� -   5        $��txtSearchBookISBN��5�   "   $��0��5�   "   #��[  5�   "   $ Search here...��5�   "   $	��0 5q�5�   "   5�   "     5�      -   5        $��
dgBookISBN��5�   #    .   . $ Single=�5�   5   $��1��5�   #   $��14(�5�   #   $��SemiBold"�5�   #   $
 ISBN��5�   #    5�   #   �� *SelectedBookISBN+ 5�        5�   "   $
 ISBN��65    6C   �� *ISBN+  5�   "   $ Language��65    6G   �� *
Language+  5�   "   $ Author Name��65    6J   �� *
AuthorName+  5�   "   $ 
Author BoF��65    6I   �� *	AuthorBoF+$ 
dd/MM/yyyy��4  .System.Windows.Controls.DataGridTemplateColumn  5�   "   $ Action��69      CellTemplate 5�   &   �� 5�   *   .R�5�   .   �� $��	btnDetail��65   -   5        $��Detail��5�   -   $	��100��5�   -   $
��10 0q�5�   -    5�   -   �� *ISBN+5�   -   5�   +   5�   #   5�      5�      5�      5�      5�      5�      5�      