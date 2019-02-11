using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controls
{
    class ControlList : IControlList
    {
        private static ControlList _controlList;
        public static ControlList Instance()
        {
            if (_controlList == null)
            {
                _controlList = new ControlList();
            }

            return _controlList;
        }
        
        private List<IControl> _controls = new List<IControl>();
        private string _player1ID;
        

        public void AddControl(int index, IControl control)
        {
            _controls.Insert(index, control);
        }
        public IControl Player1()
        {
            return this._controls.First();
        }

    }
}
