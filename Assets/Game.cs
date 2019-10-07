using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private Map map = new Map();
    private List<GameObject> targets = new List<GameObject>();
    private GameObject camera;
    private GameObject player;
    private GameObject canvasInGame;
    private GameObject canvasInMenu;
    private int currentLVL;
    private bool inGame;
    private bool inRedactor;
    
    void Awake()
    {
        Init();
        BaseMenuLoad();
        //GameLoad();
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

    private void Init()
    {
        inGame = false;
        inRedactor = false;
        canvasInGame = GameObject.Find("CanvasInGame");
        canvasInMenu = GameObject.Find("CanvasInMenu");
        player = playerAdd(0,0);
        camera = gameObject;
    }

    public void BaseMenuLoad()
    {
        canvasInMenu.SetActive(true);
        canvasInGame.SetActive(false);
        //var buttons = canvasInMenu.transform.GetComponentsInChildren<Button>();
    }

    public void GameLoad()
    {
        canvasInMenu.SetActive(false);
        canvasInGame.SetActive(true);
        if (!inGame)
        {
            MapLoad(1);
            inGame = true;
        }
        camera.transform.LookAt(player.transform);
    }

    public void RedactorLoad()
    {
        inGame = false;
        inRedactor = true;
        canvasInMenu.SetActive(false);
        canvasInGame.SetActive(false);
        map.RedactorLoad();
    }
    private GameObject playerAdd(int X, int Y)
    {
        GameObject _Player = Instantiate(Resources.Load("Models/Player", typeof(GameObject))) as GameObject;
        _Player.transform.position = new Vector3(X, 1, Y);
        GlobalVars.player = _Player;
        return _Player;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
