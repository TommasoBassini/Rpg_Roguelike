using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FogOfWarManager : MonoBehaviour
{
    private Grid grid;
    private int vista = 2;

	void Start ()
    {

    }

    public void Fog(Vector2 pos)
    {
        grid = FindObjectOfType<Grid>();
        List<Cell> cellNear = new List<Cell>();
        int _x = (int)pos.x;
        int _y = (int)pos.y;

        Vector2[] directions = new Vector2[4];

        directions[0] = new Vector2(-1, 0);
        directions[1] = new Vector2(0, -1);
        directions[2] = new Vector2(1, 0);
        directions[3] = new Vector2(0, 1);

        for (int i = (_x - vista); i <= (_x + vista); i++)
        {
            for (int y = (_y - vista); y <= (_y + vista); y++)
            {


                if (i < 0)
                    continue;
                if (y < 0)
                    continue;
                if (i > 20)
                    continue;
                if (y > 20)
                    continue;



                if (Mathf.Abs(i - _x) + Mathf.Abs(y - _y) == (vista / 2))
                {
                    SpriteRenderer sr = grid.cells[i, y].gameObject.GetComponent<SpriteRenderer>();
                    sr.color = Color.white;
                }
                if (Mathf.Abs(i - _x) + Mathf.Abs(y - _y) == (vista))
                {
                    SpriteRenderer sr = grid.cells[i, y].gameObject.GetComponent<SpriteRenderer>();
                    sr.color = Color.grey;
                }
            }
        }
    }
}
