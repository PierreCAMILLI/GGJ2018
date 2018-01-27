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

    [SerializeField]
    private bool _autoLock = true;

    Vector2 _transferDirection;

    // Update is called once per frame
    void Update ()
    {
        Controls.PlayerControls controls = Controls.Instance.Player();

        if (controls.TransfertDown)
        {
            Devil.ToggleBulletTime(true);
            Character closestCharacter = null;
            if (_autoLock && (closestCharacter = Devil.ControlledCharacter.GetClosestCharacter(TransfertManager.Instance.Radius)))
            {
                _transferDirection = closestCharacter.transform.position - Devil.ControlledCharacter.RaycastOrigin.transform.position;
            }
            else
            {
                _transferDirection = controls.LastDirection;
            }
        }
        if (controls.Transfert)
        {
            if (controls.Direction != Vector2.zero)
                _transferDirection = controls.LastDirection;
            bool isActive = TransfertManager.Instance.BulletTimeIsActive;
            Devil.ControlledCharacter.Visual.ToggleLineRenderer(isActive);
            Devil.ControlledCharacter.Visual.SetLineDirection(_transferDirection);
        }
        if (controls.TransfertUp)
        {
            Devil.ControlledCharacter.Visual.ToggleLineRenderer(false);
            if(TransfertManager.Instance.BulletTimeIsActive)
                Devil.ChangeBody(_transferDirection);
            Devil.ToggleBulletTime(false);
        }
        if (controls.ResetUp)
            GameManager.Instance.ResetScene();
    }
}
