using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;

namespace GamepadTester
{
    public class GamepadManager : MonoBehaviour
    {
        public UnityAction OnGamepadButtonClicked;
        public UnityAction OnGamepadButtonReleased;
        
        [SerializeField] private GamepadUIManager gamepadUiManager;
        [SerializeField] private bool isGamepadConnected = false;
        private Gamepad _gamepad;

        [Header("Gamepad D-Pad")] 
        [ReadOnly] public float dpadUp;
        [ReadOnly] public float dpadDown;
        [ReadOnly] public float dpadRight;
        [ReadOnly] public float dpadLeft;

        [Header("Gamepad Right Stick")]
        [ReadOnly] public Vector2 rightStick;
        [ReadOnly] public float rightStickX;
        [ReadOnly] public float rightStickY;
        [ReadOnly] public float rightStickButton;

        [Header("Gamepad Left Stick")]
        [ReadOnly] public Vector2 leftStick;
        [ReadOnly] public float leftStickX;
        [ReadOnly] public float leftStickY;
        [ReadOnly] public float leftStickButton;

        [Header("Gamepad Buttons")] 
        [ReadOnly] public float buttonNorth;
        [ReadOnly] public float buttonSouth;
        [ReadOnly] public float buttonEast;
        [ReadOnly] public float buttonWest;

        [Header("Right Trigger / Bumper")]
        [ReadOnly] public float rightBumper;
        [ReadOnly] public float rightTrigger;

        [Header("Left Trigger / Bumper")]
        [ReadOnly] public float leftTrigger;
        [ReadOnly] public float leftBumper;

        [Header("Gamepad Misc")]
        [ReadOnly] public float touchpadButton;
        [ReadOnly] public float optionsButton;
        [ReadOnly] public float shareButton;

        [Header("Gamepad Vibration")]
        public bool useDuration = false;
        public bool vibrationEnabled = false;
        [Range(0f, 1f)] public float vibrationDuration = 0.5f;
        [Range(0f, 1f)] public float lowFrequency = 1f;
        [Range(0f, 1f)] public float highFrequency = 1f;

        private void Awake()
        {
            _gamepad = Gamepad.current;
        }

        private void Start()
        {
            /*Debug.Log(Gamepad.current.name);
            Debug.Log(Gamepad.current.displayName);
            Debug.Log(Gamepad.current.description);*/
                
            gamepadUiManager.gamepadName.text = Gamepad.current.name + " (" + Gamepad.current.displayName + ")";
            gamepadUiManager.gamepadDescription.text = Gamepad.current.description + "";
        }

        private void Update()
        {
            CheckGamepadConnection();
        }

        private void CheckGamepadConnection()
        {
            if (_gamepad != null)
            {
                isGamepadConnected = true;

                dpadUp = Gamepad.current.dpad.up.ReadValue();
                dpadDown = Gamepad.current.dpad.down.ReadValue();
                dpadLeft = Gamepad.current.dpad.left.ReadValue();
                dpadRight = Gamepad.current.dpad.right.ReadValue();

                rightStick = Gamepad.current.rightStick.ReadValue();
                rightStickX = Gamepad.current.rightStick.x.ReadValue();
                rightStickY = Gamepad.current.rightStick.y.ReadValue();
                rightStickButton = Gamepad.current.rightStickButton.ReadValue();

                leftStick = Gamepad.current.leftStick.ReadValue();
                leftStickX = Gamepad.current.leftStick.x.ReadValue();
                leftStickY = Gamepad.current.leftStick.y.ReadValue();
                leftStickButton = Gamepad.current.leftStickButton.ReadValue();

                buttonNorth = Gamepad.current.buttonNorth.ReadValue();
                buttonSouth = Gamepad.current.buttonSouth.ReadValue();
                buttonEast = Gamepad.current.buttonEast.ReadValue();
                buttonWest = Gamepad.current.buttonWest.ReadValue();

                leftTrigger = Gamepad.current.leftTrigger.ReadValue();
                leftBumper = Gamepad.current.leftShoulder.ReadValue();
                
                rightTrigger = Gamepad.current.rightTrigger.ReadValue();
                rightBumper = Gamepad.current.rightShoulder.ReadValue();
                
                optionsButton = Gamepad.current.startButton.ReadValue();
                shareButton = Gamepad.current.selectButton.ReadValue();
                touchpadButton = DualShockGamepad.current.touchpadButton.ReadValue();
                
                Vibrate();
                
                gamepadUiManager.dpadUpButton.SetSliderValue(dpadUp);
                gamepadUiManager.dpadDownButton.SetSliderValue(dpadDown);
                gamepadUiManager.dpadLeftButton.SetSliderValue(dpadLeft);
                gamepadUiManager.dpadRightButton.SetSliderValue(dpadRight);
                
                gamepadUiManager.buttonNorthButton.SetSliderValue(buttonNorth);
                gamepadUiManager.buttonSouthButton.SetSliderValue(buttonSouth);
                gamepadUiManager.buttonEastButton.SetSliderValue(buttonEast);
                gamepadUiManager.buttonWestButton.SetSliderValue(buttonWest);
                
                gamepadUiManager.touchpadButton.SetSliderValue(touchpadButton);
                gamepadUiManager.optionsButton.SetSliderValue(optionsButton);
                gamepadUiManager.shareButton.SetSliderValue(shareButton);
                
                gamepadUiManager.rightBumper.SetSliderValue(rightBumper);
                gamepadUiManager.rightTrigger.SetSliderValue(rightTrigger);
                
                gamepadUiManager.leftBumper.SetSliderValue(leftBumper);
                gamepadUiManager.leftTrigger.SetSliderValue(leftTrigger);
                
                gamepadUiManager.leftStick.SetStickValue(leftStick);
                gamepadUiManager.leftStickX.SetSliderValue(leftStickX);
                gamepadUiManager.leftStickY.SetSliderValue(leftStickY);
                gamepadUiManager.leftStickButton.SetSliderValue(leftStickButton);
                
                gamepadUiManager.rightStick.SetStickValue(rightStick);
                gamepadUiManager.rightStickX.SetSliderValue(rightStickX);
                gamepadUiManager.rightStickY.SetSliderValue(rightStickY);
                gamepadUiManager.rightStickButton.SetSliderValue(rightStickButton);
            }
            else
            {
                isGamepadConnected = false;
            }
        }
        
        public void VibrateGamepad()
        {
            vibrationEnabled = !vibrationEnabled;
        }

        private void Vibrate()
        {
            if (vibrationEnabled)
            {
                if (useDuration)
                {
                    StartCoroutine(VibrateWithDuration());
                }
                else
                {
                    Gamepad.current.SetMotorSpeeds(lowFrequency, highFrequency);
                }
            }
            else
            {
                Gamepad.current.SetMotorSpeeds(0f, 0f);
            }
        }

        private IEnumerator VibrateWithDuration()
        {
            Gamepad.current.SetMotorSpeeds(lowFrequency, highFrequency);
            yield return new WaitForSeconds(vibrationDuration);
            vibrationEnabled = false;
        }
    }
}