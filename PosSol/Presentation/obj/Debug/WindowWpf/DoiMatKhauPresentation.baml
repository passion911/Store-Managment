   M S B A M L   `   `   `  ����  Presentation3    -Presentation.WindowWpf.DoiMatKhauPresentation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Đổi mật khẩu��5   	   $	��240��6   $	��400��6+    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.    � Icon$6 0/Presentation;component/Image/Icon/fl-change.png��6[    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5	      $ ../Style/Textbox.xaml?�6%   �� 5
      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Label.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      � 	 � Color$	 	#FFF3F3F3��6   
 � Offset$
 0Q�61   � 5      $	 	#FFA0B9FB��6   $
 1Q�61   5      .+�5   
   �� $��10 20 10 10 q�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Mật khẩu cũ:��6      lbControlLeft#���   6/   $	��150��6W   G� 5      -   5        $��txtMatKhauCu��5      $��20(�62   $	��200��6@    � ToolTip$ Nhập mật khẩu cũ.��6M   5      �� 5      $ 
Horizontal=�6   $��0 5 0 0q�62   .+�5      �� $��Mật khẩu mới:��6   #���   60   $	��150��6X   G� 5      -   5        $��txtMatKhauMoi��5      $��20(�63   $	��200��6A   $  Nhập mật khẩu mới.��6M   5       �� 5"      $ 
Horizontal=�6   $��0 5 0 0q�62   .+�5#      �� $ ��Nhập lại mật khẩu:��6   #���   65   G� 5$      -   5        $��txtNhapLaiMatKhau��5$      $��20(�67   $	��200��6E   $&  Nhập lại mật khẩu mới.��6Q   5%      �� 5'      $ 
Horizontal=�6   $��
150 10 0 0q�62   .+�5(      �� -   5        $��btnLuu��5(        MetroButtonTeal#���  6<   $��	Lưu (F1)��6f   $��20 10 20 10q�6y   
�������$
��Bold"�6�   �� 5)      -   5        $��btnHuy��5)      #���  6<   $��Hủy (Esc)��6f   $��10 10 10 10q�6z   $��10 0 0 0q�6�   
�������$
��Bold"�6�   5*      �� 5,      -   5        $��	lbWarning��5,      $��Warning��6%     LabelWarning#���  67   $��15(�6^   5.      5/      50      