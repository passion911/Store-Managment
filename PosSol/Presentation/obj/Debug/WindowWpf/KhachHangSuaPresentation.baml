   M S B A M L   `   `   `  ����  Presentation5    /Presentation.WindowWpf.KhachHangSuaPresentation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$#  Sửa thông tin khách hàng��5   	   $	��580��5   	   $	��380��6    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.    � Icon$4 ./Presentation;component/Image/Icon/fl-edit.png��6[    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5	      �� 5
      $ ../Style/UserControl.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   �� 5      $ ../Style/Label.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      � 	 � Color$	 	#FFF3F3F3��6   
 � Offset$
 0Q�61   � 5      $	 	#FFA0B9FB��6   $
 1Q�61   5       � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5       $��35 �6   �� 5!      $��65 �6   �� 5"      $��35 �6   �� 5#      $��35 �6   �� 5$      $��35 �6   �� 5%      $��35 �6   �� 5&      $��60 �6   �� 5'      $��35 �6   �� 5(       � ColumnDefinitions 5*   
   �� 5+      $	��150 �6   �� 5,      .+�51   
   �� $��0��6   $��0��6    $��5 0 0 0q�6-   $��Mã khách hàng��6>      lbControlLeft#���   6V   $
��auto��6~   �� 52   
   $��0��6   $��1��6    $��5 0 0 0q�6-   $��Tên khách hàng��6>   #���   6W   $
��auto��6   �� 53   
   $��0��6   $��2��6    $��5 0 0 0q�6-   $��Giới tính��6>   #���   6R   $
��auto��6z   �� 54   
   $��0��6   $��3��6    $��5 0 0 0q�6-   $��
Ngày sinh��6>   #���   6R   $
��auto��6z   �� 55   
   $��0��6   $��4��6    $��5 0 0 0q�6-   $��Email��6>   #���   6N   $
��auto��6v   �� 56   
   $��0��6   $��5��6    $��5 0 0 0q�6-   $��Nhóm khách hàng��6>   #���   6X   $
��auto��6�   �� 57   
   $��0��6   $��6��6    $��5 0 0 0q�6-   $
��SĐT��6>   #���   6L   $
��auto��6t   �� 58   
   $��0��6   $��7��6    $��5 0 0 0q�6-   $��Ghi chú��6>   #���   6P   $
��auto��6x   $	��Top=�6�   �� 59   
   $��0��6   $��8��6    $��5 0 0 0q�6-   $��Số lần mua hàng��6>   #���   6X   $
��auto��6�   �� 5:   
   $��0��6   $��9��6    $��5 0 0 0q�6-   $��Điểm tích lũy��6>   #���   6V   $
��auto��6~   �� 5;   
   $��0��6   $��10��6    $��5 0 0 0q�6.   $��Tự động lên nhóm��6?   #���   6Z   $
��auto��6�   �� 5=   
   -   5         ��Name$ txtbMaKH��5=      $��1��6$   {�.  $��0��6F     Textbox1#���  6S   $	��200��6v   $��15(�6�   $
��Left=�6�   �� 5>   
   -   5        $ txtTenKH��5>      $��1��6$   $��1��64   #���  6A   $	��200��6d   $��15(�6p   $
��Left=�6~   	� 5?   
   -   5         	�Name$ rdNam��5?      $��1��6%   $��2��65   $	��Nam��6B   $
��Left=�6P   $��Center=�6k    d� 	IsChecked$
 TrueY�6�   $��15(�6�   $��Center=�6�   $��0q�6�   	� 5@   
   -   5        $
 rdNu��5@      $��1��6$   $��2��64   $
��Nữ��6A   $
��Left=�6N   $��70 0 0 0q�6i   $��Center=�6{   $��15(�6�   $��Center=�6�   $��0q�6�   (  "System.Windows.Controls.DatePicker  5A   
   -   5          Name$ 
dtNgaySinh��5A      $��1��6)   $��3��69   $��15(�6F   $
��Left=�6T   $	��Top=�6o   $	��200��6�      FirstDayOfWeek$ Monday=�6�      SelectedDate$ 1/1/1992X�6�      DisplayDateEnd$ 1/1/2099X�6�      DisplayDateStart$ 1/1/1950X�6�    � ToolTip$ Ngày sinh khách hàng��6�      DisplayDate$ 
1992-01-01��6  �� 5B   
   -   5        $ txtEmail��5B      #���  6$   $��15(�6G   $��1��6U   $��4��6e   $
��Left=�6r   $��Center=�6�   $	��200��6�   �� 5C   
   -   5         ��Name$ 	cboNhomKH��5C      $��1��6'   $��5��67   $
��Left=�6E   $��Center=�6a   $��15(�6}   $	��200��5D       �� SelectedIndex$ 0��5E       �� SelectedValuePath$ 	MaNKH_NKH��5F      ��5G      �� 5H      .R�5I      ��  �� Orientation$ 
Horizontal=�6!   .+�5J      �� $��25��6    $��Uniform=�6G   ��6,   �� *	Anh_NKH+6G   �� 5K      $��Bottom=�6@   ��6$   �� *
TenNKH_NKH+6@   5L      5M      5O      �� 5P   
   -	   5        $ txtSDT��5P      #���  6"   $��15(�6E   $��1��6S   $��6��6c   $
��Left=�6p   $��Center=�6�   $	��200��6�   �� 5Q   
   -
   5         ��Name$ 
rtxtGhiChu��5Q      $��1��6*   $��7��6:   $��25(�6H   $
��Left=�6V   $��60��6q   $��Center=�6~   $	��200��6�   �� 5R   
   -   5        $ txtSoLanMua��5R      $��1��6'   $��8��67   #���  6D   $��15(�6g   $
��Left=�6u   $��Center=�6�   $	��100��6�   $��0��6�   �� 5S   
   -   5        $ txtDiemTichLuy��5S      $��1��6*   $��9��6:   #���  6G   $��15(�6j   $
��Left=�6x   $��Center=�6�   $	��100��6�   $��0��6�   �� 5T   
   -   5         ��Name$ ckLenNhomTuDong��5T      $��1��6,   $��10��6<   $��15(�6K   $
��Left=�6Y   $��Center=�6t   $
 TrueY�6�   �� 5U   
   $��0��6   $��11��6    $��Đang dùng��6.   #���   6B   $
��auto��6j   $��5 0 0 0q�6w   �� 5V   
   -   5        $��
ckDangDung��5V   L   $��1��6   $��11��6#   $��Center=�61   $
 TrueY�6^   �� 5X   
   $��12��6   $��2��6    $��Stretch=�64   
�������$��0 1 0 1q�6e   $��	10 0 10 5q�6   $��Center=�6�   ._�5Y      �� $ 
Horizontal=�6   $	��Top=�62   $��Center=�6J   $��0 5 0 5q�6g   .+�5Z      �� -   5        $��btnLuu��5Z        MetroButtonTomato#���  6<   $��40��6h   $��5q�6t   .��5[      �� $ 
Horizontal=�6!   .+�5\      �� $��../Image/Icon/fl_save.png��6    $��Uniform=�6C   �� 5]      $
��Lưu��6    
�������$��Center=�6A   $
��Bold"�6\   5^      5_      �� 5`      -   5        $��btnHuy��5`        MetroButtonTeal#���  6<   $��5 0 0 0q�6f   $��40��6w   $��5q�6�   .��5a      �� $ 
Horizontal=�6!   .+�5b      �� $!��../Image/Icon/fl-cancel.png��6    $��Uniform=�6E   �� 5c      $��Hủy��6    
�������$��Center=�6A   $
��Bold"�6\   5d      5e      5f      5g      �� 5h   
   -   5        $��	lbWarning��5h   `   $y�	Collapsed=�6   $��0��6'   $
��Left=�67   $��13��6R   $��5 0 0 5q�6q   $��2��6�     LabelWarning#���  6�   $��13(�6�   $��Bottom=�6�   $��Warning��6�   5i      5j      