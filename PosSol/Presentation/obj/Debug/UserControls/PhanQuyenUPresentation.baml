   M S B A M L   `   `   `  ����  Presentation6    0Presentation.UserControls.PhanQuyenUPresentation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5           UserControl#���   5        � 	Resources  5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $ ../Style/UserControl.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   �� 5      $ ../Style/Label.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF3F3F3��6    � Offset$ 0Q�61   � 5      $ 	#FFA0B9FB��6   $ 1Q�61   5       � ColumnDefinitions 5   
   �� 5      $	��330 �6   �� 5      .+�5   
   �� $��10 0 5 0q�6   .+�5       �� $��Danh sách nhóm quyền:��6   
�������$��Bottom=�6F   $��0 2 10 0q�6a   $��0q�6s   $��Italic$�6   �� 5!      -   5        $��	lboxQuyen��5!   &   $��0��6    �� SelectedValuePath$
 ID_Q��67   	 �� SelectedIndex$	 0��6P   $��Stretch=�6�   
 �� SelectionMode$
 Extended=�6�   $
��auto��5"      $��50��6$   $	��300��63   
������ 
���������5#      �� 5$      .R�5%      �  5&      �� 5'   "   $	��200 �63   �� 5(   "   $	��100 �63   .+�5*      �� 
��� � �$��20(�6W   ��6(   �� *
TenQuyen_Q+6W   �� 5+      -   5        $��1��5+   :     MetroButtonTran#���  6J   $��32��6t   $��5q�6   $��Right=�6�   $��Center=�6�   .��5,   "   �� .+�5-   &   �� $!��../Image/Icon/fl-delete.png��6,   5.   #   5/      50      51      53      �� 55       �� Orientation$ 
Horizontal=�6   $��Stretch=�62   $��50��6N   .+�56      �� -   5        $��txtThemQuyen��56        Textbox1#���  6[   $��24(�6~   $	��150��6�   �� 57      -   5        $��btnTaoMa��57        MetroButtonTeal#���  6A   $��10 0 0 0q�6k   $��Center=�6}   $��40��6�   $��5 5 10 5q�6�   .��58      �� $ 
Horizontal=�6!   .+�59      �� $&�� ../Image/Icon/fl-addDocument.png��6    $��Uniform=�6J   5:      5;      5<      �� 5>      -   5        $��	lbWarning��5>      $��Warning!��6)   $
��Wrap=�69   $��Bottom=�6M   
���  ��6h   5?      �� 5A   
   $��1��6   $��10 0 0 0q�6%   .+�5B      �� $ 
Horizontal=�6   $��20��62   $��Stretch=�6>   .+�5C      �� -   5        $��lbChiTietQuyen��5C      $��Chi tiết nhóm quyền:��6.   
�������$��Bottom=�6_   $��0 0 0 0q�6z   $��0q�6�   $��Italic$�6�   5D      &   System.Windows.Controls.DataGrid  5F      -   5          Name$ 
dgChucNang��5F        Datagrid#���  6N   $��0 0 10 0q�6q   $	��500��6�   $
��Left=�6�   $	��560��6�      Columns 5G      0  *System.Windows.Controls.DataGridTextColumn  5I      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 3* 6)      Header$ Tên chức năng��64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   �� *ChucNang.TenChucNang_CN+   ElementStyle 5J      �� 5K       �� 
TargetType" ��6$   .�5L   "   ��  �� Property � �� �� Value$
 Left=�6H   �� 5M   "    � ��$ Center=�6F   �� 5N   "    � ��$ 15(�6=   5O      5Q      4  .System.Windows.Controls.DataGridCheckBoxColumn  5T      $ Được sử dụng��6-   $	 100 6f    6C   �� *DuocSuDung_QCN+6f   5W      �� 5Y      $ 
Horizontal=�6   $
��Left=�62   .+�5Z      �� -	   5        $��
btnCapNhat��5Z        MetroButtonYellowGreen#���  6D   $
��Left=�6u   $��0 10 0 0q�6�   $��Center=�6�   $��30��6�   $	��100��6�   $��5 5 10 5q�6�   .��5[      �� $ 
Horizontal=�6!   .+�5\      �� $!��../Image/Icon/fl-update.png��6    $��Uniform=�6E   �� 5]      $��Cập nhật��6    
�������$��0q�6F   $��5 0 0 0q�6R   5^      5_      �� 5a      -
   5        $��btnReset��5a      #���  6@   $
��Left=�6q   $��	10 10 0 0q�6�   $��Center=�6�   $��30��6�   $��30��6�   $��5q�6�   .��5b      �� $ 
Horizontal=�6!   .+�5c      �� $ ��../Image/Icon/fl-reset.png��6    $��Uniform=�6D   5d      5e      5f      5i      �� 5k   
   -   5        $��
bdProgress��5k   8   $��1��6   $y�	Collapsed=�6!   $��Center=�6J   $��Center=�6g   ���	#FF5788F1$��2q�6�    �� CornerRadius$ 0��6�   ���	#E6FBFAFA._�5l      �� -   5         ��Name$ 
spProgress��5l      $��Center=�6-   $��Center=�6J   $��5q�6e   .+�5m      �� -   5         ��Name$ 
lbProgress��5m      $��0q�6,   $F��@Hệ thống đang xử lý. Vui lòng chờ trong giây lát...��68   $��Normal"�6w   ���	#FF5788F16�   � 5n      -   5         �Name$ pbTienTrinh��5n      $	��300��63    � IsIndeterminate . $��20��6V   ���	#FF5788F16b   5o      5p      5q      5r      