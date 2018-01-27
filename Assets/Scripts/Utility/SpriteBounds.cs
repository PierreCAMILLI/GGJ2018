using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SpriteBounds : MonoBehaviour {

    private SpriteRenderer _spriteRenderer;
    public SpriteRenderer spriteRenderer
    {
        get
        {
            if (_spriteRenderer == null)
                _spriteRenderer = GetComponent<SpriteRenderer>();
            return _spriteRenderer;
        }
    }

    private BoxCollider2D _boxCollider;
    public BoxCollider2D boxCollider
    {
        get
        {
            if (_boxCollider == null)
                _boxCollider = GetComponent<BoxCollider2D>();
            return _boxCollider;
        }
    }

    [SerializeField]
    private int _resolution = 1;
	public int resolution
    {
        get { return _resolution; }
    }

    [SerializeField]
    private LayerMask _collisionMask;

    public enum Direction
    {
        Top,
        Bottom,
        Left,
        Right
    }

    public float DistanceFrom(Direction direction)
    {
        if (resolution <= 0)
            return Mathf.Infinity;
        Vector2 dir;
        Vector2[] points = GetPoints(direction, out dir);

        float minDistance = Mathf.Infinity;
        foreach(Vector2 point in points)
        {
            RaycastHit2D hit;
            if (hit = Physics2D.Raycast(point, dir, Mathf.Infinity, _collisionMask))
            {
                minDistance = Mathf.Min(hit.distance, minDistance);
            }
        }

        return minDistance;
    }

    private void GetBoundStartAndEnd(Direction direction, out Vector2 start, out Vector2 end, out Vector2 dir)
    {
        start = Vector2.zero; end = Vector2.zero; dir = Vector2.zero;
        Bounds rect = boxCollider.bounds;
        switch (direction)
        {
            case Direction.Bottom:
                start = new Vector2(rect.min.x, rect.min.y);
                end = new Vector2(rect.max.x, rect.min.y);
                dir = Vector2.down;
                break;
            case Direction.Left:
                start = new Vector2(rect.min.x, rect.max.y);
                end = new Vector2(rect.min.x, rect.min.y);
                dir = Vector2.left;
                break;
            case Direction.Right:
                start = new Vector2(rect.max.x, rect.min.y);
                end = new Vector2(rect.max.x, rect.max.y);
                dir = Vector2.right;
                break;
            case Direction.Top:
                start = new Vector2(rect.max.x, rect.max.y);
                end = new Vector2(rect.min.x, rect.max.y);
                dir = Vector2.up;
                break;
        }
        //start += (Vector2) transform.position;
        //end += (Vector2) transform.position;
    }

    private Vector2[] GetPoints(Direction direction, out Vector2 dir)
    {
        Vector2 start, end;
        GetBoundStartAndEnd(direction, out start, out end, out dir);
        Vector2[] points = new Vector2[resolution];
        Vector2 step = (end - start) / (resolution + 1);
        for (int i = 0; i < resolution; ++i)
        {
            points[i] = start + step * (i + 1);
        }
        return points;
    }

    private void OnDrawGizmos()
    {
        if (resolution <= 0)
            return;
        Gizmos.color = Color.red;
        Vector2 dir;
        Vector2[] points = GetPoints(Direction.Bottom, out dir);
        foreach (Vector2 point in points)
            Gizmos.DrawSphere(point, 0.05f);
    }

}
