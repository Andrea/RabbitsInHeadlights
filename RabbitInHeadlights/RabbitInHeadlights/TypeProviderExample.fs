module TypeProviderExample

//Type providers
#if INTERACTIVE

#r "PresentationFramework.dll"
#r "System.Xaml"
#r @"C:\Source\Rabbits\RabbitInHeadlights\packages\FSharp.Data.2.0.8\lib\portable-net40+sl5+wp8+win8\FSharp.Data.dll"
#I "packages/FSharp.Charting.0.90.7"
#load @"C:\Source\RabbitsInHeadlights\RabbitInHeadlights\packages\FSharp.Charting.0.90.7\FSharp.Charting.fsx"
#endif
open System
open FSharp.Data
open FSharp.Charting
open System.IO
 
 [<Literal>]
let path = "C:\Source\Rabbits\IrelandProgrammingLanguages.csv"
type Languages = FSharp.Data.CsvProvider<path>
    
let readLanguageData =     
    
    let data = Languages.Load(new FileStream(path, FileMode.Open))
    printfn "Headers are %A" data.Headers
    printfn "Rows are %A" data.Rows
 
    printfn "Number of languages in production vs hobby"
    
    let split (text:string) =
        text.Split ','
        |> Seq.toList
 
    let splitAndCount string  =
        let languages= split string
        float languages.Length
    
    let reduceLanguageCount langs count=
        count, List.fold (fun acc langCount -> if(int langCount =count) then acc + 1 else acc ) 0 langs
    let languageCount = Seq.toList data.Rows
                        |> List.map ( fun r -> splitAndCount r.``What programming language(s) are you using in production?``)     
    let reducedCount = [for x in 1..7 -> reduceLanguageCount languageCount x]    
    printfn "Number of languges used in production count %A" reducedCount
    
    let hobbiesCount = Seq.toList data.Rows
                        |> List.map ( fun r -> splitAndCount r.``What programming language(s) are you using in your hobby/side projects?``)     
    let hobbiesReducedCount = [for x in 1..7 -> reduceLanguageCount hobbiesCount x]    
    printfn "Number of languges used in hobbies %A" hobbiesReducedCount
    
    let plot = hobbiesReducedCount 
                |> Chart.Line
                |> Chart.WithTitle "Languages used in production"
                |> Chart.WithYAxis( Title = "devs") 
                |> Chart.WithXAxis( Title = "language count") 
    
    
    let mostUsedLanguages =  data.Rows
                             |> Seq.map (fun r-> r.``What programming language(s) are you using in production?``.Split ',' )
                             |> Seq.append (data.Rows |> Seq.map (fun r-> r.``What programming language(s) are you using in your hobby/side projects?``.Split ','))
                             |> Seq.collect (fun row -> row |> Seq.ofArray )                             
                             |> Seq.countBy (fun x-> x.ToLower())                             
                             
                             |> Seq.sortBy(fun x-> -snd x)                             
                             |> Seq.take 6
                             |> Chart.Bar
                             |> Chart.WithXAxis(LabelStyle=new ChartTypes.LabelStyle() 

    0
 
 