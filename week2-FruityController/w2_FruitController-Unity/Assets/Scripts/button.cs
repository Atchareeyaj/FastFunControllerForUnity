using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class button : MonoBehaviour
{
    public int key;
    SpriteRenderer sr;
    bool active = false;
    GameObject note;
    Color old;

    void Awake() {
        sr = GetComponent<SpriteRenderer>();
        PlayerPrefs.SetInt("Score", 0);    
    }
    // Start is called before the first frame update
    void Start(){
        old = sr.color;

    }

    // Update is called once per frame
    void Update(){

        Debug.Log(MidiMaster.noteOnDelegate);


        // change Input.GetKeydown (keypress) to MidiMaster.GetKeydown (Recieveing Midi)
        if(MidiMaster.GetKeyDown(key))
            StartCoroutine(Pressed());
        // if the rightkey is pressed and status = active destroy the note
        if(MidiMaster.GetKeyDown(key)&&active){
            Destroy(note);
            AddScore();
        }
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        active =true;
        // if the object's tag is eqaul to Note
        if(col.gameObject.tag == "Note")
        note = col.gameObject;
        
    }

    void OnTriggerExit2D(Collider2D col) {
        active = false;
    }

    void AddScore(){
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")+1);
    }

    // when key is pressed change the color of the button
    IEnumerator Pressed(){

        // change to new color
        sr.color = new Color (0,0,255,100);
        //wait and turn back to original color
        yield return new WaitForSeconds(0.05f);
        sr.color = old;
    }
}
