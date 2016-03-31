using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class dress_image : MonoBehaviour {
    Renderer rend;
    Color kezdoszin;
    private Sprite objectImage;


    // Use this for initialization
    void Start () {
        rend = this.GetComponent<Renderer>();
        GameObject baba = GameObject.Find("baba1");
        this.transform.position = baba.transform.position;
        //c = rend.material.color;
        kezdoszin = this.GetComponent<Image>().color; //////////////////////majd ha megy a filebol akko tedd vissza
      
    }

    public void ResetColor()
    {
        this.GetComponent<Image>().color = kezdoszin;
    }

    /*
     public void RecolorObject(GameObject obj)
    {
        Image im = GameObject.Find(obj.name).GetComponent<Image>();
        im.color = objectColor;
    }

    public void SetObjectColor(string hex)
    {
        Color c = new Color();
        ColorUtility.TryParseHtmlString(hex, out c);
        objectColor = c;
        print(c.ToString());
    }
    */



    public void ruha_athelyez(string b)
    {
        GameObject baba = GameObject.Find(b);
        //  this.transform.parent = baba.transform;
        this.transform.position = baba.transform.position;
    }

    // Update is called once per frame
    void Update () {
	
	}


    /*public void szinezes(string hex)
    {
        Color co = new Color();

        ColorUtility.TryParseHtmlString(hex, out co);
        this.gameObject.
        //rend.material.color = co;
    }

    public void normal_szin()
    {
        rend.material.color = c;
    }

    /*
    public void SetImage(Sprite im)//ez meg a kép amire megváltoztatod.
    {
        objectImage = im;
    }

    public void ChangeObjectImage(GameObject obj)//Ez a objet, aminek a képét megváltoztatod
    {
        Image im = GameObject.Find(obj.name).GetComponent<Image>();
        im.sprite = objectImage;
    }
    */
}
