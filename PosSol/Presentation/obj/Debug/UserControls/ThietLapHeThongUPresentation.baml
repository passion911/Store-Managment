   M S B A M L   `   `   `  ����  Presentation<    6Presentation.UserControls.ThietLapHeThongUPresentation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5           UserControl#���   5   H     � 	Resources  5       �� MergedDictionaries �� Source�� 5	   
    5
      �� 5      $ ../Style/DataGrid.xaml?�6%   �� 5      $ ../Style/Label.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/UserControl.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF3F3F3��6    � Offset$ 0Q�61   � 5      $ 	#FFA0B9FB��6   $ 1Q�61   5      .+�5   
   �� .��5      �� $��Stretch=�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��	20 30 0 0q�66   .+�5      �� $��Tên cửa hàng��6     lbControlLeft#���  63   $��20(�6[   $	��200��6i   �� 5      -   5        $��txtTenCuaHang��5        Textbox1#���  63   $��25(�6V   $	��600��6d   $��10 0 0 0q�6p    � ToolTip$[ UTên hiển thị tại hóa đơn bán hàng và một số tài liệu thống kế��6�   5      �� 5!      $ 
Horizontal=�6   $��	20 10 0 0q�66   .+�5"      �� $��Địa chỉ��6   #���  6.   $��20(�6V   $	��200��6d   �� 5#      -   5        $��	txtDiaChi��5#      #���  6/   $��25(�6R   $	��600��6`   $��10 0 0 0q�6l   $< 6Địa chỉ hiển thị tại hóa đơn bán hàng.��6~   5$      �� 5&      $ 
Horizontal=�6   $��	20 10 0 0q�66   .+�5'      �� $��Số điện thoại��6   #���  64   $��20(�6\   $	��200��6j   �� 5(      -   5        $��txtSDT��5(      #���  6,   $��25(�6O   $	��600��6]   $��10 0 0 0q�6i   $3 -Điện thoại liên hệ của cửa hàng.��6{   5)      �� 5+      $ 
Horizontal=�6   $��	20 10 0 0q�66   .+�5,      �� $��Mức quy đổi điểm��6   #���  67   $��20(�6_   $	��200��6m   �� 5-      -   5        $��txtMucQuyDoi��5-      #���  62   $��25(�6U   $	��300��6c   $��10 0 0 0q�6o   $ Đồng / 1 Điểm��6�   5.      �� 5/      -   5        $��	stHanDung��5/   I   $ 
Horizontal=�6   $��	20 10 0 0q�66   .+�50      �� $��Hạn dùng��6   #���  6/   $��20(�6W   $	��200��6e   (  "System.Windows.Controls.DatePicker  51      -   5        $��dateDenNgay��51   !   $��Center=�64   $��20(�6O   $��10 0 0 0q�6]   
��� � �$	��200��6�   	   DisplayDateEnd$	 1/1/2099X�6�   
   DisplayDateStart$
 1/1/2010X�6�   52      �� 53      $ 
Horizontal=�6   $��	20 10 0 0q�66   .+�54      �� $��Voucher��6   #���  6.   $��20(�6V   $	��200��6d   d� 55      -   5        $��
btnVoucher��55   #     ToggleSwitchStyle#���  65   $��40��6a   $��80��6m   $
��Left=�6x   $��10 0 0 0q�6�   $B <Tắt bật tính năng sử dụng Voucher khi thanh toán.��6�   56      �� 58      $ 
Horizontal=�6   $��	20 10 0 0q�66   .+�59      �� $��Mã giảm giá��6   #���  62   $��20(�6Z   $	��200��6h   d� 5:      -	   5        $��btnMaGiaGia��5:   #   #���  66   $��40��6b   $��80��6n   $
��Left=�6y   $��10 0 0 0q�6�   $J DBật/tắt tính năng sử dụng mã giảm giá khi thanh toán.��6�   5;      �� 5=      $ 
Horizontal=�6   $��	20 10 0 0q�66   .+�5>      �� $��Chiết khấu hóa đơn��6   #���  69   $��20(�6a   $	��200��6o   d� 5?      -
   5        $��btnCkHoaDon��5?   #   #���  66   $��40��6b   $��80��6n   $
��Left=�6y   $��10 0 0 0q�6�   $H BBật/tắt tính năng chiết khấu hóa đơn khi thanh toán.��6�   5@      �� 5B      $ 
Horizontal=�6   $��	20 10 0 0q�66   .+�5C      �� $!��Chiết khấu sản phẩm��6   #���  6:   $��20(�6b   $	��200��6p   d� 5D      -   5        $��btnCkSanPham��5D   #   #���  67   $��40��6c   $��80��6o   $
��Left=�6z   $��10 0 0 0q�6�   $J DBật/tắt tính năng chiết khấu sản phẩm khi thanh toán.��6�   5E      �� 5G      $ 
Horizontal=�6   $��	20 10 0 0q�66   .+�5H      �� $��Kiểm tra giá nhập��6   #���  68   $��20(�6`   $	��200��6n   d� 5I      -   5        $��btnKiemTraGiaNhap��5I   #   #���  6<   $��40��6h   $��80��6t   $
��Left=�6   $��10 0 0 0q�6�   $J DBật/tắt tính năng chiết khấu sản phẩm khi thanh toán.��6�   5J      �� 5L      $ 
Horizontal=�6   $��	20 10 0 0q�66   $y�	Collapsed=�6I   .+�5M      �� $��Tích điểm KH��6   #���  63   $��25(�6[   $	��200��6i   d� 5N      -   5        $��btnTichDiem��5N   #   #���  66   $��40��6b   $��80��6n   $
��Left=�6y   $��10 0 0 0q�6�   $I CBật/Tắt tính năng ccoong điểm tích lũy cho khách hàng.��6�   5O      �� 5Q      $ 
Horizontal=�6   $��Bottom=�66   .+�5R      �� -   5        $��btnLuu��5R        MetroButtonTeal#���  6@   $	��100��6j   $��50��6v   $
��Left=�6�   $��
230 30 0 0q�6�   $��Lưu(F1)��6�   
�������$��25(�6�   5S      �� 5T      -   5        $��	lbWarning��5T        LabelWarning#���  6)   $��20(�6P   $��10 0 0 0q�6^   $y�Hidden=�6p   5U      5W      �� 5Y   
   -   5        $��
bdProgress��5Y      $��1��6   $y�Hidden=�60   $��Center=�6D   $��Center=�6a   ���	#FF5788F1$��2q�6�    �� CornerRadius$ 0��6�   ���	#E6FBFAFA._�5Z      �� -   5         ��Name$ 
spProgress��5Z      $��Center=�6-   $��Center=�6J   $��5q�6e   .+�5[      �� -   5         ��Name$ 
lbProgress��5[      $��Đang xử lý...��6,   $
��Bold"�6E   ���	#FF5788F16W   � 5\      -   5         �Name$ pbTienTrinh��5\      $	��200��63    � IsIndeterminate . $��20��6V   ���	#FF5788F16b   5]      5^      5_      5`      