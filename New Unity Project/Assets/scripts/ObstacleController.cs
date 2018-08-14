using UnityEngine;
using System;

public class ObstacleController : MonoBehaviour {

    public float rotationSpeed = 50f;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(0 , 0, rotationSpeed * Time.deltaTime));	
	}

}
