   M S B A M L   `   `   `  ���� R  NHungVuong_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HungVuong_C5_AssignmentHungVuong_C5_Assignment  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Color   ExpandCollapseToggleStyle'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard	 �� TargetProperty
 �� 
TargetName R� KeyTime  System.Windows.Visibility   Hidden R� Value   Visible F�Name  TreeViewItemFocusVisual �� StrokeDashArray J� Opacity �� Path �� RelativeSource �� AncestorType �Name �� Mode � ColumnDefinitions � RowDefinitions8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value W� From	 W� To g� Duration   	Collapsed J� RenderTransformOrigin  d�Name! �� 	ClickMode" d� 	IsChecked# ��Name$ �� Padding% ��Name& ��Name' �� Triggers( P� Property) P� Value* N� EnterActions+ ��Name, g� RepeatBehavior- g� AutoReverse. N� ExitActions/ �� BeginStoryboardName0 �� 
TargetName1 ]� 
Conditions2 �� Property3 �� Value  TreeViewItemStyle4 �� Orientation5 ��Name�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     /local%clr-namespace:HungVuong_C5_Assignment  %�  'R�       &	  +    &	 l    'Q� �    7  7   &	 �    �� "  R�.���  �@�OverridesDefaultStyle . ��  �@J�SnapsToDevicePixels . ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� �� " R�.R��� $��Border��$ 1��$��1q����� $ Transparent������ $ Transparent��._��� |�.  ��.  $��4q�.���� �� "  d�.���  � |� .  ��  � �� �� " d�.R�� $��15��$��13��
������    CheckStates��.   Checked��. �� .��T� $	 (UIElement.Visibility)�$
 	Collapsed��..�i� $ 0��# Z T� $	 (UIElement.Visibility)�$
 Expanded��..�i� $ 0��# Z   	Unchecked��  Indeterminate��.+�F� $ 	Collapsed��$
��Left=�$��Center=�$��1q�"���� 	=     � z  	= � 	=  z 	���� $ #9FA7B5��F� $ Expanded��$
��Left=�$��Center=�$��1q�"����     	= � z  	= � 	=  z 	$y�Hidden=����� $ #C4C9D5���� .���  � �� �� .R��� ._��� $��0,0,0,0q�$��5��
���   �$	 1 2R�$ 0Q��� "  Q�.���  � ��
 ���� ��  � ��$ 14(���  � ��$ SemiBold"���  � �� �� $  HorizontalContentAlignment� �� " ����  � �� �� $ VerticalContentAlignment� �� " ����  � ��$ 1,0,0,0q���  � �� �#7D84AB��  �@�FocusVisualStyle8   ��  � �� �� " Q�.R�� $ grdMain������ $ 
Background� �� $ FindAncestor=�" Q� �� $��19��$��15 ��� $��* ��� $
��Auto � �� $
��Auto ���    SelectionStates��.   Selected��. �� .���� $
 Bd��$0	 *(Panel.Background).(SolidColorBrush.Color)�.g�  $ 0��$ Transparent���� $
 PART_Header��$4	 .(TextBlock.Foreground).(SolidColorBrush.Color)�.g�  $ 0��$ #D4D9E3��  
Unselected��  SelectedInactive��. �� .���� $
 Bd��$0	 *(Panel.Background).(SolidColorBrush.Color)�.g�  $ 0��$ Transparent��  ExpansionStates��.   Expanded��. �� .��T� $	 (UIElement.Visibility)�$
 	ItemsHost��..�i� $ 0��# Z W� $
 	ItemsHost��$	 Opacity�$ 0X�$ 1X�$ 0:0:0.3D�  	Collapsed��. �� .���� .��T� $	 (UIElement.Visibility)�$
 	ItemsHost��..�i� $ 0��# Z W� $
 	ItemsHost��$	 Opacity�$ 1X�$ 0X�$ 0:0:0.3D�T� $	 (UIElement.Visibility)�$
 	ItemsHost��..�i� $ 0:0:0.3��# Z .+��� $��	imgHeader��$��0��$	 0.5Q�$ 0.5,0.5&����� $	 Tag� �� $ FindAncestor=�" Q�z��� d� $  Expander��8�� $! Press=�$��2��$	 0.5Q�" �� *
IsExpanded+ �� *TemplatedParent+�� $# Bd��$��1��#��z��#��z��#��z��#$ z��._��� $% PART_Header��$��Header��$
��Left=�$
��10 0q��� $& 	ItemsHost��$��1��$��1��$��2��$y�	Collapsed=�' P� ( �@J�IsMouseOver) . * �� $+ imgHeaderAnimation��.���� $, Forever��- . .��W� $
 	imgHeader��$	 RenderTransform.Angle�$	 -10X�$ 10X�$ 0:0:0.3D�. �� $/ imgHeaderAnimation��P� ( �@J�IsMouseOver) . . ��� $0 Bd�� � ��
 ���� �� $0 PART_Header�� � �� �#D4D9E3�� $0 	imgHeader�� �@J�Opacity$ 1Q��� $0 Expander�� �@J�Opacity$ 1Q�P� ( �@J�IsKeyboardFocusWithin) . . ��� $0 Bd�� � ��
 ���� �� $0 PART_Header�� � �� �#C4C9D5�� $0 	imgHeader�� �@J�Opacity$	 0.5Q��� $0 Expander�� �@J�Opacity$	 0.5Q�P� ( �@Q�
IsSelected) . . ���  � �� �#D4D9E3�� $0 	imgHeader�� �@J�Opacity$ 1Q��� $0 Expander�� �@J�Opacity$ 1Q�P� ( �@��HasItems) .  . ��� $0 Expander�� � y�$ Hidden=�]� 1 �� 2 � ��3 .  �� 2 � ��$
3 Auto��./��� $0 PART_Header�� � ��$ 75��]� 1 �� 2 � ��3 .  �� 2 � ��$
3 Auto��./��� $0 PART_Header�� � ��$ 19���� "  Q�.���  � �� �� .R��� $4 
Horizontal=�.+��� $5 checkBox123��$��Right=�$��0q��� $��5,0,0,0q����� 