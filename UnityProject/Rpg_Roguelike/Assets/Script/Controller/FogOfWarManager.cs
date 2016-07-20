using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FogOfWarManager : MonoBehaviour
{
    private Grid grid;
    private int vista = 5;
    private List<GameObject> cells = new List<GameObject>();

	void Start ()
    {
        grid = FindObjectOfType<Grid>();
    }

    public void Fog(Vector2 pos)
    {
        foreach (var item in cells)
        {
            item.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.25f, 0.25f, 0.25f);
        }
        cells.Clear();
        int _x = (int)pos.x;
        int _y = (int)pos.y;

        List<Vector2> farCell = new List<Vector2>(); 


        for (int i = (_x - vista); i <= (_x + vista); i++)
        {
            for (int y = (_y - vista); y <= (_y + vista); y++)
            {
                if (Mathf.Abs(i - _x) + Mathf.Abs(y - _y) == (vista))
                {
                    farCell.Add(new Vector2(i + 0.5f, y + 0.5f));
                }
            }
        }
        pos = new Vector2(pos.x + 0.5f, pos.y + 0.5f);

        foreach (var cell in farCell)
        {
            RaycastHit2D[] hit = Physics2D.LinecastAll(pos, cell);
            List<GameObject> celleCast = new List<GameObject>();
            
            foreach (RaycastHit2D cella in hit)
            {
                celleCast.Add(cella.transform.gameObject);
            }
            
            foreach (var item in celleCast)
            {
                if (item.GetComponent<Cell>() != null)
                {
                    Cell cel = item.GetComponent<Cell>();
                    if (!cel.isWall)
                    {
                        if (cel.tileEditorCell != null)
                        {
                            if (Mathf.Abs(cel.pos.x - pos.x) + Mathf.Abs(cel.pos.y - pos.y) == (vista))
                            {
                                SpriteRenderer sr = cel.tileEditorCell.GetComponent<SpriteRenderer>();
                                sr.color = new Color(0.25f, 0.25f, 0.25f);
                                if (!cells.Contains(cel.tileEditorCell))
                                    cells.Add(cel.tileEditorCell);
                                if(cel.cellObject != null)
                                {
                                    SpriteRenderer objectSr = cel.cellObject.GetComponent<SpriteRenderer>();
                                    objectSr.color = new Color(0.25f, 0.25f, 0.25f);
                                }
                            }

                            if (Mathf.Abs(cel.pos.x - pos.x) + Mathf.Abs(cel.pos.y - pos.y) == (vista - 1))
                            {
                                SpriteRenderer sr = cel.tileEditorCell.GetComponent<SpriteRenderer>();
                                sr.color = new Color(0.5f, 0.5f, 0.5f);
                                if (!cells.Contains(cel.tileEditorCell))
                                    cells.Add(cel.tileEditorCell);
                                if (cel.cellObject != null)
                                {
                                    SpriteRenderer objectSr = cel.cellObject.GetComponent<SpriteRenderer>();
                                    objectSr.color = new Color(0.5f, 0.5f, 0.5f);
                                }
                            }

                            if (Mathf.Abs(cel.pos.x - pos.x) + Mathf.Abs(cel.pos.y - pos.y) == (vista - 2))
                            {
                                SpriteRenderer sr = cel.tileEditorCell.GetComponent<SpriteRenderer>();
                                sr.color = new Color(0.75f, 0.75f, 0.75f);
                                if (!cells.Contains(cel.tileEditorCell))
                                    cells.Add(cel.tileEditorCell);
                                if (cel.cellObject != null)
                                {
                                    SpriteRenderer objectSr = cel.cellObject.GetComponent<SpriteRenderer>();
                                    objectSr.color = new Color(0.75f, 0.75f, 0.75f);
                                }
                            }

                            if (Mathf.Abs(cel.pos.x - pos.x) + Mathf.Abs(cel.pos.y - pos.y) < (vista - 2))
                            {
                                SpriteRenderer sr = cel.tileEditorCell.GetComponent<SpriteRenderer>();
                                sr.color = Color.white;
                                if (!cells.Contains(cel.tileEditorCell))
                                    cells.Add(cel.tileEditorCell);
                                if (cel.cellObject != null)
                                {
                                    SpriteRenderer objectSr = cel.cellObject.GetComponent<SpriteRenderer>();
                                    objectSr.color = Color.white;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (cel.tileEditorCell != null)
                        {
                            if (Mathf.Abs(cel.pos.x - pos.x) + Mathf.Abs(cel.pos.y - pos.y) == (vista))
                            {
                                Vector2 targetPos = new Vector2(0, 0);
                                SpriteRenderer sr = cel.tileEditorCell.GetComponent<SpriteRenderer>();
                                sr.color = new Color(0.25f, 0.25f, 0.25f);
                                if (!cells.Contains(cel.tileEditorCell))
                                    cells.Add(cel.tileEditorCell);
                                if (CheckNearAngle(cel.pos, out targetPos))
                                {

                                    SpriteRenderer sr1 = grid.cells[(int)targetPos.x, (int)targetPos.y].tileEditorCell.GetComponent<SpriteRenderer>();
                                    sr1.color = new Color(0.25f, 0.25f, 0.25f);
                                }


                            }
                            if (Mathf.Abs(cel.pos.x - pos.x) + Mathf.Abs(cel.pos.y - pos.y) == (vista - 1))
                            {
                                Vector2 targetPos = new Vector2(0, 0);
                                SpriteRenderer sr = cel.tileEditorCell.GetComponent<SpriteRenderer>();
                                sr.color = new Color(0.5f, 0.5f, 0.5f);
                                if (!cells.Contains(cel.tileEditorCell))
                                    cells.Add(cel.tileEditorCell);
                                if (CheckNearAngle(cel.pos, out targetPos))
                                {
                                    SpriteRenderer sr1 = grid.cells[(int)targetPos.x, (int)targetPos.y].tileEditorCell.GetComponent<SpriteRenderer>();
                                    sr1.color = new Color(0.5f, 0.5f, 0.5f);
                                }


                            }
                            if (Mathf.Abs(cel.pos.x - pos.x) + Mathf.Abs(cel.pos.y - pos.y) == (vista - 2))
                            {
                                Vector2 targetPos = new Vector2(0, 0);
                                SpriteRenderer sr = cel.tileEditorCell.GetComponent<SpriteRenderer>();
                                sr.color = new Color(0.75f, 0.75f, 0.75f);
                                if (!cells.Contains(cel.tileEditorCell))
                                    cells.Add(cel.tileEditorCell);
                                if (CheckNearAngle(cel.pos, out targetPos))
                                {
                                    SpriteRenderer sr1 = grid.cells[(int)targetPos.x, (int)targetPos.y].tileEditorCell.GetComponent<SpriteRenderer>();
                                    sr1.color = new Color(0.75f, 0.75f, 0.75f);
                                }


                            }
                            if (Mathf.Abs(cel.pos.x - pos.x) + Mathf.Abs(cel.pos.y - pos.y) < (vista - 1))
                            {
                                Vector2 targetPos = new Vector2(0, 0);
                                SpriteRenderer sr = cel.tileEditorCell.GetComponent<SpriteRenderer>();
                                sr.color = Color.white;
                                if (!cells.Contains(cel.tileEditorCell))
                                    cells.Add(cel.tileEditorCell);
                                if (CheckNearAngle(cel.pos, out targetPos))
                                {
                                    SpriteRenderer sr1 = grid.cells[(int)targetPos.x, (int)targetPos.y].tileEditorCell.GetComponent<SpriteRenderer>();
                                    sr1.color = Color.white;
                                }

                            }
                        }
                        break;

                    }
                }
            }
        }
    }

    bool CheckNearAngle(Vector2 pos, out Vector2 targetPos)
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

            if (grid.cells[new_x, new_y] != null)
            {
                if (grid.cells[new_x, new_y].isAngle)
                {
                    targetPos = new Vector2(new_x, new_y);
                    return true;
                }
            }
        }
        targetPos = new Vector2(0,0);
        return false;
    }
}
