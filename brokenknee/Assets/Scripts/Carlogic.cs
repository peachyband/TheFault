using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carlogic : MonoBehaviour
{
    public Animator anctrl;
    public AnimatorStateInfo info;
    public float cooldownTime = 30.0f;
    void Start()
    {
        //info = anctrl.GetCurrentAnimatorStateInfo(0);
        anctrl.Play("Car_grey", 0, 0.0f);
    }

    void Update()
    {
        /*StartCoroutine(playanim());
        if (isRunning)
        {
            anctrl.enabled = true;
            anctrl.Play("Carg", 0, 1f);
        }
        else
        {
            anctrl.enabled = false;
        }*/
        
    }

    public IEnumerator playanim()
    {
        yield return new WaitForSeconds(cooldownTime);
        anctrl.Play("Car_grey", 0, 0.0f);
    }
}
