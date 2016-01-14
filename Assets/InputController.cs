using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Pools.pool.ReplaceInput(InputIntent.FinishTurn);
        }
	}
}
