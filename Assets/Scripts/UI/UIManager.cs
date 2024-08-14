using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject _pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        PauseMenu();

    }

    public void RestartLevel(){
        GameManager.manager._lives = GameManager.manager._initiallives;
        GameManager.manager._currentScore = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
 


    }

    public void PauseMenu(){

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }


    }

    public void Continue(){

        _pauseMenu.SetActive(false);
            Time.timeScale = 1;

    }

    public void NextLevel(string SceneName){

        SceneManager.LoadScene(SceneName);
        Time.timeScale = 1f;

    }

}
