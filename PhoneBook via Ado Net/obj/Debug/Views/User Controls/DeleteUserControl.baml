   M S B A M L   `   `   `  ����P  LPhoneBook via Ado Net, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:PhoneBook_via_Ado_Net.Views.User_Controls)PhoneBook_via_Ado_Net.Views.User_Controls  5      A    ;PhoneBook_via_Ado_Net.Views.User_Controls.DeleteUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ilocal7clr-namespace:PhoneBook_via_Ado_Net.Views.User_Controls     5      .��5	      � 
�������  � RowDefinitions  5   
   �� 5      $	��10* �6   �� 5      $	��90* �6   .+�5   
   �  � ColumnDefinitions 5      �� 5      $	��10* �6#   �� 5      $	��90* �6#   .+�5      �� $��/Images/left arrow.png��6    � Cursor$
 Hand��64    J� InputBindings 5      d� 5       d� Gesture$ 	LeftClicka�6#    �� Command 67   �� *BackCommand+5      5      �� 5   
   -   5         ��Name$ 
LstVwFirst��5       $��1��5      $��20(�6A   $��Disabled=�6O   ��6    �� *
Contacts+��5"      �� 5#       �� 
TargetType" ��6   .�5$      ��  �� Property � ��	 �� Value$	 Stretch=�6C   5%      ��5(      �� 5)      .R�5*      � 
 � Orientation$
 Vertical=�6    5+       �� View 5.      �� 50      .P�51      �� $��	Full name��6%    �� Width$	 230��68    �� CellTemplate 52      �� 53      .R�54   "   �� $��20(�6F   $
��Wrap=�6T    �� TextAlignment$ Center=�6h   ��6,   �� *
FullName+6h   55      57      �� 59      $��Phone Number��6%   $	 230��6;    5:      �� 5;   "   .R�5<   &   �� $��20(�6M   $
��Wrap=�6[   $ Center=�6o   ��60   �� *PhoneNumber+6o   5=   #   5?      �� 5A      $��	Operation��6%   $	 302��68    5B      �� 5C      .R�5D   "   ��    OperationButton#��[  6)   $��Delete��6R   $��50��5F   F   ��5E   )   ��  �� ElementName$ 
LstVwFirst�� �� Path$ DataContext.DeleteCommand���5F   )   �� 6F   5G      5I      5K      5R      5T      5U      