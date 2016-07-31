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

    public override IEnumerator Attack(GameObject Target)
    {
        CombatController cc = FindObjectOfType<CombatController>();
        Animator anim = GetComponent<Animator>();

        if (Target.transform.position.x > this.transform.position.x)
        {
            anim.SetTrigger("AttackRight");
        }
        else
        {
            anim.SetTrigger("AttackLeft");
        }
        yield return new WaitForSeconds(0.5f);
        if (attackEffect != null)
        {
            GameObject effect = Instantiate(attackEffect);
            effect.transform.position = Target.transform.position;
        }
        // Suono
        if (audioAttack != null)
        {
            AudioSource audio = GameObject.Find("SoundManager").GetComponent<AudioSource>();
            audio.PlayOneShot(audioAttack);
        }

        Player player = Target.GetComponent<Player>();
        player.SubisciDanno(att);
        yield return new WaitForSeconds(2);
        cc.EndOfTurn();
    }

    void CheckPlayerNear()
    {
        Vector2 targetPos;
        if (grid.EnemyCheckPlayer(this.pos, this.passi, this.gameObject, out targetPos))
        {
            if (grid.isEnemyNearPlayer(targetPos, this.gameObject))
            {
                StartCoroutine(Attack(grid.cells[(int)targetPos.x, (int)targetPos.y].occupier));
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
