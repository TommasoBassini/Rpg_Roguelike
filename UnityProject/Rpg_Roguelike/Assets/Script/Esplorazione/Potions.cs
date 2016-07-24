using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Potions : MonoBehaviour
{
    public bool oneTime = false;
    public bool isHpPotion;
    public bool isMpPotion;
    private PlayerStatsControl stats;
    private Player player;
    private bool isDIalogueStart = false;
    public TextAsset textFile;
    public string[] textRow;
    private int nRow = 0;
    private int currentLine = 0;
    public GameObject panelDialogue;
    public Text text;
    private PlayerMovement playerMov;


    
    void Start ()
    {
        Invoke("SetObjectToCell", 0.3f);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.clear;
        stats = FindObjectOfType<PlayerStatsControl>();
    }



    void SetObjectToCell()
    {
        Vector2 pos = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f);
        Grid grid = FindObjectOfType<Grid>();
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().cellObject = this.gameObject;
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().isWall = true;
    }


    
    void Update ()
    {
        if (oneTime == true && Input.GetKeyDown(KeyCode.E))
        {
            if (isHpPotion == true && stats.soldi > 0) // Al posto dello zero, verrà imposto come limite il prezzo della pozione
            {
                stats.nPotionHealth++;
                //stats.soldi--;
                stats.soldi -= 20; 
            }

            else if (isMpPotion == true && stats.soldi > 0)
            {
                stats.nPotionMana++;
                stats.soldi--;
            }
        }


    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

                playerMov = col.gameObject.GetComponent<PlayerMovement>();
                panelDialogue.SetActive(true);
                text.text = "Se vuoi acquistare la pozione, premi E";
        }
    }
    


    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            oneTime = true;           
        }     
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        oneTime = false;
        panelDialogue.SetActive(false);
        text.text = "";
    }
}
