   M S B A M L   `   `   `  ����  Presentation8    2Presentation.UserControls.NhomSanPhamUPresentation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $��ucNhomSanPham��5         UserControl#���   6A     � 	Resources  5       �� MergedDictionaries �� Source�� 5	   
    5
      �� 5      $ ../Style/UserControl.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF3F3F3��6    � Offset$ 0Q�61   � 5      $ 	#FFA0B9FB��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5#   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��50��6;   $��5 0 0 5q�6G   .+�5$      �� -   5        $��
txtTimKiem��5$        Textbox1#���  6S   $��25(�6v   $	��200��6�   �� 5&      -   5        $��
btnTimKiem��5&        MetroButtonDarkGreen#���  6@   $��5 0 0 0q�6o   $��40��6�   $��5q�6�   .��5'      �� $ 
Horizontal=�6   .+�5(      �� $!��../Image/Icon/fl-search.png��6   $��Uniform=�6A   5)      5*      5,      �� 5.   
   -   5        $��btnReset��5.      	 � ToolTip$<	 6F1 - Cập nhập lại danh sách nhóm sản phẩm.��6!     MetroButtonTeal#���  6m   $��5 0 5 0q�6�   $��Right=�6�   $��Center=�6�   $��30��6�   $��1q�6�   .��5/      �� $ 
Horizontal=�6   .+�50      �� $ ��../Image/Icon/fl-reset.png��6   $��5q�6<   51      52      &   System.Windows.Controls.DataGrid  55   
   -   5        
  Name$
 dgNhomSanPham��55       $��1��6      SelectionMode$ Single=�67     Datagrid#���  56         
IsReadOnly .  �� SelectedItem 55   N   �� *sl+ �� Mode$ OneWay=�   Columns 58      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6%      Header$ 	Mã nhóm��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *	MaNSP_NSP+   ElementStyle 5;      �� 5<       �� 
TargetType" ��6    .�5=      ��  �� Property � �� �� Value$ Center=�6D   �� 5>       � ��$ Center=�6B   5?      5A        5C      $ 1* 6%   $ 
Tên nhóm��60    6B   �� *
TenNSP_NSP+ 5D      �� 5E      " ��6    .�5F      ��  � ��$
 Left=�6D   �� 5G       � ��$ 5 0 0 0q�67   �� 5H       � ��$ Center=�6B   5I      5K        5M      $ 2* 6%   $ Ghi chú��60    6A   �� *
GhiChu_NSP+ 5N      �� 5O      " ��6    .�5P      ��  � ��$
 Left=�6D   �� 5Q       � ��$ Center=�6B   �� 5R       � ��$ 10 0 0 0q�67   5S      5U        5W      $ 1* 6%   $ Ngày tạo��60    6B   �� *NgayTao_NSP+ �� StringFormat$ 
dd-MM-yyyy�� 5X      �� 5Y      " ��6    .�5Z      ��  � ��$ Center=�6D   �� 5[       � ��$ Center=�6B   5\      5^      4  .System.Windows.Controls.DataGridCheckBoxColumn  5`      $	 100 6)   $ Đang dùng��65    6H   �� *DangDung_NSP+ 5a      �� 5b      " ��6    .�5c      ��  � ��$ Center=�6D   �� 5d       � ��$ Center=�6B   5e      5g      4  .System.Windows.Controls.DataGridTemplateColumn  5i      $ 50 6)   $ Sửa��64      CellTemplate 5j      �� 5k      .R�5l      �� $��btnSua��6%   -   5          MetroButtonYellowGreen#���  5l   3   $��30��6y   $��2q�6�   .��5m   "   �� .+�5n   &   �� $��../Image/Icon/fl-edit.png��6-   $��Uniform=�6P   $��20��6b   5o   #   5p      5q      5s        5u      $ 50 6)   $
 Xóa��64    5v      �� 5w      .R�5x      �� $��btnXoa��6%   -   5          MetroButtonOrange#���  5x   H   $��30��6t   $��2q�6�   .��5y   "   �� .+�5z   &   �� $!��../Image/Icon/fl-delete.png��6,   $��20��6Q   $��Uniform=�6]   5{   #   5|      5}      5      5�      �� 5�   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   $��0 0 10 0q�6W   .+�5�      �� -   5        $��btnXuatExcel��5�      #���  6D   $��5 0 0 0q�6p   $��40��6�   $��5q�6�   .��5�      �� $ 
Horizontal=�6   .+�5�      �� $ ��../Image/Icon/fl-excel.png��6   $��Uniform=�6@   �� 5�      $��Xuất Excel��6   
�������$��Center=�6D   $
��Bold"�6_   5�      5�      �� 5�      -	   5        $��btnNhapExcel��5�      #���  6E   $��5 0 0 0q�6o   $��40��6�   $��5q�6�   .��5�      �� $ 
Horizontal=�6   .+�5�      �� $!��../Image/Icon/fl-Import.png��6   $��Uniform=�6A   �� 5�      $��Nhập từ Excel��6   
�������$��Center=�6G   $
��Bold"�6b   5�      5�      �� 5�      -
   5        $��
btnThemMoi��5�      #���  6@   $��5 0 0 0q�6q   $��40��6�   $��5q�6�   .��5�      �� $ 
Horizontal=�6   .+�5�      �� $&�� ../Image/Icon/fl-addDocument.png��6   $��Uniform=�6F   �� 5�      $��Thêm��6   
�������$��Center=�6>   $
��Bold"�6Y   5�      5�      5�      �� 5�   
   -   5        $��
bdProgress��5�      $��1��6   $��Center=�60   $��Center=�6M   ���	#FF5788F1$��2q�6�    �� CornerRadius$ 0��6�   ���	#E6FBFAFA._�5�      �� -   5         ��Name$ 
spProgress��5�      $��Center=�6-   $��Center=�6J   $��5q�6e   .+�5�      �� -   5         ��Name$ 
lbProgress��5�      $��Đang xử lý...��6,   $
��Bold"�6E   ���	#FF5788F16W   � 5�      -   5         �Name$ pbTienTrinh��5�      $	��200��63    � IsIndeterminate . $��20��6V   ���	#FF5788F16b   5�      5�      5�      5�      