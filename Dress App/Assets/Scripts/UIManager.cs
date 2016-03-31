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
      //  try
      //  {
            string obj_name;
        string sprite_name;
            Sprite s = new Sprite();

            string fileName = Application.dataPath + "/" + "file.txt";
        Debug.Log(fileName);
            StreamReader f = new StreamReader(fileName, Encoding.Default);

            while (!f.EndOfStream)
            {
                obj_name = f.ReadLine();
                Debug.Log("obj name "+obj_name);

            //     GameObject obj=GameObject.Find(obj_name);
            //   ChangeObjectImage(obj);
            GameObject obj = new GameObject();
                sprite_name = f.ReadLine();
                Debug.Log("spirete name:"+sprite_name);

            Sprite sssss = Resources.Load(sprite_name, typeof(Sprite)) as Sprite;
            SetImage(sssss);

            Texture2D tex = Resources.Load<Texture2D>(sprite_name) as Texture2D;//nem találja?

            s = Sprite.Create(tex, new Rect(0, 0,324, 614), new Vector2(0.5f, 0.5f));

            obj.AddComponent<SpriteRenderer>();
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
            sr.sprite = s;
            /**
            
            
            // create sprite
         Texture2D tex = Resources.Load<Texture2D>("texture2") as Texture2D;
         Sprite sprite = new Sprite();
         sprite = Sprite.Create(tex, new Rect(64, 0, 64, 64), new Vector2(0.5f, 0.5f));
            
            newSprite = new GameObject();
         newSprite.AddComponent<SpriteRenderer>();
         SpriteRenderer SR = newSprite.GetComponent<SpriteRenderer>();
         SR.sprite = sprite;

            
            
            */


            //   Sprite s = Sprite.FindObjectOfType<Sprite>.name(line);
            //   string utvon = Application.dataPath + "/" + "Resources" + "/" + "dresses" + sprite_name;//   D:\posza\Posza\suli\bme\szakirany\onlab\gitlab_cucc\dressapp\Dress App\Assets\Resources\dresses
            //   Debug.Log(utvon);
            // Sprite s = Resources.Load(utvon, typeof(Sprite)) as Sprite;
            // GetComponent(SpriteRenderer).sprite = line;
            //   GameObject.Find(obj_name).GetComponent().sprite = sprites.GetSprite("Sprite1");
            //  obj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(utvon);
            //  obj.GetComponent<SpriteRenderer>()

            // s = Resources.Load<Sprite>(utvon);
            //    s = Resources.Load<Sprite>(sprite_name) as Sprite;/////////////////////////////////
            //  SetImage(s);

            /*
            *
            void Start() {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Plane);
        Renderer rend = go.GetComponent<Renderer>();
        rend.material.mainTexture = Resources.Load("glass") as Texture;

            */
            /*   Renderer r= obj.GetComponent<Renderer>();
               r.material.mainTexture = Resources.Load(sprite_name) as Texture;*/

        }

        /*  }
          catch (Exception e)
          {
              Debug.Log(e);
          }*/
    }

}
