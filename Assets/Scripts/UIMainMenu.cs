using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Serializer.Post;

public class UIMainMenu : MonoBehaviour {
    [SerializeField]
    private GameObject PopUpPrefab404;
    private GameObject EnterPinMenu;
    private GameObject InputPIN;
    private GameObject ButtonEnter;
    private APIHandler Api;

    void Start() {
        EnterPinMenu = GameObject.FindGameObjectWithTag("EnterPinMenu");
        InputPIN = GameObject.FindGameObjectWithTag("InputPIN");
        ButtonEnter = GameObject.FindGameObjectWithTag("ButtonEnter");
        PopUpPrefab404 = GameObject.Find("PopUpPrefab404");

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
            Instantiate(PopUpPrefab404, new Vector3(0, 0, 0), Quaternion.identity);
        });
    }
}
