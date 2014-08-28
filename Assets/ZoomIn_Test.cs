using UnityEngine;
using System.Collections;

public class ZoomIn_Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	//int zoom = 20;
	//int normal = 60;
	//float smooth  = 5.0f;
	//private bool isZoomed = false;


	float side_to_side = 0.0f;
	float up_and_down = 0.0f;

	RaycastHit hit = new RaycastHit();
	Ray ray = new Ray();

	string looking_at;

	//new RaycastHit() hit
	//new Ray() ray
	//test change for git / bitbucket / sourcetree

	// Update is called once per frame
	void Update () {

		/*	if(Input.GetKeyDown(KeyCode.Z)){
				isZoomed = !isZoomed; 
			}*/
			
		if(Input.GetKey(KeyCode.X)){
			camera.fieldOfView = camera.fieldOfView + 1.0f;
		}
		if(Input.GetKey(KeyCode.C)){
			camera.fieldOfView = camera.fieldOfView - 1.0f;
		}

		//float moveUP = Input.GetKey("Mouse Y") * 100 * Time.deltaTime;
		//float moveSide = Input.GetAxis("Mouse X") * 100 * Time.deltaTime;

		side_to_side = 0.0f;
		up_and_down = 0.0f;

		if(Input.GetKey(KeyCode.A)){
			side_to_side = side_to_side + .5f;
		}

		if(Input.GetKey(KeyCode.D)){
			side_to_side = side_to_side - .5f;
		}

		if(Input.GetKey(KeyCode.W)){
			up_and_down = up_and_down - .5f;
		}

		if(Input.GetKey(KeyCode.S)){
			up_and_down = up_and_down + .5f;
		}
		
		camera.transform.Rotate(up_and_down,side_to_side,0);



		// Get the ray going through the center of the screen
		//ray = camera.ViewportPointToRay(Vector3(0.5,0.5,0));

		// Do a raycast
		/*var hit = RaycastHit;
		if (Physics.Raycast (ray, hit)) {
				print ("I'm looking at " + hit.transform.name);
		}
		else {
				print ("I'm looking at nothing!");
		}
*/
		// Get the ray going through the center of the screen
		ray = camera.ViewportPointToRay(new Vector3(0.5f,0.5f,0.0f));

		//Physics.Raycast(ray, out hit))


		// Do a raycast
		if (Physics.Raycast(ray, out hit)) {
			if (hit.transform.name != looking_at){
				looking_at = hit.transform.name;
				print ("I'm looking at " + looking_at);
			}
		}
		else {
			if (looking_at != "nothing"){
				looking_at = "nothing";
				print ("I'm looking at " + looking_at);
			}
		}


	
			//if(isZoomed == true){
			//	camera.fieldOfView = Mathf.Lerp(camera.fieldOfView,zoom,Time.deltaTime*smooth);
			//camera.fieldOfView = 20.0f;
			//}
	
			//else{
			//	camera.fieldOfView = Mathf.Lerp(camera.fieldOfView,normal,Time.deltaTime*smooth);
			//camera.fieldOfView = 60.0f;
			//}

	}
}