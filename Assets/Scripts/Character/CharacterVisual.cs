using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVisual : MonoBehaviour {

    [SerializeField]
    private Character _character;
    public Character Character
    {
        get
        {
            if (_character == null)
                _character = GetComponentInParent<Character>();
            return _character;
        }
    }

    [SerializeField]
    private Animator _animator;
    public Animator Animator
    {
        get
        {
            if (_animator == null)
                _animator = GetComponent<Animator>();
            return _animator;
        }
    }

    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    public SpriteRenderer SpriteRenderer
    {
        get
        {
            if (_spriteRenderer == null)
                _spriteRenderer = GetComponent<SpriteRenderer>();
            return _spriteRenderer;
        }
    }

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

    #region Variables

    private float _rightWalkDistance;
    public float RightWalkDistance
    {
        get { return _rightWalkDistance; }
        set { _rightWalkDistance = value; }
    }

    private float _distanceFromBottom;
    public float DistanceFromBottom
    {
        get { return _distanceFromBottom; }
        set { _distanceFromBottom = value; }
    }

#endregion

    public void ToggleLineRenderer(bool toggle)
    {
        LineRenderer.enabled = toggle;
    }

    public void SetLineDirection(Vector2 direction)
    {
        LineRenderer.SetPosition(0, Vector2.zero);
        LineRenderer.SetPosition(0, direction.normalized * TransfertManager.Instance.Radius);
    }

    public void SetFloat(string name, float value)
    {
        if(Animator != null)
            Animator.SetFloat(name, value);
    }

    private void Update()
    {
        if(SpriteRenderer != null)
        {
            SetFloat("Walk", Mathf.Abs(RightWalkDistance));
            SetFloat("DistanceBottom", DistanceFromBottom);
            if (RightWalkDistance > 0f)
                SpriteRenderer.flipX = false;
            else if (RightWalkDistance < 0f)
                SpriteRenderer.flipX = true;
        }
        
    }

}
