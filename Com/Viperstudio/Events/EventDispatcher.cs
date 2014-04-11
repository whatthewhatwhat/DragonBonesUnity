// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Com.Viperstudio.Events
{

  public class EventDispatcher 
	
	{
	
		public delegate void EventHandler (Com.Viperstudio.Events.Event e);
	
		private Dictionary<string, EventHandler> events;

		public string Name;

		public void AddEventListener(string eventType, EventHandler function)
		{
		
			if (events == null) 
			{

				events = new Dictionary<string, EventHandler>();

			} 

			if(!events.ContainsKey(eventType))
			{
				events.Add(eventType, function);
			}
			else
			{
				Delegate[] delegates = events[eventType].GetInvocationList();
				for (int i = 0; i < delegates.Length; i++)
				{
					if(delegates[i] == function)
					{
						Debug.Log ("EventDispatcher: Same function added to one event.");
						return;
					}
				}
				events[eventType] += function;
			}

		}

		public void RemoveEventListener(string eventType, EventHandler function)
		{
			if (events == null) {
				return;
			} 
			else 
			{
				if (!events.ContainsKey (eventType)) 
				{
					return;
				} 
				else 
				{
					Delegate[] delegates = events[eventType].GetInvocationList();
					for (int i = 0; i < delegates.Length; i++)
					{
						if(delegates[i] == function)
						{
							events[eventType] -= function;
							break;
						}
					}
					if(events [eventType] == null)
					{
						events.Remove(eventType);
					}
				}
			}
		}
	
		public void DispatchEvent(Com.Viperstudio.Events.Event e)
		{

			e.Target = this;

			if (events == null) 
			{
				return;
			} 
			else 
			{
				if (!events.ContainsKey (e.EventType)) 
				{
					return;
 				} 
				else
				{
					events[e.EventType](e);
				}
			}
		}
		//TODO:add logic
		public bool HasEventListener(string eventType)
		{
			if (this.events == null) {
				return false;
						}
			else if (this.events.ContainsKey (eventType))
								return true;
						else
								return false;
		}
	}
}