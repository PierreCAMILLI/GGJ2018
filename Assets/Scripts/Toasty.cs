using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toasty : MonoBehaviour {

    [SerializeField]
    private AudioSource _sound;

    [SerializeField]
    private Vector3 _showPosition;

    [SerializeField]
    private float _timeShown = 3;

    private Vector3 _target;
    private Vector3 _originalPosition;
    private Vector3 _velocity;

	// Use this for initialization
	void Start () {
        _target = _originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.SmoothDamp(transform.position, _target, ref _velocity, 0.25f, Mathf.Infinity, Time.deltaTime);
	}

    public void Show()
    {
        StopAllCoroutines();
        _target = _showPosition;
        if(_sound != null)
            _sound.Play();
        StartCoroutine(Hide());
    }

    private IEnumerator Hide()
    {
        yield return new WaitForSeconds(_timeShown);
        _target = _originalPosition;
    }
}
