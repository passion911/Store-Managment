   M S B A M L   `   `   `  ����  Presentation9    3Presentation.WindowWpf.ChiTietPhieuNhapPresentation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Chi tiết phiếu nhập��5   	   $	��500��6%   $	��750��62    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.    � Icon$6 0/Presentation;component/Image/Icon/fl-detail.png��6[    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5	      $ ../Style/Textbox.xaml?�6%   �� 5
      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   �� 5      $ ../Style/Label.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      � 	 � Color$	 	#FFF3F3F3��6   
 � Offset$
 0Q�61   � 5      $	 	#FFA0B9FB��6   $
 1Q�61   5       � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� $��0��6   .+�5       ��  �� Orientation$ 
Horizontal=�6   $��0 3 0 0q�62   .+�5!      �� $��Số phiếu:��6      lbControlLeft#���   6,   $��70��6T   $��5 0 0 0q�6_   �� 5"      -   5        $��	lbSoPhieu��5"      $��Center=�6)   $��15(�6D   $��PN.0000000001��6R   $	��150��6j   
��� � �$
��Bold"�6�   �� 5#      $��Ngày nhập:��6   #���   6-   $��80��6U   �� 5$      -   5        $��
lbNgayNhap��5$      $��Center=�6*   $��15(�6E   $��
10/01/2015��6S   $	��150��6h   
��� � �$
��Bold"�6�   �� 5%      $��Người nhập:��6   #���   6.   $��80��6V   �� 5&      -   5        $��lbNguoiNhap��5&      $��Center=�6+   $��15(�6F   $��NV.009��6T   
��� � �$
��Bold"�6x   5'      �� 5(      -   5        $��lbGhiChu��5(      #���   6$   $��15(�6L   5)      &   System.Windows.Controls.DataGrid  5+   
   -   5        $��dgDsHangNhap��5+       $��1��6     Datagrid#���  64      
IsReadOnly .    Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6%      Header$ Mã SP��60   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *	MaSP_SP+   ElementStyle 50      �� 51       �� 
TargetType" ��6    .�52      ��  �� Property � �� �� Value$ Center=�6D   �� 53       � ��$ Center=�6B   54      56        59      $ 3* 6%   $ Tên sản phẩm��60    6F   �� *
TenSP_SP+ 5:      �� 5;      " ��6    .�5<      ��  � ��$ Center=�6D   �� 5=       � ��$ Center=�6B   5>      5@        5C      $ 1* 6%   $ Số lượng nhập��60    6G   �� *
SoLuong_HN+ 5D      �� 5E      " ��6    .�5F      ��  � ��$ Center=�6D   �� 5G       � ��$ Center=�6B   5H      5J      5M      �� 5O   
   -   5        $��btnDong��5O        MetroButtonTeal#���  66   $��2��6`   $��Center=�6m   $��Center=�6�   $��Đóng��6�   $��20 10 20 10q�6�   
�������$
��Bold"�6�   5P      5Q      