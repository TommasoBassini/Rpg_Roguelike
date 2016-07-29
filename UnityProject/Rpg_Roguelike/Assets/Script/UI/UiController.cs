using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UiController : MonoBehaviour
{
    private CombatController cc;
    public GameObject UI;
    public GameObject MainPanel;
    public GameObject ActionPanel;
    public GameObject EnemyListPanel;
    public Button MoveButton;
    private Vector2 startPos;

    public Button SelectEnemyButton;
    public Button InfoEnemyButton;
    public GameObject enemyInfoPanel;
    public GameObject[] infoPlayers = new GameObject[3];

    public int faseUi = 0;
    private bool waitMovement = true;

    public GameObject dpsAbilityPanel;
    public GameObject mageAbilityPanel;
    public GameObject tankAbilityPanel;
    public GameObject activeAbilityPanel;
    public List<GameObject> attackBoxList = new List<GameObject>();
    public List<GameObject> buffBoxList = new List<GameObject>();         //Lista delle celle verdi

    public GameObject textDamagePrefab;
    private bool dpsAbility = false;

    public Button healtPotionButton;
    public Button manaPotionButton;
    public Button potionButton;

    public GameObject endPanel;

    void Start ()
    {
        cc = FindObjectOfType<CombatController>();
        Invoke("CoSetUi", 0.4f);
        MoveButton.Select();
	}

    void CoSetUi()
    {
        SetUiToPlayer(cc.player[cc.turno]);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            switch (faseUi)
            {
                case 1:
                    {
                        faseUi = 0;
                        Character character = cc.player[cc.turno].GetComponent<Character>();
                        character.PlayerMove(startPos);
                        MainPanel.SetActive(true);
                        BattleGrid grid = FindObjectOfType<BattleGrid>();
                        grid.ResetWalkableCell();
                        character.isMovible = false;
                        grid.cells[(int)startPos.x, (int)startPos.y].isOccupied = true;
                        grid.cells[(int)startPos.x, (int)startPos.y].occupier = character.gameObject;
                        //MoveButton.Select();
                        break;
                    }
                case 2:
                    {
                        faseUi = 0;

                        foreach (Transform item in EnemyListPanel.transform)
                        {
                            Destroy(item.gameObject);
                        }
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
                        UiController ui = FindObjectOfType<UiController>();

                        Text textVita = enemyInfoPanel.transform.Find("HealthText").GetComponent<Text>();
                        textVita.text = "";
                        Text textNome = enemyInfoPanel.transform.Find("NomeNemico").GetComponent<Text>();
                        textNome.text = "";
                        Image vita = enemyInfoPanel.transform.Find("Health").GetComponent<Image>();
                        vita.color = new Color(vita.color.r, vita.color.g, vita.color.b, 0);
                        Image BaseHealth = enemyInfoPanel.transform.Find("BaseHealth").GetComponent<Image>();
                        BaseHealth.color = new Color(BaseHealth.color.r, BaseHealth.color.g, BaseHealth.color.b, 0);
                        enemyInfoPanel.transform.Find("Poison").gameObject.SetActive(false);
                        enemyInfoPanel.transform.Find("Att").gameObject.SetActive(false);
                        enemyInfoPanel.transform.Find("Dif").gameObject.SetActive(false);
                        ui.EnemyListPanel.SetActive(false);
                        GameObject target = GameObject.FindGameObjectWithTag("Target");
                        Destroy(target);
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
                        Text textVita = enemyInfoPanel.transform.Find("HealthText").GetComponent<Text>();
                        textVita.text = "";
                        Text textNome = enemyInfoPanel.transform.Find("NomeNemico").GetComponent<Text>();
                        textNome.text = "";
                        Image vita = enemyInfoPanel.transform.Find("Health").GetComponent<Image>();
                        vita.enabled = false;
                        enemyInfoPanel.transform.Find("Poison").gameObject.SetActive(false);
                        enemyInfoPanel.transform.Find("Att").gameObject.SetActive(false);
                        enemyInfoPanel.transform.Find("Dif").gameObject.SetActive(false);

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
                case 5:
                    {
                        faseUi = 3;
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
                        break;
                    }
            }
        }
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.Joystick1Button0) ) && faseUi == 1 && waitMovement)
        {
            if (dpsAbility)
            {
                cc.ConfirmMovement();
                faseUi = 0;
                Button actionButton = MainPanel.transform.Find("Action").GetComponent<Button>();
                actionButton.interactable = false;
                MainPanel.SetActive(true);
                SetUiToPlayer(cc.player[cc.turno]);
                foreach (Transform item in MainPanel.transform)
                {
                    if (item.gameObject.GetComponent<Button>().IsInteractable())
                    {
                        item.gameObject.GetComponent<Button>().Select();
                        break;
                    }
                }
            }
            else
            {
                cc.ConfirmMovement();
                faseUi = 0;
                MoveButton.interactable = false;
                MainPanel.SetActive(true);
                SetUiToPlayer(cc.player[cc.turno]);
            }
        }
    }

    public void EnemyInfo()
    {
        faseUi = 2;
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        List<Button> button = new List<Button>();
        EnemyListPanel.SetActive(true);
        foreach (var item in enemy)
        {
            Button newButton = Instantiate(InfoEnemyButton);
            newButton.transform.SetParent(EnemyListPanel.transform, false);

            EnemyButton enemyButton = newButton.GetComponent<EnemyButton>();
            enemyButton.enemy = item;
            enemyButton.enemyInfoPanel = enemyInfoPanel;
            button.Add(newButton);
            newButton.gameObject.SetActive(true);
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
                    custumNav.selectOnUp = button[n - 1];
                    button[i].navigation = custumNav;
                }
                else if (i == 0)
                {
                    Navigation custumNav = new Navigation();
                    custumNav.mode = Navigation.Mode.Explicit;
                    custumNav.selectOnDown = button[n + 1];
                    custumNav.selectOnUp = button[button.Count - 1];
                    button[i].navigation = custumNav;
                    button[i].Select();
                }
                else
                {
                    Navigation custumNav = new Navigation();
                    custumNav.mode = Navigation.Mode.Explicit;
                    custumNav.selectOnDown = button[n + 1];
                    custumNav.selectOnUp = button[n - 1];
                    button[i].navigation = custumNav;
                }
            }
        }
        button.Clear();
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
        Text textVita = transform.Find("PlayersPanel" + "/" + player.uiInfo.name + "/VitaText").GetComponent<Text>();
        textVita.text = player.stats.hp.ToString() + "/" + player.stats.hpMax.ToString();
        Text textMana = transform.Find("PlayersPanel" + "/" + player.uiInfo.name + "/ManaText").GetComponent<Text>();
        textMana.text = player.stats.mp.ToString() + "/" + player.stats.mpMax.ToString();
        Image imageMp = transform.Find("PlayersPanel" + "/" + player.uiInfo.name + "/Mana").GetComponent<Image>();
        imageMp.fillAmount = ((100 * (float)player.stats.mp) / (float)player.stats.mpMax) / 100;
    }

    public void AggiornaVita(float hpMax,float hp, GameObject info)
    {
        Image image = transform.Find("PlayersPanel" + "/" + info.name + "/Health").GetComponent<Image>();
        image.fillAmount = ((100 * hp) / hpMax) / 100;
        Text textVita = transform.Find("PlayersPanel" + "/" + info.name + "/VitaText").GetComponent<Text>();
        textVita.text = hp.ToString() + "/" + hpMax.ToString();
    }

    public void AggiornaMana(float mpMax, float mp, GameObject info)
    {
        Image image = transform.Find("PlayersPanel" + "/" + info.name + "/Mana").GetComponent<Image>();
        Text textMana = transform.Find("PlayersPanel" + "/" + info.name + "/ManaText").GetComponent<Text>();
        textMana.text = mp.ToString() + "/" + mpMax.ToString();
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
        Invoke("ResetBoolMovement", 0.3f); 
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
        if (player.Contains("jopep"))
        {
            dpsAbilityPanel.SetActive(true);
            activeAbilityPanel = dpsAbilityPanel;
            activeAbilityPanel.transform.GetChild(0).GetComponent<Button>().Select();
        }
        if (player.Contains("johell"))
        {
            tankAbilityPanel.SetActive(true);
            activeAbilityPanel = tankAbilityPanel;
        }
        if (player.Contains("elibeth"))
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

        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();

        if (stats.nPotionHealth > 0)
        {
            healtPotionButton.interactable = true;
            Text textPotionHealth = ActionPanel.transform.Find("PanelVita/NHealth").GetComponent<Text>();
            textPotionHealth.text = stats.nPotionHealth.ToString();
        }
        else
        {
            healtPotionButton.interactable = false;
            Text textPotionHealth = ActionPanel.transform.Find("PanelVita/NHealth").GetComponent<Text>();
            textPotionHealth.text = stats.nPotionHealth.ToString();
        }

        if (stats.nPotionMana > 0)
        {
            manaPotionButton.interactable = true;
            Text textPotionMana = ActionPanel.transform.Find("PanelMana/NMana").GetComponent<Text>();
            textPotionMana.text = stats.nPotionMana.ToString();
        }
        else
        {
            manaPotionButton.interactable = false;
            Text textPotionMana = ActionPanel.transform.Find("PanelMana/NMana").GetComponent<Text>();
            textPotionMana.text = stats.nPotionMana.ToString();
        }
    }

    public void PassaTurno()
    {
        cc.EndOfTurn();

        MoveButton.interactable = true;
        MainPanel.SetActive(true);
        EnemyListPanel.SetActive(false);
        ActionPanel.SetActive(false);
        Button buttonAction = MainPanel.transform.Find("Action").GetComponent<Button>();
        buttonAction.interactable = true;

    }

    public void CoHealthButton()
    {
        UiController ui = FindObjectOfType<UiController>();

        ui.EnemyListPanel.SetActive(true);
        ActionPanel.SetActive(false);

        GameObject[] allyDisp = GameObject.FindGameObjectsWithTag("Player");
        List<Button> button = new List<Button>();

        foreach (GameObject ally in allyDisp)
        {
            Button newButton = Instantiate(potionButton);

            AbilityButton enemyButton = newButton.GetComponent<AbilityButton>();
            enemyButton.enemy = ally;
            enemyButton.enemyInfoPanel = ui.enemyInfoPanel;
            newButton.transform.SetParent(EnemyListPanel.transform, false);
            newButton.onClick.AddListener(() => Vita(enemyButton.enemy));
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
                    custumNav.selectOnUp = button[n - 1];
                    button[i].navigation = custumNav;
                }
                else if (i == 0)
                {
                    Navigation custumNav = new Navigation();
                    custumNav.mode = Navigation.Mode.Explicit;
                    custumNav.selectOnDown = button[n + 1];
                    custumNav.selectOnUp = button[button.Count - 1];
                    button[i].navigation = custumNav;
                }
                else
                {
                    Navigation custumNav = new Navigation();
                    custumNav.mode = Navigation.Mode.Explicit;
                    custumNav.selectOnDown = button[n + 1];
                    custumNav.selectOnUp = button[n - 1];
                    button[i].navigation = custumNav;
                }
            }
        }
        button.Clear();
        EnemyListPanel.transform.GetChild(0).GetComponent<Button>().Select();
    }

    public void Vita(GameObject _player)
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
        stats.nPotionHealth--;
        Player playerTarget = _player.GetComponent<Player>();
        int cura = Mathf.RoundToInt((playerTarget.stats.hpMax * 50)/ 100);
        //calcola effetto
        if (playerTarget.stats.hp + cura > playerTarget.stats.hpMax)
        {
            playerTarget.stats.hp = playerTarget.stats.hpMax;
        }
        else
            playerTarget.stats.hp += cura;

        // Roba UI
        AggiornaVita(playerTarget.stats.hpMax, playerTarget.stats.hp, playerTarget.uiInfo);
        DamageText(playerTarget.gameObject, cura, Color.green);
        foreach (Transform item in EnemyListPanel.transform)
        {
            Destroy(item.gameObject);
        }
        CoSvuotaPanel();

        EnemyListPanel.SetActive(false);
        ActionPanel.SetActive(false);
        MainPanel.SetActive(true);
        enemyInfoPanel.SetActive(false);
        Button actionButton = MainPanel.transform.Find("Action").GetComponent<Button>();
        actionButton.interactable = false;
    }

    public void CoManaButton()
    {
        UiController ui = FindObjectOfType<UiController>();

        ui.EnemyListPanel.SetActive(true);
        ActionPanel.SetActive(false);

        GameObject[] allyDisp = GameObject.FindGameObjectsWithTag("Player");
        List<Button> button = new List<Button>();

        foreach (GameObject ally in allyDisp)
        {
            Button newButton = Instantiate(potionButton);

            AbilityButton enemyButton = newButton.GetComponent<AbilityButton>();
            enemyButton.enemy = ally;
            enemyButton.enemyInfoPanel = ui.enemyInfoPanel;
            newButton.transform.SetParent(EnemyListPanel.transform, false);
            newButton.onClick.AddListener(() => Mana(enemyButton.enemy));
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
                    custumNav.selectOnUp = button[n - 1];
                    button[i].navigation = custumNav;
                }
                else if (i == 0)
                {
                    Navigation custumNav = new Navigation();
                    custumNav.mode = Navigation.Mode.Explicit;
                    custumNav.selectOnDown = button[n + 1];
                    custumNav.selectOnUp = button[button.Count - 1];
                    button[i].navigation = custumNav;
                }
                else
                {
                    Navigation custumNav = new Navigation();
                    custumNav.mode = Navigation.Mode.Explicit;
                    custumNav.selectOnDown = button[n + 1];
                    custumNav.selectOnUp = button[n - 1];
                    button[i].navigation = custumNav;
                }
            }
        }
        button.Clear();
        EnemyListPanel.transform.GetChild(0).GetComponent<Button>().Select();
    }

    public void Mana(GameObject _player)
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
        stats.nPotionMana--;
        Player playerTarget = _player.GetComponent<Player>();
        int cura = Mathf.RoundToInt((playerTarget.stats.mpMax * 50) / 100);
        //calcola effetto
        if (playerTarget.stats.mp + cura > playerTarget.stats.mpMax)
        {
            playerTarget.stats.mp = playerTarget.stats.mpMax;
        }
        else
            playerTarget.stats.mp += cura;

        // Roba UI
        AggiornaMana(playerTarget.stats.mpMax, playerTarget.stats.mp, playerTarget.uiInfo);
        DamageText(playerTarget.gameObject, cura, Color.blue);
        foreach (Transform item in EnemyListPanel.transform)
        {
            Destroy(item.gameObject);
        }
        CoSvuotaPanel();

        EnemyListPanel.SetActive(false);
        ActionPanel.SetActive(false);
        MainPanel.SetActive(true);
        enemyInfoPanel.SetActive(false);
        Button actionButton = MainPanel.transform.Find("Action").GetComponent<Button>();
        actionButton.interactable = false;
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

    public void CoSvuotaPanel()
    {
        StartCoroutine(SvuotaPanel());
    }

    IEnumerator SvuotaPanel()
    {
        yield return new WaitForSeconds(0.5f);
        UiController ui = FindObjectOfType<UiController>();

        Text textVita = enemyInfoPanel.transform.Find("HealthText").GetComponent<Text>();
        textVita.text = "";
        Text textNome = enemyInfoPanel.transform.Find("NomeNemico").GetComponent<Text>();
        textNome.text = "";
        Image vita = enemyInfoPanel.transform.Find("Health").GetComponent<Image>();
        vita.color = new Color(vita.color.r, vita.color.g, vita.color.b, 0);
        Image BaseHealth = enemyInfoPanel.transform.Find("BaseHealth").GetComponent<Image>();
        BaseHealth.color = new Color(BaseHealth.color.r, BaseHealth.color.g, BaseHealth.color.b, 0);
        enemyInfoPanel.transform.Find("Poison").gameObject.SetActive(false);
        enemyInfoPanel.transform.Find("Att").gameObject.SetActive(false);
        enemyInfoPanel.transform.Find("Dif").gameObject.SetActive(false);
        EnemyListPanel.SetActive(false);
        MainPanel.SetActive(true);
        enemyInfoPanel.SetActive(false);
        Button actionButton = MainPanel.transform.Find("Action").GetComponent<Button>();
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

    public void MoveAbility()
    {
        waitMovement = false;
        dpsAbility = true;
        Player character = cc.player[cc.turno].GetComponent<Player>();
        startPos = character.pos;
        character.MoveAbility();
        faseUi = 1;
        MainPanel.SetActive(false);
        Invoke("ResetBoolMovement", 0.1f);
    }

    public IEnumerator EndPanel(int expPrec, int exp, int bloodPrec ,int blood ,bool health, bool mana)
    {
        endPanel.SetActive(true);
        Text textVittoria = endPanel.transform.Find("Vittoria").GetComponent<Text>();
        textVittoria.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);

        Text textRicompensa = endPanel.transform.Find("Ricompensa").GetComponent<Text>();
        textRicompensa.gameObject.SetActive(true);
        Image riga1 = endPanel.transform.Find("Riga1").GetComponent<Image>();
        riga1.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);

        Image sangueSprite = endPanel.transform.Find("SangueSprite").GetComponent<Image>();
        sangueSprite.gameObject.SetActive(true);
        Image expSprite = endPanel.transform.Find("ExpSprite").GetComponent<Image>();
        expSprite.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);

        Text textPrecExp = endPanel.transform.Find("PrecExp").GetComponent<Text>();
        textPrecExp.text = expPrec.ToString();
        textPrecExp.gameObject.SetActive(true);
        Text textPrecSangue = endPanel.transform.Find("PrecSangue").GetComponent<Text>();
        textPrecSangue.text = bloodPrec.ToString();
        textPrecSangue.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        Text textPlusExp = endPanel.transform.Find("PlusExp").GetComponent<Text>();
        textPlusExp.gameObject.SetActive(true);
        Text textPlusSangue = endPanel.transform.Find("PlusSangue").GetComponent<Text>();
        textPlusSangue.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        Text textExp = endPanel.transform.Find("Exp").GetComponent<Text>();
        textExp.text = exp.ToString();
        textExp.gameObject.SetActive(true);
        Text textSangue = endPanel.transform.Find("Sangue").GetComponent<Text>();
        textSangue.text = blood.ToString();
        textSangue.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        Text textExpTot = endPanel.transform.Find("ExpTot").GetComponent<Text>();
        textExpTot.text = (expPrec + exp).ToString();
        textExpTot.gameObject.SetActive(true);
        Text textSangueTot = endPanel.transform.Find("SangueTot").GetComponent<Text>();
        textSangueTot.text = (bloodPrec + blood).ToString();
        textSangueTot.gameObject.SetActive(true);
        Image Riga2 = endPanel.transform.Find("Riga2").GetComponent<Image>();
        Riga2.gameObject.SetActive(true);
        Image Riga3 = endPanel.transform.Find("Riga3").GetComponent<Image>();
        Riga3.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        GameObject bottino = endPanel.transform.Find("Bottino").gameObject;
        bottino.SetActive(true);
        Image Riga4 = endPanel.transform.Find("Riga4").GetComponent<Image>();
        Riga4.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        if (health && mana)
        {
            Image Poz2 = endPanel.transform.Find("Poz2").GetComponent<Image>();
            Poz2.gameObject.SetActive(true);
            Image Poz3 = endPanel.transform.Find("Poz3").GetComponent<Image>();
            Poz3.gameObject.SetActive(true);
        }
        else if (health && !mana)
        {
            Image Poz1 = endPanel.transform.Find("Poz1").GetComponent<Image>();
            Poz1.gameObject.SetActive(true);
        }
        else if (!health && mana)
        {
            Image Poz4 = endPanel.transform.Find("Poz4").GetComponent<Image>();
            Poz4.gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(0.2f);
        GameObject scritta = endPanel.transform.Find("Premi").gameObject;
        scritta.SetActive(true);

        cc.changeReady = true;
    }
}
