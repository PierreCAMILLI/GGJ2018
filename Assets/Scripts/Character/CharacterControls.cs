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
    private bool _runner = false;
    public bool Runner
    {
        get { return _runner; }
        set { _runner = value; }
    }

    public enum Direction
    {
        LEFT,
        RIGHT
    }

    [SerializeField]
    private Direction _runnerDirection = Direction.RIGHT;
    public Direction RunnerDirection
    {
        get { return _runnerDirection; }
        set { _runnerDirection = value; }
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
        {
            if(_runner)
                Character.Walk(controls.LastDirection.x);
            else
                Character.Walk(controls.Right);
        }   

        if (_canJump && controls.JumpDown)
            Character.Jump();
	}

    private float DirectionToFloat(Direction dir)
    {
        switch (dir)
        {
            case Direction.LEFT:
                return 1f;
            case Direction.RIGHT:
                return -1f;
        }
        return 0f;
    }
}
