using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerIntroduccion : MonoBehaviour
{
    public List<TextIntroduction> textosIntro;
    [SerializeField]
    TextIntroduction current;

    public int currIdx = 0;

    public bool started = false;

    PlayerControlCC_2 test;


    //public float currTimer = 0;
    //public float timeMaxText

    // Start is called before the first frame update
    void Start()
    {
        test = GameObject.FindObjectOfType<PlayerControlCC_2>();
        test.activeMovement = false;
        test.activeSitting = false;

        GameManagerActions.current.startIntroductionEvent.AddListener(this.StartSequence);
        GameManagerActions.current.startGameEvent.AddListener(this.DisableChildren);

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
        if (current == null)
        {
            this.currIdx = 0;
            this.current = textosIntro[currIdx];
            textosIntro[currIdx].gameObject.SetActive(true);
            this.started = true;
        }
    }

    public void DisableChildren()
    {
        foreach(var child in this.textosIntro)
        {
            child.gameObject.SetActive(false);
        }
    }
}
