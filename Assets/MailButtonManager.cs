using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MailButtonManager : MonoBehaviour
{

    public TMP_Text messageSubjectUI;
    public TMP_Text messageTextUI;
    private Button myButton;

    public string subjectText = "URGENT CFBI";
    public string messageText = "HEY AGENT BAO, GREAT WORK WITH PEEING ON THOSE NASTY FLOWERS. THE CFBI FOUND THESE KEYS THAT MAY HAVE SOME RELEVANCE FOR YOU. KEEP UP THE GOOD WORK. -JP";

    // Start is called before the first frame update
    void Start()
    {   
        myButton = GetComponent<Button>();
    }

    public void AddOnClickButton(Button button, string subject, string message){
        button.onClick.AddListener(() => {ChangeUICanvasText(subject, message); });
    }

    //this should be called by some event trigger, win pee scene, etc.
    public void ChangeUICanvasText(string subject, string message){
        Debug.Log(myButton);
        messageSubjectUI.text = subjectText;
        messageTextUI.text = messageText;
    }

    // Update is called once per frame
    void Update()
    {
        //debug purposes, press some key and generate button -> add onlcick to that button
        //instantiate button at location
        GameObject newButton = DefaultControls.CreateButton( new DefaultControls.Resources() );
        // Button buttonComponent = newButton.

        var b = Instantiate(newButton, this.transform.position, transform.rotation);
        AddOnClickButton(myButton, subjectText, messageText); //TODO: change this to newbutton
    }
}
