
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
    //　スタートボタンを押したら実行する
    public void EndGame()
	{
        Destroy(distance);
		SceneManager.LoadScene("Title");
	}
}