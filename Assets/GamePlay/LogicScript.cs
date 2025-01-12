using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Classes;

public class LogicScript : MonoBehaviour
{
    public int scorePlayer;
    public int scoreNextlevel = 50;
    public GameObject choice;
    public GameObject gameOver;
    public Sprite[] SpritesPeas;
    public Sprite[] BulletPeas;
    public Sprite[] SpritesChomper;
    public Sprite[] BulletChomper;
    public GameObject[] Peas;
    public GameObject[] HidePeas;
    public static int currentIdChoice = 0;

    void Start()
    {
        Choice.Chosen = new[] { false, false, false, false };
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

        if (currentIdChoice == 0)
        {
            if (Choice.Chosen[currentIdChoice])
                Instantiate(HidePeas[currentIdChoice], new Vector3(1620, 681, 0), new Quaternion(0, 0, 0, 0));
            else
                Instantiate(Peas[currentIdChoice], new Vector3(1620, 681, 0), new Quaternion(0, 0, 0, 0));
            currentIdChoice = 1;
        }
        else if (currentIdChoice == 1)
        {
            if (Choice.Chosen[currentIdChoice])
                Instantiate(HidePeas[currentIdChoice], new Vector3(1620, 681, 2), new Quaternion(0, 0, 0, 0));
            else
                Instantiate(Peas[currentIdChoice], new Vector3(1620, 681, 2), new Quaternion(0, 0, 0, 0));
            if (Choice.Chosen[currentIdChoice + 1])
                Instantiate(HidePeas[currentIdChoice + 1], new Vector3(1620, 270, 2), new Quaternion(0, 0, 0, 0));
            else
                Instantiate(Peas[currentIdChoice + 1], new Vector3(1620, 270, 2), new Quaternion(0, 0, 0, 0));
        }
        else if (currentIdChoice == 2)
        {
            if (Choice.Chosen[currentIdChoice + 1])
                Instantiate(HidePeas[currentIdChoice + 1], new Vector3(1620, 681, 2), new Quaternion(0, 0, 0, 0));
            else
                Instantiate(Peas[currentIdChoice + 1], new Vector3(1620, 681, 2), new Quaternion(0, 0, 0, 0));
        }
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