(**
Download flows from given solution
*)

#load @"_Config.fsx"
open _Config
open DG.Daxif
open DG.Daxif.Common.Utility
open System.IO.Compression

#if INTERACTIVE
#r @"System.IO.Compression"
#r @"System.IO.Compression.FileSystem"
#endif
open System.IO
open System.Net
open System.IO.Compression

let workflowPath = Path.solutionRoot ++ @"Tests\Workflows\"
let flowSolutionName = "FlowUnitTester"

let ExtractFlowsFromSolution =    
    let EmptyFolder =
        Directory.GetFiles(workflowPath , "*.*", SearchOption.AllDirectories) |> Array.iter (fun file -> File.Delete(file))

    let ExtractAndUnzip =
        EmptyFolder
        Solution.Export(Env.dev, flowSolutionName, workflowPath , false, true)
        use archive = ZipFile.Open(workflowPath + flowSolutionName + ".zip", ZipArchiveMode.Read)
        
        archive.ExtractToDirectory(workflowPath)
        
        archive.Dispose
    
    
    let OrgnaizeFiles =
        let moveOutOfSubFolder file =
            let fileName = Path.GetFileName(file)
            File.Move(file, workflowPath + "/" + fileName)
        
        let deleteNonFlows file = 
            match file with
            | file when file.ToString().EndsWith(".json") -> printf "Keeping: %s\n" file
                                                             moveOutOfSubFolder file
            //| file when file.ToString().EndsWith(".zip") -> printf "Keeping: %s\n" file
            | _ -> printf "Deleting: %s\n" file
                   File.Delete(file)
    
        Directory.GetFiles(workflowPath , "*.*", SearchOption.AllDirectories) |> Array.iter deleteNonFlows
        Directory.Delete(workflowPath + "/Workflows")

    OrgnaizeFiles

