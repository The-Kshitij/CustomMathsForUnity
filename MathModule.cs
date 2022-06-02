using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MathModule : MonoBehaviour
{
    //method to draw line
    public static void DrawLine(Line line, ref LineRenderer lineRenderer)
    {       
        //setting up the line renderer
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, line.LineStart());
        lineRenderer.SetPosition(1, line.LineEnd());
    }

    //given a plane and line renderer, uses the three point formula to form a plane
    public static void DrawPlane(Plane plane)
    {
        Vector3 comn = plane.GetComnPt();
        Vector3 end1 = plane.GetEndPt1();
        Vector3 end2 = plane.GetEndPt2();        

        Vector3 line1 = end1 - comn;
        Vector3 line2 = end2 - comn;

        for (float t = 0.0f; t <= 1; t += 0.2f)
        {
            for (float s = 0.0f; s <= 1; s += 0.2f)
            {
                GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                obj.transform.position = comn +  t * line1 + s * line2;
            }
        }        
    }

    //given a vector returns the magnitude
    public static float Magnitude(Vector3 v2)
    {
        Vector3 v1 = Vector3.zero;
        return GetDistance(new Coordinate(v1), new Coordinate(v2));
    }

    //returns the distance between two points
    public static float GetDistance(Coordinate c1, Coordinate c2)
    {
        Vector3 v1 = c1.GetVector3();
        Vector3 v2 = c2.GetVector3();
        return Mathf.Sqrt(Mathf.Pow(v1.x - v2.x, 2) + Mathf.Pow(v1.y - v2.y, 2) + Mathf.Pow(v1.z - v2.z, 2));
    }

    //returns the normalized vector
    public static Vector3 NormalizeVector(Vector3 v)
    {
        return v / Magnitude(v);
    }

    public static float DotProduct(Vector3 v1, Vector3 v2)
    {
        return (v1.x * v2.x + v1.y * v2.y + v1.z * v2.z);
    }

    public static Vector3 CrossProduct(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.y * v2.z - v1.z * v2.y, 
                           v1.z * v2.x - v1.x * v2.z, 
                           v1.x * v2.y - v1.y * v2.x);
    }

    public static Vector3 GetIntersection(out bool res, Line line1, Line line2)
    {
        Vector3 i1 = new Vector3(0, 0, 0);
        Vector3 i2 = new Vector3(0, 0, 0);

        Vector3 intersection = new Vector3(0, 0, 0);
        Vector3 a = line1.LineStart();
        Vector3 u = line1.LineDir();
        Vector3 u_norm = line1.LineNormal();

        Vector3 b = line2.LineStart();
        Vector3 v = line2.LineDir();
        Vector3 v_norm = line2.LineNormal();        

        float denom = MathModule.DotProduct(v_norm, u);
        if (denom == 0)
        {
            res = false;
        }
        else
        {
            res = true;
            float t = (MathModule.DotProduct(v_norm, b - a))/denom;
            intersection = a + u * t;
            i1 = intersection;

            float denom2 = MathModule.DotProduct(u_norm, v);
            float s = (MathModule.DotProduct(u_norm, a - b));
            i2 = b + v * s;
            if (i1 == i2) res = true;
            else res = false;
        }

        return intersection;
    }

    public static Vector3 GetIntersection(out bool res, Line line, Plane plane)
    {
        Vector3 v = plane.GetEndPt2() - plane.GetComnPt();
        Vector3 p = plane.GetEndPt1() - plane.GetComnPt();
        Vector3 u = line.LineDir();
        Vector3 intersection = Vector3.zero;

        Vector3 cross_prod = MathModule.CrossProduct(v, p);

        float denom = MathModule.DotProduct(cross_prod, u);
        if (denom == 0)
        {
            res = false;
        }
        else
        {
            res = true;
            float t = MathModule.DotProduct(cross_prod, (plane.GetComnPt() - line.LineStart())) / denom;
            intersection = line.LineStart() + t * u;
        }
        return intersection;
    }

    //returns if moving from vector a to vector b is clockwise or not
    public static bool IsClockwise(Vector3 a, Vector3 b)
    {
        return (CrossProduct(a, b).z < 0);    
    }

    public static float GetAngle(Line a, Line b)
    {
        return Mathf.Acos(DotProduct(a.LineDir(), b.LineDir()));       
    }
}