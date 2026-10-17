using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class MisterDialogue : MonoBehaviour
{
    int i = 0;
    [Header("Scene references")]
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TextMeshProUGUI dialogueTextComponent;
    [SerializeField] private TextMeshProUGUI nameTextComponent;
    [SerializeField] private TextMeshProUGUI guideTextComponent;

    [SerializeField] private GameObject choicesObj;

    [Header("Prefab references")]
    [SerializeField] private GameObject choiceButtonPrefab;

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

    // The auto start method used on the beggining of this scene
    void StartDialogue()
    {
        index = 0;
        //StartCoroutine(TypeLine());
    }

    // The coroutine responsible for typing out text, can be interrupted
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

    // The method responsible for deciding what to do on click
    public void NextLine(bool isReply = false, Line reply = null)
    {
        guideTextComponent.text = string.Empty;

        if (!isReply)
        {
            if (lines[index].type == Line.Type.Line)
            {
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
            else
            {
                dialogBox.SetActive(false);

                int yPos = 540;
                foreach (Choice choice in lines[index].choices)
                {
                    Vector3 resultPos = new Vector3(960, yPos);
                    GameObject instButton = Instantiate(choiceButtonPrefab, resultPos, Quaternion.identity);

                    instButton.GetComponent<Button>().transform.SetParent(choicesObj.transform, false);
                    instButton.transform.position = resultPos;
                    instButton.GetComponent<Button>().onClick.AddListener( () => ChoiceSelected(choice));
                    instButton.GetComponentInChildren<TextMeshProUGUI>().text = choice.name;

                    yPos -= 50;
                }
            }
        }
        else
        {
            dialogBox.SetActive(true);

        }
    }

    // The coroutine responsible for typing out the guide text after a while, but really is just half-working, no idea why the hell it does not still work
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

    public void ChoiceSelected(Choice choice)
    {
        NextLine(true, choice.reply);
    }
}

[System.Serializable]
public class Line
{
    [Header("General settings")]
    public Type type;

    [Header("Line type settings")]
    public string text;
    public Speaker activeSpeaker;
    public float textSpeed = 0.05f;

    [Header("Choice type settings")]
    public List<Choice> choices = new();

    public enum Type
    {
        Line,
        Choices
    }
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

[System.Serializable]
public class Choice
{
    public string name;
    public Line reply;
    public bool isBad;
}