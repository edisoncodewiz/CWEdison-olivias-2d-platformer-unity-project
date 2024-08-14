using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Header("General Settings")]
    [SerializeField] private float _speed;
    [SerializeField] private Transform platformDetect;
    [SerializeField] private int _points;

    private float _rayDist;
    private bool _movingRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement(){

        transform.Translate(Vector2.right * _speed * Time.deltaTime);
        RaycastHit2D platformCheck = Physics2D.Raycast(platformDetect.position, Vector2.down, _rayDist);

        if(platformCheck.collider == false){

            if(_movingRight){

                transform.eulerAngles = new Vector2(0, -180);
                _movingRight = false;

            }
            else{

                transform.eulerAngles = new Vector2(0, 0);
                _movingRight = true;

            }

        }
    }

private void OnCollisionEnter2D(Collision2D collision){


        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Goal" || collision.gameObject.tag == "MainCamera"){

            if(_movingRight){

                transform.eulerAngles = new Vector2(0, -180);
                _movingRight = false;

            }
            else{

                transform.eulerAngles = new Vector2(0, 0);
                _movingRight = true;

            }  
        }

    }






    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Projectile"){
            GameManager.manager.AddPoints(_points);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }

    }

}
