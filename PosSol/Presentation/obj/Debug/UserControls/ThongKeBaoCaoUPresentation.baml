   M S B A M L   `   `   `  ����  Presentation:    4Presentation.UserControls.ThongKeBaoCaoUPresentation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5           UserControl#���   5        � 	Resources  5       �� MergedDictionaries �� Source�� 5	   
    5
      �� 5      $ ../Style/UserControl.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF3F3F3��6    � Offset$ 0Q�61   � 5      $ 	#FFA0B9FB��6   $ 1Q�61   5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $
��Left=�6   $	��Top=�64   $��	20 20 0 0q�6L   .+�5      �� -   5         ��Name$ 	btnHoaDon��5      $��90��6D   $��5 0 0 0q�6P   $��5 5 50 5q�6a   $
��Left=�6t     MetroButtonTomato#���  6�   .��5      �� $ 
Horizontal=�6!   .+�5      �� $!��../Image/Icon/fl-HoaDon.png��6    $��Uniform=�6E   $��5q�6W   �� 5      $��Center=�6%   $��5 0 0 0q�6@   .+�5      �� $��
Hóa đơn��6$   
�������$
��Left=�6I   $
��Bold"�6d   $��25(�6v   $��0q�6�   �� 5       $"��Doanh thu theo hóa đơn...��6$   
�������6H   5!      5"      5#      �� 5$      -   5        $ btnLichSuBanHang��5$      $��90��6R   $��5 10 0 0q�6^   $��5 5 50 5q�6p   $
��Left=�6�     MetroButtonYellowGreen#���  6�   .��5%      �� $ 
Horizontal=�6!   .+�5&      �� $"��../Image/Icon/fl-history.png��6    $��Uniform=�6F   $��5q�6X   �� 5'      $��Center=�6%   $��5 0 0 0q�6@   .+�5(      �� $��Lịch sử bán hàng��6$   
�������$
��Left=�6R   $
��Bold"�6m   $��25(�6   $��0q�6�   �� 5)      $'��!Xem lịch sử mua - trả hàng��6$   
�������6I   5*      5+      5,      �� 5-      -   5        $ btnPhieuNhap��5-      $��90��6J   $��5 10 0 0q�6V   $��5 5 50 5q�6h   $
��Left=�6{     MetroButtonGreen#���  6�   .��5.      �� $ 
Horizontal=�6!   .+�5/      �� $"��../Image/Icon/fl-nhapmua.png��6    $��Uniform=�6F   $��5q�6Y   �� 50      $��Center=�6%   $��5 0 0 0q�6@   .+�51      �� $��Phiếu nhập��6$   
�������$
��Left=�6L   $
��Bold"�6g   $��25(�6y   $��0q�6�   �� 52      $��Xem phiếu nhập kho...��6$   
�������6D   53      54      55      56      �� 58      $
��Left=�6   $	��Top=�64   $��	20 20 0 0q�6L   .+�59      �� -   5        $ btnThongKeTheoSP��59      $��90��6R   $��5 0 0 0q�6^   $��5 5 50 5q�6o   $
��Left=�6�     MetroButtonOrange#���  6�   .��5:      �� $ 
Horizontal=�6!   .+�5;      �� $"��../Image/Icon/fl-bieudo1.png��6    $��Uniform=�6F   $��5q�6Y   �� 5<      $��Center=�6%   $��5 0 0 0q�6@   .+�5=      �� $!��Doanh thu theo sản phẩm��6$   
�������$
��Left=�6Y   $
��Bold"�6t   $��20(�6�   $��0q�6�   �� 5>      $*��$Xem doanh thu từng sản phẩm...��6$   
�������6M   5?      5@      5A      �� 5B      -   5        $ btnThongKeTheoNV��5B      $��90��6R   $��5 10 0 0q�6^   $��5 5 50 5q�6p   $
��Left=�6�     MetroButtonTeal#���  6�   .��5C      �� $ 
Horizontal=�6!   .+�5D      �� $#��../Image/Icon/fl-customer.png��6    $��Uniform=�6G   $��5q�6Z   �� 5E      $��Center=�6%   $��5 0 0 0q�6@   .+�5F      �� $ ��Doanh thu theo nhân viên��6$   
�������$
��Left=�6Z   $
��Bold"�6u   $��20(�6�   $��0q�6�   �� 5G      $&�� Theo dõi nhân viên bán hàng��6$   
�������6J   5H      5I      5J      �� 5K      -   5        $ btnThongKeTheoKH��5K      $��90��6R   $��5 10 0 0q�6^   $��5 5 50 5q�6p   $
��Left=�6�     MetroButtonMaroon#���  6�   .��5L      �� $ 
Horizontal=�6!   .+�5M      �� $%��../Image/Icon/fl-tkkhachang.png��6    $��Uniform=�6I   $��5q�6[   �� 5N      $��Center=�6%   $��5 0 0 0q�6@   .+�5O      �� $!��Doanh thu theo khách hàng��6$   
�������$
��Left=�6[   $
��Bold"�6v   $��20(�6�   $��0q�6�   �� 5P      $*��$Xem doanh thu mua hàng của khách��6$   
�������6O   5Q      5R      5S      5T      5V      5W      5X      