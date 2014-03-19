using UnityEngine;
using System.Collections;
using System.Linq;

public class main : MonoBehaviour {

    // 關卡行列數
    int x=5;
    int y=5;

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
                // sub main
                i.gameObject.AddComponent<ball_main>();
                // 動畫
                i.gameObject.AddComponent<ball_animate>();
                // 顏色
                i.gameObject.AddComponent<ball_color_build>();
                // 載入特性
                i.gameObject.AddComponent<ball_feature_01>();
                // 物理特性
                i.gameObject.AddComponent<Rigidbody>();
                i.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;

                // 初始化資訊
                i.GetComponent<ball_main>().id = idx;
                i.GetComponent<ball_main>().position = new Vector2(Mathf.Repeat(idx, this.x), (int)(idx / this.y*1f));
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
