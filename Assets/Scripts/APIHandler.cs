using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIHandler : MonoBehaviour
{
    private string BaseURL = "https://serious-game-server.herokuapp.com/";

    //Post without predefined WWWForm body
    public void GamePost(string endpoint, string id, Action<string> resolve, Action<string> reject) {
        GamePost(endpoint, id, resolve, reject, new WWWForm());
    } 

    //Post with predefined WWWForm body
    public void GamePost(string endpoint, string id, Action<string> resolve, Action<string> reject, WWWForm body) {
        StartCoroutine(PostRequest($"{endpoint}/{id}", body, (result) => {
            if (result.responseCode == 404) {
                reject($"{result.error}: {result.downloadHandler.text}");
                Debug.Log($"{result.error}: {result.downloadHandler.text}");
            }
            else if (result.isNetworkError || result.isHttpError) {
                reject($"{result.error}: {result.downloadHandler.text}");
                Debug.Log($"{result.error}: {result.downloadHandler.text}");
            }
            else {
                resolve(result.downloadHandler.text);
            }
        }));
    }

    private IEnumerator PostRequest(string path, WWWForm body, Action<UnityWebRequest> callback) {
        using (UnityWebRequest request = UnityWebRequest.Post($"{BaseURL}{path}", body)) {
            yield return request.SendWebRequest();
            callback(request);
        }
    }

    private IEnumerator PutRequest(string path, byte[] body, Action<UnityWebRequest> callback) {
        using (UnityWebRequest request = UnityWebRequest.Put($"{BaseURL}{path}", body)) {
            yield return request.SendWebRequest();
            callback(request);
        }
    }
}
