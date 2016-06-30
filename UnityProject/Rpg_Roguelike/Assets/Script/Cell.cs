using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour
{

    public Vector2 pos;
    public bool isMoving;

    void Start ()
    {
       
    }

    void OnMouseUp ()
    {
        isMoving = true;

        if (isMoving)
        {
            PlayerMovement pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
            pm.PlayerMove(pos);
        }
    }
}
