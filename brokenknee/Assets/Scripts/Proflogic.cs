using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proflogic : MonoBehaviour
{
    public Animator anctrl;
    public float cooldownTime;
    public int currentscene;
    private AudioLoader aus;
    private bool tmp = false;
    public int triggerIndex = 0;


    void Start()
    {
        aus = Camera.main.GetComponent<AudioLoader>();
        if (currentscene == 0)
        {
            anctrl.Play("Prof_write", 0, 0.0f);
        }
        else if(currentscene == 1)
        {
            anctrl.Play("Prof_talk", 0, 0.0f);
        }
    }

    private void Update()
    {
        if ((!tmp) && (aus.index > triggerIndex) && (currentscene == 1))
        {
            tmp = true;
            StartCoroutine("Pill");
        }
    }
    public IEnumerator Pill()
    {
        yield return new WaitForSeconds(aus.clips[triggerIndex].length);
        anctrl.SetBool("Pill", true);
        yield return new WaitForSeconds(1f);
        GameObject.Find("Vasya").GetComponent<Animator>().SetBool("Pill", true);
    }

    public IEnumerator playanim()
    {
        yield return new WaitForSeconds(cooldownTime);
        
    }

    public void kostil() 
    {
        anctrl.SetBool("Pill", false);
        //GameObject.Find("Vasya").GetComponent<Animator>().SetBool("Pill", true);
    }

    
}
