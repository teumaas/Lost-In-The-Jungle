using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject PopUpPrefab;

    private GameObject EnterPinMenu;
    private GameObject InputPIN;
    private GameObject ButtonEnter;

    private APIHandler api;
    // Start is called before the first frame update
    void Start()
    {
        api = new APIHandler();
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
        WWWForm body = new WWWForm();

        StartCoroutine(api.Post("/play/", InputPIN.GetComponent<TMP_InputField>().text, body));
    }
}
