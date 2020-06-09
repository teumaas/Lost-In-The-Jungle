using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System;

public class APIHandler : MonoBehaviour
{
    [SerializeField]
    private string BaseURL = "localhost:3000";

    [SerializeField]
    private GameObject PopUpPrefab;

    private GameObject EnterPinMenu;
    private GameObject InputPIN;
    private GameObject ButtonEnter;

    private Departement Departement;

    private string Result;
    // Start is called before the first frame update

    void Start()
    {
        EnterPinMenu = GameObject.FindGameObjectWithTag("EnterPinMenu");
        InputPIN = GameObject.FindGameObjectWithTag("InputPIN");
        ButtonEnter = GameObject.FindGameObjectWithTag("ButtonEnter");
    }

    public void ChangedInputValue()
    {
        if(InputPIN.GetComponent<TMP_InputField>().text == string.Empty)
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
        StartCoroutine(GetCodeValidation(this.BaseURL, InputPIN.GetComponent<TMP_InputField>().text));
    }

    IEnumerator GetCodeValidation(string uri, string code)
    {
        string path = "/organisation/";

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri + path + code))
        {
            GameObject popup = Instantiate(PopUpPrefab, new Vector3(0, 0), Quaternion.identity) as GameObject;
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.responseCode == 404)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);

                popup.transform.parent = GameObject.Find("PopUpPrefab").transform;
            }
            else if(webRequest.isNetworkError || webRequest.isHttpError)
            {
                popup.transform.parent = GameObject.Find("PopUpPrefab").transform;
            }
            else
            {
                Result = webRequest.downloadHandler.text;

                Debug.Log(pages[page] + ": Result: " + Result);
            }
        }
    }

    void Update()
    {
        
    }
}
