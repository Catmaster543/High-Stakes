using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Speaker : MonoBehaviour
{
    public string name;
    public Speaker speakersObject;
    public List<EmoSprite> emoSprites = new();

    public void HighLightMe()
    {
        transform.localScale = new Vector3(1,1.2f);
    }

    public void UnlightMe()
    {
        transform.localScale = Vector3.one;
    }
}
