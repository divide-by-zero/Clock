using UnityEngine;

public class DigitalClock : MonoBehaviour
{
    public SixClockSegment[] segments;
    private int mode = 0;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == 0)
        {
            var time = System.DateTime.Now;

            segments[0].Num = time.Hour/10;
            segments[1].Num = time.Hour%10;
            segments[2].Num = time.Minute/10;
            segments[3].Num = time.Minute%10;
        }
        else
        {
            var time = System.DateTime.Now;

            segments[0].Num = time.Month/10;
            segments[1].Num = time.Month%10;
            segments[2].Num = time.Day/10;
            segments[3].Num = time.Day%10;
        }
        if (Input.GetMouseButtonDown(0))
        {
            mode = (mode + 1)%2;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}