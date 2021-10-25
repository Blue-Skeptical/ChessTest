using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager MMM;

    [SerializeField] private GameObject Title;
    [SerializeField] private Button ToMenuButton;
    [SerializeField] private Button Exit;
    [SerializeField] private Button VsAIButton;
    [SerializeField] private Button VsFriendButton;
    [SerializeField] private PostProcessVolume TransitionPostProcess;

    void Awake()
    {   //Singleton
        if (MMM == null) MMM = this;
        else if (MMM != this) Destroy(gameObject);
    }
    
    //Begin a match against AI
    public void vsAI()
    {
        //Activate the transition
        StartCoroutine(BeginTransitionToGame(1f));
        //Deactivate the buttons
        VsAIButton.gameObject.SetActive(false);
        VsFriendButton.gameObject.SetActive(false);
        ToMenuButton.gameObject.SetActive(true);
        Title.SetActive(false);
        Exit.gameObject.SetActive(false);
        //Tell to Manager to start a match against AI
        MatchManager.MM.MatchBegin(true, false);
    }

    //Begin a match against a player
    public void vsFriend()
    {
        //Activate the transition
        StartCoroutine(BeginTransitionToGame(1f));
        //Deactivate the buttons
        VsAIButton.gameObject.SetActive(false);
        VsFriendButton.gameObject.SetActive(false);
        ToMenuButton.gameObject.SetActive(true);
        Title.SetActive(false);
        Exit.gameObject.SetActive(false);
        //Tell the manager to start a match with both players humans
        MatchManager.MM.MatchBegin(true, true);
    }
    
    //In-Game "To Menu" button
    public void ToMenu()
    {
        //Activate the transition
        StartCoroutine(BeginTransitionToMenu(0.8f));
        //Tell the Manager that the match is over
        MatchManager.MM.EndMatch();
        //Reactivate the buttons
        VsFriendButton.gameObject.SetActive(true);
        VsAIButton.gameObject.SetActive(true);
        ToMenuButton.gameObject.SetActive(false);
        Title.SetActive(true);
        Exit.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    //Deactivate the MainMenuPostProcess Profile
    private IEnumerator BeginTransitionToGame(float seconds)
    {
        float i = 0;
        while (i < seconds)
        {
            TransitionPostProcess.weight = (seconds - i) / seconds;
            yield return new WaitForSeconds(0.02f);
            i+=0.02f;
        }
        TransitionPostProcess.weight = 0;

    }

    //Activate the MainMenuPostProcess Profile
    private IEnumerator BeginTransitionToMenu(float seconds)
    {
        float i = 0;
        while (i < seconds)
        {
            TransitionPostProcess.weight = i / seconds;
            yield return new WaitForSeconds(0.02f);
            i += 0.02f;
        }
        TransitionPostProcess.weight = 1;

    }
}
