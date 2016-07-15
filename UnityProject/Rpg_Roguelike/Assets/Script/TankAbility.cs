﻿using UnityEngine;
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

    public int[] costoAbilita = new int[5];
    public bool[] abilitaSbloccate = new bool[5];
    public Button[] buttonAbilita = new Button[5];

    void Start()
    {
        CombatController cc = FindObjectOfType<CombatController>();
        player = cc.player[cc.turno].GetComponent<Player>();

        int nAbilitaSbloccate = 0;

        List<Button> buttonInstance = new List<Button>();

        for (int i = 0; i < player.stats.abilitaSbloccate.Length; i++)
        {
            if (player.stats.abilitaSbloccate[i])
            {
                Button newButton = Instantiate(buttonAbilita[i]);
                newButton.transform.SetParent(this.gameObject.transform);
                buttonInstance.Add(newButton);
                nAbilitaSbloccate++;
            }
        }

        switch (nAbilitaSbloccate)
        {
            case 1:
                {

                    break;
                }
            default:
                break;
        }
    }

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
        int mp = 5;
        int danni = player.stats.attDistanza;
        GameObject effect = Instantiate(lanciaSassoSprite);
        effect.transform.position = _enemy.transform.position;
        Enemy enemy = _enemy.GetComponent<Enemy>();
        SpriteRenderer sr = _enemy.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        enemy.SubisciDannoRanged(danni, _enemy);
        player.stats.mp -= mp;
        UiController ui = FindObjectOfType<UiController>();
        ui.AggiornaMana(player.stats.mpMax, player.stats.mp, player.uiInfo);
        DestroyAttackBox();
        ui.EnemyListPanel.SetActive(false);

        ui.MainPanel.SetActive(true);

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
        DestoryEnemyButton();
    }

    public void SpawnAttackBox(int raggio)
    {
        
        CombatController cc = FindObjectOfType<CombatController>();
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

    void DestoryEnemyButton()
    {
        UiController ui = FindObjectOfType<UiController>();

        foreach (Transform item in ui.EnemyListPanel.transform)
        {
            Destroy(item.gameObject);
        }
    }
}