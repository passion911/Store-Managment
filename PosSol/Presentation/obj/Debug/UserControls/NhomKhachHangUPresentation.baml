   M S B A M L   `   `   `  ����  Presentation:    4Presentation.UserControls.NhomKhachHangUPresentation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5           UserControl#���   5        � 	Resources  5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $ ../Style/UserControl.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF3F3F3��6    � Offset$ 0Q�61   � 5      $ 	#FFA0B9FB��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5       $��50 �6   .+�5$   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��50��6;   $��5 0 0 5q�6G   .+�5%      �� -   5        $��
txtTimKiem��5%        Textbox1#���  6(   $��25(�6K   $	��200��6Y   �� 5&      -   5        $��
btnTimKiem��5&        MetroButtonDarkGreen#���  6'   $��5 0 0 0q�6V   $��40��6g   $��5q�6s   .��5'      �� $ 
Horizontal=�6   .+�5(      �� $!��../Image/Icon/fl-search.png��6   $��Uniform=�6A   5)      5*      5,      &   System.Windows.Controls.DataGrid  5/   
   -   5        	  Name$	 dgNhomKhachHang��5/       $��1��6     Datagrid#���  6b   
   
IsReadOnly
 .    RowDetailsVisibilityMode$ 	Collapsed=�50       �� SelectedItem 5/   9   �� *sl+ �� Mode$ OneWay=�   Columns 52      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6%      Header$ Mã NHK��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *	MaNKH_NKH+   ElementStyle 56      �� 57       �� 
TargetType" ��6    .�58      ��  �� Property � �� �� Value$ Center=�6D   �� 59       � ��$ Center=�6B   5:      5<        5?      $ 2* 6%   $ Tên NKH��60    6A   �� *
TenNKH_NKH+ 5@      �� 5A      " ��6    .�5B      ��  � ��$
 Left=�6D   �� 5C       � ��$ 10 0 0 0q�67   �� 5D       � ��$ Center=�6B   5E      5G        5J      $ 1* 6%   $ Chiết khấu (%)��60    6H   �� *ChietKhau_NKH+ 5K      �� 5L      " ��6    .�5M      ��  � ��$ Center=�6D   �� 5N       � ��$ Center=�6B   5O      5Q        5T      $ 1* 6%   $ Điểm cần��60    6B   �� *
Diem_NKH+ 5U      �� 5V      " ��6    .�5W      ��  � ��$ Center=�6D   �� 5X       � ��$ Center=�6B   5Y      5[      4  .System.Windows.Controls.DataGridTemplateColumn  5^      $ 1* 6)   $ Ảnh đại diện��64      CellTemplate 5_      �� 5`      .R�5a      �� $
��None=�6?   ��6$   �� *	Anh_NKH+6?   5b      5d        5g      $ 1* 6)   $ Đang dùng��64    5h      �� 5i      .R�5j      �� $��Center=�6J   $��Center=�6g    J� IsHitTestVisible .   d� 	IsChecked 6'   �� *DangDung_NKH+6�   5k      5m        5p      $ 50 6)   $ Sửa��64    5q      �� 5r      .R�5s      �� $��btnSua��6%   -   5          MetroButtonYellowGreen#���  5s   3   $��30��6y   $��2q�6�   .��5t   "   �� .+�5u   &   �� $��../Image/Icon/fl-edit.png��6-   $��Uniform=�6P   $��20��6b   5v   #   5w      5x      5z        5}      $ 50 6)   $
 Xóa��64    5~      �� 5      .R�5�      �� $��btnXoa��6%   -   5          MetroButtonOrange#���  5�   H   $��30��6t   $��2q�6�   .��5�   "   �� .+�5�   &   �� $!��../Image/Icon/fl-delete.png��6,   $��20��6Q   $��Uniform=�6]   5�   #   5�      5�      5�      5�      �� 5�   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   $��0 0 5 0q�6W   .+�5�      �� -   5        $��
btnThemMoi��5�        MetroButtonTomato#���  6@   $��5 0 0 0q�6l   $��40��6}   $��5q�6�   .��5�      �� $ 
Horizontal=�6   .+�5�      �� $&�� ../Image/Icon/fl-addDocument.png��6   $��Uniform=�6F   �� 5�      $��Thêm��6   
�������$��Center=�6>   $
��Bold"�6Y   5�      5�      �� 5�      -   5        $��btnDong��5�        MetroButtonTeal#���  6:   $��5 0 0 0q�6d   $��40��6u   $��5q�6�   .��5�      �� $ 
Horizontal=�6   .+�5�      �� $!��../Image/Icon/fl-cancel.png��6   $��Uniform=�6A   �� 5�      $��Đóng��6   
�������$��Center=�6>   $
��Bold"�6Y   5�      5�      5�      5�      5�      