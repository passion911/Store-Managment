   M S B A M L   `   `   `  ����  Presentation4    .Presentation.UserControls.BanHangUPresentation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $��0q�5   H      UserControl#���   5        � 	Resources  5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $ ../Style/DataGrid.xaml?�6%   �� 5      $ ../Style/Label.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/UserControl.xaml?�6%   %    5      .��5      � -   5        ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF3F3F3��6    � Offset$ 0Q�61   � 5      $ 	#FFA0B9FB��6   $ 1Q�61   5       � ColumnDefinitions 5   
   �� 5      �� 5      $	��300 �6   .+�5"   
   �  � RowDefinitions 5$      �� 5%      $��50 �6    �� 5&      .+�5)      � $��0��6   
����� �.+�5*      �� 	 �� Orientation$	 
Horizontal=�6   .+�5+      �� $��Sản phẩm (F1):��6   $
��Left=�65   $��Center=�6P   $
��Bold"�6k   
�������$��15(�6�   $��	10,0,10,0q�6�   �� 5,      -   5        
 ��Name$
 	txtMaHang��5,        Textbox1#���  61   $	��200��6T   $��0 5 0 5q�6`   $��Center=�6�   $��25(�6�   $��SP.00001��6�   $
��Bold"�6�   �� 5-      -   5         ��Name$ btnThemHang��5-      $��35��62    � ToolTip$ Thêm hàng vào giỏ��6>   $��10,0,0,0q�6Z   $��50��6l   $��2q�6w     MetroButtonTomato#���  6�   .��5.      �� $	 
Horizontal=�6%   .+�5/      �� $&�� ../Image/Icon/fl-shoppingAdd.png��6$   $��Uniform=�6N   50      51      �� 52      -   5        $��	lbWarning��52       $��Warning!��61   $��Center=�6A   $
��Wrap=�6\   $	��300��6p   
�������$
��Bold"�6�   $��5q�6�   53      �� 54      $��Right=�6   ._�55      �� $	 
Horizontal=�6!   $��Right=�6:   $��Center=�6V   .+�56      �� $
��(F2)��6    $��15(�6/   
�������$
��Bold"�6P   	� 57      -   5         	�Name$ 	rdBanBuon��57   &   $��
Bán buôn��69   $
��Left=�6L   $
��Bold"�6g   $��0q�6y   $��Center=�6�   $��13(�6�   
�������6�   	� 58      -   5        $ rdBanLe��58   &   $��	Bán lẻ��67   $
��Left=�6H   $��5 0 10 0q�6c   $
��Bold"�6u   $��Center=�6�    d� 	IsChecked$
 TrueY�6�   $��13(�6�   
�������6�   59      5:      5;      � 5=      $��1��6   .+�5>      &   System.Windows.Controls.DataGrid  -   5          Name$ dgDanhSachSanPham��5?        Datagrid#���  5@         SelectionMode$ Single=�5A         Columns 5G      0  *System.Windows.Controls.DataGridTextColumn  5J      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6-      Header$	 STT��68      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6W   �� *STT+   ElementStyle 5K      �� 5L   "    �� 
TargetType" ��6(   .�5M   &   ��  �� Property � �� �� Value$ Center=�6L   �� 5N   &    � ��$ Center=�6J   5O   #   5Q        5U      $	 100 6-   $ Mã sản phẩm��69    .  6`   �� *	MaSP_SP+ 5V      �� 5W   "   " ��6(   .�5X   &   ��  � ��$ Center=�6L   �� 5Y   &    � ��$ Center=�6J   5Z   #   5\        5`      $ Tên sản phẩm��6-   $ 1* 6C    .  6`   �� *
TenSP_SP+ 5a      �� 5b   "   " ��6(   .�5c   &   ��  � ��$
 Left=�6L   �� 5d   &    � ��$ Center=�6J   5e   #   5g        5k      $
 Giá��6-   $	 100 6U    .  6:   �� *GiaBan+ 5l      �� 5m   "   " ��6(   .�5n   &   ��  � ��$ Center=�6L   �� 5o   &    � ��$ Center=�6J   5p   #   5r        5v      $ SL��6-   $ 50 69    6D   �� *
SoLuong_SP+ 5w      �� 5x   "   " ��6(   .�5y   &   ��  � ��$ Center=�6L   �� 5z   &    � ��$ Center=�6J   5{   #   5}        5�      $
 CK %��6-   $ 70 6;    .  6X   �� *CKPhanTram_SP+ 5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��$ Center=�6L   �� 5�   &    � ��$ Center=�6J   5�   #   5�        5�      $ CK TM��6-   $	 100 6<    6H   �� *	CKTienMat+ 5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��$ Center=�6L   �� 5�   &    � ��$ Center=�6J   5�   #   5�        5�      $ Thành tiền��6-   $	 100 6A    .  6_   �� *ThanhTien_SP+ 5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��$ Center=�6L   �� 5�   &    � ��$ Center=�6J   5�   #   5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      $ 50 61   $ Sửa��6<    .    CellTemplate 5�      �� 5�   "   .R�5�   &   �� $��btnSuaSP��6-   -	   5          ImageButton#���  5�   -   
��� � �.��5�   *   �� .+�5�   .   �� $��../Image/Icon/fl-edit.png��64   $��Uniform=�6W   $��24��6i   $��3q�6t   5�   +   5�   '   5�   #   5�        5�      $ 50 61   $ Hủy��6<    .  5�      �� 5�   "   .R�5�   &   �� $��btnHuySP��6-   -
   5        #���  5�   -   
��� ���.��5�   *   �� $!��../Image/Icon/fl-delete.png��60   $��Uniform=�6U   $��24��6g   $��3q�6r   5�   '   5�   #   5�      5�      5�      5�      � 5�   
   $��1��5�      
����� � 5�      �� 5�      $	��350 �6    �� 5�      .+�5�      �� $��0��6   .+�5�      �� $��Stretch=�6   $	��Top=�6;   .+�5�      �� $	 
Horizontal=�6!   $��Stretch=�6:   $��0,10,0,0q�6X   .+�5�      �� $��Tổng cộng:��6      
LabelWhile#���  65   $	��100��6Z   �� 5�      -   5         ��Name$ txtbTongTien��5�   $   $��0��6:   $	��150��6C   $��20(�6O   $��Center=�6]    �� TextAlignment$ Right=�6x   
�������6�   �� 5�      $��Right=�6    $��.VNĐ��6<   #���  6K   5�      �� 5�      $	 
Horizontal=�6!   .+�5�      �� $��CK mặt hàng:��6    #���  67   $	��100��6\   �� 5�      -   5        $ txtbCkMatHang��5�   $   $��Center=�6<   $��0��6W   $	��150��6`   $��20(�6l   $ Right=�6z   
�������6�   �� 5�      $��Right=�6    $��.VNĐ��6<   #���  6K   5�      �� 5�      $	 
Horizontal=�6!   .+�5�      �� $��CK hóa đơn:��6    #���  66   $	��100��6[   �� 5�      -   5        $ txtbCkHoaDon��5�   $   $	��150��6:   $��20(�6F   $��Center=�6T   $ Right=�6o   
�������$��0��6�   �� 5�      $��Right=�6    $��.VNĐ��6<   #���  6K   5�      �� 5�      $	 
Horizontal=�5�      .+�5�      �� $��Thành tiền:��6    #���  66   $	��100��6[   �� 5�      -   5        $ txtbThanhTien��5�   $   $	��150��6;   $��Center=�6G   $��20(�6b   $ Right=�6p   
�������$��0��6�   �� 5�      $��Right=�6    $��.VNĐ��6<   #���  6K   5�      �� 5�      $	 
Horizontal=�5�      $y�	Collapsed=�62   .+�5�      �� $��Đã trả (F3):��6    #���  67   $	��100��6\   �� 5�      -   5        $ txtbTraTruoc��5�   $   $��Center=�6:   
�������$	��150��6h   $��16(�6t   $ Right=�6�   $��0��6�   �� 5�      $��Right=�6    $��.VNĐ��6<   #���  6K   5�      �� 5�      $��0,10,0,0q�6   
�������$��0,2,0,0q�6C   ._�5�      �� $	 
Horizontal=�6%   .+�5�      �� $��Còn phải trả:��6$   
�������$��Center=�6O   $��13(�6j   �� 5�      -   5        $ txtbConPhaiTra��5�   (   $��Center=�6@   
�������$
��Bold"�6n   $	��172��6�   $��20(�6�   $ Right=�6�   $��0��6�   �� 5�      $��Right=�6$   $��.VNĐ��6@   #���  6O   5�      5�      �� 5�      $��Center=�6   $	��Top=�6:   $��0 2 0 0q�6R   ���	#FFD1CACA$��2 10 2 5q�6�    �� Padding$ 0 5 0 5q�6�   ._�5�      �� $	 
Horizontal=�6%   .+�5�      �� -   5        $ btnThanhToan��5�   %   $��90��6V   $��90��6b   $��5 0 0 0q�6m     MetroButtonOrange#���  6~   .��5�   "   �� .+�5�   &   �� $ ��../Image/Icon/fl-money.png��6,   $��Uniform=�6P   $��40��6b   �� 5�   &   $��Thanh toán��6,   $��0q�6A   
�������$��Center=�6`   �� 5   &   $
��(F4)��6,   $��0q�6;   
�������$��Center=�6Z   5  #   5     �� 5     -   5        $ btnChietKhau��5  %   $��90��6V   $��90��6b   $��5 0 0 0q�6m     MetroButtonYellowGreen#���  6~   .��5  "   �� .+�5  &   �� $$��../Image/Icon/fl-discounts.png��6,   $��Uniform=�6T   $��40��6f   �� 5  &   $��Chiết khấu��6,   $��0q�6A   
�������6M   �� 5  &   $
��(F5)��6,   $��0q�6;   
�������$��Center=�6Z   5  #   5	     �� 5
     -   5        $ btnHuy��5
  %   $��90��6J   $��90��6V   $��5 0 0 0q�6a   #���  6r   .��5  "   �� .+�5  &   �� $!��../Image/Icon/fl-delete.png��6,   $��Uniform=�6Q   $��40��6c   �� 5  &   $��Hủy phiếu��6,   $��0q�6@   
�������6L   �� 5  &   $
��(F6)��6,   $��0q�6;   
�������$��Center=�6Z   5  #   5     5     5     �� 5     $��Stretch=�6   $	��Top=�6;   $��0 5 0 5q�6S   $��0,2,0,0q�6d   ��5     �� 5     $ 0.5,1&�62   $ 0.5,0&�6C   .��5  "   � $ 	#FFFBFBFB��6/   $ 0Q�6A   � 5  "   $ 	#FFF7F3F3��6/   $ 1Q�6A   5     ._�5     �� $	 
Horizontal=�6%   $��0,10,0,0q�6>   .+�5     �� $��Khách hàng(F7)��6$   
�������$
��Bold"�6P   $��Center=�6b   $��12(�6}   $��0q�6�   $��2 0 0 0q�6�   �� 5     -   5        $
 txtKhachHang��5  &   #���  6W   $	��130��6z   $��5 0 0 0q�6�   $��KH00001��6�   $��Center=�6�   $��25(�6�   $
��Bold"�6�   �� 5     -   5        $ btnKhachHang��5  %     MetroButtonGreen#���  6V   .��5   "   �� $	 
Horizontal=�6-   .+�5!  &   �� $��../Image/Icon/fl-user.png��6,   $��30��6O   $��Uniform=�6[   $��5q�6m   5"  #   5#     5$     5%     5&     5'     � 5(     -   5        $��gdKhachHang��5(     $��1��6&   5*     5+     �� 5,  
   -   5        $��
bdProgress��5,     $��1��6   $��Center=�60   $��Center=�6M   ���	#FF5788F1$��2q�6�    �� CornerRadius$ 0��6�   ���	#E6FBFAFA._�5-     �� -   5         ��Name$ 
spProgress��5-     $��Center=�6-   $��Center=�6J   $��5q�6e   .+�5.     �� -   5          ��Name$  
lbProgress��5.     $��Đang xử lý...��6,   $
��Bold"�6E   ���	#FF5788F16W   � 5/     -   5        ! �Name$! pbTienTrinh��5/     $	��200��63   " � IsIndeterminate" . $��20��6V   ���	#FF5788F16b   50     51     52     53     