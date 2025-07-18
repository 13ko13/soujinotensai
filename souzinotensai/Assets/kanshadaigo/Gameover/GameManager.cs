using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int lives = 3;

    private void Awake()
    {
        // �V���O���g���i1�������݁j
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[����؂�ւ��Ă������Ȃ�
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
            //���݂̃X�e�[�W�Ŏ���ł������邤���͂��̃X�e�[�W�ŕ�������
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            // �c�@0 �� ���j���[�V�[����
            SceneManager.LoadScene("MenuScene"); // ���V�[�����͎����̂ɍ��킹��
        }
    }

    public void ResetLives(int newLives)   //�c�@��������Ԃɖ߂�
    {
        lives = newLives;
    }
}
