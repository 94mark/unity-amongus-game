using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class CustomizeUI : MonoBehaviour
{
    [SerializeField]
    private Image characterPreview;

    [SerializeField]
    private List<ColorSelectButton> colorSelectButtons;
    // Start is called before the first frame update
    void Start()
    {
        var inst = Instantiate(characterPreview.material);
        characterPreview.material = inst;
    }

    private void OnEnable()
    {
        UpdateColorButton();

        var roomSlots = (NetworkManager.singleton as AmongUsRoomManager).roomSlots;
        foreach(var player in roomSlots)
        {
            var aPlayer = player as AmongUsRoomPlayer;
            if(aPlayer.isLocalPlayer)
            {
                UpdatePreviewColor(aPlayer.playerColor);
                break;
            }
        }
    }

    public void UpdateColorButton()
    {
        var roomSlots = (NetworkManager.singleton as AmongUsRoomManager).roomSlots;

        for (int i = 0; i < colorSelectButtons.Count; i++)
        {
            colorSelectButtons[i].SetInteractable(true);
        }
        foreach(var player in roomSlots)
        {
            var aPlayer = player as AmongUsRoomPlayer;
            colorSelectButtons[(int)aPlayer.playerColor].SetInteractable(false);
        }
    }

    public void UpdatePreviewColor(EPlayerColor color)
    {
        characterPreview.material.SetColor("_PlayerColor", PlayerColor.GetColor(color));
    }
}
