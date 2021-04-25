using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    public Text _uitext;

    [SerializeField]
    private Animator animctrl;
    
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x == 0 && y == 0)
        {
            animctrl.SetBool("Moving", false);
        }
        else
        {
            animctrl.SetBool("Moving", true);
            animctrl.SetFloat("Speed", speed);
        }
        
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.position += new Vector3(x, y, 0) * speed;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Object")
        {
            _uitext.text = other.GetComponent<Object>().Description;
            
        }
        //TODO: INPUT.ACTRION
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _uitext.text = "";
    }
}
