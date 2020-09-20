using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListView
{
    public partial class Form1 : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        public Form1()
        {
            InitializeComponent();
           
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
    }

        private void Form1_Load(object sender, EventArgs e)
        {


            listView1.View = View.Details;
            listView1.Columns.Add("Name");
            listView1.Columns.Add("ID");
            listView1.Columns.Add("Score");

            listView1.Items.Add(new ListViewItem(new[] { "John  ", "1", "100" }));
            listView1.Items.Add(new ListViewItem(new[] { "John ", "1", "100" }));
            listView1.Items.Add(new ListViewItem(new[] { "Smith ", "2", "120" }));
            listView1.Items.Add(new ListViewItem(new[] { "Cait ", "3", "97" }));
            listView1.Items.Add(new ListViewItem(new[] { "Irene", "4", "100" })); 

            listView1.GridLines = true;


        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
          

            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }
    }
}
