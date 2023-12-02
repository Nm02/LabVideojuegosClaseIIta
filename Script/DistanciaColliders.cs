using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanciaColliders : MonoBehaviour
{
    [SerializeField] Transform Player;
    Collider Coll;
    // Start is called before the first frame update
    void Start()
    {
        Coll=GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        print(Vector3.Distance(Coll.ClosestPointOnBounds(Player.position), Player.transform.position));
    }
}
