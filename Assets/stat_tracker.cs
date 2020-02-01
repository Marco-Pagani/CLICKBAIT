using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stat_tracker : MonoBehaviour {

    public int money, reputation, style, subs;
    public bool viral, drama;
    int remaining_status = 0;
    
    void Start () {
        money = 80;
        reputation = 10;
        style = 20;
        subs = 0;
        viral = false;
        drama = false;
    }

    public void apply_choice (int[] stats) {
        money += stats[0];
        reputation += stats[1];
        style += stats[2];
        subs += stats[3];

    }
    public void go_viral () {
        viral = true;
        remaining_status = 4;
    }

    public void go_drama () {
        drama = true;
        remaining_status = 4;
    }

}