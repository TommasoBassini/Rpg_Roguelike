using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public int speed;

    void Update()
    {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button2)) && Camera.main.orthographicSize < 15)
        {
            Camera.main.orthographicSize += speed * Time.deltaTime;
        }
        else if ((!Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.Joystick1Button2)) && Camera.main.orthographicSize > 3.5f)
        {
            Camera.main.orthographicSize -= speed * Time.deltaTime;
        }
    }
}
