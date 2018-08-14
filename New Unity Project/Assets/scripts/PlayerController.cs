using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

    public float gravity = -4f;
    private float velY = 0f;
    private bool fail = false;
    private const float jumpVel = 25f;
    public Camera cam;
    public float camOffset = 8;
    public string color = "red";
    public float bottomCollision = 8f;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        velY += gravity * Time.deltaTime;
        HandleKeys();
        if ((this.transform.position.y>bottomCollision)||(velY>0f))
        {
            this.transform.Translate(new Vector3(0, velY , 0) * Time.deltaTime , Space.World);
        }
        cam.transform.SetPositionAndRotation(new Vector3(cam.transform.position.x, this.transform.position.y + camOffset, cam.transform.position.z) , cam.transform.rotation);
    }

    void HandleKeys()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (fail)
        {
            return;
        }
        this.velY = jumpVel;
        System.Console.WriteLine("Jump; Vel: " + velY);
    }

    void refreshColor()
    {
        switch (color)
        {
            case "red":
                this.GetComponent<Renderer>().material.color = new Color(255 , 0 , 0);
                break;

            case "green":
                this.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
                break;

            case "blue":
                this.GetComponent<Renderer>().material.color = new Color(0, 0, 255);
                break;

            case "yellow":
                this.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Console.WriteLine("Collided with " + collision.gameObject.name);
        if (collision.gameObject.tag != color)
        {
            gravity = 0f;
            velY = 0f;
            fail = true;
        }
        else
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}
