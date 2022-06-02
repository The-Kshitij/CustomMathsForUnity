using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingObject : MonoBehaviour
{
    LineRenderer lineRenderer = new LineRenderer();

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    //method to draw line
    public void DrawLine(Line line)
    {
        MathModule.DrawLine(line, ref lineRenderer);
    }

    public void DrawPlane(Plane plane)
    {
        MathModule.DrawPlane(plane);                
    }
}