using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public int speed;
    public GameObject target;

    void Update()
    {
        Vector3 targetPos = new Vector3(target.transform.position.x, target.transform.position.y, -2f);
        transform.position = Vector3.Lerp(this.transform.position, targetPos, Time.deltaTime * 5);

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button2)) && Camera.main.orthographicSize < 15)
        {
            Camera.main.orthographicSize += speed * Time.deltaTime;
        }
        else if ((!Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.Joystick1Button2)) && Camera.main.orthographicSize > 4.5f)
        {
            Camera.main.orthographicSize -= speed * Time.deltaTime;
        }
    }
}
