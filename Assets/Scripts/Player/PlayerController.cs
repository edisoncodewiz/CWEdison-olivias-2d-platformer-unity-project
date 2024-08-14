using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [Header("General Settings")]
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpPower = 7f;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _lostLivesScreen;


    private bool _isGrounded = true;
    private float _offsetX =0.7f;
    private Rigidbody2D _rb;
    private Animator anim;
    Vector2 playerdirection;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerdirection = new Vector2(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        Fire();
    }

    void Movement(){

        
        float horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput < 0){
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            playerdirection.x = -1;
        }
        else if (horizontalInput > 0){
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            playerdirection.x = 1;

        }

        

        transform.Translate(playerdirection * horizontalInput * _speed * Time.deltaTime);
        anim.SetBool("run", horizontalInput != 0);

        if(transform.position.y < -6){

            Destroy(this.gameObject);

            if(GameManager.manager._lives==0){
            Time.timeScale = 0;
            _lostLivesScreen.SetActive(true);
            }
            else{
            GameManager.manager.SubtractLives();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }


        }

    }

    void Jump(){

        if (Input.GetKeyDown(KeyCode.Space)&& _isGrounded == true){
            _isGrounded = false;
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);

        }


    }

    void Fire(){

        Vector3 firePositionOffset = new Vector3((_offsetX), 0, 0);

        if(playerdirection.x == -1){
            _offsetX = -0.7f;
        }
        else if(playerdirection.x == 1){
            _offsetX = 0.7f;
        }

        if(Input.GetKeyDown(KeyCode.F)){

            if(playerdirection.x == -1){
            Instantiate(_bullet, transform.position + firePositionOffset, Quaternion.Euler(0, 180, 0));
            }
            else{
            Instantiate(_bullet, transform.position + firePositionOffset, Quaternion.Euler(0, 0, 0));   
            }

        }


    }

    private void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.tag == "Ground"){

            _isGrounded = true;

        }

        if(collision.gameObject.tag == "Enemy"){

            Destroy(this.gameObject);

            if(GameManager.manager._lives==0){
            Time.timeScale = 0;
            _lostLivesScreen.SetActive(true);
            }
            else{
            GameManager.manager.SubtractLives();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }

        if(collision.gameObject.tag == "Goal")
        {

            Time.timeScale = 0;
            _gameOverScreen.SetActive(true);

        }


    }
}
