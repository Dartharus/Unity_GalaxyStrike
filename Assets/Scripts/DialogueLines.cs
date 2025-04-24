using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] string[] timelineTextLines;
    int currentLineIndex = 0;
    public void NextDialogueLine()
    {
        currentLineIndex++;
        dialogueText.text = timelineTextLines[currentLineIndex];
    }
}
