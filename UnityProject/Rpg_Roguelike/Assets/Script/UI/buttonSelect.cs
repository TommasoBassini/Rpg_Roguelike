using UnityEngine;
using System.Collections;

public class buttonSelect : MonoBehaviour
{
    public void Select()
    {
        RectTransform rt = this.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2 (60,60);
    }

    public void Deselect()
    {
        RectTransform rt = this.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(40, 40);
    }
}
