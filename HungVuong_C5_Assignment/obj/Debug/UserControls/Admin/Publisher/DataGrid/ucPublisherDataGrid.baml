   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      1    +HungVuong_C5_Assignment.ucPublisherDataGrid   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgPublishers��5         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5       �� SelectedItem 5      �� *SelectedPublisher+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $
 Name��6%    63   �� *Name+  5      $ Phone��6%    64   �� *Phone+  5      $ Address��6%    66   �� *	Address+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Action��6)      CellTemplate 5      �� 5      .R�5      �� $��	btnUpdate��6%   $��Update��5   %   $	��100��5    %   $
��10 0q�5!   %   $��20��5"   %      ButtonBasicStyle#��[  5#   %   
��� ���
����  �
	 � Tag	 5   %   �� ��5&   %   �� *DataContext.UpdateCommand+
 �� RelativeSource
 ��  �� AncestorType"  5'      5(      5*        5,      $ Action��6)    5-      �� 5.      .R�5/      �� $��	btnDelete��6%   $��Delete��50   %   $	��100��52   %   $��20��53   %   $
��10 0q�54   %     ButtonDeleteStyle#��[ 55   %   	 51   %   �� ��56   %   �� *DataContext.DeleteCommand+
 �� "  57      59      5;      (   "HungVuong_C5_Assignment.Pagination  5=   
   -   5          Name$ 
pagination��5>      $��1��5=      $��45��5?      5@      5A      