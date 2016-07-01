using UnityEngine;
using System.Collections;

public class BattleGrid : MonoBehaviour
{

    public int width;
    public int height;

    public Cell[,] cells;
    public GameObject cellPrefab;

    public GameObject[] playerPrefab = new GameObject[3];

    void Start()
    {

        cells = new Cell[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject newCell = Instantiate(cellPrefab);
                newCell.transform.position = new Vector3(i + this.transform.position.x, j, 0);
                newCell.name = "Cell " + i + " " + j;
                cells[i, j] = newCell.GetComponent<Cell>();
                cells[i, j].pos = new Vector2(i, j);
            }
        }

        foreach (GameObject player in playerPrefab)
        {
            int n = Random.Range(15, 20);
            Instantiate(player);
            player.transform.position = cells[n, n].gameObject.transform.position;
        }

    }

    void Update()
    {

    }
}
