   M S B A M L   `   `   `  ����  Poberezhets01(    "Poberezhets01.Views.OutputInfoView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � ��5	   
   �� 5
        �� ImageSource$  /Images/bg2.jpg��6   69    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��70 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��First name:��6-   $��Center=�6C   $��Center=�6a   
�������6|   �� 5   
   $��0��6   $��1��6!   $��Center=�61   $��Center=�6P   
���������6k   �� *MyModel.Name+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��1��6   $��0��6   $��
Last name:��6-   $��Center=�6B   $��Center=�6`   
�������6{   �� 5   
   $��1��6   $��1��6!   $��Center=�61   $��Center=�6P   
���������6k   �� *MyModel.Surname+$ TwoWay=�$ PropertyChanged=�6�   �� 5    
   $��2��6   $��0��6   $��Email:��6-   $��Center=�6>   $��Center=�6\   
�������6w   �� 5!   
   $��2��6   $��1��6!   $��Center=�61   $��Center=�6P   
���������6k   �� *MyModel.Email+$ TwoWay=�$ PropertyChanged=�6�   �� 5"   
   $��3��6   $��0��6   $��Date of Birth:��6-   $��Center=�6F   $��Center=�6d   
�������6   �� 5#   
   $��3��6   $��1��6!   $��Center=�61   $��Center=�6P   
���������6k   �� *MyModel.BirthdayShort+$ PropertyChanged=�6�   �� 5$   
   $��4��6   $��0��6   $��Is adult? :��6-   $��Center=�6C   $��Center=�6a   
�������6|   �� 5%   
   $��4��6   $��1��6!   $��Center=�61   $��Center=�6P   
���������6k   �� *MyModel.IsAdult+$ OneWay=�$ PropertyChanged=�6�   �� 5&   
   $��5��6   $��0��6   $��	Sun Sign:��6-   $��Center=�6A   $��Center=�6_   
�������6z   �� 5'   
   $��5��6   $��1��6!   $��Center=�61   $��Center=�6P   
���������6k   �� *MyModel.SunSign+$ OneWay=�$ PropertyChanged=�6�   �� 5(   
   $��6��6   $��0��6   $��Chinese Sign:��6-   $��Center=�6E   $��Center=�6c   
�������6~   �� 5)   
   $��6��6   $��1��6!   $��Center=�61   $��Center=�6P   ���	#FFFCDDDD��6k   �� *MyModel.ChineseSign+$ OneWay=�$ PropertyChanged=�6�   �� 5*   
   $��7��6   $��0��6   $��Has birthday? :��6-   $��Center=�6G   $��Center=�6e   
�������6�   �� 5+   
   $��7��6   $��1��6!   $��Center=�61   $��Center=�6P   
���������6k   �� *MyModel.IsBirthday+$ OneWay=�$ PropertyChanged=�6�   �� 5,   
   $��8��6   $��0��6   $��10q�6.   $
��Back��6:   ��6I   �� *BackCommand+�� 5-   
   $��8��6   $��1��6   $��10q�6.   $��Close��6:   ��6J   �� *CloseCommand+5/      50      