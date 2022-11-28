using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraOrbital : MonoBehaviour
{
    
  public Transform player;//A quien debe seguir la camara
  public Vector3 camOffset;//Para obtener la direccion y posicion 
  [Range(0.1f, 1.0f)]
  public float SmoothFactor=0.1f; //para cambiar suavidad de movimiento de la camara
  public bool rotacionActiva= true;//
  public float velRotacion= 5.0f;// velocidad de movimiento de la camara
  public bool mirarAlJugador= false;//Detecta que la camara mire al jugador
  
  void Start()
  {
    camOffset= transform.position - player.position;
  }

  void FixedUpdate()
  {
    if(rotacionActiva)
    {
         Quaternion angulo = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * velRotacion, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * velRotacion, Vector3.right);
        camOffset= angulo* camOffset;
        
    }
    Vector3 newPos= player.position + camOffset;
    transform.position= Vector3.Slerp(transform.position, newPos, SmoothFactor);
    if(mirarAlJugador || rotacionActiva)
    {
        transform.LookAt(player);//la camara mirara en direccion al jugador
    }

    if (Input.GetButton("Fire1"))
    {
        rotacionActiva= true;
    }
    else
    {
        rotacionActiva=false;
        transform.LookAt(player);//la camara tendra uso con un click
    }
    }
  }

