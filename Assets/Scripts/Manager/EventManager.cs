using UnityEngine.Events;

public class EventManager
{
    private static EventManager _instance;

    public static EventManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EventManager();
            }
            return _instance;
        }
    }
    private UnityEvent gameStartEvent = new UnityEvent();
    private UnityEvent gameOverEvent = new UnityEvent();
    private UnityEvent gamePauseEvent = new UnityEvent();
    private UnityEvent gameResumeEvent = new UnityEvent();
    private UnityEvent gameRestartEvent = new UnityEvent();

    private GameManager gameManager;

    public void init(GameManager gameManager)
    {
        this.gameManager = gameManager;
        AddGameEventsListener();
    }
    private void AddGameEventsListener()
    {
        gameStartEvent.AddListener(gameManager.HandleGameStartEvent);
        gameOverEvent.AddListener(gameManager.HandleGameOverEvent);
        gamePauseEvent.AddListener(gameManager.HandleGamePauseEvent);
        gameResumeEvent.AddListener(gameManager.HandleGameResumeEvent);
        gameRestartEvent.AddListener(gameManager.HandleGameRestartEvent);
    }

    public void TriggerGameStartEvent() {
        gameStartEvent.Invoke();
    }

    public void TriggerGameOverEvent()
    {
        gameOverEvent.Invoke();
    }

    public void TriggerGamePauseEvent()
    {
        gamePauseEvent.Invoke();
    }

    public void TriggerGameResumeEvent()
    {
        gameResumeEvent.Invoke();
    }
    
    public void TriggerGameRestartEvent()
    {
        gameRestartEvent.Invoke();
    }
}
