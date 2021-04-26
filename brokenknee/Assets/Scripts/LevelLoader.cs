using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(EditorSceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelindx)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        EditorSceneManager.LoadScene(levelindx);
    }
}
