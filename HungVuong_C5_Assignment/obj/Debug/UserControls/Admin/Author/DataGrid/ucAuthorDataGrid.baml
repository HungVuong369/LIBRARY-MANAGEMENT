   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      .    (HungVuong_C5_Assignment.ucAuthorDataGrid   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5        � 	Resources  5	      =   7HungVuong_C5_Assignment.TrueFalseToAvailableUnavailable   ConvertTrueFalseTo��%   &	          5
   
   60   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	dgAuthors��5         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5       �� SelectedItem 5      �� *SelectedAuthor+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $
 Name��6%    63   �� *Name+  5      $ Summary��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 80 5   %    5   6   �� *	Summary+5   %     5      $ Description��6%   $	 80 5   %    5   :   �� *Description+5   %     5      $	 BoF��6%    62   �� *boF+
 �� StringFormat$
 
dd/MM/yyyy��  5       $ 
Created At��6%    69   �� *	CreatedAt+$
 
dd/MM/yyyy��  5!      $ Modified At��6%    6:   �� *
ModifiedAt+$
 
dd/MM/yyyy��  5"      $ Status��6%    65   �� *Status+ �� 	Converter# [     	CellStyle 5#      �� 5$       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6      CellDefault �� BasedOn# [ 6:    �� Triggers 5%      �� 5&   "    �� Binding 6.   �� *Status+ �� Value True6I   .a�5'   &   ��  �� Property � �� �� Value
 � � �6C   5(   #   �� 5*   "    6.   �� *Status+	 False6I   .a�5+   &   ��  � ��
 �  ��6C   5,   #   5.      50      4  .System.Windows.Controls.DataGridTemplateColumn  52      $ Action��6)      CellTemplate 53      �� 54      .R�55      �� $��	btnUpdate��6%   $��Update��56   %   $	��100��58   %   $
��10 0q�59   %   $��20��5:   %     ButtonBasicStyle#��[ 5;   %   
��� ���
����  �
 � Tag 57   %   �� ��5>   %   �� *DataContext.UpdateCommand+ �� RelativeSource ��  �� AncestorType"  5?      5@      5B        5D      $ Action��6)    5E      �� 5F      .R�5G      �� $��btnLock��6%   $
��Lock��5H   %   $	��100��5J   %   $��20��5K   %   $
��10 0q�5L   %     ButtonDeleteStyle#��[ 5M   %    5I   %   �� ��5N   %   �� *DataContext.LockCommand+ �� "  5O      5Q        5S      $ Action��6)      
Visibility$ 	Collapsed=�69    5T      �� 5U      .R�5V      �� $��
btnRestore��6%   $��Restore��5W   %   $	��100��5Y   %   $
��10 0q�5Z   %   $��20��5[   %   #��[ 5\   %   
��� ���
����  � 5X   %   �� ��5_   %   �� *DataContext.RestoreCommand+ �� "  5`      5b        5e      $ Action��6)   $ 	Collapsed=�69    5f      �� 5g      .R�5h      �� $��	btnDelete��6%   $��Delete��5i   %   $	��100��5k   %   $��20��5l   %   $
��10 0q�5m   %   #��[ 5n   %    5j   %   �� ��5o   %   �� *DataContext.DeleteCommand+ �� "  5p      5r      5t      (	   "HungVuong_C5_Assignment.Pagination	  5v   
   -   5         	 Name$ 
pagination��5w      $��1��5v      $��45��5x      5y      5z      