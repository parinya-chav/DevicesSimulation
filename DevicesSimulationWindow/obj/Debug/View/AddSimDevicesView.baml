   M S B A M L   `   `   `  ����  DevicesSimulationWindow4    .DevicesSimulationWindow.View.AddSimDevicesView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  AddDeviceSimView��5   	   $	��213��6"   $	��300��6/   .��5      � $��5q�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5      6!    � RowDefinitions 5
   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   .+�5   
   �� $��7q�6   Number of Devices :64   �� 5   
   $��5q�6   $��1��6    �� TextAlignment$ Right=�6-   .��6C   ��5      �� 5       �� Path$	 Qty�6   5      .��5      5      �� 5   
   $��7q�6   $��1��6    �� TextAlignment$ Right=�6,   
XML File :6N   �� 5   
   $��5q�6   $��1��6   $��1��6*   $ Right=�6:   .��6P   ��5      �� 5      $ QtyXml�6    �� Mode$ TwoWay=�6(   5      .��5      5      �� 5!   
   $��7q�6   $��2��6   $ Right=�6,   Send Time(s) :6S   �� 5"   
   $��5q�6   $��2��6   $��1��6+   $��Center=�6;    d� 	IsChecked 5#      �� *IsDefaultTime+.��67   
default 5s6C   �� 5$   
   $��5q�6   $��3��6   $��1��6*   $ Right=�6:   .��6P   ��5%      �� 5&      $ SendTime�6   $ TwoWay=�6*   5'      .��5(      5)      �� 5*   
   $��4��6   $��1��6"    �� Orientation$ 
Horizontal=�62   .+�5+      �� -   5        $��10q�5+      $��45��6!   ��6,   �� *
AddCommand+.��6`   OK6d   �� 5,      -   5        $��10q�5,      $��45��6!   ��6,   �� *CancelCommand+.��6f   Cancel6n   5-      5.      5/      