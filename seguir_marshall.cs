using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class seguir_marshall : MonoBehaviour
{

    public float radio_activacion = 10f;
    Transform objetivo;
    NavMeshAgent agente;

    private float velocidad = 0.2f;
    public float wspeed;
    public float rspeed;
    public float velocidad_rotacion;

    void Start()
    {
        objetivo = player_manager.instance.jugador.transform;
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        float distancia = Vector3.Distance(objetivo.position, transform.position);
        if (distancia <= radio_activacion)
        {
            agente.SetDestination(objetivo.position);
            if (distancia <= agente.stoppingDistance)
            {
                mirar_jugador();
            }
        }

        var z = Input.GetAxis("Horizontal") * velocidad;
        var y = Input.GetAxis("Vertical") * velocidad_rotacion;

        transform.Translate(0, 0, z);
        transform.Rotate(0, y, 0);
    }
    void mirar_jugador()
    {
        Vector3 direccion = (objetivo.position - transform.position).normalized;
        Quaternion rotar_direccion = Quaternion.LookRotation(new Vector3(direccion.x,0, direccion.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotar_direccion, Time.deltaTime * 5f);

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio_activacion);
    }
}