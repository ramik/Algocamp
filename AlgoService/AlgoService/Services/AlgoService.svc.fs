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
    abstract GetDataUsingDataContract: composite:CompositeType -> CompositeType

type AlgoService() =
    interface IAlgoService with
        member this.GetData() =
            WebOperationContext.Current.OutgoingResponse.ContentType <- "text/html"
            WebOperationContext.Current.CreateTextResponse(@"<html><body><h1> Use POST or GTFO </h1></body></html>")

        member this.GetDataUsingDataContract composite =
            match composite.BoolValue with
            | true -> composite.StringValue <- 
                          sprintf "%A%A" composite.StringValue "Suffix"
            | _ -> "do nothing" |> ignore
            composite