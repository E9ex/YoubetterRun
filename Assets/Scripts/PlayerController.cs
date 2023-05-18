using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
   public static bool alive = true;
    public float speed = 5;
    private Rigidbody rb;
    private Collider cl;
    private float HorizontalInput;
    public float speedIncreasePoint = .1f;
   private GameManager _gameManager;
   private Animator zipladiMi;
   public ragdollController RagdollController;
   public GameObject restartPanel;
   private bool isJump = true;
   public static bool isRestart = false;
   private void Awake()
   {
       _gameManager = GameObject.FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        cl = GetComponent<CapsuleCollider>();
        zipladiMi = GetComponent<Animator>();
    }
    private void Start()
    {
        if (isRestart)
        {
            alive = true;
            _gameManager.taptoplay.gameObject.SetActive(false);
            _gameManager.helpbutton.gameObject.SetActive(false);
            _gameManager.basladiMi.SetBool("Basla",true);
        }
        else
        {
            alive = false;
            _gameManager.taptoplay.gameObject.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        if (!alive)
        {
            return;
        }
        HorizontalInput = Input.GetAxis("Horizontal");
        Vector3 forwardMove = transform.forward * speed * Time.deltaTime;
        Vector3 horizontalMove = transform.right * HorizontalInput * speed * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isJump)
        {
            Jump();
            zipladiMi.SetTrigger("ZipladiMi");
            isJump = false;
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            die();
            Debug.Log("öldüm.");
        }
    }
    private void OnTriggerEnter(Collider other)
    {//coin değdiğimizde yok oluyor.
        if(other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            _gameManager.addPoints(8);
        }
        if (other.CompareTag("path"))
        {
            isJump = true;
        }
    }
    public void die()
    {
        alive = false;
        Debug.Log("öldük bekle 2 saniye.");
        restartPanel.SetActive(true);
        _gameManager.restartPanelScoretext.text = "Score: " + GameManager.score;
       // Invoke("restartGame",4);// bunu unutma
        cl.enabled=false;
        rb.isKinematic = true;
        RagdollController.OpenRigidbody();
    }
    public void restartGame()
    {
        isRestart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        GameManager.score = 0;
        restartPanel.SetActive(false);
    }
}//class
