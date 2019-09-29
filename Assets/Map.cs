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
        GameObject newCube = Instantiate(Resources.Load(GlobalVars.cubeName(type), typeof(GameObject))) as GameObject;
        newCube.transform.position = new Vector3(X, Z, Y);
        newCube.AddComponent<Cube>();
        newCube.GetComponent<Cube>().movable = movable;
        newCube.GetComponent<Cube>().type = type;
        
        GlobalVars.cubes.Add(newCube);
    }

    public void MapLoadTest()
    {
        for (int i = 0; i<5; i++)
        {
            for (int j = 0; j<5; j++)
            {
                if (i == j && i == 2)
                {
                    cubeAdd(i, j, 1, 0, true);
                    cubeAdd(i, j, 0, 1);
                }else if(i == j && i == 4)
                {
                    cubeAdd(i, j, 0, 2);
                    cubeAdd(i, j, 1, 0, true);
                }
                else
                {
                    cubeAdd(i, j, 0, 2);
                }
                
            }
        }
        //cubeAdd(3, 0, 1,2, true);
        //cubeAdd(2, 0, 1, 2, true);
    }
}
