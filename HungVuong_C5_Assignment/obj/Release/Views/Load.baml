   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  "    HungVuong_C5_Assignment.Load   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:HungVuong_C5_Assignment       � WindowStartupLocation$  CenterScreen=� � SizeToContent$ WidthAndHeight=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=�
������  � AllowsTransparency .  � Title$
 Load��$	��300��$	��300�� � 	Resources    	FadeInOut g� RepeatBehavior �� TargetProperty	 W� From	
 W� To g� Duration g� AutoReverse��%Z   &	        �� $ Forever��.��W� $ Opacity�$		 1.0X�$	
 0.3X�$ 0:0:1D� . .��� -   $��
grdLoading��$��1��.+���  �� CornerRadius$ 25��$��70��$��70��$��3q��� 
���� ��$��0 3 0 0q� J� RenderTransformOrigin$ 0.5,0.5&�$ 25��$��70��$��70������  �� 
TargetType" ��.���  �� Property � z� �� Value ��  �� Angle$ 0Q� �� Triggers :�  :� RoutedEvent$ Loaded��.[��� .���� .��W� $6 0(Border.RenderTransform).(RotateTransform.Angle)�$	 0X�$	
 370X�$ 0:0:2D�$ Forever���� 
����  �$��3 0 0 0q�$ 0.5,0.5&�$ 25��$��70��$��70������ " ��.���  � z� �� $ 0Q� :� $ Loaded��.[��� .���� .��W� $6 0(Border.RenderTransform).(RotateTransform.Angle)�$	 0X�$	
 370X�$ 0:0:2D�$ Forever���� 
���� ��$��0 0 0 3q�$ 0.5,0.5&�$ 25��$��70��$��70������ " ��.���  � z� �� $ 0Q� :� $ Loaded��.[��� .���� .��W� $6 0(Border.RenderTransform).(RotateTransform.Angle)�$	 0X�$	
 370X�$ 0:0:2D�$ Forever���� 
���  ��$��0 0 3 0q�$ 0.5,0.5&�$ 25��$��70��$��70������ " ��.���  � z� �� $ 0Q� :� $ Loaded��.[��� .���� .��W� $6 0(Border.RenderTransform).(RotateTransform.Angle)�$	 0X�$	
 370X�$ 0:0:2D�$ Forever���� $
��Load��$��14(�$��SemiBold"�$��15 20 15 15q����#DCCB94 � Triggers :� $ Loaded��.[��� #��[  