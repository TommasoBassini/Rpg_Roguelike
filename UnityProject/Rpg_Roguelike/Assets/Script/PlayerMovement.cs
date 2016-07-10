using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Grid grid;
    private FogOfWarManager fog;
    private GameControl gc;
    private Vector2 playerPos = new Vector2(0,0);
    public bool isMoving;
    private int randomEncounterProbably = 0;
    private Vector3 distance;
    private Vector3 direction;

    void Start ()
    {
        fog = this.GetComponent<FogOfWarManager>();
        gc = GameObject.Find("GameControl").GetComponent<GameControl>();

        fog.Fog(playerPos);

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
        if (((int)_pos.x >= 0) && ((int)_pos.y >= 0) && ((int)_pos.x < grid.width) && ((int)_pos.y < grid.height))
        {
            grid = GameObject.Find("Grid").GetComponent<Grid>();
            if (grid.cells[(int)_pos.x, (int)_pos.y].isWall == false)
            {
                
                //this.transform.position = grid.cells[(int)_pos.x, (int)_pos.y].gameObject.transform.position;
                playerPos = _pos;
                isMoving = true;
                

                randomEncounterProbably += 5;
                if (Random.Range(randomEncounterProbably, 255) > 240)
                {
                    randomEncounterProbably = 0;
                    gc.RandomEncounter();
                }
            }
        }
    }
        
    void Update()
    {
        if (isMoving)
        {
            distance = grid.cells[(int)playerPos.x, (int)playerPos.y].gameObject.transform.position - this.transform.position ;
            direction = distance.normalized;
            this.transform.position = this.transform.position + direction * Time.deltaTime * 3;

            if (distance.sqrMagnitude < 0.01f)
            {
                fog.Fog(playerPos);
                this.transform.position = new Vector3(grid.cells[(int)playerPos.x, (int)playerPos.y].transform.position.x, grid.cells[(int)playerPos.x, (int)playerPos.y].transform.position.y, 0);
                isMoving = false;
            }
        }

        if(Input.GetKey(KeyCode.W) && !isMoving)
        {
            PlayerMove(new Vector2(playerPos.x, playerPos.y + 1));
        }

        if (Input.GetKey(KeyCode.S) && !isMoving)
        {
            PlayerMove(new Vector2(playerPos.x, playerPos.y - 1));
        }

        if (Input.GetKey(KeyCode.D) && !isMoving)
        {
            PlayerMove(new Vector2(playerPos.x + 1, playerPos.y));
        }

        if (Input.GetKey(KeyCode.A) && !isMoving)
        {
            PlayerMove(new Vector2(playerPos.x - 1, playerPos.y));
        }
    }


}