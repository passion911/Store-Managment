   M S B A M L   `   `   `  ����  Presentation9    3Presentation.WindowWpf.SuaGiaSpTheoNhomPresentation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$:  4Sửa giá bán sản phẩm theo nhóm sản phẩm��5   	   $	��220��69   $	��300��6F    � WindowStartupLocation$ CenterScreen=�6R    � 
ResizeMode$ NoResize=�6w    � Icon$6 0/Presentation;component/Image/Icon/fl-suagia.png��6�    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5	      �� 5
      $ ../Style/UserControl.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   �� 5      $ ../Style/Label.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��* �6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"   	 �� 
StartPoint$	 0.5,0&�63   .��5      � 
 � Color$
 	#FFF3F3F3��6    � Offset$ 0Q�61   � 5      $
 	#FFA0B9FB��6   $ 1Q�61   5      .+�5"   
   �� -   5        $��lbTenNhomSanPham��5"      $��30(�6(   $��Nhóm sản phẩm 1��66   
�������$
��Bold"�6b   $��Center=�6t   $
��Left=�6�   $��10 0 0 0q�6�    � ToolTip$ Nhóm sản phẩm��6�   �� 5$   
   $��1��6   
�������$��0 1 0 1q�61   ._�5%      �� $��Center=�6   .+�5&      ��  �� Orientation$ 
Horizontal=�6   $��	10 10 0 0q�66   .+�5'      �� -   5        $��	txtSuaGia��5'      $��Right=�6Y   $��20(�6�      Textbox1#���   6�   $	��150��6�   $
��Left=�6�   �� 5(      -   5        $��lbvnd��5(      $��.VNĐ��6)   $��Center=�68   $��20(�6S   5)      5*      5+      �� 5-   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   $	��Top=�6X   .+�5.      �� -   5        $��	btnSuaGia��5.        MetroButtonYellowGreen#���  6>   $��5 0 0 0q�6o   $��40��6�   $��5q�6�   .��5/      �� $ 
Horizontal=�6   .+�50      �� $!��../Image/Icon/fl-suagia.png��6   $��Uniform=�6A   �� 51      $��
Sửa giá��6   $( "Sửa giá theo nhóm sản phẩm��6.   
�������$��Center=�6f   $
��Bold"�6�   52      53      �� 55      -   5        $��btnHuy��55      #���  68   $��5 0 0 0q�6i   $��40��6z   $��5q�6�   .��56      �� $ 
Horizontal=�6   .+�57      �� $!��../Image/Icon/fl-cancel.png��6   $��Uniform=�6A   �� 58      $��hủy��6   $( "Sửa giá theo nhóm sản phẩm��6*   
�������$��Center=�6b   $
��Bold"�6}   59      5:      5;      �� 5=   
   -   5        $��	lbWarning��5=      $y�Hidden=�6!     LabelWarning#���  65   $��2��6\   $��15(�6i   $��warning��6w   $
��Left=�6�   $��Bottom=�6�   5>      5?      