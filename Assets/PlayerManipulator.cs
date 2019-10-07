using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerManipulator : MonoBehaviour
{
    private GameObject player;
    private float Yaw;
    private InputAgregator IA;
    private Vector3 moveTo, moveTo2 = Vector3.zero;
    private bool hasFloor, hasFloor2 = false;
    private GameObject camera;

    [CanBeNull] private GameObject moveToBlock;

    private bool canMove, canMove2, canPush;
    // Start is called before the first frame update
    void Awake()
    {
        camera = GameObject.Find("Camera");
        Yaw = 0f;
        player = gameObject;
        IA = camera.GetComponent<InputAgregator>();
        IA.OnMove += move;
        IA.OnRotateToLeft += rotateLeft;
        IA.OnRotateToRight += rotateRight;
        IA.OnRotateToBack += rotateBack;
    }
    [SerializeField] private void rotateLeft()
    {
        Yaw -= 90f;
        player.transform.rotation = Quaternion.Euler(0, Yaw, 0);
    }
    [SerializeField] private void rotateRight()
    {
        Yaw += 90f;
        player.transform.rotation = Quaternion.Euler(0, Yaw, 0);
    }
    [SerializeField] private void rotateBack()
    {
        Yaw += 180f;
        player.transform.rotation = Quaternion.Euler(0, Yaw, 0);
    }
    [SerializeField] private void move()
    {
        moveToBlock = null;
        hasFloor = hasFloor2 = false;
        canMove = canPush = true;
        moveTo = player.transform.position + player.transform.forward;
        moveTo2 = player.transform.position + player.transform.forward*2;
        
        for(int i = 0; i<GlobalVars.cubes.Count; i++)
        {
            if (moveTo - Vector3.up == GlobalVars.cubes[i].transform.position) hasFloor = true;
            if (moveTo2 - Vector3.up == GlobalVars.cubes[i].transform.position) hasFloor2 = true;
            if (moveTo == GlobalVars.cubes[i].transform.position)
            {
                moveToBlock = GlobalVars.cubes[i];
                if (!moveToBlock.GetComponent<Cube>().movable) canMove = false;
            }
            if (moveTo2 == GlobalVars.cubes[i].transform.position)
            {
                canPush = false;
            }
           
        }
        if (canMove && hasFloor)
        {
            if (moveToBlock != null)
            {
                if (canPush && hasFloor2)
                {
                    //walk with a cube
                    player.transform.position += player.transform.forward;
                    moveToBlock.transform.position += player.transform.forward;
                    camera.GetComponent<Game>().checkWin();
                }
                else
                {
                    //cannt walk
                }
            }
            else
            {
                //walk without a cube
                player.transform.position += player.transform.forward;
            }
        }
        camera.transform.LookAt(player.transform);
    }
}
