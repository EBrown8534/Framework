using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    public abstract class ScrollProperties
    {
        private ScrollableControl _parentControl;

        #region Constructors
        protected ScrollProperties(ScrollableControl container) { _parentControl = container; }
        #endregion

        #region Properties
        public bool Enabled { get; set; }
        public int LargeChange { get; set; }
        public int Maximum { get; set; }
        public int Minimum { get; set; }
        protected ScrollableControl ParentControl { get { return _parentControl; } }
        public int SmallChange { get; set; }

        [BindableAttribute(true)]
        public int Value { get; set; }

        public bool Visible { get; set; }
        #endregion
    }
}
