using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private float length;
    private Vector3 origin;
    [SerializeField]
    private float speed;

    private Vector2 _velocity;

	// Use this for initialization
	void Start () {
        origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float ping = Mathf.PingPong(Time.time * speed, length) - (length * 0.5f);
        Vector2 newPosition = origin + direction.normalized * ping;

        _velocity = newPosition - (Vector2) transform.position;
        transform.position = newPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, origin + (direction.normalized * length * 0.5f));
        Gizmos.DrawLine(origin, origin - (direction.normalized * length * 0.5f));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        collision.transform.Translate(_velocity);
    }
}
