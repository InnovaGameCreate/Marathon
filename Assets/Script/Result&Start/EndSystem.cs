
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndSystem : MonoBehaviour
{
    private GameObject distance;
    public void Start()
    {
        distance = GameObject.Find("DistanceMeasure");
    }
    //�@�X�^�[�g�{�^��������������s����
    public void EndGame()
	{
        Destroy(distance);
		SceneManager.LoadScene("Title");
	}
}