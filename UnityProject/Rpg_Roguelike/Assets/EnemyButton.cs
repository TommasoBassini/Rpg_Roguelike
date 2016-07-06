using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyButton : MonoBehaviour
{
    public GameObject enemy;


    public void IlluminaPlayer()
    {
        SpriteRenderer sr = enemy.GetComponent<SpriteRenderer>();
        sr.color = Color.red;
    }

    public void DeIlluminaPlayer()
    {
        SpriteRenderer sr = enemy.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
    }

    public void AttackEnemy()
    {
        CombatController cc = FindObjectOfType<CombatController>();
        Player player = cc.player[cc.turno].GetComponent<Player>();
        player.Attack(enemy);

        SpriteRenderer sr = enemy.GetComponent<SpriteRenderer>();
        sr.color = Color.white;

    }
}
