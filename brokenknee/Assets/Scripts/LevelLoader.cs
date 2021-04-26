using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;
    public bool menu = false;


    private void Start()
    {
       if (menu) transitionTime = 0;
    }
    public void LoadNextLevel()
    {
        if (!menu)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isMoving = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Moving", false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().freezeRotation = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
       
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelindx)
    {
        yield return new WaitForSeconds(transitionTime);
        transition.SetTrigger("Start");
        SceneManager.LoadScene(levelindx);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
