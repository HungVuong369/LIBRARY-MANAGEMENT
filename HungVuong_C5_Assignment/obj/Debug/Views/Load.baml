   M S B A M L   `   `   `  ����R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  5   	   "    HungVuong_C5_Assignment.Load   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:HungVuong_C5_Assignment     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � SizeToContent$ WidthAndHeight=�5	   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency .  � Title$
 Load��5   	   $	��300��6   $	��300��6#    � 	Resources 5         	FadeInOut g� RepeatBehavior �� TargetProperty	 W� From	
 W� To g� Duration g� AutoReverse��%�   &	        �� 5   
   $ Forever��6'   .��5      W� $ Opacity�6   $		 1.0X�5      $	
 0.3X�6   $ 0:0:1D�6%    . 66   5      5      .��5      � -   5        $��
grdLoading��5      $��1��5      .+�5   
   ��  �� CornerRadius$ 25��6   $��70��6#   $��70��6/   $��3q�5      5      �� 5   
   
���� ��$��0 3 0 0q�5       J� RenderTransformOrigin$ 0.5,0.5&�5      $ 25��5      $��70��6#   $��70��6/   ��5       �� 5!       �� 
TargetType" ��6   .�5"      ��  �� Property � z� �� Value 5#      �� 5$       �� Angle$ 0Q�6.   5&       �� Triggers 5'      :� 5(       :� RoutedEvent$ Loaded��6'   .[�5)      �� .��5*   "   �� .��5+   &   W� $6 0(Border.RenderTransform).(RotateTransform.Angle)�66   $	 0X�5,   6   $	
 370X�6?   $ 0:0:2D�6H   $ Forever��5-   6   5.   #   5/      50      52      54      �� 56   
   
����  �$��3 0 0 0q�57      $ 0.5,0.5&�58      $ 25��59      $��70��6#   $��70��6/   ��5:      �� 5;      " ��6   .�5<      ��  � z� 5=      �� 5>      $ 0Q�6.   5@       5A      :� 5B      $ Loaded��6'   .[�5C      �� .��5D   "   �� .��5E   &   W� $6 0(Border.RenderTransform).(RotateTransform.Angle)�66   $	 0X�5F   6   $	
 370X�6?   $ 0:0:2D�6H   $ Forever��5G   6   5H   #   5I      5J      5L      5N      �� 5P   
   
���� ��$��0 0 0 3q�5Q      $ 0.5,0.5&�5R      $ 25��5S      $��70��6#   $��70��6/   ��5T      �� 5U      " ��6   .�5V      ��  � z� 5W      �� 5X      $ 0Q�6.   5Z       5[      :� 5\      $ Loaded��6'   .[�5]      �� .��5^   "   �� .��5_   &   W� $6 0(Border.RenderTransform).(RotateTransform.Angle)�66   $	 0X�5`   6   $	
 370X�6?   $ 0:0:2D�6H   $ Forever��5a   6   5b   #   5c      5d      5f      5h      �� 5j   
   
���  ��$��0 0 3 0q�5k      $ 0.5,0.5&�5l      $ 25��5m      $��70��6#   $��70��6/   ��5n      �� 5o      " ��6   .�5p      ��  � z� 5q      �� 5r      $ 0Q�6.   5t       5u      :� 5v      $ Loaded��6'   .[�5w      �� .��5x   "   �� .��5y   &   W� $6 0(Border.RenderTransform).(RotateTransform.Angle)�66   $	 0X�5z   6   $	
 370X�6?   $ 0:0:2D�6H   $ Forever��5{   6   5|   #   5}      5~      5�      5�      �� 5�   
   $
��Load��6   $��14(�5�      $��SemiBold"�5�      $��15 20 15 15q�5�      ���#DCCB94 � Triggers 5�      :� 5�      $ Loaded��6   .[�5�      �� #��[  6&   5�      5�      5�      5�      