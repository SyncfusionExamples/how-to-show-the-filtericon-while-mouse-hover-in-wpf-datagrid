using Syncfusion.UI.Xaml.Grid.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextMenuDemo
{
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
}
