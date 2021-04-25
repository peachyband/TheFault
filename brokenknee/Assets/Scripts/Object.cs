using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object : MonoBehaviour
{
    [TextArea]
    public string Description = "";
    public Material outline;
    public float thick;
    public bool isMoused = false;

    private void OnMouseOver()
    {
        isMoused = true;
    }
    private void OnMouseExit()
    {
        isMoused = false;
    }
}
