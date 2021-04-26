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
    public bool isMousedExit = false;
    public bool isClicked = false;
    public bool isMainObject = false;

    private void OnMouseOver()
    {
        isMoused = true;
        isMousedExit = false;
    }
    private void OnMouseExit()
    {
        isMoused = false;
        isMousedExit = true;
    }
    private void OnMouseDown()
    {
        isClicked = true;
    }
}
