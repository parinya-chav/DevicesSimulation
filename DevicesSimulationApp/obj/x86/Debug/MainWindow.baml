   M S B A M L   `   `   `  ����  DevicesSimulationApp%    DevicesSimulationApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Devices Simulation��5   	   $	��350��6$   $	��700��61    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value �� EndPoint �� 
StartPoint � Color � Offset   ReadOnlyFinish)  #System.Windows.Controls.DataGridRow	 �� Triggers
 �� Binding �� Value��%�  '        &	  5    �� 5   
   "  6   .�5      ��  � �� 5      �� 5	      $ 0.1,1&�6*   $ 0.1,0&�6;   .��5
      � $ 	#ff777777��6'   $ 0Q�69   � 5      $ 	#ff232323��6'   $ .4Q�69   � 5      $ 	#ff000000��6'   $ .4Q�69   � 5      $ 	#ff232323��6'   $ 1Q�69   5      5      �� 5       � ��$ 14(�6)   �� 5       � ��$ 5q�6(   �� 5       � ��
 �����6;   �� 5       � ��
 �   �6<   �� 5       �@J�Opacity$ .9Q�6(   65   �� 5       � ��$ 1q�60   5      �� 5   
   "  6'   	 5      �� 5      
 6   �� *Finish+ True69   .a�5      ��  �@ Item$ ReadOnly��6-   6@   5      5      5       .��5!      �  � RowDefinitions 5"   
   �� 5#      $
��Auto �6   6,   �� 5$      6   .+�5&   
   `�  J� Opacity$ .9Q�6   .�5'      c� $ .9Q�6   .@�5(      �� -   5        $��cmdSelectAll��5(      .��6q   	SelectAll6|   5)      c� 5*      .@�5+      �� -   5        $��cmdPause��5+       � ToolTip$ Pause��6)   .��5,      �� .+�5-      �� $��Icons/Pause-icon.png��6    5.      5/      �� 50      -   5        $��cmdStop��50      $
 Stop��6(   .��51      �� .+�52      �� $��Icons/Stop-icon.png��6    53      54      �� 55      -   5        $��cmdStart��55      $ Start��6)   .��56      �� .+�57      �� $��Icons/Start-icon.png��6    58      59      5:      c� 5;      .@�5<      �� -   5        $��cmdAdd��5<      $	 Add��6'   .��5=      �� .+�5>      �� $��Icons/Drive-add-icon.png��6    5?      5@      �� 5A      -   5        $��	cmdDelete��5A      $ Delete��6*   .��5B      �� .+�5C      �� $!��Icons/Drive-delete-icon.png��6    5D      5E      5F      5G      &   System.Windows.Controls.DataGrid  5L   
   -   5        $��gridDevices��5L       $��1��6   $��5q�63      AutoGenerateColumns .     CanUserAddRows .  $��Center=�5M   *      CanUserReorderColumns .     Columns 5Q      4  .System.Windows.Controls.DataGridCheckBoxColumn  5R      1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *CheckChoose+ �� UpdateSourceTrigger$ PropertyChanged=�0  *System.Windows.Controls.DataGridTextColumn  5T      ,  &System.Windows.Controls.DataGridColumn   Header$
 Imei��6%      MinWidth$	 200Q�63      
IsReadOnly .  5U   %   ��  �� Path$
 Imei�   SortDirection 6C   Z� 5V        5X      $ Description��6%    .  5Y   %   �� $ Description� 6J   Z� 5Z      4  .System.Windows.Controls.DataGridComboBoxColumn  5[      $ Status��6)   -	   5        gridComboStatus��   Width5	  /System.Windows.Controls.DataGridLengthConverter$ *	 5[   R    .    DisplayMemberPath$ Description��5\   )      SelectedValuePath$ StatusID��6I      SelectedValueBinding 5]   )   �� $ Status�5^      4
  .System.Windows.Controls.DataGridTemplateColumn
  5`      $ *	 6)   $ Time(s)��63    .  
  CellTemplate 5a      �� 5b      .R�5c      �� $
��Wrap=�6G    �� TextAlignment$ Right=�6[   ��6(   �� $ SendTime�6s   5d      5f      
  5h      $ *	 6)   $ Complete��63    .  5i      �� 5j      .R�5k      �� $
��Wrap=�6K   $ Right=�6_   ��6(   �� $ SendComplete�6w   5l      5n      
  5p      $ *	 6)   $ Total��63    .  5q      �� 5r      .R�5s      �� $ Right=�6H   ��6(   �� $ 	SendTotal�6`   5t      5v      
  5x      $ *	 6)   $ Finish��63    .  5y      �� 5z      .R�5{      �� $ Center=�6E   ��6(   �� $ Finish�6^   5|      5~      5�      5�      5�      