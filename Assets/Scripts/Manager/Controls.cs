using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : SingletonBehaviour<Controls> {

    [SerializeField]
    private List<PlayerControls> _players;
    public PlayerControls Player(int i = 0)
    {
        return _players[i];
    }

    [System.Serializable]
    public class PlayerControls
    {
        [SerializeField]
        string _horizontalAxis = "Horizontal";
        [SerializeField]
        string _verticalAxis = "Vertical";
        [SerializeField]
        KeyCode _jumpKeycode = KeyCode.JoystickButton0;
        [SerializeField]
        KeyCode _transferKeycode = KeyCode.JoystickButton1;

        public float Right
        {
            get { return Input.GetAxis(_horizontalAxis); }
        }
        public float Up
        {
            get { return Input.GetAxis(_verticalAxis); }
        }
        public Vector2 Direction
        {
            get { return new Vector2(Right, Up).normalized; }
        }

        public bool JumpDown
        {
            get { return Input.GetKeyDown(_jumpKeycode); }
        }

        public bool TransfertDown
        {
            get { return Input.GetKeyDown(_transferKeycode); }
        }

        public bool Transfert
        {
            get { return Input.GetKey(_transferKeycode); }
        }

        public bool TransfertUp
        {
            get { return Input.GetKeyUp(_transferKeycode); }
        }

    }
}
