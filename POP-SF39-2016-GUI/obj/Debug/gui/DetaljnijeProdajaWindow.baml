   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   L HPOP-SF39-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF39_2016_GUI.guiPOP_SF39_2016_GUI.gui 5   	   3   -POP_SF39_2016_GUI.gui.DetaljnijeProdajaWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   5local#clr-namespace:POP_SF39_2016_GUI.gui     5   	     � Title$  
Prodaja - ��5	   	   $	��400��6   $	��700��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K   .��5
      � .+�5   
   �� ���#68c0e8$��1q�6'   ._�5      �  � ColumnDefinitions 5      �� 5      $��1* �6'   �� 5      $��1* �6'   �� 5      $��1* �6'   �� 5      $��1* �6'    � RowDefinitions 5      �� 5      $
��1.1* �6$   �� 5      $
��1.1* �6$   �� 5      $��5* �6$   .+�5      �� $��Kupac��6   $��0��6(   $��0��68   $
��Left=�6E   $��Center=�6g   $��10,0,0,0q�6�   �� 5      -   5        $��tbKupac��5      $��1��6G   $��0��6W   $
��Left=�6d   $��Center=�6   ��6+   ��  �� Path$ Kupac�6   �� 5      $��Datum kupovine:��6   $��2��62   $��0��6B   $
��Left=�6O   $��Center=�6q   $��10,0,0,0q�6�   �� 5      -   5        $��tbDatum��5      $��3��6N   $��0��6^   $
��Left=�6k   $��Center=�6�   ��6+   �� $ DatumProdaje�6�   �� 5      $��Broj racuna��6   $��0��6.   $��1��6>   $
��Left=�6K   $��Center=�6m   $��10,0,0,0q�6�   �� 5      -   5        $��tbBrojRacuna��5      $��1��6O   $��1��6_   $
��Left=�6l   $��Center=�6�   ��60   �� $ BrRacuna�6�   �� 5      $��Ukupna cena��6   $��2��6.   $��1��6>   $
��Left=�6K   $��Center=�6m   $��10,0,0,0q�6�   �� 5      -   5        $��tbUkupnaCena��5      $��3��6Q   $��1��6a   $
��Left=�6n   $��Center=�6�   ��60   �� $ 
UkupnaCena�6�   &   System.Windows.Controls.DataGrid  5       -   5        $��dgRacun��5       $��4��6*   $��2��6>   $��Stretch=�6K   $��Stretch=�6g      AutoGenerateColumns .     SelectionMode$ Single=�6�      Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Naziv��6-   
   MinWidth$	
 130Q�6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Naziv+6V     5#      $	 
Cena Komad��6-   $
 80Q�6Z    6A   �� *Cena+6Z     5$      $	 Cena Komad + PDV��6-   $	
 120Q�6f    6G   �� *	CenaSaPdv+6f     5%      $	 Kolicina��6-   $
 50Q�6\    �� TextAlignment$ Center=�6j    6?   �� *
Kolicina+6j     5&      $	 Cena Ukupno��6-   $
 85Q�6a    6B   �� *
CenaUkupno+6a     5'      $	 Cena Ukupno + PDV��6-   $	
 125Q�6j    6H   �� *CenaUkupnoPDV+6j   5)      5*      5+      5,      5-      