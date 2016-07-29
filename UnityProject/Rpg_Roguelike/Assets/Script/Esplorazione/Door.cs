using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
    private SpriteRenderer sr;
    public Sprite door;
    private PlayerMovement keys;

    void Start()
    {
        keys = FindObjectOfType<PlayerMovement>();
        Invoke("SetObjectToCell", 0.3f);
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.clear;
        
    }

    void SetObjectToCell()
    {
        Vector2 pos = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f);
        Grid grid = FindObjectOfType<Grid>();
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().cellObject = this.gameObject;
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().isSemiWall = true;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        PlayerMovement player = coll.gameObject.GetComponent<PlayerMovement>();

        if (coll.gameObject.name == "Player" && player.hasKey && keys.nKeys > 0 )
        {
            Vector2 pos = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f);
            Grid grid = FindObjectOfType<Grid>();
            grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().isSemiWall = false;
                        
            player.hasKey = false;
            keys.nKeys--;
            sr.sprite = door;
            Collider2D thiscol = GetComponent<Collider2D>();
            thiscol.enabled = false;
        }
    }
}


