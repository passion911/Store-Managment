   M S B A M L   `   `   `  ����  Presentation7    1Presentation.UserControls.NhaCungCapUPresentation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $��ucNhaCungCap��5         UserControl#���   6#     � 	Resources  5       �� MergedDictionaries �� Source�� 5	   
    5
      �� 5      $ ../Style/UserControl.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF3F3F3��6    � Offset$ 0Q�61   � 5      $ 	#FFA0B9FB��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5#   
   �� $��0��6   $y�	Collapsed=�6"    �� Orientation$ 
Horizontal=�69   $��50��6R   $��5 0 0 5q�6^   .+�5$      �� -   5        $��
txtTimKiem��5$        Textbox1#���  6(   $��25(�6K   $	��200��6Y   �� 5%      -   5        $��
btnTimKiem��5%        MetroButtonDarkGreen#���  6'   $��5 0 0 0q�6V   $��40��6g   $��5q�6s   .��5&      �� $ 
Horizontal=�6   .+�5'      �� $!��../Image/Icon/fl-search.png��6   $��Uniform=�6A   5(      5)      5*      &   System.Windows.Controls.DataGrid  5-   
   -   5        	  Name$	 dgNhaCungCap��5-   F   $��1��6   
   SelectionMode$
 Single=�6\     Datagrid#���  5.      $��0q�60   $��Stretch=�6;      
IsReadOnly .  �� SelectedItem 5-   s   �� *sl+ �� Mode$ OneWay=�   Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6%      Header$ Mã NCC��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *	MaNCC_NCC+   ElementStyle 52      �� 53       �� 
TargetType" ��6    .�54      ��  �� Property � �� �� Value$
 Left=�6D   �� 55       � ��$ 10 0 0 0q�67   �� 56       � ��$ Center=�6B   57      59        5;      $ 1* 6%   $ Tên NCC��60    6A   �� *
TenNCC_NCC+ 5<      �� 5=      " ��6    .�5>      ��  � ��$
 Left=�6D   �� 5?       � ��$ 10 0 0 0q�67   �� 5@       � ��$ Center=�6B   5A      5C        5D      $ 2* 6%   $ Ghi chú��60    6A   �� *
GhiChu_NCC+ 5E      �� 5F      " ��6    .�5G      ��  � ��$
 Left=�6D   �� 5H       � ��$ 10 0 0 0q�67   �� 5I       � ��$ Center=�6B   5J      5L      4  .System.Windows.Controls.DataGridTemplateColumn  5N      $ 50 6)   $ Sửa��64      CellTemplate 5O      �� 5P      .R�5Q      �� $��btnSua��6%   -   5          MetroButtonYellowGreen#���  5Q   3   $��30��6y   $��2q�6�   .��5R   "   �� .+�5S   &   �� $��../Image/Icon/fl-edit.png��6-   $��Uniform=�6P   $��20��6b   5T   #   5U      5V      5X        5Y      $ 50 6)   $
 Xóa��64    5Z      �� 5[      .R�5\      �� $��btnXoa��6%   -   5          MetroButtonOrange#���  5\   H   $��30��6t   $��2q�6�   .��5]   "   �� .+�5^   &   �� $!��../Image/Icon/fl-delete.png��6,   $��20��6Q   $��Uniform=�6]   5_   #   5`      5a      5c      5f      �� 5i   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   .+�5j      �� -   5        $��btnThem��5j        MetroButtonTomato#���  6:   $��5 0 10 0q�6f   $��40��6x   $��5q�6�   .��5k      �� $ 
Horizontal=�6   .+�5l      �� $&�� ../Image/Icon/fl-addDocument.png��6   $��Uniform=�6F   �� 5m      $��Thêm��6   
�������$��Center=�6>   $
��Bold"�6Y   5n      5o      �� 5p      -   5        $��btnDong��5p      $y�	Collapsed=�6$     MetroButtonTeal#���  6Q   $��5 0 0 0q�6{   $��40��6�   $��5q�6�   .��5q      �� $ 
Horizontal=�6   .+�5r      �� $!��../Image/Icon/fl-cancel.png��6   $��Uniform=�6A   �� 5s      $��Đóng��6   
�������$��Center=�6>   $
��Bold"�6Y   5t      5u      5v      5x      5y      