using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExamineObj : MonoBehaviour

{
    public Text _uitext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Object")
        {
            Object objctrl = other.GetComponent<Object>();
            if (objctrl.isMoused)
            {
                objctrl.outline.SetColor("MainColor", Color.white * Mathf.Lerp(0, objctrl.thick, 0.5f));
                Debug.Log("unblocked");
                if (objctrl.isClicked)
                {
                    _uitext.text = objctrl.Description;
                    objctrl.isClicked = false;
                }
            }
            else if (objctrl.isMousedExit)
            {
                objctrl.outline.SetColor("MainColor", Color.white * 0);
                Debug.Log("blocked");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Object")
        {
            Object objctrl = other.GetComponent<Object>();
            _uitext.text = "";
            objctrl.outline.SetColor("MainColor", Color.white * 0);
        }
    }
}
