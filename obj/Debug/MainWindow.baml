   M S B A M L   `   `   `  ����  MongoMgr    MongoMgr.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   f bDevExpress.Xpf.Grid.v13.1.Core, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $
��1550��6)    � Icon$ Images/db.ico��66   .��5      �  � RowDefinitions 5   
   �� 5      $
��493* �6   �� 5	      $	��76* �6   .+�5   
   �� -   5        $��确认选择��5      $
��Left=�6    $��
168,29,0,0q�6;   $��1��6O   $	��Top=�6\   $��75��6t   6   �� 5   
   $��更新配置文件��6   $
��Left=�6"   $��
335,29,0,0q�6=   $��1��6Q   $	��Top=�6^   $��75��6v   �� 5   
   $��重启服务��6   $
��Left=�6    $��
508,29,0,0q�6;   $��1��6O   $	��Top=�6\   $��75��6t   )  #DevExpress.Xpf.Grid.TreeListControl  5   
   -   5        $��treeviewctr��5      $��0��62   $��0��6?      Columns 5      (  "DevExpress.Xpf.Grid.TreeListColumn  5      $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ GridFS名称��6%      AllowAutoFilter . $  DevExpress.Xpf.Grid.BaseColumn   AllowMoving] YDevExpress.Data.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5  /DevExpress.Utils.Design.DefaultBooleanConverter$ False 6Q   a ]DevExpress.Xpf.Core.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a3  -DevExpress.Xpf.Core.DXFrameworkContentElement   	AllowDrop .     AllowBestFit$
 True 6w   	   AllowSorting$
	 True 6�     5      $ 数据库名��6%    . $ False 6M    .  $
 True 6s   $
	 True 6�     5      $ 建库时间��6%    . $ False 6M    .  $
 True 6s   $
	 True 6�     5      $ 入库时间��6%    . $ False 6M    .  $
 True 6s   $
	 True 6�     5      $ 数据类型��6%    . $ False 6M    .  $
 True 6s   $
	 True 6�     5      $
 Left��6%    . $ False 6M    .  $
 True 6s   $
	 True 6�     5      $	 Top��6%    . $ False 6L    .  $
 True 6r   $
	 True 6�     5      $ Right��6%    . $ False 6N    .  $
 True 6t   $
	 True 6�     5      $ Bottom��6%    . $ False 6O    .  $
 True 6u   $
	 True 6�     5      $ 最小层级��6%    . $ False 6M    .  $
 True 6s   $
	 True 6�     5      $ 最大层级��6%    . $ False 6M    .  $
 True 6s   $
	 True 6�     5      $ 描述��6%    . $ False 6K    .  $
 True 6q   $
	 True 6�   
   View
 5      &   DevExpress.Xpf.Grid.TreeListView  5      -   5          Name$ treeview��5   #      ShowCheckboxes . 5"      5$      5'      5(      