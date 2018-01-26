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
        KeyCode _leftKey;

        public float Left
        {
            get { return Input.GetKey(_leftKey) ? 1.0f : 0f; }
        }

        public bool Jump
        {
            get { return Input.GetKey(KeyCode.UpArrow); }
        }
    }
}
