using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Ganar : MonoBehaviour
{
    [SerializeField] float tamaño=5f;
    [SerializeField] LayerMask CapaDeJugador;
    [SerializeField] GameObject CartelGanar;


    private void Start()
    {
        CartelGanar.SetActive(false);
    }

    private void Update()
    {
        if (Physics.CheckBox(transform.position,new Vector3(tamaño,tamaño,tamaño), Quaternion.identity, CapaDeJugador))
        {
            Win();
        }
    }

    void Win()
    {
        CartelGanar.SetActive(true);
        Time.timeScale = 0;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;   
        Gizmos.DrawWireSphere(transform.position, 5);
    }



}
