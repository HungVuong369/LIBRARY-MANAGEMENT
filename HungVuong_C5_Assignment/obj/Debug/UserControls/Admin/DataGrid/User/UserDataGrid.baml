   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      *    $HungVuong_C5_Assignment.UserDataGrid   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5        � 	Resources  5	      =   7HungVuong_C5_Assignment.TrueFalseToAvailableUnavailable *  &ConvertTrueFalseToAvailableUnavailable��%   &	          5
   
   60   5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgUser��5         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $ Username��6%    67   �� *
Username+  5      $ Password��6%    67   �� *
Password+  5      $ 
Created At��6%    69   �� *	CreatedAt+ �� StringFormat$ 
dd/MM/yyyy��  5      $ Modified At��6%    6:   �� *
ModifiedAt+$ 
dd/MM/yyyy��  5      $ Status��6%    65   �� *Status+	 �� 	Converter#	 [  
   	CellStyle
 5      �� 5        �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6      CellDefault �� BasedOn# [ 6:    �� Triggers 5!      �� 5"   "    �� Binding 6.   �� *Status+ �� Value True6I   .a�5#   &   ��  �� Property � �� �� Value
 � � �6C   5$   #   �� 5%   "    6.   �� *Status+	 False6I   .a�5&   &   ��  � ��
 �  ��6C   5'   #   5)      5+      4  .System.Windows.Controls.DataGridTemplateColumn  5-      $ Action��6)      CellTemplate 5.      �� 5/      .R�50      �� $��btnInfo��6%   -   5        $��Detail��51   %   $	��100��54   %   $��20��55   %   $
��10 0q�56   %   
 � Tag 52   %   �� 56   %   57      59        5;      $ Action��6)    5<      �� 5=      .R�5>      �� $��	btnUpdate��6%   -   5        $��Update��5?   %   $	��100��5B   %   $
��10 0q�5C   %   $��20��5D   %     ButtonBasicStyle#��[ 5E   %   
��� ���
����  � 5@   %   �� 5G   %   5H      5J        5L      $ Action��6)    5M      �� 5N      .R�5O      �� $��	btnDelete��6%   -   5        $��Delete��5P   %   $	��100��5S   %   $��20��5T   %   $
��10 0q�5U   %    5Q   %   �� ��5V   "   �� 5W   &   " ��6,   .�5X   *   ��  � ��$ 10q�6C   �� 5Y   *    � ��
 �  ��6G   �� 5Z   *    � ��
 �����6G   �� 5[   *    � ��
 �   �6H   �� 5\   *    � ��$ 1q�6L   �� 5]   *    � ��$ 5q�6D   �� 5^   *    � ��$
 Bold"�6G   �� 5_   *    � ��$ Arial)�6G   �� 5`   *    � ��$ 12(�6E   �� 5a   *    � ��$ 30��6C   �� 5b   *    � ��$	 140��6B   �� 5c   *    �@J�Opacity$	 0.8Q�6D   �� 5d   *    � ��$ Center=�6P   �� 5e   *    � ��$ Center=�6N   �� 5f   *    � �� 5g   .   �� 5h   2    �� 
TargetType" ��6B   .R�5i   6   � .+�5j   :   ��  ��Name$ border��6A   #��z��6Q   #��z��6{   #��z��6�    �� CornerRadius$ 5��6�   �� 5k   :   $��Center=�6K   $��Center=�6h   5l   7    �� Triggers 5m   6   P� 5n   :    P� Property �@J�IsMouseOver P� Value . . �5o   >   ��  �� 
TargetName$ border��6E    � ��
 ��� �6o   5p   ;   P� 5r   :    � {� .  . �5s   >   �� $ border��6E    � ��
 �����6o   5t   ;   5v   3   5x   +    5y   *   �� 5z   .    6:   �� *Id+ U16Q   .a�5{   2   ��  � y�$ 	Collapsed=�6O   5|   /   5~   '   5�      5�      5�        5�      $ Action��6)      
Visibility$ 	Collapsed=�69    5�      �� 5�      .R�5�      �� $��btnUserAssignment��6%   -   5        $��
Assignment��5�   %   $	��100��5�   %   $
��10 0q�5�   %   $��20��5�   %   #��[ 5�   %   
��� ���
����  � 5�   %   �� 5�   %   5�      5�      5�      (   "HungVuong_C5_Assignment.Pagination  5�   
   -   5          Name$ 
pagination��5�      $��1��5�      $��45��5�      5�      5�      