   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      8    2HungVuong_C5_Assignment.ucDetailLoanAndLoanHistory   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��History��6   $��20(�5      $
��Bold"�5      $��Center=�5      �� 5   
   -   5        $��	lbTabMenu��5      $��1��5         HorizontalListBox#��[  6   $
��5 10q�5      .@�5      �� .��6   Loan6    �� 5      .��6   Loan History6(   5      � 5   
   $��2��6    � ColumnDefinitions 5      �� 5       �� 5!      .+�5$      d� -   5        $��toggleButton��5&      $��0��5$      $��28��5%      
 � Tag$ Detail��5'      $
��Left=�5(       d� 	IsChecked 5+      �� *	IsChecked+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5,      �� 5.      -   5        $��	txtSearch��50        FloatingLabelTextBoxStyle#��[ 5.      $ Search��5/      $��1��52      $��Right=�53      $	��300��54      55      � 57   
   $��3��6   $	��450��58      $	��700��59      .+�5:      1   +HungVuong_C5_Assignment.ucLoanSlipsDataGrid  -   5          Name$ 
ucLoanSlip��5:   (   $��3��5;   (   $y�Visible=�5<   (   3   -HungVuong_C5_Assignment.ucLoanHistoryDataGrid  5>      -   5          Name$ ucLoanHistory��5>   *   $��3��5?   *   $y�	Collapsed=�5@   *   3   -HungVuong_C5_Assignment.ucLoanDetailsDataGrid  5B      -   5          Name$ ucLoanDetails��5B   *   $��3��5C   *   $y�	Collapsed=�5D   *   ;   5HungVuong_C5_Assignment.ucLoanDetailHistoriesDataGrid  5F      -   5        	  Name$	 ucLoanDetailHistories��5F   2   $��3��5G   2   $y�	Collapsed=�5H   2   5I      5J      5K      