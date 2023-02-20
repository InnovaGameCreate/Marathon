using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audiosource;

    public AudioClip title;//�^�C�g����ʗp
    public AudioClip main;//���C���Q�[����ʗp
    public AudioClip result;//���U���g��ʗp

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

    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)/*��P������prevScene��NULL�ɂȂ��Ă��܂��炵��*/
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
