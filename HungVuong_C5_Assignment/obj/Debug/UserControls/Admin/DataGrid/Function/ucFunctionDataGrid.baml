   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      0    *HungVuong_C5_Assignment.ucFunctionDataGrid   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5        � 	Resources  5	      2   ,HungVuong_C5_Assignment.ParentIDToParentName !  ConverterIdParentToParentName=   7HungVuong_C5_Assignment.TrueFalseToAvailableUnavailable * &ConvertTrueFalseToAvailableUnavailable��%:   &	        &	        5
   
   6%     5   
   60   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
dgFunction��5         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $
 Name��6%    63   �� *Name+  5      $ Description��6%    6:   �� *Description+  5      $ Parent��6%    65   �� *
IdParent+ �� 	Converter# [    5      $ 	Url Image��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 100 6U    68   �� *
UrlImage+6U     5      $ Status��6%    65   �� *Status+# [ 
   	CellStyle
 5       �� 5!       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6      CellDefault �� BasedOn# [ 6:    �� Triggers 5"      �� 5#   "    �� Binding 6.   �� *Status+ �� Value True6I   .a�5$   &   ��  �� Property � �� �� Value
 � � �6C   5%   #   �� 5&   "    6.   �� *Status+	 False6I   .a�5'   &   ��  � ��
 �  ��6C   5(   #   5*      5,      4	  .System.Windows.Controls.DataGridTemplateColumn	  5.      $ Action��6)    	  CellTemplate 5/      �� 50      .R�51      �� $��	btnUpdate��6%   -   5        $��Update��52   %   $	��100��55   %   $
��10 0q�56   %   $��20��57   %     ButtonBasicStyle#��[ 58   %   
��� ���
����  �
 � Tag 53   %   �� 5:   %   5;      5=      	  5?      $ Action��6)    5@      �� 5A      .R�5B      �� $��	btnDelete��6%   -   5        $��Delete��5C   %   $	��100��5F   %   $��20��5G   %   $
��10 0q�5H   %     ButtonDeleteStyle#��[ 5I   %    5D   %   �� 5I   %   5J      5L      	  5N      $ Action��6)      
Visibility$ 	Collapsed=�69    5O      �� 5P      .R�5Q      �� $��
btnRestore��6%   -   5        $��Restore��5R   %   $	��100��5U   %   $
��10 0q�5V   %   $��20��5W   %   #��[ 5X   %   
��� ���
����  � 5S   %   �� 5Z   %   5[      5]      5_      (
   "HungVuong_C5_Assignment.Pagination
  5a   
   -   5         
 Name$ 
pagination��5b      $��1��5a      $��45��5c      5d      5e      