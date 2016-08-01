using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class Character : MonoBehaviour
{
    public int passi;
    public float velocita;
    public Vector2 pos;
    public bool isMovible = false;
    public  List<float> turn = new List<float>();
    public int n = -1;
    public BattleGrid grid;
    private Vector3 distance;
    private bool isMoving;
    public bool movingAnim = false;
    private Vector3 direction;
    public Animator anim;

    public bool MovingRight = false;
    public bool MovingLeft = false;
    public bool facingRight = true;
    public bool facingLeft = false;   

    public void Start()
    {
        grid = FindObjectOfType<BattleGrid>();
        anim = GetComponent<Animator>();
    }

    public void Move()
    {
        isMovible = true;
        grid.AvailableMovement(pos, passi);
    }

    public void Update()
    {
        if (!this.gameObject.CompareTag("Enemy"))
        {
            if (isMoving)
            {
                distance = grid.cells[(int)pos.x, (int)pos.y].gameObject.transform.position - this.transform.position;
                direction = distance.normalized;
                this.transform.position = this.transform.position + direction * Time.deltaTime * 4;
                SpriteRenderer sr = GetComponent<SpriteRenderer>();
                sr.sortingOrder = 10 - (int)pos.y;
                if (distance.sqrMagnitude < 0.01f)
                {
                    this.transform.position = new Vector3(grid.cells[(int)pos.x, (int)pos.y].transform.position.x, grid.cells[(int)pos.x, (int)pos.y].transform.position.y, 0);
                    isMoving = false;

                }
            }

            if (!isMoving && MovingRight == true)
            {
                facingRight = true;
                MovingRight = false;
            }

            if (!isMoving && MovingLeft == true)
            {
                facingLeft = true;
                MovingLeft = false;
            }

            if ((Input.GetKey(KeyCode.W) || Input.GetAxis("Vertical") > 0) && isMovible && !isMoving)
            {
                PlayerMove(new Vector2(pos.x, pos.y + 1));

                if (isMoving && facingRight == true)
                {
                    MovingRight = true;
                }

                if (isMoving && facingLeft == true)
                {
                    MovingLeft = true;
                }

            }
            if ((Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") < 0) && isMovible && !isMoving)
            {
                PlayerMove(new Vector2(pos.x, pos.y - 1));

                if (isMoving && facingRight == true)
                {
                    MovingRight = true;
                }

                if (isMoving && facingLeft == true)
                {
                    MovingLeft = true;
                }
            }

            if ((Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0) && isMovible && !isMoving)
            {
                PlayerMove(new Vector2(pos.x + 1, pos.y));
                MovingRight = true;
                MovingLeft = false;
                facingRight = true;
                facingLeft = false;
            }

            if ((Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0) && isMovible && !isMoving)
            {
                PlayerMove(new Vector2(pos.x - 1, pos.y));
                MovingRight = false;
                MovingLeft = true;
                facingRight = false;
                facingLeft = true;
            }

            anim.SetBool("IsMoving", isMoving);
            anim.SetBool("MovingRight", MovingRight);
            anim.SetBool("MovingLeft", MovingLeft);
            anim.SetBool("IdleLeft", facingLeft);
            anim.SetBool("IdleRight", facingRight);

        }
    }

    public void PlayerMove(Vector2 _pos)
    {
        if (((int)_pos.x >= 0) && ((int)_pos.y >= 0) && ((int)_pos.x < grid.width) && ((int)_pos.y < grid.height))
        {
            if (grid.cells[(int)_pos.x, (int)_pos.y].isWalkable == true)
            {
                //this.transform.position = grid.cells[(int)_pos.x, (int)_pos.y].gameObject.transform.position;
                isMoving = true;
                pos = _pos;
            }
        }
    }
}
