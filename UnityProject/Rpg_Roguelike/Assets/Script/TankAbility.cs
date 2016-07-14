using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TankAbility : MonoBehaviour
{
    private Player player;
    public Button buttonPrefab;
    public GameObject attackBox;
    public List<GameObject> attackBoxList = new List<GameObject>();

    void Start()
    {
        
        Button newbutton = Instantiate(buttonPrefab);
        newbutton.transform.SetParent(this.gameObject.transform);
        newbutton.onClick.AddListener(()=> Prova());
    }


    public void Prova()
    {
        Debug.Log("OKOJ");
    }

    public void CoLanciaSasso()
    {

    }


    public void LanciaSasso()
    {
        int mp = 5;
        int danni = player.stats.attDistanza;
        player.stats.mp -= mp;
        UiController ui = FindObjectOfType<UiController>();
        ui.AggiornaMana(player.stats.mpMax, mp, player.uiInfo);
    }

    public void SpawnAttackBox(int raggio)
    {
        CombatController cc = FindObjectOfType<CombatController>();
        player = cc.player[cc.turno].GetComponent<Player>();
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
