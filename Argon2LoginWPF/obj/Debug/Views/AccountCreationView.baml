   M S B A M L   `   `   `  ����I  EArgon2LoginWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Argon2LoginWPF.ViewModelsArgon2LoginWPF.ViewModels  5   	   .    (Argon2LoginWPF.Views.AccountCreationView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >
viewModels'clr-namespace:Argon2LoginWPF.ViewModels     5   	     � Title$  AccountCreationView��5	   	   $	��450��6%   $	��800��62   .��5
      � $��Center=�6   $��Center=�6(    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $	��300 �6   .+�5   
   �� $��0��6   
���  ��$
��Wrap=�5      $	��200��5      $��Center=�5       �� Padding$ 5q�5      $��5q�6    ��5      �� *NewAccount.ValidationMessage+5       �� 5   
   $��1��6   $	��200��5      $��Center=�5       $��5q�5!      $��5q�6   ��5      �� *NewAccount.Name+5!      �� 5"   
   $��2��6   $	��200��5$      $��Center=�5%      $��5q�5&      $��5q�6   ��5#      �� *NewAccount.Password+5&      �� 5'   
   -   5        $��3��5'      $��Register��6   $	��200��5)      $��Center=�5*      $��5q�5+      $��5q�6   5,      5-      