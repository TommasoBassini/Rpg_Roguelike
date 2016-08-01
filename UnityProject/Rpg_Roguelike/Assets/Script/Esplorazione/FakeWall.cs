using UnityEngine;
using System.Collections;

public class FakeWall : MonoBehaviour
{

    public bool isClosed = true;
    public bool inFront = false;
    private GameControl gc;
    public AudioClip audioFakeWall;
    void Start ()
    {
        Invoke("SetObjectToCell", 0.3f);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.clear;
        gc = FindObjectOfType<GameControl>();
    }


    void Update ()
    {
        if (inFront == true && (Input.GetKey(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && !gc.incontroON)
        {
            GameObject.Find("AudioManager").GetComponent<AudioSource>().PlayOneShot(audioFakeWall);
            Vector2 pos = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f);
            Grid grid = FindObjectOfType<Grid>();
            grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().cellObject = this.gameObject;
            grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().isWall = false;
            isClosed = false;
            Destroy(this.gameObject);
        }
    }


    void SetObjectToCell()
    {
        Vector2 pos = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f);
        Grid grid = FindObjectOfType<Grid>();
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().cellObject = this.gameObject;
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().isWall = true;
    }


    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player" && isClosed == true)
        {
            inFront = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        inFront = false;
    }

}
