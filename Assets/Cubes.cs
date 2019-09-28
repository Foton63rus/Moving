using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour, IEnumerable
{
    private List<GameObject> cubeList;

    public IEnumerator GetEnumerator()
    {
        return cubeList.GetEnumerator();
    }

    public void AddCube(float X, float Y)
    {
        GameObject _cube = Instantiate(Resources.Load("Models/BoxAsphalt", typeof(GameObject))) as GameObject;
        _cube.transform.position = new Vector3(X, 0, Y);
        Debug.Log("Created " + _cube);
        cubeList.Add(_cube);
    }
}
