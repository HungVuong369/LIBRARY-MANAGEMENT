   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 0    *HungVuong_C5_Assignment.ucLoanSlipDataGrid   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity       � 	Resources  2   ,HungVuong_C5_Assignment.ExpiredDateConverter   ConvertExpiredDate��%   &	          .��� .+�&   System.Windows.Controls.DataGrid  -   $��dgLoanDetail��   AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=����� *	LoanSlips+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *SelectedLoanSlip+$ PropertyChanged=�.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ SelectionChanged��.  (System.Windows.Interactivity.TriggerBase	   Actions.	 6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 �� *!SelectionChangedLoanSlipCommand+   CommandParameter ��    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Loan ID��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *Id+  $ 	Loan Date�� �� *
LoanDate+ �� StringFormat$ 
dd/MM/yyyy��  $ Expire Date�� �� *	ExpDate+$ 
dd/MM/yyyy��  $ Quantity�� �� *
Quantity+   	CellStyle ��  �� 
TargetType*
  $System.Windows.Controls.DataGridCell" 
   CellDefault �� BasedOn# [  �� Triggers P�  P� Property �@
 
IsSelected P� Value . . ���  �� Property � �� �� Value$ 14(���  � ��
 �  ����  � ��
 �������  � ��
 �  ��   RowStyle �� )  #System.Windows.Controls.DataGridRow"   ��  �� Binding �� *	ExpDate+ �� 	Converter# [   �� Value True.a���  � ��
 �  ��P�  �@ 
IsSelected . 