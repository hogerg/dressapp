using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class color_changing_blue_button : MonoBehaviour {

   
    private Renderer rend;
    private Color32 objectColor;
    private GameObject baba;
    Color c;

    // Use this for initialization
    void Start () {
      
        rend = this.GetComponent<Renderer>();
        rend.enabled = false;
        c = this.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {

     //   this.transform.parent = baba.transform;

    
    }
 

    public void szinezes(string hex)
    {
        Color co = new Color();

        ColorUtility.TryParseHtmlString(hex, out co);
        rend.material.color = co;
    }

    public void ruha_athelyez(string b)
    {
        baba = GameObject.Find(b);
      //  this.transform.parent = baba.transform;
        this.transform.position = baba.transform.position;
    }

    public void ruha_valsztas(string b)
    {
        GameObject ruha = GameObject.Find(b);
        ruha.GetComponent<Renderer>().enabled = false;
        this.GetComponent<Renderer>().enabled = true;
        //this.transform.position = new Vector3(-2, 0, 0);
      //  this.transform.position = baba.transform.position;
    }

    public void normal_szin()
    {
        rend.material.color = c;
    }
}
