using UnityEngine;
using System.Collections;

public class TakePlayer : MonoBehaviour
{
    public string namePlayer; 
	void Start ()
    {
        Invoke("SetUI", 0.1f);
	}

    void SetUI()
    {
        Player player = GameObject.Find(namePlayer).GetComponent<Player>();
        player.uiInfo = this.gameObject;
    }
}
