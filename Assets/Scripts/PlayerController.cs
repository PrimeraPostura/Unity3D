using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class PlayerController : MonoBehaviour

{

    CharacterController characterController;

    public float velocidad_caminar=6.0f;

    public float velocidad_correr=10.0f;

    public float velocidad_salto=2.0f;

    public float gravedad =70.0f;

    private Vector3 movimiento = Vector3.zero;

    // Start is called before the first frame update

    void Start()

    {

        characterController = GetComponent<CharacterController>();

    }



    // Update is called once per frame

    void Update()

    {

        if(characterController.isGrounded){

            movimiento= new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if(Input.GetKey(KeyCode.LeftShift)){

                movimiento = transform.TransformDirection(movimiento)* velocidad_correr; 

            }

            else{

                movimiento = transform.TransformDirection(movimiento)* velocidad_caminar;

            }

            if(Input.GetKey(KeyCode.Space)){

                movimiento.y = velocidad_salto;

            }

            

        }

        movimiento.y -= gravedad * Time.deltaTime;

        characterController.Move(movimiento*Time.deltaTime);

    }

}