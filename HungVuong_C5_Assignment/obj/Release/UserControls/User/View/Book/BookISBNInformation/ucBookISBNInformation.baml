   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  3    -HungVuong_C5_Assignment.ucBookISBNInformation   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     $��5q�  � 	Resources  =   7HungVuong_C5_Assignment.TrueFalseToAvailableUnavailable *  &ConvertTrueFalseToAvailableUnavailable��%   &	          .���  � RowDefinitions �� $��* ��� $
��auto �.+�&   System.Windows.Controls.DataGrid  -   $��
dgBookISBN��   AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�$��0��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 ISBN��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *ISBN+  $ Language�� �� *
Language+  $ 	Author ID�� �� *
AuthorID+  $ Author Name�� �� *
AuthorName+  $ 
Author BoF�� �� *	AuthorBoF+ �� StringFormat$ 
dd/MM/yyyy��  $ Status�� �� *Status+	 �� 	Converter#	 [  
   	CellStyle
 ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"    CellDefault �� BasedOn# [  �� Triggers ��  �� Binding �� *Status+ �� Value True.a���  �� Property � �� �� Value
 � � ���  �� *Status+	 False.a���  � ��
 �  ��4  .System.Windows.Controls.DataGridTemplateColumn  $ Action��   CellTemplate �� .R��� $��	btnDetail��-   $��Detail��$	��100��$
��10 0q�
 � Tag �� *ISBN+(   "HungVuong_C5_Assignment.Pagination  -     Name$ 
pagination��$��1��$��45��