using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MailButton : MonoBehaviour
{
    public TMP_Text messageSubjectUI;
    public TMP_Text messageTextUI;


    //todo change these names

    public string subjectText;
    public string messageText;

    Button thisButton;

    // Start is called before the first frame update
    void Start()
    {   
        thisButton = GetComponent<Button>();
        AddOnClickButton(thisButton, subjectText, messageText);
    }
    
    public void AddOnClickButton(Button button, string subject, string message){
        button.onClick.AddListener(() => {ChangeUICanvasText(subject, message); });
    }

    //this should be called by some event trigger, win pee scene, etc.
    public void ChangeUICanvasText(string subject, string message){
        messageSubjectUI.text = subjectText;
        messageTextUI.text = messageText;
    }
}
