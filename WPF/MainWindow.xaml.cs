#region Copyright Syncfusion Inc. 2001 - 2013
// Copyright Syncfusion Inc. 2001 - 2013. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Cells;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.UI.Xaml.Grid.Helpers;
namespace ContextMenuDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            datagrid.CellRenderers.Remove("Header");
            datagrid.CellRenderers.Add("Header", new GridDataHeaderCellRendererExt());
            this.datagrid.FilterChanged += datagrid_FilterChanged;
        }

        void datagrid_FilterChanged(object sender, Syncfusion.UI.Xaml.Grid.GridFilterEventArgs e)
        {
            var headerRowBase = this.datagrid.GetRowGenerator().Items.FirstOrDefault(row => row.RowIndex == this.datagrid.GetHeaderIndex());

            var columnBase = (headerRowBase as DataRowBase).VisibleColumns.FirstOrDefault(col => col.GridColumn != null && col.GridColumn.MappingName.Equals(e.Column.MappingName));
            if (e.Column.FilterPredicates.Count != 0)
            {
                (columnBase.ColumnElement as GridHeaderCellControl).FilterIconVisiblity = Visibility.Visible;
            }
            else
                (columnBase.ColumnElement as GridHeaderCellControl).FilterIconVisiblity = Visibility.Collapsed;
        }

    }
}

