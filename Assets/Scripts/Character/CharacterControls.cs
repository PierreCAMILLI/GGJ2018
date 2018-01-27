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

	// Update is called once per frame
	void Update () {
        Controls.PlayerControls controls = Controls.Instance.Player();

        Character.Walk(controls.Right);

        if (controls.JumpDown)
            Character.Jump();
	}
}
