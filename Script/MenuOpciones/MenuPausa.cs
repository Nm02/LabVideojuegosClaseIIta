using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : Menu
{
    [SerializeField] GameObject menuPausa;
    [SerializeField] KeyCode teclaPausa;
    bool pausado = false;

    // Start is called before the first frame update
    void Start()
    {
        menuPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(teclaPausa))
        {
            Pausar(!pausado);
        }
    }

    public void Pausar(bool pausa)
    {
        pausado = !pausado;
        menuPausa.SetActive(pausa);
        if (pausa)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        
    }
}
