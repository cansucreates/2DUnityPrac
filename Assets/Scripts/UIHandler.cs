using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    // npc dialog variables
    public float displayTime = 4.0f;
    private VisualElement m_NonPlayerDialogue;
    private float m_TimerDisplay;
    public static UIHandler instance { get; private set; } // static instance of the UIHandler class
    private VisualElement m_HealthBar;

    private void Awake() // called when the script instance is being loaded
    {
        instance = this; // set the static instance to this instance
    }

    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_HealthBar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealthValue(1.0f);

        m_NonPlayerDialogue = uiDocument.rootVisualElement.Q<VisualElement>("NPCDialogue");
        m_NonPlayerDialogue.style.display = DisplayStyle.None;
        m_TimerDisplay = -1.0f;
    }

    public void SetHealthValue(float percentage)
    {
        m_HealthBar.style.width = Length.Percent(percentage * 100);
    }

    // update the timer for the npc dialog
    private void Update()
    {
        if (m_TimerDisplay > 0)
        {
            m_TimerDisplay -= Time.deltaTime;
            if (m_TimerDisplay < 0)
            {
                m_NonPlayerDialogue.style.display = DisplayStyle.None;
            }
        }
    }

    public void DisplayDialogue()
    {
        m_NonPlayerDialogue.style.display = DisplayStyle.Flex;
        m_TimerDisplay = displayTime;
    }
}
