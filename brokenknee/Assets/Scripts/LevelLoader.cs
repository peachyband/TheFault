using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;
    public float scenetime;
    public bool menu = false;
    public bool tutorial = false;
    public bool prolog = false;
    public int dialogCount;
    [TextArea]
    public string[] tut;
    public Text _uitext;


    private void Start()
    {
        if (menu) transitionTime = 0;
        StartCoroutine(WaitLevel());
        
        if (tutorial)
        {
            _uitext.gameObject.SetActive(true);
            _uitext.text = tut[dialogCount];
        }

        if (prolog)
        {
            StartCoroutine(WaitForChange(scenetime));
        }
    }

    private void Update()
    {
        if (tutorial && dialogCount > -1)
        {
            if (Input.GetMouseButtonUp(0)) 
            { 
                dialogCount -= 1;
                _uitext.text = tut[dialogCount];
            }
            if (dialogCount == 0)
            {
                _uitext.text = "";
                dialogCount -= 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
        
    }

    public void LoadNextLevel()
    {
        if (!menu && !prolog)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isMoving = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Moving", false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().freezeRotation = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator WaitForChange(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        LoadNextLevel();
    }

    IEnumerator LoadLevel(int levelindx)
    {
        yield return new WaitForSeconds(transitionTime);
        transition.SetTrigger("Start");
        SceneManager.LoadScene(levelindx);
    }

    IEnumerator WaitLevel()
    {
        yield return new WaitForSeconds(transitionTime);
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
