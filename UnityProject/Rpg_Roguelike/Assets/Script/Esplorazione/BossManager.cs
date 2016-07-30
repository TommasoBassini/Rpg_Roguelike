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

    void Awake()
    {
        if (textFile != null)
        {
            textRow = (textFile.text.Split('\n'));
            nRow = textRow.Length - 1;
        }

    }

    void Update ()
    {
        if (facingBoss == true && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && !isDIalogueStart)
        {
            player = FindObjectOfType<PlayerMovement>();
            player.isSpeaking = true;
            isDIalogueStart = true;

            panelDialogue.SetActive(true);
            text.text = textRow[0];
            return;
        }
        if (facingBoss == true && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && isDIalogueStart)
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
                player.isSpeaking = false;
                isDIalogueStart = false;
                StartBossBattle();
            }
            return;
        }
    }

    public void StartBossBattle()
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
        stats.tipoIncontro = tipoIncontro;
        SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
        battleScene = SceneManager.GetSceneByName("Battle");
        SceneManager.SetActiveScene(battleScene);
    }




    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            facingBoss = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        facingBoss = false;
        //interact.SetActive(false);
    }


}
