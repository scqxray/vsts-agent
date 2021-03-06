﻿using Microsoft.TeamFoundation.DistributedTask.WebApi;
using System;

namespace Microsoft.VisualStudio.Services.Agent.Util
{
    public static class TaskResultUtil
    {
        private static readonly int _returnCodeOffset = 100;

        public static int TranslateToReturnCode(TaskResult result)
        {
            return _returnCodeOffset + (int)result;
        }

        public static TaskResult TranslateFromReturnCode(int returnCode)
        {
            int resultInt = returnCode - _returnCodeOffset;
            if (Enum.IsDefined(typeof(TaskResult), resultInt))
            {
                return (TaskResult)resultInt;
            }
            else
            {
                return TaskResult.Failed;
            }
        }

        // Merge 2 TaskResults get the worst result.
        // Succeeded -> SucceededWithIssues -> Failed/Canceled/Skipped/Abandoned
        // SucceededWithIssues -> Failed/Canceled/Skipped/Abandoned
        // Failed -> Failed
        // Canceled -> Canceled
        // Skipped -> Skipped
        // Abandoned -> Abandoned
        public static TaskResult MergeTaskResults(TaskResult? currentResult, TaskResult comingResult)
        {
            if (currentResult == null)
            {
                return comingResult;
            }

            // current result is Failed/Canceled/Skip/Abandoned
            if (currentResult >= TaskResult.Failed)
            {
                return currentResult.Value;
            }

            // comming result is bad than current result
            if (comingResult >= currentResult)
            {
                return comingResult;
            }

            return currentResult.Value;
        }
    }
}
