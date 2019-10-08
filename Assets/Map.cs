using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Map : MonoBehaviour
{
    private GameObject spawnCube;
    private InputAgregator IA;
    private GameObject camera;

    private void Awake()
    {
        camera = GameObject.Find("Camera");
        IA = camera.GetComponent<InputAgregator>();
        Debug.Log("IA "+IA);
        IA.OnMoveForwardRB += pushBlockToForward;
        IA.OnMoveBackRB += pushBlockToBack;
        IA.OnMoveLeftRB += pushBlockToLeft;
        IA.OnMoveRightRB += pushBlockToRight;
        IA.OnMoveUpRB += pushBlockToUp;
        IA.OnMoveDownRB += pushBlockToDown;
    }

    public void Load(int mapNumber)
    {
        //TODO добавить чтение запись
        /*using (FileStream fs = new FileStream(@"Maps/maps", FileMode.Open))
        {
            Debug.Log(fs.CanRead);
        }*/
        /*
         cubeAdd(0,0, 0, false);
        cubeAdd(1,1, 1,false);
        cubeAdd(2,2, 2,false);
        */
        reset();
        MapLoadTest();
    }
    static void reset()
    {
        if(GlobalVars.player != null) GlobalVars.player.transform.position = Vector3.up;
    }

    private GameObject cubeAdd(int X, int Y, int Z, int type = 0, bool movable = false)
    {
        GameObject newCube = Instantiate(Resources.Load(GlobalVars.cubeName(type), typeof(GameObject))) as GameObject;
        newCube.transform.position = new Vector3(X, Z, Y);
        newCube.AddComponent<Cube>();
        newCube.GetComponent<Cube>().movable = movable;
        newCube.GetComponent<Cube>().type = type;
        
        GlobalVars.cubes.Add(newCube);

        return newCube;
    }
    public void MapLoadTest()
    {
        for (int i = 0; i<8; i++)
        {
            for (int j = 0; j<8; j++)
            {
                if (i == j && i == 2)
                {
                    cubeAdd(i, j, 1, 0, true);
                    cubeAdd(i, j, 0, 1);
                }else if(i == j && i == 1)
                {
                    cubeAdd(i, j, 0, 1);
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

    public void RedactorLoad()
    {
        clearMap();
        GlobalVars.player.transform.position = Vector3.up;
        camera.transform.LookAt(Vector3.zero);
        spawnCube = cubeAdd(0, 0, 0, 2);
    }

    private void clearMap()
    {
        foreach (GameObject cube in GlobalVars.cubes)
        {
            Destroy(cube);
        }
        GlobalVars.cubes = new List<GameObject>();
    }

    private void pushBlockToForward()
    {
        spawnCube.transform.position += Vector3.forward;
        camera.transform.LookAt(spawnCube.transform.position);
    }
    private void pushBlockToBack()
    {
        spawnCube.transform.position -= Vector3.forward;
        camera.transform.LookAt(spawnCube.transform.position);
    }
    private void pushBlockToLeft()
    {
        spawnCube.transform.position -= Vector3.right;
        camera.transform.LookAt(spawnCube.transform.position);
    }
    private void pushBlockToRight()
    {
        spawnCube.transform.position += Vector3.right;
        camera.transform.LookAt(spawnCube.transform.position);
    }
    private void pushBlockToUp()
    {
        spawnCube.transform.position += Vector3.up;
        camera.transform.LookAt(spawnCube.transform.position);
    }
    private void pushBlockToDown()
    {
        spawnCube.transform.position -= Vector3.up;
        camera.transform.LookAt(spawnCube.transform.position);
    }
}
