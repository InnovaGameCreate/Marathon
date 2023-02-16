
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndSystem : MonoBehaviour
{

	//　スタートボタンを押したら実行する
	public void EndGame()
	{
		SceneManager.LoadScene("NAKAZAWASTART");
	}
}