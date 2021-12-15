using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WW.Patterns
{
    public class TimeBasedReplayCommandManager : MonoBehaviour
    {        
        private SortedList<float, ICommand> commandBuffer = new SortedList<float, ICommand>();

        public bool isRecording { get; private set; }
        public bool isReplaying { get; private set; }

        private float recordingTime;
        private float replayTime;        

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();

            if (isRecording)
                commandBuffer.Add(recordingTime, command);                   
        }

        public void StartRecording()
        {
            recordingTime = 0.0f;
            isRecording = true;
        }

        public void StopRecording()
        {
            isRecording = false;
        }
        

        public void StartReplaying()
        {
            StopRecording();

            UndoAllCommands();                      

            replayTime = 0.0f;
            isReplaying = true;
        }

        SortedList<float, ICommand> GetReversedCommandBuffer()
        {
            if (commandBuffer == null || commandBuffer.Count <= 0) return new SortedList<float, ICommand>();

            var descendingComparer = Comparer<float>.Create((x, y) => y.CompareTo(x));
            var reversedCommandBuffer = new SortedList<float, ICommand>(descendingComparer);
            foreach (var command in commandBuffer)
            {
                reversedCommandBuffer.Add(command.Key, command.Value);
            }

            return reversedCommandBuffer;
        }

        private void UndoAllCommands()
        {
            var reversedCommandBuffer = GetReversedCommandBuffer();

            foreach (var command in reversedCommandBuffer)
            {
                command.Value.Undo();
            }
        }

        public void StopReplaying()
        {
            isReplaying = false;
        }

        void FixedUpdate()
        {
            if (isRecording)
            {
                recordingTime += Time.fixedDeltaTime;
                return;
            }

            if (!isReplaying) return;
            
            replayTime += Time.deltaTime;

            if (!commandBuffer.Any())
            {                
                StopReplaying();
                return;
            }

            if (Mathf.Approximately(replayTime, commandBuffer.Keys[0]))
            {
                commandBuffer.Values[0].Execute();
                commandBuffer.RemoveAt(0);
            }
        }

        public void Reset()
        {
            UndoAllCommands();
            StopRecording();
            StopReplaying();
            commandBuffer.Clear();
        }
    }
}