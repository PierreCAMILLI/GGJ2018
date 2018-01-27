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
        SetFloat("Walk", Mathf.Abs(Character.RightWalkDistance));
        if (Character.RightWalkDistance > 0f)
            SpriteRenderer.flipX = false;
        else if (Character.RightWalkDistance < 0f)
            SpriteRenderer.flipX = true;
    }

}
