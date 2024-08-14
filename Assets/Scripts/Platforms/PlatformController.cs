using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private bool _movingRight;
    private Rigidbody2D _rb;

    void Start()
    {
    _rb = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
       Movement(); 
    }

    void Movement(){

        if(_movingRight){
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
        else{
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision){

        //this code doesn't 
        if(collision.gameObject.tag == "MainCamera"){

            if(_movingRight){


                _movingRight = false;

            }
            else{


                _movingRight = true;

            }  
        }
/*
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player"){

            _rb.constraints

        }
*/
    } 
}
