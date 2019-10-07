namespace FHttp

open System
open System.Net
open System.IO

type ResponsePair =
    {
        response: HttpListenerResponse;
        body: string
    }

module Server =

    let http = new HttpListener()

    let setPort (p:int) = 
        let prefix = "http://localhost:" + (string p) + "/"
        http.Prefixes.Add(prefix)

    let getNext () =
        match http.IsListening with
        | false -> http.Start()
        | true -> ()
        let cxt = http.GetContext()
        let req = cxt.Request
        match req.HasEntityBody with
        | false -> { response=cxt.Response; body="" }
        | true ->
            let reader = new StreamReader(req.InputStream, req.ContentEncoding)
            let body = reader.ReadToEnd()
            { response=cxt.Response; body=body }

    let respond (resp:HttpListenerResponse) (msg:string) =
        let buf = System.Text.Encoding.UTF8.GetBytes(msg)
        resp.ContentLength64 <- int64(buf.Length)
        resp.OutputStream.Write(buf, 0, buf.Length)
        resp.OutputStream.Close()

