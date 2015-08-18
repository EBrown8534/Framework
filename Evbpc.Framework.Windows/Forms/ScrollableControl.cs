using Evbpc.Framework.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    public class ScrollableControl : Control, IComponent, IDisposable
    {
        #region Constructors
        public ScrollableControl() {  }
        #endregion

        #region Properties
        public override Rectangle DisplayRectangle { get { throw new NotImplementedException(); } }

        [BrowsableAttribute(false)]
        public HScrollProperties HorizontalScroll { get { throw new NotImplementedException(); } }

        protected bool HScroll { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        [BrowsableAttribute(false)]
        public VScrollProperties VerticalScroll { get { throw new NotImplementedException(); } }

        protected bool VScroll { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        #endregion

        #region Methods
        protected virtual void AdjustFormScrollbars(bool displayScrollbars) { throw new NotImplementedException(); }
        protected override void OnMouseWheel(MouseEventArgs e) { throw new NotImplementedException(); }
        protected virtual void OnScroll(ScrollEventArgs se) { throw new NotImplementedException(); }
        protected override void OnVisibleChanged(EventArgs e) { throw new NotImplementedException(); }
        protected void SetDisplayRectLocation(int x, int y) { throw new NotImplementedException(); }
        #endregion

        #region Events
        public event ScrollEventHandler Scroll;
        #endregion

        // These are not the fields you're looking for.
        #region Fields
        // Accualy is Dolan
        //protected const int ScrollStateHScrollVisible;
        //protected const int ScrollStateUserHasScrolled;
        //protected const int ScrollStateVScrollVisible;
        #endregion
    }
}
