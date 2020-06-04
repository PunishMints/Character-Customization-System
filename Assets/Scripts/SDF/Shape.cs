using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Shape : MonoBehaviour
{

    public enum ShapeType {Sphere,Cube,Torus,Prism,Cylinder,HexagonalPrism};
    public enum Operation {None, Blend, Cut, Mask}

    public ShapeType shapeType;
    public Operation operation;
    public Color colour = Color.white;
    [Range(0,1)]
    public float blendStrength;
    [HideInInspector]
    public int numChildren;

    public Vector3 Position 
    {
        get {
            return transform.position;
        }
    }

    public Quaternion Rotation
    {
        get
        {
            return transfrom.rotation;
        }
    }

    public Vector3 Scale {
        get {
            Vector3 parentScale = Vector3.one;
            if (transform.parent != null && transform.parent.GetComponent<Shape>() != null) {
                parentScale = transform.parent.GetComponent<Shape>().Scale;
            }
            return Vector3.Scale(transform.localScale, parentScale);
        }
    }
}
