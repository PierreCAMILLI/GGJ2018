using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Devil))]
public class DevilController : MonoBehaviour {

    private Devil _devil;
    public Devil Devil
    {
        get
        {
            if (_devil == null)
                _devil = GetComponent<Devil>();
            return _devil;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Controls.PlayerControls controls = Controls.Instance.Player();

        if (controls.Transfert)
        {
            Devil.ControlledCharacter.Visual.ToggleLineRenderer(true);
            Devil.ControlledCharacter.Visual.SetLineDirection(controls.Direction);
        }
        if (controls.TransfertUp)
        {
            Devil.ControlledCharacter.Visual.ToggleLineRenderer(false);
            Devil.ChangeBody(controls.Direction);
        }   
	}
}
