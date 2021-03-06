﻿using UnityEngine;

[System.Serializable]
public class FactoryData {

    [Tooltip("工場名")]
    public string factoryName;
    public int factoryRank;
    [SerializeField]
    public bool canBuild;
    [Range(1, 100), Tooltip("建設コスト")]
    public int constructionCost;

    public FactoryStatusData[] factoryStatus;
}
