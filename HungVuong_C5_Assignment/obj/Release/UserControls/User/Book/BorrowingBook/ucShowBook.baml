   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity (    "HungVuong_C5_Assignment.ucShowBook   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:HungVuong_C5_Assignment     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     -   $��showBook��  � ToolTip  _� .���� -   $	��250��$	��250��$��Uniform=�.���� -   $��gbContainer��
���   �$	��5 0q�$	��230�� � Cursor$
 Hand��$��14(�
������ 
 � Tag �� *SelectedShowBook+ �� Mode$ TwoWay=�����  �� 
TargetType" ��.���  �� Property � z� �� Value T�  T� Y$ 0Q� �� Triggers P� 	 P� Property	 �@J�IsMouseOver
 P� Value
 .  N� EnterActions �� .���� .��W�  �� TargetProperty$8 2(UIElement.RenderTransform).(TranslateTransform.Y)�	 W� To$ -5X� g� Duration$ 0:0:0.2D� N� ExitActions �� .���� .��W� $8 2(UIElement.RenderTransform).(TranslateTransform.Y)�$ 0X�$ 0:0:0.2D�.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ MouseLeftButtonDown��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *AddBookCommand+   CommandParameter �� .��� -    �Name$ grdContainer�� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� $
��auto ��� .+��� $��Book: ��$��SemiBold"�$��14(��� $��
Quantity: ��$��1��$��SemiBold"�$��14(��� $��1��$
��Wrap=�$��Center=�$��13(����� *BookTitle.Name+�� -   $��
tbQuantity��$��1��$��1��$
��Wrap=�$��13(�$��Center=����� *
Quantity+ �� UpdateSourceTrigger$ PropertyChanged=�$ TwoWay=�