using System;
using System.Collections.Generic;

namespace AccountFactory
{
    public class StateMachine
    {
        public Type CurrentState;
        public Type LastState;

        private readonly Dictionary<Type, AbstractState> stateDict = new Dictionary<Type, AbstractState>();

        public void AddState(AbstractState state)
        {
            if (CurrentState == null)
                CurrentState = state.GetType();
            stateDict.Add(state.GetType(), state);
        }

        public void RemoveState(AbstractState state)
        {
            stateDict.Remove(state.GetType());
        }

        public void Clear()
        {
            CurrentState = null;
            LastState = null;
            stateDict.Clear();
        }

        public void Execute()
        {
            if (LastState != null)
                stateDict[LastState].OnExit();

            stateDict[CurrentState].OnEnter();

            LastState = CurrentState;
        }

        public void SetNextState(Type nextState)
        {
            CurrentState = nextState;
        }
    }
}
