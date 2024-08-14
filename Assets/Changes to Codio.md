Steps missing from unity trainings:

Player Creation:
- The player should flip when moving left.
- Code should be added in PlayerController:


			in variables: Vector2 playerdirection;


			in Start(): playerdirection = new Vector2(0f, 0f);

In Movement():    


	if(horizontalInput < 0){
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        (NEW CODE)    playerdirection.x = -1;

        }
        else if (horizontalInput > 0){
            transform.localRotation = Quaternion.Euler(0, 0, 0);
          (NEW CODE)  playerdirection.x = 1;

        }
        transform.Translate(playerdirection * horizontalInput * _speed * Time.deltaTime);


OPTIONAL CODE to make player die when they fall off the course:
In Movement():
        if(transform.position.y < -6){

            Destroy(this.gameObject);

            if(_lives==0){
            Time.timeScale = 0;
            _lostLivesScreen.SetActive(true);
            }
            else{

            _lives -= 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }


        }




Player Attack:
- The player should be able to fire to the right. Code should be added in PlayerController:
- (offsetX should not be a serializefield variable. Players should test out different offsets in code only and not in inspector.)


- Following code in Fire():
-         if(playerdirection.x == -1){
-             _offsetX = -0.7f;
-         }
-         else if(playerdirection.x == 1){
-             _offsetX = 0.7f;
-         }
- 
-         if(Input.GetKeyDown(KeyCode.F)){
- 
-             if(playerdirection.x == -1){
-             Instantiate(_bullet, transform.position + firePositionOffset, Quaternion.Euler(0, 180, 0));
-             }
-             else{
-             Instantiate(_bullet, transform.position + firePositionOffset, Quaternion.Euler(0, 0, 0));   
-             }
-         }
- The rest of the code in Projectile works without any modification.


We Gotta Win:
- Missing step to write -> [SerializeField] private GameObject _gameOverScreen; to create our _gameOverScreen variable
- Missing the following step as well to drag the Canvas variable to this field inside the PlayerController script element of the player GameObject
- Must also turn off the Canvas before start of game


Enemies Arrived:
- Missing instructions to drag the transform of the platform detector to the BOTTOM RIGHT of the enemy game object and not the bottom middle like the instructions say
- Enemies should flip also when they hit another game object, not just when they reach the edge of the platform. Add collider code in EnemyController:
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
    **Note I'm not sure why but sometimes this doesn't work as intended, other times it does, with seemingly no difference


 What’s the Point?: Need to add ScoreText tmp element to all scenes, suggest making canvas a prefab

We need more lives: Lives shouldn’t go in the Player gameobject because this game object gets deleted when you lose a life. Should go in the gamemanager GO which does not get destroyedonload when level restarts



In general: 
-behavior of the game will trigger platform collider on all sides of the platform, allowing infinite jumps if colliding with the side of the platforms. If this is expected behavior it should be mentioned.

-my enemies collider behavior is often unexpected. Sometimes it falls from the initial platform it is on. It often doesn’t detect(?) the main camera collider

- I added animation to the main player (idle and walk) and just walking animation to the enemies. It’s not as complicated as I thought it would be (there was so many bad tutorials, but I found a great one “Unity 2D Platform for Complete Beginners #2 ANIMATION” by Pandemonium) I think character animation should be an Add-On







