   M S B A M L   `   `   `  ����N  JCapacitorCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CapacitorCalculatorCapacitorCalculator  5   	   $    CapacitorCalculator.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:CapacitorCalculator     5   	     � Title$  Capacitor Calculator��5
   	   $	��306��6&   $	��308��63   .��5      � $��
0,0,26,128q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6   $��Capacitance 1:��6-   �� 5   
   -   5         ��Name$ Capacitance1��5      $��0��6(   $��
0,0,-72,26q�65   $��2��6I   $��1��6Z   �� 5   
   $��1��6   $��0��6   $��Capacitance 2:��6-   �� 5   
   -   5        $ Capacitance2��5      $��1��6(   $��
0,0,-72,20q�65   $��2��6I   $��1��6Z   �� 5   
   -   5         ��Name$ SeriesButton��5      $��2��6'   $��0��64   $��Series��6D   6U   �� 5   
   -   5        $ ParallelButton��5      $��3��6)   $��Parallel��66   $��0,0,0,6q�6n   �� 5"   
   $��3��6   $��0��6   $��Total Capacitance:��6-   $��1,37,12,-37q�6J    J� RenderTransformOrigin$ 	0.5,-0.02&�6_   $��2��6�   �� 5#   
   -   5        $ TotalCapacitance��5#      $��3��6,    �� 
IsReadOnly$
 True��69   $��3,37,-50,-37q�6K   $��1��6a   �� 5$   
   $
��Left=�6   $	��103��6+   $��47,0,0,-175q�68   $��3��6M   $��Bottom=�6Z   $	��190��6u   $��2��6�   $��/SP.png��6�   5%      5&      