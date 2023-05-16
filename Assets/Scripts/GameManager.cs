using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
 public static int  score = 0;
  public TextMeshProUGUI Scoretext;
  private PlayerController PlayerController;


  private void Awake()
  {
    PlayerController = GameObject.FindObjectOfType<PlayerController>();
  }

  public void addPoints(int point)
  {
    score += point;
    Scoretext.text = "Score: " + score;
    PlayerController.speed += PlayerController.speedIncreasePoint;
  }

  
}
