   M S B A M L   `   `   `  ����h  dSAPBusinessObjects.WPF.Viewer, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304tRclr-namespace:SAPBusinessObjects.WPF.Viewer;assembly=SAPBusinessObjects.WPF.ViewerSAPBusinessObjects.WPF.Viewer  5       Presentation6   0Presentation.UserControls.TaoMaVachUPresentation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      amyRclr-namespace:SAPBusinessObjects.WPF.Viewer;assembly=SAPBusinessObjects.WPF.Viewer     5      -   5           UserControl#���   5        � 	Resources  5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $ ../Style/UserControl.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF3F3F3��6    � Offset$ 0Q�61   � 5      $ 	#FFA0B9FB��6   $ 1Q�61   5       � ColumnDefinitions 5   
   �� 5      $	��500 �6   �� 5      .+�5    
   �� $��0��6   .+�5!      �� $"��Nhập mã sản phẩm (F1)��6   $
��Left=�64   $	��Top=�6O   $��	20 20 0 0q�6g   
�������$��Italic$�6�   $��2 0 0 5q�6�   �� 5"       �� Orientation$ 
Horizontal=�6   .+�5#      �� -   5        $��txtMaSP��5#        Textbox1#���  6)   $
��Left=�6�   $��Center=�6�   $	��200��6�   $��20 0 0 0q�6�   $��25(�6�   �� 5$      -   5        $��	btnThemSP��5$        MetroButtonMaroon#���  6B   $��5 0 0 0q�6n   $��40��6   $��5q�6�   .��5%      �� $ 
Horizontal=�6!   .+�5&      �� $&�� ../Image/Icon/fl-addDocument.png��6    $��Uniform=�6J   �� 5'      $��Thêm��6    
�������$��Center=�6B   $
��Bold"�6]   5(      5)      �� 5*      -   5        $��
btnTimKiem��5*        MetroButtonDarkGreen#���  6+   $��5 0 0 0q�6Z   $��40��6k   $��5q�6w   .��5+      �� $ 
Horizontal=�6!   .+�5,      �� $!��../Image/Icon/fl-search.png��6    $��Uniform=�6E   5-      5.      5/      �� 50      -   5        $��txtbWarning��50      $
��Wrap=�6+   $
��Left=�6?   $	��Top=�6Z   $��20,5,0,0q�6r   
���  ��$��Italic$�6�   $
��auto��6�   $	��200��6�   �� 51      $'��!Danh sách sản phẩm tạo mã��6   $
��Left=�68   $	��Top=�6S   $��	10 10 0 0q�6k   
�������$��Italic$�6�   $��2 0 0 5q�6�   &   System.Windows.Controls.DataGrid  52      -   5        	  Name$	 dgDsSanPham��52        Datagrid#���  6,   $��	10 2 10 0q�53      $	��400��6+   $	��200��6;   
   Columns
 54      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6)      Header$	 Mã��64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *	MaSP_SP+   ElementStyle 57      �� 58       �� 
TargetType" ��6$   .�59   "   ��  �� Property � �� �� Value$ Center=�6H   �� 5:   "    � ��$ Center=�6F   5;      5=        5@      $ 3* 6)   $ Tên sản phẩm��64    6J   �� *
TenSP_SP+ 5A      �� 5B      " ��6$   .�5C   "   ��  � ��$
 Left=�6H   �� 5D   "    � ��$ 5 0 0 0q�6;   �� 5E   "    �@�ToolTip 6<   �� *
TenSP_SP+�� 5F   "    � ��$ Center=�6F   5G      5I        5L      $ 1* 6)   $ Giá bán lẻ��64    6H   �� *GiaBanLe_SP+ 5M      �� 5N      " ��6$   .�5O   "   ��  � ��$ Center=�6H   �� 5P   "    � ��$ Center=�6F   5Q      5S        5V         
IsReadOnly .  $ 50 6<   $ SL��6G    6S   �� *
SoLuong_SP+ 5W      �� 5X      " ��6$   .�5Y   "   ��  � ��$ Center=�6H   �� 5Z   "    � ��$ Center=�6F   5[      5]      4  .System.Windows.Controls.DataGridTemplateColumn  5`      $ 50 6-   $ Hủy��68      CellTemplate 5a      �� 5b      .R�5c   "   �� $��btnXoa��6)   -   5          ImageButton#���  5c   7   .��5d   &   �� .+�5e   *   �� $ ��../Image/delete-icon16.png��60   $
��None=�6T   5f   '   5g   #   5h      5j      5l      � 5n      -   5        $
��gdSP��5n   <   $��0 10 0 0q�6   $y�	Collapsed=�6%    � RowDefinitions 5o      �� 5p      $��40 �6$   �� 5q      $��50 �6$   �� 5r      $��40 �6$   �� 5s      $��30 �6$   �� 5t      $
��auto �6$   .+�5v      �� $��0��6   $��Stretch=�6*   $��Center=�6H   $ 
Horizontal=�6c   .+�5w      �� $��30��6   $
��Mã:��6(   $
��Left=�66   $
��Left=�6Q   $��Center=�6s   $��0 0 3 0q�6�   $��10(�6�   �� 5x      -	   5        $
��lbMa��5x      $
��Left=�6(   $	��180��6C   $��Center=�6O   $��14(�6k   
���  ��$
��Bold"�6�   5y      �� 5z      $��1��6   $��Stretch=�6*   $��Stretch=�6H   $ 
Horizontal=�6d   .+�5{      �� $��30��6   $��Tên:��6(   $
��Left=�67   $
��Left=�6R   $	��Top=�6t   $��0 0 3 0q�6�   $��10(�6�   �� 5|      -
   5        $��txtbTen��5|       $
��Left=�6/   $
��Wrap=�6J   $	��200��6^   $��50��6j   $	��Top=�6v   $��14(�6�   
��� � �$
��Bold"�6�   5}      �� 5~      $��2��6   $��Stretch=�6*   $��Center=�6H   $ 
Horizontal=�6c   .+�5      �� $��30��6   $��Giá:��6(   $
��Left=�67   $
��Left=�6R   $��Center=�6t   $��0 0 3 0q�6�   $��10(�6�   �� 5�      -   5        $��lbGia��5�      $
��Left=�6)   $	��100��6D   $��Right=�6P   $��Center=�6s   $��14(�6�   
���  ��$
��Bold"�6�   �� 5�      $��.VNĐ��6   5�      �� 5�      $��3��6   $��Stretch=�6*   $��Stretch=�6H   $ 
Horizontal=�6d   .+�5�      �� $��Số lượng tạo��6   $
��Left=�63   $��10 0 0 0q�6N   $��12(�6a   �� 5�      -   5        $��txtSoLuongTao��5�      $��1��63   $
��Left=�6<   $��Center=�6W   $��50��6r   $��10 0 0 0q�6~   �� 5�      $
��Cái��6   $��5 0 0 0q�6*   5�      5�      �� 5�      -   5        $��btnTaoMa��5�      #���  6<   $
��Left=�6h   $	��Top=�6�   $��	10 10 0 0q�6�   $��60��6�   $��5 5 20 5q�6�   .��5�      �� $ 
Horizontal=�6   .+�5�      �� $ ��../Image/Icon/fl-paint.png��6   $��Uniform=�6@   �� 5�      $��Tạo mã (F2)��6   
�������$��Center=�6E   $
��Bold"�6`   5�      5�      5�      �� 5�   
   -   5        $��
bdProgress��5�   !   $��1��6   $��Center=�63   $��Center=�6P   ���	#FF5788F1$��2q�6�    �� CornerRadius$ 0��6�   ���	#E6FBFAFA._�5�      �� -   5         ��Name$ 
spProgress��5�      $��Center=�6-   $��Center=�6J   $��5q�6e   .+�5�      �� -   5         ��Name$ 
lbProgress��5�      $��0q�6,   $F��@Hệ thống đang xử lý. Vui lòng chờ trong giây lát...��68   $��Normal"�6w   ���	#FF5788F16�   � 5�      -   5         �Name$ pbTienTrinh��5�      $	��300��63    � IsIndeterminate . $��20��6V   ���	#FF5788F16b   5�      5�      5�      5�      