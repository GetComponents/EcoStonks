using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventCard", menuName = "ScriptableObjects/EventCard", order = 1)]
public class EventCards : ScriptableObject
{
    public string MyText;
    public bool ContainsChoice;
    public bool Repeatable;
    public ESpeaker SpeakingCharacter;

    [Space]
    public float EmissionIncrease;
    public float MoneyIncrease;
    public float PassiveMoneyIncrease;
    public int NeededEnergy;
    public ETileType BuildTile;
    public ETileType DestroyTile;
    public ECardCondition CardCondition;
    public string ConditionAnswer;

    [Space]
    public float EmissionIncrease2;
    public float MoneyIncrease2;
    public float PassiveMoneyIncrease2;
    public int NeededEnergy2;
    public ETileType BuildTile2;
    public ETileType DestroyTile2;
    public ECardCondition CardCondition2;
    public string ConditionAnswer2;

    [Space]
    public int MonthAmountCondition;

    public void ShowCard()
    {
        EventUI.Instance.StartEvent(this);
    }

    public void TriggerEffect(bool VotedYes)
    {
        if (!ContainsChoice || VotedYes)
        {
            JanGameManager.Instance.Currency += MoneyIncrease;
            JanGameManager.Instance.TotalEmission += EmissionIncrease;
            JanGameManager.Instance.PassiveMoneyPerMonth += PassiveMoneyIncrease;
            JanGameManager.Instance.EnergyGoal += NeededEnergy;

            if (BuildTile != ETileType.NONE)
            {
                JanGameManager.Instance.SpawnTileRandomly(BuildTile);
            }

            if (DestroyTile != ETileType.NONE)
            {
                foreach (GridTile tile in FindObjectsOfType<GridTile>())
                {
                    if (tile.MyTile == DestroyTile)
                    {
                        tile.MyTile = ETileType.EMPTY;
                        if (!Repeatable)
                        {
                            switch (DestroyTile)
                            {
                                case ETileType.WOODS:
                                    JanGameManager.Instance.WoodEvents.Remove(this);
                                    break;
                                case ETileType.COALPP:
                                    JanGameManager.Instance.CoalEvents.Remove(this);
                                    break;
                                case ETileType.GASPP:
                                    JanGameManager.Instance.GasEvents.Remove(this);
                                    break;
                                case ETileType.WINDPP:
                                    JanGameManager.Instance.WindEvents.Remove(this);
                                    break;
                                case ETileType.SOLARPP:
                                    JanGameManager.Instance.SolarEvents.Remove(this);
                                    break;
                                case ETileType.WATERPP:
                                    JanGameManager.Instance.WaterEvents.Remove(this);
                                    break;
                                case ETileType.ATOMPP:
                                    JanGameManager.Instance.AtomEvents.Remove(this);
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    }
                }
            }

            if (!Repeatable)
            {
                JanGameManager.Instance.GetComponent<EventCardHolder>().EventCardPool.Remove(this);
            }
        }
        else
        {
            JanGameManager.Instance.Currency += MoneyIncrease2;
            JanGameManager.Instance.TotalEmission += EmissionIncrease2;
            JanGameManager.Instance.PassiveMoneyPerMonth += PassiveMoneyIncrease2;
            JanGameManager.Instance.EnergyGoal += NeededEnergy2;

            if (BuildTile2 != ETileType.NONE)
            {
                JanGameManager.Instance.SpawnTileRandomly(BuildTile2);
            }

            if (DestroyTile2 != ETileType.NONE)
            {
                foreach (GridTile tile in FindObjectsOfType<GridTile>())
                {
                    if (tile.MyTile == DestroyTile2)
                    {
                        tile.MyTile = ETileType.EMPTY;
                        if (!Repeatable)
                        {
                            switch (DestroyTile2)
                            {
                                case ETileType.WOODS:
                                    JanGameManager.Instance.WoodEvents.Remove(this);
                                    break;
                                case ETileType.COALPP:
                                    JanGameManager.Instance.CoalEvents.Remove(this);
                                    break;
                                case ETileType.GASPP:
                                    JanGameManager.Instance.GasEvents.Remove(this);
                                    break;
                                case ETileType.WINDPP:
                                    JanGameManager.Instance.WindEvents.Remove(this);
                                    break;
                                case ETileType.SOLARPP:
                                    JanGameManager.Instance.SolarEvents.Remove(this);
                                    break;
                                case ETileType.WATERPP:
                                    JanGameManager.Instance.WaterEvents.Remove(this);
                                    break;
                                case ETileType.ATOMPP:
                                    JanGameManager.Instance.AtomEvents.Remove(this);
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    }
                }
            }

            if (!Repeatable)
            {
                JanGameManager.Instance.GetComponent<EventCardHolder>().EventCardPool.Remove(this);
            }
        }
    }

    public bool CheckCondition()
    {
        if (DestroyTile != ETileType.NONE)
        {
            CheckForBuilding();
            return false;
        }
        switch (CardCondition)
        {
            case ECardCondition.NONE:
                return true;
            case ECardCondition.MONTHAMOUNT:
                JanGameManager.Instance.OnMonthChanged.AddListener(CheckForMonth);
                return false;
            default:
                break;
        }
        return false;
    }

    private void CheckForMonth()
    {
        if (MonthAmountCondition <= JanGameManager.Instance.monthCounter + (JanGameManager.Instance.cycleCounter * 6))
        {
            JanGameManager.Instance.GetComponent<EventCardHolder>().EventCardPool.Add(this);
            JanGameManager.Instance.OnMonthChanged.RemoveListener(CheckForMonth);
        }
    }

    private void CheckForBuilding()
    {
        switch (DestroyTile)
        {
            case ETileType.WOODS:
                JanGameManager.Instance.WoodEvents.Add(this);
                break;
            case ETileType.COALPP:
                JanGameManager.Instance.CoalEvents.Add(this);
                break;
            case ETileType.GASPP:
                JanGameManager.Instance.GasEvents.Add(this);
                break;
            case ETileType.WINDPP:
                JanGameManager.Instance.WindEvents.Add(this);
                break;
            case ETileType.SOLARPP:
                JanGameManager.Instance.SolarEvents.Add(this);
                break;
            case ETileType.WATERPP:
                JanGameManager.Instance.WaterEvents.Add(this);
                break;
            case ETileType.ATOMPP:
                JanGameManager.Instance.AtomEvents.Add(this);
                break;
            default:
                break;
        }
    }
}

public enum ECardCondition
{
    NONE,
    MONTHAMOUNT
}
