   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      (    "HungVuong_C5_Assignment.ucShowBook   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	      -   5        $��showBook��5        � ToolTip  5      _� 5   
   .��5      �� -   5        $	��250��5      $	��250��6    $��Uniform=�6-   6?   5      .��5      �� -   5        $��gbContainer��5      
���   �$	��5 0q�5      $	��230��5       � Cursor$
 Hand��5      $��14(�5      
������ 
 � Tag 5      �� *SelectedShowBook+ �� Mode$ TwoWay=���5   
   �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � z� �� Value 5      T� 5       T� Y$ 0Q�6-   5       �� Triggers 5       P� 5!      	 P� Property	 �@J�IsMouseOver
 P� Value
 .  N� EnterActions 5"      �� 5#      .��5$   "   �� .��5%   &   W�  �� TargetProperty$8 2(UIElement.RenderTransform).(TranslateTransform.Y)�66   	 W� To$ -5X�5&   6    g� Duration$ 0:0:0.2D�5'   6   5(   #   5)       N� ExitActions 5+      �� 5,      .��5-   "   �� .��5.   &   W� $8 2(UIElement.RenderTransform).(TranslateTransform.Y)�66   $ 0X�5/   6   $ 0:0:0.2D�50   6   51   #   52      54      56      .  (System.Windows.Interactivity.Interaction   Triggers 59   
   /  )System.Windows.Interactivity.EventTrigger  5:         	EventName$ MouseLeftButtonDown��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5;      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6(   �� *AddBookCommand+   CommandParameter 5<   (   �� 5=      .��5@   
   � -   5         �Name$ grdContainer��5@       � RowDefinitions 5A      �� 5B      $
��auto �6    �� 5C      $
��auto �6    �� 5D      $
��auto �6    �� 5E      $
��auto �6    �� 5F      $
��auto �6     � ColumnDefinitions 5I      �� 5J      $
��auto �6#   �� 5K      .+�5N      �� $��Book: ��6   $��SemiBold"�5O      $��14(�5P      �� 5a      $��
Quantity: ��6   $��1��5b      $��SemiBold"�5c      $��14(�5d      �� 5f      $��1��6   $
��Wrap=�5h      $��Center=�5i      $��13(�5j      ��5g      �� *BookTitle.Name+5j      �� 5�      -   5        $��
tbQuantity��5�      $��1��5�      $��1��5�      $
��Wrap=�5�      $��13(�5�      $��Center=�5�      ��5�      �� *
Quantity+ �� UpdateSourceTrigger$ PropertyChanged=�$ TwoWay=�5�      5�      5�      5�      