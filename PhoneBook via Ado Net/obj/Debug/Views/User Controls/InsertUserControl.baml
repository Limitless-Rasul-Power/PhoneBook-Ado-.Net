   M S B A M L   `   `   `  ����P  LPhoneBook via Ado Net, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:PhoneBook_via_Ado_Net.Views.User_Controls)PhoneBook_via_Ado_Net.Views.User_Controls  5      A    ;PhoneBook_via_Ado_Net.Views.User_Controls.InsertUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ilocal7clr-namespace:PhoneBook_via_Ado_Net.Views.User_Controls     5      .��5	      � 
�������  � RowDefinitions  5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   � $��0��6   $��0��6    5      �� 5       $	��35* �6#   �� 5!      $	��65* �6#   .+�5$      �� $��/Images/left arrow.png��6    � Cursor$
 Hand��64    J� InputBindings 5%      d� 5&       d� Gesture$ 	LeftClicka�6#    �� Command 67   �� *BackCommand+5(      5*      �� 5-   
   $��2��6   $��1��6!   $��	Full Name��61   $��Center=�6B   $��Center=�6_   $��22(�6z   �� 5/   
   $��2��6   $��2��6   $��3��6/   $��20(�6C   $��Center=�6Q   $��10, 0 ,0 ,0q�6l    �� TextWrapping$
 Wrap=�50      " �� VerticalScrollBarVisibility$
 Auto=�6&   $ �� HorizontalScrollBarVisibility$ Disabled=�6I   $��
0, 0, 0, 5q�51      
���������50   r   �� *
FullName+51   /   �� 53   
   $��3��6   $��0��6!   $��2��61   $��Phone Number��6E   $��Right=�6Y   $��Center=�6u   $��20(�54      $��
0, 0, 5, 0q�6"   �� 56   
   $��3��6   $��2��6   $��3��6/   $��20(�6C   $��Center=�6Q   $��10, 0 ,0 ,0q�6l   $
 Wrap=�57      $
 Auto=�6&   $ Disabled=�6I   $��
0, 0, 0, 5q�58      
���������57   r   �� *PhoneNumber+.��58   B   59      �� 5;   
   $��4��6   $��2��6!   $��Format XXX XXX XXXX��61   $	��Top=�6L   $��11(�6d   $��
4, 0, 0, 0q�6r   �� 5=   
   $��5��6   $��4��6   $��2��6.   $��Insert��6B      OperationButton#��[  6S   ��5>      �� *InsertCommand+5@      5A      