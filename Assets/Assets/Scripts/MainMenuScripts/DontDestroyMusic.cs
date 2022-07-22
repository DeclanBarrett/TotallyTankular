using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMusic : MonoBehaviour
{
    public string stoppingSceneName;
    public AudioClip[] revolutionaryMusic;
    public AudioClip menuMusic;

    private string previousSceneName;

    void Awake()
    {
        GetComponent<AudioSource>().volume = 0.2f;
        GetComponent<AudioSource>().PlayOneShot(menuMusic);

        revolutionaryMusic = Resources.LoadAll<AudioClip>("RevolutionaryMusic");
        Debug.Log(revolutionaryMusic.Length);
        SceneManager.activeSceneChanged += CheckSceneAndRespond;

       GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Music");
        if (musicObjects.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }

    void CheckSceneAndRespond(Scene firstScene, Scene secondScene)
    {
        Debug.Log(string.Format("Scene Changed: {0}, {1}", firstScene.name, secondScene.name));
        if (SceneManager.GetActiveScene().name == stoppingSceneName)
        {
            GetComponent<AudioSource>().Stop();
        } else if (previousSceneName == stoppingSceneName)
        {
            GetComponent<AudioSource>().volume = 0.2f;
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(menuMusic);
            GetComponent<AudioSource>().loop = true;
        }

        previousSceneName = secondScene.name;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == stoppingSceneName && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().volume = 0.15f;
            GetComponent<AudioSource>().PlayOneShot(revolutionaryMusic[Random.Range(0, revolutionaryMusic.Length - 1)]);
            GetComponent<AudioSource>().loop = false;
        }
    }
}
