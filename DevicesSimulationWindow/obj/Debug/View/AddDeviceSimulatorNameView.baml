   M S B A M L   `   `   `  ����  DevicesSimulationWindow=    7DevicesSimulationWindow.View.AddDeviceSimulatorNameView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Add Device Simulator Name��5   	   $	��236��6+   $	��309��68    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5	      6"    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   .+�5   
   �� $��5q�6   $��Device Simulator Name:��6   6?   �� 5   
   $��5q�6   $��1��6   ��6-   �� *
HeadName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6{   �� 5   
   $��1��6   $��7q�6!   Number of Devices :6A   �� 5   
   $��5q�6   $��1��6   $��1��6*    �� TextAlignment$ Right=�6:   .��6P   ��5      �� 5       �� Path$	 Qty�6   5      .��5      5      �� 5   
   $��7q�6   $��2��6    �� TextAlignment$ Right=�6,   
XML File :6N   �� 5   
   $��5q�6   $��2��6   $��1��6*   $ Right=�6:   .��6P   ��5       �� 5!      $ QtyXml�6   $ TwoWay=�6(   5"      .��5#      5$      �� 5&   
   $��7q�6   $��3��6   $ Right=�6,   Send Time(s) :6S   �� 5'   
   $��5q�6   $��3��6   $��1��6+   $��Center=�6;   	 d� 	IsChecked	 5(      �� *IsDefaultTime+.��67   
default 5s6C   �� 5)   
   $��5q�6   $��4��6   $��1��6*   $ Right=�6:   .��6P   ��5*      �� 5+      $ SendTime�6   $ TwoWay=�6*   5,      .��5-      5.      �� 5/   
   $��1��6   $��5��6%   
 �� Orientation$
 
Horizontal=�62   .+�50      �� -   5        $��3q�50      $��50��6    ��6+   �� *	OkCommand+.��6]   OK6a   �� 51      -   5        $��3q�51      $��50��6    ��6+   �� *CancelCommand+.��6e   Cancel6m   52      53      54      