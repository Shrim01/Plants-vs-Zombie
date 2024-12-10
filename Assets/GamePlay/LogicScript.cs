using System;
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BinaryTree;

public class LogicScript : MonoBehaviour
{
    public int scorePlayer;
    public int scoreNextlevel=20;
    public GameObject choice;
    public GameObject gameOver;
    public Sprite[] Sprites;
    private GoroxScript player;
    private TreeNode<Sprite> binaryTree;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GoroxScript>();
        scorePlayer = 0;
        binaryTree = new TreeNode<Sprite>(Sprites[0])
        {
            Left = new TreeNode<Sprite>(Sprites[1])
            {
                Left = new TreeNode<Sprite>(Sprites[3]),
                Right = new TreeNode<Sprite>(Sprites[4])
            },
            Right = new TreeNode<Sprite>(Sprites[2])
            {
                Left = new TreeNode<Sprite>(Sprites[5]),
                Right = new TreeNode<Sprite>(Sprites[6])
            }
        };
    }

    public void AddScore(int score)
    {
        scorePlayer += score;
        if (scorePlayer >= scoreNextlevel)
        {
            ShowChoice();
            scoreNextlevel*=3;
        }
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

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}