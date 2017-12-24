using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Text;
using System.IO;

public class Login : MonoBehaviour {

	// Use this for initialization
	public void onLoginClick(){
		UnityEngine.SceneManagement.SceneManager.LoadScene("HowCanIGo");


		checkin ();
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void checkin(){

		string url = "https://api.turkishairlines.com/test/checkin";
		string apisecret = "01ec58115dae4992afc4e78c23e2b2a1";

		string apikey = "l7xxb6f2bd5747ec482b87b47766de0ecac0";

		string results;

		var postData = "{    \"Title\": \"MR\",    \"Name\": \"AYSELCEREN\",    \"Surname\": \"ACAR\",    \"Gender\": \"M\",    \"Pnr\": \"VDPTZ6\",    \"DepartureDate\": \"2017-12-18\",    \"LocationCode\": \"IST\",   \"FlightNumber\": \"2054\",    \"Dcs_RefNumber\": \"006\",    \"SeatNumber\": \"19A\"}";
		var data = Encoding.ASCII.GetBytes(postData);

		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

		request.Method = "POST";
		request.ContentType = "application/json";
		request.ContentLength = data.Length;

		request.Headers.Add("apikey", apikey);
		request.Headers.Add("apisecret", apisecret);

		using (var stream = request.GetRequestStream())
		{
			stream.Write(data, 0, data.Length);
		}

		using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
		using (Stream stream = response.GetResponseStream())
		using (StreamReader reader = new StreamReader(stream))
		{
			results = reader.ReadToEnd();
			print (results.Length);

		}
	}
}
