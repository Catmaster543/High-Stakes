using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Speaker : MonoBehaviour
{
    public string name;
    public Speaker speakersObject;
    public Sprite quietSprite;
    public Sprite talkSprite;
    public List<EmoSprite> emoSprites = new();

    public void HighLightMe()
    {
        if (talkSprite != null)
        {
            gameObject.GetComponent<Image>().sprite = talkSprite;
        }
        transform.localScale = new Vector3(1.1f,1.1f);
    }

    public void UnlightMe()
    {
        if (quietSprite != null)
        {
            gameObject.GetComponent<Image>().sprite = quietSprite;
        }
        transform.localScale = Vector3.one;
    }
}
