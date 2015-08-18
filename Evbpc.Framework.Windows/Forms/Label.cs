using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    [ComVisibleAttribute(true)]
    [ClassInterfaceAttribute(ClassInterfaceType.AutoDispatch)]
    [DefaultBindingPropertyAttribute("Text")]
    public class Label : Control
    {
        #region Constructors
        public Label()
        {
            DefaultBindingPropertyAttribute defaultBindingAttribute =
            (DefaultBindingPropertyAttribute)Attribute.GetCustomAttribute(typeof(Label), typeof(DefaultBindingPropertyAttribute));

            if (defaultBindingAttribute != null)
                this.Text = defaultBindingAttribute.Name;
        }
        #endregion

        #region Properties
        [BrowsableAttribute(true)]
        public bool AutoEllipsis { get; set; }

        [SettingsBindableAttribute(true)]
        public override string Text { get; set; }
        #endregion
    }
}
