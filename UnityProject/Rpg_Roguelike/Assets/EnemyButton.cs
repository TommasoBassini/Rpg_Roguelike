using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyButton : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyInfoPanel;

    public void IlluminaPlayer()
    {
        SpriteRenderer sr = enemy.GetComponent<SpriteRenderer>();
        sr.color = Color.red;

        enemyInfoPanel.SetActive(true);
        //Testo vita
        Text textVita = enemyInfoPanel.transform.Find("Vita").GetComponent<Text>();
        textVita.text = "Hp : " + enemy.GetComponent<Enemy>().hp;
        //Testo mp
        Text textMana = enemyInfoPanel.transform.Find("Mana").GetComponent<Text>();
        textMana.text = "Mp : " + enemy.GetComponent<Enemy>().mp;
        //Testo Attacco
        Text textAttacco = enemyInfoPanel.transform.Find("Attacco").GetComponent<Text>();
        textAttacco.text = "Attacco : " + enemy.GetComponent<Enemy>().att;
        //Testo Difesa
        Text textDifesa = enemyInfoPanel.transform.Find("Difesa").GetComponent<Text>();
        textDifesa.text = "Difesa : " + enemy.GetComponent<Enemy>().difesa;
    }

    public void DeIlluminaPlayer()
    {
        enemyInfoPanel.SetActive(false);
        SpriteRenderer sr = enemy.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
    }

    public void AttackEnemy()
    {
        CombatController cc = FindObjectOfType<CombatController>();
        Player player = cc.player[cc.turno].GetComponent<Player>();
        SpriteRenderer sr = enemy.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        UiController ui = FindObjectOfType<UiController>();
        ui.EnemyListPanel.SetActive(false);
        ui.MainPanel.SetActive(true);
        enemyInfoPanel.SetActive(false);
        Button actionButton = ui.MainPanel.transform.Find("Action").GetComponent<Button>();
        actionButton.interactable = false;
        player.Attack(enemy);

    }
}
