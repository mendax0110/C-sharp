   M S B A M L   `   `   `  ����  DiodeCharacteristic$    DiodeCharacteristic.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Diode Characteristic��5   	   $	��459��6&   $	��904��63   .��5      �  � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Current (mA):��6-   �� 5   
   -   5         ��Name$ CurrentInput��5      $��0��6(   $��117,0,694,20q�65   $��2��6K   $��2��6\   �� 5   
   -   5        $��1��5      $��1��6   $��	Calculate��6.   6B   �� 5   
   $��2��6   $��0��6   $��Forward Voltage (V):��6-   �� 5   
   -   5        $ ForwardVoltageOutput��5      $��2��60   $��	117,0,0,0q�6=    �� 
IsReadOnly . $��2��6b   �� 5   
   -   5         ��Name$ GraphCanvas��5      
�������$��1��6=   $��10,41,10,10q�6M   $��2��6b   5      5      