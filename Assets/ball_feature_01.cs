using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class ball_feature_01 : MonoBehaviour {
    string color;
    Vector2 pos;
    bool destroy_self = false;

	// Use this for initialization
	void Start () {
        this.color = this.renderer.material.name;
        this.pos = this.GetComponent<ball_main>().position;
        // Debug.Log(pos);
	}
	
	// Update is called once per frame
	void Update () {
        // Debug.DrawRay(transform.position, transform.right,Color.red);
	}

    // 鄰近直線消除演算法
    void processor() {
        this.test_direction(Vector3.up);
        this.test_direction(Vector3.down);
        this.test_direction(Vector3.left);
        this.test_direction(Vector3.right);
    }

    void test_direction(Vector3 dir) {
        // test right
        // Debug.Log(this.color);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, dir);

        // 讓物件按照距離排序
        IOrderedEnumerable<RaycastHit> _hits = hits.OrderBy(x => Vector3.Distance(this.transform.position, x.collider.gameObject.transform.position));

        List<GameObject> prepare_destroy_gameobject = new List<GameObject>();
        prepare_destroy_gameobject.Add(this.gameObject);
        
        int hit_count = 0;
        int i = 0;
        hits = _hits.ToArray<RaycastHit>();
        while (i < hits.Length)
        {
            RaycastHit hit = hits[i];
            if (hit.collider.gameObject.renderer.material.name == this.color)
            {
                hit_count += 1;
                prepare_destroy_gameobject.Add(hit.collider.gameObject);
                if (hit_count >= 2)
                {
                    this.destroy_self = true;
                }
            }
            else
            {
                break;
            }
            i++;
        }
        if (this.destroy_self) { 
            foreach(GameObject ii in prepare_destroy_gameobject) Destroy(ii, 0.25f);
        }
        this.destroy_self = false;
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonUp(0)){
            this.processor();
        }
    }
}
