using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audiosource;

    public AudioClip title;//タイトル画面用
    public AudioClip main;//メインゲーム画面用
    public AudioClip result;//リザルト画面用

    public string lastSceneName;
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
        lastSceneName = "Title";

        audiosource.clip = title;
        audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)/*第１引数のprevSceneはNULLになってしまうらしい*/
    {
        
        if (lastSceneName == "Title" && nextScene.name == "MainGame")
        {
            audiosource.clip = main;
            audiosource.Play();
            lastSceneName = "MainGame";
        }

        if (lastSceneName == "MainGame" && nextScene.name == "Result")
        {
            audiosource.clip = result;
            audiosource.Play();
            lastSceneName = "Result";
        }

        if (SceneManager.GetActiveScene().name == "Title")
        {
            audiosource.clip = title;
            audiosource.Play();
            lastSceneName = "Title";
        }
    }
}
