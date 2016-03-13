using UnityEngine;
using System.Collections;

public class baba1_script : MonoBehaviour {
    GameObject baba;


    public void baba_valsztas (string b)
    {
        baba = GameObject.Find(b);
        baba.GetComponent<Renderer>().enabled = false;
        this.GetComponent<Renderer>().enabled = true;
        float f = float.Parse("-0.75");
        this.transform.position = new Vector3(1, f, 0); 
    }

	// Use this for initialization
	void Start () {
        this.enabled = false;
      
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
