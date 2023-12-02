using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarNotas : MonoBehaviour
{
    [SerializeField] LayerMask NoteLayer;
    [SerializeField] float RangoDeAgarre=5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit,  Mathf.Infinity, NoteLayer) && (Physics.CheckBox(transform.position, new Vector3(RangoDeAgarre, RangoDeAgarre, RangoDeAgarre), Quaternion.identity, NoteLayer)))////
            {
                hit.collider.gameObject.GetComponent<Nota>().AgarrarNota();
            }

        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, RangoDeAgarre);
    }
}
