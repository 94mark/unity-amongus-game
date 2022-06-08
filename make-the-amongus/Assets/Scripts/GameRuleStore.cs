using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using System.Text;

public enum EKillRange
{
    Short, Normal, Long
}

public enum ETaskBarUpdates
{
    Always, Meetings, Never
}

public struct GameRuleData
{
    public bool confirmEjects;
    public int emergencyMeetings;
    public int emergencyMeetingsCooldown;
    public int meetingsTime;
    public int voteTimes;
    public bool anonymousVotes;
    public float moveSpeed;
    public float crewSight;
    public float imposterSight;
    public float killCooldown;
    public EKillRange killRange;
    public bool visualTasks;
    public ETaskBarUpdates taskBarUpdates;
    public int commonTasks;
    public int complexTask;
    public int simpleTask;
}

public class GameRuleStore : NetworkBehaviour
{
    [SyncVar]
    private bool isRecommendRules;
    [SerializeField]
    private Toggle isRecommendRuleToggle;
    [SyncVar]
    private bool confirmEjects;
    [SerializeField]
    private Toggle confirmEjectsToggles;
    [SyncVar]
    private int emergencyMeetings;
    [SerializeField]
    private Text emergencyMeetingsText;
    [SyncVar]
    private int emergencyMeetingsCooldown;
    [SerializeField]
    private Text emergencyMeetingsCooldownText;
    [SyncVar]
    private int meetingsTime;
    [SerializeField]
    private Text meetingsTimeText;
    [SyncVar]
    private int voteTimes;
    [SerializeField]
    private Text voteTimeText;
    [SyncVar]
    private bool anonymousVotes;
    [SyncVar]
    private float moveSpeed;
    [SerializeField]
    private Text moveSpeedText;
    [SyncVar]
    private float crewSight;
    [SerializeField]
    private Text crewSightText;
    [SyncVar]
    private float imposterSight;
    [SerializeField]
    private Text imposterSightText;
    [SyncVar]
    private float killCooldown;
    [SerializeField]
    private Text killCooldownText;
    [SyncVar]
    private EKillRange killRange;
    [SerializeField]
    private Text killRangeText;
    [SyncVar]
    private bool visualTasks;
    [SerializeField]
    private Toggle visualTasksToggle;
    [SyncVar]
    private ETaskBarUpdates taskBarUpdates;
    [SerializeField]
    private Text taskBarUpdatesText;
    [SyncVar]
    private int commonTasks;
    [SerializeField]
    private Text commonTaskText;
    [SyncVar]
    private int complexTask;
    [SerializeField]
    private Text complexTaskText;
    [SyncVar]
    private int simpleTask;
    [SerializeField]
    private Text simpleTaksText;

    [SerializeField]
    private Text gameRuleOverview;

    private void UpdateGameRuleOverview()
    {
        var manager = NetworkManager.singleton as AmongUsRoomManager;
        StringBuilder sb = new StringBuilder(isRecommendRules ? "��õ ����\n" : "Ŀ���� ����\n");
        sb.Append("�� : The SKeId\n");
        sb.Append($"#�������� : {manager.imposterCount}\n");
        sb.Append(string.Format("Confirm Ejects : {0}\n", confirmEjects ? "����" : "����"));
        sb.Append($"��� ȸ�� : {emergencyMeetings}\n");
        sb.Append(string.Format("Anonymous Votes : {0}\n", anonymousVotes ? "����" : "����"));
        sb.Append($"��� ȸ�� ��Ÿ�� : {emergencyMeetingsCooldown}\n");
        sb.Append($"ȸ�� ���� �ð� : {meetingsTime}\n");
        sb.Append($"��ǥ ���� �ð� : {voteTimes}\n");
        sb.Append($"�̵� �ӵ� : {moveSpeed}\n");
        sb.Append($"ũ��� �þ� : {crewSight}\n");
        sb.Append($"�������� �þ� : {imposterSight}\n");
        sb.Append($"ų ��Ÿ�� : {killCooldown}\n");
        sb.Append($"ų ���� : {killRange}\n");
        sb.Append($"Task Bar Updates : {taskBarUpdates}\n");
        sb.Append(string.Format("Visual Tasks : {0}\n", visualTasks ? "����" : "����"));
        sb.Append($"���� �ӹ� : {commonTasks}\n");
        sb.Append($"������ �ӹ� : {complexTask}\n");
        sb.Append($"������ �ӹ� : {simpleTask}\n");
        gameRuleOverview.text = sb.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
