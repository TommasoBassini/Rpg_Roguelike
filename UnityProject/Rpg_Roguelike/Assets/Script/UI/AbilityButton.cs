using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyInfoPanel;
    public GameObject attackBox;
    public GameObject targetSprite;
    public GameObject allyTarget;

    private GameObject newAllyTarget;
    private GameObject newTarget;

    public void IlluminaPlayer()
    {
        if (enemy.CompareTag("Enemy"))
        {
            newTarget = Instantiate(targetSprite);
            newTarget.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 1, enemy.transform.position.z);
            Enemy _enemy = enemy.GetComponent<Enemy>();
            float hp = (float)_enemy.hp;
            float hpMax = (float)_enemy.hpMax;
            enemyInfoPanel.SetActive(true);
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
        else if (enemy.CompareTag("Player"))
        {
            newAllyTarget = Instantiate(allyTarget);
            newAllyTarget.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 1, enemy.transform.position.z);

            enemyInfoPanel.SetActive(true);
            Player _player = enemy.GetComponent<Player>();
            float hp = (float)_player.stats.hp;
            float hpMax = (float)_player.stats.hpMax;
            enemyInfoPanel.SetActive(true);
            //Testo vita
            Text textVita = enemyInfoPanel.transform.Find("HealthText").GetComponent<Text>();
            textVita.text = _player.stats.hp + "/" + _player.stats.hpMax;
            Text textNome = enemyInfoPanel.transform.Find("NomeNemico").GetComponent<Text>();
            textNome.text = enemy.name;

            Image vita = enemyInfoPanel.transform.Find("Health").GetComponent<Image>();
            vita.color = new Color(vita.color.r, vita.color.g, vita.color.b, 1);
            Image BaseHealth = enemyInfoPanel.transform.Find("BaseHealth").GetComponent<Image>();
            BaseHealth.color = new Color(BaseHealth.color.r, BaseHealth.color.g, BaseHealth.color.b, 1);
            vita.fillAmount = ((100 * hp) / hpMax) / 100;

            Image icona = enemyInfoPanel.transform.Find("Image").GetComponent<Image>();
            icona.sprite = _player.image;
        }
    }

    public void DeIlluminaPlayer()
    {
        Destroy(newTarget);
        Destroy(newAllyTarget);
    }

    public void SpawnAttackBox(int raggio)
    {
        BattleGrid grid = FindObjectOfType<BattleGrid>();
        UiController ui = FindObjectOfType<UiController>();

        Enemy ene = enemy.GetComponent<Enemy>();

        int _x = (int)ene.pos.x;
        int _y = (int)ene.pos.y;



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
    }

}
