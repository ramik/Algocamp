namespace AlgoCamp.Service

open System
open System.ServiceModel
open System.ServiceModel.Web
open System.Diagnostics
open System.IO
open System.Text

[<ServiceContract>]
type IAlgoService =
    [<OperationContract>]
    [<WebGet(UriTemplate = "/")>]
    abstract GetData: unit -> Channels.Message
    [<OperationContract>]
    [<WebInvoke(Method = "POST", UriTemplate = "/test", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)>]
    abstract GetDataUsingDataContract: composite:CompositeType -> CompositeType
    [<OperationContract>]
    [<WebInvoke(Method = "POST", UriTemplate = "/", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)>]
    abstract GetResultList : composite:CompositeType -> int[]

type AlgoService() =
    interface IAlgoService with
        member this.GetData() =
            WebOperationContext.Current.OutgoingResponse.ContentType <- "text/html"
            WebOperationContext.Current.CreateTextResponse(@"<html><body><h1> Use POST or GTFO </h1></body></html>")

        member this.GetResultList composite =
           [1;3] |> Seq.toArray
        
        member this.GetDataUsingDataContract composite =
           { a = composite.a; b = composite.b; c = composite.c; g = composite.g |> Seq.map (fun x -> x + 1) |> Seq.toArray }                                                                           