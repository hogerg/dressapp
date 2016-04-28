using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using System.IO; 

public class UIManager : MonoBehaviour {

    private Color32 objectColor;
    private Sprite objectImage;
    private Sprite[] ruhak;
    private Sprite[] felsok;
    private Sprite[] dzsekik;
    private Sprite[] alsok=new Sprite[10];
    private Sprite[] cipok;
    private Sprite[] babak;
    private GameObject b;
    private int n;
   
    /*  public GameObject b;
      public Transform buttoncontainer;
      public Sprite ssprite;*/

    public void DisableBool(Animator anim)
    {
        anim.SetBool("isDisplayed", false);
    }

    public void EnableBool(Animator anim)
    {
        anim.SetBool("isDisplayed", true);
    }

    public void NegateBool(Animator anim)
    {
        anim.SetBool("isDisplayed", !anim.GetBool("isDisplayed"));
    }

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

    public void none(Sprite s)
    {
        objectImage= s;
    }

    public void SetImage(Sprite im)//ez meg a kép amire megváltoztatod.
    {
        objectImage = im;
    }


    public void ChangeObjectImage(GameObject obj)//Ez a objekt, aminek a képét megváltoztatod
    {
        Image im = GameObject.Find(obj.name).GetComponent<Image>();
        im.sprite = objectImage;

    }

    void Start()
    {
        // gomb_filebol();
        b = GameObject.Find("sampleButton");
        ultimateDynamicAruFeltoltes();
    }

    public void ultimateDynamicAruFeltoltes()
    {
        //kell 7 file, azokbol kiolvasunk a 7 tombbe lehet kulon ciklus kene ra param(tomb, string)
        fileReading(alsok,"alsok.txt", "alsok/");//teszteljunk 1 tombbel
        
        //utana meg letre kell hozni a gombokat 7 for erre is lehet kulon eljaras param(tomb,panel name)->talan azt a 3 valtozot globalisnak kene
        
        //Sprite[] sps = Resources.LoadAll<Sprite>("alsok");
        buttonCreating(alsok, "a_Panel", "image_also");//ez a 2 sor létrehozza a tömböt spriteostul és fel bassza őket a panelra, meg scriptet rendel a buttonokhoz.
        //ebből a 2ből kell 7 db + a babákhoz más script kell.
        //rendezni kell a projektben a ruhakat, hogy konnyű legyen beolvasni
        //meg kell nézni, hogy Hodány részét hogyan lehet hozzá építeni. esetleg lehet-e olyan függvényt hozzá adni ami másik scriptbe van
    }

    private void buttonCreating(Sprite[] sprites, string panelName, string imageName)//annak a panelnak a neve, ahova akarjuk tenni
    {
        GameObject container = GameObject.Find(panelName);
        Transform buttoncontainer = container.transform;

        //oszlopba rendezosdi
        RectTransform rowRectTransform = b.GetComponent<RectTransform>();
        RectTransform containerRectTransform = container.GetComponent<RectTransform>();
        int oszlopszam = 1;

        float width = containerRectTransform.rect.width / oszlopszam;
        float ratio = width / rowRectTransform.rect.width;
        float height = rowRectTransform.rect.height * ratio;
        int rowCount = n / oszlopszam;
        if (n % rowCount > 0)
            rowCount++;

        float scrollHeight = height * rowCount;
        containerRectTransform.offsetMin = new Vector2(containerRectTransform.offsetMin.x, -scrollHeight / 2);
        containerRectTransform.offsetMax = new Vector2(containerRectTransform.offsetMax.x, scrollHeight / 2);
        //

        int i = 0;
        int j = 0;
       // foreach(Sprite s in sprites)
       while (i<n)
        {
            //oszlopbarendez

            if (i % oszlopszam == 0)
                j++;

            //

            // Texture textu = Resources.Load<Texture>("bj");
            GameObject go = Instantiate(b) as GameObject;
            go.transform.SetParent(buttoncontainer);

            //  go.GetComponent<RawImage>().texture = textu;
            Sprite tmp = (Sprite)(sprites[i]);
            //SetImage(tmp);

         //   ChangeObjectImage(go);

            //Image im = GameObject.Find(go.name).GetComponent<Image>();
           // im.sprite = tmp;
            go.GetComponent<Image>().sprite = tmp;


            // GameObject baba = GameObject.Find("baba1");
            go.transform.position = buttoncontainer.transform.position;
            Debug.Log(i.ToString());
          //  Debug.Log(tmp.name);

            go.GetComponent<Button>().onClick.AddListener(()=> on(imageName,tmp));
            /*     GameObject p = (GameObject.Find("Player"));

                 go.GetComponent<Button>().onClick.AddListener(() => p.setJacket(1));*/
           GameObject p = (GameObject)Resources.Load("player", typeof(GameObject));

            switch (imageName)
            {
                case ("image_also"):
                    {
                        go.GetComponent<Button>().onClick.AddListener(() => p.GetComponent<PlayerController>().setPants(1));
                        go.GetComponent<Button>().onClick.AddListener(() => p.GetComponent<PlayerController>().setDress(0));
                    }
                    break;
                case ("image_cipo"):
                    {
                        go.GetComponent<Button>().onClick.AddListener(() => p.GetComponent<PlayerController>().setShoes(1));
                    }
                    break;
                case ("image_dzseki"):
                    {
                        go.GetComponent<Button>().onClick.AddListener(() => p.GetComponent<PlayerController>().setJacket(1));
                    }
                    break;
                case ("image_felso"):
                    {
                        go.GetComponent<Button>().onClick.AddListener(() => p.GetComponent<PlayerController>().setTop(1));
                        go.GetComponent<Button>().onClick.AddListener(() => p.GetComponent<PlayerController>().setDress(0));
                    }
                    break;
                case ("image_dress"):
                    {
                        go.GetComponent<Button>().onClick.AddListener(() => p.GetComponent<PlayerController>().setPants(0));
                        go.GetComponent<Button>().onClick.AddListener(() => p.GetComponent<PlayerController>().setDress(1));
                        go.GetComponent<Button>().onClick.AddListener(() => p.GetComponent<PlayerController>().setTop(0));
                    }
                    break;
                /*case ("image_baba"):
                    {
                        go.GetComponent<Button>().onClick.AddListener(() => p.GetComponent<PlayerController>().setPants(1));
                        go.GetComponent<Button>().onClick.AddListener(() => p.GetComponent<PlayerController>().setDress(0));
                    }
                    break;*/
            }

            //oszlop cucc

            go.transform.parent = container.transform;

            //move and size the new item
            RectTransform rectTransform = go.GetComponent<RectTransform>();

            float x = -containerRectTransform.rect.width / 2 + width * (i % oszlopszam);
            float y = containerRectTransform.rect.height / 2 - height * j;
            rectTransform.offsetMin = new Vector2(x, y);

            x = rectTransform.offsetMin.x + width;
            y = rectTransform.offsetMin.y + height;
            rectTransform.offsetMax = new Vector2(x, y);

            //
            i++;
        }
       
    }

   private void on(string s, Sprite spr)
    {
        GameObject tmp = GameObject.Find(s);
        tmp.GetComponent<Image>().sprite = spr;
    } 

    //itt a filename->valami.txt utvonal nelkul
    private void fileReading(Sprite [] sprites, string filename, string sprite_place)
    {
        
        string sprite_name = "";

        //  Sprite s = new Sprite();
        GameObject obj = new GameObject();
        n = 0;

        string fileName = Application.dataPath + "/" + filename;
        Debug.Log(fileName);
        StreamReader f = new StreamReader(fileName, Encoding.Default);

        int i = 0;
        //filebol beolvas
        while (!f.EndOfStream)
        {

            string tmp = f.ReadLine();
            //melyik kepre bj(farmer cucc)
            
            sprite_name = sprite_place + tmp;
            
            //sprite_name = tmp;
            Debug.Log("spirte name:" + sprite_name);
            Debug.Log(i.ToString());

            //oke, na most beolvastuk a file-t es benne van a megadott tomben(kategoriak)
            sprites[i] = Resources.Load(sprite_name, typeof(Sprite)) as Sprite;

            n++;
            i++;
        }
        f.Close();
    }

    public void filebol_olvasas()
    {

        string obj_name="";
        string sprite_name="";
        Sprite s = new Sprite();
        GameObject obj = new GameObject();
        

        string fileName = Application.dataPath + "/" + "file.txt";
        Debug.Log(fileName);
        StreamReader f = new StreamReader(fileName, Encoding.Default);

        //filebol beolvas
        while (!f.EndOfStream)
        {
            //melyik objektumnak a spritejat fogjuk valtoztatni also_image vagy ilyesmi
            obj_name = f.ReadLine();
            Debug.Log("obj name " + obj_name);

           
            //melyik kepre bj(farmer cucc)
            sprite_name = f.ReadLine();
            Debug.Log("spirete name:" + sprite_name);
            
        }

        //megkeresi a filebol kiolvasott nevu spriteot, beallitja azt
        obj=GameObject.Find(obj_name);
        s = Resources.Load(sprite_name, typeof(Sprite)) as Sprite; 
        SetImage(s);

         //filebol kiolvasott objektum kepoet atallitja
      ChangeObjectImage(obj);
        //////////////////////////////////////////////////////////////gombon a képet megváltoztatja
       GameObject gobj = GameObject.Find("also_gomb");

        ChangeObjectImage(gobj);
        //////////////////////////////////////////////////////////////
        f.Close();
    }


    public void gomb_filebol()
    {

        GameObject b = GameObject.Find("also_gomb (1)") ;
        GameObject container = GameObject.Find("a_Panel");
        Transform buttoncontainer= container.transform;
        Sprite ssprite= Resources.Load("bj", typeof(Sprite)) as Sprite;

        // Texture textu = Resources.Load<Texture>("bj");
        GameObject go = Instantiate(b) as GameObject;
        go.transform.SetParent(buttoncontainer);
        //  go.GetComponent<RawImage>().texture = textu;
        SetImage(ssprite);
        ChangeObjectImage(go);
        // GameObject baba = GameObject.Find("baba1");
        go.transform.position = buttoncontainer.transform.position;

    }

    void OnApplicationQuit()
    {

        //save();

    }

    private void save()
    {
        string FILE_NAME = "save.txt";

        string si1 = "image_cipo";
        GameObject go1 = GameObject.Find(si1);
        string ss1 = go1.GetComponent<Image>().sprite.name;//valamiért nem találja a spritetot, pedig van

        string si2 = "image_also";
        GameObject go2 = GameObject.Find(si2);
        string ss2 = go2.GetComponent<Sprite>().name;

        string si3 = "image_dzseki";
        GameObject go3 = GameObject.Find(si3);
        string ss3 = go3.GetComponent<Sprite>().name;

        string si4 = "image_cipo";
        GameObject go4 = GameObject.Find(si4);
        string ss4 = go4.GetComponent<Sprite>().name;

        string si5 = "image_felso";
        GameObject go5 = GameObject.Find(si5);
        string ss5 = go5.GetComponent<Sprite>().name;

        string si6 = "image_dress";
        GameObject go6 = GameObject.Find(si6);
        string ss6 = go6.GetComponent<Sprite>().name;

        //a baba még nem így van megírva TODO
        /*   string si7 = "image_baba";
           GameObject go7 = GameObject.Find(si7);
           string ss7 = go7.GetComponent<Sprite>().name;*/

        using (StreamWriter sw = File.CreateText(FILE_NAME))
        {

            sw.WriteLine(si1);
            sw.WriteLine(ss1);

            sw.WriteLine(si2);
            sw.WriteLine(ss2);

            sw.WriteLine(si3);
            sw.WriteLine(ss3);

            sw.WriteLine(si4);
            sw.WriteLine(ss4);

            sw.WriteLine(si5);
            sw.WriteLine(ss5);

            sw.WriteLine(si6);
            sw.WriteLine(ss6);

            /*     sw.WriteLine(si7);
                 sw.WriteLine(ss7);*/

            sw.Close();
        }
        //}
    }
}
