using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyButton : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyInfoPanel;

    private float time = 0.5f;

    public GameObject targetSprite;

    private GameObject newTarget;

    public void IlluminaPlayer()
    {
        newTarget = Instantiate(targetSprite);
        newTarget.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 1, enemy.transform.position.z);

        Enemy _enemy = enemy.GetComponent<Enemy>();

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
        enemyInfoPanel.SetActive(true);
        Invoke("UpdateImage", 0.1f);

        /*   //Check Stunn
           if (_enemy.turniVeleno > 0)
           {
               enemyInfoPanel.transform.Find("Poison").gameObject.SetActive(true);
           }
           else
               enemyInfoPanel.transform.Find("Poison").gameObject.SetActive(false);*/
    }


    void UpdateImage()
    {
        Enemy _enemy = enemy.GetComponent<Enemy>();
        float hp = (float)_enemy.hp;
        float hpMax = (float)_enemy.hpMax;

        //Testo vita
        Text textVita = enemyInfoPanel.transform.Find("HealthText").GetComponent<Text>();
        textVita.text = _enemy.hp + "/" + _enemy.hpMax;
        Text textNome = enemyInfoPanel.transform.Find("NomeNemico").GetComponent<Text>();
        textNome.text = enemy.name;

        Image vita = enemyInfoPanel.transform.Find("Health").GetComponent<Image>();
        vita.color = new Color(vita.color.r, vita.color.g, vita.color.b, 1);
        Image BaseHealth = enemyInfoPanel.transform.Find("BaseHealth").GetComponent<Image>();
        BaseHealth.color = new Color(BaseHealth.color.r, BaseHealth.color.g, BaseHealth.color.b, 1);

        vita.fillAmount = ((100 * hp) / hpMax) / 100;

        Image icona = enemyInfoPanel.transform.Find("Image").GetComponent<Image>();
        icona.sprite = _enemy.icona;
    }

    public void DeIlluminaPlayer()
    {
        enemyInfoPanel.SetActive(false);
        Destroy(newTarget);
    }

    public void AttackEnemy()
    {
        CombatController cc = FindObjectOfType<CombatController>();
        Player player = cc.player[cc.turno].GetComponent<Player>();
        Destroy(newTarget);

        player.Attack(enemy);

        StartCoroutine(attivaPanel());
    }

    IEnumerator attivaPanel()
    {
        UiController ui = FindObjectOfType<UiController>();
        ui.faseUi = 2;
        Button actionButton = ui.MainPanel.transform.Find("Action").GetComponent<Button>();
        actionButton.interactable = false;
        yield return new WaitForSeconds(time);

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
        ui.MainPanel.SetActive(true);
        enemyInfoPanel.SetActive(false);
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
