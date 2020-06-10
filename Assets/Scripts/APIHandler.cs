using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIHandler : MonoBehaviour
{
    private string BaseURL = "https://serious-game-server.herokuapp.com/";

    public void StartGame(string id, Action<UnityWebRequest> callback) {
        StartGame(id, callback, new WWWForm());
    }

    public void StartGame(string id, Action<UnityWebRequest> callback, WWWForm body) {
        StartCoroutine(PostRequest($"play/{id}", body, callback));
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
