using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Torch : MonoBehaviour
{
    private Grid grid;
    private TorchFogOfWar fog;
    public GameObject torchPrefab;


    void Start()
    {
        Invoke("Fog", 0.4f);
    }

    void Fog()
    {
        fog = this.GetComponent<TorchFogOfWar>();
        fog.Fog(new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f));
    }
}