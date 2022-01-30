using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public Dialog_1_handler diaglogEndHandler;
    private Queue<string> Sentences;
    private bool DialogOpen = false;

    public PlayerMovement player;
    
    void Start()
    {
        Sentences = new Queue<string>();   
    }
    public void StartDialogue(Dialogue dialogue)
    {
        DialogOpen = true;
        animator.SetBool("IsOpen", true);
        player.SetMovementDisabled(true);

        nameText.text = dialogue.Name;

        Sentences.Clear();
        foreach (string sentence in dialogue.Sentences)
        {
            Sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (!DialogOpen) return;
        if (Sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = Sentences.Dequeue();
        dialogueText.text = sentence;
    }
    void EndDialogue()
    {
        DialogOpen = false;
        diaglogEndHandler.EndDialog();
        animator.SetBool("IsOpen", false);
        player.SetMovementDisabled(false);
    }
}
