   M S B A M L   `   `   `  ����  Presentation=    7Presentation.WindowWpf.NhapHangTraThanhToanPresentation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$#  Thanh toán trả trả hàng��5   	   $	��470��6)   $	��650��66    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.    � Icon$5 //Presentation;component/Image/Icon/fl-money.png��6[    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5	      $ ../Style/UserControl.xaml?�6%   �� 5
      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   �� 5      $ ../Style/Label.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      � 	 � Color$	 	#FFF3F3F3��6   
 � Offset$
 0Q�61   � 5      $	 	#FFA0B9FB��6   $
 1Q�61   5      .+�5   
   �� $��10q�6   .+�5      �� $��Hàng trả nhập kho ��6   $��Italic$�61   $��12(�6D   
�������6R   &   System.Windows.Controls.DataGrid  5      -   5          Name$ 	dgHangTra��5         Datagrid#���   6*   $	��220��6M      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6)      Header$ Mã SP��65      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   �� *SanPham.MaSP_SP+   ElementStyle 5!      �� 5"       �� 
TargetType" ��6$   .�5#   "   ��  �� Property � �� �� Value$
 Left=�6H   �� 5$   "    � ��$ 5 0 0 0q�6;   �� 5%   "    � ��$ Center=�6F   5&      5(        5+      $ 2* 6)   $ Tên SP��64    .  6D   �� *SanPham.TenSP_SP+ 5,      �� 5-      " ��6$   .�5.   "   ��  � ��$
 Left=�6H   �� 5/   "    � ��$ 5 0 0 0q�6;   �� 50   "    � ��$ Center=�6F   51      53        56      $ 50 6)   $ SL��64    6@   �� *	SoLuong+ 57      �� 58      " ��6$   .�59   "   ��  � ��$ Center=�6H   �� 5:   "    � ��$ Center=�6F    �� Triggers 5;   "   P� 5<   &    P� Property �@=�HasError P� Value . . �5=   *   ��  �@�ToolTip 6D   ��  �� RelativeSource �� *Self+ �� Path$) #(Validation.Errors)[0].ErrorContent�5>   '   5@      5B      5D      �� 5F       �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5G      �� $��Tiền khách đã trả:��6     lbControlLeft#���  65   $��13(�6]   $	��120��6k   �� 5H      -   5        $��lbTienKhachDaTra��5H      $��	1,000,000��60   $��13(�6D   $
��Bold"�6R   $��5 0 0 0q�6d   $	��100��6u   $��Right=�6�   �� 5I      $��.VNĐ��6   $��13(�6'   $
��Bold"�65   5J      �� 5L      $ 
Horizontal=�6   $��Center=�62   .+�5M      �� $��Tiền sau trả hàng:��6   #���  65   $��13(�6]   $	��120��6k   �� 5N      -   5        $��lbTienSauKhiTra��5N      $��	1,000,000��6/   $��13(�6C   $
��Bold"�6Q   $��5 0 0 0q�6c   $	��100��6t   $��Right=�6�   �� 5O      $��.VNĐ��6   $��13(�6'   $
��Bold"�65   5P      �� 5Q      $��Center=�6   .+�5R      �� 
�������$��0 1 0 1q�6,   $��Center=�6F   ._�5S      �� $ 
Horizontal=�6!   $��Center=�6:   .+�5T      �� $��Tiền trả khách:��6    #���  6:   $��13(�6b   $	��120��6p   �� 5U      -   5        $��lbTienTraKhach��5U       $��	1,000,000��66   $��13(�6J   $
��Bold"�6X   $��5 0 0 0q�6j   $	��100��6{   $��Right=�6�   �� 5V      $��.VNĐ��6    $��13(�6/   $
��Bold"�6=   5W      5X      �� 5Y      -   5        $��
ckInHoaDon��5Y      $��In hóa đơn��6-   $��0 3 0 0q�6B    d� 	IsChecked$
 TrueY�6S   5Z      �� 5[      $ 
Horizontal=�6   $��Center=�62   .+�5\      �� -   5        $��btnThanhToan��5\        MetroButtonTomato#���  6H   $��	0 10 10 0q�6t   $��40��6�   $��5q�6�   $��Center=�6�   .��5]      �� $ 
Horizontal=�6!   .+�5^      �� $ ��../Image/Icon/fl-money.png��6    $��Uniform=�6D   �� 5_      $��
Than toán��6    
�������$��Center=�6G   $
��Bold"�6b   5`      5a      �� 5b      -   5        $��btnHuy��5b        MetroButtonTeal#���  6<   $��0 10 0 0q�6f   $��40��6x   $��5q�6�   $��Center=�6�   .��5c      �� $ 
Horizontal=�6!   .+�5d      �� $!��../Image/Icon/fl-cancel.png��6    $��Uniform=�6E   �� 5e      $��Hủy��6    
�������$��Center=�6A   $
��Bold"�6\   5f      5g      5h      5i      5j      5k      