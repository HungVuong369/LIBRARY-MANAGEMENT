   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      0    *HungVuong_C5_Assignment.ucLoanSlipDataGrid   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5        � 	Resources  5
      2   ,HungVuong_C5_Assignment.ExpiredDateConverter   ConvertExpiredDate��%   &	          5   
   6%   5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgLoanDetail��5         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5   %   ��5      �� *	LoanSlips+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5      �� *SelectedLoanSlip+$ PropertyChanged=�.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ SelectionChanged��6!   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6,   �� *!SelectionChangedLoanSlipCommand+   CommandParameter 5   ,   �� 5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Loan ID��6%   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 66   �� *Id+  5      $ 	Loan Date��6%    68   �� *
LoanDate+ �� StringFormat$ 
dd/MM/yyyy��  5      $ Expire Date��6%    6:   �� *	ExpDate+$ 
dd/MM/yyyy��  5      $ Quantity��6%    67   �� *
Quantity+   	CellStyle 5!      �� 5"       �� 
TargetType*
  $System.Windows.Controls.DataGridCell" 
 6     CellDefault �� BasedOn# [ 62    �� Triggers 5#      P� 5$       P� Property �@
 
IsSelected P� Value . . �5%      ��  �� Property � �� �� Value$ 14(�69   �� 5&       � ��
 �  ��6<   �� 5'       � ��
 �����6;   �� 5(       � ��
 �  ��6;   5)      5+         RowStyle 5.      �� 5/      )  #System.Windows.Controls.DataGridRow"  6    50      �� 51       �� Binding 6&   �� *	ExpDate+ �� 	Converter# [   �� Value True6q   .a�52      ��  � ��
 �  ��6;   53      P� 55       �@ 
IsSelected . 56      58      5:      5;      5<      