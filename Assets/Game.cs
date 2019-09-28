using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Map map = new Map();
    // Start is called before the first frame update
    void Awake()
    {
        //Debug.Log(GlobalVars.CubeName(0));
        map.Load(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
