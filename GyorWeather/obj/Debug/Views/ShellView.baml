   M S B A M L   `   `   `  ����F  BGyorWeather, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:GyorWeather.ViewsGyorWeather.Views  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   !    GyorWeather.Views.ShellView   5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5
   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:GyorWeather.Views     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5	   	    � WindowStartupLocation$ CenterScreen=�5       � Title$ Győr Weather��5   	   $	��370��6   $	��310��6+   .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $
��auto �6   �� 5"      $
��auto �6   �� 5#      $
��auto �6   �� 5$      $��* �6   �� 5%      $��20 �6   .+�5)   
   #  MaterialDesignThemes.Wpf.Card  $��1��6   $��1��6+   $��2��6;   $��0,0,0,5q�6O   $	��260��6`   $��33��6l   .��5*      ��  �� Orientation$ 
Horizontal=�6   .+�5+      �� -   5         ��Name$ Weather_City��5+      $	��125��62   $��Center=�6>   $��5,0,0,0q�6Y   �� 5,      -   5        $ Weather_Time��5,      $	��125��62   $��Center=�6>    �� TextAlignment$ Right=�6Y   5-      5.        51   
   $��2��6   $��1��6+   $��4��6;   $	��150��6L   $	��150��6X   $��0,0,0,5q�6e   .��52      �� $��Center=�6   $��Center=�66   .+�53      �� -   5        $ Weather_Temperature��53      $��48(�69   $ Center=�6G   54      55        57   
   $��2��6   $��2��6+   $��5,0,0,5q�6;   $	��105��6L   $��33��6X   .��58      �� $��Páratartalom:��6   $��Center=�6-   $ Center=�6H   59        5<   
   $��3��6   $��2��6+   $��5,0,0,5q�6;   $	��105��6M   $��33��6Z   .��5=      �� -   5        $ Weather_Humidity��5=      $��Center=�62   $ Center=�6M   5>        5A   
   $��4��6   $��2��6+   $��5,0,0,5q�6;   $	��105��6L   $��33��6X   .��5B      �� $��
Hőérzet:��6   $��Center=�6(   $ Center=�6C   5C        5F   
   $��5��6   $��2��6+   $��5,0,0,5q�6;   $	��105��6L   $��33��6X   .��5G      �� -   5        $ Weather_FeelsLike��5G      $��Center=�63   $ Center=�6N   5H        5K   
   $��6��6   $��1��6+   $��2��6;   $��0,0,0,5q�6O   $	��260��6`   $��33��6l   .��5L      �� $ 
Horizontal=�6   .+�5M      '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 WeatherSunsetUp=�6*   $��Center=�6A   $��5,0,0,0q�6\   $��20��6m   $��20��6x   �� 5N      -   5        $ Weather_Sunrise��5N      $	��100��65   $��Center=�6A   $ Center=�6\     5O      $	 WeatherSunsetDown=�6*   $��Center=�6C   $��20��6^   $��20��6i   �� 5P      -   5        $ Weather_Sunset��5P      $	��105��64   $��Center=�6@   $ Center=�6[   5Q      5R        5U   
   $��7��6   $��1��6+   $��2��6;   $��0,0,0,5q�6O   $��33��6`   .��5V      �� $ 
Horizontal=�6   .+�5W        $	 WeatherWindy=�6*   $��Center=�6?   $��5,0,0,0q�6Z   $��20��6k   $��20��6v   �� 5X      -   5        $ Weather_WindSpeed��5X      $	��100��67   $��Center=�6C   $ Center=�6^     5Y      $	 Compass=�6*   $��Center=�69   $��20��6T   $��20��6_   �� 5Z      -	   5        $ Weather_WindDirection��5Z      $	��105��6;   $��Center=�6G   $ Center=�6b   5[      5\      �� 5_   
   -
   5        
 ��Name$
 Update��5_   V   $��8��6   $��1��6   $��2��6.   $��
Frissités��6B   6V   5`      5a      