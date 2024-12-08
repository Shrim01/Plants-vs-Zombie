using JetBrains.Annotations;
using System.Collections.Generic;
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
    private TreeNode<Sprite> binaryTree;
    public GameObject choice;

    void Start()
    {
        sprites = new[] { firstSprite, secondSprite, thirdSprite };
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GoroxScript>();
        scorePlayer = 0;
        binaryTree = new TreeNode<Sprite>(firstSprite);
        binaryTree.Left = new TreeNode<Sprite>(secondSprite);
        binaryTree.Right = new TreeNode<Sprite>(thirdSprite);
    }

    public void AddScore(int score)
    {
        scorePlayer += score;
        if (scorePlayer >= scoreNextlevel)
        {
            ShowChoice();
            scoreNextlevel*=3;
        }
        Debug.Log(scorePlayer);
        Debug.Log(scoreNextlevel);
    }
    private void ShowChoice()
    {
        choice.SetActive(true);
    }
    public void DoChoice(int num)
    {
        if(num==0)
            binaryTree=binaryTree.Left;
        if(num==1)
            binaryTree=binaryTree.Right;
        player.Upgrade(binaryTree.Value);
        choice.SetActive(false);
    }
}
public class TreeNode<T>
{
    public T Value { get; set; }
    public TreeNode<T> Left { get; set; }
    public TreeNode<T> Right { get; set; }

    public TreeNode(T value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}