using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour
{
    public int forza;
    public int destrezza;
    public int Intelligenza;
    public int passi;
    public float velocita;
    public Vector2 pos;
    public bool isMovible = false;
    public  List<float> turn = new List<float>();
    public int n = -1;
    public BattleGrid grid;

    public void Start()
    {
        grid = FindObjectOfType<BattleGrid>();
    }

    public void OnMouseDown()
    {
       
    }

    public void Move()
    {
        {
            isMovible = true;
            grid.AvailableMovement(pos, passi);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isMovible)
        {
            PlayerMove(new Vector2(pos.x, pos.y + 1));
        }

        if (Input.GetKeyDown(KeyCode.S) && isMovible)
        {
            PlayerMove(new Vector2(pos.x, pos.y - 1));
        }

        if (Input.GetKeyDown(KeyCode.D) && isMovible)
        {
            PlayerMove(new Vector2(pos.x + 1, pos.y));
        }

        if (Input.GetKeyDown(KeyCode.A) && isMovible)
        {
            PlayerMove(new Vector2(pos.x - 1, pos.y));
        }
    }

    public void PlayerMove(Vector2 _pos)
    {
        if (((int)_pos.x >= 0) && ((int)_pos.y >= 0) && ((int)_pos.x < grid.width) && ((int)_pos.y < grid.height))
        {
            if (grid.cells[(int)_pos.x, (int)_pos.y].isWalkable == true)
            {
                this.transform.position = grid.cells[(int)_pos.x, (int)_pos.y].gameObject.transform.position;
                pos = _pos;
            }
        }
    }

    public void Attack(Vector2 _pos)
    {

    }
}
