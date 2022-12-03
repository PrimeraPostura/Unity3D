using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed;

    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float f = Input.GetAxis("Horizontal");

        rigidbody.velocity =Vector3.up*rigidbody.velocity.y + Vector3.right * f * speed ;

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I'm the Player, I enter to a trigger");
    }

}

