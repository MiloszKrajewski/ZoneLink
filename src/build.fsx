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
    
Target "KeyGen" (fun _ ->
    "../privatekey.snk" |> keygen
)

Target "Version" (fun _ ->
    !! "**/Properties/AssemblyInfo.cs" |> Seq.iter updateFileVersion
    !! "**/Properties/AssemblyInfo.cs" |> Seq.iter updateProductVersion
)



RunTargetOrDefault "KeyGen"
