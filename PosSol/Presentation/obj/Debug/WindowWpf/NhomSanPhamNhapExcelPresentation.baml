   M S B A M L   `   `   `  ����  Presentation=    7Presentation.WindowWpf.NhomSanPhamNhapExcelPresentation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$*  $Nhập nhóm sản phầm từ Excel��5   	   $	��180��5   	   $	��350��6    � WindowStartupLocation$ CenterScreen=�6"    � 
ResizeMode$ NoResize=�6G    � Icon$5 //Presentation;component/Image/Icon/fl-excel.png��6]    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5	      $ ../Style/Textbox.xaml?�6%   �� 5
      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Label.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      � 	 � Color$	 	#FFF3F3F3��6   
 � Offset$
 0Q�61   � 5      $	 	#FFA0B9FB��6   $
 1Q�61   5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      .+�5   
   �� $��0��6   $��Chọn file Excel��6      lbControlLeft#���   67   $
��Bold"�6_   $
��Left=�6q   $��Center=�6�   $��5 5 0 0q�6�   
�������6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   .+�5      �� -   5         ��Name$ txtDuongDan��5      $��1��6,     Textbox1#���  69   $��20(�6\   $
��Left=�6j   $��5 0 0 0q�6�   $��Center=�6�   $	��265��6�   {�.  6�   �� 5      -   5         ��Name$ btnChonFile��5        MetroButtonOlive#���  6*   
�������$��20(�6h   $��5 2 5 2q�6v   $��1��6�   $	��...��6�   $
��Left=�6�   $��10 0 0 0q�6�   $��Center=�6�   $��30��6�   6�   5       �� 5!   
   $��2��6   $ 
Horizontal=�6"   $
��Left=�6;   $��5 0 0 10q�6V   .+�5"      �� $��Xem file mẫu��6   $
��Left=�6,   $��25��6G   $��0q�6S   $��Center=�6_   
������ 
������ $��94��6�   ���	#FF0250D8$��14.667(�6�   $��Italic$�6�   �� 5#      -   5        $��btnNhap��5#        MetroButtonTomato#���  6;   $��40��6g   $��5q�6s   $��50 0 0 0q�6   .��5$      �� $ 
Horizontal=�6   .+�5%      �� $��../Image/Icon/fl_save.png��6   $��Uniform=�6?   �� 5&      $
��Lưu��6   
�������$��Center=�6=   $
��Bold"�6X   5'      5(      �� 5*      -   5        $��btnHuy��5*        MetroButtonTeal#���  68   $��5 0 0 0q�6b   $��40��6s   $��5q�6   .��5+      �� $ 
Horizontal=�6   .+�5,      �� $!��../Image/Icon/fl-cancel.png��6   $��Uniform=�6A   �� 5-      $��Hủy��6   
�������$��Center=�6=   $
��Bold"�6X   5.      5/      50      51      52      