using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinate
{
    private float x;
    private float y;
    private float z;
    

    public Coordinate(float _x = 0, float _y = 0, float _z = 0)
    {
        x = _x;
        y = _y;
        z = _z;
    }

    public Coordinate(Vector3 v)
    {
        x = v.x;
        y = v.y;
        z = v.z;
    }

    public Vector3 GetVector3()
    {
        return new Vector3(x, y, z);
    }

    //+ operation for two coordinates
    public static Coordinate operator + (Coordinate a1, Coordinate a2)
    {
        return new Coordinate(a1.x + a2.x, a1.y + a2.y, a1.z + a2.z);
    }

    //- operation for two coordinates, returns a1 - a2
    public static Coordinate operator -(Coordinate a1, Coordinate a2)
    {        
        return new Coordinate(a1.x - a2.x, a1.y - a2.y, a1.z - a2.z);
    }

    public override string ToString() 
    {
        return "(" + x + "," + y + "," + z + ")";
    }
}
