   M S B A M L   `   `   `  ????J  FLinearExpoGraph, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:FunctionGraphFunctionGraph  5   	       FunctionGraph.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:FunctionGraph     5   	     ? Title$  Function Graph??5   	   $	??450??6    $	??800??6-   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      $
??Auto ?6   ?? 5      $??* ?6   .+?5   
   ??  ?? Orientation$ 
Horizontal=?6   $??10q?6.    ? 	Resources 5       ?? 
TargetType ?? Property ?? Value??%Q   '??       ?? 5      " ??6   .?5      ??  ? ??$ 5q?6/   5      5      .+?5      ?? $	??x1:??6   ?? 5      -   5         ??Name$ 	X1TextBox??5      $??50??6)   ?? 5      $	??y1:??6   ?? 5      -   5        $ 	Y1TextBox??5      $??50??6)   ?? 5      $	??x2:??6   ?? 5      -   5        $ 	X2TextBox??5      $??50??6)   ?? 5      $	??y2:??6   ?? 5      -   5        $ 	Y2TextBox??5      $??50??6)   ?? 5      -   5         ??Name$ 
DrawButton??5      $
??Draw??6)   68   5      ?? 5    
   $??1??6   $??10q?6    5!      ??%w   '??       ?? 5"      " ??6   .?5#      ??  ? ??
 ?   ?6/   ?? 5$       ? ??$ 2??68   5%      5&      .+?5'      ?? -   5        	 ??Name$	 XAxis??5'      	
 ?? X1$
 0??6"   	 ?? Y1$	 200??6)   	 ?? X2$	 600??62   	 ?? Y2$	 200??6;   ?? 5(      -   5        $	 YAxis??5(      $	
 300??6"   $ 0??6+   $	 300??62   $	 400??6;   ? 5)      -   5         ?Name$ LinearFunction??5)      
???  ??6/   ? 5*      -	   5        $ ExponentialFunction??5*      
????  ?64   5+      5,      5-      