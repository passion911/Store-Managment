   M S B A M L   `   `   `  ����  Presentation8    2Presentation.WindowWpf.KiemKeTimHoaDonPresentation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Tìm hóa đơn��5   	   $	��500��6   $	��700��6*    � Icon$6 0/Presentation;component/Image/Icon/fl-search.png��66    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�6    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5	      $ ../Style/UserControl.xaml?�6%   �� 5
      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   �� 5      $ ../Style/Label.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      $��50 �6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"   	 �� 
StartPoint$	 0.5,0&�63   .��5      � 
 � Color$
 	#FFF3F3F3��6    � Offset$ 0Q�61   � 5      $
 	#FFA0B9FB��6   $ 1Q�61   5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��	10 0 10 0q�6.   $
��Left=�6A   .+�5      �� -   5        $��
txtTimKiem��5         Textbox1#���   6S   $��20(�6v   $��Center=�6�   $	��150��6�    � ToolTip$G ATìm kiếm theo số hóa đơn, nhân viên hoặc khách hàng��6�   $��0 0 10 0q�6�   (  "System.Windows.Controls.DatePicker  5       -   5        $��dateNgayLap��5       $��20(�6,   $��Center=�6:   $	��200��6\   $��Center=�6i   �� 5!      -   5        $��btnTim��5!        MetroButtonOrange#���  68   $��5q�6d   $��5q�6o   $��50��6{   $��Center=�6�   .��5"      �� $��Center=�6   $��Center=�68   .+�5#      �� $6��0/Presentation;component/Image/Icon/fl-search.png��6   $��Uniform=�6W   $��5q�6j   5$      5%      5&      �� 5'   
   -   5        $��btnReset��5'        MetroButtonYellowGreen#���  68   $��5q�6i   $��Right=�6t   $��Bottom=�6�   $��30��6�   $��1q�6�   .��5(      �� $ 
Horizontal=�6   .+�5)      �� $ ��../Image/Icon/fl-reset.png��6   $��5q�6<   �� 5*      $
��(F1)��6   
�������$
��Bold"�6:   5+      5,      &   System.Windows.Controls.DataGrid  5-   
   -   5        $��dgHoaDon��5-       $��1��6     Datagrid#���  60      
IsReadOnly .    Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6%      Header$ Số hóa đơn��60   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   �� *	SoHD_HD+   ElementStyle 51      �� 52       �� 
TargetType" ��6    .�53      ��  �� Property � �� �� Value$
 Left=�6D   �� 54       � ��$ 10 0 0 0q�67   �� 55       � ��$ Center=�6B   56      58        5;      $ 1* 6%   $ Ngày lập��60    6B   �� *
NgayLap_HD+ �� StringFormat$ dd-MM-yyyy HH:mm�� 5<      �� 5=      " ��6    .�5>      ��  � ��$
 Left=�6D   �� 5?       � ��$ 10 0 0 0q�67   �� 5@       � ��$ Center=�6B   5A      5C        5G      $ 1* 6%   $ Người lập��60    6C   �� *NguoiLap_HD+ 5H      �� 5I      " ��6    .�5J      ��  � ��$ Center=�6D   �� 5K       �@�ToolTip 68   �� *
HoTen_NV+�� 5L       � ��$ Center=�6B   5M      5O      5Q      �� 5S   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   $��Center=�6X   .+�5T      �� -   5        $��btnChon��5T        MetroButtonTeal#���  6:   $��Chọn��6d   
�������$��5q�6�   $��20(�6�   $
��Bold"�6�   $��0 0 10 0q�6�   �� 5U      -   5        $��btnHuy��5U      #���  68   $��Hủy��6b   
�������$��5q�6�   $��20(�6�   $
��Bold"�6�   5V      5W      5X      