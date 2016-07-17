using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

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

    public GameObject dpsAbilityPanel;
    public GameObject mageAbilityPanel;
    public GameObject tankAbilityPanel;
    public GameObject activeAbilityPanel;
    public List<GameObject> attackBoxList = new List<GameObject>();

    public GameObject textDamagePrefab;
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
                case 3:
                    {
                        faseUi = 2;
                        foreach (var item in attackBoxList)
                        {
                            Destroy(item);
                        }
                        attackBoxList.Clear();
                        ActionPanel.SetActive(true);
                        activeAbilityPanel.SetActive(false);
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
                        break;
                    }
                case 4:
                    {
                        faseUi = 2;
                        foreach (var item in attackBoxList)
                        {
                            Destroy(item);
                        }
                        attackBoxList.Clear();
                        ActionPanel.SetActive(true);
                        Player player = cc.player[cc.turno].GetComponent<Player>();
                        player.CheckAttack();
                        foreach (var item in player.checkboxAttack)
                        {
                            Destroy(item);
                        }
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
        Vector3 targetPos_screenSpace = Camera.main.WorldToScreenPoint(_player.transform.position);
        UI.transform.position = targetPos_screenSpace;
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
        image.fillAmount = ((100 * hp) / hpMax) / 100;
    }

    public void AggiornaMana(float mpMax, float mp, GameObject info)
    {
        Image image = transform.Find("PlayersPanel" + "/" + info.name + "/Mana").GetComponent<Image>();

        image.fillAmount = ((100 * mp) / mpMax) / 100;
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
    public void Ability()
    {
        faseUi = 3;
        ActionPanel.SetActive(false);
        Character character = cc.player[cc.turno].GetComponent<Character>();
        string player = character.gameObject.name.ToLower();
        if (player.Contains("dps"))
        {
            dpsAbilityPanel.SetActive(true);
            activeAbilityPanel = dpsAbilityPanel;
            activeAbilityPanel.transform.GetChild(0).GetComponent<Button>().Select();
        }
        if (player.Contains("tank"))
        {
            tankAbilityPanel.SetActive(true);
            activeAbilityPanel = tankAbilityPanel;
        }
        if (player.Contains("mage"))
        {
            mageAbilityPanel.SetActive(true);
            activeAbilityPanel = mageAbilityPanel;
            activeAbilityPanel.transform.GetChild(0).GetComponent<Button>().Select();
        }
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
        faseUi = 4;
        Player player = cc.player[cc.turno].GetComponent<Player>();
        player.SpawnAttackBox();
        ActionPanel.SetActive(false);
        EnemyListPanel.SetActive(true);
        List<Button> button = new List<Button>();

        foreach (GameObject enemy in player.enemyDisp)
        {
            Button newButton = Instantiate(SelectEnemyButton);
            newButton.transform.SetParent(EnemyListPanel.transform, false);

            EnemyButton enemyButton = newButton.GetComponent<EnemyButton>();
            enemyButton.enemy = enemy;
            enemyButton.enemyInfoPanel = enemyInfoPanel;
            button.Add(newButton);
        }

        if (button.Count > 1)
        {
            for (int i = 0; i <= button.Count - 1; i++)
            {
                int n = i;
                if (i == button.Count - 1)
                {
                    Navigation custumNav = new Navigation();
                    custumNav.mode = Navigation.Mode.Explicit;
                    custumNav.selectOnDown = button[0];
                    custumNav.selectOnUp = button[n- 1];
                    button[i].navigation = custumNav;
                    Debug.Log(button[i].navigation.mode);

                }
                else if (i == 0)
                {
                    Navigation custumNav = new Navigation();
                    custumNav.mode = Navigation.Mode.Explicit;
                    custumNav.selectOnDown = button[n + 1];
                    custumNav.selectOnUp = button[button.Count - 1];
                    button[i].navigation = custumNav;
                    Debug.Log(button[i].navigation.mode);
                }
                else
                {
                    Navigation custumNav = new Navigation();
                    custumNav.mode = Navigation.Mode.Explicit;
                    custumNav.selectOnDown = button[n+ 1];
                    custumNav.selectOnUp = button[n- 1];
                    button[i].navigation = custumNav;
                    Debug.Log(button[i].navigation.mode);

                }
            }
        }
        button.Clear();
        player.enemyDisp.Clear();
        EnemyListPanel.transform.GetChild(0).GetComponent<Button>().Select();
    }

    public void DamageText(GameObject pos, int danni, Color color)
    {
        GameObject textPrefab = Instantiate(textDamagePrefab);
        Vector3 targetPos_screenSpace = Camera.main.WorldToScreenPoint(pos.transform.position);
        textPrefab.transform.SetParent(this.gameObject.transform);
        textPrefab.transform.position = targetPos_screenSpace;

        Text text = textPrefab.GetComponentInChildren<Text>();
        text.text = danni.ToString();
        text.color = color;
    }

    public void CoAttivaPanel()
    {
        StartCoroutine(attivaPanel());
    }

    public IEnumerator attivaPanel()
    {
        yield return new WaitForSeconds(0.6f);
        UiController ui = FindObjectOfType<UiController>();

        ui.EnemyListPanel.SetActive(false);
        ui.MainPanel.SetActive(true);
        ui.enemyInfoPanel.SetActive(false);
        Button actionButton = ui.MainPanel.transform.Find("Action").GetComponent<Button>();
        actionButton.interactable = false;
        foreach (Transform item in ui.MainPanel.transform)
        {
            if (item.gameObject.GetComponent<Button>().IsInteractable())
            {
                item.gameObject.GetComponent<Button>().Select();
                break;
            }
        }
    }
}
