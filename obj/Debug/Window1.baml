   M S B A M L   `   `   `  ����C  ?Hoz_Shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Hoz_ShopHoz_Shop  5   	       Hoz_Shop.Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Hoz_Shop     5   	     � Title$!  Окно волонтера��5   	   $	��447��6    $	��717��6-   ���	#FF7581AA$	��400��6P   $	��350��6_    � 
ResizeMode$ CanMinimize=�6o   .��5	      � $��0,0,2,2q�6    � ColumnDefinitions 5
   
   �� 5      $��3* �6   �� 5      $	��11* �6   �� 5      $��8* �6   �� 5      $	��37* �6   �� 5      $	��76* �6   �� 5      $	��94* �6   �� 5      $	��94* �6   �� 5      $
��178* �6   �� 5      $	��99* �6   �� 5      $
��115* �6   .+�5   
   �� -   5         ��Name$ tabik��5      $��10��6$   .@�5      �� -   5        $��tabIitemContent��5      $��Мероприятия��6-   ���	#DDFFFFFF��5      � 5      -   5        $��fk��5      ���	#FF7581AA$	��777��6<    5      �� 5      $
��288* �6/   �� 5      $
��491* �6/   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
EventsUser��5   #   $��
233,0,61,0q�67   $��2��6K      AutoGenerateColumns .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .  	   CanUserDeleteRows	 .  
   
IsReadOnly
 . $
��Auto��6�   $
��Auto��6	   � 	Resources 5       �� 
TargetType   WrapText �� Property �� Value��%T   &	        �� 5    "   " ��6(   .�5!   &   ��  � ��$
 Wrap=�6E   5"   #   5#         Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Мероприятие��6T      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6i   1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [  6s      Binding 65   �� *	EventName+6�     5&   "   $ Категория��6R   $ * 6e   # [  6o    65   �� *
Category+6�     5'   "   $ 
Место��6S   $ * 6b   # [  6l    65   �� *
Location+6�     5(   "   $ Дата��6S   $ * 6a   # [  6k    65   �� *	EventDate+6k     5)   "   $ Статус��6P   $ * 6`   # [  6j    65   �� *Status+6�   5+      �� 5,      $��Статус задачи��6    $
��Left=�68   $��	42,68,0,0q�6S   $	��Top=�6f    J� RenderTransformOrigin$ -0.111,0.667&�6~   ���	#DDFFFFFF$��16(�6�   $
��Bold"�6�   $	��162��6�   �� 5-      -   5        $��Выполнить��5-   !   $
��Left=�65   $��
12,169,0,0q�6P   $	��Top=�6d   $	��192��6|    � Cursor$	 Pen��6�   $��16(�6�   �� 5.      -   5         ��Name$ 
simpleList��5.   4   $
��Left=�6I   $��38��6d   $	��Top=�6q   $	��136��6�   $ �� IsSynchronizedWithCurrentItem$ FalseY�6�    �� SelectedIndex$ 0��6�   $��16(�6�   $��-368,191,0,0q�6�   ��6#   Z� 6�   �� 5/      -   5        $��uservera��5/   v   $
��Left=�6#   $��
42,120,0,0q�6>   $	��Top=�6R   $	��120��6j   
�������6�   50      53      �� 54      -   5         ��Name$ backgroundcolor��54      $)��#Выполненные задачи��6/   .��55      �  56      �� 57      $
��282* �6+   �� 58      $
��497* �6+   .+�5:        -	   5        $ 	vpzadachi��5:      $��2��62    .   .   .   .  	 .  
 . $
��Auto��6�   $
��Auto��6�    5;      ��%T   &	        �� 5<      " ��6$   .�5=   "   ��  � ��$
 Wrap=�6A   5>      5?       5@        5A      $ Название��6P   $ * 6b   # [  6l    61   �� *	EventName+6l     5B      $ Категория��6N   $ * 6a   # [  6k    61   �� *
Category+6k     5C      $ 
Место��6O   $ * 6^   # [  6h    61   �� *
Location+6h     5D      $ Дата��6P   $ * 6^   # [  6h    61   �� *	EventDate+6h     5E      $ Статус��6M   $ * 6]   # [  6g    61   �� *Status+6g   5G      5H      5J      5M      �� 5N   
   $��9��6   $��ContentControl��6)   $
��Left=�6B   $��301,347,0,0q�6]   $	��Top=�6r   5O      5P      