using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator levelChangeAnimator;

    private int levelToLoad;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        levelChangeAnimator.SetTrigger("FadeOut");

    }

    public void OnFadeComplete()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelToLoad);
    }
}
