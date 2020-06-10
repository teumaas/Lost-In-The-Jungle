using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuestionMarkers : MonoBehaviour
{
    private bool questionOneAnswered = false;
    private bool questionTwoAnswered = false;
    private bool questionThreeAnswered = false;
    private bool questionFourAnswered = false;
    private bool questionFiveAnswered = false;

    private bool gameIsPaused = false;
    public GameObject questionUI;
    private TextMeshProUGUI questionText;
    private TextMeshProUGUI answerOneButtonText;
    private TextMeshProUGUI answerTwoButtonText;
    private TextMeshProUGUI answerThreeButtonText;
    private TextMeshProUGUI answerFourButtonText;

    [SerializeField]
    private int timerQuestionOne = 3;
    [SerializeField]
    private int timerQuestionTwo = 26;
    [SerializeField]
    private int timerQuestionThree = 37;
    [SerializeField]
    private int timerQuestionFour = 53;
    [SerializeField]
    private int timerQuestionFive = 60;

    private Level levelData;
    private Dictionary<string, string> responses = new Dictionary<string, string>();

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
            Debug.Log(responses);
            // Normal speed
            Time.timeScale = 1f;
            gameIsPaused = false;
        }

    void Pause(int questionNumber)
    {
        questionUI.SetActive(true);

        questionText.text = levelData.questions[questionNumber - 1].question;
        answerOneButtonText.text = levelData.questions[questionNumber - 1].answers[0].answer;
        answerTwoButtonText.text = levelData.questions[questionNumber - 1].answers[1].answer;
        answerThreeButtonText.text = levelData.questions[questionNumber - 1].answers[2].answer;
        answerFourButtonText.text = levelData.questions[questionNumber - 1].answers[3].answer;

        // Zero speed (Pause)
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    void MarkQuestionAnswered(){
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
        int a = 0;
        if(Time.timeSinceLevelLoad >= timerQuestionOne && questionOneAnswered == false){
            a = 1;
        }
        // Question two trigger
        if(Time.timeSinceLevelLoad >= timerQuestionTwo && questionTwoAnswered == false){
            a = 2;
        }
        // Question three trigger
        if(Time.timeSinceLevelLoad >= timerQuestionThree && questionThreeAnswered == false){
            a = 3;
        }
        // Question four trigger
        if(Time.timeSinceLevelLoad >= timerQuestionFour && questionFourAnswered == false){
            a = 4;
        }
        // Question five trigger
        if(Time.timeSinceLevelLoad >= timerQuestionFive && questionFiveAnswered == false){
            a = 5;
        }

        responses.Add(levelData.questions[a - 1]._id, levelData.questions[a - 1].answers[0]._id);
        MarkQuestionAnswered();
        Resume();
    }

    public void clickButtonTwo(){
        // -- TBD Smits API data implementatie
        Debug.Log("Second answer clicked.");
        int a = 0;
        if(Time.timeSinceLevelLoad >= timerQuestionOne && questionOneAnswered == false){
            a = 1;
        }
        // Question two trigger
        if(Time.timeSinceLevelLoad >= timerQuestionTwo && questionTwoAnswered == false){
            a = 2;
        }
        // Question three trigger
        if(Time.timeSinceLevelLoad >= timerQuestionThree && questionThreeAnswered == false){
            a = 3;
        }
        // Question four trigger
        if(Time.timeSinceLevelLoad >= timerQuestionFour && questionFourAnswered == false){
            a = 4;
        }
        // Question five trigger
        if(Time.timeSinceLevelLoad >= timerQuestionFive && questionFiveAnswered == false){
            a = 5;
        }

        responses.Add(levelData.questions[a - 1]._id, levelData.questions[a - 1].answers[1]._id);
        MarkQuestionAnswered();
        Resume();
    }

    public void clickButtonThree(){
        // -- TBD Smits API data implementatie
        Debug.Log("Third answer clicked.");
        int a = 0;
        if(Time.timeSinceLevelLoad >= timerQuestionOne && questionOneAnswered == false){
            a = 1;
        }
        // Question two trigger
        if(Time.timeSinceLevelLoad >= timerQuestionTwo && questionTwoAnswered == false){
            a = 2;
        }
        // Question three trigger
        if(Time.timeSinceLevelLoad >= timerQuestionThree && questionThreeAnswered == false){
            a = 3;
        }
        // Question four trigger
        if(Time.timeSinceLevelLoad >= timerQuestionFour && questionFourAnswered == false){
            a = 4;
        }
        // Question five trigger
        if(Time.timeSinceLevelLoad >= timerQuestionFive && questionFiveAnswered == false){
            a = 5;
        }

        responses.Add(levelData.questions[a - 1]._id, levelData.questions[a - 1].answers[2]._id);
        MarkQuestionAnswered();
        Resume();
    }

    public void clickButtonFour(){
        // -- TBD Smits API data implementatie
        Debug.Log("Fourth answer clicked.");
        int a = 0;
        if(Time.timeSinceLevelLoad >= timerQuestionOne && questionOneAnswered == false){
            a = 1;
        }
        // Question two trigger
        if(Time.timeSinceLevelLoad >= timerQuestionTwo && questionTwoAnswered == false){
            a = 2;
        }
        // Question three trigger
        if(Time.timeSinceLevelLoad >= timerQuestionThree && questionThreeAnswered == false){
            a = 3;
        }
        // Question four trigger
        if(Time.timeSinceLevelLoad >= timerQuestionFour && questionFourAnswered == false){
            a = 4;
        }
        // Question five trigger
        if(Time.timeSinceLevelLoad >= timerQuestionFive && questionFiveAnswered == false){
            a = 5;
        }

        responses.Add(levelData.questions[a - 1]._id, levelData.questions[a - 1].answers[3]._id);
        MarkQuestionAnswered();
        Resume();
    }

}
