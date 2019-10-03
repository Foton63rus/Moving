using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public static class GlobalVars
{
    [CanBeNull] public static GameObject player;
    private static List<string> cubeNames = new List<string>();
    public static List<GameObject> cubes = new List<GameObject>();
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
        //Loading Resources/cubeNames
        cubeNames.Add("Models/BoxMov_01");    // cubeNames[0] - movable box
        cubeNames.Add("Models/BoxTarget");    // cubeNames[1] - target box
        cubeNames.Add("Models/BoxGround 1");
        cubeNames.Add("Models/BoxAsphalt");
        cubeNames.Add("Models/BoxTile");
        
        
        Debug.Log("GlobalVars loaded");
    }


}
