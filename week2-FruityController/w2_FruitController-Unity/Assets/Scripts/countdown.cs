using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    
    public StateManager StateManager; 
    public float timeStart;
    bool timeState = true;

    void Awake() {
          timeState = true;  
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if(timeState){
            timeStart -= Time.deltaTime;
            // GetComponent<Text>().text = Mathf.Round(timeStart).ToString();
            GetComponent<Text>().text = timeStart.ToString("F2");

            if(timeStart < 0){
                timeState = false;
                FindObjectOfType<StateManager>().WinGame();
            }
        }

    }
}
