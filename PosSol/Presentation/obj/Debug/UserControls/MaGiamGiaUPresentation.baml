   M S B A M L   `   `   `  ����  Presentation6    0Presentation.UserControls.MaGiamGiaUPresentation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5           UserControl#���   5   H     � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5	      �� 5
      $ ../Style/UserControl.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   �� 5      $ ../Style/Label.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF3F3F3��6    � Offset$ 0Q�61   � 5      $ 	#FFA0B9FB��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      �� 5      $��50 �6   .+�5!   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5"      �� 
���2͚�$��0 0 1 1q�6/   $��Center=�6I   $��Center=�6f   	 �� Padding$	 5q�6�   $��70��6�   ._�5#      �� .+�5$      �� $��Chiết khấu��6   
 � ToolTip$
 % / Tổng hóa đơn��61   $��15(�6L   �� 5%      -   5        $��txtChietKhau��5%        Textbox1#���  62   $��15(�6U   $��Normal"�6c   5&      5'      �� 5)      
���2͚�$��0 0 1 1q�6/   $��Center=�6I   $��Center=�6f   $	 5q�6�   $��70��6�   ._�5*      �� .+�5+      �� $��Ngày hết hạn��6   $
 % / Tổng hóa đơn��63   $��15(�6N   (  "System.Windows.Controls.DatePicker  5,      -   5        $��dateNgayHetHan��5,   !   $��14(�67   $��Normal"�6E   5-      5.      �� 50      
���2͚�$��0 0 0 1q�6/   $��Center=�6I   $��Center=�6f   $	 5q�6�   $��70��6�   ._�51      �� .+�52      �� $��Số lượng��6   $
 % / Tổng hóa đơn��6/   $��15(�6J   �� 53      -   5        $��
txtSoLuong��53      #���  60   $��14(�6S   $��Normal"�6a   54      55      �� 57      
���2͚�$��0 0 0 0q�6/   $��Center=�6I   $��Center=�6f   $	 5q�6�   $��70��6�   $��20 0 0 0q�6�   ._�58      �� -   5        $��btnTao��58        MetroButtonTomato#���  6<   $��Tạo��6h   $��Center=�6v   $��Bottom=�6�   $��	10 5 10 5q�6�   $��0 0 0 5q�6�   
�������$
��Bold"�6�   59      5:      �� 5;   
   -   5        $��	lbwarning��5;        LabelWarning#���  6!   $��15(�6H   $��1��6V   $��warning��6c   $��Center=�6u   $	��Top=�6�   &   System.Windows.Controls.DataGrid  5<   
   -   5        $��dgMaGiamGia��5<   3   $��1��6   $��0 30 0 0q�6!     Datagrid#���  6F      
IsReadOnly . $	��550��6{      Columns 5=      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Header$	 Mã��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *
MaGG_MGG+   ElementStyle 5@      �� 5A       �� 
TargetType" ��6    .�5B      ��  �� Property � �� �� Value$ Center=�6D   �� 5C       � ��$ Center=�6B   5D      5F        5H      $ Chiết khấu��6%   $	 150 69    6E   �� *ChietKhau_MGG+ 5I      �� 5J      " ��6    .�5K      ��  � ��$ Center=�6D   �� 5L       � ��$ Center=�6B   5M      5O        5Q      $ Ngày hết hạn��6%   $	 150 6;    6G   �� *NgayHetHan_MGG+ �� StringFormat$ 
dd/MM/yyyy�� 5R      �� 5S      " ��6    .�5T      ��  � ��$ Center=�6D   �� 5U       � ��$ Center=�6B   5V      5X      4  .System.Windows.Controls.DataGridTemplateColumn  5[      $ 50 6)   $
 Xóa��64      CellTemplate 5\      �� 5]      .R�5^      �� $��btnXoa��6%   -   5          MetroButtonYellowGreen#���  5^   H   $��30��6y   $��2q�6�   .��5_   "   �� .+�5`   &   �� $!��../Image/Icon/fl-delete.png��6,   $��20��6Q   $��Uniform=�6]   5a   #   5b      5c      5e      5h      �� 5i   
   -	   5        $��
bdProgress��5i      $��1��6   $��Center=�60   $��Center=�6M   ���	#FF5788F1$��2q�6�    �� CornerRadius$ 0��6�   ���	#E6FBFAFA._�5j      �� -
   5         ��Name$ 
spProgress��5j      $��Center=�6-   $��Center=�6J   $��5q�6e   .+�5k      �� -   5         ��Name$ 
lbProgress��5k      $��Đang xử lý...��6,   $
��Bold"�6D   ���	#FF5788F16V   � 5l      -   5         �Name$ pbTienTrinh��5l      $	��200��63    � IsIndeterminate . $��20��6V   ���	#FF5788F16b   5m      5n      5p      5q      