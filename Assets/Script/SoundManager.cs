using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audiosource;

    //public AudioClip title;//�^�C�g����ʗp
    public AudioClip main;//���C���Q�[����ʗp
    //public AudioClip result;//���U���g��ʗp

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
        //����S�ẴV�[���ɑΉ������ꍇ�����������Ă���
        // 1/21���_�ł̓��C���Q�[���p�̉��y�𗬂����Ƃ̂݋L�q����

        
    }
}
