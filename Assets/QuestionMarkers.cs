using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionMarkers : MonoBehaviour
{
    public bool questionOneAnswered = false;
    public bool questionTwoAnswered = false;
    public bool questionThreeAnswered = false;

    public static bool gameIsPaused = false;
    public GameObject questionUI;
    public Text questionText;
    public Text answerOneButtonText;
    public Text answerTwoButtonText;
    public Text answerThreeButtonText;

    // Update is called once per frame
    void Update()
    {
        // Question one trigger
        if(Time.timeSinceLevelLoad >= 26 && questionOneAnswered == false){
            Pause(1);
        }
        // Question two trigger
        if(Time.timeSinceLevelLoad >= 37 && questionTwoAnswered == false){
            Pause(2);
        }
        // Question three trigger
        if(Time.timeSinceLevelLoad >= 53 && questionThreeAnswered == false){
            Pause(3);
        }
    }

    void Resume(){
            questionUI.SetActive(false);
            // Normal speed
            Time.timeScale = 1f;
            gameIsPaused = false;
        }

    void Pause(int questionNumber){
        questionUI.SetActive(true);
        // Update met dummy data -- TBD Smits API data implementatie
        if(questionNumber == 1){
        questionText.text = "Bier, koffie of thee?";
        answerOneButtonText.text = "Bier";
        answerTwoButtonText.text = "Koffie";
        answerThreeButtonText.text = "Thee";
        }else if(questionNumber == 2){
        questionText.text = "Groen, bruin of geel?";
        answerOneButtonText.text = "Groen";
        answerTwoButtonText.text = "Bruin";
        answerThreeButtonText.text = "Geel";
        }else if(questionNumber == 3){
        questionText.text = "Links, rechts of rechtdoor?";
        answerOneButtonText.text = "Links";
        answerTwoButtonText.text = "Rechts";
        answerThreeButtonText.text = "Rechtdoor";
        }
        // Zero speed (Pause)
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    void checkQuestionAnswered(){
        if(Time.timeSinceLevelLoad >= 25){
            questionOneAnswered = true;
        }
        if(Time.timeSinceLevelLoad >= 36){
            questionTwoAnswered = true;
        }
        if(Time.timeSinceLevelLoad >= 52){
            questionThreeAnswered = true;
        }
    }

    public void clickButtonOne(){
        // -- TBD Smits API data implementatie
        Debug.Log("First answer clicked.");
        checkQuestionAnswered();
        Resume();
    }

    public void clickButtonTwo(){
        // -- TBD Smits API data implementatie
        Debug.Log("Second answer clicked.");
        checkQuestionAnswered();
        Resume();
    }

    public void clickButtonThree(){
        // -- TBD Smits API data implementatie
        Debug.Log("Third answer clicked.");
        checkQuestionAnswered();
        Resume();
    }

}
