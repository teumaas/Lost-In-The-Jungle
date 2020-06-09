using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class APIHandler
{
    [SerializeField]
    private string BaseURL = "https://serious-game-server.herokuapp.com";

    private Level level;

    private string Result;

    public APIHandler()
    {

    }

    public IEnumerator PostGamePin(string path, string id)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Post(this.BaseURL + path + id, string.Empty))
        {
            // GameObject popup = Instantiate(PopUpPrefab, new Vector3(0, 0), Quaternion.identity) as GameObject;
            
            yield return webRequest.SendWebRequest();

            string[] pages = this.BaseURL.Split('/');
            int page = pages.Length - 1;

            if (webRequest.responseCode == 404)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);

                //popup.transform.parent = GameObject.Find("PopUpPrefab").transform;
            }
            else if(webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
                //popup.transform.parent = GameObject.Find("PopUpPrefab").transform;
            }
            else
            {
                Result = webRequest.downloadHandler.text;
                level = Level.CreateFromJSON(Result);
                Debug.Log(level.questions[0].answers[0].answer);

                //Debug.Log(pages[page] + ": Result: " + Result);
            }
        }
    }
}
