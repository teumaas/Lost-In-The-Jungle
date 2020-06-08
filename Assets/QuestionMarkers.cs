using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMarkers : MonoBehaviour
{
    public bool questionOneAnswered = false;
    public bool questionTwoAnswered = false;
    public bool questionThreeAnswered = false;

    public static bool gameIsPaused = false;
    public GameObject questionUI;

    // Update is called once per frame
    void Update()
    {
        // Game pause while showing question
        // Escape key placeholder to resume
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
                if(Time.timeSinceLevelLoad >= 25){
                    questionOneAnswered = true;
                }
                if(Time.timeSinceLevelLoad >= 36){
                    questionTwoAnswered = true;
                }
                if(Time.timeSinceLevelLoad >= 52){
                    questionThreeAnswered = true;
                }
                Resume();
            } else {
                Pause();
            }
        }

        // Question one trigger
        if(Time.timeSinceLevelLoad >= 26 && questionOneAnswered == false){
            Pause();
        }

        // Question two trigger
        if(Time.timeSinceLevelLoad >= 37 && questionTwoAnswered == false){
            Pause();
        }

        // Question three trigger
        if(Time.timeSinceLevelLoad >= 53 && questionThreeAnswered == false){
            Pause();
        }

        void Resume(){
            questionUI.SetActive(false);
            // Normal speed
            Time.timeScale = 1f;
            gameIsPaused = false;
        }

        void Pause(){
            questionUI.SetActive(true);
            // Zero speed (Pause)
            Time.timeScale = 0f;
            gameIsPaused = true;
        }
    }

}
