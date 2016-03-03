using UnityEngine;
using System.Collections;

public class color_changing_blue_button : MonoBehaviour {
   
    
	// Use this for initialization
	void Start () {
       
       
    }

    // Update is called once per frame
    void Update()
    {

     /*   if (Input.GetButton("Fire1"))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            /*   Renderer rend = GetComponent<Renderer>();
          rend.material.shader = Shader.Find("Specular");
          rend.material.SetColor("_SpecColor", Color.red);*/
        //}
    }
    public void valami()
    {
        //gameObject.GetComponent<Renderer>().material.color = Color.blue;
        //gameObject.renderer.material.SetColor("-);
        //Renderer rend = GetComponent<Renderer>();
        //gameObject.rend.material.color = new Color(0, 1, 0,0);
        // gameObject.GetComponent<Renderer>().material.SetColor(0, Color.blue);//
        //transform.GetComponent<Renderer>().material.color = Color.blue;//
        transform.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);//
        //transform.renderer.material.color = Color.red;
    }
    
}
