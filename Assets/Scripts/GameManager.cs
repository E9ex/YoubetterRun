using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
 public static int  score = 0;
 public static int  bestscore = 0;
  public TextMeshProUGUI Scoretext,BestScoretext;
  private PlayerController PlayerController;


  private void Awake()
  {
    PlayerController = GameObject.FindObjectOfType<PlayerController>();
  }

  private void Start()
  {
    BestScoretext.text = "BestScore: "+PlayerPrefs.GetInt("bestscore").ToString();
    bestscore = PlayerPrefs.GetInt("bestscore");
    BestScoretext.text = "Best: "+bestscore.ToString();
  }

  public void addPoints(int point)
  {
    score += point;
    Scoretext.text = "Score: " + score;
    PlayerController.speed += PlayerController.speedIncreasePoint;
    if (score > bestscore)
    {
      bestscore = score;
      PlayerPrefs.SetInt("bestscore", bestscore);
    }
  }

  
}
