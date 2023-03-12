using UnityEngine;
using System.Collections;
using TMPro;

public class weather_script : MonoBehaviour
{
	string JSON_Temperature;
	private int unit = 0;

	[SerializeField] private TMP_Text temperatureText;
	[SerializeField] private TMP_Text cityText;
	[SerializeField] private TMP_Dropdown dropdown;
	

	WWW www;
	string url = "http://api.weatherapi.com/v1/current.json?key=f6ad9712aafc496c8d8145010221403&aqi=no&q=";

	void Start() // Use this for initialization
	{
		url = url + cityText.text;
		www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			string work = www.text;

			_Particle fields = JsonUtility.FromJson<_Particle>(work);
			string temp_unit;
			if(unit==0)
            {
				JSON_Temperature = fields.current.temp_c;
				temp_unit = " °C ";
			}
            else
            {
				JSON_Temperature = fields.current.temp_f;
				temp_unit = " °F ";
			}
			


			string temp = JSON_Temperature.Substring(0, 2);
			temperatureText.text = temp + temp_unit;
			
		
		}

	}

	// Update is called once per frame

	[System.Serializable]
	public class _current
	{
		public string temp_c;
		public string temp_f;

	}


	[System.Serializable]
	public class _Particle
	{
		public _current current;
	}

	public void handleDropdown()
    {
		if (dropdown.value == 0) unit = 0;
		else unit = 1;
    }




}