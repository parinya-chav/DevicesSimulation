   M S B A M L   `   `   `  ����  DevicesSimulationApp+    %DevicesSimulationApp.AddDevicesWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  AddDevicesWindow��5   	   $	��200��6"   $	��300��6/   .��5      � -   5        $��gridAddDevices��5      $��5q�6!    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5	      6!    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   .+�5   
   �� -   5        $��tbQty��5      $��7q�6   Number of Devices :6A   �� 5   
   $��5q�6   $��1��6    �� TextAlignment$ Right=�6-   .��6C   ��5      �� 5       �� Path$	 Qty�6   5      .��5      5      �� 5   
   $��7q�6   $��1��6    �� TextAlignment$ Right=�6,   
XML File :6N   �� 5   
   -   5        $��tbQtyXml��5      $��5q�6"   $��1��6-   $��1��6:   $ Right=�6J   .��6`   ��5      �� 5      $ QtyXml�6    �� Mode$ TwoWay=�6(   5      .��5      5       �� 5"   
   -   5        $��7q�5"      $��2��6   $ Right=�6,   Send Time(s) :6�   �� 5#   
   -   5        $��cmdCheckDefault��5#      $��5q�6*   $��2��65   $��1��6B   $��Center=�6R   .��5$   [   
default 5s6g   �� 5%   
   -   5        $��
tbSendTime��5%      $��5q�6$   $��3��6/   $��1��6<   $ Right=�6L   .��6b   ��5&      �� 5'      $ SendTime�6   $ TwoWay=�6*   5(      .��5)      5*      �� 5+   
   $��5q�6   $��4��6!   $��1��6.    �� Orientation$ 
Horizontal=�6>   .+�5,      �� -   5        $��cmdOK��5,      $��45��6"   .��6A   OK6E   �� 5-      -	   5        $��	cmdCancel��5-      $��45��6&   .��6I   Cancel6Q   5.      5/      50      