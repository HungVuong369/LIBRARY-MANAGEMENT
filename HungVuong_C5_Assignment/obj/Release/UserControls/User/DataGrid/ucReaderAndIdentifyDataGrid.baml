   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  9    3HungVuong_C5_Assignment.ucReaderAndIdentifyDataGrid   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment       � 	Resources  3   -HungVuong_C5_Assignment.TrueFalseToReaderType   ConvertReaderType=   7HungVuong_C5_Assignment.TrueFalseToAvailableUnavailable * &ConvertTrueFalseToAvailableUnavailable��%   &	        &	          .���  � RowDefinitions �� $��* ��� $
��auto �.+�&   System.Windows.Controls.DataGrid  -   $��dgReader��   AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Identify��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
Identify+  $
 Name�� �� *
FullName+  $	 BoF�� �� *BoF+ �� StringFormat$ 
dd/MM/yyyy��  $ 
ReaderType�� �� *Type+	 �� 	Converter#	 [  
   	CellStyle
 ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"    CellDefault �� BasedOn# [  �� Triggers ��  �� Binding �� *Type+ �� Value True.a���  �� Property � �� �� Value
 �� ����  �� *Type+	 False.a���  � ��
 ��  �  $ 	CreatedAt�� �� *	CreatedAt+$ 
dd/MM/yyyy��  $ 
ModifiedAt�� �� *
ModifiedAt+$ 
dd/MM/yyyy��  $ Status�� �� *Status+#	 [ 
 �� "  # [  ��  �� *Status+ True.a���  � ��
 � � ���  �� *Status+	 False.a���  � ��
 �  ��4  .System.Windows.Controls.DataGridTemplateColumn  $ Action��   CellTemplate �� .R��� $��	btnDetail��-   $��Detail��$	��100��$
��10 0q�
 � Tag ��   $ Action�� �� .R��� $��btnLock��-   $
��Lock��  ButtonDeleteStyle#��[ $	��100��$
��10 0q�$��20�� ��   $ Action��   
Visibility$ 	Collapsed=� �� .R��� $��
btnRestore��-   $��Restore��  ButtonBasicStyle#��[ $	��100��
��� ���$��20��
����  �$
��10 0q� ��   $ Action�� �� .R��� $��
btnHistory��-   $��History��$	��100��$
��10 0q� ��   $ Action��$ 	Collapsed=� �� .R��� $��	btnDelete��-   $��Delete��#��[ $	��100��$
��10 0q�$��20�� �� (	   "HungVuong_C5_Assignment.Pagination	  -    	 Name$ 
pagination��$��1��$��45��