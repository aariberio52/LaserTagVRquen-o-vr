using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour {

    
    float velocity;
    Rigidbody rigidbody;
    private RaycastHit raycast;
    private bool vrMode;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(float _velocity, bool _vrMode)
    {
        velocity = _velocity;
        vrMode = _vrMode;
    }

    void FixedUpdate()
    {

        var sensitivity = 0.01f;
        var movementAmount = 0.15f;
        var movementVector = new Vector3(0f, 0f, 0f);

        if (vrMode)
        {
            var hMove = Input.GetAxis("Vertical");
            var vMove = Input.GetAxis("Horizontal");
            // left arrow
            if (hMove < -sensitivity)
                transform.position -= Camera.main.transform.right * velocity * Time.deltaTime;
            // right arrow
            if (hMove > sensitivity)
                transform.position += Camera.main.transform.right * velocity * Time.deltaTime;
            // up arrow
            if (vMove < -sensitivity)
                transform.position += Camera.main.transform.forward * velocity * Time.deltaTime;
            // down arrow
            if (vMove > sensitivity)
                transform.position -= Camera.main.transform.forward * velocity * Time.deltaTime;
        }
        else
        {
            var vMove = Input.GetAxis("Vertical");
            var hMove = Input.GetAxis("Horizontal");
            // left arrow
            if (hMove < -sensitivity)
                transform.position -= Camera.main.transform.right * velocity * Time.deltaTime;
            // right arrow
            if (hMove > sensitivity)
                transform.position += Camera.main.transform.right * velocity * Time.deltaTime;
            // up arrow
            if (vMove < -sensitivity)
                transform.position -= Camera.main.transform.forward * velocity * Time.deltaTime;
            // down arrow
            if (vMove > sensitivity)
                transform.position += Camera.main.transform.forward * velocity * Time.deltaTime;


        }
    }
}