   M S B A M L   `   `   `  ����  Presentation3    -Presentation.UserControls.KiemKeUPresentation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5           UserControl#���   5   H     � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5	      �� 5
      $ ../Style/UserControl.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   �� 5      $ ../Style/Label.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF3F3F3��6    � Offset$ 0Q�61   � 5      $ 	#FFA0B9FB��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      �� 5      $��50 �6   .+�5"   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��80��6;   .+�5#      �� $��Center=�6   .+�5$      �� $��Chọn nhóm sản phẩm��6   $
��Left=�65   $	��Top=�6P   
�������$��Italic$�6{   $��2 0 0 5q�6�   �� 5%      -   5        $��	cboNhomSP��5%      	 �� DisplayMemberPath$	 
TenNSP_NSP��6[   
 �� SelectedValuePath$
 	MaNSP_NSP��6z    �� SelectedIndex$ 0��6�   $��25(�6�   $	��250��6�   $��20 0 0 0q�6�   5&      �� 5(      $ 
Horizontal=�6   $��Center=�62   .+�5)      �� .+�5*      �� $#��Tìm kiếm sản phẩm (F1)��6   $
��Left=�6=   $	��Top=�6X   $��10 0 0 0q�6p   
�������$��Italic$�6�   $��2 0 0 5q�6�   �� 5+      -   5        $��
txtMaTenSP��5+        Textbox1#���  6�   $
��Left=�6�   $��Center=�6�   $	��200��6�   $��10 0 0 0q�6�   $��25(�6�   5,      �� 5.      -   5        $��
btnTimKiem��5.        MetroButtonTomato#���  6D   $��5 20 0 0q�6p   $��40��6�   $��5q�6�   .��5/      �� $ 
Horizontal=�6!   .+�50      �� $!��../Image/Icon/fl-search.png��6    $��Uniform=�6E   51      52      �� 54      -   5        $��	lbWarning��54        LabelWarning#���  6)   $��Warning!��6P   $��10 0 0 0q�6c   $��Bottom=�6u   55      56      �� 58   
   -   5        $��btnReset��58        MetroButtonTran#���  68   $��5 0 5 10q�6b   $��Right=�6t   $��Bottom=�6�   $��30��6�   $��1q�6�   .��59      �� $ 
Horizontal=�6   .+�5:      �� $ ��../Image/Icon/fl-reset.png��6   $��5q�6<   5;      5<      &   System.Windows.Controls.DataGrid  5>   
   -   5          Name$ dgDsSanPham��5>       $��1��6     Datagrid#���  65      Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6%      Header$	 Mã��60   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *	MaSP_SP+   ElementStyle 5C      �� 5D       �� 
TargetType" ��6    .�5E      ��  �� Property � �� �� Value$ Center=�6D   �� 5F       � ��$ Center=�6B   5G      5I        5L      $ 3* 6%   $ Tên sản phẩm��60    6F   �� *
TenSP_SP+ 5M      �� 5N      " ��6    .�5O      ��  � ��$
 Left=�6D   �� 5P       � ��$ Center=�6B   �� 5Q       � ��$ 2 0 0 0q�67   5R      5T        5W      $ 3* 6%   $ Nhóm sản phẩm��60    6G   �� *NSP_SP.TenNSP_NSP+ 5X      �� 5Y      " ��6    .�5Z      ��  � ��$
 Left=�6D   �� 5[       � ��$ Center=�6B   �� 5\       � ��$ 2 0 0 0q�67   5]      5_        5b         
IsReadOnly .  $	 100 68   $ SL��6D    6P   �� *
SoLuong_SP+ 5c      �� 5d      " ��6    .�5e      ��  � ��$ Center=�6D   �� 5f       � ��$ Center=�6B   5g      5i      4  .System.Windows.Controls.DataGridTemplateColumn  5l      $ 50 6)   $ Sửa��64      CellTemplate 5m      �� 5n      .R�5o      �� $��btnSua��6%   -   5          MetroButtonOrange#���  5o   3   .��5p   "   �� .+�5q   &   �� $��../Image/Icon/fl-edit.png��6,   $��Uniform=�6O   $��20��6a   $��2q�6l   5r   #   5s      5t      5v      5y      �� 5{   
   $��2��6   $��	 0 0 10 0q�6"   $��Right=�65   $��Center=�6Q   .+�5|      �� -	   5        $��btnIn��5|        MetroButtonYellowGreen#���  66   $��40��6g   $��Right=�6s   $��5 0 10 0q�6�   .��5}      �� $ 
Horizontal=�6   .+�5~      �� $"��../Image/Icon/fl-printer.png��6   $��Uniform=�6B   $��5q�6T   �� 5      $��In��6   $��15(�6)   
�������$
��Bold"�6J   $��Center=�6\   5�      5�      5�      �� 5�   
   $ 
Horizontal=�6   $��2��6.   $
��Left=�6;   $��Center=�6V   .+�5�      �� $��Số mặt hàng:��6   $��15(�6+   
�������69   �� 5�      -
   5        $��lbSoMatHang��5�      $��0��6'   $��15(�63   
��� � �$
��Bold"�6T   �� 5�      $��Tổng số sản phẩm:��6   $��15(�60   
�������$��30 0 0 0q�6P   �� 5�      -   5        $��
lbTongSoSP��5�      $��0��6&   $��15(�62   
��� � �$
��Bold"�6S   5�      �� 5�   
   -   5        $��
bdProgress��5�      $��1��6   $��Center=�60   $��Center=�6M   ���	#FF5788F1$��2q�6�    �� CornerRadius$ 0��6�   ���	#E6FBFAFA._�5�      �� -   5         ��Name$ 
spProgress��5�      $��Center=�6-   $��Center=�6J   $��5q�6e   .+�5�      �� -   5         ��Name$ 
lbProgress��5�      $��0q�6,   $F��@Hệ thống đang xử lý. Vui lòng chờ trong giây lát...��68   $��Normal"�6w   ���	#FF5788F16�   � 5�      -   5         �Name$ pbTienTrinh��5�      $	��300��63    � IsIndeterminate . $��20��6V   ���	#FF5788F16b   5�      5�      5�      5�      