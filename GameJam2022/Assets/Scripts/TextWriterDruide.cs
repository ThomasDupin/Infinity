using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriterDruide : MonoBehaviour
{
    private static TextWriterDruide instance;
   private List<TextWriterSingle> textWriterSingleList;

   private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }

   public static TextWriterSingle AddWriter_Static(Text uiText, string TextToWrite, float timePerCharacter, bool invisibleCharacters, bool removeWriterBeforeAdd, Action onComplete)
    {
        if (removeWriterBeforeAdd)
        {
            instance.RemoveWriter(uiText);
        }
        return instance.AddWriter(uiText, TextToWrite, timePerCharacter, invisibleCharacters, onComplete);
    }
   private TextWriterSingle AddWriter(Text uiText, string TextToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
    {
        TextWriterSingle textWriterSingle = new TextWriterSingle(uiText, TextToWrite, timePerCharacter, invisibleCharacters, onComplete);
        textWriterSingleList.Add(textWriterSingle);
        return textWriterSingle;
    }

    public static void RemoveWriter_Static(Text uiText)
    {
        instance.RemoveWriter(uiText);
    }

    private void RemoveWriter(Text uiText)
    {
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            if (textWriterSingleList[i].GetUIText() == uiText)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    private void Update()
    {
        //Debug.log(textWriterSingleList.Count);
        for(int i = 0; i < textWriterSingleList.Count; i++)
        {
            bool destroyInstance = textWriterSingleList[i].Update();
            if (destroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }

    }

    /* Represent a single TextWriter Instance*/

    public class TextWriterSingle
    {
        private Text uiText;
        private string TextToWrite;
        private int characterIndex;
        private bool invisibleCharacters;
        private float timePerCharacter;
        private float timer;
        private Action onComplete;

        public TextWriterSingle(Text uiText, string TextToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
        {
            this.uiText = uiText;
            this.TextToWrite = TextToWrite;
            this.timePerCharacter = timePerCharacter;
            this.invisibleCharacters = invisibleCharacters;
            characterIndex = 0;
            this.onComplete = onComplete;
        }

        public bool Update()
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                timer += timePerCharacter;
                characterIndex++;
                string text = TextToWrite.Substring(0, characterIndex);
                if (invisibleCharacters)
                {
                    text += "<color=#00000000>" + TextToWrite.Substring(characterIndex) + "</color>";
                }
                uiText.text = text;

                if (characterIndex >= TextToWrite.Length)
                {
                    if (onComplete != null) onComplete();
                    return true;
                }

            }

            return false;
        }

        public Text GetUIText()
        {
            return uiText;
        }

        public bool IsActive()
        {
            return characterIndex < TextToWrite.Length;
        }

        public void WriteAllAndDestroy()
        {
            uiText.text = TextToWrite;
            characterIndex = TextToWrite.Length;
            if (onComplete != null) onComplete();
            TextWriterDruide.RemoveWriter_Static(uiText);
        }
    }
}
