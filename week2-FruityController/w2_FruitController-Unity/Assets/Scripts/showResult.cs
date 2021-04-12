using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showResult : MonoBehaviour
{
    string score = "0";
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("Score")+"";
    }

    // Update is called once per frame
    void Update()
    {
       // PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score"));
       GetComponent<Text>().text = score;
    }
}
