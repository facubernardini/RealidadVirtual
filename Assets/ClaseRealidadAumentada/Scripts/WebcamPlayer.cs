using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WebcamPlayer : MonoBehaviour {

	public RawImage rawimage;
	void Start () 
	{
		WebCamTexture webcamTexture = new WebCamTexture();

		webcamTexture.requestedFPS =(15);

		rawimage.texture = webcamTexture;
		webcamTexture.Play();

	}
}
