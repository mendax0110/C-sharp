   M S B A M L   `   `   `  ????H  DKW48_Resistor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ResistanceCalculatorResistanceCalculator  5   	   %    ResistanceCalculator.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:ResistanceCalculator     5   	     ? Title$  Resistance Calculator??5   	   $	??207??6'   $	??432??64   .??5	      ? $??	0,0,0,-26q?6    ? RowDefinitions 5
   
   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $??* ?6    ? ColumnDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $??* ?6   .+?5   
   ?? $??0??6   $??0??6   $??5q?6-   .??68   
Voltage:6B   ?? 5   
   -   5         ??Name$ voltageTextBox??5      $??0??6*   $??1??67   $??5q?6G   ?? 5   
   $??1??6   $??0??6   $??5q?6-   .??68   
Current:6B   ?? 5   
   -   5        $ currentTextBox??5      $??1??6*   $??1??67   $??5q?6G   ?? 5   
   -   5         ??Name$ calculateButton??5      $??2??6*   $??1??67   $??5q?6G   .??6p   Calculate Resistance6?   ?? 5   
   -   5         ??Name$ resultLabel??5      $??3??6%   $??1??62   $??5q?6B   ?? 5   
   $??1??6   $
??Left=?6    $??43??6;   $??
106,10,0,0q?6G   $??4??6[   $	??Top=?6h   $	??133??6?   $"??/Resistor_symbol_IEC.svg.png??6?   5       5!      