   M S B A M L   `   `   `  ����  Presentation6    0Presentation.UserControls.KhachHangUPresentation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $��ucKhachHang��5         UserControl#���   6!     � 	Resources  5       �� MergedDictionaries �� Source�� 5	   
    5
      �� 5      $ ../Style/UserControl.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   �� 5      $ ../Style/Label.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF3F3F3��6    � Offset$ 0Q�61   � 5      $ 	#FFA0B9FB��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5       $��50 �6   .+�5#   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��50��6;   $��5 0 0 5q�6G   .+�5$      �� -   5        $��cboNhomKhachHang��5$      	 �� SelectedIndex$	 0��6/   
 �� DisplayMemberPath$
 
TenNKH_NKH��6A    �� SelectedValuePath$ 	MaNKH_NKH��6`   $��20(�6�   $	��250��6�   $��Center=�6�   $��0 0 30 0q�6�   $��Center=�6�   �� 5%      -   5         ��Name$ 
txtTimKiem��5%        Textbox1#���  6*   $��20(�6M   $	��200��6[   $	��0,6q�6g   �� 5&      -   5        $��
btnTimKiem��5&        MetroButtonDarkGreen#���  6@   $��5 0 0 0q�6o   $��35��6�   $��5q�6�   .��5'      �� $ 
Horizontal=�6   .+�5(      �� $!��../Image/Icon/fl-search.png��6   $��Uniform=�6A   5)      5*      �� 5+      -   5        $��	lbWarning��5+      $y�Hidden=�6%   $��Warning!��69     LabelWarning#���  6M   $��10 0 0 0q�6u   $��Center=�6�   $��15(�6�   5,      �� 5.   
   -   5        $��btnReset��5.        MetroButtonTeal#���  68   $��5 0 5 0q�6b   $��Right=�6s   $��Center=�6�   $��30��6�   $��1q�6�   .��5/      �� $ 
Horizontal=�6   .+�50      �� $ ��../Image/Icon/fl-reset.png��6   $��5q�6<   51      52      &   System.Windows.Controls.DataGrid  54   
   -   5          Name$ dgKhachHang��54      $��1��6*      SelectionMode$ Single=�67     Datagrid#���  6w      
IsReadOnly .    RowDetailsVisibilityMode$ 	Collapsed=�55       �� SelectedItem 54   N   �� *sl+ �� Mode$ OneWay=�   Columns 57      4  .System.Windows.Controls.DataGridTemplateColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Header$ Nhóm KH��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6:      CellTemplate 5;      �� 5<      .R�5=      �� $
��None=�6?   ��6$   �� *	Anh_NKH+ � ToolTip 6N   �� *
TenNKH_NKH+5>      5@      0  *System.Windows.Controls.DataGridTextColumn  5C      $	 100 6%   $	 Mã��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *	MaKH_KH+   ElementStyle 5D      �� 5E       �� 
TargetType" ��6    .�5F      ��  �� Property � �� �� Value$ Center=�6D   �� 5G       � ��$ Center=�6B   5H      5J        5M      $ 2* 6%   $
 Tên��60    6=   �� *
HoTen_KH+ 5N      �� 5O      " ��6    .�5P      ��  � ��$
 Left=�6D   �� 5Q       � ��$ 5,0,0,0q�67   �� 5R       � ��$ Center=�6B   5S      5U        5X      $ 50 6%   $ Điểm��60    6>   �� *DiemTichLuy_KH+ 5Y      �� 5Z      " ��6    .�5[      ��  � ��$ Center=�6D   �� 5\       � ��$ Center=�6B   5]      5_        5b      $ 80 6%   $ Số lần mua��60    6D   �� *SoLanMuaHang_KH+ 5c      �� 5d      " ��6    .�5e      ��  � ��$ Center=�6D   �� 5f       � ��$ Center=�6B   5g      5i        5l      $ 1* 6%   $ Lần mua gần nhất��60    6J   �� *LanMuaHangGanNhat_KH+ �� StringFormat$ 
dd-MM-yyyy�� 5m      �� 5n      " ��6    .�5o      ��  � ��$ Center=�6D   �� 5p       � ��$ Center=�6B   5q      5s        5v      $	 100 6%   $
 SĐT��61    6>   �� *SDT_KH+ 5w      �� 5x      " ��6    .�5y      ��  � ��$
 Left=�6D   �� 5z       � ��$ 5 0 0 0q�68   �� 5{       � ��$ Center=�6B   5|      5~      4  .System.Windows.Controls.DataGridCheckBoxColumn  5�      $ 1* 6)   $ Tự động lên nhóm��64      
IsReadOnly .  6N   �� *TuDongLenNhom_KH+ 5�      �� 5�      " ��6    .�5�      ��  � ��$ Center=�6D   �� 5�       � ��$ Center=�6B   �� 5�       �@J�IsHitTestVisible .  6A   5�      5�        5�      $ 1* 6)   $ Đang dùng��64    .  6G   �� *DangDung_KH+ 5�      �� 5�      " ��6    .�5�      ��  � ��$ Center=�6D   �� 5�       � ��$ Center=�6B   �� 5�       �@J�IsHitTestVisible .  6A   5�      5�        5�      $ 50 6)   $ Sửa��64    5�      �� 5�      .R�5�      �� $��btnSua��6%   -   5          MetroButtonYellowGreen#���  5�   3   $��30��6y   $��2q�6�   .��5�   "   �� .+�5�   &   �� $��../Image/Icon/fl-edit.png��6-   $��Uniform=�6P   $��20��6b   5�   #   5�      5�      5�        5�      $ 50 6)   $
 Xóa��64    5�      �� 5�      .R�5�      �� $��btnXoa��6%   -	   5          MetroButtonOrange#���  5�   H   $��30��6t   $��2q�6�   .��5�   "   �� .+�5�   &   �� $!��../Image/Icon/fl-delete.png��6,   $��20��6Q   $��Uniform=�6]   5�   #   5�      5�      5�         RowDetailsTemplate 5�      �� 5�      .R�5�      � ��5�      �� 5�      $ 0.5,1&�62   $ 0.5,0&�6C   .��5�   "   � $ 	#FFF3F3F3��6/   $ 0Q�6A   � 5�   "   $ 	#FFA0B9FB��6/   $ 1Q�6A   5�      .+�5�      �� $��1��6%   $ Vertical=�65   $��10 5 0 5q�6L   .+�5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $��
Họ tên:��6(   $��Center=�6:   $	��100��6U   �� 5�   "   $��Center=�6F   ��6,   �� *
HoTen_KH+6F   5�      �� 5�      $ 
Horizontal=�6)   .+�5�   "   �� $��Nhóm khách hàng:��6(   $��Center=�6C   �� 5�   "   $��0��6I   $��Center=�6Y   ��6-   �� *
TenNKH_NKH+6Y   5�      �� 5�      $ 
Horizontal=�6)   .+�5�   "   �� $��Giới tính:��6(   $	��100��6=   $��Center=�6I   �� 5�   "   $��Center=�6I   ��6,   �� *GioiTinh_KH+6I   5�      �� 5�      $ 
Horizontal=�6)   .+�5�   "   �� $��
Ngày sinh��6(   $��Center=�6<   $	��100��6W   �� 5�   "   $��Center=�6a   ��6,   �� *NgaySinh_KH+$ 
dd-MM-yyyy��6a   5�      �� 5�      $ 
Horizontal=�6)   .+�5�   "   �� $��Email:��6(   $��Center=�6:   $	��100��6U   �� 5�   "   $��Center=�6F   ��6,   �� *
Email_KH+6F   5�      �� 5�      $ 
Horizontal=�6)   .+�5�   "   �� $��	Ghi chú:��6(   $	��100��6;   $��Center=�6G   �� 5�   "   $��Center=�6G   ��6,   �� *	GhiChu_KH+6G   5�      5�      5�      5�      5�      �� 5�   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   $��Center=�6W   $��0 0 5 0q�6r   .+�5�      �� -
   5        $��btnXuatExcel��5�      #���  6)   $��5 0 0 0q�6U   $��40��6f   $��5q�6r   .��5�      �� $ 
Horizontal=�6   .+�5�      �� $ ��../Image/Icon/fl-excel.png��6   $��Uniform=�6@   �� 5�      $��Xuất Excel��6   
�������$��Center=�6D   $
��Bold"�6_   5�      5�      �� 5�      -   5        $��
btnThemMoi��5�      #���  6@   $��5 0 0 0q�6l   $��40��6}   $��5q�6�   .��5�      �� $ 
Horizontal=�6   .+�5�      �� $&�� ../Image/Icon/fl-addDocument.png��6   $��Uniform=�6F   �� 5�      $��Thêm��6   
�������$��Center=�6>   $
��Bold"�6Y   5�      5�      �� 5�      -   5        $��btnInThe��5�      #���  6<   $��5 0 0 0q�6h   $��40��6y   $��5q�6�   .��5�      �� $ 
Horizontal=�6   .+�5�      �� $"��../Image/Icon/fl-printer.png��6   $��Uniform=�6B   �� 5�      $��In thẻ��6   
�������$��Center=�6@   $
��Bold"�6[   5�      5�      5�      5�      5�      