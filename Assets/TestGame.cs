using UnityEngine;
using System.Collections;
using System;
using System.Net;

public class TestGame : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
        IPAddress[] ips= Dns.GetHostAddresses(Dns.GetHostName());
        string rawIp = ips[1].ToString();
        Debug.Log(rawIp);

    }
  
    // Update is called once per frame
    void Update () {
	
	}
}
