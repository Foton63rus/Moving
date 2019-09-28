using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVars
{
    private static List<string> cubeNames = new List<string>();
    public static List<Cube> cubes = new List<Cube>();
    public static int cubeNamesCount
    {
        get
        {
            return cubeNames.Count;
        }
    }

    public static string cubeName(int index)
    {
        return cubeNames[index];
    }
    //private static Dictionary<int, string> cubeName = new Dictionary<int, string>(){};
    static GlobalVars()
    {
        cubeNames.Add("Models/BoxGround 1");
        cubeNames.Add("Models/BoxAsphalt");
        cubeNames.Add("Models/BoxTile");
        
        Debug.Log("GlobalVars loaded");
    }
}
