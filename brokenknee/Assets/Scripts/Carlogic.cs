using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carlogic : MonoBehaviour
{
    public Animator anctrl;
    public AnimatorStateInfo info;
    public bool isRunning = false;
    void Start()
    {
        info = anctrl.GetCurrentAnimatorStateInfo(0);
    }

    void Update()
    {
        StartCoroutine(playanim());
        if (isRunning)
        {
            anctrl.enabled = true;
            anctrl.Play("Carg", 0, 1f);
        }
        else
        {
            anctrl.enabled = false;
        }
    }

    public IEnumerator playanim()
    {
        isRunning = false;
        yield return new WaitForSeconds(5);
        isRunning = true;
    }
}
