   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      *    $HungVuong_C5_Assignment.ucSearchBook   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5        � 	Resources  5	      =   7HungVuong_C5_Assignment.TrueFalseToAvailableUnavailable   convertTrueFalse��%   &	          5
   
   60   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $
��auto �6   6,   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
dgBookInfo��5         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5   )   $��0��5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      
Visibility$ 	Collapsed=�5   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   1   �� *Id+5   %     5      $
 ISBN��6%    63   �� *ISBN+  5      $
 Name��6%    63   �� *Name+  5      $ Category��6%    67   �� *
Category+  5      $ Author��6%    65   �� *BookAuthor.Name+  5      $ Language��6%    67   �� *
Language+  5      $ 
Translator��6%   $ 	Collapsed=�5   %    5   9   �� *BookTranslator.Name+5   %     5       $ Publisher Name��6%   $ 	Collapsed=�5!   %    5    =   �� *BookPublisher.Name+5!   %     5"      $ Publish Date��6%   $ 	Collapsed=�5#   %    5"   ;   �� *PublishDate+	 �� StringFormat$	 
dd/MM/yyyy��5#   %     5$      $ Quantity��6%    67   �� *
Quantity+  5%      $ Status��6%    65   �� *Status+
 �� 	Converter#
 [     	CellStyle 5&      �� 5'       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6      CellDefault �� BasedOn# [ 6:    �� Triggers 5(      �� 5)   "    �� Binding 6.   �� *Status+ �� Value True6I   .a�5*   &   ��  �� Property � �� �� Value
 � � �6C   5+   #   �� 5,   "    6.   �� *Status+	 False6I   .a�5-   &   ��  � ��
 �  ��6C   5.   #   50      52        54      $ Book Status��6%   $ 	Collapsed=�55   %    54   :   �� *
BookStatus+55   %   57      (   "HungVuong_C5_Assignment.Pagination  59   
   -   5          Name$ 
pagination��5:      $��1��59      $��45��5;      5<      5=      