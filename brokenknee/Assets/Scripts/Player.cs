using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    public Text _uitext;
    private Rigidbody2D rigid;

    [SerializeField]
    private Animator animctrl;
    public bool isMoving = true;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.G))
        {
            Time.timeScale = 0;
        }*/
    }

    void FixedUpdate()
    {
        if (isMoving)
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
            animctrl.SetFloat("Speed", speed/30);
        }
        
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        rigid.velocity = new Vector2(x, y) * speed * Time.fixedDeltaTime;
    }

   /* private void OnTriggerStay2D(Collider2D other)
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
    }*/
}
