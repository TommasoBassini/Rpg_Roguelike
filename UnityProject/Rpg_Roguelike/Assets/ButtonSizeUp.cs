using UnityEngine;
using System.Collections;

public class ButtonSizeUp : MonoBehaviour
{
    public int start;
    public int end;
    public void Select()
    {
        RectTransform rt = this.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(end, end);
    }

    public void Deselect()
    {
        RectTransform rt = this.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(start, start);
    }
}
