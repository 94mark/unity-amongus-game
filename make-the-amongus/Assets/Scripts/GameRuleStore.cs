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
        StringBuilder sb = new StringBuilder(isRecommendRules ? "추천 설정\n" : "커스텀 설정\n");
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
