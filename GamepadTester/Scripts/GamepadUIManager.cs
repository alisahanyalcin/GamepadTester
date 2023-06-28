using TMPro;
using UnityEngine;

namespace GamepadTester
{
    public class GamepadUIManager : MonoBehaviour
    {
        public TMP_Text gamepadName;
        public TMP_Text gamepadDescription;
        
        [Header("Colors")]
        public Color normalColor;
        public Color activeColor;
        
        [Header("Gamepad D-Pad")]
        public GamepadButton dpadUpButton;
        public GamepadButton dpadDownButton;
        public GamepadButton dpadRightButton;
        public GamepadButton dpadLeftButton;
        
        [Header("Gamepad Buttons")]
        public GamepadButton buttonNorthButton;
        public GamepadButton buttonSouthButton;
        public GamepadButton buttonEastButton;
        public GamepadButton buttonWestButton;
        
        [Header("Gamepad Misc")]
        public GamepadButton touchpadButton;
        public GamepadButton optionsButton;
        public GamepadButton shareButton;

        [Header("Right Trigger / Bumper")]
        public GamepadButton rightTrigger;
        public GamepadButton rightBumper;

        [Header("Left Trigger / Bumper")]
        public GamepadButton leftTrigger;
        public GamepadButton leftBumper;

        [Header("Gamepad Right Stick")]
        public GamepadButton rightStick;
        public GamepadButton rightStickX;
        public GamepadButton rightStickY;
        public GamepadButton rightStickButton;

        [Header("Gamepad Left Stick")]
        public GamepadButton leftStick;
        public GamepadButton leftStickX;
        public GamepadButton leftStickY;
        public GamepadButton leftStickButton;
    }  
}