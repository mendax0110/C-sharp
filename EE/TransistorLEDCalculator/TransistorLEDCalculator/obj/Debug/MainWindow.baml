   M S B A M L   `   `   `  ����  TransistorLEDCalculator(    "TransistorLEDCalculator.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Transistor LED Calculator��5   	   $	��406��6+   $	��604��68    � 
ResizeMode$ NoResize=�6D   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Supply Voltage (V):��6-   �� 5   
   -   5        $��txtSupplyVoltage��5      $��0��6   $��111,0,389,23q�67   $��2��6M   �� 5   
   $��1��6   $��0��6   $��LED Voltage (V):��6-   $��
0,0,487,26q�6H   $��2��6\   �� 5   
   -   5        $��txtLedVoltage��5      $��1��6   $��Right=�64   $��	0,0,390,3q�6P   $	��103��6c   �� 5   
   $��2��6   $��0��6   $��LED Current (mA):��6-   �� 5   
   -   5        $��txtLedCurrent��5      $��1��6   $��111,23,389,26q�64   $��3��6K   �� 5   
   $��3��6   $��0��6   $��Transistor hFE:��6-   �� 5   
   -   5        $��txtHfe��5      $��3��6   $��111,0,390,286q�6-   $��2��6D   �� 5   
   -   5        $��btnCalculate��5   .   $��1��6   $��0��6   $��	Calculate��6B   $��50��6q   $��343,11,56,17q�6}   $	��NaN��6�   $��3��6�   �� 5   
   $��4��6   $��0��6   
���   �$��1q�6B   $��
16,10,4,10q�6V    �� Padding$ 10q�6j   ._�5      �� -   5        $��graphCanvas��5      $	��400��6(   $	��200��64   5      5      5      