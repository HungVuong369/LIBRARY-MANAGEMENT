   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      0    *HungVuong_C5_Assignment.ucSelectBookByISBN   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5        � 	Resources  5	      =   7HungVuong_C5_Assignment.TrueFalseToAvailableUnavailable   convertTrueFalse��%   &	          5
   
   60   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   �� $��Please select a book��6   $��20(�5      $
��Bold"�5      $��Center=�5      �� 5   
   -   5        $��	txtSearch��5        FloatingLabelTextBoxStyle#��[ 5      
 � Tag$ Search here...��5      $��1��5      $��5q�5      � 5!   
   $��2��6   $	��5 0q�6    5"      �� 5#      $��* �6    6-   �� 5$      $
��auto �6    60   .+�5'      &   System.Windows.Controls.DataGrid  -   5        $��
dgBookInfo��5'         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5(   )   $��0��5)         Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)      
Visibility$ 	Collapsed=�5,   %   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5+   5   �� *Id+5,   %     5-      $
 ISBN��6)   	 67   �� *ISBN+  5.      $
 Name��6)   	 67   �� *Name+  5/      $ Category��6)   	 6;   �� *
Category+  51      $ Author��6)   	 69   �� *BookAuthor.Name+  52      $ Language��6)   	 6;   �� *
Language+  54      $ 
Translator��6)   	 6=   �� *BookTranslator.Name+  56      $ Publisher Name��6)   	 6A   �� *BookPublisher.Name+  57      $ Publish Date��6)   	 6?   �� *PublishDate+
 �� StringFormat$
 
dd/MM/yyyy��  58      $ Quantity��6)   	 6;   �� *
Quantity+  59      $ Status��6)   	 69   �� *Status+ �� 	Converter# [     	CellStyle 5:      �� 5;       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6$     CellDefault �� BasedOn# [ 6>    �� Triggers 5<   "   �� 5=   &    �� Binding 62   �� *Status+ �� Value True6M   .a�5>   *   ��  �� Property � �� �� Value
 � � �6G   5?   '   �� 5@   &    62   �� *Status+	 False6M   .a�5A   *   ��  � ��
 �  ��6G   5B   '   5D      5F        5H      $ Book Status��6)   $ 	Collapsed=�5I   %   	 5H   >   �� *
BookStatus+5I   %   5K      (   "HungVuong_C5_Assignment.Pagination  5M      -   5          Name$ 
pagination��5N      $��1��5M      $��45��5O      5P      � 5U   
   $��3��6    � ColumnDefinitions 5V      �� 5W      �� 5X      .+�5[      �� -   5        $��
btnConfirm��5^      $��Confirm��5[      $��5q�5\      {�.  5_      �� 5`      -   5        $��	btnCancel��5c      $��Cancel��5`      $��1��5a      $��5q�5b      5d      5e      5f      5g      