   M S B A M L   `   `   `  ����  Presentation9    3Presentation.UserControls.PhieuNhapKhoUPresentation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5           UserControl#���   5   H     � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5	      �� 5
      $ ../Style/UserControl.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   �� 5      $ ../Style/Label.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF3F3F3��6    � Offset$ 0Q�61   � 5      $ 	#FFA0B9FB��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5!   
   ��  �� Orientation$ 
Horizontal=�6   $��10 0 0 0q�6.   .+�5"      �� $
��Từ��6     lbControlLeft#���  6!   $��20(�6I   $��30��6W   $��	10 0 10 0q�6b   (  "System.Windows.Controls.DatePicker  5#      -   5        $��
dateTuNgay��5#      $��Center=�6+   $��15(�6F   
��� � �$	��150��6g   	   DisplayDateEnd$	 1/1/2099X�6s   
   DisplayDateStart$
 1/1/2010X�6�   �� 5$      $��đến��6   #���  6"   $��20(�6J   $��35��6X   $��	10 0 10 0q�6c     5%      -   5        $��dateDenNgay��5%      $��Center=�6,   $��15(�6G   
��� � �$	��150��6h   $	 1/1/2099X�6t   $
 1/1/2010X�6�   �� 5&      -   5        $��btnXem��5&        MetroButtonTomato#���  68   $��5 0 0 0q�6d   $��35��6u   $��1q�6�   .��5'      �� $ 
Horizontal=�6   .+�5(      �� $	��Xem��6   
�������$��Center=�6=   $
��Bold"�6X   5)      5*      5+      �� 5,   
   -   5        $��btnReset��5,        MetroButtonTeal#���  68   $��5 0 0 0q�6b   $��Right=�6s   $��Center=�6�   $��30��6�   $��1q�6�   .��5-      �� $ 
Horizontal=�6   .+�5.      �� $ ��../Image/Icon/fl-reset.png��6   $��5q�6<   5/      50      �� 52   
   -   5        $��lbStatus��52      $��1��6   $��Danh sách phiếu nhập��6-   
�������$��Italic$�6_   $��15(�6r   &   System.Windows.Controls.DataGrid  54   
   -   5        $��dgDsPhieuNhap��54   2   $��1��6   $��0 30 0 0q�6      Datagrid#���  6G      
IsReadOnly .    Columns 55      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6%      Header$ Số phiếu nhập��60   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *
SoPhieu_PN+   ElementStyle 59      �� 5:       �� 
TargetType" ��6    .�5;      ��  �� Property � �� �� Value$ Center=�6D   �� 5<       � ��$ Center=�6B   5=      5?        5B      $ 1* 6%   $ Ngày nhập��60    6C   �� *NgayNhap_PN+ �� StringFormat$ 
dd-MM-yyyy�� 5C      �� 5D      " ��6    .�5E      ��  � ��$ Center=�6D   �� 5F       � ��$ Center=�6B   5G      5I        5L      $ 1* 6%   $ Mã nhân viên��60    6F   �� *NguoiNhap_PN.MaNV_NV+ 5M      �� 5N      " ��6    .�5O      ��  � ��$ Center=�6D   �� 5P       � ��$ Center=�6B   �� 5Q       �@�ToolTip 68   �� *NguoiNhap_PN.HoTen_NV+5R      5T        5W      $ 1* 6%   $ Ghi chú��60    6A   �� *	GhiChu_PN+ 5X      �� 5Y      " ��6    .�5Z      ��  � ��$
 Left=�6D   �� 5[       � ��$ 5 0 0 0q�67   �� 5\       � ��$ Center=�6B   5]      5_      4  .System.Windows.Controls.DataGridTemplateColumn  5b      $ 70 6)   $ 
Chi tiết��64      CellTemplate 5c      �� 5d      .R�5e      �� $��btnXemChiTiet��6%   -   5          MetroButtonOlive#���  5e   V   $��30��6�   $��2q�6�   .��5f   "   �� .+�5g   &   �� $!��../Image/Icon/fl-detail.png��6,   $��20��6Q   $��Uniform=�6]   5h   #   5i      5j      5l      5|      �� 5}   
   -	   5        $��
bdProgress��5}      $��1��6   $y�	Collapsed=�60   $��Center=�6G   $��Center=�6d   ���	#FF5788F1$��2q�6�    �� CornerRadius$ 0��6�   ���	#E6FBFAFA._�5~      �� -
   5         ��Name$ 
spProgress��5~      $��Center=�6-   $��Center=�6J   $��5q�6e   .+�5      �� -   5         ��Name$ 
lbProgress��5      $��Đang xử lý...��6,   $
��Bold"�6E   ���	#FF5788F16W   � 5�      -   5         �Name$ pbTienTrinh��5�      $	��200��63    � IsIndeterminate . $��20��6V   ���	#FF5788F16b   5�      5�      5�      5�      