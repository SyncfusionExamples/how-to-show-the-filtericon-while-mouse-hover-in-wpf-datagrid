# How to show the FilterIcon while Mouse hover in WPF DataGrid (SfDataGrid)?

How to show the FilterIcon while Mouse hover in WPF DataGrid (SfDataGrid)?

# About the sample

By default, SfDataGrid does not provide the support to set the filter icon visibility based on mouse positions, you can achieve this by customize the GridDataHeaderCellRenderer and GridHeaderCellControl.

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
## Requirements to run the demo
 Visual Studio 2015 and above versions
