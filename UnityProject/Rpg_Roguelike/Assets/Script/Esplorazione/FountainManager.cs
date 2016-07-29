using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FountainManager : MonoBehaviour {

    private Cell pos;
    public Vector2 checkpointPos;    
    public bool inRange = false;
    public GameObject interact;

    void Start()
    {        
        Invoke("SetObjectToCell", 0.3f);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.clear;
    }


    void SetObjectToCell()
    {
        Vector2 pos = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f);
        Grid grid = FindObjectOfType<Grid>();
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().cellObject = this.gameObject;
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().isSemiWall = true;
    }

    
    void Update()
    {
        if (inRange == true && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0)))
        {
            PlayerMovement pos = FindObjectOfType<PlayerMovement>();
            checkpointPos = pos.playerPos;
            pos.respawnPos = checkpointPos;

            PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
            UiControlExploration ui = FindObjectOfType<UiControlExploration>();
            stats.lastCheckpoint = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f);
            stats.statsDps.hp = stats.statsDps.hpMax;
            stats.statsTank.hp = stats.statsTank.hpMax;
            stats.statsMago.hp = stats.statsMago.hpMax;

            stats.statsDps.mp = stats.statsDps.mpMax;
            stats.statsTank.mp = stats.statsTank.mpMax;
            stats.statsMago.mp = stats.statsMago.mpMax;

            ui.AggiornaMana();
            ui.AggiornaVita();
            Debug.Log("Hai recuperato vita");                     
        }
    }



    void OnTriggerStay2D(Collider2D coll)
    {   
         if (coll.gameObject.name == "Player")
            {
                inRange = true;
                Text text = interact.transform.Find("A/Text").GetComponent<Text>();
                text.text = "Ripristina vita e mana";
                interact.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        inRange = false;
        interact.SetActive(false);
    }        
  }
