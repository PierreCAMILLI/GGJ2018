using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devil : SingletonBehaviour<Devil> {

    [SerializeField]
    private Transform _visual;

    [SerializeField]
    private bool isAlive = true;

    [SerializeField]
    private Character _controlledCharacter;
    public Character ControlledCharacter
    {
        get { return _controlledCharacter; }
    }

    [SerializeField]
    private float _smoothTime = 0.25f;

    private Vector2 _velocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CenterCamera();
		if(_controlledCharacter != null)
        {
            transform.position = Vector2.SmoothDamp(transform.position, _controlledCharacter.transform.position, ref _velocity, _smoothTime, Mathf.Infinity, Time.deltaTime);
            float sqrMagnitude = Vector2.SqrMagnitude(transform.position - _controlledCharacter.transform.position);
            _visual.gameObject.SetActive(sqrMagnitude > 2f);
        }
	}

    void CenterCamera()
    {
        Vector3 newPosition = transform.position;
        newPosition.z = Camera.main.transform.position.z;
        Camera.main.transform.position = newPosition;
    }

    public bool ToggleBulletTime(bool toggle)
    {
        return TransfertManager.Instance.ToggleBulletTime(toggle);
    }

    public void ChangeBody(Vector2 dir)
    {
        if(_controlledCharacter != null)
        {
            CharacterControls controller = _controlledCharacter.CharacterControls;
            Character newCharacter = _controlledCharacter.TargetCharacter(dir, TransfertManager.Instance.Radius);
            
            // Transfer succeeded
            if(newCharacter != null)
            {
                controller.enabled = false;
                _controlledCharacter = newCharacter;
                controller = _controlledCharacter.CharacterControls;
                controller.enabled = true;
            }
        }
        
    }
    private void IsAlive()
    {
        if (isAlive == false)
        {
            Debug.Log("controll undone");
            CharacterControls controller = _controlledCharacter.CharacterControls;
            controller.enabled = false;
        }
    }
}
