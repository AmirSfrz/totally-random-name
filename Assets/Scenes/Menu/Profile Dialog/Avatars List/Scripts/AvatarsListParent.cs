using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarsListParent : MonoBehaviour
{
    [SerializeField]
    private RectTransform avatarsListRectTransform;

    [SerializeField]
    private AvatarListItem AvatarListItemPrefab;

    private void Start()
    {
        for (int i = 0; i < GameData.Instance.avatars.Length; i++)
        {
            AvatarListItem newItem = Instantiate(AvatarListItemPrefab, avatarsListRectTransform);
            newItem.Initialize(i);
        }
    }
}
