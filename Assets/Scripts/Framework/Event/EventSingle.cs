using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts.Framework.Event
{
    public class EventSingle : Singleton<EventSingle>
    {
        //key 对应的是事件的名字
        //value 对应的是监听这个事件对应的委托函数们
        private Dictionary<EventDefine, Delegate> eventDic = 
            new Dictionary<EventDefine, Delegate>();


        /// <summary>
        /// 添加事件监听
        /// </summary>
        /// <param name="define">事件定义</param>
        /// <param name="action">准备用来处理事件的委托函数</param>
        public void AddListener<T>(EventDefine define, Action<T> action) where T : IEventArgs
        {
            //判断字典里有没有对应这个事件，有就执行，没有就加进去。
            if (eventDic.ContainsKey(define))
            {
                eventDic[define] = Delegate.Combine(eventDic[define], action);
            }
            else
            {
                eventDic.Add(define, action);
            }
        }

        public void AddListener(EventDefine define, Action action)
        {
            // 将无参委托函数包装成带参数的委托函数
            Action<IEventArgs> handler = (args) => action();
            // 调用泛型 AddListener 方法
            AddListener(define, handler);
        }

        /// <summary>
        /// 移除事件监听者
        /// </summary>
        /// <param name="define">事件</param>
        /// <param name="action">委托函数</param>
        public void RemoveListener<T>(EventDefine define, Action<T> action) where T : IEventArgs
        {
            if (eventDic.ContainsKey(define))
            {
                eventDic[define] = Delegate.Remove(eventDic[define], action);
            }
        }

        public void RemoveListener(EventDefine define, Action action)
        {
            // 将无参委托函数包装成带参数的委托函数
            Action<IEventArgs> handler = (args) => action();
            // 调用泛型 AddListener 方法
            RemoveListener(define, handler);
        }

        /// <summary>
        /// 清空事件中心，主要用于场景切换
        /// </summary>
        public void Clear()
        {
            eventDic.Clear();
        }

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="define">发送的事件定义</param>
        public void SendEvent(EventDefine define, IEventArgs info = default)
        {
            if (eventDic.ContainsKey(define))
            {
                var action = eventDic[define] as Action<IEventArgs>;
                if (action != null)
                {
                    action.Invoke(info);
                }
            }
        }
    }
}
