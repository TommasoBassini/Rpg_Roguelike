using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour
{
    public Vector2 pos;
    public bool isMoving;


    void Start ()
    {
       
    }

    void OnMouseUp()
    {
        isMoving = true;

        if (isMoving == true)
        {
            PlayerMovement pm1 = GameObject.Find("Player").GetComponent<PlayerMovement>();
            pm1.PlayerMove(pos);
        }

        


    }




}
