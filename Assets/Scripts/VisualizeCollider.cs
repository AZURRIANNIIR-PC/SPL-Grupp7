using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VisualizeCollider : MonoBehaviour
{
    private Collider2D collider2D;

    void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }

    void OnDrawGizmos()
    {
        if (collider2D != null)
        {
            Gizmos.color = Color.green;
            if (collider2D is BoxCollider2D boxCollider)
            {
                DrawWireBox(boxCollider);
            }
            else if (collider2D is PolygonCollider2D polygonCollider)
            {
                DrawWirePolygon(polygonCollider);
            }
            else if (collider2D is CircleCollider2D circleCollider)
            {
                DrawWireCircle(circleCollider);
            }
        }
    }

    void DrawWireBox(BoxCollider2D boxCollider)
    {
        Vector2 size = boxCollider.size;
        Vector2 offset = boxCollider.offset;
        Vector2 min = (Vector2)transform.position + offset - size / 2f;
        Vector2 max = (Vector2)transform.position + offset + size / 2f;

        Gizmos.DrawLine(min, new Vector2(max.x, min.y));
        Gizmos.DrawLine(new Vector2(max.x, min.y), max);
        Gizmos.DrawLine(max, new Vector2(min.x, max.y));
        Gizmos.DrawLine(new Vector2(min.x, max.y), min);
    }

    void DrawWirePolygon(PolygonCollider2D polygonCollider)
    {
        Vector2[] points = polygonCollider.points;
        Vector2 offset = polygonCollider.offset;

        for (int i = 0; i < points.Length - 1; i++)
        {
            Gizmos.DrawLine((Vector2)transform.position + points[i] + offset, (Vector2)transform.position + points[i + 1] + offset);
        }

        // Connect the last point to the first point to close the polygon
        Gizmos.DrawLine((Vector2)transform.position + points[points.Length - 1] + offset, (Vector2)transform.position + points[0] + offset);
    }

    void DrawWireCircle(CircleCollider2D circleCollider)
    {
        Vector2 offset = circleCollider.offset;
        float radius = circleCollider.radius;

        int segments = 36;
        float angleIncrement = 360f / segments;

        Vector2 prevPoint = Vector2.zero;
        for (int i = 0; i <= segments; i++)
        {
            float angle = Mathf.Deg2Rad * i * angleIncrement;
            Vector2 point = new Vector2(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius);
            if (i > 0)
            {
                Gizmos.DrawLine((Vector2)transform.position + prevPoint + offset, (Vector2)transform.position + point + offset);
            }
            prevPoint = point;
        }
    }
}


