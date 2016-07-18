using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{

    PlayerMovement player;
    Grid grid;
    public bool hasTheKey = false;


    void Start()
    {        
        player = GetComponent<PlayerMovement>();       
    }



    void SetDoor()
    {
        Vector2 pos = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f);
        grid = GetComponent<Grid>();
        grid.cells[(int)pos.x, (int)pos.y].isWall = true;
    }



   /* void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player" && player.hasKey == true)
        {
            grid = GetComponent<Grid>();
            grid.cells[(int)pos.x, (int)pos.y].isWall = false;



            PlayerMovement player = coll.gameObject.GetComponent<PlayerMovement>();
            player.hasKey = true;

        }
    }
    */

           

}


