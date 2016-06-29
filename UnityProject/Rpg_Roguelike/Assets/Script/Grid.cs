using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{
    public Cell[,] cells = new Cell[20, 20];
    public GameObject cellPrefab;
    public GameObject playerPrefab;
    private FogOfWarManager fog;

    void Start ()
    {
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                GameObject newCell = Instantiate(cellPrefab);

                newCell.transform.position = new Vector3(j, i, 0);
                newCell.name = "Cell " + i + " " + j;
                cells[i, j] = newCell.GetComponent<Cell>();
                
                SpriteRenderer sr = newCell.GetComponent<SpriteRenderer>();
                sr.color = Color.clear;
            }
        }

        GameObject player = Instantiate(playerPrefab);
        fog = player.GetComponent<FogOfWarManager>();
        int x = Random.Range(0, 19);
        int y = Random.Range(0, 19);
        Vector2 fogPos = new Vector2(y, x);
        player.transform.position = new Vector3(x, y, 0);
        fog.Fog(fogPos);
    }
	

	void Update ()
    {
	
	}
}
