   M S B A M L   `   `   `  ����  SiliconDiodePlotter$    SiliconDiodePlotter.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Silicon Diode Plotter��5   	   $	��350��6'   $	��525��64   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��5q�6;   .+�5      �� $��Reverse Bias Voltage (V):��6   �� 5      -   5         ��Name$ ReverseBiasVoltageTextBox��5      $	��100��69   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��5q�6;   .+�5      �� $��Saturation Current (A):��6   �� 5      -   5        $ SaturationCurrentTextBox��5      $	��100��68   5      �� 5   
   $��2��6   $ 
Horizontal=�6"   $��5q�6;   .+�5      �� $��Ideality Factor (V):��6   �� 5      -   5        $ IdealityFactorTextBox��5      $	��100��65   5      �� 5   
   $��3��6   $ 
Horizontal=�6"   $��5q�6;   .+�5      �� -   5         ��Name$ CalculateButton��5      $��	Calculate��6.   6B   5      �� 5!   
   -   5         ��Name$ ResultTextBlock��5!      $��4��6-   $��5q�6:   5"      5#      