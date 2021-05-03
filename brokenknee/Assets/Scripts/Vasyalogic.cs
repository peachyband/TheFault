using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vasyalogic : MonoBehaviour
{
    public Animator anctrl;
    public float cooldownTime;

    void Start()
    {
        StartCoroutine(playanim());
    }

    public IEnumerator playanim()
    {
        yield return new WaitForSeconds(cooldownTime);
        anctrl.Play("Vasya_up", 0, 0.0f);
    }

    public void MakeUp()
    {
        anctrl.SetBool("Upped", true);
        anctrl.Play("Vasya_idle", 0, 0.0f);
    }
}
