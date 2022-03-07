using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Druide : MonoBehaviour
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
                string[] messageArray = new string[4]
                {
                    " La légende du peuple perdu sont différentes en fonction des régions et des croyances sur la magie des peuples. La seule information qui concorde entre tous les récits est l’existence d’un village de druide séparés et isolés du monde. Ce village se serait retrouvé en danger à la suite de l’invasion d’une terrible armée sur leurs terres poussant une ancienne magie à s’activer.",
                    " La rune en s'activant à enfermer son village dans un espace-temps infini. Les récits ne précisent pas la localisation exacte du village, ils expliquent cependant tous que le sceau empêchant la destruction de cette boucle se trouve non loin d’ici.",
                    "Je te conseil d'explorer les alentours à la recherche de signes.",
                    "Courage à toi mon pote"
                    
                };


                string message = messageArray[i - 1];
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
