using MTCSharedModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MTCPhoneApp.Services
{
    class MountainTrackerClimbAPIService : IDisposable
    {
        HttpClient ClientConnection;
#if DEBUG
        const string RootURL = "http://localhost:12699/Api/";
#else
        const string RootURL = "http://mtntracker.com/Api/";
#endif

        string BearerToken = null;

        public MountainTrackerClimbAPIService()
        {
            ClientConnection = new HttpClient();
            ClientConnection.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        }

        protected Uri MakeURI(string EndPoint)
        {
            Uri uri = new Uri($"{RootURL}{EndPoint}");
            return uri;
        }

        protected Uri MakeURI<T>(string EndPoint, T obj)
        {
            Type TType = typeof(T);
            PropertyInfo[] Properties = TType.GetProperties();
            string GetVars = "?";
            foreach (PropertyInfo Property in Properties)
            {
                GetVars += $"{Property.Name}={Property.GetValue(obj)}&";
            }
            GetVars = GetVars.Remove(GetVars.Length - 1, 1);
            Uri uri = new Uri($"{RootURL}{EndPoint}{GetVars}");
            return uri;
        }

        protected Uri MakeURI(string EndPoint, int ID)
        {
            Uri uri = new Uri($"{RootURL}{EndPoint}/{ID}");
            return uri;
        }

        protected Uri MakeURI<T>(string EndPoint, int ID, T obj)
        {
            Type TType = typeof(T);
            PropertyInfo[] Properties = TType.GetProperties();
            string GetVars = "?";
            foreach (PropertyInfo Property in Properties)
            {
                GetVars += $"{Property.Name}={Property.GetValue(obj)}&";
            }
            GetVars = GetVars.Remove(GetVars.Length - 1, 1);
            Uri uri = new Uri($"{RootURL}{EndPoint}/{ID}{GetVars}");
            return uri;
        }

        protected async Task<List<T>> GetList<T>(Uri URI, bool AddSecurityTokenHeader = true)
        {
            HttpResponseMessage Response = await ClientConnection.GetAsync(URI);
            if(AddSecurityTokenHeader)
                Response.Headers.Add("Bearer Token", BearerToken);
            if(Response.IsSuccessStatusCode)
            {
                Stream Content = await Response.Content.ReadAsStreamAsync();
                using (Stream Stream = Content)
                using (StreamReader SR = new StreamReader(Stream))
                using (JsonReader Reader = new JsonTextReader(SR))
                {
                    JsonSerializer Serializer = new JsonSerializer();
                    return Serializer.Deserialize<List<T>>(Reader);
                }
            }
            else
                throw new Exception($"{Response.StatusCode}: {Response.ReasonPhrase}");
        }

        protected async Task<T> GetItem<T>(Uri URI, bool AddSecurityTokenHeader = true)
        {
            HttpResponseMessage Response = await ClientConnection.GetAsync(URI);
            if (AddSecurityTokenHeader)
                Response.Headers.Add("Bearer Token", BearerToken);
            if (Response.IsSuccessStatusCode)
            {
                Stream Content = await Response.Content.ReadAsStreamAsync();
                using (Stream Stream = Content)
                using (StreamReader SR = new StreamReader(Stream))
                using (JsonReader Reader = new JsonTextReader(SR))
                {
                    JsonSerializer Serializer = new JsonSerializer();
                    return Serializer.Deserialize<T>(Reader);
                }
            }
            else
                throw new Exception($"{Response.StatusCode}: {Response.ReasonPhrase}");
        }

        const string CountriesController = "Coutries";
        public async Task<List<Country>> GetCountries()
        {
            Uri URL = MakeURI(CountriesController);
            return await GetList<Country>(URL);
        }

        public async Task<Country> GetCountry(int id)
        {
            Uri URL = MakeURI(CountriesController, id);
            return await GetItem<Country>(URL);
        }

        public async Task<List<ProvinceOrState>> GetProvincesOrStates()
        {
            Uri URL = MakeURI(CountriesController);
            return await GetList<ProvinceOrState>(URL);
        }

        public async Task<ProvinceOrState> GetProvinceOrState(int id)
        {
            Uri URL = MakeURI(CountriesController, id);
            return await GetItem<ProvinceOrState>(URL);
        }

        public async Task<List<Region>> GetRegions()
        {
            Uri URL = MakeURI(CountriesController);
            return await GetList<Region>(URL);
        }

        public async Task<Region> GetRegion(int id)
        {
            Uri URL = MakeURI(CountriesController, id);
            return await GetItem<Region>(URL);
        }

        public async Task<List<District>> GetDistricts()
        {
            Uri URL = MakeURI(CountriesController);
            return await GetList<District>(URL);
        }

        public async Task<District> GetDistrict(int id)
        {
            Uri URL = MakeURI(CountriesController, id);
            return await GetItem<District>(URL);
        }

        public async Task<List<DistrictZone>> GetZones()
        {
            Uri URL = MakeURI(CountriesController);
            return await GetList<DistrictZone>(URL);
        }

        public async Task<DistrictZone> GetZone(int id)
        {
            Uri URL = MakeURI(CountriesController, id);
            return await GetItem<DistrictZone>(URL);
        }

        public async Task<List<ZoneArea>> GetAreas()
        {
            Uri URL = MakeURI(CountriesController);
            return await GetList<ZoneArea>(URL);
        }

        public async Task<ZoneArea> GetArea(int id)
        {
            Uri URL = MakeURI(CountriesController, id);
            return await GetItem<ZoneArea>(URL);
        }

        public async Task<List<ClimbingWall>> GetClimbingWalls()
        {
            Uri URL = MakeURI(CountriesController);
            return await GetList<ClimbingWall>(URL);
        }

        public async Task<ClimbingWall> GetClimbingWall(int id)
        {
            Uri URL = MakeURI(CountriesController, id);
            return await GetItem<ClimbingWall>(URL);
        }

        public async Task<List<RockClimbingDifficulty>> GetRockClimbingDifficulties()
        {
            Uri URL = MakeURI(CountriesController);
            return await GetList<RockClimbingDifficulty>(URL);
        }

        public async Task<RockClimbingDifficulty> GetRockClimbingDifficulty(int id)
        {
            Uri URL = MakeURI(CountriesController, id);
            return await GetItem<RockClimbingDifficulty>(URL);
        }

        //public async Task<RouteGear> GetRockClimbingDifficulty(int id)
        //{
        //    Uri URL = MakeURI(CountriesController, id);
        //    return await GetItem<RockClimbingDifficulty>(URL);
        //}

        public void Dispose()
        {
            ClientConnection.Dispose();
        }
    }
}
