using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Close()
    { 
        Destroy(this.gameObject);
    }

    public void ExitGame() {
        SceneManager.LoadScene(0);
    }
}
