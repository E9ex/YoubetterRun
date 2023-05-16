using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
   public static bool alive = true;
    public float speed = 5;
    private Rigidbody rb;
    private float HorizontalInput;
    public float speedIncreasePoint = .1f;
   private GameManager _gameManager;
   private Animator zipladiMi;
    
    
    
    private void Awake()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        zipladiMi = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!alive)
        {
            return;
        }
        Vector3 forwardMove = transform.forward * speed * Time.deltaTime;
        Vector3 horizontalMove = transform.right * HorizontalInput * speed * Time.deltaTime;
        
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        if (HorizontalInput==0)
        {
            zipladiMi.SetBool("zipla",false);
        }

    }

    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            zipladiMi.SetBool("zipla",true);
          
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
    }
    public void die()
    {
        alive = false;
        Debug.Log("öldük bekle 2 saniye.");
            Invoke("restartGame",2);
    }
    public void restartGame()
    {
        alive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        GameManager.score = 0;
    }



}//class
