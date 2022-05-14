using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventUI : MonoBehaviour
{
    public static EventUI Instance;
    [SerializeField]
    TextMeshProUGUI myTextBubble;
    [SerializeField]
    GameObject ChoiceButtons, OkButtons, SpeechBubble, InfoBubble;

    public bool ContainsChoice;
    public string MyText;
    public ESpeaker Speaker;
    public EventCards CurrentEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void StartEvent(EventCards _currentEvent)
    {
        myTextBubble.text = _currentEvent.MyText;
        CurrentEvent = _currentEvent;
        if (!_currentEvent.ContainsChoice)
        {
            SpawnOKButton();
        }
        else
        {
            SpawnChoiceButton();
        }

        if (_currentEvent.SpeakingCharacter != ESpeaker.NONE)
        {
            SpawnCharacter(_currentEvent.SpeakingCharacter);
        }
        else
        {
            SpawnInfo();
        }
    }

    public void TriggerEvent(bool _votedYes)
    {
        CurrentEvent.TriggerEffect(_votedYes);
        myTextBubble.text = "";
        ChoiceButtons.SetActive(false);
        OkButtons.SetActive(false);
        SpeechBubble.SetActive(false);
        InfoBubble.SetActive(false);
    }

    private void SpawnOKButton()
    {
        ChoiceButtons.SetActive(false);
        OkButtons.SetActive(true);
    }

    private void SpawnChoiceButton()
    {
        ChoiceButtons.SetActive(true);
        OkButtons.SetActive(false);
    }

    private void SpawnCharacter(ESpeaker character)
    {
        switch (character)
        {
            case ESpeaker.NONE:
                break;
            case ESpeaker.MAYOR:
                break;
            case ESpeaker.ADMIRAL:
                break;
            case ESpeaker.CONSTRUCTOR:
                break;
            case ESpeaker.ACTIVIST:
                break;
            case ESpeaker.WOODPERSON:
                break;
            case ESpeaker.ANGRYPERSON:
                break;
            case ESpeaker.DEATH:
                break;
            default:
                break;
        }
        SpeechBubble.SetActive(true);
        InfoBubble.SetActive(false);
    }

    private void SpawnInfo()
    {
        SpeechBubble.SetActive(false);
        InfoBubble.SetActive(true);
    }
}

public enum ESpeaker
{
    NONE,
    MAYOR,
    ADMIRAL,
    CONSTRUCTOR,
    ACTIVIST,
    WOODPERSON,
    ANGRYPERSON,
    DEATH
}
