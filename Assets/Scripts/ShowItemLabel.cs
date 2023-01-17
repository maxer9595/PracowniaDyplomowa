using UnityEngine;

public class ShowItemLabel : MonoBehaviour
{
    bool labelDraw = false;
    GUIStyle style = new GUIStyle();
    private void Update()
    {
        labelDraw = false;
    }
    public void ShowLabelOnGui()
    {
        labelDraw = true;
    }

    void OnGUI()
    {
        style.fontSize = 30;
        if (labelDraw)
        {
            GUI.Label(new Rect(50, Screen.height / 2, 500, 500), "Press 'E' to pick up", style);
        }
    }
}
