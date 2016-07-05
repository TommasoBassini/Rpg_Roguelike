using UnityEngine;
using System.Collections;

public class EnemyMelee : Enemy
{

    public bool isPlayerNear = false;

    public override void Ai()
    {
        CheckPlayerNear();
    }
    

    void CheckPlayerNear()
    {
        base.grid.EnemyCheckPlayer(pos,passi);
    }
}
