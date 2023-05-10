using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  [SerializeField] int score = 0;
  public TextMeshProUGUI Scoretext;
  private PlayerController PlayerController;


  private void Awake()
  {
    PlayerController = GetComponent<PlayerController>();
  }

  public void addPoints(int point)
  {
    score += point;
    Scoretext.text = " "+score.ToString();
    PlayerController.speed += PlayerController.speedIncreasePoint;
  }
}
