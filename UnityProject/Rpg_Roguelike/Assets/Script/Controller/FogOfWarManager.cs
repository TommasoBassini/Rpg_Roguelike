using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FogOfWarManager : MonoBehaviour
{
    private Grid grid;
    private int vista = 4;
    private List<GameObject> cellsA = new List<GameObject>();
    private List<GameObject> cellsB = new List<GameObject>();


    void Start ()
    {
        grid = FindObjectOfType<Grid>();        
    }

    public void Fog(Vector2 pos)
    {
        foreach (var item in cellsB)
        {
            if (item != null)
            {
                if (!cellsA.Contains(item))
                {
                    item.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f);
                }
            }

        }
        cellsB.Clear();
        foreach (var item in cellsA)
        {
            cellsB.Add(item);
        }
        cellsA.Clear();
        pos = new Vector2(pos.x, pos.y);
        pos = new Vector2(pos.x + 0.5f, pos.y + 0.5f);

        int _x = (int)pos.x;
        int _y = (int)pos.y;

        List<Vector2> farCell = new List<Vector2>(); 

        for (int i = (_x - vista); i <= (_x + vista); i++)
        {
            for (int y = (_y - vista); y <= (_y + vista); y++)
            {
                if (Mathf.Abs(i - _x) + Mathf.Abs(y - _y) == (vista))
                {
                    farCell.Add(new Vector2(i + 0.5f , y + 0.5f));
                }
            }
        }
        List<Cell> wall = new List<Cell>();
        foreach (var cell in farCell)
        {
            RaycastHit2D[] hit = Physics2D.LinecastAll(pos, cell);
            List<GameObject> celleCast = new List<GameObject>();

            Debug.DrawLine(pos, cell, Color.red);
            foreach (RaycastHit2D cella in hit)
            {
                celleCast.Add(cella.transform.gameObject);
            }

            foreach (var item in celleCast)
            {
                if (item.GetComponent<Cell>() != null)
                {
                    Cell cel = item.GetComponent<Cell>();
                    if (!cel.isIlluminated)
                    {


                        if (!cel.isWall)
                        {
                            if (cel.tileEditorCell != null)
                            {
                                if (!cellsA.Contains(cel.tileEditorCell))
                                    cellsA.Add(cel.tileEditorCell);

                                if (Mathf.Abs((cel.pos.x) - (pos.x - 0.5f)) + Mathf.Abs((cel.pos.y ) - (pos.y - 0.5f)) <= (vista -2))
                                {
                                    SpriteRenderer sr = cel.tileEditorCell.GetComponent<SpriteRenderer>();
                                    Color newColor = Color.white;
                                    StartCoroutine(ChangeColor(sr.color, newColor, sr));
                                    if (!cellsA.Contains(cel.tileEditorCell))
                                        cellsA.Add(cel.tileEditorCell);
                                    if (cel.cellObject != null)
                                    {
                                        SpriteRenderer objectSr = cel.cellObject.GetComponent<SpriteRenderer>();
                                        StartCoroutine(ChangeColor(objectSr.color, Color.white, objectSr));
                                    }
                                }

                                if (Mathf.Abs((cel.pos.x) - (pos.x - 0.5f)) + Mathf.Abs((cel.pos.y) - (pos.y - 0.5f)) == (vista))
                                {
                                    SpriteRenderer sr = cel.tileEditorCell.GetComponent<SpriteRenderer>();
                                    Color newColor = new Color(0.4f, 0.4f, 0.4f);
                                    StartCoroutine(ChangeColor(sr.color, newColor, sr));
                                    if (!cellsA.Contains(cel.tileEditorCell))
                                        cellsA.Add(cel.tileEditorCell);
                                    if (cel.cellObject != null)
                                    {
                                        SpriteRenderer objectSr = cel.cellObject.GetComponent<SpriteRenderer>();
                                        StartCoroutine(ChangeColor(objectSr.color, new Color(0.33f, 0.33f, 0.33f), objectSr));
                                    }
                                }

                                if (Mathf.Abs((cel.pos.x) - (pos.x - 0.5f)) + Mathf.Abs((cel.pos.y) - (pos.y - 0.5f)) == (vista - 1))
                                {
                                    SpriteRenderer sr = cel.tileEditorCell.GetComponent<SpriteRenderer>();
                                    Color newColor = new Color(0.66f, 0.66f, 0.66f);
                                    StartCoroutine(ChangeColor(sr.color, newColor, sr));
                                    if (!cellsA.Contains(cel.tileEditorCell))
                                        cellsA.Add(cel.tileEditorCell);
                                    if (cel.cellObject != null)
                                    {
                                        SpriteRenderer objectSr = cel.cellObject.GetComponent<SpriteRenderer>();
                                        StartCoroutine(ChangeColor(objectSr.color, new Color(0.66f, 0.66f, 0.66f), objectSr));
                                    }
                                }   
                            }
                        }
                        else
                        {
                            // Prova nuova cosa
                            if (cel.tileEditorCell != null)
                            {
                                wall.Add(cel);

                                Vector2[] directions = new Vector2[4];

                                directions[0] = new Vector2(-1, 0);
                                directions[1] = new Vector2(0, -1);
                                directions[2] = new Vector2(1, 0);
                                directions[3] = new Vector2(0, 1);

                                foreach (var dir in directions)
                                {
                                    int new_x = (int)cel.pos.x + (int)dir.x;
                                    int new_y = (int)cel.pos.y + (int)dir.y;

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
                                        if (grid.cells[new_x, new_y].isWall)
                                        {
                                            wall.Add(grid.cells[new_x, new_y]);
                                        }
                                    }
                                }
                            }
                                break;
                        }

                    }
                }
            }
        }

        foreach (var cell in wall)
        {
            if (!cellsA.Contains(cell.tileEditorCell))
                cellsA.Add(cell.tileEditorCell);
            if (Mathf.Abs((int)cell.pos.x - (pos.x - 0.5f)) + Mathf.Abs((int)cell.pos.y - (pos.y - 0.5f)) == vista)
            {
                SpriteRenderer sr = cell.tileEditorCell.GetComponent<SpriteRenderer>();
                Color newColor = new Color(0.4f, 0.4f, 0.4f);
                StartCoroutine(ChangeColor(sr.color, newColor, sr));
                if (cell.cellObject != null)
                {
                    SpriteRenderer objectSr = cell.cellObject.GetComponent<SpriteRenderer>();
                    StartCoroutine(ChangeColor(objectSr.color, new Color(0.4f, 0.4f, 0.4f), objectSr));
                }
            }
            if (Mathf.Abs((int)cell.pos.x - (pos.x - 0.5f)) + Mathf.Abs((int)cell.pos.y - (pos.y - 0.5f)) == vista - 1)
            {
                SpriteRenderer sr = cell.tileEditorCell.GetComponent<SpriteRenderer>();
                Color newColor = new Color(0.66f, 0.66f, 0.66f);
                StartCoroutine(ChangeColor(sr.color, newColor, sr));
                if (cell.cellObject != null)
                {
                    SpriteRenderer objectSr = cell.cellObject.GetComponent<SpriteRenderer>();
                }
            }
            if (Mathf.Abs((int)cell.pos.x - (pos.x - 0.5f)) + Mathf.Abs((int)cell.pos.y - (pos.y - 0.5f)) <= vista - 2)
            {
                SpriteRenderer sr = cell.tileEditorCell.GetComponent<SpriteRenderer>();
                Color newColor = Color.white;
                StartCoroutine(ChangeColor(sr.color, newColor, sr));
                if (cell.cellObject != null)
                {
                    SpriteRenderer objectSr = cell.cellObject.GetComponent<SpriteRenderer>();
                    StartCoroutine(ChangeColor(objectSr.color, Color.white, objectSr));
                }
            }
        }


    }

    IEnumerator ChangeColor(Color oldColor, Color newColor, SpriteRenderer sr)
    {
        float timeElapsed = 0f;
        float totalTime = 0.4f;

        while (timeElapsed < totalTime)
        {
            timeElapsed += Time.deltaTime;
            sr.color = Color.Lerp(oldColor, newColor, timeElapsed / totalTime);
            yield return null;
        }
    }
}
