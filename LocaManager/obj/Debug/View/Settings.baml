   M S B A M L   `   `   `  ����F  BLocaManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:LocaManager.ViewLocaManager.View  5   	   =#clr-namespace:LocaManager.ViewModelLocaManager.ViewModel  5   	       LocaManager.View.Settings   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:LocaManager.View     5   	   9	viewModel#clr-namespace:LocaManager.ViewModel     5   	     � Title$  Settings��5	   	   $	��515��6   $	��810��6'    � 
ResizeMode$ NoResize=�63    � Topmost .  � ShowInTaskbar .   � DataContext 5      &    LocaManager.ViewModel.SettingsVM  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��60 �6   .+�5   
   � $��0��6   $��20q�6   $	��755��6(    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $��	Addresses��6   $��0��6*   .��5      ��  �� Orientation$ Vertical=�6   .+�5      �� $��Project Location��6   $��50��69   .��5      �� $ 
Horizontal=�6%   .+�5      �� -   5        $��pathTb��5   &   $��23��64    �� TextWrapping$ NoWrap=�6C   $��Center=�6�   $	��277��6�   $��0,2.02q�6�   ��6Y   �� *
ProjectLoc+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�6�   �� 5      $��Select��6%   $��77��66   ��6A   �� *SetProjectLocationCommand+5      5       �� 5!      $��Loca Offset��6   $��50��64   .��5"      �� $��23��6"   $��Center=�6�   ��61   �� *LocalSettingsModel.LocaOffset+$	 TwoWay=�$
 PropertyChanged=�6�   5#      �� 5$      $��Prod Address��6   $��50��65   .��5%      �� $��23��6"   $��Center=�6�   ��61   �� * LocalSettingsModel.ProdAddress+$	 TwoWay=�$
 PropertyChanged=�6�   5&      �� 5'      $��Dev Address��6   $��50��64   .��5(      �� $��23��6"   $��Center=�6�   ��61   �� *LocalSettingsModel.DevAddress+$	 TwoWay=�$
 PropertyChanged=�6�   5)      �� 5*      $��LevelData Command��6   $��50��6:   .��5+      �� $��23��6"   $��Center=�6�   ��61   �� *%#LocalSettingsModel.LevelDataCommand+$	 TwoWay=�$
 PropertyChanged=�6�   5,      5-      5.      �� 5/      $
��Loca��6   $��1��6%   .��50      �� $ Vertical=�6   .+�51      �� $��Dialog Start��6   $��50��65   .��52      �� $��23��6"   $��Center=�6�   ��61   �� * LocalSettingsModel.DialogStart+$	 TwoWay=�$
 PropertyChanged=�6�   53      �� 54      $��
Dialog End��6   $��50��63   .��55      �� $��23��6"   $��Center=�6�   ��61   �� *LocalSettingsModel.DialogEnd+$	 TwoWay=�$
 PropertyChanged=�6�   56      �� 57      $��
Loca Start��6   $��50��63   .��58      �� $��23��6"   $��Center=�6�   ��61   �� *LocalSettingsModel.LocaStart+$	 TwoWay=�$
 PropertyChanged=�6�   59      �� 5:      $��Loca End��6   $��50��61   .��5;      �� $��23��6"   $��Center=�6�   ��61   �� *LocalSettingsModel.LocaEnd+$	 TwoWay=�$
 PropertyChanged=�6�   5<      �� 5=      $
��Term��6   $��50��6-   .��5>      �� $��23��6"   $��Center=�6�   ��61   �� *LocalSettingsModel.Term+$	 TwoWay=�$
 PropertyChanged=�6�   5?      �� 5@      $��Description��6   $��50��64   .��5A      �� $��23��6"   $��Center=�6�   ��61   �� *LocalSettingsModel.Desc+$	 TwoWay=�$
 PropertyChanged=�6�   5B      �� 5C      $��Language��6   $��50��61   .��5D      �� $��23��6"   $��Center=�6�   ��61   �� *LocalSettingsModel.Lan+$	 TwoWay=�$
 PropertyChanged=�6�   5E      5F      5G      5H      � 5I   
   $��1��6    5J      �� 5K      $��* �6#   �� 5L      $��* �6#   .+�5N      �� $
��Save��6   $��0��6$   $��Center=�64   $��Center=�6Q   $	��200��6l   $��40��6x    �� 	IsDefault . ��6�   �� *SaveCommand+$	 OneWay=�{�6�   �� *Text+ �� ElementName$ pathTb��   HasTextConv �� 	Converter# [  �� 5O      $��Close��6   $��1��6%   $��Center=�65   $��Center=�6R   $	��200��6m   $��40��6y    �� IsCancel . {�6�   �� *Text+$ pathTb��# [  5P      5Q      5R      