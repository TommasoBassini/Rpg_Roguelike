using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyButton : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyInfoPanel;

    private float time = 0.5f;

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

        player.Attack(enemy);

        StartCoroutine(attivaPanel());
    }

    IEnumerator attivaPanel()
    {
        yield return new WaitForSeconds(time);
        UiController ui = FindObjectOfType<UiController>();

        ui.EnemyListPanel.SetActive(false);
        ui.MainPanel.SetActive(true);
        enemyInfoPanel.SetActive(false);
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
