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

        private float Right
        {
            get { return Input.GetAxis(_horizontalAxis); }
        }
        private float Up
        {
            get { return Input.GetAxis(_verticalAxis); }
        }
        public Vector2 Direction
        {
            get { return new Vector2(Right, Up).normalized; }
        }

        public bool JumpDown
        {
            get { return false; }
        }

        public bool TransfertDown
        {
            get { return false; }
        }

    }
}
