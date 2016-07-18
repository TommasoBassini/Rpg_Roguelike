using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DpsAbility : MonoBehaviour
{
    private Player player;
    public GameObject attackBox;
    public List<GameObject> attackBoxList = new List<GameObject>();         //Lista delle celle rosse
    public List<GameObject> enemyDisp = new List<GameObject>();             // enemy a tiro nel raggio di azione dell'abilità
    public Button abilityButton;
    public Button attacchiAriaButton;
    public int[] costoAbilita = new int[5];
    public bool[] abilitaSbloccate = new bool[5];
    public Button[] buttonAbilita = new Button[5];

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
    // ABILITA ESORTAZIONE    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void Esortazione()
    {
        //costo e variabili
        int mp = 10;
        int nturni = 3;
        int percentualeDebuff = 25;


        //Cerca gli alleati
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(players.Length);

        foreach (var item in players)
        {
            if (item != null)
            {
                Player pl = item.GetComponent<Player>();
                int buffMelee = (pl.stats.attMelee * percentualeDebuff) / 100;
                int buffMagico = (pl.stats.attMagico * percentualeDebuff) / 100;
                int buffRanged = (pl.stats.attDistanza * percentualeDebuff) / 100;

                pl.nturnoBuffAttacco.Add(nturni);

                pl.buffAttaccoMelee.Add(buffMelee);
                pl.buffAttaccoMagico.Add(buffMagico);
                pl.buffAttaccoRanged.Add(buffRanged);

                pl.stats.attMelee += buffMelee;
                pl.stats.attDistanza += buffRanged;
                pl.stats.attMagico += buffMagico;
            }
        }

        // Roba UI
        UiController ui = FindObjectOfType<UiController>();
        ui.dpsAbilityPanel.SetActive(false);
        ui.AggiornaMana((float)player.stats.mpMax, (float)player.stats.mp, player.uiInfo);
        ui.CoAttivaPanel();
        player.stats.mp -= mp;
    }

    // ABILITA FRECCE GEMELLE             ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void CoFrecceGemelle()
    {

        UiController ui = FindObjectOfType<UiController>();

        ui.dpsAbilityPanel.SetActive(false);
        ui.EnemyListPanel.SetActive(true);

        List<Button> button = new List<Button>();

        foreach (GameObject enemy in enemyDisp)
        {
            Button newButton = Instantiate(abilityButton);


            AbilityButton enemyButton = newButton.GetComponent<AbilityButton>();
            enemyButton.enemy = enemy;
            enemyButton.enemyInfoPanel = ui.enemyInfoPanel;
            newButton.transform.SetParent(ui.EnemyListPanel.transform, false);
            newButton.onClick.AddListener(() => FrecceGemelle(enemyButton.enemy));
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


    public void FrecceGemelle(GameObject _enemy)
    {
        //costo e variabili
        int mp = 20;

        //calcola effetto
        int danni = player.stats.attDistanza + Mathf.RoundToInt(player.stats.attDistanza / 2);

        Enemy enemy = _enemy.GetComponent<Enemy>();
        //scala il danno dal nemico e gli mp al player
        SpriteRenderer sr = _enemy.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        enemy.SubisciDannoMelee(danni, _enemy);
        player.stats.mp -= mp;
        // Roba UI
        UiController ui = FindObjectOfType<UiController>();
        ui.AggiornaMana(player.stats.mpMax, player.stats.mp, player.uiInfo);
        DestroyAttackBox();
        DestroyEnemyButton();
    }

    // Freccia Avvelenata             ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void CoVeleno()
    {

        UiController ui = FindObjectOfType<UiController>();

        ui.dpsAbilityPanel.SetActive(false);
        ui.EnemyListPanel.SetActive(true);

        List<Button> button = new List<Button>();

        foreach (GameObject enemy in enemyDisp)
        {
            Button newButton = Instantiate(abilityButton);


            AbilityButton enemyButton = newButton.GetComponent<AbilityButton>();
            enemyButton.enemy = enemy;
            enemyButton.enemyInfoPanel = ui.enemyInfoPanel;
            newButton.transform.SetParent(ui.EnemyListPanel.transform, false);
            newButton.onClick.AddListener(() => Veleno(enemyButton.enemy));
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

    public void Veleno(GameObject _enemy)
    {
        //costo e variabili
        int mp = 15;
        int nturni = 3;
        int percentualeVeleno = 5;
        int danni = player.stats.attDistanza;
        //calcola effetto
        Enemy enemy = _enemy.GetComponent<Enemy>();
        enemy.turniVeleno += nturni;
        enemy.percVeleno = percentualeVeleno;
        //scala il danno dal nemico e gli mp al player
        SpriteRenderer sr = _enemy.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        enemy.SubisciDannoRanged(danni, _enemy);
        player.stats.mp -= mp;

        // Robe per UI
        UiController ui = FindObjectOfType<UiController>();
        ui.AggiornaMana(player.stats.mpMax, player.stats.mp, player.uiInfo);
        DestroyAttackBox();
        DestroyEnemyButton();
    }

    // ABILITA SpaccaTeschi             ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void CoPioggiaDiFrecce()
    {

        UiController ui = FindObjectOfType<UiController>();

        ui.dpsAbilityPanel.SetActive(false);
        ui.EnemyListPanel.SetActive(true);

        List<Button> button = new List<Button>();

        foreach (GameObject enemy in enemyDisp)
        {
            Button newButton = Instantiate(attacchiAriaButton);


            AbilityButton enemyButton = newButton.GetComponent<AbilityButton>();
            enemyButton.enemy = enemy;
            enemyButton.enemyInfoPanel = ui.enemyInfoPanel;
            newButton.transform.SetParent(ui.EnemyListPanel.transform, false);
            newButton.onClick.AddListener(() => PioggiaDiFrecce(enemyButton.enemy));
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
        DestroyAttackBox();
        ui.EnemyListPanel.transform.GetChild(0).GetComponent<Button>().Select();
    }


    public void PioggiaDiFrecce(GameObject _enemy)
    {
        BattleGrid grid = FindObjectOfType<BattleGrid>();
        UiController ui = FindObjectOfType<UiController>();

        //costo e variabili
        int mp = 30;
        int danni = Mathf.RoundToInt(((player.stats.attDistanza) * 63) / 100);
        List <GameObject> targets = new List<GameObject>();
        // cerca i target
        
        Enemy ene = _enemy.GetComponent<Enemy>();
        int _x = (int)ene.pos.x;
        int _y = (int)ene.pos.y;



        for (int i = (_x - 3); i <= (_x + 3); i++)
        {
            for (int y = (_y - 3); y <= (_y + 3); y++)
            {

                if (i < 0)
                    continue;
                if (y < 0)
                    continue;
                if (i > grid.width - 1)
                    continue;
                if (y > grid.height - 1)
                    continue;

                if (Mathf.Abs(i - _x) + Mathf.Abs(y - _y) <= (3))
                {
                    if (grid.cells[i, y].occupier != null)
                    {
                        targets.Add(grid.cells[i, y].occupier);
                    }
                }
            }
        }

        foreach (GameObject item in targets)
        {
            if(item.GetComponent<Enemy>() != null)
            {
                Enemy enemy1 = item.GetComponent<Enemy>();
                enemy1.SubisciDannoRanged(danni, item);
            }
            else
            {
                Player player1 = item.GetComponent<Player>();
                player1.SubisciDanno(danni);
            }
        }

        Enemy enemy = _enemy.GetComponent<Enemy>();
        //scala il danno dal nemico e gli mp al player
        SpriteRenderer sr = _enemy.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        player.stats.mp -= mp;
        // Roba UI
        ui.AggiornaMana(player.stats.mpMax, player.stats.mp, player.uiInfo);
        DestroyAttackBox();
        DestroyEnemyButton();
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
