   M S B A M L   `   `   `  ����   Candidate_WPF_GUI(    "Candidate_WPF_GUI.JobPostingWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     c _MahApps.Metro.IconPacks.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  ;av2http://schemas.microsoft.com/expression/blend/2008  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  $	��720��$
��1080��  � WindowStartupLocation$  CenterScreen=� � AllowsTransparency$
 True��
������  � WindowStyle$
 None=� � 	Resources    	BoolToVis��%   &	        �� .���� -    �� CornerRadius$ 30�����#EFF2F7._��  � ColumnDefinitions �� $	��200 ��� $��* �.+��  � RowDefinitions �� $
��auto ��� $��* �.+���   	topButton#��[ $
��Left=�$��
20 28 0 35q�.��.  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Menu=�$��15��$��15���� $��1�����#5eccb4$ 	0 50 0 30��._�]� .+��� $��Silvers Club��
�������$��22(�$��SemiBold"�$	��Top=�$��	5 25 0 10q� �� TextAlignment$ Center=��� $��Members, France��
�������$��14(�$��SemiBold"�$	��Top=�$ Center=��� $��25q�
�������$	��Top=�$	��0.8���� $	��Top=�.+���   
menuButton#��[ .���� 	 �� Orientation$	 
Horizontal=�.+�  $ HomeVariant=�  menuButtonIcon#��[ �� $��	Dashboard���� #��[ ���#05a884
�������.���� $	 
Horizontal=�.+�  $ CalendarClock=�#��[ �� $��Job posting���� #��[ .���� $	 
Horizontal=�.+�  $ AccountMultipleOutline=�#��[ �� $��Candidate profile���� #��[ .���� $	 
Horizontal=�.+�  $ CashMultiple=�#��[ �� $��Wallet���� #��[ .���� $	 
Horizontal=�.+�  $ ForumOutline=�#��[ �� $��Messages���� -   
 ��Name$
 btnClose��#��[ ���#05a884$��Bottom=�$��Bottom=�$��
15 0 15 20q�.���� $	 
Horizontal=�.+�  $ Logout=�#��[ �� $��Logout��� $��1��$��30 20 20 20q� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* ��� $
��auto �.+�� $	��300��$
��Left=�.+��� $
��20 0q�$��Center=����#B0B9C6 J� IsHitTestVisible$ False�� K� ZIndex$ 1��$��Search here ...��y��� *Text.IsEmpty+ �� 	Converter# [   �� ElementName$ textBoxSearch���� -    ��Name$ textBoxSearch��  searchTextbox#��[   $ Magnify=�$��15��$��15��$��Center=�$��0 0 15 0q����#B0B9C6$��Right=��� #��[ $��0 0 20 0q����#dcdcdc$��Right=�.��  $	 Cog=��� #��[ $��0 0 55 0q�$��Right=�.��  $
 Bell=��� $��Job Posting��$��1��$��32(�$��SemiBold"�$��0 20 0 0q����#121518$
��Left=��� -   $ 	txtPostId�� % !MaterialDesignFloatingHintTextBox#��[ )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Posting Id��   FloatingOffset$ 0, -20&����#c5c8cc$��14,34,680,0q�$��5��$	��Top=�$��	0 0 0 1.5q�$��18(��� -   $ txtTitle��#��[ $ Title��$ 0, -20&����#c5c8cc$��177,34,503,0q�$��5��$	��Top=�$��	0 0 0 1.5q�$��18(��� -   $ txtDescription��#��[ $ Posting description��$ 0, -90&����#c5c8cc �� TextWrapping$
 Wrap=�$��14,165,503,0q�$��5��$	��Top=�$��	0 0 0 1.5q�$	��167��$��18(�(  "System.Windows.Controls.DatePicker  -     Name$ dtgPostDate��$
��Left=�$��33��$��	14,96,0,0q�$	��Top=�$	��313��$��5��$��18(��� -   $
 btnAdd��  	addButton#��[ $��0,354,670,100q�$��5��.���� $	 
Horizontal=�.+�  $
 Plus=�$��Center=�$��0 1 8 0q�$��11��$��11���� $��Add New Posting���� -	   $
 	btnUpdate��  updateButton#��[ $��0,354,503,100q�$��5��.���� $	 
Horizontal=�.+�  $ Pencil=�$��Center=�$��0 1 8 0q�$��11��$��11���� $��Update Posting���� -
   $
 	btnDelete��  deleteButton#��[ $��0,407,670,47q�$��5��.���� $	 
Horizontal=�.+�  $ TrashCan=�$��Center=�$��0 1 8 0q�$��11��$��11���� $��Delete Posting���� $��1��$��3�����#DAE2EA$��	0 -1 0 10q��� $��6��$
��Left=����#DEE4EC$��1q�$ 5�� �� Padding$ 5q����#ffffff$��427,10,0,10q�._��� $	 
Horizontal=�.+���  	 pagingButton#��[	 .��  $ ChevronLeft=� 
 pagingButtonIcon#��[
 �� $��1�����#DEE4EC$	��3 7q��� #��[	 $��1���� #��[	 $��2�����#05a884���#ffffff�� #��[	 $��3���� $	��...�����#6C7682$��Center=�$
��10 0q�$��15(��� #��[	 $��7���� #��[	 $��8���� #��[	 $��9���� $��1�����#DEE4EC$	��3 7q��� #��[	 .��  $ ChevronRight=�#��[
 &   System.Windows.Controls.DataGrid  -     Name$ 
dtgJobPost��$
��Left=�$	��435��$��
343,44,0,0q�$��5��$	��Top=�$	��478�����#c5c8cc$��1q�   CanUserAddRows$ False��