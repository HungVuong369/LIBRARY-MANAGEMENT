   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  *    $HungVuong_C5_Assignment.UserDataGrid   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment       � 	Resources  =   7HungVuong_C5_Assignment.TrueFalseToAvailableUnavailable *  &ConvertTrueFalseToAvailableUnavailable��%   &	          .���  � RowDefinitions �� �� $
��auto �.+�&   System.Windows.Controls.DataGrid  -   $��dgUser��   AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $ Username�� �� *
Username+  $ Password�� �� *
Password+  $ 
Created At�� �� *	CreatedAt+ �� StringFormat$ 
dd/MM/yyyy��  $ Modified At�� �� *
ModifiedAt+$ 
dd/MM/yyyy��  $ Status�� �� *Status+	 �� 	Converter#	 [  
   	CellStyle
 ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"    CellDefault �� BasedOn# [  �� Triggers ��  �� Binding �� *Status+ �� Value True.a���  �� Property � �� �� Value
 � � ���  �� *Status+	 False.a���  � ��
 �  ��4  .System.Windows.Controls.DataGridTemplateColumn  $ Action��   CellTemplate �� .R��� $��btnInfo��-   $��Detail��$	��100��$��20��$
��10 0q�
 � Tag ��   $ Action�� �� .R��� $��	btnUpdate��-   $��Update��$	��100��$
��10 0q�$��20��  ButtonBasicStyle#��[ 
��� ���
����  � ��   $ Action�� �� .R��� $��	btnDelete��-   $��Delete��$	��100��$��20��$
��10 0q� �� ���� " ��.���  � ��$ 10q���  � ��
 �  ����  � ��
 �������  � ��
 �   ���  � ��$ 1q���  � ��$ 5q���  � ��$
 Bold"���  � ��$ Arial)���  � ��$ 12(���  � ��$ 30����  � ��$	 140����  �@J�Opacity$	 0.8Q���  � ��$ Center=���  � ��$ Center=���  � �� ��  �� 
TargetType" ��.R�� .+���  ��Name$ border��#��z��#��z��#��z�� �� CornerRadius$ 5���� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  �� 
TargetName$ border�� � ��
 ��� �P�  � {� .  . ��� $ border�� � ��
 ����� ��  �� *Id+ U1.a���  � y�$ 	Collapsed=�  $ Action��   
Visibility$ 	Collapsed=� �� .R��� $��btnUserAssignment��-   $��
Assignment��$	��100��$
��10 0q�$��20��#��[ 
��� ���
����  � �� (   "HungVuong_C5_Assignment.Pagination  -     Name$ 
pagination��$��1��$��45��