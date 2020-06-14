using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Serializer.Post;

public class UIMainMenu : MonoBehaviour {
    [SerializeField]
    private GameObject PopUpPrefab;
    private GameObject EnterPinMenu;
    private GameObject InputPIN;
    private GameObject ButtonEnter;

    private APIHandler Api;

    void Start() {
        EnterPinMenu = GameObject.FindGameObjectWithTag("EnterPinMenu");
        InputPIN = GameObject.FindGameObjectWithTag("InputPIN");
        ButtonEnter = GameObject.FindGameObjectWithTag("ButtonEnter");

        Api = gameObject.AddComponent<APIHandler>();
    }

    public void ChangedInputValue() {
        if (InputPIN.GetComponent<TMP_InputField>().text == string.Empty) {
            ButtonEnter.GetComponent<Button>().interactable = false;
        }
        else {
            ButtonEnter.GetComponent<Button>().interactable = true;
        }
    }

    public void EnterButton()
    {
        Api.GamePost("play", InputPIN.GetComponent<TMP_InputField>().text, (result) => {
            GameController.loadForestFire(Level.CreateFromJSON(result));
        }, (error) => {
            //TODO handle error correctly (show popup?)
        });
    }
}
