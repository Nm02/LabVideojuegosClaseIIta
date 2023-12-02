using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContenedorRespuesta : MonoBehaviour
{
    public Dialogo dialogo;

    [SerializeField] Text Texto;

    public void Elegir(VentanaDialogosRespuesta Ventana)
    {
        Ventana.conversacion = dialogo;
        Ventana.Abrir();
    }

    public void Activar(string dialogo)
    {
        gameObject.SetActive(true);
        Texto.text = dialogo;
    }
}
