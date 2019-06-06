
using UnityEngine;

public class BasicAI : MonoBehaviour {

    public Transform me;
    public Transform myTransform;

	
	
	// Update is called once per frame
	void Update () {
       
	}
    private void FixedUpdate()
    {
        transform.LookAt(me);
        transform.Translate(Vector3.forward * 5 * Time.deltaTime);
    }
}
