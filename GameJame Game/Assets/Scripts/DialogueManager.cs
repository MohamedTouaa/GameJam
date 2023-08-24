using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public Image Portrait;
    private Queue<string> sentences;
    public Animator animator;
    private int dialoguecounter =0;
    public DialogueTrigger[] NextDialogues;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        animator.SetBool("IsOpen", true);
        Portrait.sprite = dialogue.spritePortrait;
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSenetence();
    }

    public void DisplayNextSenetence()
    {
        if (sentences.Count == 0)
        {
            Enddialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    private IEnumerator  TypeSentence(string sentence)
    {
        descriptionText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            descriptionText.text += letter;
            yield return null;
        }


    }
    private void Enddialogue()
    {
        if (dialoguecounter < NextDialogues.Length - 1)
        {
            dialoguecounter++;
            NextDialogues[dialoguecounter].gameObject.SetActive(true);
            animator.SetBool("IsOpen", false);
        }
        else
        {
            
            StopAllCoroutines();
            SceneManager.LoadScene(2);
        }
    }
}
