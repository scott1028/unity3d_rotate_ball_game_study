using UnityEngine;
using System.Collections;
using System.Linq;

public class main : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Transform cc = GameObject.Find("Board").GetComponentInChildren<Transform>();
        Transform[] all_cc = new Transform[cc.childCount];
        IOrderedEnumerable<Transform> all_dd;

        for (int i = 0; i < cc.childCount; i++) all_cc[i] = cc.GetChild(i);

        int idx = 0;

        // sorting
        all_dd = all_cc.OrderBy(a => Mathf.Round(a.transform.localPosition.z * 100)).ThenBy(a => Mathf.Round(a.transform.localPosition.x * 100));

        foreach (Transform i in all_dd)
        {
            if (i.active)
            {
                i.gameObject.AddComponent<ball_main>();
                i.gameObject.AddComponent<ball_animate>();
                i.gameObject.AddComponent<ball_color_build>();
                i.GetComponent<ball_main>().id = idx;
                i.GetComponent<ball_main>().position = new Vector2(Mathf.Repeat(idx, 6), (int)(idx / 6f));
                i.gameObject.name+= idx.ToString();
                idx += 1;
            }
        }
	}

    // Update is called once per frame
    void Update()
    {
	
	}
}
