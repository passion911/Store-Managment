   M S B A M L   `   `   `  ����  Presentation9    3Presentation.WindowWpf.SanPhamNhapExcelPresentation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$#  Thêm sản phẩm từ Excel��5   	   $	��170��5   	   $	��368��6    � 
ResizeMode$ NoResize=�5   	   $��16(�6    � WindowStartupLocation$ CenterScreen=�6-    � Icon$5 //Presentation;component/Image/Icon/fl-excel.png��6R    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5	      �� 5
      $ ../Style/Button1.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      � 	 � Color$	 	#FFF3F3F3��6   
 � Offset$
 0Q�61   � 5      $	 	#FFA0B9FB��6   $
 1Q�61   5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   .+�5   
   �� $��0��6   $��Chọn file Excel��6   $
��Left=�67   $��Center=�6R   $��10,0,0,0q�6m   $��Italic$�6   
�������6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   .+�5      �� -   5        $��txtDuongDan��5      $
��Left=�6)   $��Center=�6D   $��10,0,0,0q�6_   $	��300��6q   {�.  6}   �� 5      -   5        $��btnChonDuongDan��5         MetroButtonTeal#���   6J   $	��...��6t   
�������$
��Left=�6�   $��Center=�6�   $��10,0,0,0q�6�   $��30��6�   $��22��6�   5      �� 5    
   $ 
Horizontal=�6   $��Right=�6.   $��Center=�6J   $��2��6e   .+�5!      �� $��Xem file mẫu��6   $
��Left=�6,   $��Center=�6G   $��
10,0,120,0q�6b   
����  �$��Italic$�6�   
������ 
������ 6�   �� 5"      -   5        $��btnOK��5"        MetroButtonYellowGreen#���  6"   
�������$��OK��6{   $��50��6�   $��30��6�   $
��Left=�6�   $��Center=�6�   $��10,0,0,0q�6�   �� 5#      -   5        $��btnHuy��5#      #���  69   
�������$��Hủy��6~   $��50��6�   $��30��6�   $
��Left=�6�   $��Center=�6�   $��	10,0,10,0q�6�   5$      5%      5&      