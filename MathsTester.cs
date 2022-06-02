using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathsTester : MonoBehaviour
{
    //first object used for location of point
    [SerializeField] Transform pt_obj1;
    //second object used for location of point
    [SerializeField] Transform pt_obj2;

    //third object used for location of point
    [SerializeField] Transform pt_obj3;
    //fourth object used for location of point
    [SerializeField] Transform pt_obj4;

    [SerializeField] Transform plane_comnPt;
    [SerializeField] Transform plane_end1;
    [SerializeField] Transform plane_end2;

    List<DrawingObject> drawingObjects = new List<DrawingObject>();
    //parent that contatins all helpers
    [SerializeField] GameObject parent_Obj;

 
    private void Start()
    {
        Plane plane = new Plane(plane_comnPt.position, plane_end1.position, plane_end2.position);                
        
        Line line1 = new Line(new Coordinate(pt_obj1.position), new Coordinate(pt_obj2.position));        

        Line line2 = new Line(new Coordinate(pt_obj3.position), new Coordinate(pt_obj4.position));

        foreach (DrawingObject ob in parent_Obj.GetComponentsInChildren<DrawingObject>())
        {
            drawingObjects.Add(ob);
        }
        //Debug.Log("Found " + drawingObjects.Count + " line renderers");

        if (drawingObjects.Count >= 2)
        {
            drawingObjects[0].DrawLine(line1);
            drawingObjects[1].DrawLine(line2);
            drawingObjects[2].DrawPlane(plane);

        }

        bool res;
        Vector3 intersection;
        /* 
        intersection = MathModule.GetIntersection(out res, line1, line2);
        if (res)
        {
            Debug.Log("Intersection at " + intersection);
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            obj.transform.position = intersection;
        }*/

        intersection = MathModule.GetIntersection(out res, line2, plane);
        if (res)
        {
            Debug.Log("Intersection at " + intersection);
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            obj.name = "Intersection";
            obj.transform.position = intersection;
        }
    }
}