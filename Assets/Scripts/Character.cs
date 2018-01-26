using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    [SerializeField]
    private Vector3 _direction;

    [SerializeField]
    private float _speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += _direction.normalized * _speed * Time.deltaTime;
	}
}
