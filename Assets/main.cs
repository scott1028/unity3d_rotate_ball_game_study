using UnityEngine;
using System.Collections;
using System.Linq;

public class main : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Transform cc = GameObject.Find("Board").GetComponentInChildren<Transform>();
        Transform[] all_cc = new Transform[cc.childCount];
        IOrderedEnumerable<Transform> all_dd;

        for (int i = 0; i < cc.childCount; i++)
        {
            all_cc[i] = cc.GetChild(i);
        }

        int idx = 0;
        // sorting
        all_dd = all_cc.OrderBy(a => a.transform.localPosition.z).ThenBy(b => b.transform.localPosition.x);
        foreach (Transform i in all_dd) {
            Debug.Log(i.localPosition.x);
            i.gameObject.AddComponent<ball_main>();
            i.gameObject.AddComponent<ball_animate>();
            i.gameObject.AddComponent<ball_color_build>();
            i.GetComponent<ball_main>().id = idx;
            i.GetComponent<ball_main>().position = new Vector2(Mathf.Repeat(idx, 5), (int)(idx / 5f));
            idx += 1;
            i.gameObject.name = idx.ToString();
        }
	}

    // Update is called once per frame
    void Update()
    {
	
	}
}
