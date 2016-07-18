using UnityEngine;
using System.Collections;

public class EnemyMelee : Enemy
{

    public bool isPlayerNear = false;
    private Vector2 endPos;

    public override void Ai()
    {
        Invoke("CheckPlayerNear", 0.5f);
    }
    

    void CheckPlayerNear()
    {
        base.grid.EnemyCheckPlayer(this.pos,this.passi,this.gameObject);
    }


}
