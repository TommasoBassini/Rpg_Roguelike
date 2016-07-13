using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    private CombatController cc;
    public GameObject UI;
    public GameObject MainPanel;
    public GameObject MovePanel;
    public GameObject ActionPanel;
    public GameObject EnemyListPanel;
    public Button MoveButton;
    private Vector2 startPos;

    public Button SelectEnemyButton;
    public GameObject enemyInfoPanel;
    public GameObject[] infoPlayers = new GameObject[3];

    public int faseUi = 0;
    private bool waitMovement = true;

    void Start ()
    {
        cc = FindObjectOfType<CombatController>();
        MoveButton.Select();
	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            switch (faseUi)
            {
                case 1:
                    {
                        faseUi = 0;
                        Character character = cc.player[cc.turno].GetComponent<Character>();
                        character.PlayerMove(startPos);
                        MainPanel.SetActive(true);
                        MovePanel.SetActive(false);
                        BattleGrid grid = FindObjectOfType<BattleGrid>();
                        grid.ResetWalkableCell();
                        //MoveButton.Select();
                        break;
                    }
                case 2:
                    {
                        faseUi = 0;

                        MainPanel.SetActive(true);
                        if (MoveButton.IsInteractable())
                        {
                            MoveButton.Select();
                        }
                        else
                        {
                            Button buttonAction = MainPanel.transform.Find("Action").GetComponent<Button>();
                            buttonAction.Select();
                        }
                        ActionPanel.SetActive(false);
                        break;
                    }
            }
        }
        if (Input.GetKeyDown(KeyCode.Return) && faseUi == 1 && waitMovement)
        {
            cc.ConfirmMovement();
            faseUi = 0;
            MoveButton.interactable = false;
            MainPanel.SetActive(true);
            SetUiToPlayer(cc.player[cc.turno]);
        }
    }
    
    public void SetUiToPlayer(GameObject _player)
    {
        Vector3 blocksPos_screenSpace = Camera.main.WorldToScreenPoint(_player.transform.position);
        UI.transform.position = blocksPos_screenSpace;
    }

    public void SetUiPlayer(GameObject Player)
    {
        Player player = Player.GetComponent<Player>();
        Image imageLife = transform.Find("PlayersPanel" + "/"+player.uiInfo.name + "/Health").GetComponent<Image>();
        imageLife.fillAmount = ((100 *  (float)player.stats.hp) / (float)player.stats.hpMax) / 100;

        Image imageMp = transform.Find("PlayersPanel" + "/" + player.uiInfo.name + "/Mana").GetComponent<Image>();
        imageMp.fillAmount = ((100 * (float)player.stats.mp) / (float)player.stats.mpMax) / 100;
    }

    public void AggiornaVita(float hpMax,float hp, GameObject info)
    {
        Image image = transform.Find("PlayersPanel" + "/" + info.name + "/Health").GetComponent<Image>();
        
        float fill = ((100 * hp) / hpMax) / 100;
        image.fillAmount = ((100 * hp) / hpMax) / 100;
    }

    public void Move()
    {
        waitMovement = false;
        Character character = cc.player[cc.turno].GetComponent<Character>();
        startPos = character.pos;
        character.Move();
        faseUi = 1;
        MainPanel.SetActive(false);
        Invoke("ResetBoolMovement", 0.1f); 
    }
    void ResetBoolMovement()
    {
        waitMovement = true;
    }
    public void ConfirmPosition()
    {
        cc.ConfirmMovement();
        faseUi = 0;
        MoveButton.interactable = false;
        MainPanel.SetActive(true);
        MovePanel.SetActive(false);
    }


    public void BackToMain()
    {
        MainPanel.SetActive(true);
        ActionPanel.SetActive(false);
    }

    public void Action()
    {
        faseUi = 2;
        MainPanel.SetActive(false);
        ActionPanel.SetActive(true);
        Player player = cc.player[cc.turno].GetComponent<Player>();
        player.CheckAttack();
        if (player.enemyDisp.Count == 0)
        {
            Button buttonAttack = ActionPanel.transform.Find("Attack").GetComponent<Button>();
            buttonAttack.interactable = false;
            Button buttonAbility = ActionPanel.transform.Find("Ability").GetComponent<Button>();
            buttonAbility.Select();

        }
        else
        {
            Button buttonAttack = ActionPanel.transform.Find("Attack").GetComponent<Button>();
            buttonAttack.interactable = true;
            buttonAttack.Select();
        }
    }

    public void PassaTurno()
    {
        cc.EndOfTurn();

        MoveButton.interactable = true;
        MainPanel.SetActive(true);
        MovePanel.SetActive(false);
        EnemyListPanel.SetActive(false);
        ActionPanel.SetActive(false);
        Button buttonAction = MainPanel.transform.Find("Action").GetComponent<Button>();
        buttonAction.interactable = true;

    }

    public void Attack()
    {
        Player player = cc.player[cc.turno].GetComponent<Player>();
        player.SpawnAttackBox();
        ActionPanel.SetActive(false);
        EnemyListPanel.SetActive(true);

            foreach (GameObject enemy in player.enemyDisp)
            {
                Button newButton = Instantiate(SelectEnemyButton);
                newButton.transform.SetParent(EnemyListPanel.transform, false);

                EnemyButton enemyButton = newButton.GetComponent<EnemyButton>();
                enemyButton.enemy = enemy;
                enemyButton.enemyInfoPanel = enemyInfoPanel;
                Text text = newButton.GetComponentInChildren<Text>();
                text.text = enemy.name;
            }
            player.enemyDisp.Clear();
    }
}
