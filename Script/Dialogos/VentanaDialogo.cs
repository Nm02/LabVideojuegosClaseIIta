using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VentanaDialogo : MonoBehaviour
{
    [SerializeField] bool Pausa;
    [SerializeField] string[] Dialogos;
    int indice = 0;

    [SerializeField] Text Texto;
    public void Abrir()
    {
        gameObject.SetActive(true);
        if (Pausa)
        {
            Time.timeScale = 0;
        }
        Texto.text=Dialogos[indice];
    }

    public void AbrirSiguente()
    {
        gameObject.SetActive(true);
        if (Pausa)
        {
            Time.timeScale = 0;
        }
        indice += 1;
        Texto.text = Dialogos[indice];
    }

    public void Btn_Siguiente(bool siguiente)
    {
        if (siguiente && indice+1<Dialogos.Length)
        {
            indice += 1;
            Texto.text = Dialogos[indice];
        }
        else
        {
            Cerrar();
        }
    }

    public void Cerrar()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
