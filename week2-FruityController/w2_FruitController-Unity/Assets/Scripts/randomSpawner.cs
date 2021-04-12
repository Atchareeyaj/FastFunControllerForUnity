using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawner : MonoBehaviour{

    public GameObject[] fruits;
    float delay = 0.5f;
    float nextSpawnTime;
    Vector2 spawnPos;
    int x = 0;

    private Vector2 screenBounds;

    int randomInt;

    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update(){
        if(Time.time > nextSpawnTime){
            nextSpawnTime = Time.time + delay;
            SpawnRandom();
            if(randomInt == 0){
                x = -6;
            }else if(randomInt == 1){
                x = -2;
            }else if(randomInt == 2){
                x = 2;
            }else if(randomInt == 3){
                x = 6;
            }
            spawnPos = new Vector2(x,6);
            Instantiate(fruits[randomInt], spawnPos, Quaternion.identity);
        }



    }

    void SpawnRandom(){
        randomInt = Random.Range(0, fruits.Length);
    }
}
