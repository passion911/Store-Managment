   M S B A M L   `   `   `  ����  Presentation:    4Presentation.WindowWpf.NhomKhachHangThemPresentation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$$  Thêm mới nhóm khách hàng��5   	   $	��355��6*   $	��330��67    � WindowStartupLocation$ CenterScreen=�6D    � 
ResizeMode$ NoResize=�6i    � Icon$; 5/Presentation;component/Image/Icon/fl-addDocument.png��5        � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5	      $ ../Style/UserControl.xaml?�6%   �� 5
      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   �� 5      $ ../Style/Label.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      � 	 � Color$	 	#FFF3F3F3��6   
 � Offset$
 0Q�61   � 5      $	 	#FFA0B9FB��6   $
 1Q�61   5      .+�5   
   �� $��5 0 0 0q�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0 10 0 0q�62   .+�5      �� $	��Mã��6      lbControlLeft#���   6%   $	��100��6M   $��Bottom=�6Y   �� 5      -   5         ��Name$ txtMaNKH��5        Textbox1#���  6,   $��20(�6O   $	��200��6]   {�.  6j   5      �� 5      $ 
Horizontal=�6   $��0 5 0 0q�62   .+�5       �� $
��Tên��6   #���   6&   $	��100��6N   $��Bottom=�6Z   �� 5!      -   5        $ 	txtTenNKH��5!       �� TextWrapping$
 Wrap=�6-   #���  6A   $��20(�6d   $	��200��6r   5"      �� 5$      $ 
Horizontal=�6   $��0 5 0 0q�62   .+�5%      �� $��Chiết khấu %��6   #���   6/   $	��100��6W   $��Bottom=�6c   �� 5&      -   5        $ txtChietKhau��5&      #���  61   $��20(�6T   $	��200��6b   5'      �� 5)      $ 
Horizontal=�6   $��0 5 0 0q�62   .+�5*      �� $��Điểm��6   #���   6'   $	��100��6O   $��Bottom=�6[   �� 5+      -   5        $ txtDiem��5+      #���  6,   $��20(�6O   $	��200��6]   5,      �� 5.      $ 
Horizontal=�6   $��0 5 0 0q�62   .+�5/      �� $
��Icon��6   #���   6'   $	��100��6O   $	��Top=�6[   �� 50      -   5         ��Name$ cboIcon��50      $��40��6-   $��60��69   $
��Left=�6D    �� SelectedValuePath$ TenAnh��6_    �� SelectedIndex$ 0��6z   
���   ���6�   Z� ��6�   Z� ��51      �� 52      .R�53      �� .+�54   "   �� ��6(   �� *DuongDanAnh+55      56      58      59      �� 5;      $ 
Horizontal=�6   $��0 5 0 0q�62   .+�5<      �� $��Đang dùng��6   #���   6,   $	��100��6T   $��Bottom=�6`   �� 5=      -   5         ��Name$ 
ckDangDung��5=      $��20(�6/   $	��200��6=   $��Center=�6I    d� 	IsChecked$
 TrueY�6d   5>      �� 5@      
�������$��0 1 0 1q�6(   $��0 10 0 0q�6B   ._�5A      �� $ 
Horizontal=�6   $
��Left=�66   $��	100 5 0 5q�6Q   .+�5B      �� -   5        $��btnLuu��5B        MetroButtonTomato#���  6@   $��0 0 0 0q�6l   $��40��6}   $��5q�6�   .��5C      �� $ 
Horizontal=�6%   .+�5D      �� $��../Image/Icon/fl_save.png��6$   $��Uniform=�6G   $��5q�6Y   �� 5E      $��	Lưu (F1)��6$   
�������$��Center=�6J   $��13(�6e   5F      5G      �� 5H      -	   5        $��btnHuy��5H        MetroButtonTeal#���  6@   $��5 0 0 0q�6j   $��40��6{   $��5q�6�   .��5I      �� $ 
Horizontal=�6%   .+�5J      �� $!��../Image/Icon/fl-cancel.png��6$   $��Uniform=�6I   $��5q�6[   �� 5K      $��Hủy (Esc)��6$   
�������$��Center=�6K   $��13(�6f   5L      5M      5N      5O      �� 5Q      -
   5        $��	lbWarning��5Q      $��Warning!��6%     LabelWarning#���  68   $��12(�6_   5R      5S      5T      