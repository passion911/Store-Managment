   M S B A M L   `   `   `  ����  Presentation7    1Presentation.WindowWpf.NhaCungCapThemPresentation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$!  Thêm mới nhà cung cấp��5   	    � 
ResizeMode$ NoResize=�6'    � WindowStartupLocation$ CenterScreen=�6=   $	��255��5   	   $	��330��6    � Icon$; 5/Presentation;component/Image/Icon/fl-addDocument.png��6"    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5	      $ ../Style/Textbox.xaml?�6%   �� 5
      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Label.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      � 	 � Color$	 	#FFF3F3F3��6   
 � Offset$
 0Q�61   � 5      $	 	#FFA0B9FB��6   $
 1Q�61   5      .+�5   
   �� $��5q�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0 5 0 0q�63   .+�5      �� $��Mã NCC��6      lbControlLeft#���   6)   $	��100��6Q   $��Center=�6]   �� 5      -   5        $��txtMaNCC��5        Textbox1#���  6*   $��20(�6M   $	��200��6[   $��Center=�6g   5      �� 5      $ 
Horizontal=�6   $��0 5 0 0q�62   .+�5      �� $��Tên NCC��6   #���   6*   $	��100��6R   $��Center=�6^   �� 5      -   5        $��	txtTenNCC��5      #���  6+   $��20(�6N   $	��200��6\   $��Center=�6h   5      �� 5      $ 
Horizontal=�6   $��0 5 0 0q�62   .+�5       �� $��Ghi chú��6   #���   6*   $	��100��6R   $	��Top=�6^   �� 5!      -   5        $��
rtxtGhiChu��5!      $��Center=�60   $	��200��6L   $��60��6X   $��20(�6d   5"      �� 5$      $��10q�6    �� Padding$ 5q�6!   
�������$��0 1 0 1q�6@   ._�5%      �� $ 
Horizontal=�6   $��Center=�66   .+�5&      �� -   5        $��btnLuu��5&        MetroButtonTomato#���  6@   $��5 0 0 0q�6l   $��40��6}   $��5q�6�   .��5'      �� $ 
Horizontal=�6%   .+�5(      �� $��../Image/Icon/fl_save.png��6$   $��Uniform=�6G   �� 5)      $
��Lưu��6$   
�������$��Center=�6E   $
��Bold"�6`   5*      5+      �� 5,      -   5        $��btnHuy��5,        MetroButtonTeal#���  6,   $��5 0 0 0q�6V   $��40��6g   $��5q�6s   .��5-      �� $ 
Horizontal=�6%   .+�5.      �� $!��../Image/Icon/fl-cancel.png��6$   $��Uniform=�6I   �� 5/      $��Hủy��6$   
�������$��Center=�6E   $
��Bold"�6`   50      51      52      53      54      55      56      