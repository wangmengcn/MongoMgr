   M S B A M L   `   `   `  ����   MongoMgr    MongoMgr.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     f bDevExpress.Xpf.Grid.v13.1.Core, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   -     � Title$  数据集管理工具��$	��450��$
��1550�� � Icon$ Images/db.ico�� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $
��493* ��� $	��76* �.+��� -   $��确认选择��$
��Left=�$��
168,29,0,0q�$��1��$	��Top=�$��75���� -   $��重启服务��$
��Left=�$��
277,29,0,0q�$��1��$	��Top=�$��75��)  #DevExpress.Xpf.Grid.TreeListControl  -   $��treeviewctr��$��0��$��0��   Columns (  "DevExpress.Xpf.Grid.TreeListColumn  $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ GridFS名称��   AllowAutoFilter . $  DevExpress.Xpf.Grid.BaseColumn   AllowMoving] YDevExpress.Data.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5  /DevExpress.Utils.Design.DefaultBooleanConverter$ False a ]DevExpress.Xpf.Core.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a3  -DevExpress.Xpf.Core.DXFrameworkContentElement   	AllowDrop .  	   AllowBestFit$
	 True 
   AllowSorting$

 True   $ 数据库名�� . $ False  .  $
	 True $

 True   $ 建库时间�� . $ False  .  $
	 True $

 True   $ 入库时间�� . $ False  .  $
	 True $

 True   $ 数据类型�� . $ False  .  $
	 True $

 True   $
 Left�� . $ False  .  $
	 True $

 True   $	 Top�� . $ False  .  $
	 True $

 True   $ Right�� . $ False  .  $
	 True $

 True   $ Bottom�� . $ False  .  $
	 True $

 True   $ 最小层级�� . $ False  .  $
	 True $

 True   $ 最大层级�� . $ False  .  $
	 True $

 True   $ 描述�� . $ False  .  $
	 True $

 True    View &   DevExpress.Xpf.Grid.TreeListView  -     Name$ treeview��   ShowCheckboxes . �� -   $��全选��$
��Left=�$��	56,29,0,0q�$��1��$	��Top=�$��75��