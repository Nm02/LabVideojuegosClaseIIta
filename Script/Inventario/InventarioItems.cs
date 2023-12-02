using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioItems : MonoBehaviour
{
    [SerializeField] Item[] InventarioDeItems=new Item[10];
    [SerializeField] Item ItemEnMano;
    int ItemActivo = 1;
    [SerializeField] GameObject Mano;
    [SerializeField] int RadioDeBusqueda;
    [SerializeField] LayerMask LayerItem;

    private void Start()
    {

    }

    private void Update()
    {
        Collider[] ItemEnRango = Physics.OverlapSphere(transform.position, RadioDeBusqueda, LayerItem, QueryTriggerInteraction.UseGlobal);
        if (ItemEnRango.Length > 0 && Input.GetKeyDown("e"))
        {
            AgarrarItem(ItemEnRango[0].gameObject.GetComponent<Item>());

        }
    }


    public int BuscarEspacio()
    {
        for (int i = 0; i < InventarioDeItems.Length; i++)
        {
            if (InventarioDeItems[i] == null)
            {
                return i;
            }
        }
        return -1;
    }

    public void AgarrarItem(Item ItemParaAgarrar)
    {
        int casillaVacia=BuscarEspacio();
        if (casillaVacia==-1)
        {
            print("Inventario lleno");
        }
        else
        {
            InventarioDeItems[casillaVacia] = ItemParaAgarrar;
            
            ItemParaAgarrar.SerAgarrado(Mano);
            foreach(Item item in InventarioDeItems)
            {
                item.gameObject.SetActive(false);
            }
        }
    }

    public Item ObtenerItemEnInventario(int casilla)
    {
        return InventarioDeItems[casilla];
    }
    public void PonerItemEnInventario(int casilla, Item ItemParaPoner)
    {
        InventarioDeItems[casilla] = ItemParaPoner;
    }
    public Item ObtenerItemEnMano1()
    {
        return ItemEnMano;
    }
    public void PonerItemEnMano1(Item ItemAPoner)
    {
        ItemEnMano = ItemAPoner;
    }

}
