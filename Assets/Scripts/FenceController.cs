using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FenceController : MonoBehaviour {

	private float rSmall = 2f;
	private float rBig = 5f;
	public float postDist = 0.3f;

	private GameObject fenceBig;
	private GameObject fenceSmall;

	public Transform fencePost;

	// Use this for initialization
	void Start () {

		fenceBig = new GameObject();
		fenceSmall = new GameObject ();
		
		makeFence (rSmall,fenceSmall);
		makeFence (rBig,fenceBig);	
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.I)) {
			rBig += 0.2f;
			Destroy(fenceBig);
			fenceBig = new GameObject();
			makeFence(rBig,fenceBig);
		}

		if (Input.GetKeyDown (KeyCode.K)) {
			rBig -= 0.2f;
			Destroy(fenceBig);
			fenceBig = new GameObject();
			makeFence(rBig,fenceBig);
		}

		if (Input.GetKeyDown (KeyCode.U)) {
			rSmall += 0.2f;
			Destroy(fenceSmall);
			fenceSmall = new GameObject();
			makeFence(rSmall,fenceSmall);
		}
		
		if (Input.GetKeyDown (KeyCode.J)) {
			rSmall -= 0.2f;
			Destroy(fenceSmall);
			fenceSmall = new GameObject();
			makeFence(rSmall,fenceSmall);
		}
	}


	void makeFence(float r,GameObject name){
		float x; float z;
		int numPosts = (int)(2f*Mathf.PI*r/postDist);
		
		float circInterval = 2*Mathf.PI/numPosts;
		float currAngle = 0;
		for(int i = 0; i < numPosts; i++){
			x = r*Mathf.Sin(currAngle);
			z = r*Mathf.Cos(currAngle);
			Transform currPost = (Transform) Instantiate(fencePost,new Vector3(x,1,z),Quaternion.identity);
			currPost.parent = name.transform;
			currAngle += circInterval;
		}
	}
	
}
