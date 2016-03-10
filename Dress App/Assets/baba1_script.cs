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

    public void baba1_meghal(string nev)
    {
        Destroy(baba);
       // baba = new GameObject();
        baba = GameObject.Find(nev);
        baba.transform.position = new Vector3(0, 0, 0);
    }

	// Use this for initialization
	void Start () {
   /*     baba = GameObject.Find("baba1");
        Destroy(baba);
        baba = GameObject.Find("baba");
        Destroy(baba);*/
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
