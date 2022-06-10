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
    public int commonTask;
    public int complexTask;
    public int simpleTask;
}

public class GameRuleStore : NetworkBehaviour
{
    [SyncVar(hook = nameof(SetIsRecommendRule_Hook))]
    private bool isRecommendRule;
    [SerializeField]
    private Toggle isRecommendRuleToggle;
    public void SetIsRecommendRule_Hook(bool _, bool value)
    {
        UpdateGameRuleOverview();
    }

    [SyncVar(hook = nameof(SetConfirmEjects_Hook))]
    private bool confirmEjects;
    [SerializeField]
    private Toggle confirmEjectsToggles;
    public void SetConfirmEjects_Hook(bool _, bool value)
    {
        UpdateGameRuleOverview();
    }

    [SyncVar]
    private int emergencyMeetings;
    [SerializeField]
    private Text emergencyMeetingsText;
    public void SetEmergencyMeetings_Hook(int _, int value)
    {
        emergencyMeetingsText.text = value.ToString();
        UpdateGameRuleOverview();
    }

    [SyncVar(hook = nameof(SetEmergencyMeetingCooldown_Hook))]
    private int emergencyMeetingsCooldown;
    [SerializeField]
    private Text emergencyMeetingsCooldownText;
    public void SetEmergencyMeetingCooldown_Hook(int _, int value)
    {
        emergencyMeetingsCooldownText.text = string.Format("{0}s", emergencyMeetingsCooldown);
        UpdateGameRuleOverview();
    }

    [SyncVar(hook = nameof(SetMeetingsTime_Hook))]
    private int meetingsTime;
    [SerializeField]
    private Text meetingsTimeText;
    public void SetMeetingsTime_Hook(int _, int value)
    {
        meetingsTimeText.text = string.Format("{0}s", value);
        UpdateGameRuleOverview();
    }

    [SyncVar(hook = nameof(SetVoteTime_Hook))]
    private int voteTimes;
    [SerializeField]
    private Text voteTimeText;
    public void SetVoteTime_Hook(int _, int value)
    {
        voteTimeText.text = string.Format("{0}s", value);
        UpdateGameRuleOverview();
    }

    [SyncVar(hook = nameof(SetAnonymousVotes_Hook))]
    private bool anonymousVotes;
    [SerializeField]
    private Toggle anonymouseVotesToggle;
    public void SetAnonymousVotes_Hook(bool _, bool value)
    {
        UpdateGameRuleOverview();
    }

    [SyncVar(hook = nameof(SetMoveSpeed_Hook))]
    private float moveSpeed;
    [SerializeField]
    private Text moveSpeedText;
    public void SetMoveSpeed_Hook(float _, float value)
    {
        moveSpeedText.text = string.Format("{0:0:0}x", value);
        UpdateGameRuleOverview();
    }

    [SyncVar(hook = nameof(SetCrewSight_Hook))]
    private float crewSight;
    [SerializeField]
    private Text crewSightText;
    public void SetCrewSight_Hook(float _, float value)
    {
        crewSightText.text = string.Format("{0:0:0}x", value);
        UpdateGameRuleOverview();
    }

    [SyncVar(hook = nameof(SetImposterSight_Hook))]
    private float imposterSight;
    [SerializeField]
    private Text imposterSightText;
    public void SetImposterSight_Hook(float _, float value)
    {
        imposterSightText.text = string.Format("{0:0:0}x", value);
        UpdateGameRuleOverview();
    }

    [SyncVar(hook = nameof(SetKillCooldown_Hook))]
    private float killCooldown;
    [SerializeField]
    private Text killCooldownText;
    public  void SetKillCooldown_Hook(float _, float value)
    {
        killCooldownText.text = string.Format("{0:0:0}s", value);
        UpdateGameRuleOverview();
    }

    [SyncVar(hook = nameof(SetKillRange_Hook))]
    private EKillRange killRange;
    [SerializeField]
    private Text killRangeText;
    public void SetKillRange_Hook(EKillRange _, EKillRange value)
    {
        killRangeText.text = value.ToString();
        UpdateGameRuleOverview();
    }

    [SyncVar(hook = nameof(SetVisualTasks_Hook))]
    private bool visualTasks;
    [SerializeField]
    private Toggle visualTasksToggle;
    public void SetVisualTasks_Hook(bool _, bool value)
    {
        UpdateGameRuleOverview();
    }

    [SyncVar(hook = nameof(SetTaskBarUpdates_Hook))]
    private ETaskBarUpdates taskBarUpdates;
    [SerializeField]
    private Text taskBarUpdatesText;
    public void SetTaskBarUpdates_Hook(ETaskBarUpdates _, ETaskBarUpdates value)
    {
        taskBarUpdatesText.text = value.ToString();
        UpdateGameRuleOverview();
    }

    [SyncVar(hook = nameof(SetCommonTask_Hook))]
    private int commonTask;
    [SerializeField]
    private Text commonTaskText;
    public void SetCommonTask_Hook(int _, int value)
    {
        commonTaskText.text = value.ToString();
        UpdateGameRuleOverview();
    }

    [SyncVar(hook = nameof(SetComplexTask_Hook))]
    private int complexTask;
    [SerializeField]
    private Text complexTaskText;
    public void SetComplexTask_Hook(int _, int value)
    {
        complexTaskText.text = value.ToString();
        UpdateGameRuleOverview();
    }

    [SyncVar(hook = nameof(SetSimpleTask_Hook))]
    private int simpleTask;
    [SerializeField]
    private Text simpleTaskText;
    public void SetSimpleTask_Hook(int _, int value)
    {
        simpleTaskText.text = value.ToString();
        UpdateGameRuleOverview();
    }

    [SerializeField]
    private Text gameRuleOverview;

    private void UpdateGameRuleOverview()
    {
        var manager = NetworkManager.singleton as AmongUsRoomManager;
        StringBuilder sb = new StringBuilder(isRecommendRule ? "��õ ����\n" : "Ŀ���� ����\n");
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
        sb.Append($"���� �ӹ� : {commonTask}\n");
        sb.Append($"������ �ӹ� : {complexTask}\n");
        sb.Append($"������ �ӹ� : {simpleTask}\n");
        gameRuleOverview.text = sb.ToString();
    }

    private void SetRecommendGameRule()
    {
        isRecommendRule = true;
        confirmEjects = true;
        emergencyMeetings = 1;
        emergencyMeetingsCooldown = 15;
        meetingsTime = 15;
        voteTimes = 120;
        moveSpeed = 1f;
        crewSight = 1f;
        imposterSight = 1.5f;
        killCooldown = 45f;
        killRange = EKillRange.Normal;
        visualTasks = true;
        commonTask = 1;
        complexTask = 1;
        simpleTask = 2;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(isServer)
        {
            SetRecommendGameRule();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
