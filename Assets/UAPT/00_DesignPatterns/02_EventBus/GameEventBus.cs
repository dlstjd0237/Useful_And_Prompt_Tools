using System.Collections.Generic;
using UnityEngine.Events;
public class GameEventBus : MonoSingleton<GameEventBus>
{
    private static readonly IDictionary<GameEventBusType, UnityEvent> Events = new Dictionary<GameEventBusType, UnityEvent>();

    /// <summary>
    /// 이벤트 구독
    /// </summary>
    /// <param name="gameEventType">어떤 타입의?</param>
    /// <param name="listener">어떤 메서드를?</param>
    public static void Subscribe(GameEventBusType gameEventType, UnityAction listener)
    {
        UnityEvent thisEvent;
        if (Events.TryGetValue(gameEventType, out thisEvent)) //이벤트 딕셔너리 안에 gameEventType 키값으로
                                                              //만들어진 UnityEvent가 있다면 UnityEvent에 받아온 액션 구독
        {
            thisEvent.AddListener(listener);
        }
        else // 이벤트 딕셔너리에 gameEventType의 키값으로 만들어진 UnityEvent가 없다면 
        {
            thisEvent = new UnityEvent(); // 새로운 UnityEvent를 만들어서
            thisEvent.AddListener(listener); //구독해주고
            Events.Add(gameEventType, thisEvent); // 이벤트 딕셔너리에 추가
        }
    }

    /// <summary>
    /// 이벤트 구독 해지
    /// </summary>
    /// <param name="gameEventType">어떤 타입의?</param>
    /// <param name="listener">어떤 메서드를?</param>
    public static void UnSubscribe(GameEventBusType gameEventType, UnityAction listener)
    {
        UnityEvent thisEvent;
        if (Events.TryGetValue(gameEventType, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    /// <summary>
    /// 타입 변경
    /// </summary>
    /// <param name="gameEventType">변결할 타입</param>
    public static void Publish(GameEventBusType gameEventType)
    {
        UnityEvent thisEvent;
        if (Events.TryGetValue(gameEventType, out thisEvent))
        {
            thisEvent?.Invoke();
        }
    }
}
