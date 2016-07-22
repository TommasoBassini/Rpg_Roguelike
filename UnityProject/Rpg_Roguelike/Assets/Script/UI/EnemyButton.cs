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
        Enemy _enemy = enemy.GetComponent<Enemy>();
        float hp = (float) _enemy.hp;
        float hpMax = (float)_enemy.hpMax;
        enemyInfoPanel.SetActive(true);
        //Testo vita
        Text textVita = enemyInfoPanel.transform.Find("HealthText").GetComponent<Text>();
        textVita.text = _enemy.hp + "/" + _enemy.hpMax;
        Text textNome = enemyInfoPanel.transform.Find("NomeNemico").GetComponent<Text>();
        textNome.text = enemy.name;
        Image vita = enemyInfoPanel.transform.Find("Health").GetComponent<Image>();
        vita.fillAmount = ((100 * hp) / hpMax) / 100;

        Image icona = enemyInfoPanel.transform.Find("Image").GetComponent<Image>();
        icona.sprite = _enemy.icona;
        //Check Debuff difesa
        if (_enemy.nturnoDifesa.Count > 0)
        {
            enemyInfoPanel.transform.Find("Dif").gameObject.SetActive(true);
        }
        else
            enemyInfoPanel.transform.Find("Dif").gameObject.SetActive(false);

        //Check Debuff attacco
        if (_enemy.nturnoAttacco.Count > 0)
        {
            enemyInfoPanel.transform.Find("Att").gameObject.SetActive(true);
        }
        else
            enemyInfoPanel.transform.Find("Att").gameObject.SetActive(false);

        //Check veleno
        if (_enemy.turniVeleno > 0)
        {
            enemyInfoPanel.transform.Find("Poison").gameObject.SetActive(true);
        }
        else
            enemyInfoPanel.transform.Find("Poison").gameObject.SetActive(false);

     /*   //Check Stunn
        if (_enemy.turniVeleno > 0)
        {
            enemyInfoPanel.transform.Find("Poison").gameObject.SetActive(true);
        }
        else
            enemyInfoPanel.transform.Find("Poison").gameObject.SetActive(false);*/
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
