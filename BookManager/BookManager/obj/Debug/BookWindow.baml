   M S B A M L   `   `   `  ����F  BBookManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:BookManager.ViewModelBookManager.ViewModel  5   	       BookManager.BookWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:BookManager.ViewModel     5   	     � Title$  
BookWindow��5   	   $	��350��6   $	��300��6)    � 	Resources 5	      2  ,BookManager.ViewModel.CreateNewBookViewModel   newBook��%   &	          5
   
   6'   5      .��5      A�  A� Columns$ 2��6    A� Rows$ 7��6   .+�5   
   �� 
�������$��Center=�6&   $��Center=�6J   .��6l   Title6s   �� 5   
    �� TextWrapping$
 Wrap=�5      ��6!   ��  �� Source# [   �� Path$ 	BookTitle��� 5   
   
�������$��Center=�6'   $��Center=�6K   .��6m   Author6u   �� 5   
   $
 Wrap=�5      ��6!   �� # [  $ 
BookAuthor��� 5   
   
�������$��Center=�6&   $��Center=�6J   .��6l   ISBN6r   �� 5   
   $
 Wrap=�5      ��6!   �� # [  $ BookISBN��� 5   
   
�������$��Center=�6'   $��Center=�6K   .��6m   	Publisher6x   �� 5   
   $
 Wrap=�5       ��6!   �� # [  $ BookPublisher��� 5"   
   
�������$��Center=�6&   $��Center=�6J   .��6l   Date6r   �� 5$   
   $
 Wrap=�5%      ��6!   �� # [  $ BookDate��� 5'   
   
�������$��Center=�6'   $��Center=�6K   .��6m   Price6t   �� 5)   
   $
 Wrap=�5*      ��6!   �� # [  $ 	BookPrice��� 5,   
   -   5        
��� d �$��	Save Book��5,   (   ��6<   �� *New+ �� Mode$ OneWay=�# [  6�   �� 5-   
   -   5        
���  ��$��Cancel��5-   &    �� IsCancel . 6G   50      51      