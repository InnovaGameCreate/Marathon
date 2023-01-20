using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audiosource;

    //public AudioClip title;//タイトル画面用
    public AudioClip main;//メインゲーム画面用
    //public AudioClip result;//リザルト画面用

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        audiosource.clip = main;
        audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //今後全てのシーンに対応した場合分けを書いていく
        // 1/21時点ではメインゲーム用の音楽を流すことのみ記述する

        
    }
}
