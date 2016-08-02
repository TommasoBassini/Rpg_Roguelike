using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour {

    public bool facingBoss = false;
    private bool isDIalogueStart = false;
    public TextAsset textFile;
    public string[] textRow;
    private int nRow = 0;
    private int currentLine = 0;
    public GameObject panelDialogue;
    public Text text;
    private PlayerMovement player;
    public Scene battleScene;
    public int tipoIncontro;
    private GameControl gc;
    private PlayerStatsControl stats;
    public int nBoss;
    private bool oneTime;
    public GameObject interact;


    void Awake()
    {
        stats = FindObjectOfType<PlayerStatsControl>();
        if (textFile != null)
        {
            textRow = (textFile.text.Split('\n'));
            nRow = textRow.Length - 1;
        }
        gc = FindObjectOfType<GameControl>();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.clear;
    }

    void Update ()
    {
        if (stats.boss[nBoss])
        {
            Vector2 pos = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f);
            Grid grid = FindObjectOfType<Grid>();
            grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().cellObject = null;
            grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().isSemiWall = false;
            Destroy(this.gameObject);
        }

        if (facingBoss == true && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && !isDIalogueStart && !gc.incontroON)
        {
            player = FindObjectOfType<PlayerMovement>();
            player.isSpeaking = true;
            isDIalogueStart = true;

            panelDialogue.SetActive(true);
            text.text = textRow[0];
            return;
        }
        if (facingBoss == true && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && isDIalogueStart && !gc.incontroON)
        {
            currentLine++;
            if (currentLine < nRow)
            {
                text.text = textRow[currentLine];
            }
            else
            {
                text.text = "";
                panelDialogue.SetActive(false);
                if (!oneTime)
                {
                    oneTime = true;
                    StartBossBattle();
                }
                Invoke("ResetDialog", 10f);
            }
            return;
        }
    }

    public void StartBossBattle()
    {
        GameControl gc = FindObjectOfType<GameControl>();
        StartCoroutine (gc.RandomEncounter(new Vector2(120, 120), tipoIncontro));
    }

    void ResetDialog()
    {
        oneTime = false;
        isDIalogueStart = false;
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            facingBoss = true;
            Text text = interact.transform.Find("A/Text").GetComponent<Text>();
            text.text = "Parla";
            interact.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        facingBoss = false;
        interact.SetActive(false);
    }


}
