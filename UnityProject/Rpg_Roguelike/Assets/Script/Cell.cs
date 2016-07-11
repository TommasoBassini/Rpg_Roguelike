using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cell : MonoBehaviour
{
    public Vector2 pos;
    public bool isWall = false;
    public GameObject tileEditorCell;
    public bool isAngle = false;
    private Grid grid;
    public List<GameObject> wallNear = new List<GameObject>();

    void Start ()
    {
        
    }

    void Update()
    {

    }
    
    void CheckNearPlayer()
    {
        if (CircleCast())
        {
            Cell cell = wallNear[0].GetComponent<Cell>();
            SpriteRenderer sr = cell.tileEditorCell.GetComponent<SpriteRenderer>();
            if (sr.color != Color.clear)
            {
                SpriteRenderer sr1 = tileEditorCell.GetComponent<SpriteRenderer>();
                sr1.color = Color.white;
            }
        }
        else
        {
            Cell cell1 = wallNear[0].GetComponent<Cell>();
            SpriteRenderer sr = cell1.tileEditorCell.GetComponent<SpriteRenderer>();
            SpriteRenderer sr1 = tileEditorCell.GetComponent<SpriteRenderer>();
            sr1.color = sr.color;
        }
    }

    bool CircleCast()
    {
        bool isPlayer = false;

        Collider2D[] player = Physics2D.OverlapCircleAll(this.pos, 3);
        foreach (var item in player)
        {
            if (item.CompareTag("Player"))
                isPlayer = true;
        }
        return isPlayer;
    }


    public void CheckNearWall()
    {
        Invoke("CoCheckNearWall",0.5f);
        if (isAngle)
            InvokeRepeating("CheckNearPlayer", 0.5f, 0.3f);
    }
    void CoCheckNearWall()
    {
        grid = FindObjectOfType<Grid>();
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
            if (new_x > grid.width - 1)
                continue;
            if (new_y > grid.height - 1)
                continue;

            if (grid.cells[new_x, new_y].isWall)
            {
                wallNear.Add(grid.cells[new_x, new_y].gameObject);
            }
        }

        if (wallNear.Count > 1)
            isAngle = true;
    }
}
