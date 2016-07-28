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

                if ((bool) GameObject.Find("Tile(" + i + "," + j + ")"))
                {
                    GameObject tileCell = GameObject.Find("Tile(" + i + "," + j + ")");
                    GameObject newCell = Instantiate(cellPrefab);
                    newCell.transform.position = new Vector3(i + 0.5f, j + 0.5f, 0);
                    newCell.name = "Cell " + i + " " + j;
                    cells[i, j] = newCell.GetComponent<Cell>();
                    cells[i, j].pos = new Vector2(i, j);

                    Cell cell = newCell.GetComponent<Cell>();
                    cell.tileEditorCell = tileCell;
                    string oggetto =  i + "," + j;

                    if (cell.tileEditorCell != null)
                    {
                        SpriteRenderer sr1 = cell.tileEditorCell.GetComponent<SpriteRenderer>();
                        sr1.color = Color.clear;
                        if (cell.tileEditorCell.transform.parent.name == "Muri")
                        {
                            cell.isWall = true;
                        }
                        if (cell.tileEditorCell.transform.parent.name == "Angoli")
                        {
                            cell.isWall = true;
                            cell.isAngle = true;
                        }
                    }
                    if (SceneManager.GetActiveScene().name == "ProvaTommy" || SceneManager.GetActiveScene().name == "ProvaTommy 1" || SceneManager.GetActiveScene().name == "NewGameDesign") 
                    {
                        SpriteRenderer sr = newCell.GetComponent<SpriteRenderer>();
                        sr.color = Color.clear;
                    }
                }
                else
                {
                    cells[i, j] = null;
                    continue;
                }
            }
            if (SceneManager.GetActiveScene().name == "ProvaTommy" || SceneManager.GetActiveScene().name == "ProvaTommy 1" || SceneManager.GetActiveScene().name == "NewGameDesign")
            {
                PlayerMovement pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
                pm.Invoke("SetPlayerPosition", 0.1f);
            }
        }
        
        

    }

}
