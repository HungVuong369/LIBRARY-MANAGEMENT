   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      0    *HungVuong_C5_Assignment.ucCategoryDataGrid   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5        � 	Resources  5
      =   7HungVuong_C5_Assignment.TrueFalseToAvailableUnavailable   ConvertTrueFalse��%   &	          5   
   60   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgCategories��5         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5       �� SelectedItem 5      �� *SelectedCategory+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $
 Name��6%    63   �� *Name+  5      $ Status��6%    65   �� *Status+	 �� 	Converter#	 [  
   	CellStyle
 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6      CellDefault �� BasedOn# [ 6:    �� Triggers 5      �� 5    "    �� Binding 6.   �� *Status+ �� Value True6I   .a�5!   &   ��  �� Property � �� �� Value
 � � �6C   5"   #   �� 5$   "    6.   �� *Status+	 False6I   .a�5%   &   ��  � ��
 �  ��6C   5&   #   5(      5*        5+      $ 
Created At��6%    69   �� *	CreatedAt+ �� StringFormat$ 
dd/MM/yyyy��  5,      $ Modified At��6%    6:   �� *
ModifiedAt+$ 
dd/MM/yyyy��4  .System.Windows.Controls.DataGridTemplateColumn  5.      $ Action��6)      CellTemplate 5/      �� 50      .R�51      �� $��	btnUpdate��6%   $��Update��52   %   $	��100��54   %   $
��10 0q�55   %   $��20��56   %     ButtonBasicStyle#��[ 57   %   
��� ���
����  �
 � Tag 53   %   �� ��5:   %   �� *DataContext.UpdateCommand+ �� RelativeSource ��  �� AncestorType"  5;      5<      5>        5@      $ Action��6)    5A      �� 5B      .R�5C      �� $��btnLock��6%   $
��Lock��5D   %   $	��100��5F   %   $��20��5G   %   $
��10 0q�5H   %     ButtonDeleteStyle#��[ 5I   %    5E   %   �� ��5J   %   �� *DataContext.LockCommand+ �� "  5K      5M        5O      $ Action��6)      
Visibility$ 	Collapsed=�69    5P      �� 5Q      .R�5R      �� $��
btnRestore��6%   $��Restore��5S   %   $	��100��5U   %   $
��10 0q�5V   %   $��20��5W   %   #��[ 5X   %   
��� ���
����  � 5T   %   �� ��5[   %   �� *DataContext.RestoreCommand+ �� "  5\      5^        5`      $ Action��6)   $ 	Collapsed=�69    5a      �� 5b      .R�5c      �� $��	btnDelete��6%   $��Delete��5d   %   $	��100��5f   %   $��20��5g   %   $
��10 0q�5h   %   #��[ 5i   %    5e   %   �� ��5j   %   �� *DataContext.DeleteCommand+ �� "  5k      5m      5o      (   "HungVuong_C5_Assignment.Pagination  5q   
   -   5          Name$ 
pagination��5r      $��1��5q      $��45��5s      5t      5u      