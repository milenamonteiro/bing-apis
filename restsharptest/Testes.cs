using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace restsharptest
{
    class Testes
    {
        private static IRestClient client;
        private static IRestResponse response;
        //client = new RestClient("https://app.omie.com.br");
        public static async void ss()
        {
            client = new RestClient("https://marketplace.hivecloud.com.br");
            //var request = new RestRequest("/api/v1/geral/unidade/?JSON={\"call\":\"ListarUnidades\",\"app_key\":\"1560731700\",\"app_secret\":\"226dcf372489bb45ceede61bfd98f0f1\",\"param\":[{\"codigo\":\"\"}]}", Method.POST);
            var request = new RestRequest("/hub/simulacaoFrete/simular?contaId=b8651a4a-a3b1-45a3-b64d-245ae6775db6", Method.POST);
            response = client.Execute(request);
            var responseModel = JsonConvert.DeserializeObject<UnidadeCadastro>(response.Content);



            var baseAddress = new Uri("http://api.cargobr.com/v1/");
            string responseData = "";
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authentication", "");

                using (var content = new StringContent("{\"origin_zipcode\": \"14030360\",\"destination_zipcode\": \"05022060\", \"origin_document\": \"456.252.749-83\",\"destination_document\": \"456.252.749-83\",\"volumes\": [{ \"width\": 0.1,\"height\": 0.2, \"length\": 0.3, \"weight\": 0.4,   \"value\": 1000.5,  \"amount\": 1,  \"object_types\": [\"frageis\"]},{        \"width\": 0.20, \"height\": 0.2,  \"length\": 0.3, \"weight\": 0.4, \"value\": 2000.5,\"amount\": 2,\"object_types\": [\"vidro\"]}]})", System.Text.Encoding.Default, "application/json"))
                {
                    using (var response = await httpClient.PostAsync("freights/quotations/?New%20item=", content))
                    {
                        responseData = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            Console.WriteLine(responseData);
        }

        public static async void ass()
        {
            var baseAddress = new Uri("https://marketplace.hivecloud.com.br/");
            string responseData = "";
            HttpResponseMessage response = new HttpResponseMessage();
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authentication", "");
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
                using (var content = new StringContent("{\"carga\":{\"mercadoriaList\":[{\"medidaVolumeList\":[],\"localOrigem\":{\"municipio\":{\"codigo\":\"3550308\",\"nome\":\"SÃO PAULO\"},\"pais\":{\"codigo\":\"1058\",\"nome\":\"BRASIL\"},\"uf\":{\"codigo\":\"35\",\"sigla\":\"SP\"},\"cep\":\"05311000\",\"bairro\":\"VILA LEOPOLDINA\",\"logradouro\":\"AVENIDA MOFARREJ\"},\"localDestino\":{\"municipio\":{\"codigo\":\"3550308\",\"nome\":\"SÃO PAULO\"},\"pais\":{\"codigo\":\"1058\",\"nome\":\"BRASIL\"},\"uf\":{\"codigo\":\"35\",\"sigla\":\"SP\"},\"cep\":\"05388000\",\"bairro\":\"VILA DALVA\",\"logradouro\":\"RUA JOSÉ DO PATROCÍNIO WAETGE\"},\"ncmList\":[],\"volume\":\"0.002187\",\"pesoBruto\":\"1\",\"valorMercadoria\":\"0\",\"qtdVolumes\":1,\"pesoLiquido\":\"1\"}],\"enderecoLocalColeta\":{\"municipio\":{\"codigo\":\"3550308\",\"nome\":\"SÃO PAULO\"},\"pais\":{\"codigo\":\"1058\",\"nome\":\"BRASIL\"},\"uf\":{\"codigo\":\"35\",\"sigla\":\"SP\"},\"cep\":\"05311000\",\"bairro\":\"VILA LEOPOLDINA\",\"logradouro\":\"AVENIDA MOFARREJ\"},\"enderecoLocalEntrega\":{\"municipio\":{\"codigo\":\"3550308\",\"nome\":\"SÃO PAULO\"},\"pais\":{\"codigo\":\"1058\",\"nome\":\"BRASIL\"},\"uf\":{\"codigo\":\"35\",\"sigla\":\"SP\"},\"cep\":\"05388000\",\"bairro\":\"VILA DALVA\",\"logradouro\":\"RUA JOSÉ DO PATROCÍNIO WAETGE\"},\"tipoCarga\":\"FRACIONADA\",\"tipoServico\":\"TRANSFERENCIA\",\"tipoVeiculo\":\"CARRETA_BAU\"},\"contribuinte\":false,\"qtdEntregas\":1,\"criterioAgrupamento\":\"CARGA_FECHADA\"}", System.Text.Encoding.Default, "application/json"))
                {
                    using (response = await httpClient.PostAsync("hub/simulacaoFrete/simular?contaId=b8651a4a-a3b1-45a3-b64d-245ae6775db6", content))
                    {
                        responseData = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            Console.WriteLine(responseData);
        }

        public static async void bags()
        {
            var baseAddress = new Uri("https://calculafrete.com");
            string responseData = "";
            HttpResponseMessage response = new HttpResponseMessage();
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                using (var content = new StringContent("TipoCargaEnum=0&TotalEixo=2&DistanciaKM=1&PossuiRetorno=1", System.Text.Encoding.UTF8, "application/x-www-form-urlencoded"))
                {
                    using (response = await httpClient.PostAsync("", content))
                    {
                        responseData = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            Console.WriteLine(responseData);
        }

        public static async void hacks()
        {
            var baseAddress = new Uri("https://maps.googleapis.com/maps/api/js/DistanceMatrixService.GetDistanceMatrix?1m1&2sCentro%2CBras%C3%ADlia%2C%20DF&2m1&2sCentro%2CAlcoba%C3%A7a%2C%20BA&3e0&4b0&5b0&6spt-BR&7e0&callback=_xdc_._pmkfzb&key=AIzaSyCMP00Us2BQc-L4YcOSy_MMj1FLLns7hCc&token=104682");
            string responseData = "";
            HttpResponseMessage response = new HttpResponseMessage();
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                using (var content = new StringContent("", System.Text.Encoding.Default, "application/json"))
                {
                    using (response = await httpClient.PostAsync("", content))
                    {
                        responseData = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            Console.WriteLine(responseData);
        }

        private static void LogRequest(IRestRequest request, IRestResponse response, long durationMs)
        {
            var requestToLog = new
            {
                resource = request.Resource,
                // Parameters are custom anonymous objects in order to have the parameter type as a nice string
                // otherwise it will just show the enum value
                parameters = request.Parameters.Select(parameter => new
                {
                    name = parameter.Name,
                    value = parameter.Value,
                    type = parameter.Type.ToString()
                }),
                // ToString() here to have the method as a nice string otherwise it will just show the enum value
                method = request.Method.ToString(),
                // This will generate the actual Uri used in the request
                uri = client.BuildUri(request),
            };

            var responseToLog = new
            {
                statusCode = response.StatusCode,
                content = response.Content,
                headers = response.Headers,
                // The Uri that actually responded (could be different from the requestUri if a redirection occurred)
                responseUri = response.ResponseUri,
                errorMessage = response.ErrorMessage,
            };

            Console.WriteLine(string.Format("Request completed in {0} ms,\n\nRequest: {1}, \n\nResponse: {2}",
                    durationMs,
                    JsonConvert.SerializeObject(requestToLog),
                    JsonConvert.SerializeObject(responseToLog)));
        }
    }
}


//var queryResult = JsonConvert.DeserializeObject<UnidadeCadastro>(response.Content);

//request.AddJsonBody(new Clasehaha{codigo = "" });
//request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);


//request.AddParameter("OMIE_APP_KEY", "818668847997", ParameterType.UrlSegment);
//request.AddParameter("OMIE_APP_SECRET", "b74fed707f9ea9ff149156f7e551490c", ParameterType.UrlSegment);
//request.AddParameter("OMIE_CALL", "ListarUnidades", ParameterType.UrlSegment);

//var json = request.JsonSerializer.Serialize(UnidadeCadastro);

//request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
//request.AddHeader("Content-type", "application/json; encoding=UTF-8");
//request.AddJsonBody(new { codigo = "" });
//request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
//request.AddParameter("application/json", new JavaScriptSerializer().Serialize(jObject.ToString()), ParameterType.RequestBody);

//request.AddParameter("codigo", "L     ", ParameterType.RequestBody);

//string jsonToSend = Serialize.ToJson(uni);
//request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
//request.AddHeader("Content-Type", "application/json; encoding=UTF-8");
//request.JsonSerializer.ContentType = "application/json; encoding=utf-8";

//request.AddParameter("application/json; charset=utf-8", stringo, ParameterType.RequestBody);
//request.AddJsonBody(stringo);
//request.AddParameter("application/json; encoding=utf-8", jsonToSend, ParameterType.RequestBody);

//request.AddParameter(stringo, ParameterType.RequestBody);
//response = client.Execute<List<Clasehaha>>(request);
//request.JsonSerializer = new RestSharpJsonNetSerializer(); 
//var stringo = new RestSharpJsonNetSerializer().Serialize(new { codigo = "" });
//request.AddHeader("Accept", "application/json; encoding=utf-8");
//request.AddHeader("content-type", "application/json; encoding=utf-8");
//request.Parameters.Clear();

//request.AddQueryParameter("OMIE_APP_KEY", "818668847997");
//request.AddQueryParameter("OMIE_APP_SECRET", "b74fed707f9ea9ff149156f7e551490c");
//request.AddQueryParameter("OMIE_CALL", "ListarUnidades");
//request.AddParameter("codigo", "", ParameterType.RequestBody);
//LogRequest(request, response, 1);