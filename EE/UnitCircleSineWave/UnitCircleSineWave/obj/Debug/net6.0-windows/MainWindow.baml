   M S B A M L   `   `   `  ����M  IUnitCircleSineWave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:UnitCircleSineWaveUnitCircleSineWave  5   	   #    UnitCircleSineWave.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:UnitCircleSineWave     5   	     � Title$  Unit Circle Sine Wave��5   	   $	��450��6'   $	��800��64   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��unitCircleCanvas��5      
�������.+�5      A� $	��100��6   $	��100��6"   
���   �$��1��6>    �� Left$	 350��6R   
 �� Top$	 200��6d   �� 5      -   5        $��pointerLine��5      	 �� X1$	 400��6&   	 �� Y1$	 250��6/   	 �� X2$	 400��68   	 �� Y2$	 200��6A   
���   �$��2��6Y    J� RenderTransformOrigin$ 0.5,0&�6m   5      �� 5   
   -   5        $��graphCanvas��5      $��1��6$   
�������.+�5      � -   5        $��sineWavePolyline��5      
���  ��$��2��6<   5      5      5      