   M S B A M L   `   `   `  ����L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PresentationLayerPresentationLayer  5   	   +    %PresentationLayer.PlayerWindowBatting   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PresentationLayer     5   	     � Title$  PlayerWindowBatting��5   	   $	��450��6%   $	��800��62   .��5	      � ���#ededed � ColumnDefinitions 5
      �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      $��50 �6   6#    � RowDefinitions 5      �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5      �� -   5        $��PlayerNameLbl��5   
   $
��Name��6   $��Arial Black)�6.   $
��Bold"�6G   $��14(�6Y   $��1,1,1,1q�6g   $	��Top=�6x   $��Center=�6�   $��0��6�   $��0��6�   �� 5      $��0��6
   $��0��6   $	��100��6'   $��2��64   $	��100��6E   $��
avatar.png��6Q   �� 5      $
��Hits��6
   $��Arial Black)�6   $
��Bold"�62   $��14(�6D   $��1,1,1,1q�6R   $	��Top=�6c   $��Center=�6{   $��2��6�   $��0��6�   �� 5      $��
Strikeouts��6
   $��Arial Black)�6   $
��Bold"�68   $��14(�6J   $��1,1,1,1q�6X   $	��Top=�6i   $��Center=�6�   $��1��6�   $��1��6�   �� 5      $��	Home Runs��6
   $��Arial Black)�6   $
��Bold"�67   $��14(�6I   $��1,1,1,1q�6W   $	��Top=�6h   $��Center=�6�   $��3��6�   $��1��6�   �� 5      $��RBI's��6
   $��Arial Black)�6   $
��Bold"�63   $��14(�6E   $��1,1,1,1q�6S   $	��Top=�6d   $��Center=�6|   $��2��6�   $��2��6�   �� 5       $��Batting Average��6
   $��Arial Black)�6$   $
��Bold"�6=   $��14(�6O   $��1,1,1,1q�6]   $	��Top=�6n   $��Center=�6�   $��1��6�   $��3��6�   �� 5!      $
��Team��6
   $��Arial Black)�6   $
��Bold"�62   $��14(�6D   $��1,1,1,1q�6R   $	��Top=�6c   $��Center=�6{   $��3��6�   $��3��6�   �� 5"      $��Position��6
   $��Arial Black)�6   $
��Bold"�66   $��14(�6H   $��1,1,1,1q�6V   $	��Top=�6g   $��Center=�6   $��2��6�   $��4��6�   �� 5$      -   5        $��
HitsBorder��5$       � ToolTip$l fBatter hits ball into fair territory, reaching base or bases without aid of fielder's choice or error.��6   
���   �$��5,5,5,5q�6�   ���#e1f0e8 �� Padding$ 5q�6�    �� CornerRadius$ 20��6�   $��70��6�   $��70��6�   $��2��6  $��0��6  $��1,1,1,1q�6#  $��Center=�64  $��Center=�6O  $��2��6l  ._�5%      �� -   5        $��HitsTextBox��5%   G   $��Center=�6   $��Center=�6*   $��	TextBlock��6Z   $��Arial)�6k   5&      �� 5(      -   5        $��StrikeoutsBorder��5(      $L FBatter misses three swinging or looking throws (strikes) from pitcher.��6#   
���   �$��5,5,5,5q�6�   ���#e1f0e8$ 5q�6�   $ 20��6�   $��70��6�   $��70��6�   $��1��6�   $��1��6�   $��1,1,1,1q�6	  $��Center=�6  $��Center=�65  $��2��6R  ._�5)      �� -   5        $��StrikeoutsTextBox��5)   G   $��Center=�6   $��Center=�6*   $��	TextBlock��6`   $��Arial)�6q   5*      �� 5,      -   5        $��HomerunsBorder��5,      $� �Home Runs-batter hits ball into fair play and scores without being put or benefit from error. Usually occurs when ball leaves outfield fence in fair territory, but in-park home runs also occur.��6!   
���   �$��5,5,5,5q�6  ���#e1f0e8$ 5q�60  $ 20��6<  $��70��6N  $��70��6Z  $��3��6e  $��1��6u  $��1,1,1,1q�6�  $��Center=�6�  $��Center=�6�  $��2��6�  ._�5-      �� -   5        $��HomeRunsTextBox��5-   G   $��Center=�6   $��Center=�6*   $��	TextBlock��6^   $��Arial)�6o   5.      �� 50      -   5        $��
RBIsBorder��50      $d ^Runs Batted In-occurs when batter hits ball into fair territory, causing teammate(s) to score.��6   
���   �$��5,5,5,5q�6�   ���#e1f0e8$ 5q�6�   $ 20��6�   $��70��6�   $��70��6�   $��2��6�   $��2��6  $��1,1,1,1q�6  $��Center=�6,  $��Center=�6G  $��2��6d  ._�51      �� -	   5        $��RBIsTextBox��51   G   $��Center=�6   $��Center=�6*   $��	TextBlock��6Z   $��Arial)�6k   52      �� 54      -
   5        $��BattingAverageBorder��54      $B <Calculated by dividing player's total hits by total at-bats.��6'   
���   �$��5,5,5,5q�6�   ���#e1f0e8$ 5q�6�   $ 20��6�   $��70��6�   $��70��6�   $��1��6�   $��3��6�   $��1,1,1,1q�6  $��Center=�6  $��Center=�6/  $��2��6L  ._�55      �� -   5        $��BattingAverageTextBox��55   G   $��Center=�6   $��Center=�6*   $��	TextBlock��6d   $��Arial)�6u   56      �� 58      -   5        $��
TeamBorder��58      
���   �$��5,5,5,5q�61   ���#e1f0e8$ 5q�6`   $ 20��6l   $��70��6~   $��70��6�   $��3��6�   $��3��6�   $��1,1,1,1q�6�   $��Center=�6�   $��Center=�6�   $��2��6�   ._�59      �� -   5        $��TeamTextBox��59   G   $��Center=�6   $��Center=�6*   $��	TextBlock��6Z   $��Arial)�6k   5:      �� 5<      -   5        $��PositionBorder��5<      
���   �$��5,5,5,5q�65   ���#e1f0e8$ 5q�6d   $ 20��6p   $��70��6�   $��70��6�   $��2��6�   $��4��6�   $��1,1,1,1q�6�   $��Center=�6�   $��Center=�6�   $��2��6�   ._�5=      �� -   5        $��PositionTextBox��5=   G   $��Center=�6   $��Center=�6*   $��	TextBlock��6^   $��Arial)�6o   5>      5A      5B      