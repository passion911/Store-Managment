   M S B A M L   `   `   `  ����  Presentation:    4Presentation.UserControls.LichSuBanHangUPresentation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5           UserControl#���   5   H     � 	Resources  5       �� MergedDictionaries �� Source�� 5	   
    5
      �� 5      $ ../Style/UserControl.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   �� 5      $ ../Style/Label.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF3F3F3��6    � Offset$ 0Q�61   � 5      $ 	#FFA0B9FB��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5       $��50 �6   .+�5#   
   ��  �� Orientation$ 
Horizontal=�6   $��10 0 0 0q�6.   .+�5$      �� $
��Từ��6     lbControlLeft#���  6!   $��20(�6I   $��30��6W   $��	10 0 10 0q�6b   (  "System.Windows.Controls.DatePicker  5%      -   5        $��
dateTuNgay��5%      $��Center=�6+   $��15(�6F   
��� � �$	��150��6g   	   DisplayDateEnd$	 1/1/2099X�6s   
   DisplayDateStart$
 1/1/2010X�6�   �� 5&      $��đến��6   #���  6"   $��20(�6J   $��35��6X   $��	10 0 10 0q�6c     5'      -   5        $��dateDenNgay��5'      $��Center=�6,   $��15(�6G   
��� � �$	��150��6h   $	 1/1/2099X�6t   $
 1/1/2010X�6�   �� 5(      -   5        $��btnXem��5(        MetroButtonTomato#���  69   $��5 0 0 0q�6e   $��35��6v   $��5q�6�   $	��Xem��6�   $��Center=�6�   $��Center=�6�   
�������$
��Bold"�6�   5)      �� 5*   
   -   5        $��lbStatus��5*      $��1��6    $��Danh sách hóa đơn��6-   
�������$��Italic$�6[   $��15(�6n   $
��Left=�6|   $	��Top=�6�   &   System.Windows.Controls.DataGrid  5,   
   -   5        $��dgLichSuBanHang��5,   2   $��1��6   $��0 30 0 0q�6      Datagrid#���  6I      
IsReadOnly .    Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6%      Header$ Thời gian��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   �� *ThoiGian_LSBH+ �� StringFormat$ dd-MM-yyyy HH:mm tt��   ElementStyle 53      �� 54       �� 
TargetType" ��6    .�55      ��  �� Property � �� �� Value$
 Left=�6D   �� 56       � ��$ 5 0 0 0q�67   �� 57       � ��$ Center=�6B   58      5:        5=      $	 150 6%   $ Số hóa đơn��61    6E   �� *SoHD_LSBH.SoHD_HD+ 5>      �� 5?      " ��6    .�5@      ��  � ��$ Center=�6D   �� 5A       � ��$ Center=�6B   5B      5D        5G      $ 1* 6%   $ Mô tả��60    6?   �� *	MoTa_LSBH+ 5H      �� 5I      " ��6    .�5J      ��  � ��$
 Left=�6D   �� 5K       � ��$ 5 0 0 0q�67   �� 5L       � ��$ Center=�6B   5M      5O        5R      $	 150 6%   $ Nhân viên��61    6D   �� *NhanVienThucHien_LSBH.MaNV_NV+ 5S      �� 5T      " ��6    .�5U      ��  � ��$ Center=�6D   �� 5V       � ��$ Center=�6B   5W      5Y      4  .System.Windows.Controls.DataGridTemplateColumn  5\      $	 100 6)   $ Xem chi tiết��65      CellTemplate 5]      �� 5^      .R�5_      �� $��btnXemChiTiet��6%   -   5          MetroButtonTeal#���  5_   V   $��30��6�   $��2q�6�   .��5`   "   �� .+�5a   &   �� $!��../Image/Icon/fl-detail.png��6,   $��20��6Q   $��Uniform=�6]   5b   #   5c      5d      5f      5i      �� 5k   
   $ 
Horizontal=�6   $��2��6.   $��10q�6;   $
��Left=�6G   .+�5l      �� $��Tổng thu:��6   #���  6(   $��70��6P   �� 5m      -   5        $��	lbTongThu��5m      
��� � �$��15(�68   $��0��6F   $
��Bold"�6R   �� 5n      $��.VNĐ��6   $��15(�6$   $��0 0 30 0q�62   �� 5o      $��Tổng lãi:��6   #���  6(   $��70��6P   �� 5p      -	   5        $��	lbTongLai��5p      
��� � �$��15(�68   $��0��6F   $
��Bold"�6R   �� 5q      $��.VNĐ��6   $��15(�6$   $��0 0 30 0q�62   5r      �� 5t   
   $��0��6   $ 
Horizontal=�6"   $��Right=�6;   $��0 0 10 0q�6W   .+�5u      �� -
   5        $��btnReset��5u      #���  6<   $��5 0 0 0q�6f   $��30��6w   $��1q�6�   .��5v      �� $ 
Horizontal=�6   .+�5w      �� $ ��../Image/Icon/fl-reset.png��6   $��5q�6@   5x      5y      5z      �� 5|   
   -   5        $��
bdProgress��5|      $��1��6   $y�	Collapsed=�60   $��Center=�6G   $��Center=�6d   ���	#FF5788F1$��2q�6�    �� CornerRadius$ 0��6�   ���	#E6FBFAFA._�5}      �� -   5         ��Name$ 
spProgress��5}      $��Center=�6-   $��Center=�6J   $��5q�6e   .+�5~      �� -   5         ��Name$ 
lbProgress��5~      $��Đang xử lý...��6,   $
��Bold"�6E   ���	#FF5788F16W   � 5      -   5         �Name$ pbTienTrinh��5      $	��200��63    � IsIndeterminate . $��20��6V   ���	#FF5788F16b   5�      5�      5�      5�      