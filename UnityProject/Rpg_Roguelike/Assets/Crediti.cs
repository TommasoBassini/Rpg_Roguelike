using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Crediti : MonoBehaviour
{
	void Update ()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("MainMenu");
        }
	}
}
