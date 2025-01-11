using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int scorePlayer;
    public int scoreNextlevel = 20;
    public GameObject choice;
    public GameObject gameOver;
    

    void Start()
    {
        scorePlayer = 0;
    }

    public void AddScore(int score)
    {
        scorePlayer += score;
        if (scorePlayer >= scoreNextlevel)
        {
            ShowChoice();
            scoreNextlevel *= 3;
        }
    }

    private void ShowChoice()
    {
        choice.SetActive(true);
    }

    public void DoChoice(int num)
    {
        if (num == 0)
            if (num == 1)
                choice.SetActive(false);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}