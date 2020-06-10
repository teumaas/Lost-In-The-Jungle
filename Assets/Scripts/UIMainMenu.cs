﻿using System.Collections;
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

    private APIHandler Api;
    // Start is called before the first frame update
    void Start()
    {
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

        Api.StartGame(InputPIN.GetComponent<TMP_InputField>().text);
    }
}
