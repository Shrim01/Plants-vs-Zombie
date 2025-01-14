using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Classes;
using TMPro; // Не забудьте добавить ссылку на TextMeshPro

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
    public static int currentIdChoice;
    public GameObject[] Buttons;

    // UI элементы для шкалы опыта
    public Image experienceBar; // Ссылка на Image, представляющий шкалу опыта
    public TMP_Text TextBar; // Ссылка на TMP_Text, представляющий текстовый элемент с опытом

    void Start()
    {
        Choice.Chosen = new[] { false, false, false, false };
        scorePlayer = 0;
        UpdateExperienceBar(); // Инициализация шкалы опыта
    }

    public void AddScore(int score)
    {
        scorePlayer += score;
        UpdateExperienceBar(); // Обновляем шкалу опыта
        if (scorePlayer >= scoreNextlevel)
        {
            ShowChoice();
            scoreNextlevel *= 3; // Увеличиваем необходимый опыт для следующего уровня
        }
    }

    public void UpdateExperienceBar()
    {
        if (experienceBar != null)
        {
            float experiencePercentage = (float)scorePlayer / scoreNextlevel;
            experienceBar.fillAmount = experiencePercentage; // Обновляем заполнение шкалы

            // Обновляем текстовое поле
            if (TextBar != null)
            {
                TextBar.text = $"{scorePlayer}/{scoreNextlevel}"; // Форматируем текст
            }
        }
    }

    private void ShowChoice()
    {
        choice.SetActive(true);
        if (currentIdChoice == 0)
        {
            if (!Choice.Chosen[currentIdChoice])
                Instantiate(HidePeas[currentIdChoice], new Vector3(1620 - 40, 681, 0), new Quaternion(0, 0, 0, 0));
            else
                Instantiate(Peas[currentIdChoice], new Vector3(1620 - 40, 681, 0), new Quaternion(0, 0, 0, 0));
            currentIdChoice = 1;
        }
        else if (currentIdChoice == 1)
        {
            if (!Choice.Chosen[currentIdChoice])
                Instantiate(HidePeas[currentIdChoice], new Vector3(1620 - 40, 681, 2), new Quaternion(0, 0, 0, 0));
            else
                Instantiate(Peas[currentIdChoice], new Vector3(1620 - 40, 681, 2), new Quaternion(0, 0, 0, 0));
            if (!Choice.Chosen[currentIdChoice + 1])
                Instantiate(HidePeas[currentIdChoice + 1], new Vector3(1620 - 40, 270, 2), new Quaternion(0, 0, 0, 0));
            else
                Instantiate(Peas[currentIdChoice + 1], new Vector3(1620 - 40, 270, 2), new Quaternion(0, 0, 0, 0));
        }
        else if (currentIdChoice == 2)
        {
            if (!Choice.Chosen[currentIdChoice + 1])
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