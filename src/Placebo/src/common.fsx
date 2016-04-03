module Common

#r "packages/FAKE/tools/FakeLib.dll"

open System
open System.IO
open System.Text.RegularExpressions
open Fake
open Fake.ConfigurationHelper
open Fake.ReleaseNotesHelper
open Fake.StrongNamingHelper

let outDir = "./../out"
let testDir = outDir @@ "test"
let buildDir = outDir @@ "build"
let releaseDir = outDir @@ "release"
let secretFile = "../.secrets"
let releaseNotes = "../CHANGES.md" |> LoadReleaseNotes

let testFile fn = (fileInfo fn).Exists
let secret key =
    match testFile secretFile with
    | false -> None
    | _ ->
        try
            let xml = readConfig secretFile
            let xpath = sprintf "/secret/%s" key
            let node = xml.SelectSingleNode(xpath)
            node.InnerText |> Some
        with _ -> None

let assemblyVersionRxDef =
    [
        """(?<=^\s*\[assembly:\s*AssemblyVersion(Attribute)?\(")[0-9]+(\.([0-9]+|\*)){1,3}(?="\))""", false, false
        """(?<=^\s*PRODUCTVERSION\s+)[0-9]+(\,([0-9]+|\*)){1,3}(?=\s*$)""", false, true
        """(?<=^\s*VALUE\s+"ProductVersion",\s*")[0-9]+(\.([0-9]+|\*)){1,3}(?="\s*$)""", false, false
        """(?<=^\s*\[assembly:\s*AssemblyFileVersion(Attribute)?\(")[0-9]+(\.([0-9]+|\*)){1,3}(?="\))""", true, false
        """(?<=^\s*FILEVERSION\s+)[0-9]+(\,([0-9]+|\*)){1,3}(?=\s*$)""", true, true
        """(?<=^\s*VALUE\s+"FileVersion",\s*")[0-9]+(\.([0-9]+|\*)){1,3}(?="\s*$)""", true, false
    ] |> List.map (fun (rx, p, c) -> (Regex(rx, RegexOptions.Multiline), p, c))

let updateVersionInfo productVersion (version: string) fileName =
    let fixVersion commas =
        match commas with | true -> version.Replace(".", ",") | _ -> version

    let allRx =
        assemblyVersionRxDef
        |> Seq.filter (fun (_, p, _) -> p || productVersion)
        |> Seq.map (fun (rx, _, c) -> (rx, c))
        |> List.ofSeq

    let source = File.ReadAllText(fileName)
    let replace s (rx: Regex, c) = rx.Replace(s, fixVersion c)
    let target = allRx |> Seq.fold replace source
    if source <> target then
        trace (sprintf "Updating: %s" fileName)
        File.WriteAllText(fileName, target)

let updateFileVersion = updateVersionInfo false releaseNotes.AssemblyVersion
let updateProductVersion = updateVersionInfo true releaseNotes.AssemblyVersion
        
let build platform sln =
    sln
    |> MSBuildReleaseExt null [ ("Platform", platform) ] "Build"
    |> Log (sprintf "Build-%s-Output: " platform)
   
let keygen snk =
    match testFile snk with
    | true -> ()
    | _ -> snk |> sprintf "-k %s" |> StrongName id

let cleanup () = 
    !! "**/bin" ++ "**/obj" |> CleanDirs
    outDir |> DeleteDir
