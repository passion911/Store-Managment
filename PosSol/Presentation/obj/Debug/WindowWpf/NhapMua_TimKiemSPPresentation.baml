   M S B A M L   `   `   `  ����  Presentation:    4Presentation.WindowWpf.NhapMua_TimKiemSPPresentation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Tìm kiếm sản phẩm��5   	   $	��500��6#   $	��700��60    � 
ResizeMode$ NoResize=�6<    � WindowStartupLocation$ CenterScreen=�5        � Icon$6 0/Presentation;component/Image/Icon/fl-search.png��6E    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5	      �� 5
      $ ../Style/Datagrid.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      � 	 � Color$	 	#FFF3F3F3��6   
 � Offset$
 0Q�61   � 5      $	 	#FFA0B9FB��6   $
 1Q�61   5       � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5       �� 5!      �� 5"      $	��100 �6#   .+�5$      � $��0��6    5%      �� 5&      $��* �6$   �� 5'      $��* �6$   �� 5(      $��* �6$   .+�5*      ��  �� Orientation$ 
Horizontal=�6   $��0��66   .+�5+      �� $��Tên sản phẩm��6   $��80��63   $
��Left=�6>   $��Center=�6Y   $��5 0 0 0q�6t   �� 5,      -   5        $��txtTenSP��5,         Textbox1#���   6.   $	��485��6Q   $��26��6]   $��5 0 0 0q�6i   $
��Left=�6z   $��Center=�6�   $��12(�6�   5-      �� 5.      $ 
Horizontal=�6   $��1��66   .+�5/      �� -   5        $��cboMaSP_AndOr��5/       �� SelectedIndex$ 0��64    �� SelectedValuePath$ Value��6F    �� DisplayMemberPath$
 Name��6`   $
��Left=�6y   $��Center=�6�   $��60��6�   $��10 0 0 0q�6�   �� 50      $��Mã sản phẩm��6   $��Center=�62   �� 51      -   5        $��txtMaSP��51      #���   6-   $	��100��6P   $��26��6\   $��5 0 0 0q�6h   $
��Left=�6y   $��Center=�6�   $��12(�6�   �� 52      -   5        $��cboNSP_AndOr��52      $ 0��63   $ Value��6E   $
 Name��6_   $��60��6x   $��20 0 0 0q�6�   $��Center=�6�   �� 53      $��Nhóm sản phẩm��6   $	��100��64   $
��Left=�6@   $��Center=�6[   �� 54      -   5        $��	cboNhomSP��54      $ 	MaNSP_NSP��60   $ 
TenNSP_NSP��6N   $ 0��6m   $��26��6   $	��140��6�   $
��Left=�6�   $��Center=�6�   55      �� 56      $ 
Horizontal=�6   $��2��66   .+�57      �� -   5        $��cboNgayTao_AndOr��57      $ 0��67   $ Value��6I   $
 Name��6c   $
��Left=�6|   $��Center=�6�   $��60��6�   $��10 0 0 0q�6�   �� 58      $��Ngày tạo��6   $��80��6/   $
��Left=�6:   $��Center=�6U   (  "System.Windows.Controls.DatePicker  59      -   5        $��dtTuNgay��59   !   $	��150��5:   !   $��26��6-   $��5 0 0 0q�69   $
��Left=�6J   $��Center=�6e   $��12(�6�   �� 5;      $��Đến��6   $
��Left=�6*   $��Center=�6E     5<      -	   5        $��	dtDenNgay��5<   !   $	��150��62   $��26��6>   $��5 0 0 0q�6J   $
��Left=�6[   $��Center=�6v   $��12(�6�   �� 5=      -
   5        $��btnReset��5=        MetroButtonYellowGreen#���  6D   $��Center=�6u   $��70��6�   $��26��6�   
��� ���$��15 0 0 0q�6�   
������ .��5>      �� $ 
Horizontal=�6%   $��Right=�6>   .+�5?      �� $��../Image/View-reset.png��6$   �� 5@      $��Reset��6$   
�������$��10(�6G   5A      5B      5C      5D      �� 5E      -   5        $��btnTim��5E   %   $��1��6     MetroButtonTeal#���  63   $��Stretch=�6r   $��Stretch=�6�   .��5F      �� $��0 10 0 3q�6   .+�5G      �� $��../Image/makefg.png��6   $��Uniform=�69   $��Center=�6K   $��Center=�6h   $��60��6�   �� 5H      $��Tìm kiếm��6   
�������$
��Bold"�6C   5I      5J      5K      � 5N   
   $��1��6   .+�5O      &   System.Windows.Controls.DataGrid  -   5        $
��dgSP��5O        Datagrid#���  6#      SelectionMode$ Extended=�6F      
IsReadOnly .    Columns 5Q      0  *System.Windows.Controls.DataGridTextColumn  5T      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6)      Header$ Mã sản phẩm��64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *	MaSP_SP+   ElementStyle 5U      �� 5V       �� 
TargetType" ��6$   .�5W   "   ��  �� Property � �� �� Value$ Center=�6H   �� 5X   "    � ��$ Center=�6F   5Y      5[        5^      $ 2* 6)   $ Tên sản phẩm��64    6J   �� *
TenSP_SP+ 5_      �� 5`      " ��6$   .�5a   "   ��  � ��$
 Left=�6H   �� 5b   "    � ��$ Center=�6F   5c      5e      5g      5h      �� 5j   
   $ 
Horizontal=�6   $��2��6.   .+�5k      �� -   5        $��lbTongBanGhi��5k      $��Kết quả��6(   
����  �$��Center=�6L   �� 5l      -   5        $��	lbWarning��5l      $��Warning!��6%   $��Center=�68   
���  ��6S   5m      �� 5o   
   $ 
Horizontal=�6   $��2��6.   $��Center=�6;   .+�5p      �� -   5        $��btnChon��5p      $��Chọn��6:   #���  6I   
�������$��Center=�6�   $��30��6�   $
��Bold"�6�   $��50��6�   $��0 0 5 0q�6�   �� 5q      -   5        $��btnHuy��5q      $��Hủy��68   $��Center=�6F   #���  6a   
�������$
��Bold"�6�   $��30��6�   $��50��6�   $��0 0 5 0q�6�   5r      �� 5t   
   -   5        $��
bdProgress��5t      $��1��6   $��Center=�60   $��Center=�6M   ���	#FF5EACE2$��2q�6�    �� CornerRadius$ 0��6�   ���	#E6FBFAFA._�5u      �� -   5         ��Name$ 
spProgress��5u      $��Center=�6-   $��Center=�6J   $��5q�6e   .+�5v      �� -   5         ��Name$ 
lbProgress��5v      $,��&Đang xử lý. Vui lòng đợi . . .��6,   $��Italic$�6U   $
��Bold"�6h   ���	#FF3FA8E46z   � 5w      -   5         �Name$ pbTienTrinh��5w      $	��200��63    � IsIndeterminate . $��20��6V   ���	#FF5788F16b   5x      5y      5z      5{      