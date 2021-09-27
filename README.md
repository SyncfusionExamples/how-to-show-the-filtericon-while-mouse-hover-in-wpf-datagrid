# How to show the FilterIcon while Mouse hover in WPF DataGrid (SfDataGrid)?

This sample show cases how to show the FilterIcon while Mouse hover in [WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) (SfDataGrid)?

# About the sample

[WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) (SfDataGrid) does not provide the support to set the filter icon visibility based on mouse positions, you can achieve this by customize the [GridDataHeaderCellRenderer](https://help.syncfusion.com/cr/cref_files/wpf/Syncfusion.SfGrid.WPF~Syncfusion.UI.Xaml.Grid.SfDataGrid~CellRenderers.html) and [GridHeaderCellControl](https://help.syncfusion.com/cr/cref_files/wpf/Syncfusion.SfGrid.WPF~Syncfusion.UI.Xaml.Grid.GridHeaderCellControl.html).

```c#
public class GridDataHeaderCellRendererExt : GridDataHeaderCellRenderer
{
    protected override Syncfusion.UI.Xaml.Grid.GridHeaderCellControl OnCreateEditUIElement()
    {
        return new GridHeaderCellControlExt();
    }

    public override void OnUpdateEditBinding(Syncfusion.UI.Xaml.Grid.DataColumnBase dataColumn, Syncfusion.UI.Xaml.Grid.GridHeaderCellControl element, object dataContext)
    {
        base.OnUpdateEditBinding(dataColumn, element, dataContext);
        element.FilterIconVisiblity = System.Windows.Visibility.Collapsed;
    }
}

public class GridHeaderCellControlExt:GridHeaderCellControl
{
    public GridHeaderCellControlExt()
        : base()
    {
            
    }

    protected override void OnMouseEnter(System.Windows.Input.MouseEventArgs e)
    {
        base.OnMouseEnter(e);

        if(this.DataGrid.AllowFiltering && Column.AllowFiltering)
            this.FilterIconVisiblity = System.Windows.Visibility.Visible;
        else if(this.DataGrid.AllowFiltering && !Column.AllowFiltering)
            this.FilterIconVisiblity = System.Windows.Visibility.Collapsed;
        else if(!this.DataGrid.AllowFiltering && Column.AllowFiltering)
            this.FilterIconVisiblity = System.Windows.Visibility.Visible;
        else
            this.FilterIconVisiblity = System.Windows.Visibility.Collapsed;
    }

    protected override void OnMouseLeave(System.Windows.Input.MouseEventArgs e)
    {
        base.OnMouseLeave(e);

        if(Column.FilterPredicates.Count!=0)
            this.FilterIconVisiblity = System.Windows.Visibility.Visible;
        else
            this.FilterIconVisiblity = System.Windows.Visibility.Collapsed;
    }
}
```

KB article - [How to show the FilterIcon while Mouse hover in WPF DataGrid (SfDataGrid)?](https://www.syncfusion.com/kb/11913/how-to-show-the-filtericon-while-mouse-hover-in-wpf-datagrid-sfdatagrid)

## Requirements to run the demo
 Visual Studio 2015 and above versions
