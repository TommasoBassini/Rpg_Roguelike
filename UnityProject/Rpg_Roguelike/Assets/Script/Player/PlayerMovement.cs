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
    public int nKeys = 0;
    public AudioClip walk;
    public int nPassi = 0;

    public bool isOpenMenu = false;

    void Start ()
    {
        fog = this.GetComponent<FogOfWarManager>();
        Invoke("CoFog", 0.1f);
        Debug.Log(GetComponent<SpriteRenderer>().color);
    }

    // Imposta la posizione iniziale del giocatore all'interno della griglia
    public void SetPlayerPosition()
    {
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        this.transform.position = grid.cells[(int)playerPos.x, (int)playerPos.y].gameObject.transform.position;
    }

    void CoFog()
    {
        fog.Fog(playerPos);
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
                fog.Fog(playerPos);

                nPassi++;
                randomEncounterProbably += 5;
                if (Random.Range(randomEncounterProbably, 300) > 295 && nPassi > 20)
                {
                    nPassi = 0;
                    GameControl gc = FindObjectOfType<GameControl>();
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
                this.transform.position = new Vector3(grid.cells[(int)playerPos.x, (int)playerPos.y].transform.position.x, grid.cells[(int)playerPos.x, (int)playerPos.y].transform.position.y, 0);
                isMoving = false;
            }
        }
        
        if (!isSpeaking && !isOpenMenu)
        {
            if ((Input.GetKey(KeyCode.W) || Input.GetAxis("Vertical") > 0.5f) && !isMoving)
            {

               // GameObject.Find("AudioManager").GetComponent<AudioSource>().PlayOneShot(walk);

                PlayerMove(new Vector2(playerPos.x, playerPos.y + 1));
                facingUp = true;
                facingDown = false;
                facingRight = false;
                facingLeft = false;

                
            }

            if ((Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") < -0.5f) && !isMoving)
            {

               // GameObject.Find("AudioManager").GetComponent<AudioSource>().PlayOneShot(walk);

                PlayerMove(new Vector2(playerPos.x, playerPos.y - 1));
                facingUp = false;    
                facingDown = true;
                facingRight = false;
                facingLeft = false;
            }

            if ((Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0.5f) && !isMoving)
            {

               // GameObject.Find("AudioManager").GetComponent<AudioSource>().PlayOneShot(walk);

                PlayerMove(new Vector2(playerPos.x + 1, playerPos.y));
                facingUp = false;
                facingDown = false;
                facingRight = true;
                facingLeft = false;
            }

            if ((Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < -0.5f) && !isMoving)
            {

              // GameObject.Find("AudioManager").GetComponent<AudioSource>().PlayOneShot(walk);

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