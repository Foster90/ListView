﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace ListView
{
   
    /// This class is an implementation of the 'IComparer' interface.
    public class ListViewColumnSorter : IComparer
    {

         /// Case insensitive comparer object
        private CaseInsensitiveComparer ObjectCompare;

        /// Class constructor. Initializes various elements
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            SortColumn = 0;
            
            // Initialize the sort order to 'none'
            Order = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

       
        /// This method is inherited from the IComparer interface. It compares the two objects passed using a case insensitive comparison.
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            compareResult = ObjectCompare.Compare(listviewX.SubItems[SortColumn].Text, listviewY.SubItems[SortColumn].Text);

            // Calculate correct return value based on object comparison
            if (Order == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (Order == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        public int SortColumn { set; get; }

        
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        public SortOrder Order { set; get; }

    }
}
