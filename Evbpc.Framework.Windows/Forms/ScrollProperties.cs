using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    public abstract class ScrollProperties
    {
        #region Constructors
        protected ScrollProperties(ScrollableControl container)
        {
            ParentControl = container;
        }
        #endregion

        #region Properties
        public bool Enabled { get; set; }
        public int LargeChange { get; set; }
        public int Maximum { get; set; }
        public int Minimum { get; set; }
        protected ScrollableControl ParentControl { get; }
        public int SmallChange { get; set; }

        [Bindable(true)]
        public int Value { get; set; }

        public bool Visible { get; set; }
        #endregion
    }
}
