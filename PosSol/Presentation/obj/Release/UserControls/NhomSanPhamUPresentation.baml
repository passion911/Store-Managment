   M S B A M L   `   `   `  ����   Presentation8    2Presentation.UserControls.NhomSanPhamUPresentation   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -   $��ucNhomSanPham��$��0q�
������ $��Stretch=�$��Stretch=�$��0,0,0,0q�$	��600��$	��600��  � 	Resources     Datagrid �� 
TargetType&   System.Windows.Controls.DataGrid �� Property  ColumnHeaderStyle �� Value  	selectRow=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Triggers P� Property P� Value)  #System.Windows.Controls.DataGridRow  RowStyle*  $System.Windows.Controls.DataGridCell��%�  &	        &	 P     &	     &	 �    �� "  .���  �@ ColumnHeaderStyle# �  ��  �@ RowStyle# �  �� "  .���  � ��$ 20����  � �� �	#FF4169AA��  � ��
 �������  � ��$ Center=� P�  �@J�IsMouseOver . . ���  �@�ToolTip$ Sắp xếp���� "   P�  �@ 
IsSelected . . ���  � ��
 �/�����  � ��$ 2q���  � ��$ 15(���  � ��$
 Bold"��� "  .���  � ��$ 30��.���  � RowDefinitions �� $��* ��� $��50 �.+�  -     Name$ dgNhomSanPham��	   SelectionMode$	 Single=�#���   $��0q�$��Stretch=�$��Stretch=�$��Times New Roman)�$��13.333(�
������ 
   AutoGenerateColumns
 .     CanUserAddRows .     CanUserResizeRows .     AlternatingRowBackground
 ����� �� AlternationCount$ 2��   HorizontalGridLinesBrush �	#FF303030   VerticalGridLinesBrush �	#FFA69D9D   
IsReadOnly .  �� SelectedItem �� *sl+ �� Mode$ OneWay=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100    Header$ 	Mã nhóm��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Ma_NSP+   ElementStyle �� " ��.���  � ��$ Center=���  � ��$ Center=�  $ 1* $ 
Tên nhóm�� �� *TenNSP+ �� " ��.���  � ��$ Center=���  � ��$ Center=�4	  .System.Windows.Controls.DataGridCheckBoxColumn	  $	 100 $ Đang dùng�� �� *
DangDung+ �� " ��.���  � ��$ Center=���  � ��$ Center=�  $ 2* $ Ghi chú�� �� *GhiChu+ �� " ��.���  � ��$ Center=���  � ��$ Center=�4
  .System.Windows.Controls.DataGridTemplateColumn
  $ 50 $ Sửa�� 
  CellTemplate �� .R��� $��btnSua��-   $��5,5,5,5q�.���� .+��� $��../Image/Pencil-icon.png��$
��None=�
  $ 50 $
 Xóa�� �� .R��� $��btnXoa��-   $��5,5,5,5q�.��Xóa� -    �Name$ 
gridButton��$��1��$��50��$��0q�$��Stretch=�$��Bottom=�
�������.+��� -    ��Name$ btnDong��$��Đóng��$��Right=�$��29��$��	0,11,36,0q�$	��Top=�$��62���� -   $ 
btnThemMoi��$��Thêm��$��Right=�$��29��$��
0,11,123,0q�$	��Top=�$��69���� -   $ btnNhapExcel��$��Nhập từ Excel��$��Right=�$��29��$��
0,11,215,0q�$	��Top=�$��91���� -	   $ btnXuatExcel��$��Xuất Excel��$��Right=�$��29��$��
0,11,329,0q�$	��Top=�$��66��