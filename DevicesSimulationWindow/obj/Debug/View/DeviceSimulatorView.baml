   M S B A M L   `   `   `  ����R  NDevicesSimulationWindow, Version=0.0.0.1, Culture=neutral, PublicKeyToken=nullW0clr-namespace:DevicesSimulationWindow.Extensions"DevicesSimulationWindow.Extensions  5   	   K*clr-namespace:DevicesSimulationWindow.ViewDevicesSimulationWindow.View  5   	   6    0DevicesSimulationWindow.View.DeviceSimulatorView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Blocal0clr-namespace:DevicesSimulationWindow.Extensions     5   	   9my*clr-namespace:DevicesSimulationWindow.View     5   	     � Title$  DeviceSimulatorView��5   	   $	��365��6%   $	��600��62    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5   	   �� *Main+   Locator �� Source# [   � 	Resources 5	      ;   5DevicesSimulationWindow.Extensions.ImagePathConverter  ImagePathConverter&   System.Windows.Controls.DataGrid �� 
TargetType �� Triggers P� Property P� Value	 �� Property
 �� Value)  #System.Windows.Controls.DataGridRow �� Binding �� Path �� Value*  $System.Windows.Controls.DataGridCell��%*  &	       '       '  �     '  �      5
   
   6@   �� 5   
   "  6    5      P� 5       �@ 
IsReadOnly . . �5      �� 	 �@ RowBackground

 �����66   5      5      �� 5   
   "  6    5      �� 5       6   �� $ Status� 16?   .a�5      �� 	 � ��

 �  ��6A   5      �� 5       6   �� $ Status� 36?   .a�5      �� 	 � ��

 � � �6C   5      5!      �� 5#   
   "  6    5$      P� 5%       �@ 
IsReadOnly . 5'      5)      5+      .��5,      � .+�5-   
   �� $��10q�6   .+�5.      `�  J� Opacity$ .9Q�6   .�5/      c� .@�50      ��  � ToolTip$	 New��6   ��6+   �� *
NewCommand+.��51      �� .+�52      �� $��/Icons/New-file-icon.png��6$   54      55      �� 56      $
 Load��6   ��6,   �� *OpenCommand+.��57      �� .+�58      �� $��/Icons/Load-icon.png��6$   5:      5;      5<      5=      `� 5>      $ .9Q�6   .�5O      c� .@�5P      ��  6   �� *	StartText+��6;   �� *StartCommand+.��5Q      �� .+�5U      �� $��16��6$   $��16��6/   $	��3,0q�6;   $��/Icons/Start-icon.png��6H   ��5V   "   �� 5W   &   " ��6,    5X   *   �� 5Y   .    6:   �� *
validStart+ true6Y   .a�5Z   2   �� 	 � ��$
 /Icons/Start-icon.png��6K   5[   /   �� 5\   .    6:   �� *
validStart+	 false6Y   .a�5]   2   �� 	 � ��$$
 /Icons/Start-Disabled-icon.png��6K   5^   /   5`   '   5b      5c      5d      �� 5e      $ Pause��6   ��6-   �� *PauseCommand+.��5f      �� .+�5g      �� $��/Icons/Pause-icon.png��6$   5i      5j      �� 5k      $
 Stop��6   ��6,   �� *StopCommand+.��5l      �� .+�5m      �� $��/Icons/Stop-icon.png��6$   5o      5p      5q      c� 5r      .@�5s      �� $	 Add��6   ��6+   �� *
AddCommand+.��5t      �� .+�5u      �� $��/Icons/Drive-add-icon.png��6$   5v      5w      �� 5x      $ Delete��6   ��6.   �� *DeleteCommand+.��5y      �� .+�5z      �� $"��/Icons/Drive-delete-icon.png��6$   5{      5|      5}      5~        5�         AutoGenerateColumns .     CanUserAddRows .  $	��250��5�      ��6   �� *SimDeviceList+   
IsReadOnly 6D   �� *	IsRunning+ �� SelectedItem 5�      �� *SelectedSimDevice+ J� InputBindings 5�      �� 5�      
 �� Key$ Delete��6!    �� Command 6.   �� *DeleteSimDeviceCommand+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$
 Imei��6)      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�      �� $
 Imei�   SortDirection 67   Z� 5�        5�      $ Description��6)    .   5�   %   �� $ Description� 6J   Z� 5�        5�      $ Time(s)��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6:    .   5�   %   �� $ SendTime� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� 6z   Z� 5�      4	  .System.Windows.Controls.DataGridTemplateColumn	  5�      $ * 6-   $ Complete��67    .   	  CellTemplate 5�      �� 5�      .R�5�   "   �� $
��Wrap=�6O     �� TextAlignment$  Right=�6c   ��6,   �� $ SendComplete�6{   5�      5�      	  5�      $ * 6-   $ Total��67    .  5�      �� 5�      .R�5�   "   �� $  Right=�6L   ��6,   �� $ 	SendTotal�6d   5�      5�      4
  .System.Windows.Controls.DataGridComboBoxColumn
  5�      $ Status��6-    . ! 
  SelectedValuePath$! StatusID��5�      " 
  DisplayMemberPath$" Description��5�      # 
  SelectedValueBinding# 5�      �� *Status+$ 
  ElementStyle$ 5�      �� 5�      " ��6$   .�5�   "   �� 	 � ��
 6@   �� % �� RelativeSource% �� *Findancestor+& �� AncestorType"& �$# DataContext.StatusWorkingList�5�      ' 
  EditingElementStyle' 5�      �� 5�      " ��6$   .�5�   "   �� 	 � ��
 6@   �� % �� *Findancestor+"& �$# DataContext.StatusWorkingList�5�      5�      5�      5�      5�      5�      