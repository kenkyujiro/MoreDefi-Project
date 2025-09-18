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

    //ゲームクリア関数
    public void GameClear()
    {
        GoalText.gameObject.SetActive(true);
        Debug.Log("Goal!");

        //シーンをリロードしてリスタートする関数
        //※これでスコアが0に戻る
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //ゲームを止めている
        Time.timeScale = 0;
    }

    //ゲームオーバー関数
    public void GameOver()
    {
        GoalText.gameObject.SetActive(true);
        Debug.Log("Game Over");

        //ゲームを止めている
        Time.timeScale = 0;
    }

    //ゲーム再開関数
    public void GameResume()
    {
        GoalText.gameObject.SetActive(false);
        Debug.Log("Reset");

        //シーンをリロードしてリスタートする関数
        //※これでスコアが0に戻る
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //ゲームを再開
        Time.timeScale = 1;
    }
}
