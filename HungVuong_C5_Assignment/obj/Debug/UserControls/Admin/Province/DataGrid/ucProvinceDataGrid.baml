   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      0    *HungVuong_C5_Assignment.ucProvinceDataGrid   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5        � 	Resources  5	      =   7HungVuong_C5_Assignment.TrueFalseToAvailableUnavailable   ConvertTrueFalse��%   &	          5
   
   60   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgProvinces��5         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5       �� SelectedItem 5      �� *SelectedProvince+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $
 Name��6%    63   �� *Name+  5      $ Status��6%    65   �� *Status+	 �� 	Converter#	 [  
   	CellStyle
 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6      CellDefault �� BasedOn# [ 6:    �� Triggers 5      �� 5   "    �� Binding 6.   �� *Status+ �� Value True6I   .a�5    &   ��  �� Property � �� �� Value
 � � �6C   5!   #   �� 5#   "    6.   �� *Status+	 False6I   .a�5$   &   ��  � ��
 �  ��6C   5%   #   5'      5)      4  .System.Windows.Controls.DataGridTemplateColumn  5*      $ Action��6)      CellTemplate 5+      �� 5,      .R�5-      �� $��	btnUpdate��6%   $��Update��5.   %   $	��100��50   %   $
��10 0q�51   %   $��20��52   %     ButtonBasicStyle#��[ 53   %   
��� ���
����  �
 � Tag 5/   %   �� ��56   %   �� *DataContext.UpdateCommand+ �� RelativeSource ��  �� AncestorType"  57      58      5:        5<      $ Action��6)    5=      �� 5>      .R�5?      �� $��btnLock��6%   $
��Lock��5@   %   $	��100��5B   %   $��20��5C   %   $
��10 0q�5D   %     ButtonDeleteStyle#��[ 5E   %    5A   %   �� ��5F   %   �� *DataContext.LockCommand+ �� "  5G      5I        5K      $ Action��6)      
Visibility$ 	Collapsed=�69    5L      �� 5M      .R�5N      �� $��
btnRestore��6%   $��Restore��5O   %   $	��100��5Q   %   $
��10 0q�5R   %   $��20��5S   %   #��[ 5T   %   
��� ���
����  � 5P   %   �� ��5W   %   �� *DataContext.RestoreCommand+ �� "  5X      5Z        5\      $ Action��6)   $ 	Collapsed=�69    5]      �� 5^      .R�5_      �� $��	btnDelete��6%   $��Delete��5`   %   $	��100��5b   %   $��20��5c   %   $
��10 0q�5d   %   #��[ 5e   %    5a   %   �� ��5f   %   �� *DataContext.DeleteCommand+ �� "  5g      5i      5k      (   "HungVuong_C5_Assignment.Pagination  5m   
   -   5          Name$ 
pagination��5n      $��1��5m      $��45��5o      5p      5q      