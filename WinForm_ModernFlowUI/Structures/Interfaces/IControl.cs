using ModernUI.Structures.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernUI.Structures.Interfaces
{
    internal interface IControl
    {

        #region Properties
        IStyleManager StyleManager { get; set; }
        #endregion


        #region Events
        event EventHandler BeforeStyleUpdate;
        event EventHandler StyleUpdated;
        #endregion

    }
}
