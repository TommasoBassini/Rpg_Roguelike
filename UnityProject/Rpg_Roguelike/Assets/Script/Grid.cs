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
                GameObject newCellGo = Instantiate(cellPrefab);

                newCellGo.transform.position = new Vector3(j, i, 0);
                newCellGo.name = "Cell " + i + " " + j;
                cells[i, j] = newCellGo.GetComponent<Cell>();
            }
        }
    }
	
	void Update ()
    {
	
	}
}
