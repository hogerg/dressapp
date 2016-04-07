using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using System.IO; 

public class UIManager : MonoBehaviour {

    private Color32 objectColor;
    private Sprite objectImage;

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


    public void ChangeObjectImage(GameObject obj)//Ez a objet, aminek a képét megváltoztatod
    {
        Image im = GameObject.Find(obj.name).GetComponent<Image>();
        im.sprite = objectImage;

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
    /*
        public void gomb_filebol()
        {
        /*    Vector2 scrollPosition;
            string log;
            float scaleX, scaleY, btOffsetX, btOffsetY, btWidth, btHeight;
            scaleX = Screen.width / 1280f;
            scaleY = Screen.height / 720f;
            btOffsetX = 950;
            btOffsetY = 620;
            btWidth = 300;
            btHeight = 50;

            if (GUI.Button(new Rect(btOffsetX * scaleX, btOffsetY * scaleY, btWidth * scaleX, btHeight * scaleY), "Clear log"))
            {
                log = "Debug Console Output \n ------------------------------ \n";
            }*/

    ///     //Button b = UnityEngine.Resources.Load<Button>("UI/Button");//b miért null
    // Button ib = (Button)UnityEngine.Object.Instantiate(b);
    /*     GameObject panelObject = GameObject.Find("image_also");
         float h = 10.0f;
         float w = 10.0f;
         float y = 0.0f;
         float x = 0.0f;

         GameObject buttonObject = new GameObject("Button");
         buttonObject.transform.SetParent(panelObject.transform);
         buttonObject.layer = 6;


          RectTransform trans = buttonObject.AddComponent<RectTransform>();
          SetSize(trans, new Vector2(w, h));
  /* trans.anchoredPosition3D = new Vector3(0, 0, 0);
   trans.anchoredPosition = new Vector2(x, y);
   trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
   trans.localPosition.Set(0, 0, 0);
   buttonObject.AddComponent<CanvasRenderer>();*/
    //
    /*   float f = float.Parse("-0.75");
       buttonObject.transform.position = new Vector3(1,f,0);
       buttonObject.transform.position = panelObject.transform.position;     


       Image image = buttonObject.AddComponent<Image>();
       Texture2D tex = Resources.Load<Texture2D>("bj");
       image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));

       Button button = buttonObject.AddComponent<Button>();
 /////     button.interactable = true;
 //button.onClick.AddListener(eventListner);

 /**
  1 GameObject buttonObject = new GameObject("Button");
2 buttonObject.transform.SetParent(panelObject.transform);
3 buttonObject.layer = LayerUI;


Now lets create the RectTransform and position our button accordingly.

1 RectTransform trans = buttonObject.AddComponent<RectTransform>();
2 SetSize(trans, new Vector2(w, h));
3 trans.anchoredPosition3D = new Vector3(0, 0, 0);
4 trans.anchoredPosition = new Vector2(x, y);
5 trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
6 trans.localPosition.Set(0, 0, 0);
7 
8 buttonObject.AddComponent<CanvasRenderer>();

Setting background image for button will be similar to that of panel's. The png file button_bkg.png should be at Assets\Resources as before.

1 Image image = buttonObject.AddComponent<Image>();
2 Texture2D tex = Resources.Load<Texture2D>("button_bkg");
3 image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));

Creating the actual button, eventListner is of type UnityAction.

1 Button button = buttonObject.AddComponent<Button>();
2 button.interactable = true;
3 button.onClick.AddListener(eventListner);
 */


    /**
    *
     GameObject newButton = Instantiate(button) as GameObject;
    newButton.transform.SetParent(newCanvas.transform, false);


    Button buttonPrefab = UnityEngine.Resources.Load<Button>("UI/Button");
     Button instance = (Button)UnityEngine.Object.Instantiate(buttonPrefab);

    button.AddComponent<Image>();
    button.transform.parent = canvas.transform;

    */

    /*   }
       private static void SetSize(RectTransform trans, Vector2 size)
       {
           Vector2 currSize = trans.rect.size;
           Vector2 sizeDiff = size - currSize;
           trans.offsetMin = trans.offsetMin -
                                     new Vector2(sizeDiff.x * trans.pivot.x,
                                         sizeDiff.y * trans.pivot.y);
           trans.offsetMax = trans.offsetMax +
                                     new Vector2(sizeDiff.x * (1.0f - trans.pivot.x),
                                         sizeDiff.y * (1.0f - trans.pivot.y));
       }*/
    /* void OnGUI()
     {
         string log;
         float scaleX, scaleY, btOffsetX, btOffsetY, btWidth, btHeight;

         scaleX = Screen.width / 1280f;
         scaleY = Screen.height / 720f;
         btOffsetX = 950;
         btOffsetY = 620;
         btWidth = 300;
         btHeight = 50;

         GUI.BeginGroup(new Rect(scaleX * 10, scaleY * 10, scaleX * 1200, scaleY * 600));
       //  scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(scaleX * 1180), GUILayout.Height(scaleY * 580));
    //     GUILayout.Label(log);
         GUILayout.EndScrollView();
         GUI.EndGroup();

         if (GUI.Button(new Rect(btOffsetX * scaleX, btOffsetY * scaleY, btWidth * scaleX, btHeight * scaleY), "Clear log"))
         {
             log = "Debug Console Output \n ------------------------------ \n";
         }
     }*/

  /*  void OnGUI()
    {
        //Here if the player hit the button Start will trigger an action
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Start Game!"))
        {
            //Here we call the method who will call the level named "LevelName"
         //   Application.LoadLevel("LevelName");
        }

    }*/
}
