using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public GameObject MessagePanel;
    public GameObject UI_Voyageur;
    public GameObject UI_Voyageur2;
    public GameObject UI_Voyageur3;
    public GameObject UI_Voyageur4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenMessagePanel(string text)
    {
        Debug.Log("2");
        MessagePanel.SetActive(true);
    }
    public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);

    }

    public void OpenMessageDialogue(string text)
    {
        Debug.Log("1");
        UI_Voyageur.SetActive(true);
        
    }
    public void OpenMessageDialogue2(string text)
    {
        
        UI_Voyageur2.SetActive(true);

    }
    public void CloseMessageDialogue()
    {
        Debug.Log("saleupute");
        UI_Voyageur.SetActive(false);

    }
    public void CloseMessageDialogue2()
    {
        Debug.Log("saleupute");
        UI_Voyageur2.SetActive(false);

    }
    public void OpenMessageDialoguePnj(string text)
    {

        UI_Voyageur3.SetActive(true);

    }
    public void CloseMessageDialoguePnj()
    {
        UI_Voyageur3.SetActive(false);

    }
    public void OpenMessageDialoguePnj2(string text)
    {

        UI_Voyageur4.SetActive(true);

    }
    public void CloseMessageDialoguePnj2()
    {
        UI_Voyageur4.SetActive(false);

    }
}
