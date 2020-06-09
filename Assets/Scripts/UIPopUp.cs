using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPopUp : MonoBehaviour
{
    private GameObject PopUpPrefab;

    private GameObject Title;
    private GameObject Message;

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
}
