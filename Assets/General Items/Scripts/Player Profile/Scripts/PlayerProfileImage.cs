using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfileImage : MonoBehaviour
{
    [SerializeField]
    private Image playerImage;

    private void Awake()
    {
        if(playerImage == null)
        {
            playerImage = GetComponent<Image>();
        }
    }

    private void Start()
    {
        SetProfileImg(SaveOrLoadManager.instance.PlayerAvatarIndex);

        // set the event
        SaveOrLoadManager.instance.OnPlayerAvatarUpdated.AddListener(SetProfileImg);
    }

    private void SetProfileImg(int avatarIndex)
    {
        Sprite profileImage= GameData.instance.avatars[avatarIndex];

        playerImage.sprite = profileImage;
    }
}
