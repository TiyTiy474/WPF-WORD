   M S B A M L   `   `   `  ����B  >WpfApp6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp6WpfApp6  5   	       WpfApp6.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp6     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   c� $��0��6   .@�5      �� -   5        $
��Font��5      $	��150��6#   .@�5      �� .��6   Arial6&   �� 5      .��6   Times New Roman60   �� 5      .��6   	Verdana6(   5      �� 5      -   5        $��FontSize��5      $��60��6'   .@�5      �� .��6   126#   �� 5      .��6   146#   �� 5      .��6   166#   5      d� 5      -   5        $��
BoldButton��5      .��6F   Жирный6N   d� 5      -   5        $��ItalicButton��5      .��6J   Курсив6R   d� 5       -   5        $��UnderlineButton��5       .��6P   Подчеркнутый6^   �� 5"      -   5        $��
LeftButton��5"      .��6@   По левому краю6P   �� 5#      -   5        $��CenterButton��5#      .��6D   По центру6O   �� 5$      -   5        $��RightButton��5$      .��6B   По правому краю6S   5%      �� 5'   
   -	   5         ��Name$ RichTextBox��5'   #   $��1��6   $��10q�68   $��793.7��6D   $��1122.52��6R   . �5(      /�  /� 	PageWidth$ 793.7��6    /� 
PageHeight$ 1122.52��6-    /� ColumnWidth$ 793.7��6B    /� 	ColumnGap$ 0��6V   5*      5+      �� 5-   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��Bottom=�6X   $��	0,10,0,10q�6s   .+�5.      �� -
   5        $��FileOpenButton��5.      $��Открыть файл��6+   $��30��6B   $	��100��6N   $��5q�6Z   6e   �� 5/      -   5        $
��Seal��5/      $��Печать��6!   $��30��62   $	��100��6>   $��5q�6J   6U   �� 50      -   5        $��SaveFileButton��50      $��Сохранить��6+   $��30��6?   $	��100��6K   $��5q�6W   6b   51      52      53      