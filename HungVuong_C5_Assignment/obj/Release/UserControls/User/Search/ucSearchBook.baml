   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  *    $HungVuong_C5_Assignment.ucSearchBook   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment       � 	Resources  =   7HungVuong_C5_Assignment.TrueFalseToAvailableUnavailable   convertTrueFalse��%   &	          .���  � RowDefinitions �� $��* ��� $
��auto �.+�&   System.Windows.Controls.DataGrid  -   $��
dgBookInfo��   AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�$��0��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��   
Visibility$ 	Collapsed=�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $
 ISBN�� �� *ISBN+  $
 Name�� �� *Name+  $ Category�� �� *
Category+  $ Author�� �� *BookAuthor.Name+  $ Language�� �� *
Language+  $ 
Translator��$ 	Collapsed=� �� *BookTranslator.Name+  $ Publisher Name��$ 	Collapsed=� �� *BookPublisher.Name+  $ Publish Date��$ 	Collapsed=� �� *PublishDate+	 �� StringFormat$	 
dd/MM/yyyy��  $ Quantity�� �� *
Quantity+  $ Status�� �� *Status+
 �� 	Converter#
 [     	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"    CellDefault �� BasedOn# [  �� Triggers ��  �� Binding �� *Status+ �� Value True.a���  �� Property � �� �� Value
 � � ���  �� *Status+	 False.a���  � ��
 �  ��  $ Book Status��$ 	Collapsed=� �� *
BookStatus+(   "HungVuong_C5_Assignment.Pagination  -     Name$ 
pagination��$��1��$��45��