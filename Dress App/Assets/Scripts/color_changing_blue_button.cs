using UnityEngine;
using System.Collections;

public class color_changing_blue_button : MonoBehaviour {

    private GameObject mit ;
    private GameObject gomb1;
    private GameObject gomb2;
    private Color kek = Color.blue;
    private Color piros = Color.red;
    private Renderer rend;

    // Use this for initialization
    void Start () {
        mit = GameObject.Find("a_square");
        gomb1 = GameObject.Find("Button_Blue");
        gomb2 = GameObject.Find("Button_Red");
        rend = mit.GetComponent<Renderer>();

      /*  string shaderText =
            "Shader \"Alpha Additive\" {" +
         //   "Properties { _Color (\"Main Color\", Color) = (1,0,1,1) }" +
            "SubShader {" +
          //  "    Tags { \"Queue\" = \"Transparent\" }" +
            "    Pass {" +
          //  "        Blend One One ZWrite Off ColorMask RGB" +
            "        Material { Diffuse [_Color] Ambient [_Color] }" +
          //  "        Lighting On" +
            "        SetTexture [_Dummy] { combine primary double, primary }" +
            "    }" +
            "}" +
            "}";*/
       // rend.material = new Material(shaderText);

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
        //transform.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);//

        if (gomb1.active)
            // mit.GetComponent<Renderer>().material.color = Color.blue;
            // mit.GetComponent<Renderer>().material.SetColor(0, Color.blue);
            rend.material.color = kek;
        else if (gomb2.active)
            // mit.GetComponent<Renderer>().material.color = Color.red;//it miafaszért nem vált ált???? miért változik a close is???? hogy lehet új materialt csináéni?
            //mit.GetComponent<Renderer>().material.SetColor(1, Color.red);
            rend.material.color = piros;
        else { }
        //transform.renderer.material.color = Color.red;
    }


    }
