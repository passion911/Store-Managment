   M S B A M L   `   `   `  ����  Presentation5    /Presentation.UserControls.TrangChuUPresentation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5           UserControl#���   5   H     � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5	      �� 5
      $ ../Style/UserControl.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF3F3F3��6    � Offset$ 0Q�61   � 5      $ 	#FFA0B9FB��6   $ 1Q�61   5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $
��Left=�6   $	��Top=�64   $��	20 20 0 0q�6L   .+�5      �� -   5         ��Name$ 
btnBanHang��5      $��90��6F   $��5 0 0 0q�6R   $��5 5 50 5q�6c   $
��Left=�6v     MetroButtonTomato#���  6�   .��5      �� $ 
Horizontal=�6!   .+�5      �� $#��../Image/Icon/fl-shopping.png��6    $��Uniform=�6G   �� 5      $��Center=�6%   $��5 0 0 0q�6@   .+�5      �� $��
Bán hàng��6$   
�������$
��Left=�6J   $
��Bold"�6e   $��25(�6w   $��0q�6�   �� 5      $!��Lập hóa đơn bán hàng��6$   
�������6C   5       5!      5"      �� 5#      -   5        $ 
btnNhanMua��5#      $��90��6F   $��5 10 0 0q�6R   $��5 5 50 5q�6d   $
��Left=�6w     MetroButtonYellowGreen#���  6�   .��5$      �� $ 
Horizontal=�6!   .+�5%      �� $"��../Image/Icon/fl-produce.png��6    $��Uniform=�6F   �� 5&      $��Center=�6%   $��5 0 0 0q�6@   .+�5'      �� $��
Nhập mua��6$   
�������$
��Left=�6J   $
��Bold"�6e   $��25(�6w   $��0q�6�   �� 5(      $(��"Nhập sản sản phẩm vào kho��6$   
�������6H   5)      5*      5+      �� 5,      -   5        $ btnKhacHang��5,      $��90��6H   $��5 10 0 0q�6T   $��5 5 50 5q�6f   $
��Left=�6y     MetroButtonGreen#���  6�   .��5-      �� $ 
Horizontal=�6!   .+�5.      �� $$��../Image/Icon/fl-KhachHang.png��6    $��Uniform=�6H   �� 5/      $��Center=�6%   $��5 0 0 0q�6@   .+�50      �� $��Khách hàng��6$   
�������$
��Left=�6L   $
��Bold"�6g   $��25(�6y   $��0q�6�   �� 51      $��Thông tin khách hàng��6$   
�������6C   52      53      54      �� 55      -   5        $ 
btnSanPham��55      $��90��6F   $��5 10 0 0q�6R   $��5 5 50 5q�6d   $
��Left=�6w     MetroButtonDarkGreen#���  6�   .��56      �� $ 
Horizontal=�6!   .+�57      �� $"��../Image/Icon/fl-sanpham.png��6    $��Uniform=�6F   �� 58      $��Center=�6%   $��5 0 0 0q�6@   .+�59      �� $��Sản phẩm��6$   
�������$
��Left=�6J   $
��Bold"�6e   $��25(�6w   $��0q�6�   �� 5:      $(��"Quản lý thông tin sản phẩm��6$   
�������6I   5;      5<      5=      5>      �� 5@      $
��Left=�6   $	��Top=�64   $��	20 20 0 0q�6L   .+�5A      �� -   5        $ 
btnHangTra��5A      $��90��6F   $��5 0 0 0q�6R   $��5 5 50 5q�6c   $
��Left=�6v     MetroButtonOrange#���  6�   .��5B      �� $ 
Horizontal=�6!   .+�5C      �� $!��../Image/Icon/fl-change.png��6    $��Uniform=�6E   �� 5D      $��Center=�6%   $��5 0 0 0q�6@   .+�5E      �� $��Nhập hàng trả��6$   
�������$
��Left=�6O   $
��Bold"�6j   $��25(�6|   $��0q�6�   �� 5F      $$��Hàng khác mua trả lại...��6$   
�������6G   5G      5H      5I      �� 5J      -   5        $ 	btnMaVach��5J      $��90��6D   $��5 10 0 0q�6P   $��5 5 50 5q�6b   $
��Left=�6u     MetroButtonMaroon#���  6�   .��5K      �� $ 
Horizontal=�6!   .+�5L      �� $"��../Image/Icon/fl-barcode.png��6    $��Uniform=�6F   �� 5M      $��Center=�6%   $��5 0 0 0q�6@   .+�5N      �� $$��In mã vạch cho sản phẩm��6$   
�������$
��Left=�6Y   $
��Bold"�6t   $��20(�6�   $��0q�6�   �� 5O      $!��Mã vạch cho sản phẩm��6$   
�������6C   5P      5Q      5R      �� 5S      -   5        $ btnDoiMatKHau��5S      $y�Hidden=�60   $��90��6D   $��5 10 0 0q�6P   $��5 5 50 5q�6b   $
��Left=�6u     MetroButtonOlive#���  6�   .��5T      �� $ 
Horizontal=�6!   .+�5U      �� $%��../Image/Icon/fl-doimatkhau.png��6    $��Uniform=�6I   �� 5V      $��Center=�6%   $��5 0 0 0q�6@   .+�5W      �� $��Đổi mật khẩu��6$   
�������$
��Left=�6N   $
��Bold"�6i   $��25(�6{   $��0q�6�   �� 5X      $'��!Đổi mật khẩu đăng nhập��6$   
�������6E   5Y      5Z      5[      5\      5]      5^      5_      