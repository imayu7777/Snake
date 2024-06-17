using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public int hiscore;
    private Snake snake;
    public AudioSource audioSource;
    public AudioClip eatSound;
    public AudioClip deadSound;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;
    public Food greatFood;
    private int foodCount;
    void Start()
    {
        foodCount = 0;
        snake = FindObjectOfType<Snake>();
        hiscore = PlayerPrefs.GetInt("Hiscore", 0);
        hiscoreText.SetText(hiscore.ToString());
        audioSource = GetComponent<AudioSource>();
        DisableGreatFood();
    }
    public void GameOver(){
        audioSource.clip = deadSound;
        audioSource.Play();
        score = 0;
        scoreText.SetText(score.ToString());
        snake.Reset();
        foodCount = 0;
        DisableGreatFood();
    }
    public void Eat(int reward){
        PlayEatSound();
        UpdateScore(reward);
        if(reward == 1){
            //统计吃过的食物的数量
            foodCount ++;
        }
        if(foodCount % 5 == 0){
            //每吃到5个食物，就产生一个大号食物
            EnableGreatFood();
        }
    }
    private void UpdateScore(int reward)
    {
        score += reward;
        scoreText.SetText(score.ToString());
        if(score > hiscore){
            hiscore = score;
            PlayerPrefs.SetInt("Hiscore", hiscore);
            hiscoreText.SetText(hiscore.ToString());
        }
    }
    public void PlayEatSound()
    {
        audioSource.clip = eatSound;
        audioSource.Play();
    }
    public void EnableGreatFood()
    {
        greatFood.gameObject.SetActive(true);
        greatFood.RandomPosition();
        snake.GreatFace();
    }
    public void DisableGreatFood()
    {
        greatFood.gameObject.SetActive(false);
        snake.UsualFace();
    }
}
