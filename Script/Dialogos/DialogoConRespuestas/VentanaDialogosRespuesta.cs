using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VentanaDialogosRespuesta : MonoBehaviour
{
    [SerializeField] bool Pausa;
    public Dialogo conversacion;

    [SerializeField] Text Texto;
    [SerializeField] ContenedorRespuesta[] Opciones;

    public void Abrir()
    {
        gameObject.SetActive(true);
        if (Pausa)
        {
            Time.timeScale = 0;
        }
        for (int i = 0; i < Opciones.Length; i++)
        {
            Opciones[i].gameObject.SetActive(false);
        }
        conversacion.indice = 0;
        Texto.text = conversacion.Dialogos[conversacion.indice];
    }

    public void AbrirSiguente()
    {
        gameObject.SetActive(true);
        if (Pausa)
        {
            Time.timeScale = 0;
        }

        if (conversacion.indice + 1 < conversacion.Dialogos.Length)
        {
            conversacion.indice += 1;
            Texto.text = conversacion.Dialogos[conversacion.indice];
        }
        else
        {
            for (int i = 0; i < Opciones.Length; i++)
            {
                if (conversacion.Respuestas.Length >= i)
                {
                    Opciones[i].dialogo = conversacion.Respuestas[i];
                    Opciones[i].Activar(conversacion.TextoOpcion);

                }

            }
            if (conversacion.Respuestas.Length == 0)
            {
                Cerrar();
            }
        }
    }

    public void Btn_Siguiente(bool siguiente)
    {
        if (siguiente)
        {
            if (conversacion.indice + 1 < conversacion.Dialogos.Length)
            {
                
                conversacion.indice += 1;
                Texto.text = conversacion.Dialogos[conversacion.indice];
            }
            else
            {
                
                if (conversacion.Respuestas.Length == 0)
                {
                    Cerrar();
                }
                else
                {
                    for (int i = 0; i < Opciones.Length; i++)
                    {
                        if (conversacion.Respuestas.Length > i)
                        {
                            Opciones[i].dialogo = conversacion.Respuestas[i];
                            Opciones[i].Activar(conversacion.Respuestas[i].TextoOpcion);

                        }

                    }
                }
            }
            
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
