using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _speed = 5f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         MoveForward();
         CheckBoundary();
    }

    void MoveForward(){
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    void CheckBoundary(){

        if(transform.position.x > 10){

            Destroy(this.gameObject);
        }

    }
}
