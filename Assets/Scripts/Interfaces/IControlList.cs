using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controls
{
    interface IControlList
    {
        IControl Player1();
        void AddControl(int index, IControl control);
    }
}
