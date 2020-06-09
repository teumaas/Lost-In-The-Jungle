using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class APIHandler : MonoBehaviour
{
    private string BaseURL = "https://serious-game-server.herokuapp.com/";

    public string StartGame(string id)
    {
        WWWForm body = new WWWForm();
        string result = string.Empty;
        
        StartCoroutine(PostRequest($"play/{id}", body, (UnityWebRequest req) =>
        {
            if (req.responseCode == 404)
            {
                Debug.Log($"{req.error}: {req.downloadHandler.text}");
                //popup.transform.parent = GameObject.Find("PopUpPrefab").transform;
            }
            else if (req.isNetworkError || req.isHttpError)
            {
                Debug.Log($"{req.error}: {req.downloadHandler.text}");
                //popup.transform.parent = GameObject.Find("PopUpPrefab").transform;
            }
            else
            {
                result = req.downloadHandler.text;
            }
        }));

        return result;
    }

    private IEnumerator PostRequest(string path, WWWForm body, Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Post($"{BaseURL}{path}", body))
        {
            yield return request.SendWebRequest();
            callback(request);
        }
    }

    private IEnumerator PutRequest(string path, byte[] body, Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Put($"{BaseURL}{path}", body))
        {
            yield return request.SendWebRequest();
            callback(request);
        }
    }
}
