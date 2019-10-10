using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public static class GlobalVars
{
    [CanBeNull] public static GameObject player;
    private static List<string> cubeNames = new List<string>();
    public static List<GameObject> cubes = new List<GameObject>();
    public static InputAgregator IA;
    [CanBeNull] public static Game game = null;
    public static int currentLVL = 1;
    public static int maxLVL = 1;
    public static int LVLCount = 1;

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
