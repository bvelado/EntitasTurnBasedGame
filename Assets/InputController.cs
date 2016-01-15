using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Pools.pool.ReplaceInput(InputIntent.FinishTurn);
        }
	}
}
