using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Map map = new Map();
    private List<GameObject> targets = new List<GameObject>();
    void Awake()
    {
        MapLoad(1);
    }

    public void MapLoad(int i)
    {
        map.Load(i);
        targets = GlobalVars.cubes.ToList().Where(x => x.GetComponent<Cube>().type == 1).ToList();
    }
    public void checkWin()
    {
        uint tar = 0;
        foreach (GameObject target in targets)
        {
            foreach (GameObject cube in GlobalVars.cubes)
            {
                if (target.transform.position + Vector3.up == cube.transform.position)
                {
                    tar++;
                    break;
                }
            }
        }
        if(tar == targets.Count) Debug.Log("win");
    }
}
