
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndSystem : MonoBehaviour
{

	//�@�X�^�[�g�{�^��������������s����
	public void EndGame()
	{
		SceneManager.LoadScene("NAKAZAWASTART");
	}
}