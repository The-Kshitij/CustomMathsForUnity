using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line
{
    Vector3 dir;
    Coordinate startPt;
    Coordinate endPt;
    
    //uses the parametric form of a line
    public Line(Coordinate start, Coordinate end)
    {
        startPt = start;
        endPt = end;
        dir = MathModule.NormalizeVector((endPt - startPt).GetVector3());        
    }

    //returns the starting point of the line
    public Vector3 LineStart()
    {
        return startPt.GetVector3();
    }

    //returns the ending point of the line
    public Vector3 LineEnd()
    {
        return endPt.GetVector3();
    }

    //returns the direction in unit vector form
    public Vector3 LineDir()
    {
        return dir;
    }

    public Vector3 LineNormal()
    {
        Vector3 v = new Vector3(dir.y, -dir.x, 0);
        return v;
    }
}