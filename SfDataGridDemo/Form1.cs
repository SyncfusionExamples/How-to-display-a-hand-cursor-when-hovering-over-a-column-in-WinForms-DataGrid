using SfDataGridDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SfDataGridDemo
{
    public partial class Form1 : Form
    {
        OrderInfoCollection _orderInfos;
        public Form1()
        {
            InitializeComponent();
            _orderInfos = new OrderInfoCollection();
            sfDataGrid1.DataSource = _orderInfos.Orders;

            // Event subscription
            sfDataGrid1.TableControl.MouseMove += OnTableControlMouseMove;
        }

        // Event Customization
        private void OnTableControlMouseMove(object sender, MouseEventArgs e)
        {
            // Get the row and column index at the mouse position
            var rowColumnIndex = sfDataGrid1.TableControl.PointToCellRowColumnIndex(e.Location);

            // Check if mouse is over a valid column
            if (rowColumnIndex.ColumnIndex > -1)
            {
                // Change to hand cursor when hovering over the columns
                Cursor = Cursors.Hand;
            }
            else
            {
                // Reset cursor to default when not over any column
                Cursor = Cursors.Arrow;
            }
        }
    }
}
