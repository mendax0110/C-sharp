   M S B A M L   `   `   `  ����E  AADC_Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ADC_Reader
ADC_Reader  5   	       ADC_Reader.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ADC_Reader     5   	     � Title$  
ADC Reader��5   	   $	��440��6   $	��676��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��5q�6-   $��Right=�68   $��Center=�6T   $��Port:��6o   �� 5   
   -   5         ��Name$ PortTextBox��5   :   $��0��6   $��1��6   $��5q�6/   6:   �� 5   
   -   5         ��Name$ ConnectButton��5   �   $��2��6   $��1��6   $��	216,0,0,0q�6.   $
��Left=�6A   $��Center=�6\   $��Connect��6w    J� RenderTransformOrigin$ 4.906,10.02&�6�   �� 5   
   -   5        $ DisconnectButton��5   �   $��2��6   $��1��6   $��	294,0,0,0q�6.   $
��Left=�6A   $��Center=�6\   $��
Disconnect��6w   ${�False��6�   �� 5   
   $��1��6   $��0��6   $��5q�6-   $��Right=�68   $��Center=�6T   $��Voltage:��6o   �� 5   
   -   5        $ VoltageTextBox��5   :   $��1��6   $��1��6   $��5q�6/    �� 
IsReadOnly$
 True��6R   �� 5   
   -   5        $ RequestButton��5   �   $��2��6   $��1��6   $��	131,5,0,0q�6.   $
��Left=�6A   $	��Top=�6\   $��Request��6t   $ 0.971,0.678&�6�   o� 5   
   $��2��6   $��
10,5,513,5q�6   $��1��60   .@�5      m� $��Measurement��6   .@�5      m� -   5        $��Voltage��5      
 � Tag$ VOLTAGE��6,   6:   m� 5      -   5        $��Current��5      $ CURRENT��6,   6:   m� 5       -   5        $��
Resistance��5       $ 
RESISTANCE��6/   6@   5!      5"      �� 5#   
   $��1��6   $
��Left=�6    $	��222��6;   $��777,579,0,0q�6H   $��4��6]   $	��Top=�6j   $	��454��6�   �� 5$   
   $��1��6   $
��Left=�6    $��65��6;   $��
154,77,0,0q�6G   $��4��6[   $	��Top=�6h   $	��152��6�   �� 5%   
   $��1��6   $
��Left=�6    $	��290��6;   $��	141,0,0,0q�6H   $��4��6[   $��Center=�6h   $	��291��6�   $��/ATMEGA16A.png��6�   5&      5'      