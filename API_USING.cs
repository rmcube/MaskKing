using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class Response
{
    public Body response;
}

[System.Serializable]
public class Body
{
    public Item[] body;
}

[System.Serializable]
public class Item
{
    public string dataTime;
}

public class API_USING : MonoBehaviour
{
    private const string apiKey = "Qj0WWfRKERlJwE1vgiFEdBsvloir3s9EBJ9pbfiRTUTvxSsJr6W4glqq3tWpJhiMiU%2FukYOpGQOVjdft2pZzwg%3D%3D";

    void api_W()
    {
        string url = "http://apis.data.go.kr/B552584/ArpltnInforInqireSvc/getMinuDustFrcstDspth";
        url += "?ServiceKey=" + apiKey;
        url += "&returnType=json";
        url += "&numOfRows=100";
        url += "&pageNo=1";
        url += "&sidoName=서울";
        url += "&ver=1.0";

        StartCoroutine(GetAPIResponse(url));
    }

    IEnumerator GetAPIResponse(string apiUrl)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("API request error: " + webRequest.error);
            }
            else
            {
                Response jsonResponse = JsonUtility.FromJson<Response>(webRequest.downloadHandler.text);
                if (jsonResponse != null && jsonResponse.response != null && jsonResponse.response.body.Length > 0)
                {
                    string dataTime = jsonResponse.response.body[0].dataTime;
                    Debug.Log(dataTime);
                }
                else
                {
                    Debug.LogError("Invalid API response");
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        api_W();
    }

}
