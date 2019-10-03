using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerManipulator : MonoBehaviour
{
    private GameObject player;
    private float Yaw;

    private Vector3 moveTo, moveTo2 = Vector3.zero;
    private bool hasFloor, hasFloor2 = false;

    [CanBeNull] private GameObject moveToBlock;

    private bool canMove, canMove2, canPush;
    // Start is called before the first frame update
    void Awake()
    {
        GlobalVars.player = player;
        Yaw = 0f;
        player = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) move();
        if (Input.GetKeyDown(KeyCode.A)) rotateLeft();
        if (Input.GetKeyDown(KeyCode.S)) rotateBack();
        if (Input.GetKeyDown(KeyCode.D)) rotateRight();
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
                Debug.Log("cannt push");
            }
           
        }
        if (canMove && hasFloor)
        {
            if (moveToBlock != null)
            {
                if (canPush && hasFloor2)
                {
                    player.transform.position += player.transform.forward;
                    moveToBlock.transform.position += player.transform.forward;
                    GameObject.Find("Camera").GetComponent<Game>().checkWin();
                }
                else
                {
                    Debug.Log(2);
                }
            }
            else
            {
                player.transform.position += player.transform.forward;
                Debug.Log(3);
            }
        }
    }
}
