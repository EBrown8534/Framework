using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [DefaultBindingProperty("Text")]
    public class Label : Control
    {
        #region Constructors
        public Label()
        {
            DefaultBindingPropertyAttribute defaultBindingAttribute = (DefaultBindingPropertyAttribute)Attribute.GetCustomAttribute(typeof(Label), typeof(DefaultBindingPropertyAttribute));

            if (defaultBindingAttribute != null)
            {
                Text = defaultBindingAttribute.Name;
            }
        }
        #endregion

        #region Properties
        [Browsable(true)]
        public bool AutoEllipsis { get; set; }

        [SettingsBindable(true)]
        public override string Text { get; set; }
        #endregion
    }
}
