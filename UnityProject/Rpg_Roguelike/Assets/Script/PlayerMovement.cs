using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    private Grid grid;
    private FogOfWarManager fog;
    private GameControl gc;
    private Vector2 playerPos = new Vector2(0,0);

    private int randomEncounterProbably = 0;


    void Start ()
    {
        fog = this.GetComponent<FogOfWarManager>();
        gc = GameObject.Find("GameControl").GetComponent<GameControl>();

        //fog.Fog(playerPos);

    }

    // Imposta la posizione iniziale del giocatore all'interno della griglia
    public void SetPlayerPosition()
    {
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        this.transform.position = grid.cells[0, 0].gameObject.transform.position;
    }


    // Imposta la destinazione che il giocatore deve raggiungere
    public virtual void PlayerMove(Vector2 _pos)
    {
        if (((int)_pos.x >= 0) && ((int)_pos.y >= 0) && ((int)_pos.x < grid.width) && ((int)_pos.y < grid.height))
        {
            grid = GameObject.Find("Grid").GetComponent<Grid>();
            if (grid.cells[(int)_pos.x, (int)_pos.y].isWall == false)
            {
                this.transform.position = grid.cells[(int)_pos.x, (int)_pos.y].gameObject.transform.position;
                playerPos = _pos;
                fog.Fog(_pos);

                randomEncounterProbably += 5;
                Debug.Log(randomEncounterProbably);
                if (Random.Range(randomEncounterProbably, 150) > 140)
                {
                    randomEncounterProbably = 0;
                    gc.RandomEncounter();
                }
            }
        }
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