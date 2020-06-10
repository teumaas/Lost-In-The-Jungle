using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuestionMarkers : MonoBehaviour
{
    public bool questionOneAnswered = false;
    public bool questionTwoAnswered = false;
    public bool questionThreeAnswered = false;
    public bool questionFourAnswered = false;
    public bool questionFiveAnswered = false;

    public static bool gameIsPaused = false;
    public GameObject questionUI;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI answerOneButtonText;
    public TextMeshProUGUI answerTwoButtonText;
    public TextMeshProUGUI answerThreeButtonText;
    public TextMeshProUGUI answerFourButtonText;
    public int timerQuestionOne = 3;
    public int timerQuestionTwo = 26;
    public int timerQuestionThree = 37;
    public int timerQuestionFour = 53;
    public int timerQuestionFive = 60;

    private Level levelData;

    void Start() {
        levelData = GameController.getLevelData();
    }

    // Update is called once per frame
    void Update()
    {
        // Question one trigger
        if(Time.timeSinceLevelLoad >= timerQuestionOne && questionOneAnswered == false){
            Pause(1);
        }
        // Question two trigger
        if(Time.timeSinceLevelLoad >= timerQuestionTwo && questionTwoAnswered == false){
            Pause(2);
        }
        // Question three trigger
        if(Time.timeSinceLevelLoad >= timerQuestionThree && questionThreeAnswered == false){
            Pause(3);
        }
        // Question four trigger
        if(Time.timeSinceLevelLoad >= timerQuestionFour && questionFourAnswered == false){
            Pause(4);
        }
        // Question five trigger
        if(Time.timeSinceLevelLoad >= timerQuestionFive && questionFiveAnswered == false){
            Pause(5);
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
            Debug.Log(levelData);
            Debug.Log("Question one reached!");
            questionText.text = levelData.questions[0].question;
            answerOneButtonText.text = levelData.questions[0].answers[0].answer;
            answerTwoButtonText.text = levelData.questions[0].answers[1].answer;
            answerThreeButtonText.text = levelData.questions[0].answers[2].answer;
            answerFourButtonText.text = levelData.questions[0].answers[3].answer;
        }else if(questionNumber == 2){
        questionText.text = "Groen, bruin of geel?";
        answerOneButtonText.text = "Groen";
        answerTwoButtonText.text = "Bruin";
        answerThreeButtonText.text = "Geel";
        answerFourButtonText.text = "Blauw";
        }else if(questionNumber == 3){
        questionText.text = "Links, rechts of rechtdoor?";
        answerOneButtonText.text = "Links";
        answerTwoButtonText.text = "Rechts";
        answerThreeButtonText.text = "Rechtdoor";
        answerFourButtonText.text = "Achteruit";
        }else if(questionNumber == 4){
        questionText.text = "Groen, bruin of geel?";
        answerOneButtonText.text = "Groen";
        answerTwoButtonText.text = "Bruin";
        answerThreeButtonText.text = "Geel";
        answerFourButtonText.text = "Blauw";
        }else if(questionNumber == 5){
        questionText.text = "Bier, koffie of thee?";
        answerOneButtonText.text = "Bier";
        answerTwoButtonText.text = "Koffie";
        answerThreeButtonText.text = "Thee";
        answerFourButtonText.text = "Wijn";
        }
        // Zero speed (Pause)
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    void checkQuestionAnswered(){
        if(Time.timeSinceLevelLoad >= (timerQuestionOne - 1)){
            questionOneAnswered = true;
        }
        if(Time.timeSinceLevelLoad >= (timerQuestionTwo - 1)){
            questionTwoAnswered = true;
        }
        if(Time.timeSinceLevelLoad >= (timerQuestionThree - 1)){
            questionThreeAnswered = true;
        }
        if(Time.timeSinceLevelLoad >= (timerQuestionFour - 1)){
            questionFourAnswered = true;
        }
        if(Time.timeSinceLevelLoad >= (timerQuestionFive - 1)){
            questionFiveAnswered = true;
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

    public void clickButtonFour(){
        // -- TBD Smits API data implementatie
        Debug.Log("Fourth answer clicked.");
        checkQuestionAnswered();
        Resume();
    }

}
