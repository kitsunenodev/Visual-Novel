using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;
using Image = UnityEngine.UI.Image;

public class MainGame : MonoBehaviour
{
    [SerializeField]
    
    public Text TextDialog;
   
    public Text TextCharacterName;
    
    public Image ImageCharacter;
    
    public DialogSequence[] Dialogs;
    
    public int _sequenceNumber;
    
    public Image ImageBackground;
    
    public ButtonManager ManagerButton;
    // Start is called before the first frame update
    void Start()
    {
        Deactivate(ManagerButton.bouton2);
        UpdateDialogSequence(Dialogs[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (_sequenceNumber + 1 == Dialogs.Length)
        {
                    Deactivate(ManagerButton.bouton1); 
                    Deactivate(ManagerButton.bouton2); 
        }
    }

    void UpdateDialogSequence(DialogSequence sequence)
    {
        TextDialog.text = sequence.TextDialog;
        TextCharacterName.text = sequence.TextNameCharactrer;
        ImageCharacter.sprite = sequence.SpriteCharacter;
        ImageBackground.sprite = sequence.BackgroundImage;

        if (sequence.ChoixMultiple)
        {
            ManagerButton.bouton1.GetComponentInChildren<Text>().text = sequence.Choix1;
            ManagerButton.bouton1.GetComponent<Image>().sprite = ManagerButton.SpriteAlt;
            ManagerButton.bouton2.SetActive(true);
            ManagerButton.bouton2.GetComponentInChildren<Text>().text = sequence.Choix2;
        }
        else
        {
            ManagerButton.bouton1.GetComponent<Image>().sprite = ManagerButton.SpriteReg;
            ManagerButton.bouton1.GetComponentInChildren<Text>().text = "suite";
            if (ManagerButton.bouton2.activeInHierarchy)
            {
                ManagerButton.bouton2.SetActive(false);
            }
        }
    }

    public void OnClickNextDialog()
    {
        _sequenceNumber+= Dialogs[_sequenceNumber].Nextdialog;
        UpdateDialogSequence(Dialogs[_sequenceNumber]);
    }
    void Deactivate(GameObject bouton)
    {
        bouton.SetActive(false);
    }

    public void OnClickChoice2()
    {
        _sequenceNumber+= Dialogs[_sequenceNumber].Nextdialog * 2;
        UpdateDialogSequence(Dialogs[_sequenceNumber]);
    }
}
