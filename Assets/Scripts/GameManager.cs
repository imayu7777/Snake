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
    public AudioClip[] sounds;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;
    void Start()
    {
        snake = FindObjectOfType<Snake>();
        hiscore = PlayerPrefs.GetInt("Hiscore", 0);
        hiscoreText.SetText(hiscore.ToString());
        audioSource = GetComponent<AudioSource>();
    }
    public void GameOver(){
        PlayEndSound();
        score = 0;
        scoreText.SetText(score.ToString());
        snake.Reset();
    }
    public void Eat(int reward){
        PlayEatSound();
        UpdateScore(reward);
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
        int index = Random.Range(0, sounds.Length-1);
        if (index >= 0 && index < sounds.Length)
        {
            audioSource.clip = sounds[index];
            audioSource.Play();
        }
    }
    public void PlayEndSound()
    {
        audioSource.clip = sounds[sounds.Length-1];
        audioSource.Play();
    }
}
