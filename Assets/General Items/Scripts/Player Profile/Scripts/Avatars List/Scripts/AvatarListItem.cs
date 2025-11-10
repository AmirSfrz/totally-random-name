using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarListItem : MonoBehaviour
{
    [SerializeField]
    private Image img;

    private int avatarIndex;

    private void Awake()
    {
        if (img == null) img = GetComponent<Image>();
    }
    public void Initialize(int avatarIndex)
    {
        img.sprite = GameData.instance.avatars[avatarIndex];

        this.avatarIndex = avatarIndex;
    }

    public void OnAvatarItemClicked()
    {
        SaveOrLoadManager.instance.PlayerAvatarIndex = avatarIndex;
    }
}
