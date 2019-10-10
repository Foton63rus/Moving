using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
public class Map : MonoBehaviour
{
    private GameObject spawnCube;
    private InputAgregator IA;
    private Transform camera;
    private int R_blockType;
    private readonly Vector3 R_spawnBoxScale = new Vector3(1.1f, 1.1f, 1.1f);
    private string[] lvl_data;
    private bool RMOVABLE;
    const string path = "Assets/Resources/Maps/Maps.txt";
    private void Awake()
    {
        Read();
        camera = GameObject.Find("Camera").transform;
        IA = GameObject.Find("Camera").GetComponent<InputAgregator>();
        Debug.Log("IA "+IA);
        R_blockType = 2;
        RMOVABLE = false;
        IA.OnMoveForwardRB += pushBlockToForward;
        IA.OnMoveBackRB += pushBlockToBack;
        IA.OnMoveLeftRB += pushBlockToLeft;
        IA.OnMoveRightRB += pushBlockToRight;
        IA.OnMoveUpRB += pushBlockToUp;
        IA.OnMoveDownRB += pushBlockToDown;
        IA.OnBlockAdd += redactorBlockAdd;
        IA.OnBlockDelete += redactorBlockDelete;
        IA.OnBlockChanged += redactorBlockChanged;
    }
    public void Load(int mapNumber)
    {
        GlobalVars.currentLVL = mapNumber;
        reset();
        clearMap();
        if (mapNumber <= lvl_data.Length-1)
        {
            string[] components = lvl_data[mapNumber - 1].Split(',');
            if (((components.Length-1)/5).ToString() == components[0])
            {
                for (int i = 0; i < ((components.Length-1)/5); i++)
                {
                    cubeAdd(int.Parse(components[1+i*5]), int.Parse(components[1+i*5+1]), int.Parse(components[1+i*5+2]), int.Parse(components[1+i*5+3]), int.Parse(components[1+i*5+4]) == 1 ? true : false);
                }
            }
            Debug.Log("loaded #"+mapNumber);
        }
        else
        {
            Debug.Log("Error of map loading #"+mapNumber);
        }
    }

    public void Restart()
    {
        Load(GlobalVars.currentLVL);
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
    public void RedactorLoad()
    {
        clearMap();
        GlobalVars.player.transform.position = Vector3.up;
        camera.LookAt(Vector3.zero);
        spawnCube = Instantiate(Resources.Load(GlobalVars.cubeName(R_blockType), typeof(GameObject))) as GameObject;
        spawnCube.transform.position = new Vector3(0, 0, 0);
    }

    private void clearMap()
    {
        foreach (GameObject cube in GlobalVars.cubes)
        {
            Destroy(cube);
        }
        GlobalVars.cubes = new List<GameObject>();
        Destroy(spawnCube);
    }

    private void pushBlockToForward()
    {
        spawnCube.transform.position += Vector3.forward;
        camera.LookAt(spawnCube.transform.position);
    }
    private void pushBlockToBack()
    {
        spawnCube.transform.position -= Vector3.forward;
        camera.LookAt(spawnCube.transform.position);
    }
    private void pushBlockToLeft()
    {
        spawnCube.transform.position -= Vector3.right;
        camera.LookAt(spawnCube.transform.position);
    }
    private void pushBlockToRight()
    {
        spawnCube.transform.position += Vector3.right;
        camera.LookAt(spawnCube.transform.position);
    }
    private void pushBlockToUp()
    {
        spawnCube.transform.position += Vector3.up;
        camera.LookAt(spawnCube.transform.position);
    }
    private void pushBlockToDown()
    {
        spawnCube.transform.position -= Vector3.up;
        camera.LookAt(spawnCube.transform.position);
    }
    private void redactorBlockAdd()
    {
        Vector3 scp = spawnCube.transform.position;
        if(GlobalVars.cubes.Where(x => x.transform.position == spawnCube.transform.position).ToList().Count == 0) cubeAdd((int)scp.x, (int)scp.z, (int)scp.y, R_blockType, RMOVABLE);
    }
    private void redactorBlockChanged()
    {
        Vector3 pos = spawnCube.transform.position;
        R_blockType = (++R_blockType % GlobalVars.cubeNamesCount);
        Debug.Log(R_blockType+ " / "+GlobalVars.cubes.Count);
        Destroy(spawnCube);
        spawnCube = Instantiate(Resources.Load(GlobalVars.cubeName(R_blockType), typeof(GameObject))) as GameObject;
        spawnCube.transform.position = pos;
        spawnCube.transform.localScale = R_spawnBoxScale;
    }
    private void redactorBlockDelete()
    {
        if (GlobalVars.cubes.Count > 0)
        {
            if (GlobalVars.cubes.Where(x => x.transform.position == spawnCube.transform.position).ToList().Count > 0)
            {
                GameObject block4Deleting = GlobalVars.cubes.Where(x => x.transform.position == spawnCube.transform.position).ToList()[0];
                if (block4Deleting != null)
                {
                    if (GlobalVars.cubes.Contains(block4Deleting)) GlobalVars.cubes.Remove(block4Deleting);
                    Destroy(block4Deleting);
                }
            }
        }
    }
    public void Save()
    {
        string path = "Assets/Resources/Maps/Maps.txt";
        using (StreamWriter SW = new StreamWriter(path, true))
        {
            string line = GlobalVars.cubes.Count.ToString();
            foreach (GameObject cube in GlobalVars.cubes)
            {
                Vector3 cubePosition = cube.transform.position;
                line += "," + cubePosition.x + "," + cubePosition.z + "," + cubePosition.y + "," +
                        cube.GetComponent<Cube>().type + "," + (cube.GetComponent<Cube>().movable ? 1 : 0);
            }
            SW.WriteLine(line);
            reset();
            RedactorLoad();
        }
    }

    public void RMovableChange()
    {
        RMOVABLE = !RMOVABLE;
        Debug.Log("Movable = " + RMOVABLE);
    }
    private void Read()
    {
        using (StreamReader SR = new StreamReader(path))
        {
            lvl_data = SR.ReadToEnd().Split('\n');
            GlobalVars.LVLCount = lvl_data.Length-1;
        }
    }
}
