using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Map map;
    private List<GameObject> targets = new List<GameObject>();
    public GameObject camera;
    private GameObject player;
    private GameObject canvasInGame, canvasInMenu, canvasInRedactor;
    private int currentLVL;
    private int maxLVL;
    private bool inGame;
    private bool inRedactor;
    //TODO СДЕЛАТЬ ПЛИТОЧНОЕ МЕНЮ УРОВНЕЙ В МЕНЮ
    void Awake()
    {
        Init();
        BaseMenuLoad();
        GlobalVars.game = this;
        currentLVL = maxLVL = 1;
    }

    public bool InGame
    {
        get { return inGame; }
    }

    public bool InRedactor
    {
        get { return inRedactor; }
    }

    public void MapLoad(int i)
    {
        map.Load(i);
    }
    public void checkWin()
    {
        targets = GlobalVars.cubes.ToList().Where(x => x.GetComponent<Cube>().type == 1).ToList();
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

        if (tar == targets.Count)
        {
            //TODO need to do WIN action
            if (currentLVL < GlobalVars.LVLCount)
            {
                ++currentLVL;
                if (currentLVL > maxLVL) maxLVL = currentLVL;
                MapLoad(currentLVL);
            }
            else
            {
                Debug.Log("Game Finished!!! Wait new levels");
            }
        }
    }

    private void Init()
    {
        inGame = false;
        inRedactor = false;
        canvasInGame = GameObject.Find("CanvasInGame");
        canvasInMenu = GameObject.Find("CanvasInMenu");
        canvasInRedactor = GameObject.Find("CanvasInRedactor");
        player = playerAdd(0,0);
        camera = gameObject;
        map = camera.GetComponent<Map>();
    }

    public void BaseMenuLoad()
    {
        canvasInMenu.SetActive(true);
        canvasInGame.SetActive(false);
        canvasInRedactor.SetActive(false);
    }

    public void GameLoad()
    {
        player.GetComponent<PlayerManipulator>().enabled = true;
        canvasInMenu.SetActive(false);
        canvasInGame.SetActive(true);
        canvasInRedactor.SetActive(false);
        if (!inGame)
        {
            MapLoad(currentLVL);
            inGame = true;
            inRedactor = false;
        }
        camera.transform.LookAt(player.transform);
    }

    public void RedactorLoad()
    {
        player.GetComponent<PlayerManipulator>().enabled = false;
        targets = new List<GameObject>();
        inGame = false;
        inRedactor = true;
        canvasInRedactor.SetActive(true);
        canvasInMenu.SetActive(false);
        canvasInGame.SetActive(false);
        map.RedactorLoad();
    }
    private GameObject playerAdd(int X, int Y)
    {
        GameObject _Player = Instantiate(Resources.Load("Models/Player", typeof(GameObject))) as GameObject;
        _Player.transform.position = new Vector3(X, 1, Y);
        GlobalVars.player = _Player;
        _Player.AddComponent<PlayerManipulator>();
        //_Player.AddComponent<Animator>();
        return _Player;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
