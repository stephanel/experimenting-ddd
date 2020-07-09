using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExperimentingDDD.Domains.DomainEvents
{
    public class DomainEventsHandler
    {
        [ThreadStatic]
        private static List<Delegate> _actions;

        public static void Register<T>(Action<T> callback)
            where T : IDomainEvent
        {
            if(_actions == null)
            {
                _actions = new List<Delegate>();
            }

            _actions.Add(callback);
        }

        public static void ClearCallbacks()
        {
            _actions = null;
        }

        public static void Raise<T>(T args)
            where T : IDomainEvent
        {
            if(_actions != null)
            {
                foreach(var action in _actions)
                {
                    if(action is Action<T>)
                    {
                        ((Action<T>)action)(args);
                    }
                }
            }
        }
    }
}