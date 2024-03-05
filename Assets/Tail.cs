using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tail : MonoBehaviour
{

    public float pointSpacing = 0.1f;
    public Transform snake;

    // we should have a list to keep our points
    // In order to make comparisons
    List<Vector2> points;

    private LineRenderer line;
    private EdgeCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        // Set a material for our line renderer so it can take color
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.widthMultiplier = 0.1f;

        col = GetComponent<EdgeCollider2D>();

        points = new List<Vector2>();

        SetPoint();
    }

    // Update is called once per frame
    void Update()
    {
        // If we have move for a reasonable distance so we can set a new point on line renderer
        if (Vector3.Distance(points.Last(), snake.position) > pointSpacing)
        {
            SetPoint();
        }
    }

    private void SetPoint()
    {
        // First we add the new point to our list so we can use it later
        points.Add(snake.position);
        // increase the position array count
        line.positionCount = points.Count;
        // Set a new point on line renderer
        line.SetPosition(points.Count - 1, snake.position);
        // use the same points for our edge collider
        col.points = points.ToArray();
    }
}
