   M S B A M L   `   `   `  ����P  LIndumentariaIntimaWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:IndumentariaIntimaWPF.Formularios!IndumentariaIntimaWPF.Formularios  5   	   5    /IndumentariaIntimaWPF.Formularios.Transacciones   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:IndumentariaIntimaWPF.Formularios     5   	     � Title$  Transacciones��5   	   $	��503��6   $
��1321��6,    � WindowStartupLocation$ CenterScreen=�69   .��5	      � .+�5
   
   �� -   5         ��Name$ TBXBusqueda��5
      $��30��6'   $	��Top=�63   $��145,282,957,0q�6K   $��14(�6b   �� 5   
   -   5        $��Buscar��5      $��30��6:   $	��Top=�6F   $��470,282,788,0q�6^   �� 5   
   -   5         ��Name$ ClienteComboBox��5      $��30��6,   $	��Top=�68   $��145,360,957,0q�6P   $��14(�6g    �� DisplayMemberPath$ NOMBRE��5       �� SelectedValuePath$ 
CLIENTE_ID��6&   �� 5   
   -   5        $��Agregar Cliente��5      $��30��6E   $	��Top=�6Q   $��470,360,673,0q�6i   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ProductosDataGridView��5         AutoGenerateColumns . $��64,32,969,243q�6M     5   
   -   5        $ DataGridViewVentas��5       . $��580,32,72,243q�6J      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID Producto��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *
IDProducto+6Y     5      $	 Precio��6%   $
 * 6P    65   �� *Precio+6P     5      $	 Cantidad��6%   $
 * 6T    67   �� *
Cantidad+6T     5      $	 Total��6%   $
 * 6N    64   �� *Total+6N   5      �� 5   
   -   5        $��	Agregar >��5      $��30��6E   $	��Top=�6Q   $��406,54,821,0q�6i   �� 5   
   -   5        $��Eliminar��5      $��30��6>   $	��Top=�6J   $��406,109,821,0q�6b   �� 5   
   -	   5        $��Limpiar Grilla��5      $��30��6A   $	��Top=�6M   $��406,174,821,0q�6e   �� 5    
   -
   5        $��Concretar Venta��5       $��30��6F   $	��Top=�6R   $��895,355,248,0q�6j   �� 5!   
   $��Fecha��6   $
��Left=�6    $��816,297,0,0q�6;   $	��Top=�6P   (  "System.Windows.Controls.DatePicker  5"   
   -   5          Name$ FechaCaptura��5"      $
��Left=�6+   $��895,297,0,0q�6F   $	��Top=�6[   $	��178��6s   $��26��6   �� 5#   
   -   5        $��Volver��5#      $
��Left=�6"   $��1110,364,0,0q�6=   $	��Top=�6S    J� RenderTransformOrigin$ -0.603,-0.15&�6k   $��30��6�   $��91��6�   6�   �� 5$   
   -   5        $��Agregar Producto��5$      $
��Left=�6,   $��580,284,0,0q�6G   $	��Top=�6\   $��26��6t   $	��118��6�   6�   �� 5%   
   $��Producto��6   $
��Left=�6#   $��
70,282,0,0q�6>   $	��Top=�6R   $��62��6j   �� 5&   
   $��Cliente��6   $
��Left=�6"   $��
70,362,0,0q�6=   $	��Top=�6Q   $��62��6i   �� 5'   
   -   5        $ TipoDePagoComboBox��5'      $
��Left=�6/   $��145,434,0,0q�6J   $	��Top=�6_   $	��219��6w   $��27��6�   .@�5(      �� $��Efectivo��6   �� 5)      $��TarjetadeCredito��6   �� 5*      $��TransferenciaBancaria��6   �� 5+      $��TarjetadeDebito��6   5,      �� 5-   
   $��Medio de Pago��6   $
��Left=�6(   $��
37,434,0,0q�6C   $	��Top=�6W   $��27��6o   $��95��6{   5/      51      