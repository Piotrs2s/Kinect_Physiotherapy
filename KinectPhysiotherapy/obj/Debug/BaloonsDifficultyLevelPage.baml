   M S B A M L   `   `   `  ����N  JKinectPhysiotherapy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:KinectPhysiotherapyKinectPhysiotherapy  5      4    .KinectPhysiotherapy.BaloonsDifficultyLevelPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:KinectPhysiotherapy     5        N� Title$   BaloonsDifficultyLevelPage��5	      $	��720��6*   $	��960��6:   $��Stretch=�6I   $��Stretch=�6e    N� 
Background
 �����.��5      � $��	10 0 10 0q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Center=�6   $��Center=�61   $��1��6N   $
��Wrap=�6[   $��Choose  difficulty level��6o   $��23��6�   $	��123��6�   �� 5   
   -   5         ��Name$ baloons_veryEasyButton��5      $��	Very easy��61   $��Center=�6E   $��Center=�6b   $��
0,50,300,0q�6}   $��1��6�   $��75��6�   6�   �� 5   
   -   5        $ baloons_easyButton��5      $
��Easy��6-   $��Center=�6<   $��Center=�6Y   $��
0,50,100,0q�6t   $��1��6�   $��75��6�   6�   �� 5   
   -   5        $ baloons_mediumButton��5      $��Medium��6/   $��Center=�6@   $��Center=�6]   $��
100,50,0,0q�6x   $��1��6�   $��75��6�   6�   �� 5   
   -   5        $ baloons_hardButton��5      $
��Hard��6-   $��Center=�6<   $��Center=�6Y   $��
300,50,0,0q�6t   $��1��6�   $��75��6�   6�    � 5   
   -   5        $
��Main��5      $��2��6     � NavigationUIVisibility$ Hidden=�6.   $��Stretch=�6N   $��Stretch=�6l   $��Stretch=�6�   $��Stretch=�6�   5      5      