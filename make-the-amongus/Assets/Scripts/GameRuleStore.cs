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

    [SyncVar(hook = nameof(SetVisualTasks_Hook))]
    private bool visualTasks;
    [SerializeField]
    private Toggle visualTasksToggle;
    public void SetVisualTasks_Hook(bool _, bool value)
    {
        UpdateGameRuleOverview();
    }

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
        StringBuilder sb = new StringBuilder(isRecommendRule ? "추천 설정\n" : "커스텀 설정\n");
        sb.Append("맵 : The SKeId\n");
        sb.Append($"#임포스터 : {manager.imposterCount}\n");
        sb.Append(string.Format("Confirm Ejects : {0}\n", confirmEjects ? "켜짐" : "꺼짐"));
        sb.Append($"긴급 회의 : {emergencyMeetings}\n");
        sb.Append(string.Format("Anonymous Votes : {0}\n", anonymousVotes ? "켜짐" : "꺼짐"));
        sb.Append($"긴급 회의 쿨타임 : {emergencyMeetingsCooldown}\n");
        sb.Append($"회의 제한 시간 : {meetingsTime}\n");
        sb.Append($"투표 제한 시간 : {voteTimes}\n");
        sb.Append($"이동 속도 : {moveSpeed}\n");
        sb.Append($"크루원 시야 : {crewSight}\n");
        sb.Append($"임포스터 시야 : {imposterSight}\n");
        sb.Append($"킬 쿨타임 : {killCooldown}\n");
        sb.Append($"킬 범위 : {killRange}\n");
        sb.Append($"Task Bar Updates : {taskBarUpdates}\n");
        sb.Append(string.Format("Visual Tasks : {0}\n", visualTasks ? "켜짐" : "꺼짐"));
        sb.Append($"공통 임무 : {commonTasks}\n");
        sb.Append($"복잡한 임무 : {complexTask}\n");
        sb.Append($"간단한 임무 : {simpleTask}\n");
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
        commonTasks = 1;
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
