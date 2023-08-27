using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;

[System.Serializable]
public class Response
{
    public Body response;
}

[System.Serializable]
public class Body
{
    public List<Item> body;
}

[System.Serializable]
public class Item
{
    public string dataTime;
}

public class API_USING : MonoBehaviour
{
    void api_W()
    {
        string url = "http://apis.data.go.kr/B552584/ArpltnInforInqireSvc/getMinuDustFrcstDspth"; // URL
        url += "?ServiceKey=" + "Qj0WWfRKERlJwE1vgiFEdBsvloir3s9EBJ9pbfiRTUTvxSsJr6W4glqq3tWpJhiMiU%2FukYOpGQOVjdft2pZzwg%3D%3D"; // Service Key
        url += "&returnType=json";
        url += "&numOfRows=100";
        url += "&pageNo=1";
        url += "&sidoName=서울";
        url += "&ver=1.0";

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";

        string results = string.Empty;
        HttpWebResponse response;

        using (response = request.GetResponse() as HttpWebResponse)
        {
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonString = reader.ReadToEnd();

            Response jsonResponse = JsonUtility.FromJson<Response>(jsonString);
            results = jsonResponse.response.body[0].dataTime;
        }

        Debug.Log(results);
    }

    // Start is called before the first frame update
    void Start()
    {
        api_W();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
