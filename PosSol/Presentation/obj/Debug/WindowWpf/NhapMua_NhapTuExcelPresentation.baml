   M S B A M L   `   `   `  ����  Presentation<    6Presentation.WindowWpf.NhapMua_NhapTuExcelPresentation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Nhập từ Excel��5   	   $	��150��6   $	��400��6,    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�6    � Icon$5 //Presentation;component/Image/Icon/fl-excel.png��6D   .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5	      �  � Color$ 	#FFF3F3F3��6    � Offset$ 0Q�61   � 5
      $ 	#FFA0B9FB��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��40 �6   �� 5      $��40 �6   .+�5   
   �� $��0��6   $��Chọn file Excel��6   $
��Left=�67   $��Center=�6R   $��5 0 0 0q�6m   $��0q�6~   
�������$��Italic$�6�   �� 5   
   $��1��6   	 �� Orientation$	 
Horizontal=�6"   $��5 0 5 0q�6;   $��Right=�6L   .+�5      �� -   5        $��txtDuongDan��5      {�.  $
��Left=�6;   $��Center=�6V   $	��330��6q   $��30��6}   $��5 0 5 0q�6�   �� 5      -   5        $��btnChonFileExcel��5      $��30��6L   $��Center=�6X   $��30��6s   
����+��
������ .��5      �� .+�5      �� $*��$../Image/Icon/fl-selectExcelFile.png��6   $��Uniform=�6J   $��2q�6\   5      5      5      �� 5   
   $��2��6   $��Lấy File mẫu��6   $��5 0 0 0q�64   
����  �$��Center=�6W   $��Italic$�6r   $
��Bold"�6�   �� 5   
   $	 
Horizontal=�6   $��2��6.   $��Right=�6;   $��Center=�6W   $�� 0 0 5 0q�6r   .+�5      �� -   5        $��btnOk��5      $��80��66   $��30��6A   
��� � �
������ .��5      �� $	 
Horizontal=�6   .+�5      �� $ ��../Image/Icon/fl-check.png��6   $��Uniform=�6@   $��30��6R   $��3q�6]   �� 5       $��Chọn��6   $��Center=�6+   
�������$��13(�6Y   $
��Bold"�6g   $��0q�6y   5!      5"      �� 5#      -   5        $��btnHuy��5#      $��70��68   $��30��6C   
���i��
������ .��5$      �� $	 
Horizontal=�6   $��Center=�66   .+�5%      �� $!��../Image/Icon/fl-cancel.png��6   $��Uniform=�6A   $��30��6S   $��3q�6^   �� 5&      $��Hủy��6   $��Center=�6*   
�������$��13(�6X   $
��Bold"�6f   $��0q�6x   5'      5(      5)      5*      5+      