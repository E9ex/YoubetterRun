using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
 public static int  score = 0;
 public static int  bestscore = 0;
  public TextMeshProUGUI Scoretext,BestScoretext;
  public Button taptoplay,helpbutton;
  private PlayerController PlayerController;
  public GameObject helpPanel;
  public Animator basladiMi;
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
  public void startGame()
  {
    PlayerController.alive = true;
    taptoplay.gameObject.SetActive(false);
    helpbutton.gameObject.SetActive(false);
     basladiMi.SetBool("Basla",true);
  }
  public  void infoVer()
  {
    helpPanel.SetActive(!helpPanel.activeSelf);
  } 
}
