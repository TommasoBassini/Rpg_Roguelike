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
        Vector2 targetPos;
        if (grid.EnemyCheckPlayer(this.pos, this.passi, this.gameObject, out targetPos))
        {
            if (grid.isEnemyNearPlayer(targetPos, this.gameObject))
            {
                StartCoroutine(AttackPlayer(grid.cells[(int)targetPos.x, (int)targetPos.y].occupier));
            }
            else
                StartCoroutine(GoToCellNearPlayer(this.pos, targetPos));
        }
        else
        {
            FindNearestPlayer();
        }
    }


}
