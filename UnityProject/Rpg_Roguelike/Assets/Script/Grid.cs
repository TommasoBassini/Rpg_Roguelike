using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{
    public Cell[,] cells = new Cell[20, 20];
    public GameObject cellPrefab;

    void Start ()
    {
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                GameObject newCell = Instantiate(cellPrefab);
                newCell.transform.position = new Vector3(i, j, 0);
                newCell.name = "Cell " + i + " " + j;
                cells[i, j] = newCell.GetComponent<Cell>();
                cells[i, j].pos = new Vector2(i, j);
            }
        }
        PlayerMovement pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
        pm.SetPlayerPosition();
    }
	


	void Update ()
    {
	
	}
}
