   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      9    3HungVuong_C5_Assignment.ucReaderAndIdentifyDataGrid   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5        � 	Resources  5	      3   -HungVuong_C5_Assignment.TrueFalseToReaderType   ConvertReaderType=   7HungVuong_C5_Assignment.TrueFalseToAvailableUnavailable * &ConvertTrueFalseToAvailableUnavailable��%:   &	        &	        5
   
   6&     5   
   60   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgReader��5         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5   %      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Identify��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *
Identify+  5      $
 Name��6%    63   �� *
FullName+  5      $	 BoF��6%    62   �� *BoF+ �� StringFormat$ 
dd/MM/yyyy��  5      $ 
ReaderType��6%    69   �� *Type+	 �� 	Converter#	 [  
   	CellStyle
 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6      CellDefault �� BasedOn# [ 6:    �� Triggers 5      �� 5   "    �� Binding 6.   �� *Type+ �� Value True6G   .a�5   &   ��  �� Property � �� �� Value
 �� ��6C   5    #   �� 5!   "    6.   �� *Type+	 False6G   .a�5"   &   ��  � ��
 ��  �6C   5#   #   5%      5'        5(      $ 	CreatedAt��6%    68   �� *	CreatedAt+$ 
dd/MM/yyyy��  5)      $ 
ModifiedAt��6%    69   �� *
ModifiedAt+$ 
dd/MM/yyyy��  5*      $ Status��6%    65   �� *Status+#	 [ 
 5+      �� 5,      "  6    # [ 6:    5-      �� 5.   "    6.   �� *Status+ True6I   .a�5/   &   ��  � ��
 � � �6C   50   #   �� 51   "    6.   �� *Status+	 False6I   .a�52   &   ��  � ��
 �  ��6C   53   #   55      57      4  .System.Windows.Controls.DataGridTemplateColumn  59      $ Action��6)      CellTemplate 5:      �� 5;      .R�5<      �� $��	btnDetail��6%   -   5        $��Detail��5=   -   $	��100��5@   -   $
��10 0q�5A   -   
 � Tag 5>   -   �� 5A   -   5B      5D        5F      $ Action��6)    5G      �� 5H      .R�5I      �� $��btnLock��6%   -   5        $
��Lock��5J   %     ButtonDeleteStyle#��[ 5L   %   $	��100��5N   %   $
��10 0q�5O   %   $��20��5P   %    5K   %   �� 5P   %   5Q      5S        5U      $ Action��6)      
Visibility$ 	Collapsed=�69    5V      �� 5W      .R�5X      �� $��
btnRestore��6%   -   5        $��Restore��5Y   %     ButtonBasicStyle#��[ 5[   %   $	��100��5]   %   
��� ���$��20��5_   %   
����  �$
��10 0q�5a   %    5Z   %   �� 5a   %   5b      5d        5f      $ Action��6)    5g      �� 5h      .R�5i      �� $��
btnHistory��6%   -   5        $��History��5j   %   $	��100��5m   %   $
��10 0q�5n   %    5k   %   �� 5n   %   5o      5q        5s      $ Action��6)   $ 	Collapsed=�69    5t      �� 5u      .R�5v      �� $��	btnDelete��6%   -   5        $��Delete��5w   %   #��[ 5y   %   $	��100��5{   %   $
��10 0q�5|   %   $��20��5}   %    5x   %   �� 5}   %   5~      5�      5�      (	   "HungVuong_C5_Assignment.Pagination	  5�   
   -   5         	 Name$ 
pagination��5�      $��1��5�      $��45��5�      5�      5�      