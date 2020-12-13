using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManagerIntroduccion : MonoBehaviour
{

    public static ManagerIntroduccion instance { get; private set; }

    public List<TextIntroduction> textosIntro;
    [SerializeField]
    TextIntroduction current;

    public UnityEvent startIntroductionEvent;

    public int currIdx = 0;

    public bool started = false;

    //PlayerControlCC_2 test;


    //public float currTimer = 0;
    //public float timeMaxText

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
            instance = this;
        //instance.textosIntro = new List<TextIntroduction>();

    }
    void Start()
    {
        this.startIntroductionEvent.AddListener(this.StartSequence);
        //test = 
        //GameManagerActions.current.startIntroductionEvent.AddListener(this.StartSequence);


        //GameManagerActions.current.startGameEvent.AddListener(this.DisableChildren);

        

    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
            return;
        

        if (current.anyKey && Input.anyKeyDown)
        {

            PassNext();
        }
        else if (Input.GetKeyDown(current.requiredKey) && !current.anyKey)
        {
            print("cpakhskd");
            this.current.gameObject.SetActive(false);
            GameManagerActions.current.startGameEvent.Invoke();
        }
    }

    public void PassNext()
    {
        //if (currIdx + 1 < textosIntro.Count)
        //{
        currIdx++;
        this.current = textosIntro[currIdx];
        this.current.gameObject.SetActive(true);

        //}


        textosIntro[currIdx - 1].gameObject.SetActive(false);
    }

    public void StartSequence()
    {
        //if (current == null)
        //{
        this.currIdx = 0;
        this.current = textosIntro[currIdx];
        textosIntro[currIdx].gameObject.SetActive(true);
        this.started = true;
        //}
    }

    public void DisableChildren()
    {
        foreach (var child in this.textosIntro)
        {
            child.gameObject.SetActive(false);
        }
    }
}
