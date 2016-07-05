using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Enemy : Character
{

    public abstract void Ai();
    public List<CombatCell> cellToCross = new List<CombatCell>();
    public void FindNearestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject nearestPlayer = null;
        int nearestPlayerDistance = 10000;
        // Cerca il GO player più vicino
        foreach (GameObject player in players)
        {
            Player pl = player.GetComponent<Player>();
            int distance = Mathf.Abs((int)pl.pos.x - (int)pos.x) + Mathf.Abs((int)pl.pos.y - (int)pos.y);
            if (distance <= (nearestPlayerDistance))
            {
                nearestPlayerDistance = distance;
                nearestPlayer = player;
                
            }
        }
        StartCoroutine(NearestCellToPlayer(this.pos, this.passi, nearestPlayer));
        //NearestCellToPlayer(this.pos, this.passi, nearestPlayer);
    }

    IEnumerator NearestCellToPlayer(Vector2 _pos, int raggio,GameObject playerNear)
    {
        Player player = playerNear.GetComponent<Player>();
        CombatCell nearestCell = null;
        int nearestCellDistance = 10000;
        Debug.Log(_pos);
        int _x = (int)_pos.x;
        int _y = (int)_pos.y;        
        Vector2[] directions = new Vector2[4];

        directions[0] = new Vector2(-1, 0);
        directions[1] = new Vector2(0, -1);
        directions[2] = new Vector2(1, 0);
        directions[3] = new Vector2(0, 1);

        // incomincia a scansionare l'area
        for (int i = (_x - raggio); i <= (_x + raggio); i++)
        {
            for (int y = (_y - raggio); y <= (_y + raggio); y++)
            {
                if (i < 0)
                    continue;
                if (y < 0)
                    continue;
                if (i > base.grid.width - 1)
                    continue;
                if (y > base.grid.height - 1)
                    continue;

                int distance = Mathf.Abs(i - (int)player.pos.x) + Mathf.Abs(y - (int)player.pos.y);
                if (distance <= nearestCellDistance && !base.grid.cells[i,y].isOccupied)
                {
                    if (nearestCell != null)
                    {
                        SpriteRenderer sr1 = nearestCell.GetComponent<SpriteRenderer>();
                        sr1.color = Color.white;
                    }

                    nearestCellDistance = distance;
                    nearestCell = base.grid.cells[i, y];
                    SpriteRenderer sr = base.grid.cells[i, y].GetComponent<SpriteRenderer>();
                    sr.color = Color.blue;
                    yield return new WaitForSeconds(0.5f);
                }
            }
        }
        if(nearestCell !=null)
            StartCoroutine(GoToEndCell(_pos, nearestCell.pos));
    }



    IEnumerator GoToEndCell(Vector2 _pos,Vector2 endPos)
    {
        
        BattleGrid grid = FindObjectOfType<BattleGrid>();
        grid.cells[(int)this.pos.x, (int)this.pos.y].isOccupied = false;
        int x = (int)endPos.x - (int)_pos.x;
        int y = (int)endPos.y - (int)_pos.y;
        int zy = 0;
        int zx = x / Mathf.Abs(x);

        for (int i = 1; i < Mathf.Abs(x) + 1; i++)
        {
            cellToCross.Add(base.grid.cells[((int)this.pos.x + (zx * i)), (int)this.pos.y]);
        }

        x = Mathf.Abs(x) + cellToCross.Count;

        if (y != 0)
        {
            zy = y / Mathf.Abs(y);
        }
        for (int j = 1; j < Mathf.Abs(y)+ 1; j++)
        {
            
            cellToCross.Add(base.grid.cells[x -1 , (int)this.pos.y + (zy * j)]);
        }
        foreach (CombatCell item in cellToCross)
        {
            this.transform.position = item.gameObject.transform.position;
            base.pos = item.pos;
            yield return new WaitForSeconds(0.5f);
        }
        grid.cells[(int)this.pos.x, (int)this.pos.y].isOccupied = true;
        //cellToCross.Clear();

    }


}
