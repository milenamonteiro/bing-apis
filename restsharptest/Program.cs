﻿using System;
using System.Net;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Web;
using restsharptest.Ok;

namespace restsharptest
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteMethods();
            Console.ReadKey();
        }

        public static async void ExecuteMethods()
        {
            EnderecoJson origin = await GetAddress("05314-000");
            EnderecoJson destination = await GetAddress("04180-112");
            QueryCoordinates coordinatesorigin = await GetCoordinates(GenerateUri(origin));
            QueryCoordinates coordinatesdestination = await GetCoordinates(GenerateUri(destination));
            var distancematrix = await PostDistance(GenerateJsonBody(coordinatesorigin, coordinatesdestination));
            var frete = await ValorDoFrete(GetDistance(distancematrix));
            Console.WriteLine(frete.ValorFrete);
        }

        public static double GetDistance(DistanceMatrix distanceMatrix)
        {
            foreach (var a in distanceMatrix.ResourceSets)
            {
                foreach (var b in a.Resources)
                {
                    foreach (var c in b.Results)
                    {
                        return c.TravelDistance;
                    }
                }
            }
            return 1;
        }

        public static string GenerateJsonBody(QueryCoordinates origin, QueryCoordinates destination)
        {
            var originarray = CoordinatesArray(origin);
            var destarray = CoordinatesArray(destination);

            Destination[] origins = new Destination[1];
            origins[0] = new Destination
            {
                Latitude = originarray[0],
                Longitude = originarray[1]
            };

            Destination[] destinations = new Destination[1];
            destinations[0] = new Destination
            {
                Latitude = destarray[0],
                Longitude = destarray[1]
            };

            BodyDistanceMatrix body = new BodyDistanceMatrix()
            {
                Origins = origins,
                Destinations = destinations,
                TravelMode = "driving"
            };

            return Serialize.ToJson(body);
        }

        public static double[] CoordinatesArray(QueryCoordinates coordinates)
        {
            double[] array = new double[2];
            foreach (var sets in coordinates.ResourceSets)
            {
                foreach (var a in sets.Resources)
                {
                    int i = 0;
                    foreach (var b in a.GeocodePoints)
                    {
                        foreach (var c in b.Coordinates)
                        {
                            array[i] = c;
                            i++;
                        }
                        if (i == 2)
                            break;
                    }
                }
            }
            return array;
        }

        public static string GenerateUri(EnderecoJson x)
        {
            string end = x.Street + ", " + x.District + ", " + x.City + " - " + x.Uf + ", " + x.Cep + ", Brazil";
            return Uri.EscapeDataString(end);
        }

        private static async Task<EnderecoJson> GetAddress(string cep)
        {
            string responseData;
            var baseAddress = new Uri("http://api.frenet.com.br/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.Add("accept", "application/json");
                httpClient.DefaultRequestHeaders.Add("token", "EFB53FBBRF4CAR4EDARB177R7F076B125EE8");

                using (var response = await httpClient.GetAsync("CEP/Address/" + cep))
                {
                    responseData = await response.Content.ReadAsStringAsync();
                }
            }
            return EnderecoJson.FromJson(responseData);
        }

        private static async Task<QueryCoordinates> GetCoordinates(string address)
        {
            string responseData;
            var baseAddress = new Uri("http://dev.virtualearth.net/REST/v1/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                using (var response = await httpClient.GetAsync("Locations/"+address+"?includeNeighborhood=1&maxResults=1&key=Av9IgsvQJRzGVg0lZV6QFzJJrsI9gW8EOq2vxtZCpYoqBvQtJZYowjyCOXg3YXlz"))
                {
                    responseData = await response.Content.ReadAsStringAsync();
                }
            }
            return QueryCoordinates.FromJson(responseData);
        }

        private static async Task<DistanceMatrix> PostDistance(string body)
        {
            var baseAddress = new Uri("http://dev.virtualearth.net/REST/v1/");
            string responseData = "";
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                using (var content = new StringContent(body, System.Text.Encoding.Default, "application/json"))
                {
                    using (var response = await httpClient.PostAsync("Routes/DistanceMatrix?key=Av9IgsvQJRzGVg0lZV6QFzJJrsI9gW8EOq2vxtZCpYoqBvQtJZYowjyCOXg3YXlz", content))
                    {
                        responseData = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            return DistanceMatrix.FromJson(responseData);
        }

        public static async Task<FreteAntt> ValorDoFrete(double distancia)
        {
            var baseAddress = new Uri("https://calculafrete.com");
            string responseData = "";
            HttpResponseMessage response = new HttpResponseMessage();
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                using (var content = new StringContent("TipoCargaEnum=4&TotalEixo=2&DistanciaKM="+ Convert.ToInt16(distancia) + "&CargaLotacao=0", System.Text.Encoding.UTF8, "application/x-www-form-urlencoded"))
                {
                    using (response = await httpClient.PostAsync("", content))
                    {
                        responseData = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            return FreteAntt.FromJson(responseData);
        }
    }
}