using UnityEngine;
using System.Collections;

public class ZoomIn_Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		camera.fieldOfView = 10.0f;
	}

	//int zoom = 20;
	//int normal = 60;
	//float smooth  = 5.0f;
	//private bool isZoomed = false;


	float side_to_side = 0.0f;
	float up_and_down = 0.0f;

	//float red = 0.0f;
	//float green = 0.0f;
	//float blue = 0.0f;

	RaycastHit hit = new RaycastHit();
	Ray ray = new Ray();
	//float ray_distance = 0.0f;

	string looking_at;


	//new RaycastHit() hit
	//new Ray() ray
	//test change for git / bitbucket / sourcetree

	// Update is called once per frame
	void Update () {

		/*	if(Input.GetKeyDown(KeyCode.Z)){
				isZoomed = !isZoomed; 
			}*/
			
		if(Input.GetKey(KeyCode.X) && camera.fieldOfView < 60){
			camera.fieldOfView = camera.fieldOfView + 1.0f;
			print (camera.fieldOfView);
		}
		if(Input.GetKey(KeyCode.C) && camera.fieldOfView > 5){
			camera.fieldOfView = camera.fieldOfView - 1.0f;
			print (camera.fieldOfView);
		}

		//float moveUP = Input.GetKey("Mouse Y") * 100 * Time.deltaTime;
		//float moveSide = Input.GetAxis("Mouse X") * 100 * Time.deltaTime;

		side_to_side = 0.0f;
		up_and_down = 0.0f;

		if(Input.GetKey(KeyCode.A)){
			side_to_side = side_to_side - .5f;
		}

		if(Input.GetKey(KeyCode.D)){
			side_to_side = side_to_side + .5f;
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
				//red = Random.Range(0.0f,1.0f);
				//green = Random.Range(0.0f,1.0f);
				//blue = Random.Range(0.0f,1.0f);
				//hit.transform.renderer.material.color = Color(red,green,blue);
				hit.transform.renderer.material.color = new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f));
				//print ("I'm looking at " + looking_at);
				//print (hit.distance);
			}
		}
		else {
			if (looking_at != "nothing"){
				looking_at = "nothing";
				//print ("I'm looking at " + looking_at);
				//print (hit.distance);
			}
		}

		//print (hit.distance);
		//print (camera.fieldOfView);


		if (looking_at != "nothing" && hit.distance < 34.5 - camera.fieldOfView && camera.fieldOfView < 60) {
			camera.fieldOfView = camera.fieldOfView + Mathf.Abs (hit.distance - camera.fieldOfView) / 50;
			//print ("out out out");
		} 
		else if (looking_at != "nothing" && hit.distance > 35.5 - camera.fieldOfView && camera.fieldOfView > 5) {
			camera.fieldOfView = camera.fieldOfView - Mathf.Abs (camera.fieldOfView - hit.distance) / 50;
			//print ("in in in");
		} 
		else if (camera.fieldOfView < 80) {
			camera.fieldOfView = camera.fieldOfView + 0.0001f + Mathf.Abs (hit.distance - camera.fieldOfView) / 50;
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