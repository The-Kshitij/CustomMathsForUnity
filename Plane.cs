using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane
{
    Coordinate comn, end1, end2;

    //plane formed by one common point and two vertices
    public Plane(Coordinate _comn, Coordinate _end1, Coordinate _end2)
    {
        comn = _comn;
        end1 = _end1;
        end2 = _end2;
    }

    //plane formed by one common point and two vertices
    public Plane(Vector3 _comn, Vector3 _end1, Vector3 _end2)
    {
        comn = new Coordinate(_comn);
        end1 = new Coordinate(_end1);
        end2 = new Coordinate(_end2);
    }

    public Vector3 GetComnPt()
    {
        return comn.GetVector3();
    }

    public Vector3 GetEndPt1()
    {
        return end1.GetVector3();
    }

    public Vector3 GetEndPt2()
    {
        return end2.GetVector3();
    }
}