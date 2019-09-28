using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class Map : MonoBehaviour
{
    

    public Map()
    {
        
    }
    
    public void Load(int mapNumber)
    {
        /*using (FileStream fs = new FileStream(@"Maps/"+mapNumber.ToString(), FileMode.Open))
        {
            
        }*/
        /*
         cubeAdd(0,0, 0, false);
        cubeAdd(1,1, 1,false);
        cubeAdd(2,2, 2,false);
        */
        MapLoadTest();
    }
    static void reset()
    {
        
    }

    private void cubeAdd(int X, int Y, int Z, int type = 0, bool movable = false)
    {
        Cube newCube = new Cube(X, Y, Z, type, movable);
        GlobalVars.cubes.Add(newCube);
    }

    public void MapLoadTest()
    {
        for (int i = 0; i<GlobalVars.cubeNamesCount; i++)
        {
            cubeAdd(i, 0, 0, i);
        }
        cubeAdd(3, 0, 1,2, true);
        cubeAdd(2, 0, 1, 2, true);
    }
}
