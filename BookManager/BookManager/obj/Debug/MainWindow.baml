   M S B A M L   `   `   `  ����F  BBookManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:BookManager.ViewModelBookManager.ViewModel  5   	       BookManager.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   5local#clr-namespace:BookManager.ViewModel     5   	     � Title$  Konstantins BookManager��5   	   $	��720��6)   $	��540��66    � 	Resources 5      3   -BookManager.ViewModel.BookCollectionViewModel   myCollection��%   &	          5      6&   5      .��5
      ]� .+�5   
   o� $	��Top=�6   .@�5      m� $
��File��6   .@�5      m� $	��New��6    m� Command 6(   �� *New+ �� Mode$ OneWay=� �� Source# [  �� 5      m� 5      $
��Save��6    6)   �� *Save+$ OneWay=�# [  m� 5      $
��Load��6    6)   �� *Load+$ OneWay=�# [  �� 5      m� 5      -   5        $
��Quit��5      6)   5      5      A� 5   
    A� Columns$ 1��6    A� Rows$ 2��6"   .+�5      �� -   5        $��Listing��5   S   
���������6   �� # [  ��5      �� 5      .R�5      �� .+�5      �� 
���   �$
��Bold"�6;   $��18(�6M   ��6[   ��  �� Path$ 	BookTitle��� 5      
���   �$��Italic$�6;   $��16(�6N   ��6\   �� $ 
BookAuthor��� 5      
���   �$��14(�6;   ��6I   �� $ BookDate��� 5      $��50��6%   $��12��60   $
��Left=�6<   .+�5   "   A� $��	YearColor��6*   $��10��6;   
���   �$��10��5   F    �� Left$ 5��6Q   ��6&   �� $ 	ColorYear�5    #   5!      �� 5"      	 �� Orientation$	 
Horizontal=�6)   .+�5#   "   �� ��6,   �� $
 Year�6I   5$      5%      5&      5(      A� 5)      $ 2��6   $ 1��6&   .+�5*      A� $ 2��6   $ 6��6*   .+�5+      �� 
�������$��Center=�62   $��Center=�6V   .��6x   Title:6�   �� 5-      ��5.      �� 
 �� ElementName$
 Listing��$ SelectedItem.BookTitle��� 50      
�������$��Center=�63   $��Center=�6W   .��6y   	Author:6�   �� 52      ��53      �� $
 Listing��$ SelectedItem.BookAuthor��� 55      
�������$��Center=�62   $��Center=�6V   .��6x   ISBN:6   �� 57      ��58      �� $
 Listing��$ SelectedItem.BookISBN��� 5:      
�������$��Center=�63   $��Center=�6W   .��6y   
Publisher:6�   �� 5<      ��5=      �� $
 Listing��$  SelectedItem.BookPublisher��� 5?      
�������$��Center=�62   $��Center=�6V   .��6x   Date:6   �� 5A      ��5B      �� $
 Listing��$ SelectedItem.BookDate��� 5D      
�������$��Center=�63   $��Center=�6W   .��6y   Price:6�   �� 5F      ��5G      �� $
 Listing��$ SelectedItem.BookPrice�5I      A� 5J      $ 1��6   $ 2��6*   .+�5K      A� $ 2��6"   $ 2��6.   .+�5L      �� $��New Book��6!   ��64   �� *New+$ OneWay=�# [  �� 5M      $��Delete Item��6!   ��67   �� *Delete+$ OneWay=�# [  ��6�   �� $
 Listing��$ SelectedItem��� 5N      $��	Save Book��6!   ��65   �� *Save+$ OneWay=�# [  �� 5O      $��	Load Book��6!   ��65   �� *Load+$ OneWay=�# [  5P      �� 5Q      -   5        $��Quit Application��5Q       �� IsCancel . 6H   5R      5S      5T      5U      5V      