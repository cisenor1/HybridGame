using System;
using UnityEngine;

namespace Controls
{
    class SNES8Bitdo : IControl
    {
        private const string Y_AXIS = "axis 1";
        private const string X_AXIS = "axis 0";
        private const int SELECT = 10;
        private const int START = 11;
        private const int A_BUTTON = 0;
        private const int B_BUTTON = 1;
        private const int X_BUTTON = 3;
        private const int Y_BUTTON = 4;
        private const int L_BUTTON = 6;
        private const int R_BUTTON = 7;
        public readonly int[] BUTTONS = {
            A_BUTTON,
            B_BUTTON,
            X_BUTTON,
            Y_BUTTON,
            L_BUTTON,
            R_BUTTON,
            SELECT,
            START,
        };

        private string _controlName = "Controller (SNES30 Joy    )";
        private string _controlType;
        private int _index;
        private Input _input;

        public SNES8Bitdo()
        {
            var allNames = Input.GetJoystickNames();

            for (int i = 0; i < allNames.Length; i++)
            {
                
                var controlName = allNames[i];
                if (_controlName.Equals(controlName))
                {
                    _index = i + 1; // Joysticks are 1-indexed.
                    _controlType = String.Format("joystick {0}", _index);
                    break;
                }
            }
            if (_controlType == null) throw new UnityException("No Controller Found.");
        }

        public string ControlType
        {
            get
            {
                return this._controlType;
            }
        }

        public int Index
        {
            get
            {
                return this._index;
            }
        }

        public bool ActionButtonPressed()
        {
            return ButtonDown(A_BUTTON);

        }

        public bool ActionButton()
        {
            return Button(A_BUTTON);
        }

        public bool ActionButtonReleased()
        {
            return ButtonUp(A_BUTTON);
        }

        public bool EnterDoor()
        {
            return YAxis().Equals(1);
        }

        public bool JumpButtonPressed()
        {
            return ButtonDown(B_BUTTON); 
        }

        public bool JumpButton()
        {
            return Button(B_BUTTON);
        }

        public bool JumpButtonReleased()
        {
            return ButtonUp(B_BUTTON);
        }

        public bool NextButton()
        {
            return Button(SELECT);
        }

        public bool PausePressed()
        {
            return ButtonDown(START);
        }

        public bool Pause()
        {
            return Button(START);
        }

        public bool PauseReleased()
        {
            return ButtonUp(START);
        }

        public bool PrevButton()
        {
            return Button(B_BUTTON);
        }

        public bool RunButtonPressed()
        {
            return ButtonDown(Y_BUTTON);
        }

        public bool RunButton()
        {
            return Button(Y_BUTTON);
        }

        public bool RunButtonReleased()
        {
            return ButtonUp(Y_BUTTON);
        }

        public bool ShootButtonPressed()
        {
            return ButtonDown(Y_BUTTON);
        }

        public bool ShootButton()
        {
            return Button(Y_BUTTON);
        }

        public bool ShootButtonReleased()
        {
            return ButtonUp(Y_BUTTON);
        }

        public int XAxis()
        {
            return Mathf.RoundToInt(Input.GetAxis(String.Format("{0} {1}", _controlType, X_AXIS)));
        }

        public int YAxis()
        {
            return Mathf.RoundToInt(Input.GetAxis(String.Format("{0} {1}", _controlType, Y_AXIS)));
        }

        public bool MenuButtonPressed()
        {
            return Button(X_BUTTON);
        }

        public bool MenuButton()
        {
            return Button(X_BUTTON);
        }

        public bool MenuButtonReleased()
        {
            return ButtonUp(X_BUTTON);
        }

        private string ButtonName(int buttonId)
        {
            return String.Format("{0} button {1}", _controlType, buttonId);
        }

        private bool ButtonDown(int buttonId)
        {
            return Input.GetKeyDown(ButtonName(buttonId));
        }

        private bool ButtonUp(int buttonId)
        {
            return Input.GetKeyUp(ButtonName(buttonId));
        }

        private bool Button(int buttonId)
        {
            return Input.GetKey(ButtonName(buttonId));
        }

        public override string ToString()
        {
            return String.Format("Inside " + _controlName +
                "Pressed:{0}" +
                "X-Axis: " + XAxis() + "{0}" +
                "Y-Axis: " + YAxis() + "{0}" +
                "A: " + ButtonDown(A_BUTTON) + "{0}" +
                "B: " + ButtonDown(B_BUTTON) + "{0}" +
                "X: " + ButtonDown(X_BUTTON) + "{0}" +
                "Y: " + ButtonDown(Y_BUTTON) + "{0}" +
                "START: " + ButtonDown(START) + "{0}" +
                "SELECT: " + ButtonDown(SELECT) + "{0}" +
                "Down:{0}" +
                "A: " + Button(A_BUTTON) + "{0}" +
                "B: " + Button(B_BUTTON) + "{0}" +
                "X: " + Button(X_BUTTON) + "{0}" +
                "Y: " + Button(Y_BUTTON) + "{0}" +
                "START: " + Button(START) + "{0}" +
                "SELECT: " + Button(SELECT) + "{0}" +
                "Released:{0}" +
                "A: " + ButtonUp(A_BUTTON) + "{0}" +
                "B: " + ButtonUp(B_BUTTON) + "{0}" +
                "X: " + ButtonUp(X_BUTTON) + "{0}" +
                "Y: " + ButtonUp(Y_BUTTON) + "{0}" +
                "START: " + ButtonUp(START) + "{0}" +
                "SELECT: " + ButtonUp(SELECT) + "{0}", " ");
        }
    }
}
