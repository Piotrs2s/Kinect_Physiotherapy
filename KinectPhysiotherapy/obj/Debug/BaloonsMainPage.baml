   M S B A M L   `   `   `  ����N  JKinectPhysiotherapy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:KinectPhysiotherapyKinectPhysiotherapy  5      )    #KinectPhysiotherapy.BaloonsMainPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:KinectPhysiotherapy     5        N� Title$  BaloonsMainPage��5	      $	��720��6    $	��960��60   $��Stretch=�6?   $��Stretch=�6[    N� 
Background
 �����.��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ camera��5       J� RenderTransformOrigin$ 0.5,0.5&�6    $	��720��6A   $	��960��6N   $��Center=�6Z   $��Center=�6w   �� 5   
   -   5        $��baloonCanvas��5      $	��720��6%   $	��960��62   $��Center=�6?   $��Center=�6\   �� 5   
   -   5        $��
bodyCanvas��5      $	��720��6#   $	��960��60   $��Center=�6<   $��Center=�6Y   �� 5   
   -   5         ��Name$ Start��5      $��Start��6    $��	0,0,10,10q�60   $��Bottom=�6\   $��Right=�6w   $	��150��6�   $��30��6�   �� 5   
   -   5         ��Name$ textBoxBaloonPosition��5      $
��Left=�61   $��16��6L   $��
448,12,0,0q�6X    �� TextWrapping$
 Wrap=�6l   $	��Top=�6�   $	��238��6�   �� 5   
   $
��Left=�6   $��	60,12,0,0q�6/   $
��Wrap=�6B   $
��Hand��6V   $	��Top=�6b   �� 5   
   -   5        $ textBoxHandPosition��5      $
��Left=�6/   $��16��6J   $��	94,12,0,0q�6V   $
 Wrap=�6i   $	��Top=�6}   $	��238��6�   �� 5   
   $
��Left=�6   $��
382,10,0,0q�6/   $
��Wrap=�6C   $��Last Baloon��6W   $	��Top=�6j   �� 5   
   -   5        $ textBox_baloonsHitted��5      $
��Left=�61   $	��Top=�6L   $��25��6d   $	��120��6q   $��
100,50,0,0q�6}   $
 Wrap=�6�   �� 5    
   -   5        $ textBox_baloonsFloated��5       $
��Left=�62   $	��Top=�6M   $��25��6e   $	��120��6r   $��
250,50,0,0q�6~   $
 Wrap=�6�   �� 5!   
   -	   5        $ textBox_percent��5!      $
��Left=�6+   $	��Top=�6F   $��25��6^   $	��120��6k   $��
400,50,0,0q�6w   $
 Wrap=�6�   5'      5(      