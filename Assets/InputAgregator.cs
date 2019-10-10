using UnityEngine;
public delegate void inputEvents();
public class InputAgregator : MonoBehaviour
{
    private Transform CamTransform;
    private float hMouse, vMouse;
    public event inputEvents OnMove;
    public event inputEvents OnRotateToLeft;
    public event inputEvents OnRotateToRight;
    public event inputEvents OnRotateToBack;
    public event inputEvents OnMoveForwardRB;
    public event inputEvents OnMoveBackRB;
    public event inputEvents OnMoveLeftRB;
    public event inputEvents OnMoveRightRB;
    public event inputEvents OnMoveUpRB;
    public event inputEvents OnMoveDownRB;
    public event inputEvents OnBlockAdd;
    public event inputEvents OnBlockChanged;
    public event inputEvents OnBlockDelete;
    public InputAgregator()
    {
        Debug.Log("InputAgregator loaded");
    }

    private void Awake()
    {
        GlobalVars.IA = this;
        CamTransform = GameObject.Find("Camera").transform;
        Debug.Log("Input Aggregator loaded");
    }

    void Update()
    {
        if (GlobalVars.game.InGame)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) Move();
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) RotateToLeft();
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) RotateToBack();
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) RotateToRight();
        }
        if (GlobalVars.game.InRedactor)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) moveForwardRB();
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) moveLeftRB();
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) moveBackRB();
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) moveRightRB();
            if (Input.GetKeyDown(KeyCode.Space)) moveUpRB();
            if (Input.GetKeyDown(KeyCode.LeftControl)) moveDownRB();
            if (Input.GetKeyDown(KeyCode.E)) blockAdd();
            if (Input.GetKeyDown(KeyCode.Q)) blockDelete();
            if (Input.GetKeyDown(KeyCode.R)) blockChanged();
        }
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
    public void moveForwardRB()
    {
        if (OnMoveForwardRB != null)
        {
            OnMoveForwardRB();
        }
    }
    public void moveLeftRB()
    {
        if (OnMoveLeftRB != null)
        {
            OnMoveLeftRB();
        }
    }
    public void moveRightRB()
    {
        if (OnMoveRightRB != null)
        {
            OnMoveRightRB();
        }
    }
    public void moveBackRB()
    {
        if (OnMoveBackRB != null)
        {
            OnMoveBackRB();
        }
    }
    public void moveUpRB()
    {
        if (OnMoveUpRB != null)
        {
            OnMoveUpRB();
        }
    }
    public void moveDownRB()
    {
        if (OnMoveDownRB != null)
        {
            OnMoveDownRB();
        }
    }
    public void blockAdd()
    {
        if (OnBlockAdd != null)
        {
            OnBlockAdd();
        }
    }
    public void blockDelete()
    {
        if (OnBlockDelete != null)
        {
            OnBlockDelete();
        }
    }
    public void blockChanged()
    {
        if (OnBlockChanged != null)
        {
            OnBlockChanged();
        }
    }
}
