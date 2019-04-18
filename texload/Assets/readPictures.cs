using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class readPictures : MonoBehaviour
{
    private Image image;
    public Text text;

    private string picpathWWW = "1.jpg"; //WWW的加载方式路径
    private string url = "http://192.168.43.1/tex/";
    private int idx = 1;
    public int length = 8;

    // Use this for initialization
    private void Start()
    {
        image = GetComponent<Image>();
        LoadByWWW();
    }


    public void UpPage() {
        idx -= 1;
        if (idx < 1)
        {
            idx = 1;
        }
        DestroyImmediate(image.mainTexture);
        picpathWWW = idx + ".jpg";
        LoadByWWW();
    }

    public void NextPage()
    {
        idx += 1;
        if (idx > length)
        {
            idx = length;
        }
        DestroyImmediate(image.mainTexture);
        picpathWWW = idx + ".jpg";
        LoadByWWW();
        text.text = idx + "/" + length;
    }


    private void LoadByWWW()
    {
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        WWW www = new WWW(url + picpathWWW);//只能放URL
                                            //        WWW www = new WWW(url);//只能放URL 这里可以换做网络的URL
        yield return www;
        if (www != null && string.IsNullOrEmpty(www.error))
        {
            Texture2D texture = www.texture;
            //创建 Sprite
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

            image.sprite = sprite;
        }
    }


}