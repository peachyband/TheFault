using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vasyalogic : MonoBehaviour
{
    public AudioSource audcrtl;
    public Animator anctrl;
    public Animator profctrl;
    public float cooldownTime;
    public float talkcooldownTime;
    public int currentscene;

    void Start()
    {
        if (currentscene == 0)
        {
            StartCoroutine(playanim());
        }
        else if (currentscene == 1)
        {
            anctrl.Play("Vasya_lasttalk", 0, 0.0f);
        }
    }

    public IEnumerator playanim()
    {
        yield return new WaitForSeconds(cooldownTime);
        anctrl.Play("Vasya_up", 0, 0.0f);
    }
    
    public IEnumerator playtalkanim()
    {
        yield return new WaitForSeconds(talkcooldownTime);
        anctrl.Play("Vasya_talk", 0, 0.0f);
    }

    public void MakeUp()
    {
        anctrl.SetBool("Upped", true);
        anctrl.Play("Vasya_idle", 0, 0.0f);
        audcrtl.Pause();
        profctrl.SetBool("Stared", true);
        profctrl.Play("Prof_staring", 0, 0.0f);
        StartCoroutine(playtalkanim());
    }

}
