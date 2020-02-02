using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTracker : MonoBehaviour {

    public stat_display display;
    public int money, reputation, style, subs;
    public bool viral, drama;
    public float effect_multiplier = 1.2f;
    int remaining_status = 0;

    void Start () {
        money = 80;
        reputation = 10;
        style = 20;
        subs = 0;
        viral = false;
        drama = false;

         int[] display_stats = new int[] { money, reputation, style, subs };
        display.update_stats (display_stats);
    }

    public void apply_choice (int[] stats) {
        for (int i = 0; i < stats.Length; i++)
            if ((viral && stats[i] > 0) || (drama && stats[i] < 0))
                stats[i] = (int) (stats[i] * effect_multiplier);

        money += stats[0];
        reputation += stats[1];
        style += stats[2];
        subs += stats[3];

        remaining_status--;
        if (remaining_status == 0) {
            viral = false;
            drama = false;
        }
        if (stats.Length == 5) {
            if (stats[4] == 1)
                go_viral ();
            else
                go_drama ();

        }
        int[] display_stats = new int[] { money, reputation, style, subs };
        display.update_stats (display_stats);
        check_end_states ();
    }
    public void go_viral () {
        viral = true;
        remaining_status = 4;
    }

    public void go_drama () {
        drama = true;
        remaining_status = 4;
    }
    void check_end_states () {
        if (money <= 0) {

        } else if (reputation <= 0) {

        } else if (style <= 0) {

        } else if (subs >= 1000) {

        }
    }
}