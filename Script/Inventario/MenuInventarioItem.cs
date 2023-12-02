using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInventarioItem : MonoBehaviour
{
    public GameObject PanelInventarioPrincipal;
    public InventarioItems Inventario;
    SlotMenuInventario[] SlotsInventarioPrincipal;

    public SlotMenuInventario ItemEquipado;



    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        gameObject.SetActive(true);

        //Obtener Slots principales
        int SlotCount = PanelInventarioPrincipal.transform.childCount;
        this.SlotsInventarioPrincipal = new SlotMenuInventario[SlotCount];
        int i = 0;
        for (i = 0; i < SlotCount; i++)
        {
            this.SlotsInventarioPrincipal[i] = PanelInventarioPrincipal.transform.GetChild(i).GetComponent<SlotMenuInventario>();
            
            this.SlotsInventarioPrincipal[i].slotIndex = i;
            this.SlotsInventarioPrincipal[i].SlotItem = Inventario.ObtenerItemEnInventario(i);
            //this.SlotsInventarioPrincipal[i].Button = PanelInventarioPrincipal.transform.GetChild(i).GetComponent<Button>();
            //this.SlotsInventarioPrincipal[i].Imagen = PanelInventarioPrincipal.transform.GetChild(i).GetComponent<Image>();
            this.SlotsInventarioPrincipal[i].Principal = true;
            /*
            if (this.SlotsInventarioPrincipal[i].SlotItem != null)
            {
                //this.SlotsInventarioPrincipal[i].Imagen.sprite = this.SlotsInventarioPrincipal[i].SlotItem.Icono;
            }
            */
            this.SlotsInventarioPrincipal[i].iniciar();


        }
        //Obtener slots equipados
        
        ItemEquipado.SlotItem= Inventario.ObtenerItemEnMano1();
        ItemEquipado.slotIndex = -1;
        ItemEquipado.iniciar();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    void OnClick()
    {
        
    }
}
