using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMenuInventario : MonoBehaviour
{
    public int slotIndex;
    public Item SlotItem;
    public Button Button;
    public Image Imagen;
    public bool Principal=false;//para ver si esta en el inventario principal o equipado
    public MenuInventarioItem Menu;

    private void Start()
    {
        
    }
    public void iniciar()
    {
        Button = gameObject.GetComponent<Button>();
        Button.onClick.RemoveAllListeners();
        Button.onClick.AddListener(OnClick);
        Imagen = gameObject.GetComponent<Image>();
        if (SlotItem != null)
        {
            Imagen.sprite = SlotItem.Icono;
        }
        else
        {
            Imagen.sprite = null;
        }
        
    }

    public void IniciarEquipado()
    {
        Button = gameObject.GetComponent<Button>();
        Button.onClick.RemoveAllListeners();
        Button.enabled = false;
        Imagen = gameObject.GetComponent<Image>();
        if (SlotItem != null)
        {
            Imagen.sprite = SlotItem.Icono;
        }
        else
        {
            Imagen.sprite = null;
        }
    }
    public void OnClick()
    {
        print("si");
        Item Temporal= Menu.ItemEquipado.SlotItem;
        Menu.Inventario.PonerItemEnMano1(SlotItem);
        Menu.ItemEquipado.SlotItem = SlotItem;
        SlotItem = Temporal;
        iniciar();
        Menu.Inventario.PonerItemEnInventario(slotIndex, SlotItem);
        Menu.ItemEquipado.IniciarEquipado();
    }
}

    
