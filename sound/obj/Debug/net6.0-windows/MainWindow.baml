   M S B A M L   `   `   `  ����@  <sound, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:soundsound  5   	       sound.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:sound     5   	     � Title$  
MainWindow��5   	   $	��520��6   $	��800��6)   .��5	      � .+�5
   
   ��  �� Orientation$ 
Horizontal=�6   $��Bottom=�6/   $��Center=�6J   .+�5      �� -   5        $��Открыть��5      $��0,0,0,0q�6'   68   5      � 5   
   $��Center=�6   $��Center=�6+   $	��220��6H    � ColumnDefinitions 5      �� 5      �� 5      $
��Auto �6#   .+�5      �� -   5        $��
track_list��5      $��-270,6,-304,4q�6(   $��2��6k    J� RenderTransformOrigin$ 0.5,0.5&�6   z�5      V� 5      .~�5      �� �� 5       �� AngleY$ -0.828Q�6(   �� 5      T� 5       T� Y$ -1.186Q�6-   5      5      5      � 5   
   .+�5       �� $��Center=�6   $��	0,200,0,0q�64   .+�5!      �� -   5        $��track_mesto��5!       �� Orientation$ 
Horizontal=�6,   $��1��6E   $��	10,66,0,0q�6U   $ 	0.5,0.666&�6�   �� 5"      $��3��6   $ 
Horizontal=�6*   $��Center=�6C   .+�5#      �� -   5         ��Name$ current_time��5#       $��00:00��66   5$      �� 5%      $��4��6   $ 
Horizontal=�6*   $��Center=�6C   .+�5&      �� -   5        $ music_duration��5&       5'      5(      5)      � 5*   
   $��0,-3,0,3q�6   .+�5+      �� $ 
Horizontal=�6   $	��Top=�62   $
��Left=�6J   .+�5,      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5           Label$
 Back��5,      6-     5-      -   5        $
 Play��5-      6-     5.      -   5        $ Pause��5.      6.     5/      -	   5        	  Name$	 replay_button��5/      $  ��66   6@     50      -
   5        $
 Next��50      6-     51      -   5        $ Shuffle��51      60   52      �� 53      $��: ��6   $��419,384,375,104q�6"   54      55      56      