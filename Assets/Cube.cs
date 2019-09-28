using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    //private static List<string> cubeNames = new List<string>();
    private int x;    //mapload position
    private int y;    //mapload position
    private int z;    //
    private int type;
    private bool movable;
    private GameObject go;

    public Cube(int _x, int _y, int _z, int _type = 0, bool _movable = false) : base()
    {
        x = _x; 
        y = _y;
        z = _z;
        type = _type;
        movable = _movable;
        go = Instantiate(Resources.Load(GlobalVars.cubeName(type), typeof(GameObject))) as GameObject;
        go.transform.position = new Vector3(x, z, y);
    }

    public GameObject GetGameObject()
    {
        return go;
    }

    public bool Movable
    {
        get { return movable; }
    }
}
