using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        KeyCode[] _jumpKeycode;
        [SerializeField]
        KeyCode[] _transferKeycode;

        Vector2 _lastDirection;

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

        public Vector2 LastDirection
        {
            get { return _lastDirection; }
        }

        public bool JumpDown
        {
            get { return _jumpKeycode.Any(x => Input.GetKeyDown(x)); }
        }

        public bool TransfertDown
        {
            get { return _transferKeycode.Any(x => Input.GetKeyDown(x)); }
        }

        public bool Transfert
        {
            get { return _transferKeycode.Any(x => Input.GetKey(x)); }
        }

        public bool TransfertUp
        {
            get { return _transferKeycode.Any(x => Input.GetKeyUp(x)); }
        }

        public void Update()
        {
            if (Direction != Vector2.zero)
                _lastDirection = Direction;
            else if (_lastDirection == Vector2.zero)
                _lastDirection = Vector2.right;
        }
    }

    void Update()
    {
        _players.ForEach(p => p.Update());
    }
}
