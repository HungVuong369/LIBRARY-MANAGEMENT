   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      -    'HungVuong_C5_Assignment.ucRestoreReader   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      $��5q�5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   �� $��Restore Reader��6   $��20(�5      $��SemiBold"�5      $��Center=�5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgReader��5         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5   %   $��1��5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Last Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *LName+  5      $ 
First Name��6%    69   �� *FName+  5      $	 BoF��6%    62   �� *BoF+ �� StringFormat$ 
dd/MM/yyyy��  5      $ 
ReaderType��6%    69   �� *
ReaderType+  5      $ 	CreatedAt��6%    68   �� *	CreatedAt+$ 
dd/MM/yyyy��  5      $ 
ModifiedAt��6%    69   �� *
ModifiedAt+$ 
dd/MM/yyyy��  5      $ Status��6%    65   �� *Status+4  .System.Windows.Controls.DataGridTemplateColumn  5!      $ Action��6)      CellTemplate 5"      �� 5#      .R�5$      �� .+�5%   "   �� $��
btnRestore��6)   -   5        $��Restore��5&   )      ButtonBasicStyle#��[  5(   )   
��� ���
����  �$	��100��5,   )   $��20��5-   )   $
��10 0q�5.   )   
	 � Tag	 5'   )   �� 5.   )   50      51      53      55      56      57      