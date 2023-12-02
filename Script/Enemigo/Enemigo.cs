using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [Header("FOV Config")]
    [SerializeField] float Radio;
    [Range(0, 180)]
    [SerializeField] float AnguloDeVision;




    [Header("General Config")]
    [SerializeField] LayerMask DetectLayers;
    [SerializeField] string CapaObjetivo;
    [SerializeField] float Espera;



    [HideInInspector] public Collider Objetivo;
    NavMeshAgent ObjectAgent;
    Vector3 PosicionInicial;
    bool regresando;

    private void Awake()
    {
        Objetivo = null;
        ObjectAgent = GetComponent<NavMeshAgent>();
        PosicionInicial = transform.position;
    }


    void Update()
    {
        if (Objetivo == null)
        {
            BuscarObjetivo();

        }
        if (Objetivo != null)
        {

            Dirigirse(Objetivo);
            regresando = false;
        }
        else
        {
            if (regresando == false)
            {
                StartCoroutine(VolverAInicio());

            }
        }
        Buscar(Objetivo);

    }

    IEnumerator VolverAInicio()
    {
        regresando = true;
        yield return new WaitForSeconds(Espera);
        ObjectAgent.SetDestination(PosicionInicial);

    }
    void Buscar(Collider Target)
    {
        if (!EnEsfera(Target))
        {
            Objetivo = null;

        }
    }

    void BuscarObjetivo()
    {
        Collider[] Objetivos = new Collider [0];
        Objetivos = Physics.OverlapSphere(transform.position, Radio, DetectLayers);

        foreach (Collider Objetive in Objetivos) Debug.DrawRay(transform.position, Objetive.transform.position - transform.position, Color.red);

        for (int i = 0; i < Objetivos.Length; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Objetivos[i].transform.position - transform.position, out hit, Radio))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer(CapaObjetivo) && EnConoDeVision(Objetivos[i]))
                {
                    Objetivo = Objetivos[i];
                    break;
                }
            }

        }
    }
   
    void Dirigirse(Collider Target)
    {
        if (EnEsfera(Target) && EnConoDeVision(Target))
        {
            Debug.DrawRay(transform.position, Target.transform.position - transform.position, Color.green);
            ObjectAgent.SetDestination(Target.transform.position);

        }

    }
    bool EnEsfera(Collider Target)
    {
        if (Target == null) return false;
        Collider[] Objetivos = Physics.OverlapSphere(transform.position, Radio, DetectLayers);
        for(int i = 0; i < Objetivos.Length; i++)
        {
            if (Target == Objetivos[i]) return true;

        }
        return false;
    }
    bool  EnConoDeVision(Collider Target)
    {
        if(Target == null) return false;

        return Vector3.Angle(transform.forward, Target.transform.position - transform.position) < AnguloDeVision;
    }

  
    bool OnStartPosition()
    {
        return transform.position.x == PosicionInicial.x && transform.position.z == PosicionInicial.z;
    }

    Vector3 Vector(float angulo)
    {
        angulo += transform.localEulerAngles.y;
        return new Vector3(Mathf.Sin(angulo * Mathf.Deg2Rad), 0, Mathf.Cos(angulo * Mathf.Deg2Rad)) * Radio;
    }

    private void OnDrawGizmos()
    {      
        Debug.DrawLine(transform.position,transform.position + Vector(AnguloDeVision),Color.blue);
        Debug.DrawLine(transform.position,transform.position + Vector(-AnguloDeVision),Color.blue);
        
    }
   
}
