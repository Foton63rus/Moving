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

    [CanBeNull] private GameObject moveToBlock;

    private bool canMove, canPush;
    // Start is called before the first frame update
    void Awake()
    {
        Yaw = 0f;
        player = gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            move();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rotateLeft();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rotateBack();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rotateRight();
        }
    }

    private void rotateLeft()
    {
        Yaw -= 90f;
        player.transform.rotation = Quaternion.Euler(0, Yaw, 0);
    }
    private void rotateRight()
    {
        Yaw += 90f;
        player.transform.rotation = Quaternion.Euler(0, Yaw, 0);
    }
    private void rotateBack()
    {
        Yaw += 180f;
        player.transform.rotation = Quaternion.Euler(0, Yaw, 0);
    }
    private void move()
    {
        moveToBlock = null;
        canMove = canPush = true;
        moveTo = player.transform.position + player.transform.forward;
        moveTo2 = player.transform.position + player.transform.forward*2;
        
        for(int i = 0; i<GlobalVars.cubes.Count; i++)
        {
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

        if (canMove)
        {
            if (moveToBlock != null)
            {
                if (canPush)
                {
                    player.transform.position += player.transform.forward;
                    moveToBlock.transform.position += player.transform.forward;
                }
                else
                {
                    
                }
            }
            else
            {
                player.transform.position += player.transform.forward;
            }
        }
        
    }
}
