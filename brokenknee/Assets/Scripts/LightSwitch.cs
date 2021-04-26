using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject flashL;
    public GameObject roomL;
    public GameObject[] hiddenObjs;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in hiddenObjs)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchL() 
    {
        flashL.SetActive(false);
        roomL.SetActive(true);
        foreach (GameObject obj in hiddenObjs) 
        {
            obj.SetActive(true);
        }
    }
}
