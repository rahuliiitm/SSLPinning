   M S B A M L   `   `   `  ����K  GSSLPinningClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SSLPinningClientSSLPinningClient  5   	   !    SSLPinningClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   0localclr-namespace:SSLPinningClient     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��600��6)    � 	Resources 5      $   SSLPinningClient.MainViewModel 	  Model��%   &	          5   
   6.   5	      .��5
      �  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      6   �� 5      $��50 �6   6*   .+�5   
   �� ��6   ��  �� Source# [   �� Path$ ErrorMessage�6W   &   System.Windows.Controls.DataGrid  5   
   -   5        $��PostGrid��5       $��1��6      AutoGenerateColumns$ False��6x   $	��510��6�   ��60   �� # [  $ PostDetails�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 61   	   
IsReadOnly$
	 True��6\   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6<   �� $ PostId�6p     5      $ 	LikeCount��6%   $	 100 68   
 6D   �� $ 	LikeCount�6i     5      $
 Text��6%   $	 250 63   
 6?   �� $ Description�6f   5      �� 5    
   $��2��6   $
��Save��6   $	��200��6q   $��30��6}   ��6-   �� # [  $ SaveCommand�6�   5!      5"      