using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiManagerDemo : MonoBehaviour
{
    public static GuiManagerDemo instance { get; private set; }
    public GameObject GuiPlaya;

    private void Start()
    {
        if (instance == null)
            instance = this;
    }

    public void SwitchGuiPlaya(bool val, GameObject targetCanvas)
    {
        targetCanvas.SetActive(val);
    }

}
