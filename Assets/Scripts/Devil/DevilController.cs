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

    private Vector2 _lastDirection;

	// Use this for initialization
	void Start () {
        _lastDirection = Vector2.right;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Controls.PlayerControls controls = Controls.Instance.Player();

        if (controls.TransfertDown)
        {
            Devil.ToggleBulletTime(true);
        }
        if (controls.Transfert)
        {
            bool isActive = TransfertManager.Instance.BulletTimeIsActive;
            Devil.ControlledCharacter.Visual.ToggleLineRenderer(isActive);
            Devil.ControlledCharacter.Visual.SetLineDirection(controls.LastDirection);
        }
        if (controls.TransfertUp)
        {
            Devil.ControlledCharacter.Visual.ToggleLineRenderer(false);
            if(TransfertManager.Instance.BulletTimeIsActive)
                Devil.ChangeBody(controls.LastDirection);
            Devil.ToggleBulletTime(false);
        }   
	}
}
