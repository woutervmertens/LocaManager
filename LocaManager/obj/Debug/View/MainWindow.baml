   M S B A M L   `   `   `  ����F  BLocaManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:LocaManager.ViewLocaManager.View  5   	   =#clr-namespace:LocaManager.ViewModelLocaManager.ViewModel  5   	   )clr-namespace:LocaManagerLocaManager  5   	   !    LocaManager.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:LocaManager.View     5   	   9	viewModel#clr-namespace:LocaManager.ViewModel     5   	   -helpersclr-namespace:LocaManager     5   	     � Title$  Loca Manager��5
   	   $
��Auto��6   $	��800��6,   $	��800��68   $	��635��6G    � DataContext 5      "   LocaManager.ViewModel.MainVM  5   
   .��5      � .+�5   
   ]� .+�5      � $	��Top=�6   $��80��6+   $	��Top=�67    � ColumnDefinitions 5      �� 5      $	��560 �6'   �� 5      $��* �6'   .+�5      �� 
���   �$��1q�6-   $	��Top=�6A   $��80��6Y   $��2��6h   ._�5      ��  �� Orientation$ 
Horizontal=�6!   $��0��6:   .+�5      �� $��Search a term��6#   $��79��6:   $	��215��6F   .��5      �� $ 
Horizontal=�6)   .+�5   "   �� $ Vertical=�6-   .+�5   &   �� $��23��6.    �� TextWrapping$ NoWrap=�6:   $	��120��6l   $��10,5,0,5q�6x   ��6P   �� *
SearchText+6x   �� 5   &   $��Full Search��6/   $��	20,0,20,0q�6E    d� 	IsChecked 6X   �� *IsFullSearch+5   #   �� 5   "   $��Search��6)   $��60��6:   $��10,0,0,0q�6E   ��6W   �� *SearchCommand+ �� Mode$ OneWay=�5       5!      �� 5"      $��	Load data��6!   $��75��65   $��10,0,0,0q�6@   ��6R   �� *LoadDataCommand+$ OneWay=��� 5#      $��New loca��6!   $��75��64   $��10,0,0,0q�6?   ��6Q   �� *NewLocaCommand+$ OneWay=��� 5$      $��From LevelID��6!   $��75��68   $��10,0,0,0q�6C   ��6U   �� *FromLevelIdCommand+$ OneWay=��� 5%      $��Settings��6!   $��75��64   $��10,0,0,0q�6?   ��6Q   �� *SettingsCommand+$ OneWay=�5&      5'      �� 5(      $
��Data��6   $��79��6)   $	��200��65   $��	10,0,10,0q�6D   $��1��6W   .��5)      �� $ Vertical=�6!   .+�5*      �� $ 
Horizontal=�6%   .+�5+      �� $��Number of terms:��6$   $	��5,0q�6?   $��11(�6M   �� 5,      $	��5,0q�6r   $��11(�6�   ��6$   �� *NumberOfTerms+   IntToStringConv �� 	Converter# [  6�   5-      �� 5.      $ 
Horizontal=�6%   .+�5/      �� $��Number of viewable terms:��6$   $	��5,0q�6H   $��11(�6V   �� 50      $	��5,0q�6v   $��11(�6�   ��6$   �� *NumberOfViewTerms+# [  6�   51      �� 52      $ 
Horizontal=�6%   .+�53      �� $��Number of new terms:��6$   $	��5,0q�6C   $��11(�6Q   �� 54      $	��5,0q�6u   $��11(�6�   ��6$   �� *NumberOfNewTerms+# [  6�   55      �� 56      $ 
Horizontal=�6%   .+�57      �� $��Number of edited terms:��6$   $	��5,0q�6F   $��11(�6T   �� 58      $	��5,0q�6x   $��11(�6�   ��6$   �� *NumberOfEditedTerms+# [  6�   59      5:      5;      5<      � 5=       5>      �� 5?      $��* �6'   �� 5@      $��* �6'   .+�5B      �� $	��345��6   $	��340��6*   $��0��6�   ��6:   �� *Locas+ �� SelectedIndex 6X   �� *SelectedIndex+*   $LocaManager.ScrollToSelectedBehavior	   SelectedValue	 6�   �� *SelectedLoca+
 �� View
 5C      �� 5D      .P�5E      �� $��#��6-    �� Width$ 50��68    �� DisplayMemberBinding 6C   �� *Index+�� 5F      $	��Key��6-   $
 Auto��6:    6G   �� *Term+�� 5G      $��Description��6-   $	 100��6B    6N   �� *Description+5H      5J      �� 5K      
���   �$��1q�6-   $	��332��6A   $	��340��6P   $��1��6`   ._�5L      � .+�5M      �� $ Vertical=�6%   .+�5N      �� $	��Key��6'   $��50��64   .��5O   "   �� $��23��6*   $
 Wrap=�69   $��Center=�6p   ��6M   �� *SelectedLoca.Term+6p   5P      �� 5Q      $��Description��6'   $
��Auto��6<   .��5R   "   �� $��23��6*   $
 Wrap=�69   $��Center=�6w   ��6M   �� *SelectedLoca.Description+6w   5S      �� 5T      $��English��6'   $
��Auto��68   .��5U   "   �� $��23��6*   $
 Wrap=�69   $��Center=�6s   ��6M   �� *SelectedLoca.English+6s   5V      �� 5W      $��French��6'   $
��Auto��67   .��5X   "   �� $��23��6*   $
 Wrap=�69   $��Center=�6r   ��6M   �� *SelectedLoca.French+6r   5Y      �� 5Z      $��Chinese��6'   $
��Auto��68   .��5[   "   �� $��23��6*   $
 Wrap=�69   $��Center=�6s   ��6M   �� *SelectedLoca.Chinese+6s   5\      �� 5]      $��
Portuguese��6'   $
��Auto��6;   .��5^   "   �� $��23��6*   $
 Wrap=�69   $��Center=�6v   ��6M   �� *SelectedLoca.Portuguese+6v   5_      �� 5`      $��Russian��6'   $
��Auto��68   .��5a   "   �� $��23��6*   $
 Wrap=�69   $��Center=�6s   ��6M   �� *SelectedLoca.Russian+6s   5b      �� 5c      $��Spanish��6'   $
��Auto��68   .��5d   "   �� $��23��6*   $
 Wrap=�69   $��Center=�6s   ��6M   �� *SelectedLoca.Spanish+6s   5e      �� 5f      $��40��6%   $
��20,5q�61   $��	Save edit��6?   ��6T   �� *SaveEditCommand+$ OneWay=�5g      �� 5h      $��40��6!   $��20,20q�6-   $
��Save��6<   $��Bottom=�6y   ��6L   �� *SaveCommand+$ OneWay=�6y   5i      5j      5k      5l      5m      5n      