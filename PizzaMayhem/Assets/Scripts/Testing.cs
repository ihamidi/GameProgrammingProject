using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

    [Header("Set in Inspector")]
    public Transform player;
    public Transform enemy;

	// Use this for initialization
	void Start () {
        Instantiate(player, transform.position, transform.rotation);
        //Instantiate(enemy, transform.position, transform.rotation);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
