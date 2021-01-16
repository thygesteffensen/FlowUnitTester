﻿(**
WorkflowSyncDev
*)

#load @"_Config.fsx"
open _Config
open DG.Daxif
open DG.Daxif.Common.Utility

let workflowDll = Path.solutionRoot ++ @"Workflow\bin\Release\ILMerged.Delegate.DG.FlowUnitTester.Workflow.dll"

Workflow.Sync(Env.dev, workflowDll, SolutionInfo.name)
