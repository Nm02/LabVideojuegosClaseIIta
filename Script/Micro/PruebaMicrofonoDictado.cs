using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class PruebaMicrofonoDictado : MonoBehaviour
{

    private DictationRecognizer m_DictationRecognizer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_DictationRecognizer = new DictationRecognizer();

        m_DictationRecognizer.Start();

        m_DictationRecognizer.DictationResult += (text, confidence) =>
        {
            print(text);
        };
    }
}
