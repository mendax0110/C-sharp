   M S B A M L   `   `   `  ����  ACResistanceDiodeCircuit)    #ACResistanceDiodeCircuit.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5   	     � Title$!  AC Resistance Diode Circuit��5   	   $	��524��6-   $	��862��6:   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Diode Voltage Drop (Vd):��6   �� 5   
   -   5         ��Name$ DiodeVoltageDropTextBox��5      $��0��6   $��
162,0,0,26q�6@   $��2��6T   �� 5   
   $��1��6   $��Resistor Value (R):��6   �� 5   
   -   5        $ ResistorValueTextBox��5      $��1��6   $��
162,0,0,20q�6=   $��2��6Q   �� 5   
   -   5        $��2��5      $��	Calculate��6   62   �� 5   
   $��3��6   $��Circuit Resistance (Rc):��6   �� 5   
   -   5         ��Name$  CircuitResistanceTextBlock��5   !   $��3��6   $��162,0,0,410q�6E   $��2��6Z     OxyPlot.Wpf.Plot  5   
   -   5          Name$
 Plot��5       $��4��6   $��42,30,42,30q�6.   5      5      