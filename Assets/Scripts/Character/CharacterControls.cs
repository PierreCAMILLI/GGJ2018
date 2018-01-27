using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterControls : MonoBehaviour {

    [SerializeField]
    private Character _character;
	public Character Character
    {
        get {
            if (_character == null)
                _character = GetComponent<Character>();
            return _character;
        }
    }

    [SerializeField]
    private bool _canWalk = true;
    public bool CanWalk
    {
        get { return _canWalk; }
        set { _canWalk = value; }
    }

    [SerializeField]
    private bool _canJump = true;
    public bool CanJump
    {
        get { return _canJump; }
        set { _canJump = value; }
    }

    // Update is called once per frame
    void Update () {
        Controls.PlayerControls controls = Controls.Instance.Player();

        if(_canWalk && !controls.Transfert)
            Character.Walk(controls.Right);

        if (_canJump && controls.JumpDown)
            Character.Jump();
	}
}
