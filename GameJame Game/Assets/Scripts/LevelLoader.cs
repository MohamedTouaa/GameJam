using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    [SerializeField]
    private float TransitionTime = 1f;
    // Update is called once per frame
    void Update()
    {

    }

    public void LoadNextScene()
    {
       StartCoroutine(Transition(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private IEnumerator Transition(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
