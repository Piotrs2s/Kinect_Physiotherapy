   M S B A M L   `   `   `  ����N  JKinectPhysiotherapy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:KinectPhysiotherapyKinectPhysiotherapy  5      .    (KinectPhysiotherapy.PhysiotherapistPage1   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:KinectPhysiotherapy     5        N� Title$  PhysiotherapistPage1��5	      $	��720��6%   $	��960��62    N� 
Background
 �����.��5      � $��	10 0 10 0q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ camera��5       J� RenderTransformOrigin$ 0.5,0.5&�6    $��221,96,204,178q�6B   $	��512��6Z   $	��424��6f   �� 5   
   -   5        $��	imgCanvas��5      $	��512��6"   $	��424��6.   $��221,96,204,178q�6;   �� 5   
   -   5        $��baloonCanvas��5      $	��512��6%   $	��424��61   $��221,96,204,178q�6>   $ 0.5,0.5&�6W   �� 5   
   -   5        $��
bodyCanvas��5      $	��512��6#   $	��424��6/   $��221,96,204,178q�6<   �� 5   
   -   5         ��Name$ Start��5      $��Start��6    $��672,642,46,106.6q�61   $ 0.5,0.5&�6b   �� 5   
   -   5         ��Name$ textBox_baloonsHitted��5      $
��Left=�61   $��23��6L   $��
32,253,0,0q�6X    �� TextWrapping$
 Wrap=�6l   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ textBoxBaloonPosition��5      $
��Left=�61   $��36��6L   $��
358,61,0,0q�6X   $
 Wrap=�6l   $	��Top=�6�   $	��238��6�   �� 5   
   $
��Left=�6   $��
601,12,0,0q�6/   $
��Wrap=�6C   $
��Hand��6W   $	��Top=�6c   �� 5   
   -   5        $ textBoxHandPosition��5      $
��Left=�6/   $��36��6J   $��
358,11,0,0q�6V   $
 Wrap=�6j   $	��Top=�6~   $	��238��6�   �� 5    
   $
��Left=�6   $��
601,61,0,0q�6/   $
��Wrap=�6C   $��Last Baloon��6W   $	��Top=�6j   �� 5!   
   -	   5        $ textBox_baloonsFloated��5!      $
��Left=�62   $��23��6M   $��
32,304,0,0q�6Y   $
 Wrap=�6m   $	��Top=�6�   $	��120��6�   �� 5"   
   -
   5        $ textBox_percent��5"      $
��Left=�6+   $��23��6F   $��
32,354,0,0q�6R   $
 Wrap=�6f   $	��Top=�6z   $	��120��6�   5(      5)      