using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void inputEvents();
public class InputAgregator : MonoBehaviour
{
    public event inputEvents OnMove;
    public event inputEvents OnRotateToLeft;
    public event inputEvents OnRotateToRight;
    public event inputEvents OnRotateToBack;
    public InputAgregator()
    {
        Debug.Log("InputAgregator loaded");
    }

    private void Awake()
    {
        Debug.Log("Input Aggregator loaded");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) Move();
        if (Input.GetKeyDown(KeyCode.A)) RotateToLeft();
        if (Input.GetKeyDown(KeyCode.S)) RotateToBack();
        if (Input.GetKeyDown(KeyCode.D)) RotateToRight();
    }
    public void Move()
    {
        if (OnMove != null)
        {
            OnMove();
        }
    }
    public void RotateToLeft()
    {
        if (OnRotateToLeft != null)
        {
            OnRotateToLeft();
        }
    }
    public void RotateToRight()
    {
        if (OnRotateToRight != null)
        {
            OnRotateToRight();
        }
    }
    public void RotateToBack()
    {
        if (OnRotateToBack != null)
        {
            OnRotateToBack();
        }
    }
}
