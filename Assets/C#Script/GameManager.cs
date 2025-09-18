using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI GoalText;

    private void Start()
    {
        GoalText.gameObject.SetActive(false);
    }

    //�Q�[���N���A�֐�
    public void GameClear()
    {
        GoalText.gameObject.SetActive(true);
        Debug.Log("Goal!");

        //�V�[���������[�h���ă��X�^�[�g����֐�
        //������ŃX�R�A��0�ɖ߂�
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //�Q�[�����~�߂Ă���
        Time.timeScale = 0;
    }

    //�Q�[���I�[�o�[�֐�
    public void GameOver()
    {
        GoalText.gameObject.SetActive(true);
        Debug.Log("Game Over");

        //�Q�[�����~�߂Ă���
        Time.timeScale = 0;
    }

    //�Q�[���ĊJ�֐�
    public void GameResume()
    {
        GoalText.gameObject.SetActive(false);
        Debug.Log("Reset");

        //�V�[���������[�h���ă��X�^�[�g����֐�
        //������ŃX�R�A��0�ɖ߂�
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //�Q�[�����ĊJ
        Time.timeScale = 1;
    }
}
