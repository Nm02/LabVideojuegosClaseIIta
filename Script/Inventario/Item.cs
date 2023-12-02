using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Sprite Icono;
    public string Nombre="Item";

    public void SerAgarrado(GameObject PlayerMano)
    {
        gameObject.SetActive(true);
        gameObject.transform.parent = PlayerMano.transform;
        gameObject.transform.localPosition = new Vector3(0, 0, 0);

    }



}
