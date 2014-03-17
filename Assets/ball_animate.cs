using UnityEngine;
using System.Collections;

public class ball_animate : MonoBehaviour {
    Vector3 scale2;
    Vector3 scale1;
    bool play = false;
    bool can_small = false;
    bool can_large = false;

	// Use this for initialization
	void Start () {
        this.scale2 = this.gameObject.transform.localScale * 1.3f;
        this.scale1 = this.gameObject.transform.localScale * 1;
	}

    void larger() {
        this.gameObject.transform.localScale = Vector3.Lerp(this.gameObject.transform.localScale, scale2, 6f * Time.deltaTime);
        if (this.scale2.x - this.gameObject.transform.localScale.x <= 0.05f) {
            this.gameObject.transform.localScale = this.scale2;
            this.can_large = false;
            this.can_small = true;
        }
    }

    void smaller() {
        this.gameObject.transform.localScale = Vector3.Lerp(this.gameObject.transform.localScale, scale1, 9f * Time.deltaTime);
        if (this.gameObject.transform.localScale.x - this.scale1.x <= 0.05f)
        {
            this.gameObject.transform.localScale = this.scale1;
            this.play = false;
            this.can_small = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (play){
            if (can_large) {
                this.larger();
            }
            else if (can_small) {
                this.smaller();
            }
        }
        else {
            
        }
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) {
            this.play = true;
            this.can_large = true;
        }
    }
}
