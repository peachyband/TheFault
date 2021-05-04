using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proflogic : MonoBehaviour
{
    public Animator anctrl;
    public float cooldownTime;
    public int currentscene;


    void Start()
    {
        if(currentscene == 0)
        {
            anctrl.Play("Prof_write", 0, 0.0f);
        }
        else if(currentscene == 1)
        {
            anctrl.Play("Prof_talk", 0, 0.0f);
        }
    }

    public IEnumerator playanim()
    {
        yield return new WaitForSeconds(cooldownTime);
        
    }

    
}
