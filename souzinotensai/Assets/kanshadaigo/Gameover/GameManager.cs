using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int lives = 3;

    private void Awake()
    {
        // シングルトン（1つだけ存在）
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンを切り替えても消えない
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
       
    }

    public void OnPlayerDeath()
    {
        lives--;

        if (lives > 0)
        {
            //現在のステージで死んでもがあるうちはそのステージで復活する
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            // 残機0 → メニューシーンへ
            SceneManager.LoadScene("MenuScene"); // ←シーン名は自分のに合わせて
        }
    }

    public void ResetLives(int newLives)   //残機を初期状態に戻す
    {
        lives = newLives;
    }
}
