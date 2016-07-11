using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FogOfWarManager : MonoBehaviour
{
    private Grid grid;
    private int vista = 6;
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
                        }

                        if (Mathf.Abs(cel.pos.x - pos.x) + Mathf.Abs(cel.pos.y - pos.y) == (vista - 1))
                        {
                            SpriteRenderer sr = cel.tileEditorCell.GetComponent<SpriteRenderer>();
                            sr.color = new Color(0.5f, 0.5f, 0.5f);
                            if (!cells.Contains(cel.tileEditorCell))
                                cells.Add(cel.tileEditorCell);
                        }
                        if (Mathf.Abs(cel.pos.x - pos.x) + Mathf.Abs(cel.pos.y - pos.y) == (vista - 2))
                        {
                            SpriteRenderer sr = cel.tileEditorCell.GetComponent<SpriteRenderer>();
                            sr.color = new Color(0.75f, 0.75f, 0.75f);
                            if (!cells.Contains(cel.tileEditorCell))
                                cells.Add(cel.tileEditorCell);
                        }

                        if (Mathf.Abs(cel.pos.x - pos.x) + Mathf.Abs(cel.pos.y - pos.y) < (vista -2))
                        {
                            SpriteRenderer sr = cel.tileEditorCell.GetComponent<SpriteRenderer>();
                            sr.color = Color.white;
                            if (!cells.Contains(cel.tileEditorCell))
                                cells.Add(cel.tileEditorCell);
                        }
                    }
                }
                else
                {
                    if (cel.tileEditorCell != null)
                    {
                        if (Mathf.Abs(cel.pos.x - pos.x) + Mathf.Abs(cel.pos.y - pos.y) == (vista))
                        {
                            SpriteRenderer sr = cel.tileEditorCell.GetComponent<SpriteRenderer>();
                            sr.color = new Color(0.25f, 0.25f, 0.25f);
                            if(!cells.Contains(cel.tileEditorCell))
                                cells.Add(cel.tileEditorCell);
                        }
                        if (Mathf.Abs(cel.pos.x - pos.x) + Mathf.Abs(cel.pos.y - pos.y) == (vista - 1))
                        {
                            SpriteRenderer sr = cel.tileEditorCell.GetComponent<SpriteRenderer>();
                            sr.color = new Color(0.5f, 0.5f, 0.5f);
                            if (!cells.Contains(cel.tileEditorCell))
                                cells.Add(cel.tileEditorCell);
                        }
                        if (Mathf.Abs(cel.pos.x - pos.x) + Mathf.Abs(cel.pos.y - pos.y) == (vista - 2))
                        {
                            SpriteRenderer sr = cel.tileEditorCell.GetComponent<SpriteRenderer>();
                            sr.color = new Color(0.75f, 0.75f, 0.75f);
                            if (!cells.Contains(cel.tileEditorCell))
                                cells.Add(cel.tileEditorCell);
                        }
                        if (Mathf.Abs(cel.pos.x - pos.x) + Mathf.Abs(cel.pos.y - pos.y) < (vista - 1))
                        {
                            SpriteRenderer sr = cel.tileEditorCell.GetComponent<SpriteRenderer>();
                            sr.color = Color.white;
                            if (!cells.Contains(cel.tileEditorCell))
                                cells.Add(cel.tileEditorCell);
                        }
                    }
                    break;
                }
            }
        }
    }
}
