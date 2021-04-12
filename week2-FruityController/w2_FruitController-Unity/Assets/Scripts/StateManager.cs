
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour{

    bool gameEnd = false;


    public GameObject gameResult; 

    private void Awake() {
        gameResult.SetActive(false);
        gameEnd = false;
    }

    public void EndGame(){
        if(gameEnd == false){
            gameEnd = true;
            Debug.Log("GameOver");
            gameResult.SetActive(true);

        }
    }

    public void WinGame(){
        Debug.Log("WIN ");
        gameResult.SetActive(true);
    }

    public void Restarting(){

        gameResult.SetActive(false);
        //Reload the same scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
