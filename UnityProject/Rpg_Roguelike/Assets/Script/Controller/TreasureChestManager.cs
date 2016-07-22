using UnityEngine;
using System.Collections;

public class TreasureChestManager : MonoBehaviour
{

    public bool hpPotion;
    public bool mpPotion;
    public bool tankPowerUp;
    public bool dpsPowerUp;
    public bool magePowerUp;
    public bool isClosed = true;
    public bool inFront = false;

	void Start()
    {
        Invoke("SetObjectToCell", 0.3f);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.clear;
    }


    void SetObjectToCell()
    {
        Vector2 pos = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f);
        Grid grid = FindObjectOfType<Grid>();
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().cellObject = this.gameObject;
    }
        

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player" && isClosed == true)
        {
            inFront = true;
            if (inFront == true && Input.GetKeyDown(KeyCode.E)) // Da sistemare questa parte (Non si "apre" quando premo E)
            {
                isClosed = false;
                Debug.Log("Scrigno aperto!!");
                Destroy(this.gameObject);
            }
                    
        }
	}
}
