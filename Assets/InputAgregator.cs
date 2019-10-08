using UnityEngine;
public delegate void inputEvents();
public class InputAgregator : MonoBehaviour
{
    private float MouseScrollScale = 0.1f;
    private float RedactorScaleFactor = 0.1f;
    private Transform CamTransform;
    private float hMouse, vMouse;
    private Vector3 CamPos = new Vector3();
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
            if (Input.GetKeyDown(KeyCode.W)) Move();
            if (Input.GetKeyDown(KeyCode.A)) RotateToLeft();
            if (Input.GetKeyDown(KeyCode.S)) RotateToBack();
            if (Input.GetKeyDown(KeyCode.D)) RotateToRight();
        }

        if (GlobalVars.game.InRedactor)
        {
            //TODO сделать управление в редакторе
            
            //CamPos = CamTransform.position;
            //CamPos.x += Input.mouseScrollDelta.y * MouseScrollScale;
            //CamTransform.position = CamPos;
            
            if (Input.GetKeyDown(KeyCode.W)) moveForwardRB();
            if (Input.GetKeyDown(KeyCode.A)) moveLeftRB();
            if (Input.GetKeyDown(KeyCode.S)) moveBackRB();
            if (Input.GetKeyDown(KeyCode.D)) moveRightRB();
            if (Input.GetKeyDown(KeyCode.Space)) moveUpRB();
            if (Input.GetKeyDown(KeyCode.LeftControl)) moveDownRB();
            
            //hMouse = -1.55f * Input.GetAxis("Mouse X");
            //vMouse = 1 * Input.GetAxis("Mouse Y");
            //transform.Rotate(vMouse, hMouse, 0);
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
        OnMoveForwardRB();
    }
    public void moveLeftRB()
    {
        OnMoveLeftRB();
    }
    public void moveRightRB()
    {
        OnMoveRightRB();
    }
    public void moveBackRB()
    {
        OnMoveBackRB();
    }
    public void moveUpRB()
    {
        OnMoveUpRB();
    }
    public void moveDownRB()
    {
        OnMoveDownRB();
    }
}
