using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Druide2 : MonoBehaviour
{

    private Text messageText;
    private TextWriterDruide.TextWriterSingle textWriterSingle;
    private AudioSource talkingAudioSource;
    int i = 1;
  

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
                string[] messageArray2 = new string[5]
                {
                    "Tu vas bien !!!!!",
                    " Je crois que tu as active la rune infinie sans faire expres. J'ai bien peur que nous soyons bloque",
                    " Comme je t'explique avant, il y aurait un village dans cette dimension, les textes les plus ancients nous raconte que les villageois ne semblent pas etre au courant",
                    " Grace au texte que j'ai trouve plus tot dans la journée, il raconte que les villageois auraient des quetes et des demandes pour nous, si nous les accomplissont nous pourrons les sortir de cette boucle",
                    " Cependant, prends garde, d'apres mes recherche le temps semblent s'ecouler differement. En effet il semble boucler toutes les minutes à l'infini  "
                };


                string message = messageArray2[i - 1];
                StartTalkingSound();
                textWriterSingle = TextWriterDruide.AddWriter_Static(messageText, message, 0.015f, true, true, StopTalkingSound);
                i++;

            }
            else
            {
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
