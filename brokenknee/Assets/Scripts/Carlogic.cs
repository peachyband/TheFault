using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carlogic : MonoBehaviour
{
    public Animator anctrl;
    public float cooldownTime;
    void Start()
    {
        anctrl.Play(name, 0, 0.0f);
    }

    public IEnumerator playanim()
    {
        yield return new WaitForSeconds(cooldownTime);
        anctrl.Play(name, 0, 0.0f);
    }
}
