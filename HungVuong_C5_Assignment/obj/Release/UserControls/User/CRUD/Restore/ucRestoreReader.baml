   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  -    'HungVuong_C5_Assignment.ucRestoreReader   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     $��5q�.���   � RowDefinitions  �� $
��auto ��� .+��� $��Restore Reader��$��20(�$��SemiBold"�$��Center=�&   System.Windows.Controls.DataGrid  -   $��dgReader��   AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�$��1��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	Last Name��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *LName+  $ 
First Name�� �� *FName+  $	 BoF�� �� *BoF+ �� StringFormat$ 
dd/MM/yyyy��  $ 
ReaderType�� �� *
ReaderType+  $ 	CreatedAt�� �� *	CreatedAt+$ 
dd/MM/yyyy��  $ 
ModifiedAt�� �� *
ModifiedAt+$ 
dd/MM/yyyy��  $ Status�� �� *Status+4  .System.Windows.Controls.DataGridTemplateColumn  $ Action��   CellTemplate �� .R��� .+��� $��
btnRestore��-   $��Restore��   ButtonBasicStyle#��[  
��� ���
����  �$	��100��$��20��$
��10 0q�
	 � Tag	 �� 