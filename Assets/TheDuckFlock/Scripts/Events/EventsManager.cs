using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    /// <summary>
    /// Implementation of Observer Pattern
    /// </summary>
    /// <typeparam name="CustomEvent">GamepadEvent or GameplayEvent enum</typeparam>
    /// <typeparam name="CustomListenerInterface">IGamepadEventsListener or IGameplayEventsListener interface</typeparam>
    public class EventsManager<CustomEvent, CustomListenerInterface, CustomParameterType> : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        public static CustomListenerInterface CurrentListeners 
        { 
            get 
            { 
                return currentListeners; 
            }  
            set 
            { 
                currentListeners = value; 
            }
        }

        private static Dictionary<CustomEvent, List<Action<CustomParameterType[]>>> listenersDictionary = new Dictionary<CustomEvent, List<Action<CustomParameterType[]>>>();
        private static CustomListenerInterface currentListeners;

        #region Public methods
        /// <summary>
        /// Registers listener for an event of type given in parameter
        /// </summary>
        /// <param name="eventType">One of GamepadEvent defined in GamepadEvent enum</param>
        /// <param name="callbackFunction"></param>
        public static void RegisterListener(CustomEvent eventType, Action<CustomParameterType[]> callbackFunction)
        {
            if (!listenersDictionary.ContainsKey(eventType))
            {
                listenersDictionary.Add(eventType, new List<Action<CustomParameterType[]>>());
            }

            listenersDictionary[eventType].Add(callbackFunction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType">One of GamepadEvents defined in GamepadEvent enum</param>
        /// <param name="callbackFunction"></param>
        public static void UnregisterListener(CustomEvent eventType, Action<CustomParameterType[]> callbackFunction)
        {
            if (!listenersDictionary.ContainsKey(eventType))
            {
                return;
            }

            if (!listenersDictionary[eventType].Contains(callbackFunction))
            {
                return;
            }

            listenersDictionary[eventType].Remove(callbackFunction);
        }

        /// <summary>
        /// Callbacks all of registered listeners about occurrence of an event given in the first parameter
        /// </summary>
        /// <param name="eventType">One of a GamepadEvents defined in GamepadEvent enum</param>
        /// <param name="dataValues"> dynamic values list of type int. Using by some of an eventTypes</param>
        public static void DispatchEvent(CustomEvent eventType, params CustomParameterType[] dataValues)
        {
            Debug.Log("EventsManager | Dispatch event: " + eventType);

            if (!listenersDictionary.ContainsKey(eventType))
            {
                return;
            }

            /* OLD
            foreach (Action<short> listener in listenersDictionary[eventType])
            {
                listener(value);
            }
            */

            List<Action<CustomParameterType[]>> actionsList = listenersDictionary[eventType];//.ForEach(e => e(value));
            //actionsList.ForEach(e => e(value));

            for (int i = 0; i < actionsList.Count; i++)
            {
                actionsList[i].Invoke(dataValues);
            }

        }
        #endregion
    }
}