using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExamineObj : MonoBehaviour
{
    public int layer;
    public float radius;
    public Collider2D[] cols;

    public Text _uitext;
    // Start is called before the first frame update
    void Start()
    {
        layer = LayerMask.GetMask("Object");
        Debug.Log(layer);
    }

    // Update is called once per frame
    void Update()
    {
        /*cols = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D other in cols)
        {
            if (other.transform.tag == "Object")
            {
                Object objctrl = other.GetComponent<Object>();
                if (objctrl.isMoused)
                {
                    objctrl.outline.SetColor("MainColor", Color.white * Mathf.Lerp(0, objctrl.thick, 0.5f));
                    //Debug.Log("unblocked");
                    if (objctrl.isClicked)
                    {
                        _uitext.text = objctrl.Description;
                        objctrl.isClicked = false;
                    }
                }
                else if (objctrl.isMousedExit)
                {
                    objctrl.outline.SetColor("MainColor", Color.white * 0);
                    //Debug.Log("blocked");
                }
            }
        }*/
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
                    if (other.GetComponent<LightSwitch>()) other.GetComponent<LightSwitch>().SwitchL();
                    _uitext.text = objctrl.Description;
                    _uitext.gameObject.SetActive(true);
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
            _uitext.gameObject.SetActive(false);
            objctrl.outline.SetColor("MainColor", Color.white * 0);
        }
    }

   /* private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }*/
}
