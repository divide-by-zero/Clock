using UnityEngine;
using UnityEngine.UI;

public class AnalogClock : MonoBehaviour {

    private int H { set; get; }
    private int M { set; get; }
    private int S { set; get; }

    public int? TH;
    public int? TM;
    public int? TS;

    public Image hImage;
    public Image mImage;
    public Image sImage;

    public Image[] bgImage;
    public bool isAnalog;

    public Sprite[] bgSprites;
    private float bgTransitionValue;
    private bool bgTransitionTarget;

    private void UpdateTime()
    {
        var hAngle = H * 30.0f;
        var mAngle = M * 6.0f;
        var sAngle = S * 6.0f;

        //厳密版
//        if (isAnalog)
//        {
//            hAngle += M * 0.5f + S * 0.1f;
//            mAngle += S * 0.1f;
//        }

        hImage.transform.localEulerAngles = new Vector3(0,0,-hAngle);
        mImage.transform.localEulerAngles = new Vector3(0,0,-mAngle);
        sImage.transform.localEulerAngles = new Vector3(0,0,-sAngle);
    }
    
    // Use this for initialization
	void Start ()
	{
        SetRandomSprite();
    }

    public void SetRandomSprite()
    {
        if (bgTransitionTarget)
        {
            bgImage[1].sprite = bgSprites.RandomAt();
        }
        else
        {
            bgImage[0].sprite = bgSprites.RandomAt();
        }
        bgTransitionTarget = !bgTransitionTarget;
    }

	// Update is called once per frame
	void Update ()
	{
	    if (bgTransitionTarget)
	    {
	        bgTransitionValue += Time.deltaTime;
	        if (bgTransitionValue > 1.0f) bgTransitionValue = 1.0f;
	    }
	    else
	    {
	        bgTransitionValue -= Time.deltaTime;
	        if (bgTransitionValue < 0.0f) bgTransitionValue = 0.0f;
	    }
        bgImage[0].color = new Color(0.5f,0.5f,0.5f,bgTransitionValue);
        bgImage[1].color = new Color(0.5f,0.5f,0.5f,1 - bgTransitionValue);

	    var time = System.DateTime.Now;
	    var th = TH ?? time.Hour % 12;
	    var tm = TM ?? time.Minute;
	    var ts = TS ?? time.Second;

        UpdateTime();

	    if (th != H || tm != M)
	    {
	        M++;
	        if (M > 60)
	        {
	            H++;
	            if (H >= 12) H = 0;
	            M = 0;
	        }
	    }
	    if (ts != S)
	    {
	        S++;
	        if (S > 60)
	        {
	            S = 0;
                SetRandomSprite();
	        }
	    }
	}

    public void Set(int? h, int? m,int? s)
    {
        SetRandomSprite();
        TH = h;
        TM = m;
        TS = s;

        if (!TH.HasValue && !TM.HasValue && !TS.HasValue)
        {
            hImage.color = new Color(0, 0, 0, 0.3f);
            mImage.color = new Color(0, 0, 0, 0.3f);
            sImage.color = new Color(0, 0, 0, 0.3f);
            isAnalog = true;
        }
        else
        {
            hImage.color = Color.red;
            mImage.color = Color.green;
            sImage.color = Color.blue;
            isAnalog = false;
        }
    }
}
