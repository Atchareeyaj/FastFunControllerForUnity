using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour{

    public StateManager StateManager; 

    public void RestartButtonClick(){
        Debug.Log("Restart");
        FindObjectOfType<StateManager>().Restarting();
    }
}
