using System;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;

namespace FSM7_eventdriven
{
    public class MessageDispatcher {
        private static readonly MessageDispatcher _instance = new MessageDispatcher();
        public static MessageDispatcher Instance => _instance;

        private SortedDictionary<float, Telegram> prioritySD;

        public void Setup() {
            prioritySD = new SortedDictionary<float, Telegram>();
        }

        public void DispatchMessage(float delayTime, string senderName, string receiverName, string message) {
            BaseGameEntity receiver = EntityDatabase.Instance.GetEntityFromName(receiverName);
            if(receiver == null) {
                Debug.Log($"<color=red>Warning! No Receiver with ID of ‹b›<i>{receiverName}</i></b› found‹/color>");
                return;
            }

            Telegram telegram = new Telegram();
            telegram.SetTelegram(0, senderName, receiverName, message);

            if(delayTime <= 0.00001f) {
                Discharge(receiver, telegram);
            }
            else {
                //지연시간이 있는 메세지는 보내야 할 시간을 기록하여 prioritySD에 저장
                telegram.dispatchTime = Time.time + delayTime;
                //SortedDictionary에 저장되므로 자동정렬됨
                prioritySD.Add(telegram.dispatchTime, telegram);
            }
        }

        public void DispatchMessageImmidiately(string senderName, string receiverName, string message) {
            BaseGameEntity receiver = EntityDatabase.Instance.GetEntityFromName(receiverName);
            if(receiver == null) {
                Debug.Log($"<color=red>Warning! No Receiver with ID of ‹b›<i>{receiverName}</i></b› found‹/color>");
                return;
            }

            Telegram telegram = new Telegram();
            telegram.SetTelegram(0, senderName, receiverName, message);
            Discharge(receiver, telegram);
        }

        private void Discharge(BaseGameEntity receiver, Telegram telegram)
        {
            receiver.HandleMessage(telegram);
        }

        public void DispatchDelayedMessage() {
            // 현재 대기 중인 메세지중에 보낼 시간이 된 메세지를 발송함
            prioritySD.ForEach<KeyValuePair<float, Telegram>>(e => {
                if(e.Key <= Time.time) {
                    BaseGameEntity receiver = EntityDatabase.Instance.GetEntityFromName(e.Value.receiver);

                    Discharge(receiver, e.Value);
                    prioritySD.Remove(e.Key);

                    return;
                }
            });
        }
    }
}