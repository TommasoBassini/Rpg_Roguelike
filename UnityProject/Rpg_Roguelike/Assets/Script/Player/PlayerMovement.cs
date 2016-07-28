using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Grid grid;
    private FogOfWarManager fog;
    public Vector2 playerPos = new Vector2(1,1);
    public bool isMoving;
    private int randomEncounterProbably = 0;
    private Vector3 distance;
    private Vector3 direction;
    public bool hasKey = false;
    public bool isSpeaking = false;
    public Vector2 respawnPos;
    public Animator animator;
    public bool facingRight = true;
    public bool facingLeft = false;
    public bool facingUp = false;
    public bool facingDown = false;

    public bool isOpenMenu = false;
    void Start ()
    {
        fog = this.GetComponent<FogOfWarManager>();
        fog.Fog(playerPos);
    }

    // Imposta la posizione iniziale del giocatore all'interno della griglia
    public void SetPlayerPosition()
    {
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        this.transform.position = grid.cells[(int)playerPos.x, (int)playerPos.y].gameObject.transform.position;
    }


    // Imposta la destinazione che il giocatore deve raggiungere
    public void PlayerMove(Vector2 _pos)
    {
        if (((int)_pos.x >= 0) && ((int)_pos.y >= 0) && ((int)_pos.x < grid.width) && ((int)_pos.y < grid.height))
        {
            grid = GameObject.Find("Grid").GetComponent<Grid>();
            if (grid.cells[(int)_pos.x, (int)_pos.y].isWall == false && grid.cells[(int)_pos.x, (int)_pos.y].isSemiWall == false)
            {
                
                //this.transform.position = grid.cells[(int)_pos.x, (int)_pos.y].gameObject.transform.position;
                playerPos = _pos;
                isMoving = true;
                

                randomEncounterProbably += 5;
                if (Random.Range(randomEncounterProbably, 255) > 250)
                {
                    GameControl gc = FindObjectOfType<GameControl>();
                    randomEncounterProbably = 0;
                    //gc.RandomEncounter();
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

        
        if (!isSpeaking && !isOpenMenu)
        {
            if (Input.GetKey(KeyCode.W) && !isMoving)
            {
                PlayerMove(new Vector2(playerPos.x, playerPos.y + 1));
                facingUp = true;
                facingDown = false;
                facingRight = false;
                facingLeft = false;

                
            }

            if (Input.GetKey(KeyCode.S) && !isMoving)
            {
                PlayerMove(new Vector2(playerPos.x, playerPos.y - 1));
                facingUp = false;    
                facingDown = true;
                facingRight = false;
                facingLeft = false;
            }

            if (Input.GetKey(KeyCode.D) && !isMoving)
            {
                
                PlayerMove(new Vector2(playerPos.x + 1, playerPos.y));
                facingUp = false;
                facingDown = false;
                facingRight = true;
                facingLeft = false;
            }

            if (Input.GetKey(KeyCode.A) && !isMoving)
            {                
                PlayerMove(new Vector2(playerPos.x - 1, playerPos.y));
                facingUp = false;
                facingDown = false;
                facingRight = false;
                facingLeft = true;
            }

          

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            FountainManager fountain = FindObjectOfType<FountainManager>();            
            playerPos = respawnPos;
            this.transform.position = respawnPos;
            Debug.Log(fountain.checkpointPos);
        }

        animator.SetBool("IsMoving", isMoving);
        animator.SetBool("FacingRight", facingRight);
        animator.SetBool("FacingLeft", facingLeft);
        animator.SetBool("FacingUp", facingUp);
        animator.SetBool("FacingDown", facingDown);       
    }
} 