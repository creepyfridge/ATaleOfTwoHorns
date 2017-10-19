using UnityEngine;
using System.Collections;

public static class InputManager
{
    public enum InputTypes
    {
        Keyboard,
        Gamepad1,
        Gamepad2
    };
    public static InputTypes _playerOne = InputTypes.Gamepad1;
    public static InputTypes _playerTwo = InputTypes.Gamepad2;


    #region Movement
    static Vector2 _movement = new Vector2();
    public static Vector2 getMovement(InputTypes player)
    {
        switch (player)
        {
            case InputTypes.Keyboard:
                _movement = Vector2.zero;

                if (Input.GetKey(KeyCode.W))
                    _movement.y = 1;

                if (Input.GetKey(KeyCode.S))
                    _movement.y -= 1;

                if (Input.GetKey(KeyCode.D))
                    _movement.x = 1;

                if (Input.GetKey(KeyCode.A))
                    _movement.x -= 1;
                return _movement;
            case InputTypes.Gamepad1:
                return GamepadInput.GamePad.GetAxis(GamepadInput.GamePad.Axis.LeftStick, GamepadInput.GamePad.Index.One);
            case InputTypes.Gamepad2:
                return GamepadInput.GamePad.GetAxis(GamepadInput.GamePad.Axis.LeftStick, GamepadInput.GamePad.Index.Two);

        };
        return Vector2.zero;
    }

    #region Jump
    public static bool getJumpDown(InputTypes player)
    {
        switch (player)
        {
            case InputTypes.Keyboard:
                return Input.GetKeyDown(KeyCode.Space);
            case InputTypes.Gamepad1:
                return GamepadInput.GamePad.GetButtonDown(GamepadInput.GamePad.Button.A, GamepadInput.GamePad.Index.One);
            case InputTypes.Gamepad2:
                return GamepadInput.GamePad.GetButtonDown(GamepadInput.GamePad.Button.A, GamepadInput.GamePad.Index.Two);

        };
        return false;
    }

    public static bool getJump(InputTypes player)
    {
        switch (player)
        {
            case InputTypes.Keyboard:
                return Input.GetKey(KeyCode.Space);
            case InputTypes.Gamepad1:
                return GamepadInput.GamePad.GetButton(GamepadInput.GamePad.Button.A, GamepadInput.GamePad.Index.One);
            case InputTypes.Gamepad2:
                return GamepadInput.GamePad.GetButton(GamepadInput.GamePad.Button.A, GamepadInput.GamePad.Index.Two);
        };
        return false;
        
    }

    public static bool getJumpUp(InputTypes player)
    {
        switch (player)
        {
            case InputTypes.Keyboard:
                return Input.GetKeyUp(KeyCode.Space);
            case InputTypes.Gamepad1:
                return GamepadInput.GamePad.GetButtonUp(GamepadInput.GamePad.Button.A, GamepadInput.GamePad.Index.One);
            case InputTypes.Gamepad2:
                return GamepadInput.GamePad.GetButtonUp(GamepadInput.GamePad.Button.A, GamepadInput.GamePad.Index.Two);
        };
        return false;
        
    }
    #endregion

    #region Dash
    public static bool getDashDown(InputTypes player)
    {
        switch (player)
        {
            case InputTypes.Keyboard:
                return Input.GetKeyDown(KeyCode.LeftShift);
            case InputTypes.Gamepad1:
                return GamepadInput.GamePad.GetButtonDown(GamepadInput.GamePad.Button.X, GamepadInput.GamePad.Index.One);
            case InputTypes.Gamepad2:
                return GamepadInput.GamePad.GetButtonDown(GamepadInput.GamePad.Button.X, GamepadInput.GamePad.Index.Two);

        };
        return false;
    }

    public static bool getDash(InputTypes player)
    {
        switch (player)
        {
            case InputTypes.Keyboard:
                return Input.GetKey(KeyCode.LeftShift);
            case InputTypes.Gamepad1:
                return GamepadInput.GamePad.GetButton(GamepadInput.GamePad.Button.X, GamepadInput.GamePad.Index.One);
            case InputTypes.Gamepad2:
                return GamepadInput.GamePad.GetButton(GamepadInput.GamePad.Button.X, GamepadInput.GamePad.Index.Two);
        };
        return false;

    }

    public static bool getDashUp(InputTypes player)
    {
        switch (player)
        {
            case InputTypes.Keyboard:
                return Input.GetKeyUp(KeyCode.LeftShift);
            case InputTypes.Gamepad1:
                return GamepadInput.GamePad.GetButtonUp(GamepadInput.GamePad.Button.X, GamepadInput.GamePad.Index.One);
            case InputTypes.Gamepad2:
                return GamepadInput.GamePad.GetButtonUp(GamepadInput.GamePad.Button.X, GamepadInput.GamePad.Index.Two);
        };
        return false;

    }
    #endregion
    #endregion

    #region Fire

    const float FIRE_THRESHOLD = 2.0f;
    public static bool getFire(InputTypes player)
    {
        switch (player)
        {
            case InputTypes.Keyboard:
                return Input.GetMouseButton(0);
            case InputTypes.Gamepad1:
                return GamepadInput.GamePad.GetTrigger(GamepadInput.GamePad.Trigger.RightTrigger, GamepadInput.GamePad.Index.One) > FIRE_THRESHOLD;
            case InputTypes.Gamepad2:
                return GamepadInput.GamePad.GetTrigger(GamepadInput.GamePad.Trigger.RightTrigger, GamepadInput.GamePad.Index.Two) > FIRE_THRESHOLD;

        };
        return false;
    }
    #endregion

    #region Aiming
    static Vector2 _aim = new Vector2();
    public static Vector2 getAim(InputTypes player)
    {
        switch (player)
        {
            case InputTypes.Keyboard:
                _aim.x = Input.mousePosition.x - (Screen.width / 2.0f);
                _aim.y = Input.mousePosition.y - (Screen.height / 2.0f);
                return _aim;
            case InputTypes.Gamepad1:
                return GamepadInput.GamePad.GetAxis(GamepadInput.GamePad.Axis.RightStick, GamepadInput.GamePad.Index.One);
            case InputTypes.Gamepad2:
                return GamepadInput.GamePad.GetAxis(GamepadInput.GamePad.Axis.RightStick, GamepadInput.GamePad.Index.Two);

        };
        return Vector2.zero;
    }
#endregion
    /*
    menu hot keys
    menu clicks
    */
}
