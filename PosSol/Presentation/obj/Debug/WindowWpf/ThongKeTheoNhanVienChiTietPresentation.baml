   M S B A M L   `   `   `  ����  PresentationC    =Presentation.WindowWpf.ThongKeTheoNhanVienChiTietPresentation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$'  !Chi tiết nhân viên bán hàng��5   	   $	��600��6-   $	��800��6:    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.    � Icon$6 0/Presentation;component/Image/Icon/fl-detail.png��6D    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5	      $ ../Style/UserControl.xaml?�6%   �� 5
      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   �� 5      $ ../Style/Label.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      � 	 � Color$	 	#FFF3F3F3��6   
 � Offset$
 0Q�61   � 5      $	 	#FFA0B9FB��6   $
 1Q�61   5       � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5    
   ��  �� Orientation$ 
Horizontal=�6   $��10 0 0 0q�6.   .+�5!      �� $
��Từ��6      lbControlLeft#���   6!   $��20(�6I   $��30��6W   $��	10 0 10 0q�6b   (  "System.Windows.Controls.DatePicker  5"      -   5        $��
dateTuNgay��5"      $��Center=�6+   $��15(�6F   
��� � �$	��150��6g      DisplayDateEnd$ 1/1/2099X�6s      DisplayDateStart$ 1/1/2010X�6�   �� 5#      $��đến��6   #���   6"   $��20(�6J   $��35��6X   $��	10 0 10 0q�6c     5$      -   5        $��dateDenNgay��5$      $��Center=�6,   $��15(�6G   
��� � �$	��150��6h   $ 1/1/2099X�6t   $ 1/1/2010X�6�   �� 5%      -   5        $��btnXem��5%        MetroButtonTomato#���  68   $��5 0 0 0q�6d   $��35��6u   $��1q�6�   .��5&      �� $ 
Horizontal=�6   .+�5'      �� $	��Xem��6   
�������$��Center=�6=   $
��Bold"�6X   5(      5)      5*      �� 5,   
   -   5        $��lbStatus��5,      $��1��6   $��Danh sách sản phẩm��6-   
�������$��Italic$�6]   $��15(�6p   &   System.Windows.Controls.DataGrid  5.   
   -   5        $��
dgDsHoaDon��5.   U   $��1��6   $��0 30 0 0q�6C     Datagrid#���  6g      
IsReadOnly .    Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6%      Header$ Số hóa đơn��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *HoaDon.SoHD_HD+   ElementStyle 52      �� 53       �� 
TargetType" ��6    .�54      ��  �� Property � �� �� Value$ Center=�6D   �� 55       � ��$ Center=�6B   56      58        5;      $ 1* 6%   $ Ngày lập��60    6B   �� *HoaDon.NgayLap_HD+ �� StringFormat$ dd-MM-yyyy HH:mm�� 5<      �� 5=      " ��6    .�5>      ��  � ��$ Center=�6D   �� 5?       � ��$ Center=�6B   5@      5B        5E      $	 150 6%   $ 
Tổng thu��61    6C   �� *	TongThu+ 5F      �� 5G      " ��6    .�5H      ��  � ��$ Center=�6D   �� 5I       � ��$ Center=�6B   5J      5L        5O      $	 150 6%   $ Tổng lãi��61    6C   �� *TongLoiNhuan+ 5P      �� 5Q      " ��6    .�5R      ��  � ��$ Center=�6D   �� 5S       � ��$ Center=�6B   5T      5V      4  .System.Windows.Controls.DataGridTemplateColumn  5Y      $ 70 6)   $ 
Chi tiết��64      CellTemplate 5Z      �� 5[      .R�5\      �� $��btnXemChiTiet��6%   -   5        #���  5\   V   $��30��6�   $��2q�6�   .��5]   "   �� .+�5^   &   �� $!��../Image/Icon/fl-detail.png��6,   $��20��6Q   $��Uniform=�6]   5_   #   5`      5a      5c      5f      �� 5h   
   -   5        $��btnReset��5h        MetroButtonTeal#���  68   $��5 0 0 0q�6b   $��Right=�6s   $��Center=�6�   $��30��6�   $��1q�6�   .��5i      �� $ 
Horizontal=�6   .+�5j      �� $ ��../Image/Icon/fl-reset.png��6   $��5q�6<   5k      5l      �� 5n   
   $ 
Horizontal=�6   $��2��6.   $��10q�6;   $
��Left=�6G   .+�5o      �� $��Tổng thu:��6   #���   6(   $��70��6P   �� 5p      -	   5        $��	lbTongThu��5p      
��� � �$��15(�68   $��0��6F   �� 5q      $��.VNĐ��6   $��15(�6$   $��0 0 30 0q�62   �� 5r      $��Tổng lãi:��6   #���   6(   $	��100��6P   �� 5s      -
   5        $��	lbTongLai��5s      
��� � �$��15(�68   $��0��6F   �� 5t      $��.VNĐ��6   $��15(�6$   $��0 0 30 0q�62   5u      �� 5w   
   -   5        $��
bdProgress��5w      $��1��6   $y�	Collapsed=�60   $��Center=�6G   $��Center=�6d   ���	#FF5788F1$��2q�6�    �� CornerRadius$ 0��6�   ���	#E6FBFAFA._�5x      �� -   5         ��Name$ 
spProgress��5x      $��Center=�6-   $��Center=�6J   $��5q�6e   .+�5y      �� -   5         ��Name$ 
lbProgress��5y      $��Đang xử lý...��6,   $
��Bold"�6E   ���	#FF5788F16W   � 5z      -   5         �Name$ pbTienTrinh��5z      $	��200��63    � IsIndeterminate . $��20��6V   ���	#FF5788F16b   5{      5|      5~      5      