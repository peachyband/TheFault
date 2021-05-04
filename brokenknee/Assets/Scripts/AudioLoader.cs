using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoader : MonoBehaviour
{
    public AudioSource audS;
    public AudioClip[] clips;
    public float[] coolDowns;
    public int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        audS = this.GetComponent<AudioSource>();
        index = 0;
        StartCoroutine(PlayClip(coolDowns[index]));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayClip(float coolDown) 
    {
        if (index > 0) coolDown += clips[index-1].length;
        yield return new WaitForSeconds(coolDown);
        //audS.clip = clips[index];
        audS.PlayOneShot(clips[index]);
        index++;
        if (index < clips.Length)
            StartCoroutine(PlayClip(coolDowns[index]));
    }
}
