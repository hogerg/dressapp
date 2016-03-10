using UnityEngine;
using System.Collections;

public class baba1_script : MonoBehaviour {
    GameObject baba;

   public void baba1_letrehozas(string b)
    {
        /*GameObject baba = new GameObject();
        baba = GameObject.Find("baba1");
        baba = Instantiate(baba1);*/
        baba = GameObject.Find(b);
        Instantiate(baba);
        baba.transform.position=new Vector3(0, 0, 0);
    }

    public void baba1_meghal()
    {
        Destroy(baba);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
