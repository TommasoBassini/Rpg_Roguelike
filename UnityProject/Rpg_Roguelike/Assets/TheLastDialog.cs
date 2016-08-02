using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TheLastDialog : MonoBehaviour
{
    private bool isDIalogueStart = false;
    public TextAsset textFile;
    public string[] textRow;
    private int nRow = 0;
    private int currentLine = 0;
    public GameObject panelDialogue;
    public Text text;
    private PlayerMovement player;
    private bool oneTime;
    public Camera camera;

    void Awake()
    {
        if (textFile != null)
        {
            textRow = (textFile.text.Split('\n'));
            nRow = textRow.Length - 1;
        }

        //panelDialogue = GameObject.Find("DialoguePanel");
        //text = panelDialogue.GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (Input.anyKeyDown && isDIalogueStart)
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
        }
    }

    public void StartBossBattle()
    {
        GameControl gc = FindObjectOfType<GameControl>();
        CameraController cc = camera.GetComponent<CameraController>();
        cc.toPlayer = false;
        StartCoroutine(gc.RandomEncounter(new Vector2(120, 120), 4));
    }

    void ResetDialog()
    {
        oneTime = false;
        isDIalogueStart = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            CameraController cc = camera.GetComponent<CameraController>();
            cc.toPlayer = false;
            camera.orthographicSize = 7;
            camera.transform.position = new Vector3(cc.target.transform.position.x, cc.target.transform.position.y + 3, -4.5f);
            if (!isDIalogueStart)
            {
                player = col.gameObject.GetComponent<PlayerMovement>();
                player.isSpeakingTwo = true;
                isDIalogueStart = true;

                panelDialogue.SetActive(true);
                text.text = textRow[0];
            }
        }
    }
}