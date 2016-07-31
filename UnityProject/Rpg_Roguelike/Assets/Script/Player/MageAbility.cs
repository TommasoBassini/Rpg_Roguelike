using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MageAbility : MonoBehaviour
{
    private Player player;
    public GameObject attackBox;
    public GameObject allyBox;
    public List<GameObject> enemyDisp = new List<GameObject>();             // enemy a tiro nel raggio di azione dell'abilità

    public List<GameObject> buffBoxList = new List<GameObject>();          // Lista delle celle verdi
    public List<GameObject> allyDisp = new List<GameObject>();             // player a tiro nel raggio di azione dell'abilità

    public Button abilityButton;

    public int[] costoAbilita = new int[5];
    public bool[] abilitaSbloccate = new bool[5];
    public Button[] buttonAbilita = new Button[5];

    public GameObject protezione;
    public GameObject cura;
    public GameObject assorbiAnimaEnemy;
    public GameObject assorbiAnimaPlayer;
    public GameObject ragnatela;
    public GameObject fulmine;

    public AudioClip audioProtezione;
    public AudioClip audioCura;
    public AudioClip audioAssorbiAnima;
    public AudioClip audioRagnatela;
    public AudioClip audioFulmine;

    public List<Button> buttons = new List<Button>();

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
                buttons.Add(buttonAbilita[i]);
            }
        }

        buttons[0].Select();
    }

    //Fulmine nero //////////////////////////////////////////////////////
    public void CoFulmine()
    {
        UiController ui = FindObjectOfType<UiController>();

        ui.mageAbilityPanel.SetActive(false);
        ui.EnemyListPanel.SetActive(true);
        List<Button> button = new List<Button>();

        foreach (GameObject enemy in enemyDisp)
        {
            Button newButton = Instantiate(abilityButton);


            AbilityButton enemyButton = newButton.GetComponent<AbilityButton>();
            enemyButton.enemy = enemy;
            enemyButton.enemyInfoPanel = ui.enemyInfoPanel;
            newButton.transform.SetParent(ui.EnemyListPanel.transform, false);
            newButton.onClick.AddListener(() => Fulmine(enemyButton.enemy));
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


    public void Fulmine(GameObject _enemy)
    {
        //costo e variabili
        int mp = costoAbilita[4];

        GameObject effect = Instantiate(fulmine);
        effect.transform.position = _enemy.transform.position;

        // Suono
        AudioSource audio = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        audio.PlayOneShot(audioFulmine);

        //calcola effetto
        int danni = Mathf.RoundToInt  (((player.stats.attMagico) * 1.5f) * (Random.Range(1.0f,1.25f)));
        Enemy enemy = _enemy.GetComponent<Enemy>();
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

    //Attacco ragnatela //////////////////////////////////////////////////////
    public void CoRagnatela()
    {
        UiController ui = FindObjectOfType<UiController>();

        ui.mageAbilityPanel.SetActive(false);
        ui.EnemyListPanel.SetActive(true);
        List<Button> button = new List<Button>();

        foreach (GameObject enemy in enemyDisp)
        {
            Button newButton = Instantiate(abilityButton);


            AbilityButton enemyButton = newButton.GetComponent<AbilityButton>();
            enemyButton.enemy = enemy;
            enemyButton.enemyInfoPanel = ui.enemyInfoPanel;
            newButton.transform.SetParent(ui.EnemyListPanel.transform, false);
            newButton.onClick.AddListener(() => Ragnatela(enemyButton.enemy));
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


    public void Ragnatela(GameObject _enemy)
    {
        //costo e variabili
        int mp = costoAbilita[3];
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

        GameObject effect = Instantiate(ragnatela);
        effect.transform.position = _enemy.transform.position;
        // Suono
        AudioSource audio = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        audio.PlayOneShot(audioRagnatela);

        //calcola effetto
        int danni = Mathf.RoundToInt(((1) * 1.5f) * (Random.Range(1.0f, 1.25f)));
        Enemy enemy = _enemy.GetComponent<Enemy>();
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

    // ABILITA Protezione             ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void CoProtezione()
    {

        UiController ui = FindObjectOfType<UiController>();

        ui.mageAbilityPanel.SetActive(false);
        ui.EnemyListPanel.SetActive(true);

        List<Button> button = new List<Button>();

        foreach (GameObject ally in allyDisp)
        {
            Button newButton = Instantiate(abilityButton);

            AbilityButton enemyButton = newButton.GetComponent<AbilityButton>();
            enemyButton.enemy = ally;
            enemyButton.enemyInfoPanel = ui.enemyInfoPanel;
            newButton.transform.SetParent(ui.EnemyListPanel.transform, false);
            newButton.onClick.AddListener(() => Protezione(enemyButton.enemy));
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


    public void Protezione(GameObject _player)
    {
        //costo e variabili
        int mp = costoAbilita[1];
        int nTurniBuff = 2;
        Player playerTarget = _player.GetComponent<Player>();

        GameObject effect = Instantiate(protezione);
        effect.transform.position = new Vector3 (_player.transform.position.x, _player.transform.position.y + 0.5f, _player.transform.position.z);
        // Suono
        AudioSource audio = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        audio.PlayOneShot(audioProtezione);

        //calcola effetto
        playerTarget.nTurnoProtezione += nTurniBuff;
        //scala il danno dal nemico e gli mp al player
        SpriteRenderer sr = _player.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        this.player.stats.mp -= mp;
        // Roba UI
        UiController ui = FindObjectOfType<UiController>();
        ui.AggiornaMana(this.player.stats.mpMax, this.player.stats.mp, this.player.uiInfo);
        DestroyBuffBox();
        DestroyEnemyButton();
        ui.CoSvuotaPanel();
    }

    // CURAAAAAAAAAAAAAAAAAAAAAA /////////////////////////////////////////////////////
    public void CoCura()
    {

        UiController ui = FindObjectOfType<UiController>();

        ui.mageAbilityPanel.SetActive(false);
        ui.EnemyListPanel.SetActive(true);

        List<Button> button = new List<Button>();

        foreach (GameObject ally in allyDisp)
        {
            Button newButton = Instantiate(abilityButton);

            AbilityButton enemyButton = newButton.GetComponent<AbilityButton>();
            enemyButton.enemy = ally;
            enemyButton.enemyInfoPanel = ui.enemyInfoPanel;
            newButton.transform.SetParent(ui.EnemyListPanel.transform, false);
            newButton.onClick.AddListener(() => Cura(enemyButton.enemy));
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


    public void Cura(GameObject _player)
    {
        //costo e variabili
        int mp = costoAbilita[0];
        Player playerTarget = _player.GetComponent<Player>();
        GameObject effect = Instantiate(ragnatela);
        effect.transform.position = _player.transform.position;
        // Suono
        AudioSource audio = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        audio.PlayOneShot(audioCura);
        //calcola effetto
        int cura = Mathf.RoundToInt(this.player.stats.attMagico * (Random.Range(1f, 1.25f)));
        if(playerTarget.stats.hp + cura > playerTarget.stats.hpMax)
        {
            playerTarget.stats.hp = playerTarget.stats.hpMax;
        }
        else
            playerTarget.stats.hp += cura;
        //scala il danno dal nemico e gli mp al player
        SpriteRenderer sr = _player.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        this.player.stats.mp -= mp;
        // Roba UI
        UiController ui = FindObjectOfType<UiController>();
        ui.AggiornaVita(playerTarget.stats.hpMax, playerTarget.stats.hp, playerTarget.uiInfo);
        ui.DamageText(playerTarget.gameObject, cura, Color.green);
        ui.AggiornaMana(this.player.stats.mpMax, this.player.stats.mp, this.player.uiInfo);
        DestroyBuffBox();
        DestroyEnemyButton();
        ui.CoSvuotaPanel();
    }

    // Assorbi anima             ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void CoAssorbiAnima()
    {
        UiController ui = FindObjectOfType<UiController>();

        ui.mageAbilityPanel.SetActive(false);
        ui.EnemyListPanel.SetActive(true);
        List<Button> button = new List<Button>();

        foreach (GameObject enemy in enemyDisp)
        {
            Button newButton = Instantiate(abilityButton);


            AbilityButton enemyButton = newButton.GetComponent<AbilityButton>();
            enemyButton.enemy = enemy;
            enemyButton.enemyInfoPanel = ui.enemyInfoPanel;
            newButton.transform.SetParent(ui.EnemyListPanel.transform, false);
            newButton.onClick.AddListener(() => AssorbiAnima(enemyButton.enemy));
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


    public void AssorbiAnima(GameObject _enemy)
    {
        //calcola effetto
        int danni = player.stats.attDistanza;

        Enemy enemy = _enemy.GetComponent<Enemy>();
        GameObject effect = Instantiate(assorbiAnimaEnemy);
        effect.transform.position = new Vector3 (_enemy.transform.position.x, _enemy.transform.position.y + 0.5f, _enemy.transform.position.z);
        GameObject effect1 = Instantiate(assorbiAnimaPlayer);
        effect1.transform.position = player.transform.position;
        // Suono
        AudioSource audio = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        audio.PlayOneShot(audioAssorbiAnima);
        //scala il danno dal nemico e gli mp al player
        SpriteRenderer sr = _enemy.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        int danniEffettivi = enemy.SubisciDannoRangedAndReturn(danni, _enemy);
        if (player.stats.mp + danniEffettivi > player.stats.mpMax)
        {
            player.stats.mp = player.stats.mpMax;
        }
        else
            player.stats.mp += danniEffettivi;
        // Roba UI
        UiController ui = FindObjectOfType<UiController>();
        ui.DamageText(player.gameObject, danniEffettivi, Color.blue);
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

    public void SpawnBuffBox(int raggio)
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
                    GameObject newAttack = Instantiate(allyBox);
                    newAttack.transform.position = grid.cells[i, y].gameObject.transform.position;
                    ui.buffBoxList.Add(newAttack);
                    if (grid.cells[i, y].occupier != null)
                    {
                        if (grid.cells[i, y].occupier.CompareTag("Player"))
                            allyDisp.Add(grid.cells[i, y].occupier);
                    }
                }
            }
        }
    }

    public void DestroyBuffBox()
    {
        UiController ui = FindObjectOfType<UiController>();

        foreach (var item in ui.buffBoxList)
        {
            Destroy(item);
        }
        ui.buffBoxList.Clear();
        allyDisp.Clear();
    }
}
