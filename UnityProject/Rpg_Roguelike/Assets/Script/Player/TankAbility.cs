using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TankAbility : MonoBehaviour
{
    private Player player;
    public GameObject attackBox;
    public List<GameObject> attackBoxList = new List<GameObject>();         //Lista delle celle rosse
    public List<GameObject> enemyDisp = new List<GameObject>();             // enemy a tiro nel raggio di azione dell'abilità
    public Button abilityButton;

    public GameObject lanciaSassoSprite;
    public GameObject attaccoMeno;
    public GameObject difesaMeno;
    public GameObject attaccoFisico;
    public GameObject spaccaossi;
    public GameObject percuotere;
    public GameObject attaccoCasuale;

    public int[] costoAbilita = new int[5];
    public bool[] abilitaSbloccate = new bool[5];
    public Button[] buttonAbilita = new Button[5];

    // Audioclip
    public AudioClip difMeno;
    public AudioClip lanciaSas;
    public AudioClip attMeno;
    public AudioClip spaccaOs;
    public AudioClip audioPercuotere;

    void Start()
    {
        for (int i = 0; i < player.stats.abilitaSbloccate.Length; i++)
        {
            if (player.stats.abilitaSbloccate[i])
            {
                abilitaSbloccate[i] = player.stats.abilitaSbloccate[i];

            }
            else
            {
                abilitaSbloccate[i] = player.stats.abilitaSbloccate[i];
                buttonAbilita[i].interactable = false;
            }
        }

        CheckAvailableAbility();
    }


    void OnEnable()
    {
        CheckAvailableAbility();
    }

    void CheckAvailableAbility()
    {
        CombatController cc = FindObjectOfType<CombatController>();
        player = cc.player[cc.turno].GetComponent<Player>();

        for (int i = 0; i < 5; i++)
        {
            if (costoAbilita[i] > player.stats.mp && abilitaSbloccate[i])
            {
                buttonAbilita[i].interactable = false;
            }
            else if (costoAbilita[i] <= player.stats.mp && abilitaSbloccate[i])
            {
                buttonAbilita[i].interactable = true;
            }
        }

        foreach (Transform item in this.transform)
        {
            if (item.gameObject.GetComponent<Button>().IsInteractable())
            {
                item.gameObject.GetComponent<Button>().Select();
                break;
            }
        }
    }
    // ABILITA LANCIA SASSO             /////////////////////////////////////////
    public void CoLanciaSasso()
    {
        UiController ui = FindObjectOfType<UiController>();

        ui.tankAbilityPanel.SetActive(false);
        ui.EnemyListPanel.SetActive(true);
        List<Button> button = new List<Button>();

        foreach (GameObject enemy in enemyDisp)
        {
            Button newButton = Instantiate(abilityButton);
            

            AbilityButton enemyButton = newButton.GetComponent<AbilityButton>();
            enemyButton.enemy = enemy;
            enemyButton.enemyInfoPanel = ui.enemyInfoPanel;
            newButton.transform.SetParent(ui.EnemyListPanel.transform, false);
            newButton.onClick.AddListener(() => LanciaSasso(enemyButton.enemy));
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

        ui.EnemyListPanel.transform.GetChild(0).GetComponent<Button>().Select();
    }


    public void LanciaSasso(GameObject _enemy)
    {
        //costo e variabili
        int mp = costoAbilita[0];

        //calcola effetto
        int danni = Mathf.RoundToInt(player.stats.attMelee * Random.Range(1.0f,1.25f));
        GameObject effect = Instantiate(lanciaSassoSprite);
        effect.transform.position = _enemy.transform.position;
        Enemy enemy = _enemy.GetComponent<Enemy>();
        // Suono
        AudioSource audio = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        audio.PlayOneShot(lanciaSas);
        //scala il danno dal nemico e gli mp al player
        SpriteRenderer sr = _enemy.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        enemy.SubisciDannoRanged(danni, _enemy);
        player.stats.mp -= mp;
        // Roba UI
        UiController ui = FindObjectOfType<UiController>();
        ui.AggiornaMana(player.stats.mpMax, player.stats.mp, player.uiInfo);
        DestroyAttackBox();
        DestroyEnemyButton();
        ui.CoSvuotaPanel();
        
    }

    // ABILITA DEMOLISCI             //////////////////////////////////////////

    public void CoDemolisci()
    {

        UiController ui = FindObjectOfType<UiController>();

        ui.tankAbilityPanel.SetActive(false);
        ui.EnemyListPanel.SetActive(true);

        List<Button> button = new List<Button>();

        foreach (GameObject enemy in enemyDisp)
        {
            Button newButton = Instantiate(abilityButton);


            AbilityButton enemyButton = newButton.GetComponent<AbilityButton>();
            enemyButton.enemy = enemy;
            enemyButton.enemyInfoPanel = ui.enemyInfoPanel;
            newButton.transform.SetParent(ui.EnemyListPanel.transform, false);
            newButton.onClick.AddListener(() => Demolisci(enemyButton.enemy));
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
        ui.EnemyListPanel.transform.GetChild(0).GetComponent<Button>().Select();
    }

    public void Demolisci(GameObject _enemy)
    {
        //costo e variabili
        int mp = costoAbilita[2];
        int nturni = 2;
        int percentualeDebuff = 35;
        int danni = player.stats.attMelee;
        GameObject effect = Instantiate(difesaMeno);
        effect.transform.position = _enemy.transform.position;
        GameObject effect1 = Instantiate(attaccoFisico);
        effect1.transform.position = _enemy.transform.position;
        //calcola effetto
        Enemy enemy = _enemy.GetComponent<Enemy>();
        int debuffDifesa = Mathf.RoundToInt((enemy.difesa * percentualeDebuff) / 100);
        enemy.nturnoDifesa.Add(nturni);
        enemy.debuffDifesa.Add(debuffDifesa);
        enemy.difesa -= debuffDifesa;
        // Suono
        AudioSource audio = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        audio.PlayOneShot(difMeno);
        //scala il danno dal nemico e gli mp al player
        SpriteRenderer sr = _enemy.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        enemy.SubisciDannoMelee(danni, _enemy);
        player.stats.mp -= mp;

        // Robe per UI
        UiController ui = FindObjectOfType<UiController>();
        ui.AggiornaMana(player.stats.mpMax, player.stats.mp, player.uiInfo);
        DestroyAttackBox();
        DestroyEnemyButton();
        ui.CoSvuotaPanel();
    }

    // ABILITA DEMOLISCI             //////////////////////////////////////////

    public void CoDisarma()
    {

        UiController ui = FindObjectOfType<UiController>();

        ui.tankAbilityPanel.SetActive(false);
        ui.EnemyListPanel.SetActive(true);

        List<Button> button = new List<Button>();

        foreach (GameObject enemy in enemyDisp)
        {
            Button newButton = Instantiate(abilityButton);


            AbilityButton enemyButton = newButton.GetComponent<AbilityButton>();
            enemyButton.enemy = enemy;
            enemyButton.enemyInfoPanel = ui.enemyInfoPanel;
            newButton.transform.SetParent(ui.EnemyListPanel.transform, false);
            newButton.onClick.AddListener(() => Disarma(enemyButton.enemy));
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
        ui.EnemyListPanel.transform.GetChild(0).GetComponent<Button>().Select();
    }

    public void Disarma(GameObject _enemy)
    {
        //costo e variabili
        int mp = costoAbilita[3];
        int nturni = 2;
        int percentualeDebuff = 35;
        int danni = player.stats.attMelee;
        //calcola effetto
        GameObject effect = Instantiate(attaccoMeno);
        effect.transform.position = _enemy.transform.position;
        GameObject effect1 = Instantiate(attaccoFisico);
        effect1.transform.position = _enemy.transform.position;
        Enemy enemy = _enemy.GetComponent<Enemy>();
        int debuffAttacco = Mathf.RoundToInt((enemy.att * percentualeDebuff) / 100);
        enemy.nturnoAttacco.Add(nturni);
        enemy.debuffAttacco.Add(debuffAttacco);
        enemy.att -= debuffAttacco;
        // Suono
        AudioSource audio = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        audio.PlayOneShot(attMeno);
        //scala il danno dal nemico e gli mp al player
        SpriteRenderer sr = _enemy.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        enemy.SubisciDannoMelee(danni, _enemy);
        player.stats.mp -= mp;

        // Robe per UI
        UiController ui = FindObjectOfType<UiController>();
        ui.AggiornaMana(player.stats.mpMax, player.stats.mp, player.uiInfo);
        DestroyAttackBox();
        DestroyEnemyButton();
        ui.CoSvuotaPanel();
    }

    // ABILITA SpaccaTeschi             /////////////////////////////////////////
    public void CoSpaccaTeschi()
    {

        UiController ui = FindObjectOfType<UiController>();

        ui.tankAbilityPanel.SetActive(false);
        ui.EnemyListPanel.SetActive(true);

        List<Button> button = new List<Button>();

        foreach (GameObject enemy in enemyDisp)
        {
            Button newButton = Instantiate(abilityButton);


            AbilityButton enemyButton = newButton.GetComponent<AbilityButton>();
            enemyButton.enemy = enemy;
            enemyButton.enemyInfoPanel = ui.enemyInfoPanel;
            newButton.transform.SetParent(ui.EnemyListPanel.transform, false);
            newButton.onClick.AddListener(() => SpaccaTeschi(enemyButton.enemy));
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
        ui.EnemyListPanel.transform.GetChild(0).GetComponent<Button>().Select();
    }


    public void SpaccaTeschi(GameObject _enemy)
    {
        //costo e variabili
        int mp = costoAbilita[4];

        //calcola effetto
        int danni = player.stats.attMelee + Mathf.RoundToInt(player.stats.attMelee /2);
        GameObject effect = Instantiate(spaccaossi);
        effect.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, 0); ;
        GameObject effect1 = Instantiate(attaccoCasuale);
        effect1.transform.position = _enemy.transform.position;
        Enemy enemy = _enemy.GetComponent<Enemy>();
        //scala il danno dal nemico e gli mp al player
        SpriteRenderer sr = _enemy.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        enemy.SubisciDannoMelee(danni, _enemy);
        player.stats.mp -= mp;
        // Suono
        AudioSource audio = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        audio.PlayOneShot(spaccaOs);
        // Roba UI
        UiController ui = FindObjectOfType<UiController>();
        ui.AggiornaMana(player.stats.mpMax, player.stats.mp, player.uiInfo);
        DestroyAttackBox();
        DestroyEnemyButton();
        ui.CoSvuotaPanel();
    }

    //Percuoti //////////////////////////////////////////////////////
    public void CoPercuoti()
    {
        UiController ui = FindObjectOfType<UiController>();

        ui.tankAbilityPanel.SetActive(false);
        ui.EnemyListPanel.SetActive(true);
        List<Button> button = new List<Button>();

        foreach (GameObject enemy in enemyDisp)
        {
            Button newButton = Instantiate(abilityButton);


            AbilityButton enemyButton = newButton.GetComponent<AbilityButton>();
            enemyButton.enemy = enemy;
            enemyButton.enemyInfoPanel = ui.enemyInfoPanel;
            newButton.transform.SetParent(ui.EnemyListPanel.transform, false);
            newButton.onClick.AddListener(() => Percuoti(enemyButton.enemy));
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

        ui.EnemyListPanel.transform.GetChild(0).GetComponent<Button>().Select();
    }


    public void Percuoti(GameObject _enemy)
    {
        //costo e variabili
        int mp = costoAbilita[1];
        float random = Random.Range(0.0f, 100.0f);
        if (random >= 0)
        {
            List<int> n = new List<int>();
            CombatController cc = FindObjectOfType<CombatController>();
            int nturni = 0;
            for (int j = cc.turno + 1; j < cc.player.Count; j++)
            {
                if (cc.player[j] == _enemy)
                    n.Add(j);

                nturni++;

                if (nturni == 2)
                    break;
            }
            n.Reverse();
            foreach (var item in n)
            {
                cc.player.RemoveAt(item);
            }
            cc.UpdateTurnPortrait();
        }
        //calcola effetto
        GameObject effect1 = Instantiate(percuotere);
        effect1.transform.position = _enemy.transform.position;
        int danni = Mathf.RoundToInt(((player.stats.attMelee)) * (Random.Range(1.0f, 1.20f)));
        Enemy enemy = _enemy.GetComponent<Enemy>();
        // Suono
        AudioSource audio = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        audio.PlayOneShot(audioPercuotere);
        //scala il danno dal nemico e gli mp al player
        enemy.SubisciDannoRanged(danni, _enemy);
        player.stats.mp -= mp;
        // Roba UI
        UiController ui = FindObjectOfType<UiController>();
        ui.AggiornaMana(player.stats.mpMax, player.stats.mp, player.uiInfo);
        DestroyAttackBox();
        DestroyEnemyButton();
        ui.CoSvuotaPanel();
    }

    public void SpawnAttackBox(int raggio)
    {
        BattleGrid grid = FindObjectOfType<BattleGrid>();
        UiController ui = FindObjectOfType<UiController>();

        int _x = (int)player.pos.x;
        int _y = (int)player.pos.y;



        for (int i = (_x - raggio); i <= (_x + raggio); i++)
        {
            for (int y = (_y - raggio); y <= (_y + raggio); y++)
            {

                if (i < 0)
                    continue;
                if (y < 0)
                    continue;
                if (i > grid.width - 1)
                    continue;
                if (y > grid.height - 1)
                    continue;

                if (Mathf.Abs(i - _x) + Mathf.Abs(y - _y) <= (raggio))
                {
                    GameObject newAttack = Instantiate(attackBox);
                    newAttack.transform.position = grid.cells[i, y].gameObject.transform.position;
                    ui.attackBoxList.Add(newAttack);
                    if (grid.cells[i, y].occupier != null)
                    {
                        if (grid.cells[i, y].occupier.CompareTag("Enemy"))
                            enemyDisp.Add(grid.cells[i, y].occupier);
                    }
                }
            }
        }
    }

    public void DestroyAttackBox()
    {
        UiController ui = FindObjectOfType<UiController>();

        foreach (var item in ui.attackBoxList)
        {
            Destroy(item);
        }
        ui.attackBoxList.Clear();
        enemyDisp.Clear();
    }

    void DestroyEnemyButton()
    {
        UiController ui = FindObjectOfType<UiController>();
        ui.CoAttivaPanel();

        foreach (Transform item in ui.EnemyListPanel.transform)
        {
            Destroy(item.gameObject);
        }
    }
}
