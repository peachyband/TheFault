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
    private AudioLoader aus;
    private bool tmp = false;
    public int triggerIndex = 0;

    void Start()
    {
        aus = Camera.main.GetComponent<AudioLoader>();
        if (currentscene == 0)
        {
            StartCoroutine(playanim());
        }
        else if (currentscene == 1)
        {
            //aus = Camera.main.GetComponent<AudioLoader>();
            anctrl.Play("Vasya_lasttalk", 0, 0.0f);
        }
    }

    private void Update()
    {
        if ((!tmp) && (aus.index > triggerIndex) && (currentscene == 1))
        {
            tmp = true;
            StartCoroutine("Faint");
        }
    }
    public IEnumerator Faint() 
    {
        yield return new WaitForSeconds(aus.clips[triggerIndex].length);
        anctrl.SetBool("Upped", true);
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
