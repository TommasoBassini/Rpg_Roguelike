using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cell : MonoBehaviour
{
    public Vector2 pos;
    public bool isWall = false;
    public GameObject tileEditorCell;
    public bool isAngle = false;
    private Grid grid;
    public List<GameObject> wallNear = new List<GameObject>();

    void Start ()
    {
        
    }

    void Update()
    {

    }

}
