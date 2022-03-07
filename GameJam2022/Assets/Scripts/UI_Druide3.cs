using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Druide3 : MonoBehaviour
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
                    "Bien le bonjour jeune homme, je n'ai jamais vu un tel acoutrement. Mais bref les jeunes de nos jours",
                    "Peux-tu m'aider à retrouver mon petit chaton perdu. Je n'arrive pas à le retrouver, j'ai vraiment besoin d'aide",
                    " Il me semble que je l'ai apercu proche du lac mais je ne suis pas sur ",
                    " Retrouve le vite, tu devrais parler à Jerome il me semble que lui aussi a besoin d'aide, merci d'avance"
                };


                string message = messageArray2[i - 1];
                StartTalkingSound();
                textWriterSingle = TextWriterDruide.AddWriter_Static(messageText, message, 0.015f, true, true, StopTalkingSound);
                i++;

            }
            else
            {
                Hud.CloseMessageDialoguePnj();
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
