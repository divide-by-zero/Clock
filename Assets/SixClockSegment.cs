using UnityEngine;

public class SixClockSegment : MonoBehaviour
{
    private AnalogClock[] clocks = new AnalogClock[6];
    public AnalogClock analogClockPrefab;

    private int _num;
    public int Num
    {
        set
        {
            if (_num == value) return;
            switch (value)
            {
                case 0:
                    Set(3, 30, 30, 9, 30, 30,
                        0, 30, 0, 0, 30, 0,
                        0, 15, 0, 0, 45, 0);
                    break;
                case 1:
                    Set(null, null, null, 8, 30, 30,
                        null, null, null, 0, 30, 0,
                        null, null, null, 9, 15, 0);
                    break;
                case 2:
                    Set(3, 15, 15, 9, 30, 45,
                        3, 30, 30, 0, 45, 0,
                        0, 15, 0, 9, 45, 45);
                    break;
                case 3:
                    Set(3, 15, 15, 9, 30, 30,
                        3, 15, 15, 6, 45, 0,
                        3, 15, 15, 0, 45, 0);
                    break;
                case 4:
                    Set(6, 30, 30, 6, 30, 30,
                        0, 15, 0, 6, 45, 0,
                        null, null, null, 0, 0, 0);
                    break;
                case 5:
                    Set(3, 30, 15, 9, 45, 45,
                        0, 15, 0, 9, 30, 30,
                        3, 15, 15, 0, 45, 0);
                    break;
                case 6:
                    Set(3, 30, 15, 9, 45, 45,
                        3, 30, 0, 9, 30, 45,
                        0, 15, 0, 0, 45, 0);
                    break;
                case 7:
                    Set(3, 30, 30, 9, 30, 30,
                        0, 0, 0, 0, 30, 0,
                        null, null, null, 0, 0, 0);
                    break;
                case 8:
                    Set(3, 30, 30, 9, 30, 30,
                        3, 30, 0, 9, 30, 0,
                        0, 15, 0, 0, 45, 0);
                    break;
                case 9:
                    Set(3, 30, 30, 9, 30, 30,
                        0, 15, 0, 0, 30, 45,
                        3, 15, 15, 0, 45, 0);
                    break;
            }
            _num = value;
        }
    }

    public void Start()
    {
        _num = -9;
        for (int i = 0; i < 6; ++i)
        {
            var a = Instantiate(analogClockPrefab);
            a.transform.SetParent(this.transform,false);
            clocks[i] = a;
        }
    }

    private void Set(params int?[] time)
    {
        for (int index = 0; index < clocks.Length; index++)
        {
            clocks[index].Set(time[index*3 + 0], time[index*3 + 1], time[index*3 + 2]);
        }
    }
}