   M S B A M L   `   `   `  ����P  LPhoneBook via Ado Net, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:PhoneBook_via_Ado_Net.Views.User_Controls)PhoneBook_via_Ado_Net.Views.User_Controls  5      A    ;PhoneBook_via_Ado_Net.Views.User_Controls.UpdateUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ilocal7clr-namespace:PhoneBook_via_Ado_Net.Views.User_Controls     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Cie:http://schemas.microsoft.com/expression/2010/interactivity  6T   .��5	      � 
�������  � RowDefinitions  5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5"   
   � $��0��6   $��0��6    5$      �� 5%      �� 5&      .+�5)      �� $��0��6   $��0��6!   $��/Images/left arrow.png��61   $��5q�6Q    � Cursor$
 Hand��6\    J� InputBindings 5*      d� 5+       d� Gesture$ 	LeftClicka�6#    �� Command 67   �� *BackCommand+5-      5.      �� 52   
   -   5         ��Name$ 
LstBxFirst��53   A   $��1��52      $��7��6   $��4��63   $��Disabled=�6D   $
��Auto=�53      $
 Hand��6v   ��6U   �� *
Contacts+.  (System.Windows.Interactivity.Interaction   Triggers 55      /  )System.Windows.Interactivity.EventTrigger  56         	EventName$ SelectionChanged��6"   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 57      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6-   �� *SelectionChangedCommand+   CommandParameter 58   -   ��  �� ElementName$ 
LstBxFirst�� �� Path$ SelectedItem�59      ��5<      �� 5=      .R�5>      �  � Orientation$ Vertical=�6    5?      ��5B      �� 5C      .R�5D      � $��60��6V   ���#005f73��6   �� $ 
LstBxFirst��$ ActualWidth� 5E      �� 5F      �� 5G      .+�5J      �� $��0��6$   $��25(�64   ���#ffd000$��Center=�6q   $��Center=�5K   $   ��5J   B   �� *
FullName+5K   $   �� 5L      $��1��6$   $��25(�64   ���#ffd000$��Center=�6t   $��Center=�5M   $   ��5L   B   �� *PhoneNumber+5M   $   5N      5O      5Q      �� 5S   
   $��5��6   $��0��6!   $��2��61   $��2��6E   $��Center=�6V   $��Center=�6q   $��Full Name: ��6�   $��17(�5T      �� 5V   
   $��5��6   $��2��6   $��4��6/   $��2��6C   $��Center=�6u   $��10, 0, 0, 0q�5W      $��18(�6(    �� TextWrapping$
 Wrap=�66   $��Disabled=�5X      $
��Auto=�6H   ��5V   T   �� *UpdatedFullName+5X   H   �� 5Z   
   $��6��6   $��0��6!   $��2��61   $��2��6E   $��Center=�6V   $��Center=�6q   $��Phone Number: ��5[      $��17(�6*   �� 5]   
   $��6��6   $��2��6   $��4��6/   $��2��6C   $��Center=�6x   $��10, 0, 0, 0q�6�   $��18(�5^      $
 Wrap=�6    $��Disabled=�64   $
��Auto=�6j   ��5]   T   �� *UpdatedPhoneNumber+5^   j   �� 5`   
   $��8��6   $��6��6   $
��Save��6.      OperationButton#��[  6=   ���#38b000$��DemiBold"�5a   &   ��5`   f   �� *SaveCommand+5a   &   5c      5d      