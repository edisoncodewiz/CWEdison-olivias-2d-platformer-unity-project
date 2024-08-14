using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    private TMP_Text _scoreText;
    public int _currentScore;

    private TMP_Text _livesText;
    [SerializeField] public int _lives;
    public int _initiallives;

    public static GameManager manager;

    // Start is called before the first frame update

    void Awake(){
        if(manager == null){
            manager = this;
            DontDestroyOnLoad(gameObject);
        }
            else if (manager != this){

                Destroy(gameObject);

            }



        }

    


    void Start()
    {
        _scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        _livesText = GameObject.Find("LivesText").GetComponent<TMP_Text>();
        _initiallives = _lives;
        UpdateScore();
        UpdateLives();

    }

    // Update is called once per frame
    void Update()
    {
        if(_scoreText == null){

            _scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
            UpdateScore();
            

        }

        if(_livesText == null){

            _livesText = GameObject.Find("LivesText").GetComponent<TMP_Text>();
            UpdateLives();
            
        }
    }

    void UpdateScore(){

        _scoreText.text = "Score: "+_currentScore.ToString();


    }

    void UpdateLives(){

        _livesText.text = "Lives: "+ _lives.ToString();

    }

    public void AddPoints(int points){

        _currentScore += points;
        UpdateScore();

    }

    public void SubtractLives(){
        _lives -= 1;
        UpdateLives();

    }
}
