using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

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
    private CharacterVisual _visual;
    public CharacterVisual Visual
    {
        get
        {
            if (_visual == null)
                _visual = GetComponentInChildren<CharacterVisual>();
            return _visual;
        }
    }

    [SerializeField]
    private CharacterControls _characterControls;
    public CharacterControls CharacterControls
    {
        get
        {
            if (_characterControls == null)
                _characterControls = GetComponent<CharacterControls>();
            return _characterControls;
        }
    }

    [SerializeField]
    private SpriteBounds _spriteBounds;
    public SpriteBounds SpriteBounds
    {
        get
        {
            if (_spriteBounds == null)
                _spriteBounds = GetComponent<SpriteBounds>();
            return _spriteBounds;
        }
    }

    [SerializeField]
    private Transform _raycastOrigin;
    public Transform RaycastOrigin
    {
        get { return _raycastOrigin; }
    }

    [SerializeField]
    private LayerMask _characterLayer;

    public bool TouchGround
    {
        get { return SpriteBounds.DistanceFrom(SpriteBounds.Direction.Bottom) < 0.02f; ; }
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
    private float _jumpPower = 1f;
    public float JumpPower
    {
        get { return _jumpPower; }
    }
    [SerializeField]
    private int _maxJump = 1;
    public int MaxJump
    {
        get { return _maxJump; }
    }
    private int _jumpCount = 0;
    #endregion

#region Actions

    public void Walk(float dir, bool scaled = true)
    {
        transform.Translate(Vector2.right * _speed * dir * (scaled ? Time.deltaTime : 1f));
    }

    public void Jump()
    {
        if (_jumpCount < _maxJump)
        {
            Rigidbody.AddForce(new Vector2(0f, JumpPower), ForceMode2D.Impulse);
            transform.Translate(0.0f, 0.03f, 0.0f);
            ++_jumpCount;
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
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(_raycastOrigin.position, dir, radius, _characterLayer);
        float minDist = Mathf.Infinity;
        foreach(RaycastHit2D hit in hits)
        {
            Character tempCharacter = hit.transform.GetComponent<Character>();
            if(tempCharacter != null && tempCharacter != this && hit.distance < minDist)
            {
                character = tempCharacter;
                minDist = hit.distance;
            }
        }
        return character;
    }

    public Character GetClosestCharacter(float radius)
    {
        Character closestCharacter = null;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_raycastOrigin.position, radius, _characterLayer);
        float minDistance = Mathf.Infinity;
        foreach(Collider2D collider in colliders)
        {
            Character tmpCharacter = null;
            float sqrMagnitude = Vector2.SqrMagnitude((Vector2)(transform.position - collider.transform.position));
            if ((sqrMagnitude < minDistance) && (tmpCharacter = collider.GetComponent<Character>()) && (tmpCharacter != this))
            {
                closestCharacter = tmpCharacter;
                minDistance = sqrMagnitude;
            }
        }
        return closestCharacter;
    }

#endregion


    #region Unity Functions
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (TouchGround)
            _jumpCount = 0;
	}
#endregion
}
