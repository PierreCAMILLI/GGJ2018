﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    private static Character ControlledCharacter
    {
        get { return null; }
    }

    #region Getter

    [SerializeField]
    private Rigidbody2D _rigidbody;
    public Rigidbody2D Rigidbody
    {
        get
        {
            if (_rigidbody == null)
                _rigidbody = GetComponent<Rigidbody2D>();
            return _rigidbody;
        }
    }

    [SerializeField]
    private Transform _raycastOrigin;

    [SerializeField]
    private LayerMask _characterLayer;

    public bool TouchGround
    {
        // TODO: Check if character touches ground
        get { return true; }
    }

#endregion

    #region Variables
    [SerializeField]
    private float _speed;
    public float Speed
    {
        get { return _speed; }
    }

    [SerializeField]
    private float _jumpPower;
    public float JumpPower
    {
        get { return _jumpPower; }
    }
    #endregion

#region Actions

    public void Walk(Vector2 dir, bool scaled = true)
    {
        transform.Translate(dir * (scaled ? Time.deltaTime : 1f));
    }

    public void Jump()
    {
        if (TouchGround)
        {
            Rigidbody.AddForce(new Vector2(0f, JumpPower));
        }
    }

    /// <summary>
    /// Returns close character
    /// </summary>
    /// <param name="dir"></param>
    /// <param name="radius"></param>
    /// <returns></returns>
    public Character TargetCharacter(Vector2 dir, float radius)
    {
        Character character = null;
        RaycastHit2D hit;
        if (hit = Physics2D.Raycast(_raycastOrigin.position, dir, radius, _characterLayer))
        {
            character = hit.transform.GetComponent<Character>();
        }
        return character;
    }

#endregion


    #region Unity Functions
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
#endregion
}
