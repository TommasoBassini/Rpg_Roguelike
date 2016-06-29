using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    
    private Grid grid;	
	void Start ()
    {
       



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

        

        }
        
     


    


    void Update()
    {

        



    }

}