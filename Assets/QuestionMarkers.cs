using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Assets.Scripts.Serializer.Post;
using Assets.Scripts.Serializer.Put;

public class QuestionMarkers : MonoBehaviour
{
    private APIHandler Api;
    private Level levelData;
    private Game gameData;
    private bool gameIsPaused = false;
    private Dictionary<string, string> responses = new Dictionary<string, string>();
    
    [SerializeField]
    private GameObject PopUpPrefabDone;
    [SerializeField]
    private GameObject questionUI;
    [SerializeField]
    private TextMeshProUGUI[] textQuestion = new TextMeshProUGUI[5];
    [SerializeField]
    private int[] timerQuestion = new int[] { 3, 5, 7, 9, 11 };
    [SerializeField]
    private bool[] questionAnswered = new bool[] { false, false, false, false, false };

    void Start()
    {
        levelData = GameController.getLevelData();
        Api = gameObject.AddComponent<APIHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (Time.timeSinceLevelLoad >= timerQuestion[i] && questionAnswered[i] == false)
            {
                Pause(i + 1);
            }
        }
    }
    private void Resume()
    {
        questionUI.SetActive(false);

        // Normal speed
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    private void Pause(int questionNumber)
    {
        questionUI.SetActive(true);
        textQuestion[0].text = levelData.questions[questionNumber - 1].question;
        for (int i = 1; i < 5; i++)
        {
            textQuestion[i].text = levelData.questions[questionNumber - 1].answers[i - 1].answer;
        }

        // Zero speed (Pause)
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    private void MarkQuestionAnswered()
    {
        for (int i = 0; i < 5; i++)
        {
            if (Time.timeSinceLevelLoad >= (timerQuestion[i] - 1))
            {
                questionAnswered[i] = true;
            }
        }
    }

    public void clickQuestionButton(int numberQuestion)
    {
        Debug.Log($"{numberQuestion + 1} answer clicked.");
        int selectedAnswer = 0;

        for (int answer = 0; answer < 5; answer++)
        {
            if (Time.timeSinceLevelLoad >= timerQuestion[answer] && !(answer > 5) && questionAnswered[answer] == false)
            {
                selectedAnswer = answer;
            }
        }

        responses.Add(levelData.questions[selectedAnswer]._id, levelData.questions[selectedAnswer].answers[numberQuestion]._id);

        if (responses.Count < 5)
        {
            MarkQuestionAnswered();
            Resume();
        }
        else
        {
            SubmitAnswers();
        }
    }

    // TODO: Netjes de sessie afsluiten.
    public static void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void SubmitAnswers() {
        gameData = new Game();
        gameData.level = levelData.level;

        foreach (KeyValuePair<string, string> item in responses) {
            gameData.answers.Add(new Assets.Scripts.Serializer.Put.Answer(item.Key, item.Value));
        }
        Api.GamePut("play", levelData.playID, (result) => {
            Level l = Level.CreateFromJSON(result);
            switch (l.level) {
                case 1:
                    GameController.loadForestFire(l);
                    break;
                case 2:
                    GameController.loadVillage(l);
                    break;
                case 3:
                    GameController.loadRuins(l);
                    break;
                default:
                    SceneManager.LoadScene(4);
                    break;
            }
        }, (error) => {
            //TODO handle error correctly (show popup?)
        }, JsonUtility.ToJson(gameData));
    }
}
