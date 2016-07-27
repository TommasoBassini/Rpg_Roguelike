using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorPanel : MonoBehaviour
{
    public GameObject panel;
    public Color color;
    public Color white;

    public void Color()
    {
         panel.GetComponent<Image>().color = color;
    }

    public void clear()
    {
        panel.GetComponent<Image>().color = white;
    }
}
