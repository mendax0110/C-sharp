   M S B A M L   `   `   `  ����  SignalGenerator     SignalGenerator.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Signal Generator��5   	   $	��450��6"   $	��800��6/   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��10q�6.   .+�5      �� $��Signal type:��6   $��Center=�6+   $��0 0 5 0q�6F   �� 5      -   5         ��Name$ signalSelector��5      $	��120��6/    �� SelectedIndex$ 0��6;   .@�5      �� .��6   
Sawtooth6)   �� 5      .��6   	Rectangle6*   �� 5      .��6   Sine6%   5      �� 5      $��Frequency (Hz):��6   $��Center=�6.   $��20 0 5 0q�6I   �� 5      -   5         ��Name$ frequencyInput��5      $��60��6.   $��10��69   �� 5      $��
Amplitude:��6   $��Center=�6)   $��20 0 5 0q�6D   �� 5      -   5        $ amplitudeInput��5      $��60��6.   $��1��69   �� 5      -   5         ��Name$ 
DrawSignal��5      $��Draw signal��6)   $��20 0 0 0q�6?   5      �� 5   
   -   5         ��Name$ canvas��5      $��1��6!   
�������$��10q�6A   .+�5      �� 	 �� X1$ 0��6   
���   �$��2��6  		 �� Y1	 6   �� *ActualHeight+
 �� RelativeSource
 ��  �� AncestorType$ CanvasL�	 �� X2 6k   �� *ActualWidth+
 �� $ CanvasL�	 �� Y2 6�   �� *ActualHeight+
 �� $ CanvasL�6  �� 5      $	 0��6c   
���   �$��2��6   6   �� *ActualWidth+
 �� $ CanvasL� 6j   �� *ActualWidth+
 �� $ CanvasL� 6�   �� *ActualHeight+
 �� $ CanvasL�6  5      5      5       