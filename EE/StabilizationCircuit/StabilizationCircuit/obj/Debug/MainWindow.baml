   M S B A M L   `   `   `  ����  StabilizationCircuit%    StabilizationCircuit.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   R NOxyPlot.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5   	     � Title$  Stabilization Circuit��5   	   $	��424��6'   $	��570��64   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��
R1 (ohms):��6-   �� 5   
   -   5        $��	R1TextBox��5   /   $��0��6   $��1��6   6/   �� 5   
   $��1��6   $��0��6   $��Vcc (volts):��6-   �� 5   
   -   5        $��
VccTextBox��5   /   $��1��6   $��1��6   6/   �� 5   
   -   5        $��2��5      $��1��6   $ ��Update Stabilization Curve��6.   $��129,10,195,0q�6�   $��25��6�   $	��Top=�6�     OxyPlot.Wpf.Plot  5   
   -   5        $��StabilizationPlot��5   4   $��2��6   $��2��6    $��	0,70,0,10q�6M      Title$ Stabilization Curve��5   A      Axes 5        OxyPlot.Wpf.LinearAxis  5        OxyPlot.Wpf.Axis   Position$ Bottom=�6!      Title$ IC (mA)��63     5      $
 Left=�6!   $ VCE (volts)��61      Series. 5        OxyPlot.Wpf.LineSeries  !  OxyPlot.Wpf.DataPointSeries   
DataFieldX$ IC��6G   	   
DataFieldY$		 VCE��6W   ��6   �� *StabilizationData+6W   5      5      5      