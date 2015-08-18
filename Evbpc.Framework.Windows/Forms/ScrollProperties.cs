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
        protected ScrollProperties(ScrollableControl container) { throw new NotImplementedException(); }
        #endregion

        #region Properties
        public bool Enabled { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public int LargeChange { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public int Maximum { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public int Minimum { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        protected ScrollableControl ParentControl { get { throw new NotImplementedException(); } }
        public int SmallChange { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        [BindableAttribute(true)]
        public int Value { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public bool Visible { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        #endregion
    }
}
