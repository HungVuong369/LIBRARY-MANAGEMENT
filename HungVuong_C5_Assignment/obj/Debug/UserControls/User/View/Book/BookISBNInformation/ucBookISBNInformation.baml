   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      3    -HungVuong_C5_Assignment.ucBookISBNInformation   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      $��5q�5        � 	Resources  5
      =   7HungVuong_C5_Assignment.TrueFalseToAvailableUnavailable *  &ConvertTrueFalseToAvailableUnavailable��%   &	          5   
   60   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $
��auto �6   6,   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
dgBookISBN��5         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5   %   $��0��5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 ISBN��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *ISBN+  5      $ Language��6%    67   �� *
Language+  5      $ 	Author ID��6%    68   �� *
AuthorID+  5      $ Author Name��6%    6:   �� *
AuthorName+  5      $ 
Author BoF��6%    69   �� *	AuthorBoF+ �� StringFormat$ 
dd/MM/yyyy��  5      $ Status��6%    65   �� *Status+	 �� 	Converter#	 [  
   	CellStyle
 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6      CellDefault �� BasedOn# [ 6:    �� Triggers 5      �� 5    "    �� Binding 6.   �� *Status+ �� Value True6I   .a�5!   &   ��  �� Property � �� �� Value
 � � �6C   5"   #   �� 5#   "    6.   �� *Status+	 False6I   .a�5$   &   ��  � ��
 �  ��6C   5%   #   5'      5)      4  .System.Windows.Controls.DataGridTemplateColumn  5+      $ Action��6)      CellTemplate 5,      �� 5-      .R�5.      �� $��	btnDetail��6%   -   5        $��Detail��5/   %   $	��100��52   %   $
��10 0q�53   %   
 � Tag 50   %   �� *ISBN+53   %   54      56      58      (   "HungVuong_C5_Assignment.Pagination  5:   
   -   5          Name$ 
pagination��5;      $��1��5:      $��45��5<      5=      5>      