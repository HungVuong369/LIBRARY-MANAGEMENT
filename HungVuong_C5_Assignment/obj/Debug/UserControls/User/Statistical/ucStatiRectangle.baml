   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5      .    (HungVuong_C5_Assignment.ucStatiRectangle   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HungVuong_C5_Assignment     5      .��5	      �� -   5          ��Name$  gbContainer��5      $	��210��5	      $	��120��5
      $��	30 30 0 0q�5      ���#A6A6A6$��20(�5      $��SemiBold"�5      
������ ��5   
   �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � z� �� Value 5      T� 5       T� Y$ 0Q�6-   5       �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value .  N� EnterActions 5      �� 5      .��5   "   �� .��5   &   W� 	 �� TargetProperty$8	 2(UIElement.RenderTransform).(TranslateTransform.Y)�66   	
 W� To$	
 -10X�5   6    g� Duration$ 0:0:0.2D�5   6   5    #   5!       N� ExitActions 5#      �� 5$      .��5%   "   �� .��5&   &   W� $8	 2(UIElement.RenderTransform).(TranslateTransform.Y)�66   $
 0X�5'   6   $ 0:0:0.2D�5(   6   5)   #   5*      5,      5.      .��50   
   �  � ColumnDefinitions 51      �� 52      $
��auto �6#   �� 53      .+�56      F� -   5        $
��path��59      $��Center=�56      $��Center=�57      $��10q�58      
���   � �� Stretch$ Uniform=�5;      $��50��5<      $��50��5=      ��5>      ��  �� Path$	 Tag� �� RelativeSource ��  �� Mode$
 Self=�5?      �� 5A      -   5        $��
tbQuantity��5E      $��Right=�5A      $��Center=�5B      $��25(�5C      ���#1ABC9C$��10q�5F      $��1��5G      5W      5X      5Y      