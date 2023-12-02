using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBrillo : MonoBehaviour
{
    //Para que funcione se debe declarar el tag "GlowPanel" antes de empezar
    private Image Brillo;



    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "GlowPanel";
        Brillo = gameObject.GetComponent<Image>();
        ActualizarBrillo();
        AudioListener.volume = PlayerPrefs.GetFloat("VolumenAudio", 0.5f);
    }


    public void ActualizarBrillo()
    {
        Brillo.color = new Color(Brillo.color.r, Brillo.color.g, Brillo.color.b, 1 - PlayerPrefs.GetFloat("Brillo", 0.5f));
    }
}
