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

    public bool[] abilitaSbloccate = new bool[5];
}

public abstract class Player : Character
{
    public Statistiche stats;
    public abstract void TakeStats();
    public abstract void SubisciDanno(float danni);
    public abstract void SpawnAttackBox();
    public abstract void CheckAttack();
    public List<GameObject> enemyDisp = new List<GameObject>();
    public GameObject uiInfo;
    public GameObject checkAttack;
    public List<GameObject> checkboxAttack = new List<GameObject>();

    // liste buff/debuff
    public List<int> nturnoBuffAttacco = new List<int>();
    public List<int> buffAttaccoMelee = new List<int>();
    public List<int> buffAttaccoRanged = new List<int>();
    public List<int> buffAttaccoMagico = new List<int>();

    public void Attack(GameObject _enemy)
    {
        Invoke("DestroyButton", 0.6f);
        Enemy enemy = _enemy.GetComponent<Enemy>();
        Debug.Log("il player " + this.gameObject.name + " ha attaccato " + enemy.name);
        enemy.SubisciDannoMelee(stats.attMelee,_enemy);

        foreach (GameObject cell in checkboxAttack)
        {
            Destroy(cell);
        }
        checkboxAttack.Clear();
    }

    void DestroyButton()
    {
        foreach (Transform child in FindObjectOfType<UiController>().EnemyListPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void StartTurn()
    {
        if (nturnoBuffAttacco.Count != 0)
        {
            CheckBuffAttacco();
        }
    }

    void CheckBuffAttacco()
    {
        for (int i = nturnoBuffAttacco.Count - 1; i >= 0; i--)
        {
            nturnoBuffAttacco[i]--;
            if (nturnoBuffAttacco[i] == 0)
            {
                stats.attMelee -= buffAttaccoMelee[i];
                stats.attMagico -= buffAttaccoMagico[i];
                stats.attDistanza -= buffAttaccoRanged[i];

                buffAttaccoMelee.RemoveAt(i);
                buffAttaccoMagico.RemoveAt(i);
                buffAttaccoRanged.RemoveAt(i);

                nturnoBuffAttacco.RemoveAt(i);
            }
        }
    }

}
