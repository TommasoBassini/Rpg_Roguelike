using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TreasureChestManager : MonoBehaviour
{
    public bool hpPotion;
    public bool mpPotion;
    public bool tankPowerUp;
    public bool dpsPowerUp;
    public bool magePowerUp;
    public bool isClosed = true;
    public bool inFront = false;
    public Sprite openChest;
    private SpriteRenderer sr;
    public GameObject interact;
    void Start()
    {
        Invoke("SetObjectToCell", 0.3f);
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.clear;
    }

    void Update()
    {
        if (inFront == true && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && isClosed == true) 
        {
            Vector2 pos = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f);
            Grid grid = FindObjectOfType<Grid>();
            grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().cellObject = this.gameObject;
            grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().isSemiWall = true;
            isClosed = false;
            if (hpPotion)
            {
                PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
                UiControlExploration ui = FindObjectOfType<UiControlExploration>();
                stats.nPotionHealth++;
                ui.AggiornaPotion();
            }
            if (mpPotion)
            {
                PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
                UiControlExploration ui = FindObjectOfType<UiControlExploration>();
                stats.nPotionMana++;
                ui.AggiornaPotion();
            }
            Debug.Log("Scrigno aperto!!");
            sr.sprite = openChest;
            
        }
    }

    void SetObjectToCell()
    {
        Vector2 pos = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f);
        Grid grid = FindObjectOfType<Grid>();
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().cellObject = this.gameObject;
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().isSemiWall = true;
    }
        

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player" && isClosed == true)
        {
            inFront = true;
            Text text = interact.transform.Find("A/Text").GetComponent<Text>();
            text.text = "Apri scrigno";
            interact.SetActive(true);
        }          
	}

    void OnTriggerExit2D(Collider2D coll)
    {
        inFront = false;
        interact.SetActive(false);
    }
}
