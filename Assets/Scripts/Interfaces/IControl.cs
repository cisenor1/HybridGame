using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controls
{
    interface IControl
    {
        string ControlType { get; }
        int Index { get; }

        int XAxis();
        int YAxis();
        bool EnterDoor();
        bool ActionButtonPressed();
        bool ActionButton();
        bool ActionButtonReleased();
        bool RunButtonPressed();
        bool RunButton();
        bool RunButtonReleased();
        bool JumpButtonPressed();
        bool JumpButton();
        bool JumpButtonReleased();
        bool ShootButtonPressed();
        bool ShootButton();
        bool ShootButtonReleased();
        bool PausePressed();
        bool Pause();
        bool PauseReleased();
        bool NextButton();
        bool PrevButton();
        bool MenuButtonPressed();
        bool MenuButton();
        bool MenuButtonReleased();
    }
}
