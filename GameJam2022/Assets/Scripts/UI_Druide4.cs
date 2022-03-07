using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Druide4: MonoBehaviour
{

    private Text messageText;
    private TextWriterDruide.TextWriterSingle textWriterSingle;
    private AudioSource talkingAudioSource;
    int i = 1;
    public HUD Hud;
  

    public void Dialogue()
    {

    }
    private void StartTalkingSound()
    {
        talkingAudioSource.Play();
    }

    private void StopTalkingSound()
    {
        talkingAudioSource.Stop();
    }

    private void Update()
    {
 
        Debug.Log("2");

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("3");
            if (textWriterSingle != null && textWriterSingle.IsActive())
            {
                textWriterSingle.WriteAllAndDestroy();
            }
            else if (i <= 4)
            {
                string[] messageArray2 = new string[4]
                {
                    "Bien le bonjour a toi etranger, je vois que tu as un style bien particulier mais je suppose que bobby a du te faire la remarque je le connais bien ",
                    " Est-ce que tu peux te rendre utile ? J'ai perdu mon baton magique et j'en ai besoin pour manger ",
                    " Je l'ai apercu vers la coline avec l'arbre dessus ",
                    " Il me semble que Jerome avait perdu son chat, regarde ca aussi s'il te plait"
                };


                string message = messageArray2[i - 1];
                StartTalkingSound();
                textWriterSingle = TextWriterDruide.AddWriter_Static(messageText, message, 0.015f, true, true, StopTalkingSound);
                i++;

            }
            else
            {
                Hud.CloseMessageDialoguePnj2();
            }

        };
    }

    void Start()
    {
        messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
        talkingAudioSource = transform.Find("talkingSound").GetComponent<AudioSource>();

      
        //TextWriterDruide.AddWriter_Static(messageText, "Ceci est un text test pour pouvoir voir comment le text rend bien sur le beau fond d'écran que j'ai fait le but est bien sur de faire un truc stylé bkabka !", 0.015f, true);
    }

    
}
