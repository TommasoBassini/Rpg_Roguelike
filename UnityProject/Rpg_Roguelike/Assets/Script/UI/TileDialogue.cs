using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TileDialogue : MonoBehaviour
{
    private bool isDIalogueStart = false;
    public TextAsset textFile;
    public string[] textRow;
    private int nRow = 0;
    private int currentLine = 0;
    public GameObject panelDialogue;
    public Text text;
    private PlayerMovement player;

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
                player.isSpeaking = false;
                isDIalogueStart = false;
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player");
        {
            if (!isDIalogueStart)
            {
                player = col.gameObject.GetComponent<PlayerMovement>();
                player.isSpeaking = true;
                isDIalogueStart = true;

                panelDialogue.SetActive(true);
                text.text = textRow[0];
            }
        }
    }
}
