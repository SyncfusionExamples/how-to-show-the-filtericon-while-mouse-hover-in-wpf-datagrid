using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.ScrollAxis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using ContextMenuDemo;
using System.Windows.Data;
using System.ComponentModel;

namespace ContextMenuDemo
{
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
}
