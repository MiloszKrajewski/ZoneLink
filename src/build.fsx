#load "common.fsx"

open System
open System.IO
open System.Text.RegularExpressions
open Fake
open Fake.ConfigurationHelper
open Fake.ReleaseNotesHelper
open Fake.StrongNamingHelper
open Common

module Option =
    let def value opt = defaultArg opt value

Target "Clean" (fun _ ->
    cleanup ()
)

Target "KeyGen" (fun _ ->
    "../Placebo.snk" |> keygen
)

Target "Version" (fun _ ->
    !! "**/Properties/AssemblyInfo.cs" |> Seq.iter updateFileVersion
    !! "**/Properties/AssemblyInfo.cs" |> Seq.iter updateProductVersion
)

Target "Build" (fun _ ->
    !! "**.sln" |> build "Any CPU"
)

"Clean" ==> "Build"
"KeyGen" ==> "Build"
"Version" ==> "Build"

RunTargetOrDefault "Build"
