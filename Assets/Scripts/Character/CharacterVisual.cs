using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVisual : MonoBehaviour {

    [SerializeField]
    private Transform _head;

    [SerializeField]
    private LineRenderer _lineRenderer;
    public LineRenderer LineRenderer
    {
        get
        {
            if (_lineRenderer == null)
                _head.GetComponent<LineRenderer>();
            return _lineRenderer;
        }
    }

    public void ToggleLineRenderer(bool toggle)
    {
        LineRenderer.enabled = toggle;
    }

    public void SetLineDirection(Vector2 direction)
    {
        LineRenderer.SetPosition(0, Vector2.zero);
        LineRenderer.SetPosition(0, direction.normalized * TransfertManager.Instance.Radius);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
