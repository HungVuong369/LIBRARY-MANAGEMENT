   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      0    *HungVuong_C5_Assignment.ucUserRoleDataGrid   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5        � 	Resources  5	      =   7HungVuong_C5_Assignment.TrueFalseToAvailableUnavailable *  &ConvertTrueFalseToAvailableUnavailable��%   &	          5
   
   60   5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
dgUserRole��5         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $ Username��6%    67   �� *
Username+  5      $ Password��6%    67   �� *
Password+  5      $ 	Name Role��6%    68   �� *
NameRole+  5      $ Group��6%    64   �� *Group+  5      $ Status��6%    65   �� *Status+ �� 	Converter# [  	   	CellStyle	 5      �� 5      
 �� 
TargetType*  $System.Windows.Controls.DataGridCell"
  6      CellDefault �� BasedOn# [ 6:    �� Triggers 5       �� 5!   "    �� Binding 6.   �� *Status+ �� Value True6I   .a�5"   &   ��  �� Property � �� �� Value
 � � �6C   5#   #   �� 5$   "    6.   �� *Status+	 False6I   .a�5%   &   ��  � ��
 �  ��6C   5&   #   5(      5*        5+      $ 
Created At��6%    69   �� *	CreatedAt+ �� StringFormat$ 
dd/MM/yyyy��  5,      $ Modified At��6%    6:   �� *
ModifiedAt+$ 
dd/MM/yyyy��4  .System.Windows.Controls.DataGridTemplateColumn  5.      $ Action��6)      CellTemplate 5/      �� 50      .R�51      �� $��btnInfo��6%   -   5        $��Detail��52   %   $	��100��55   %   $��20��56   %   $
��10 0q�57   %   
 � Tag 53   %   �� 57   %   58      5:        5<      $ Action��6)    5=      �� 5>      .R�5?      �� $��btnUserAssignment��6%   -   5        $��
Assignment��5@   %   $	��100��5C   %   $
��10 0q�5D   %   $��20��5E   %   
��� ���
����  � 5A   %   �� ��5H   "   �� 5I   &   "
 ��6,   .�5J   *   ��  � �� 6C   �� *Margin+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" ���� 5K   *    � ��
 �  ��6G   �� 5L   *    � ��
 �����6G   �� 5M   *    � ��
 �   �6H   �� 5N   *    � ��$ 1q�6L   �� 5O   *    � �� 6D   �� *	Padding+ �� $ FindAncestor=�" ���� 5P   *    � ��$
 Bold"�6G   �� 5Q   *    � ��$ Arial)�6G   �� 5R   *    � ��$ 12(�6E   �� 5S   *    � ��$ Center=�6P   �� 5T   *    � ��$ Center=�6N   �� 5U   *    � ��$ Center=�6W   �� 5V   *    � ��$ Center=�6U   �� 5W   *    � �� 5X   .   �� 5Y   2    �� 
TargetType" ��6B   .R�5Z   6   � .+�5[   :   ��  ��Name$ border��6A   #��z��6Q   #��z��6{   #��z��6�    �� CornerRadius$ 5��6�   �� 5\   :   $��Center=�6K   $��Center=�6h   5]   7    �� Triggers 5^   6   P� 5_   :    P� Property �@J�IsMouseOver P� Value . . �5`   >   ��  �� 
TargetName$ border��6E    � �� �#FFCBA76o   5a   ;   P� 5c   :    � {� .  . �5d   >   �� $ border��6E    � ��
 �����6o   5e   ;   5g   3   5i   +    5j   *   �� 5k   .    6:   �� *Id+ U16Q   .a�5l   2   ��  � y�$ 	Collapsed=�6O   5m   /   5o   '   5q      5r      5t      5v      (   "HungVuong_C5_Assignment.Pagination  5x   
   -   5          Name$ 
pagination��5y      $��1��5x      $��45��5z      5{      5|      