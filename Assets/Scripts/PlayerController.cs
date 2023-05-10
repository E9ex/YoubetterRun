using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
   public static bool alive = true;
    private float speed = 5;
    private Rigidbody rb;
    private float HorizontalInput;
    private float jumpforce = 5f;
    [SerializeField] private LayerMask groundedmask;
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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

    }

    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
        
    }

    void jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isgrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2)+0.1f,groundedmask);
        rb.AddForce(Vector3.up*jumpforce);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            die();
            Debug.Log("öldüm.");
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
    }



}//class
