using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExamineObj : MonoBehaviour
{
    public int layer;
    public float radius;
    public GameObject indicator;
    public Collider2D[] cols;

    public LevelLoader _lvlctrl;
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
      
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Object")
        {
            Object objctrl = other.GetComponent<Object>();
            if (!objctrl.isReaded) indicator.SetActive(true);
            if (objctrl.isMoused)
            {
                if (objctrl.isMainObject) objctrl.outline.SetColor("MainColor", Color.red * Mathf.Lerp(0, objctrl.thick, 1));
                else objctrl.outline.SetColor("MainColor", Color.white * Mathf.Lerp(0, objctrl.thick, 1));
                Debug.Log("unblocked");
                if (objctrl.isClicked)
                {
                    if (other.GetComponent<LightSwitch>()) other.GetComponent<LightSwitch>().SwitchL();
                    _uitext.text = objctrl.Description;
                    _uitext.gameObject.SetActive(true);
                    objctrl.isClicked = false;
                    objctrl.isReaded = true;
                    if (objctrl.isMainObject) _lvlctrl.LoadNextLevel();
                    if (objctrl.isFinalObject) _lvlctrl.LoadMainMenu();
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
            indicator.SetActive(false);
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
