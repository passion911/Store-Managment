   M S B A M L   `   `   `  ����  Presentation6    0Presentation.UserControls.DonViTinhUPresentation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $��ucDonViTinh��5         UserControl#���   6[     � 	Resources  5       �� MergedDictionaries �� Source�� 5	   
    5
      �� 5      $ ../Style/UserControl.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   �� 5      $ ../Style/Datagrid.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF3F3F3��6    � Offset$ 0Q�61   � 5      $ 	#FFA0B9FB��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5       $��50 �6   .+�5#   
   �� $��0��6   $y�Hidden=�6"    �� Orientation$ 
Horizontal=�66   $��50��6O   $��5 0 0 5q�6[   .+�5$      �� -   5        $��
txtTimKiem��5$        Textbox1#���  6(   $��25(�6K   $	��200��6Y   �� 5%      -   5        $��
btnTimKiem��5%        MetroButtonDarkGreen#���  6'   $��5 0 0 0q�6V   $��40��6g   $��5q�6s   .��5&      �� $ 
Horizontal=�6   .+�5'      �� $!��../Image/Icon/fl-search.png��6   $��Uniform=�6A   5(      5)      5*      &   System.Windows.Controls.DataGrid  5-   
   -   5        	  Name$	 dgDonViTinh��5-       $��1��6   
   SelectionMode$
 Single=�65     Datagrid#���  6L      
IsReadOnly .    Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6%      Header$ Mã đơn vị��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   �� *	MaDVT_DVT+   ElementStyle 53      �� 54       �� 
TargetType" ��6    .�55      ��  �� Property � �� �� Value$
 Left=�6D   �� 56       � ��$ 10 0 0 0q�67   �� 57       � ��$ Center=�6B   58      5:        5=      $ 1* 6%   $ Tên đơn vị��60    6D   �� *
TenDVT_DVT+ 5>      �� 5?      " ��6    .�5@      ��  � ��$
 Left=�6D   �� 5A       � ��$ 10 0 0 0q�67   �� 5B       � ��$ Center=�6B   5C      5E      4  .System.Windows.Controls.DataGridCheckBoxColumn  5H      $	 200 6)   $ Đang dùng��65    6H   �� *DangDung_DVT+ 5I      �� 5J      " ��6    .�5K      ��  � ��$ Center=�6D   �� 5L       � ��$ Center=�6B   �� 5M       �@J�IsHitTestVisible .  6A   5N      5P      4  .System.Windows.Controls.DataGridTemplateColumn  5S      $ 50 6)   $ Sửa��64      CellTemplate 5T      �� 5U      .R�5V      �� $��btnSua��6%   -   5          MetroButtonYellowGreen#���  5V   3   $��30��6y   $��2q�6�   .��5W   "   �� .+�5X   &   �� $��../Image/Icon/fl-edit.png��6-   $��Uniform=�6P   $��20��6b   5Y   #   5Z      5[      5]        5`      $ 50 6)   $
 Xóa��64    5a      �� 5b      .R�5c      �� $��btnXoa��6%   -   5          MetroButtonOrange#���  5c   H   $��30��6t   $��2q�6�   .��5d   "   �� .+�5e   &   �� $!��../Image/Icon/fl-delete.png��6,   $��20��6Q   $��Uniform=�6]   5f   #   5g      5h      5j      5m      �� 5p   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   $��Center=�6W   $��0 0 5 0q�6r   .+�5q      �� -   5        $��
btnThemMoi��5q        MetroButtonTeal#���  6@   $��5 0 0 0q�6j   $��40��6{   $��5q�6�   .��5r      �� $ 
Horizontal=�6   .+�5s      �� $&�� ../Image/Icon/fl-addDocument.png��6   $��Uniform=�6F   �� 5t      $��Thêm��6   
�������$��Center=�6>   $
��Bold"�6Y   5u      5v      5w      5y      5z      