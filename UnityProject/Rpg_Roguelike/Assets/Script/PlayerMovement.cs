using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Grid grid;
    private FogOfWarManager fog;
    private Vector2 playerPos = new Vector2(0,0);

    void Start ()
    {
        fog = this.GetComponent<FogOfWarManager>();
        //fog.Fog(playerPos);

    }

    // Imposta la posizione iniziale del giocatore all'interno della griglia
    public void SetPlayerPosition()
    {
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        this.transform.position = grid.cells[0, 0].gameObject.transform.position;
    }


    // Imposta la destinazione che il giocatore deve raggiungere
    public void PlayerMove(Vector2 _pos)
    {        
        grid = GameObject.Find("Grid").GetComponent<Grid>();        
        this.transform.position = grid.cells[(int)_pos.x, (int)_pos.y].gameObject.transform.position;
        playerPos = _pos;
        fog.Fog(_pos);
    }
        
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            PlayerMove(new Vector2(playerPos.x, playerPos.y + 1));
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerMove(new Vector2(playerPos.x, playerPos.y - 1));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerMove(new Vector2(playerPos.x + 1, playerPos.y));
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerMove(new Vector2(playerPos.x - 1, playerPos.y));
        }



    }

}