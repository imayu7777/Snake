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
    public AudioClip[] sounds;  //0~打开游戏，-0~关闭游戏， -1~游戏结束， 1~-1 游戏中的音效
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
        PlaySound(0);
    }
    public void GameOver(){
        PlaySound(sounds.Length-2);
        score = 0;
        scoreText.SetText(score.ToString());
        snake.Reset();
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
        int index = Random.Range(1, sounds.Length-2);
        if (index >= 0 && index < sounds.Length)
        {
            PlaySound(index);
        }
    }
    public void PlaySound(int index)
    {
        if (index >= 0 && index < sounds.Length){
            audioSource.clip = sounds[index];
            audioSource.Play();
        }
        
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
    void OnApplicationQuit()
    {
        // 游戏退出时执行的逻辑
        // 无法正常播放音频，推测是此时音频组件已经被销毁
        Debug.Log("Game is quitting!");
        PlaySound(sounds.Length-1);
    }
}
