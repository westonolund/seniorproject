   M S B A M L   `   `   `  ����L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PresentationLayerPresentationLayer  5   	   )    #PresentationLayer.TeamBattingWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PresentationLayer     5   	     � Title$  TeamBattingWindow��5   	   $	��450��6#   $
��1150��60   .��5	      � .+�5
      &   System.Windows.Controls.DataGrid  -   5        $��TeamDataGrid��5
         
IsReadOnly$
 True��6!      SelectionMode$ Single=�63      AutoGenerateColumns$ False��6J      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Rank��6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6'   �� *Rank+6B     5      $ 	FirstName��6    6,   �� *	FirstName+6L     5      $ LastName��6    6+   �� *
LastName+6J     5      $ Homeruns��6    6+   �� *
Homeruns+6J     5      $
 Year��6    6'   �� *Year+6B     5      $	 Age��6    6&   �� *Age+6@     5      $
 Team��6    6'   �� *
TeamAbrv+6F     5      $ League��6    6)   �� *League+6F     5      $ GamesPlayed��6    6.   �� *GamesPlayed+6P     5      $ PlateAppearances��6    63   �� *PlateAppearances+6Z     5      $ AtBats��6    6)   �� *AtBats+6F     5      $
 Runs��6    6'   �� *Runs+6B     5      $
 Hits��6    6'   �� *Hits+6B     5      $	 RBI��6    6&   �� *RBI+6@     5      $ Walks��6    6(   �� *Walks+6D     5      $ 
StrikeOuts��6    6-   �� *
StrikeOuts+6N     5      $ StolenBases��6    6.   �� *StolenBases+6P     5      $ 
BattingAvg��6    6-   �� *
BattingAvg+6N     5      $ OnBasePercentage��6    63   �� *OnBasePercentage+6Z     5      $ Position��6    6+   �� *
Position+6J   5"      5#      5$      