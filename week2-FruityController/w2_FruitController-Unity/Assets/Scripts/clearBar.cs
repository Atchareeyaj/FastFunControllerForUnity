using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearBar : MonoBehaviour
{
    public StateManager StateManager; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // //checkScore
        // if(PlayerPrefs.GetInt("Score") < 0){
        //     FindObjectOfType<StateManager>().EndGame();
        //     //Debug.Log("Game Over");
        // }
    }

    void OnTriggerEnter2D(Collider2D col) {
        Destroy(col.gameObject);
        MinusScore();
    }

     void MinusScore(){
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")-1);
    }
}
