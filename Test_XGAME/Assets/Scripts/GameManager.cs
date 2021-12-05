using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int scores =0;
    public GameObject heart1, heart2, heart3;
    public static int Health;
    public static GameManager inst;
    public GameObject gameOver;
    

    [SerializeField] Text ScoreText;
    [SerializeField] Text WinScoreText;



    PlayerMove player;
    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMove>();
        Health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
    }

    private void Update()
    {

        switch(Health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 1:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(true);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                PlayerMove.PlayerLive = false;
                GroundTile.spawnnn = false;
                
                break;
        }
    }
    public void Score()
    {
        
        scores++;
        ScoreText.text = "SCORE: " + scores;
        WinScoreText.text = "BEST YOUR SCORE : " + scores;
    }

   
}
