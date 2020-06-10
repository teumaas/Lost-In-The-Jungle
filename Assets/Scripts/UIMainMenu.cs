using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject PopUpPrefab;

    private GameObject EnterPinMenu;
    private GameObject InputPIN;
    private GameObject ButtonEnter;

    private QuestionMarkers QuestionMarkers;
    private APIHandler Api;

    void Start()
    {
        QuestionMarkers = gameObject.AddComponent<QuestionMarkers>();
        Api = gameObject.AddComponent<APIHandler>();
        EnterPinMenu = GameObject.FindGameObjectWithTag("EnterPinMenu");
        InputPIN = GameObject.FindGameObjectWithTag("InputPIN");
        ButtonEnter = GameObject.FindGameObjectWithTag("ButtonEnter");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangedInputValue()
    {
        if (InputPIN.GetComponent<TMP_InputField>().text == string.Empty)
        {
            ButtonEnter.GetComponent<Button>().interactable = false;
        }
        else
        {
            ButtonEnter.GetComponent<Button>().interactable = true;
        }
    }

    public void EnterButton()
    {
        //Debug.Log(api.StartGame(InputPIN.GetComponent<TMP_InputField>().text));
        //popup.transform.parent = GameObject.Find("PopUpPrefab").transform;

        Api.GamePost("play", InputPIN.GetComponent<TMP_InputField>().text, (result) => {
            if (result.responseCode == 404) {
                //TODO Scherm laten zien dat de error code incorrect is
                Debug.Log($"{result.error}: {result.downloadHandler.text}");
            }
            else if (result.isNetworkError || result.isHttpError) {
                //TODO Scherm laten zien dat ze de verbinding moeten controleren
                Debug.Log($"{result.error}: {result.downloadHandler.text}");
            }
            else {
                //TODO Ga naar de startscheme met de vragen uit de result
                GameController.LoadData(result.downloadHandler.text);
                SceneManager.LoadScene(2);
            }
        });
    }
}
