using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int scorePlayer;
    public int scoreNextlevel=20;
    private int level = 1;
    public Sprite firstSprite;
    public Sprite secondSprite;
    public Sprite thirdSprite;
    public Sprite[] sprites;
    private GoroxScript player;

    void Start()
    {
        sprites = new[] { firstSprite, secondSprite, thirdSprite };
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GoroxScript>();
        scorePlayer = 0;
    }

    public void AddScore(int score)
    {
        scorePlayer += score;
        if (scorePlayer >= scoreNextlevel)
        {
            player.Upgrade(sprites[level++]);
            scoreNextlevel*=3;
        }
        Debug.Log(scorePlayer);
        Debug.Log(scoreNextlevel);
    }
}