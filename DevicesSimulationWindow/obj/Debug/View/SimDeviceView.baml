   M S B A M L   `   `   `  ����  DevicesSimulationWindow0    *DevicesSimulationWindow.View.SimDeviceView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � DataContext  5      �� *	SimDevice+   Locator �� Source# [  .��5
      � $	��131��6   $	��364��6   $��5q�6$    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5      6!   �� 5      $
��Auto �6   6.   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $
��Imei��6   $��5q�6    $��Center=�6+   �� 5   
   $��5q�6   $��1��6   $��2��6-   $��Center=�6A   $	��100��6\   $��25��5   4   $
��Left=�6@   ��6   �� *Imei+ �� Mode$ TwoWay=�6@   �� 5   
   $��1��6   $��5q�6!   $��Description��6,   $��Center=�6?   �� 5   
   $��1��6   $��1��6   $��5q�6/   $��Center=�6:   $	��100��5   ;   $��25��6G   $
��Left=�6S   ��6   �� *Description+$ TwoWay=�6S   �� 5   
   $��1��6   $��2��6!   $��5q�61   $��Center=�6<   $��Status��6W   �� 5   
   $��1��6   $��3��6   $��5q�6/   $��Center=�6:   $	��100��5   6   $��25��6B   $
��Left=�6N   ��6   �� *Status+$ TwoWay=�6N   �� 5   
   $��2��6   $��0��6!   $��5q�61   $��Center=�6<   $��Total��6W   �� 5    
   $��2��6   $��1��6   $��5q�6/   $��Center=�6:   $	��100��5!   9   $��25��6E   $
��Left=�6Q   ��6   �� *	SendTotal+$ TwoWay=�6Q   �� 5"   
   $��2��6   $��2��6!   $��5q�61   $��Center=�6<   $��Complete��6W   �� 5#   
   $��2��6   $��3��6   $��5q�6/   $��Center=�6:   $	��100��5$   <   $��25��6H   $
��Left=�6T   ��6   �� *SendComplete+$ TwoWay=�6T   5%      5&      