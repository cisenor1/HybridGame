using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ControlDebugScript : MonoBehaviour {
    // Slap this code onto an object in the scene then press buttons
    // I recommend you test with 3-4 controllers (different models) for best effect
    void Awake()
    {
        var names = new List<string>(Input.GetJoystickNames());
        Debug.Log("Connected Joysticks:");
        for (var i = 0; i < names.Count; i++) {
            Debug.Log("Joystick" + (i + 1) + " = " + names[i]);
        }
    }

    void Update()
    {
        DebugLogJoystickButtonPresses();
    }

    private void DebugLogJoystickButtonPresses() {
    var joyNum = 1; // start at 1 because unity calls them joystick 1 - 4
    var buttonNum = 1;
    var keyCode = 350; // start at joy 1 keycode
   
    // log button presses on 3 joysticks (20 button inputs per joystick)
        // NOTE THAT joystick 4 is not supported via keycodes for some reason, so only polling 1-3
    for(var i  = 0; i< 2; i++) {

            // Log any key press
        var code = String.Format("joystick 2 axis {0}", buttonNum);
            var raw = Input.GetAxis(code);
            Debug.Log(code + raw.ToString());
        if(raw != 0) Debug.Log("Pressed! Joystick " + joyNum + " Button " + buttonNum + " @ " + Time.time);
       
        buttonNum++; // Increment
       
        // Reset button count when we get to last joy button
        if(buttonNum == 2) {
            buttonNum = 0;
            joyNum++; // next joystick
        }
    }
}
}
