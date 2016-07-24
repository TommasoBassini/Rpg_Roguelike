using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CombatController : MonoBehaviour
{

    public List<GameObject> player;
    public List<float> tempo;
    public int turno = 0;

    private BattleGrid grid;
    public Image[] turnImage = new Image[8];

    public Sprite[] turnPortrait;

    public List<int> enemyLvl = new List<int>();
    public bool changeReady;

    void Start ()
    {
        grid = FindObjectOfType<BattleGrid>();
	}

    void Update()
    {
        if (changeReady && Input.anyKeyDown)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("ProvaTommy"));
            SceneManager.UnloadScene(1);
        }
    }

    public void TurnOrder(List<float> _players, int n)
    {
        float temp;
        GameObject playerTemp;
        for (int i = 0; i < n-1; i++)
        {
            for (int k = 0; k < n - 1 - i; k++)
            {
                if (_players[k] > _players[k + 1])
                {
                    temp = _players[k];
                    playerTemp = player[k];

                    _players[k] = _players[k + 1];
                    player[k] = player[k + 1];

                    player[k + 1] = playerTemp;
                    _players[k + 1] = temp;
                }
            }
        }
        UpdateTurnPortrait();
        UiController ui = FindObjectOfType<UiController>();
        ui.SetUiToPlayer(player[turno]);
    }

    public void UpdateTurnPortrait()
    {
        string nome = "";
        for (int i = 0; i < turnImage.Length; i++)
        {
            if (player[i].name == "Bho")
            {
                turnImage[i].sprite = turnPortrait[0];
                if(i == 0)
                {
                    nome = "dps";
                }
            }
            if (player[i ].name == "Elibeth")
            {
                turnImage[i].sprite = turnPortrait[1];
                if (i == 0)
                {
                    nome = "Elibeth";
                }
            }
            if (player[i ].name == "Johell")
            {
                turnImage[i].sprite = turnPortrait[2];
                if (i == 0)
                {
                    nome = "Johell";
                }
            }
            if (player[i].name.Contains("Mage"))
            {
                turnImage[i].sprite = turnPortrait[3];
                if (i == 0)
                {
                    nome = "Mage";
                }
            }
            if (player[i].name.Contains("Melee"))
            {
                turnImage[i].sprite = turnPortrait[4];
                if (i == 0)
                {
                    nome = "Melee";
                }
            }
            if (player[i].name.Contains("Ranged"))
            {
                turnImage[i].sprite = turnPortrait[5];
                if (i == 0)
                {
                    nome = "Ranged";
                }
            }
        }
        Text text = GameObject.Find("Nome").GetComponent<Text>();
        text.text = nome.ToUpper();
    }

    public void ConfirmMovement()
    {
        Character character = player[turno].GetComponent<Character>();
        grid.ResetWalkableCell();
        character.isMovible = false;
        grid.cells[(int)character.pos.x, (int)character.pos.y].isOccupied = true;
        grid.cells[(int)character.pos.x, (int)character.pos.y].occupier = character.gameObject;
    }

    public void EndOfTurn()
    {
        AzzeraRitratto();
        if (player[turno].CompareTag("Enemy"))
        {
            SpriteRenderer sr = player[turno].GetComponent<SpriteRenderer>();
            sr.color = Color.white;
        }
        UiController ui = FindObjectOfType<UiController>();
        //turno++;
        player.RemoveAt(0);

        UpdateTurnPortrait();
        if (player[turno].GetComponent<Enemy>() != null)
        {
            ui.UI.SetActive(false);
            Invoke ("AggiornaRitrattoEnemy", 0.1f);
            player[turno].GetComponent<Enemy>().Ai();
            player[turno].GetComponent<Enemy>().StartTurn();
        }
        else
        {
            Invoke("AggiornaRitrattoPlayer", 0.1f);
            ui.SetUiToPlayer(player[turno]);
            ui.UI.SetActive(true);
            player[turno].GetComponent<Player>().StartTurn();
        }
    }

    public bool CheckWinner()
    {
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length - 1 <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Win()
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();

        int lvlTot = 0;
        foreach (var item in enemyLvl)
        {
            lvlTot += item;
        }

        int exp = Mathf.RoundToInt((lvlTot * (Random.Range(40, 45))) * Random.Range(1.0f, 1.25f));
        int sangue = Mathf.RoundToInt((lvlTot * (Random.Range(7, 10))) * Random.Range(1.0f, 1.25f));
        bool health = false;
        if (Random.Range(0f,100f) > 50)
        {
            health = true;
        }

        bool mana = false;
        if (Random.Range(0f, 100f) > 95)
        {
            mana = true;
        }

        UiController ui = FindObjectOfType<UiController>();
        StartCoroutine (ui.EndPanel(stats.esperience, exp, stats.soldi, sangue, health, mana));

        Player[] players = FindObjectsOfType<Player>();

        foreach (var item in players)
        {
            item.EndBattle();
        }

        stats.esperience += exp;
        stats.soldi += sangue;
    }

    public void Lose()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("ProvaTommy"));
        SceneManager.UnloadScene(1);
    }

    void AggiornaRitrattoEnemy()
    {
        UiController ui = FindObjectOfType<UiController>();
        ui.enemyInfoPanel.SetActive(true);
        GameObject info = GameObject.Find("EnemyInfo");
        Image icona = info.transform.Find("Image").GetComponent<Image>();
        Text nome = info.transform.Find("NomeSpell").GetComponent<Text>();

        icona.sprite = player[turno].GetComponent<Enemy>().icona;
        nome.text = player[turno].name;
        Text textVita = ui.enemyInfoPanel.transform.Find("HealthText").GetComponent<Text>();
        textVita.text = player[turno].GetComponent<Enemy>().hp + "/" + player[turno].GetComponent<Enemy>().hpMax;


        Image vita = ui.enemyInfoPanel.transform.Find("Health").GetComponent<Image>();
        vita.color = new Color(vita.color.r, vita.color.g, vita.color.b, 1);
        Image BaseHealth = ui.enemyInfoPanel.transform.Find("BaseHealth").GetComponent<Image>();
        BaseHealth.color = new Color(BaseHealth.color.r, BaseHealth.color.g, BaseHealth.color.b, 1);
    }

    void AggiornaRitrattoPlayer()
    {
        UiController ui = FindObjectOfType<UiController>();
        ui.enemyInfoPanel.SetActive(true);
        GameObject info = GameObject.Find("EnemyInfo");
        Image icona = info.transform.Find("Image").GetComponent<Image>();
        Text nome = info.transform.Find("NomeSpell").GetComponent<Text>();

        icona.sprite = player[turno].GetComponent<Player>().image;
        nome.text = player[turno].name;
        Text textVita = ui.enemyInfoPanel.transform.Find("HealthText").GetComponent<Text>();
        textVita.text = player[turno].GetComponent<Player>().stats.hp + "/" + player[turno].GetComponent<Player>().stats.hpMax;


        Image vita = ui.enemyInfoPanel.transform.Find("Health").GetComponent<Image>();
        vita.color = new Color(vita.color.r, vita.color.g, vita.color.b, 1);
        Image BaseHealth = ui.enemyInfoPanel.transform.Find("BaseHealth").GetComponent<Image>();
        BaseHealth.color = new Color(BaseHealth.color.r, BaseHealth.color.g, BaseHealth.color.b, 1);
    }

    void AzzeraRitratto()
    {
        UiController ui = FindObjectOfType<UiController>();
        ui.enemyInfoPanel.SetActive(false);
    }
}
