using UnityEngine;
using System.Collections;

public class StickmanAnimator : MonoBehaviour {

    public Sprite[] sprites;
    public float fps;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
        fps = 10;
	}
	
	// Update is called once per frame
	void Update () {
        int t = (int)(Time.timeSinceLevelLoad * fps);
        t = t % sprites.Length;
        spriteRenderer.sprite = sprites[t];
	}

    public void setFPS (float x)
    {
        fps = x;
    }
}
