namespace AlgoCamp.Service

open System.Runtime.Serialization
open System.ServiceModel

[<DataContract>]
type InnerType = {
        [<DataMember>] mutable id : int
        [<DataMember>] mutable e : int[]
        [<DataMember>] mutable f : int
    }

[<DataContract>]
type CompositeType =  {
     [<DataMember>] mutable a : string
     [<DataMember>] mutable b : int
     [<DataMember>] mutable c : InnerType[]
     [<DataMember>] mutable g : int[]
     }

