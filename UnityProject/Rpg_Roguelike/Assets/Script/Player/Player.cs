using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Statistiche
{
    //Statistiche
    public int hpMax;
    public int hp;
    public int mpMax;
    public int mp;

    public int attMelee;
    public int attMagico;
    public int attDistanza;

    public int difFisica;
    public int difMagica;

    public int evasione;
    public int precisione;
    public int velocita;
}

public abstract class Player : Character
{
    public Statistiche stats;
    public abstract void TakeStats();
    public abstract void SubisciDanno(int danni);
    public List<GameObject> enemyDisp = new List<GameObject>();
    public GameObject uiInfo;

 

    public void CheckAttack()
    {
        //classico controllo delle direzioni
        Vector2[] directions = new Vector2[4];

        directions[0] = new Vector2(-1, 0);
        directions[1] = new Vector2(0, -1);
        directions[2] = new Vector2(1, 0);
        directions[3] = new Vector2(0, 1);

        foreach (Vector2 dir in directions)
        {
            int new_x = (int)pos.x + (int)dir.x;
            int new_y = (int)pos.y + (int)dir.y;

            if (new_x < 0)
                continue;
            if (new_y < 0)
                continue;
            if (new_x > base.grid.width - 1)
                continue;
            if (new_y > base.grid.height - 1)
                continue;
            //se non esce dalla griglia e non è occupata aggiungo la posizione alla lista posDisp
            if (base.grid.cells[new_x, new_y].occupier != null)
            {
                if (base.grid.cells[new_x, new_y].occupier.CompareTag("Enemy"))
                    enemyDisp.Add(base.grid.cells[new_x, new_y].occupier);
            }
        }
    }

    public void Attack(GameObject enemy)
    {
        Debug.Log("il player " + this.gameObject.name + " ha attaccato " + enemy.name);
        UiController ui = FindObjectOfType<UiController>();
        ui.PassaTurno();
    }

}
