using UnityEngine;
using System.Collections;

public class ball_color_build : MonoBehaviour {
    Material[] ms = new Material[3];
	// Use this for initialization
	void Start () {
        ms[0] = Resources.Load("ball_styles/blue") as Material;
        ms[1] = Resources.Load("ball_styles/red") as Material;
        ms[2] = Resources.Load("ball_styles/green") as Material;
        this.gameObject.renderer.material = ms[Random.Range(0, 3)];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
