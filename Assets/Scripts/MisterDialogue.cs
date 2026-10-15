using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class MisterDialogue : MonoBehaviour
{
    int i = 0;
    [Header("Scene references")]
    [SerializeField] private TextMeshProUGUI dialogueTextComponent;
    [SerializeField] private TextMeshProUGUI nameTextComponent;
    [SerializeField] private TextMeshProUGUI guideTextComponent;

    [Header("General")]
    public List<Speaker> characters = new();

    [Header("Dialogue")]
    public Line[] lines;
    private float textSpeed = 0.05f;

    [Header("Extra settings")]
    public string guideText;

    [Header("Debug (if turned on)")]
    private int index;
    private bool isTyping;

    void Start()
    {
        dialogueTextComponent.text = string.Empty;
        guideTextComponent.text = string.Empty;
        StartDialogue();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            NextLine();
        }
    }

    void StartDialogue()
    {
        index = -1;
        //StartCoroutine(TypeLine());
    }

    System.Collections.IEnumerator TypeLine()
    {
        isTyping = true;
        if (lines[index].activeSpeaker != null)
        {
            nameTextComponent.text = lines[index].activeSpeaker.name;
            lines[index].activeSpeaker.HighLightMe();
        }
        else
        {
            nameTextComponent.text = string.Empty;
        }

        dialogueTextComponent.text = string.Empty;

        foreach (char c in lines[index].text.ToCharArray())
        {
            dialogueTextComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        if (lines[index].activeSpeaker != null)
        {
            lines[index].activeSpeaker.UnlightMe();
        }

        i++;
        isTyping = false;

        StartCoroutine(TypeGuideLine());
    }
    public void NextLine()
    {
        guideTextComponent.text = string.Empty;

        if (isTyping)
        {
            dialogueTextComponent.text = lines[index].text;
            isTyping = false;
            StopAllCoroutines();
            StartCoroutine(TypeGuideLine());
            i++;
        }
        else
        {
            StopCoroutine(TypeGuideLine());
            guideTextComponent.text = string.Empty;
            if (index < lines.Length - 1)
            {
                index++;
                dialogueTextComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                dialogueTextComponent.text = string.Empty;
            }
        }
    }

    System.Collections.IEnumerator TypeGuideLine()
    {
        guideTextComponent.text = string.Empty;
        yield return new WaitForSeconds(2);

        foreach (char c in guideText.ToCharArray())
        {
            guideTextComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}

[System.Serializable]
public class Line
{
    public string text;
    public Speaker activeSpeaker;
    public float textSpeed = 0.05f;
}

[System.Serializable]
public class EmoSprite
{
    public string spriteName;
    public Sprite sprite;
    public Emotion emotion;
    public enum Emotion
    {
        None,
        Glad,
        Normal,
        Confused,
        Angry,
        Sad,
        Dissappointed,
        Scared,
        Shocked
    }
}