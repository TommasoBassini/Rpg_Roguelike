using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Grid : MonoBehaviour
{
    public int width;
    public int height;

    public Cell[,] cells ;
    public GameObject cellPrefab;

    void Start ()
    {

        cells = new Cell[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject newCell = Instantiate(cellPrefab);
                newCell.transform.position = new Vector3(i + this.transform.position.x, j , 0);
                newCell.name = "Cell " + i + " " + j;
                cells[i, j] = newCell.GetComponent<Cell>();
                cells[i, j].pos = new Vector2(i, j);

                if (SceneManager.GetActiveScene().name == "ProvaTommy")
                {
                    SpriteRenderer sr = newCell.GetComponent<SpriteRenderer>();
                    sr.color = Color.clear;
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "ProvaTommy")
        {
            PlayerMovement pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
            pm.SetPlayerPosition();
        }

    }
	


	void Update ()
    {
	
	}
}
