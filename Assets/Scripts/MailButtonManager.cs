using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MailButtonManager : MonoBehaviour
{

    public TMP_Text messageSubjectUI;
    public TMP_Text messageTextUI;


    //todo change these names
    public GameObject buttonPrefab1;
    public GameObject buttonPrefab2;

    public GameObject buttonParent;

    public Vector3 buttonSpawnPosition;

    public string subjectText;
    public string messageText;

    // Start is called before the first frame update
    void Start()
    {   
        // myButton = GetComponent<Button>();
        buttonSpawnPosition = transform.position;
        buttonSpawnPosition.y = 350;
        buttonSpawnPosition.x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)){

            FinishedPottyGameMail();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            FinishedSniperGameMail();
        }

    }

    public void FinishedSniperGameMail()
    {
        subjectText = "SUBJECT2";
        messageText = "MESSAGE2";
        //debug purposes, press some key and generate button -> add onlcick to that button
        //instantiate button at location
        // GameObject newButton = DefaultControls.CreateButton( new DefaultControls.Resources() );
        // Button buttonComponent = newButton.
        var b = Instantiate(buttonPrefab2, buttonSpawnPosition, buttonParent.transform.rotation);
        buttonSpawnPosition.y -= 100;
        b.transform.SetParent(buttonParent.transform, false); //setparent false for worldPositionStays
        Button myButton = b.GetComponent<Button>();

        AddOnClickButton(myButton, subjectText, messageText); //TODO: change this to newbutton
    }

    public void FinishedPottyGameMail(){
        subjectText = "SUBJECT1";
        messageText = "MESSAGE1";

        var b = Instantiate(buttonPrefab1, buttonSpawnPosition, buttonParent.transform.rotation);
        buttonSpawnPosition.y -= 100;
        b.transform.SetParent(buttonParent.transform, false);
        Button myButton = b.GetComponent<Button>();

        AddOnClickButton(myButton, subjectText, messageText);
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
