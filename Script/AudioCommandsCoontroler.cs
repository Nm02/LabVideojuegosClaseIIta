using System.Collections;
using UnityEngine;
//KeywordRecognizer imports
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;


public class AudioCommandsCoontroler : MonoBehaviour
{
    //Declarate KeywordRecognizer
    KeywordRecognizer keywordRecognizer;
    //Create Key/events diccionary
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    //bool Contraseña = false;

    // Start is called before the first frame update
    void Start()
    {
        //Add key and event to the diccionary with normal function
        keywords.Add("hola perro", Saludar_Perro);

        //Add key and event to the diccionary with Lamda function
        keywords.Add("hola gato", () =>
        {
            // action to be performed when this keyword is spoken
            print("miau");
        });

        keywords.Add("hola", () =>
        {
            print("Hola");
        });

        keywords.Add("tres tristes tigres tragaban trigo en un trigal", () =>
        {
            print("A ella se la estan haciendo tragar");
        });

        keywords.Add("Skidush", () => print("bum"));

        /*
        keywords.Add("a", Error);
        keywords.Add("e", Error);
        keywords.Add("i", Error);
        keywords.Add("o", Error);
        keywords.Add("u", Error);
        */

        //Create KeywordRecognizer and assign the key list from the Key/Events diccionary
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;


        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            if (!keywordRecognizer.IsRunning)
            {
                //Start Recognizerd
                keywordRecognizer.Start();
                print("Microfono encendido");
                //Contraseña = false;
            }
            
        }
        else
        {
            if (keywordRecognizer.IsRunning)
            {
                //Stop Recognized
                keywordRecognizer.Stop();
                print("Microfono apagado");
                /*
                if (!Contraseña)
                {
                    print("comando no encontrado");
                }
                Contraseña = true;
                */
            }
        }
    }

    //Event that is activated when a phrase is recognized
    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;


        // if the keyword recognized is in our dictionary, call that Action.
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            //Contraseña = true;
            keywordAction.Invoke();
        }

    }


    void Saludar_Perro()
    {
        print("guau");
    }

    void Error()
    {
        print("I cant recognize that phrase");
        keywordRecognizer.Stop();
    }
}
