using UnityEngine;
using System.Collections;

public class SemiWallTile : MonoBehaviour
{

	void Start ()
    {
        Invoke("SetObjectToCell", 0.3f);
    }

    void SetObjectToCell()
    {
        Vector2 pos = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f);
        Grid grid = FindObjectOfType<Grid>();
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().cellObject = this.gameObject;
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().isSemiWall = true;
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().isWall = false;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sortingOrder = 100 - (int)pos.y;
    }
}
