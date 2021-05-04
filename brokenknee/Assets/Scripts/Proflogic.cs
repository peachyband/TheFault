using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proflogic : MonoBehaviour
{
    public Animator anctrl;
    public float cooldownTime;

    void Start()
    {

    }

    public IEnumerator playanim()
    {
        yield return new WaitForSeconds(cooldownTime);
        
    }

    
}
