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
        string title, results;
        if (money <= 0) {
            title = "You're broke hun!";
            results = "If you don't have the capital to produce that sweet content, you're not getting clicks, you're not getting sponsors, and you're definitely not hittin a million subs. Maybe keep an eye on that cash flow next time...";
        } else if (reputation <= 0) {
            title = "You'll never work in this town again!";
            results = "Wow, not a good look. This aint it chief. Yikes. You're demonetized, you're banned from Twitter, and the New York Times is writing editorials about your behavior. Maybe next time think about your actions a little? You are capital cee Cancelled.";
        } else if (style <= 0) {
            title = "Trash can!!!!";
            results = "Oh dear, you really let yourself go. Money can buy a lot of things but it can't make you conventionally attractive. Well, maybe it can, but you sure didn't use it for that. Maybe be careful who you associate with sweetie, it's not a good look.";
        } else if (subs >= 1000) {
            title = "PLATINUM!";
            results = "WOW. You guys I am just speechless, I don't know what to say. I never thought I would be in this position and it's honestly just so important to me that you all know how grateful I am for you all (and my sponsors). I am just so lucky you guys omggg.";
        }
    }
}