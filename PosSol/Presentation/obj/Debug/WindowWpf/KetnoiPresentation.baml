   M S B A M L   `   `   `  ����  Presentation/    )Presentation.WindowWpf.KetnoiPresentation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Cấu hính kết nối��5   	   $	��310��6"   $	��350��6/    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � Icon$8 2/Presentation;component/Image/Icon/fl-setting1.png��66    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5	      �� 5
      $ ../Style/Label.xaml?�6%   �� 5      $ ../Style/Textbox.xaml?�6%   �� 5      $ ../Style/Button1.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      � 	 � Color$	 	#FFF3F3F3��6   
 � Offset$
 0Q�61   � 5      $	 	#FFA0B9FB��6   $
 1Q�61   5      .+�5   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   $��	15 15 0 0q�62   .+�5      �� $��Sever��6      lbControlLeft#���   6(   $	��100��6P   
�������$
��Bold"�6n   $��20(�6�   �� 5      -   5        $��txtSever��5        Textbox1#���  6*   $��22(�6M   $	��200��6[   5      �� 5      $ 
Horizontal=�6   $��	15 10 0 0q�62   .+�5      �� $��Database��6   #���   6+   $	��100��6S   
�������$
��Bold"�6q   $��20(�6�   �� 5       -   5        $��txtDatabase��5       #���  6-   $��22(�6P   $	��200��6^   5!      �� 5#      $ 
Horizontal=�6   $��	15 10 0 0q�62   .+�5$      �� $��Username��6   #���   6+   $	��100��6S   
�������$
��Bold"�6q   $��20(�6�   �� 5%      -   5        $��txtUsername��5%      #���  6-   $��22(�6P   $	��200��6^   5&      �� 5(      $ 
Horizontal=�6   $��	15 10 0 0q�62   .+�5)      �� $��Password��6   #���   6+   $	��100��6S   
�������$
��Bold"�6q   $��20(�6�   G� 5*      -   5        $��txtPass��5*      $��22(�6-   $	��200��6;   5+      �� 5-      
��� � �$��0 1 0 1q�6)   $��
10 10 10 0q�6C    �� Padding$ 5q�6W   ._�5.      �� $ 
Horizontal=�6   $��Center=�66   .+�5/      �� -   5        $��btnLuu��5/        MetroButtonMaroon#���  6@   $��5 0 0 0q�6l   $��40��6}   $��5q�6�   .��50      �� $ 
Horizontal=�6%   .+�51      �� $��../Image/Icon/fl_save.png��6$   $��Uniform=�6G   �� 52      $
��Lưu��6$   
�������$��Center=�6E   $
��Bold"�6`   53      54      �� 55      -   5        $��btnTest��55        MetroButtonYellowGreen#���  6B   $��5 0 0 0q�6s   $��40��6�   $��5q�6�   .��56      �� $ 
Horizontal=�6%   .+�57      �� $"��../Image/Icon/fl-connect.png��6$   $��Uniform=�6J   �� 58      $
��Test��6$   
�������$��Center=�6F   $
��Bold"�6a   59      5:      5;      5<      �� 5=      -   5        $��	lbWarning��5=        LabelWarning#���  6&   $��Warning!��6M   $��15(�6`   $y�Hidden=�6n   $��10 0 0 0q�6�   5>      5?      5@      