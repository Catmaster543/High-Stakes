using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class MisterDialogue : MonoBehaviour
{   
    int i = 0;
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI guideTextComponent;
    public string guideText;
    public string[] lines;
    private float textSpeed = 0.05f;
    private int index;
    private bool isTyping;

    void Start()
    {
        textComponent.text = string.Empty;
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
        index = 0;
        //StartCoroutine(TypeLine());
    }

    System.Collections.IEnumerator TypeLine()
    {
        isTyping = true;
        textComponent.text = string.Empty;

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
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
            textComponent.text = lines[index];
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
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                textComponent.text = string.Empty;
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
