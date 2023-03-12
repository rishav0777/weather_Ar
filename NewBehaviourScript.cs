using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;


public class NewBehaviourScript : MonoBehaviour
{

    //private string city = "error";
    [SerializeField] private TMP_Text city_con;
    // Start is called before the first frame update
    void Start()
      {
          StartCoroutine("SetCity");
      }




    public class IpApiData
    {
        public string city;

        public static IpApiData CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<IpApiData>(jsonString);
        }
    }


    public  IEnumerator SetCity()
    {
        string ip = new System.Net.WebClient().DownloadString("https://api.ipify.org");
        string uri = $"https://ipapi.co/{ip}/json/";


        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            IpApiData ipApiData = IpApiData.CreateFromJSON(webRequest.downloadHandler.text);

             city_con.text = ipApiData.city;

        }
    }
}
