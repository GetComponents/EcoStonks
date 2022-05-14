using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventUI : MonoBehaviour
{
    public static EventUI Instance;
    [SerializeField]
    TextMeshProUGUI myTextBubble;
    [SerializeField]
    GameObject ChoiceButtons, OkButtons, SpeechBubble, InfoBubble, CharacterSprite;

    public bool ContainsChoice;
    public string MyText;
    public ESpeaker Speaker;
    public EventCards CurrentEvent;

    [SerializeField]
    Sprite MayorSprite, AdmiralSprite, BuilderSprite, KarenSprite, RangerSprite, ReporterSprite, DeathSprite, ActivistSprite;

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
        Time.timeScale = 0;
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
        Time.timeScale = 1;
        CurrentEvent.TriggerEffect(_votedYes);
        myTextBubble.text = "";
        ChoiceButtons.SetActive(false);
        OkButtons.SetActive(false);
        SpeechBubble.SetActive(false);
        InfoBubble.SetActive(false);
        CharacterSprite.SetActive(false);
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
        CharacterSprite.SetActive(true);
        switch (character)
        {
            case ESpeaker.NONE:
                break;
            case ESpeaker.MAYOR:
                CharacterSprite.GetComponent<Image>().sprite = MayorSprite;
                break;
            case ESpeaker.ADMIRAL:
                CharacterSprite.GetComponent<Image>().sprite = AdmiralSprite;
                break;
            case ESpeaker.CONSTRUCTOR:
                CharacterSprite.GetComponent<Image>().sprite = BuilderSprite;
                break;
            case ESpeaker.ACTIVIST:
                CharacterSprite.GetComponent<Image>().sprite = ActivistSprite;
                break;
            case ESpeaker.WOODPERSON:
                CharacterSprite.GetComponent<Image>().sprite = RangerSprite;
                break;
            case ESpeaker.ANGRYPERSON:
                CharacterSprite.GetComponent<Image>().sprite = KarenSprite;
                break;
            case ESpeaker.DEATH:
                CharacterSprite.GetComponent<Image>().sprite = DeathSprite;
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
    DEATH,
    NEWSANCHOR
}
