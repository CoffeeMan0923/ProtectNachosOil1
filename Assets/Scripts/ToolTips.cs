using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTips : MonoBehaviour
{
    bool OilboyButton;
    bool BallonistButton;
    bool TruckCallerButton;
    bool FixFloorButton;
    bool SellTowerButton;
    [SerializeField] GameObject OilboyTooltip;
    [SerializeField] GameObject BallonistTooltip;
    [SerializeField] GameObject TruckCallerTooltip;
    [SerializeField] GameObject FixFloorTooltip;
    [SerializeField] GameObject SellTowerTooltip;
    public void OilboyTrue()
    {
        OilboyTooltip.SetActive(true);
        BallonistTooltip.SetActive(false);
        TruckCallerTooltip.SetActive(false);
        FixFloorTooltip.SetActive(false);
        SellTowerTooltip.SetActive(false);
    }
    public void BallonistTrue()
    {
        OilboyTooltip.SetActive(false);
        BallonistTooltip.SetActive(true);
        TruckCallerTooltip.SetActive(false);
        FixFloorTooltip.SetActive(false);
        SellTowerTooltip.SetActive(false);
    }
    public void TruckCallerTrue()
    {
        OilboyTooltip.SetActive(false);
        BallonistTooltip.SetActive(false);
        TruckCallerTooltip.SetActive(true);
        FixFloorTooltip.SetActive(false);
        SellTowerTooltip.SetActive(false);
    }
    public void FixFloorTrue()
    {
        OilboyTooltip.SetActive(false);
        BallonistTooltip.SetActive(false);
        TruckCallerTooltip.SetActive(false);
        FixFloorTooltip.SetActive(true);
        SellTowerTooltip.SetActive(false);
    }
    public void SellTowerTrue()
    {
        OilboyTooltip.SetActive(false);
        BallonistTooltip.SetActive(false);
        TruckCallerTooltip.SetActive(false);
        FixFloorTooltip.SetActive(false);
        SellTowerTooltip.SetActive(true);
    }
    public void Exited()
    {
        OilboyTooltip.SetActive(false);
        BallonistTooltip.SetActive(false);
        TruckCallerTooltip.SetActive(false);
        FixFloorTooltip.SetActive(false);
        SellTowerTooltip.SetActive(false);
    }
    void Update()
    {
        
    }
}
