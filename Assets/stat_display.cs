using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stat_display : MonoBehaviour {

    public StatTracker data;
    int[] current_stat;
    int[] target_stat;

    public Color gain, lose, m, p, s;

    GameObject m_obj;
    GameObject p_obj;
    GameObject s_obj;
    GameObject sub_obj;

    void Start () {
        current_stat = new int[] { 0, 0, 0, 1000 };
        target_stat = new int[] { 0, 0, 0, 0 };

        m_obj = gameObject.transform.Find ("Money").gameObject;
        p_obj = gameObject.transform.Find ("Reputation").gameObject;
        s_obj = gameObject.transform.Find ("Style").gameObject;
        sub_obj = gameObject.transform.Find ("Subcount").gameObject;
    }
    void Update () {
        if (current_stat[0] < target_stat[0]) {
            //Debug.Log ("Current " + current_stat[0] + " Target " + target_stat[0]);
            current_stat[0]++;
            m_obj.GetComponent<UnityEngine.UI.Image> ().color = gain;
        } else if (current_stat[0] > target_stat[0]) {
            //Debug.Log ("Current " + current_stat[0] + " Target " + target_stat[0]);
            current_stat[0]--;
            m_obj.GetComponent<UnityEngine.UI.Image> ().color = lose;
        } else {
            m_obj.GetComponent<UnityEngine.UI.Image> ().color = m;
        }

        if (current_stat[1] < target_stat[1]) {
            current_stat[1]++;
            p_obj.GetComponent<UnityEngine.UI.Image> ().color = gain;
        } else if (current_stat[1] > target_stat[1]) {
            current_stat[1]--;
            p_obj.GetComponent<UnityEngine.UI.Image> ().color = lose;
        } else {
            p_obj.GetComponent<UnityEngine.UI.Image> ().color = p;
        }

        if (current_stat[2] < target_stat[2]) {
            current_stat[2]++;
            s_obj.GetComponent<UnityEngine.UI.Image> ().color = gain;
        } else if (current_stat[2] > target_stat[2]) {
            current_stat[2]--;
            s_obj.GetComponent<UnityEngine.UI.Image> ().color = lose;
        } else {
            s_obj.GetComponent<UnityEngine.UI.Image> ().color = s;
        }

        if (current_stat[3] < target_stat[3]) {
            current_stat[3]++;
            sub_obj.GetComponent<UnityEngine.UI.Text> ().color = gain;
        } else if (current_stat[3] > target_stat[3]) {
            current_stat[3] -= 5;
            sub_obj.GetComponent<UnityEngine.UI.Text> ().color = lose;
        } else {
            sub_obj.GetComponent<UnityEngine.UI.Text> ().color = Color.black;
        }

        m_obj.GetComponent<RectTransform> ().sizeDelta = new Vector2 (((float) current_stat[0]).Remap (0, 100, 25, 760), 36);
        p_obj.GetComponent<RectTransform> ().sizeDelta = new Vector2 (((float) current_stat[1]).Remap (0, 100, 25, 760), 36);
        s_obj.GetComponent<RectTransform> ().sizeDelta = new Vector2 (((float) current_stat[2]).Remap (0, 100, 25, 760), 36);
        if (current_stat[3] <= 0)
            sub_obj.GetComponent<UnityEngine.UI.Text> ().text = "Sub Count:\n0";
        else if (current_stat[3] >= 1000)
            sub_obj.GetComponent<UnityEngine.UI.Text> ().text = "Sub Count:\n1,000,000!!!";
        else
            sub_obj.GetComponent<UnityEngine.UI.Text> ().text = "Sub Count:\n" + current_stat[3] + ",000";
    }

    public void update_stats (int[] update) {
        target_stat[0] = update[0];
        target_stat[1] = update[1];
        target_stat[2] = update[2];
        target_stat[3] = update[3];
    }
}