using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItemLabel : MonoBehaviour
{
    [HideInInspector] public bool labelDraw = false;
    GUIStyle style = new GUIStyle();
    void OnGUI()
    {
        style.fontSize = 30;
        if (labelDraw)
        {
            GUI.Label(new Rect(50, Screen.height / 2, 500, 500), "Press 'E' to pick up", style);
        }
    }
}
