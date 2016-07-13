using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public int speed;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && Camera.main.orthographicSize < 15)
        {
            Camera.main.orthographicSize += speed * Time.deltaTime;
        }
        else if (!Input.GetKey(KeyCode.Space) && Camera.main.orthographicSize > 5)
        {
            Camera.main.orthographicSize -= speed * Time.deltaTime;
        }
    }
}
