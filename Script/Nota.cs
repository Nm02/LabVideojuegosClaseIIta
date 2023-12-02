using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nota : MonoBehaviour
{
    [SerializeField] GameObject PanelDeNota;

    private void Start()
    {
        PanelDeNota.SetActive(false);
    }

    public void AgarrarNota()
    {
        gameObject.SetActive(false);
        PanelDeNota.SetActive(true);
        Time.timeScale = 0;
    }

    public void Cerrar()
    {
        PanelDeNota.SetActive(false);
        Time.timeScale = 1.0f;
    }

}
