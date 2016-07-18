using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyInfoPanel;
    public GameObject attackBox;

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
